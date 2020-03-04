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
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Notifica
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandNotifica;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Notifica(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Notifica()
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
            commandNotifica = db.GetStoredProcCommand("PRC_SVDN_NOTIFICA");

            db.AddInParameter(commandNotifica, "i_operation", DbType.String);
            db.AddInParameter(commandNotifica, "i_option", DbType.String);

            db.AddInParameter(commandNotifica, "i_mt_id", DbType.Int32);
            db.AddInParameter(commandNotifica, "i_documento", DbType.String);
            db.AddInParameter(commandNotifica, "i_nit", DbType.String);
            db.AddInParameter(commandNotifica, "i_estado", DbType.Boolean);
            db.AddInParameter(commandNotifica, "i_fechaenvio", DbType.DateTime);
   
            db.AddOutParameter(commandNotifica, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandNotifica, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Notifica

        /// <summary>
        /// Lista todas las cuentas por cobrar (Notifica).
        /// </summary>
        /// <returns></returns>
        public List<NotificaInfo> List()
        {
            db.SetParameterValue(commandNotifica, "i_operation", 'S');
            db.SetParameterValue(commandNotifica, "i_option", 'A');

            List<NotificaInfo> col = new List<NotificaInfo>();

            IDataReader dr = null;

            NotificaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandNotifica);

                while (dr.Read())
                {
                    m = Factory.GetNotifica(dr);

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
        /// Realiza la actualizacion del estado de la asignacion de premio de bienvenida.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdateNotifica(string Nit, int Mt_Id, string Documento)

        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandNotifica, "i_operation", 'U');
                db.SetParameterValue(commandNotifica, "i_option", 'A');
                db.SetParameterValue(commandNotifica, "i_nit", Nit);
                db.SetParameterValue(commandNotifica, "i_mt_id", Mt_Id);
                db.SetParameterValue(commandNotifica, "i_documento", Documento);

                dr = db.ExecuteReader(commandNotifica);

                transOk = true;

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

            return transOk;
        }


        #endregion
    }
}