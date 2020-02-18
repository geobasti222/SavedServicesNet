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
    public class Lider
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandLider;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Lider(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Lider()
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
            commandLider = db.GetStoredProcCommand("PRC_SVDN_LIDER");

            db.AddInParameter(commandLider, "i_operation", DbType.String);
            db.AddInParameter(commandLider, "i_option", DbType.String);
            db.AddInParameter(commandLider, "i_lider", DbType.String);
            db.AddInParameter(commandLider, "i_nombres", DbType.String);
            db.AddInParameter(commandLider, "i_cedula", DbType.String);
            db.AddInParameter(commandLider, "i_zona", DbType.String);
            db.AddInParameter(commandLider, "i_vendedor", DbType.String);

            db.AddOutParameter(commandLider, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandLider, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Lider

        /// <summary>
        /// Lista todos los lideres
        /// </summary>
        /// <returns></returns>
        public List<LiderInfo> List()
        {
            db.SetParameterValue(commandLider, "i_operation", 'S');
            db.SetParameterValue(commandLider, "i_option", 'A');

            List<LiderInfo> col = new List<LiderInfo>();

            IDataReader dr = null;

            LiderInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLider);

                while (dr.Read())
                {
                    m = Factory.GetLider(dr);

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
        /// Lista todos los lideres x zona
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<LiderInfo> ListxZona(string Zona)
        {
            db.SetParameterValue(commandLider, "i_operation", 'S');
            db.SetParameterValue(commandLider, "i_option", 'B');
            db.SetParameterValue(commandLider, "i_zona", Zona);

            List<LiderInfo> col = new List<LiderInfo>();

            IDataReader dr = null;

            LiderInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLider);

                while (dr.Read())
                {
                    m = Factory.GetLider(dr);

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
        /// Lista la informacion de un lider especifico.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public LiderInfo ListxIdLider(string IdLider)
        {
            db.SetParameterValue(commandLider, "i_operation", 'S');
            db.SetParameterValue(commandLider, "i_option", 'C');
            db.SetParameterValue(commandLider, "i_lider", IdLider);

            IDataReader dr = null;

            LiderInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLider);

                while (dr.Read())
                {
                    m = Factory.GetLider(dr);
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