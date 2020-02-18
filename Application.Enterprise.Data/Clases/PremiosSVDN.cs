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
    public class PremiosSVDN
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosSVDN;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosSVDN(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosSVDN()
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
            commandPremiosSVDN = db.GetStoredProcCommand("PRC_SVDN_SIESA_PREMIOSJA");

           
            db.AddInParameter(commandPremiosSVDN, "i_option", DbType.String);

            db.AddInParameter(commandPremiosSVDN, "i_nit", DbType.String);
            db.AddInParameter(commandPremiosSVDN, "i_campanaActual", DbType.String);
            db.AddInParameter(commandPremiosSVDN, "i_zona", DbType.String);
            db.AddInParameter(commandPremiosSVDN, "i_numeroPedido", DbType.String);
           
            db.AddOutParameter(commandPremiosSVDN, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosSVDN, "o_err_msg", DbType.String, 1000);

        }
        #endregion



       /// <summary>
       /// calcular premio
       /// </summary>
       /// <param name="pedido"></param>
       /// <returns></returns>
        public bool ganarPremio(string  pedido)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                
                db.SetParameterValue(commandPremiosSVDN, "i_option", '1');
                
                db.SetParameterValue(commandPremiosSVDN, "i_numeroPedido", pedido);
                
                dr = db.ExecuteReader(commandPremiosSVDN);

                oktrans = true;
            }
            catch (Exception ex)
            {
                oktrans = false;

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
            return oktrans;
        }


        /// <summary>
        /// Inserta el premio en el pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public bool insertarPremio(string pedido)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                
                db.SetParameterValue(commandPremiosSVDN, "i_option", '5');

                db.SetParameterValue(commandPremiosSVDN, "i_numeroPedido", pedido);

                dr = db.ExecuteReader(commandPremiosSVDN);

                oktrans = true;
            }
            catch (Exception ex)
            {
                oktrans = false;

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
            return oktrans;
        }
    }
}
