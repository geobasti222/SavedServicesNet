using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class CentroOperacion
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCentroOperacion;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CentroOperacion(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CentroOperacion()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        /// <summary>
        ///  Metodo para configurar el comando de la DatabaseFactory
        /// </summary>
        private void Config()
        {
            commandCentroOperacion = db.GetStoredProcCommand("PRC_SVDN_CENTROSOPERACION");

            db.AddInParameter(commandCentroOperacion, "i_operation", DbType.String);
            db.AddInParameter(commandCentroOperacion, "i_option", DbType.String);

            db.AddInParameter(commandCentroOperacion, "i_id", DbType.Int32);
            db.AddInParameter(commandCentroOperacion, "i_codigocentroop", DbType.String);
            db.AddInParameter(commandCentroOperacion, "i_nombrecentroop", DbType.String);
            db.AddInParameter(commandCentroOperacion, "i_textoempresaria", DbType.String);
            db.AddInParameter(commandCentroOperacion, "i_entregarensitio", DbType.Boolean);
            db.AddInParameter(commandCentroOperacion, "i_estado", DbType.Boolean);

            db.AddOutParameter(commandCentroOperacion, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCentroOperacion, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Centro de Operacion

        /// <summary>
        /// lista todos los centro de operacion existentes activos.
        /// </summary>
        /// <returns></returns>
        public List<CentroOperacionInfo> List()
        {
            db.SetParameterValue(commandCentroOperacion, "i_operation", 'S');
            db.SetParameterValue(commandCentroOperacion, "i_option", 'A');

            List<CentroOperacionInfo> col = new List<CentroOperacionInfo>();

            IDataReader dr = null;

            CentroOperacionInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCentroOperacion);

                while (dr.Read())
                {
                    m = Factory.GetCentroOperacion(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// lista un centro de operacion especifico.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CentroOperacionInfo ListxId(int Id)
        {
            db.SetParameterValue(commandCentroOperacion, "i_operation", 'S');
            db.SetParameterValue(commandCentroOperacion, "i_option", 'B');
            db.SetParameterValue(commandCentroOperacion, "i_id", Id);

            IDataReader dr = null;

            CentroOperacionInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCentroOperacion);

                while (dr.Read())
                {
                    m = Factory.GetCentroOperacion(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }

        #endregion
    }
}