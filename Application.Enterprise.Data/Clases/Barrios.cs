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
    public class Barrios
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandBarrios;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Barrios(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Barrios()
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
            commandBarrios = db.GetStoredProcCommand("PRC_SVDN_BARRIOS");

            db.AddInParameter(commandBarrios, "i_operation", DbType.String);
            db.AddInParameter(commandBarrios, "i_option", DbType.String);
            db.AddInParameter(commandBarrios, "i_bar_codbarrio", DbType.Int32);
            db.AddInParameter(commandBarrios, "i_bar_nombre", DbType.String);
            db.AddInParameter(commandBarrios, "i_ciu_codciudad", DbType.Int32);

            db.AddOutParameter(commandBarrios, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandBarrios, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Barrios

        /// <summary>
        /// Lista todos los barrios
        /// </summary>
        /// <returns></returns>
        public List<BarriosInfo> List()
        {
            db.SetParameterValue(commandBarrios, "i_operation", 'S');
            db.SetParameterValue(commandBarrios, "i_option", 'A');

            List<BarriosInfo> col = new List<BarriosInfo>();

            IDataReader dr = null;

            BarriosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandBarrios);

                while (dr.Read())
                {
                    m = Factory.GetBarrios(dr);

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
        /// Lista todos los barrios de una ciudad especifica.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <returns></returns>
        public List<BarriosInfo> ListxCiudad(int CodigoCiudad)
        {
            db.SetParameterValue(commandBarrios, "i_operation", 'S');
            db.SetParameterValue(commandBarrios, "i_option", 'B');
            db.SetParameterValue(commandBarrios, "i_ciu_codciudad", CodigoCiudad);

            List<BarriosInfo> col = new List<BarriosInfo>();

            IDataReader dr = null;

            BarriosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandBarrios);

                while (dr.Read())
                {
                    m = Factory.GetBarrios(dr);

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

        #endregion
    }
}