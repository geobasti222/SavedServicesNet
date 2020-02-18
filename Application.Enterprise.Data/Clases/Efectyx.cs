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
    /// JA
    /// </summary>
    public class Efectyx
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEfecty;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Efectyx(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Efectyx()
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
            commandEfecty = db.GetStoredProcCommand("PRC_SVDN_SIESA_EFECTY");

            db.AddInParameter(commandEfecty, "i_operation", DbType.String);
            db.AddInParameter(commandEfecty, "i_option", DbType.String);            

            db.AddOutParameter(commandEfecty, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEfecty, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        /// <summary>
        /// Traer los saldos de la cartera por mes
        /// </summary>
        /// <returns></returns>
        public DataTable traerCarteraSaldos()
        {
            db.SetParameterValue(commandEfecty, "i_operation", 'S');
            db.SetParameterValue(commandEfecty, "i_option", 'A');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandEfecty);

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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

            return dt;
        }


        /// <summary>
        /// Traer llos totales linea 03
        /// </summary>
        /// <returns></returns>
        public DataTable traerTotales()
        {
            db.SetParameterValue(commandEfecty, "i_operation", 'S');
            db.SetParameterValue(commandEfecty, "i_option", 'B');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandEfecty);

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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

            return dt;
        }
    }
}
