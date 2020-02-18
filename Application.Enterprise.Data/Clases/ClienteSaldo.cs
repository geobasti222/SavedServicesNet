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
    public class ClienteSaldo
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandClienteSaldo;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ClienteSaldo(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ClienteSaldo()
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
            commandClienteSaldo = db.GetStoredProcCommand("PRC_SVDN_CLIENTESALDO");

            db.AddInParameter(commandClienteSaldo, "i_operation", DbType.String);
            db.AddInParameter(commandClienteSaldo, "i_option", DbType.String);

            db.AddInParameter(commandClienteSaldo, "i_nit", DbType.String);
            db.AddInParameter(commandClienteSaldo, "i_mes", DbType.String);

            db.AddOutParameter(commandClienteSaldo, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandClienteSaldo, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de ClienteSaldo

        /// <summary>
        /// Lista todos los Cambios de una empresaria
        /// </summary>
        /// <returns></returns>
        public ClienteSaldoInfo ListXNit(string nit, string mes)
        {
            db.SetParameterValue(commandClienteSaldo, "i_operation", 'S');
            db.SetParameterValue(commandClienteSaldo, "i_option", 'A');
            db.SetParameterValue(commandClienteSaldo, "i_nit", nit);
            db.SetParameterValue(commandClienteSaldo, "i_mes", mes);
            
            IDataReader dr = null;

            ClienteSaldoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteSaldo);
                if (dr.Read())
                {
                    m = Factory.GetClienteSaldo(dr);
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
