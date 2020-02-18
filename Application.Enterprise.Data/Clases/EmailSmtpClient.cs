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
    public class EmailSmtpClient
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEmailSmtpClient;

        
        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public EmailSmtpClient(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public EmailSmtpClient()
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
            commandEmailSmtpClient = db.GetStoredProcCommand("PRC_SVDN_EMAIL_SMTPCLIENTS");

            db.AddInParameter(commandEmailSmtpClient, "i_operation", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_option", DbType.String);

            db.AddInParameter(commandEmailSmtpClient, "i_cod", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_credencialuser", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_credencialpass", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_port", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_host", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_enablessl", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_nombre", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_email", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_maximoenvios", DbType.String);
            db.AddInParameter(commandEmailSmtpClient, "i_estado", DbType.Int32);

            db.AddOutParameter(commandEmailSmtpClient, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEmailSmtpClient, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Clientes Smtp

        /// <summary>
        /// lista todos los clientes smtp
        /// </summary>
        /// <returns></returns>
        public List<EmailSmtpClientInfo> List()
        {
            db.SetParameterValue(commandEmailSmtpClient, "i_operation", 'S');
            db.SetParameterValue(commandEmailSmtpClient, "i_option", 'A');

            List<EmailSmtpClientInfo> col = new List<EmailSmtpClientInfo>();

            IDataReader dr = null;

            EmailSmtpClientInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEmailSmtpClient);

                while (dr.Read())
                {
                    m = Factory.GetEmailSmtpClient(dr);

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
        /// Trae cliente smtp por codigo
        /// </summary>
        /// <returns></returns>
        public EmailSmtpClientInfo ListXCod(string cod)
        {
            db.SetParameterValue(commandEmailSmtpClient, "i_operation", 'S');
            db.SetParameterValue(commandEmailSmtpClient, "i_option", 'B');
            db.SetParameterValue(commandEmailSmtpClient, "i_cod", cod);

            IDataReader dr = null;

            EmailSmtpClientInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEmailSmtpClient);

                if (dr.Read())
                {
                    m = Factory.GetEmailSmtpClient(dr);
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

        /// <summary>
        /// Insertar un cliente smtp
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(EmailSmtpClientInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandEmailSmtpClient, "i_operation", 'I');
                db.SetParameterValue(commandEmailSmtpClient, "i_option", 'A');

                db.SetParameterValue(commandEmailSmtpClient, "i_cod", item.Cod);
                db.SetParameterValue(commandEmailSmtpClient, "i_credencialuser", item.CredencialUser);
                db.SetParameterValue(commandEmailSmtpClient, "i_credencialpass", item.CredencialPass);
                db.SetParameterValue(commandEmailSmtpClient, "i_port", item.Port);
                db.SetParameterValue(commandEmailSmtpClient, "i_host", item.Host);
                db.SetParameterValue(commandEmailSmtpClient, "i_enablessl", item.Enablessl);
                db.SetParameterValue(commandEmailSmtpClient, "i_nombre", item.Nombre);
                db.SetParameterValue(commandEmailSmtpClient, "i_email", item.Email);
                db.SetParameterValue(commandEmailSmtpClient, "i_maximoenvios", item.MaximoEnvios);
                db.SetParameterValue(commandEmailSmtpClient, "i_estado", item.Estado);
                
                dr = db.ExecuteReader(commandEmailSmtpClient);

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

        /// <summary>
        /// Actualizar un cliente smtp
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(EmailSmtpClientInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandEmailSmtpClient, "i_operation", 'U');
                db.SetParameterValue(commandEmailSmtpClient, "i_option", 'A');

                db.SetParameterValue(commandEmailSmtpClient, "i_cod", item.Cod);
                db.SetParameterValue(commandEmailSmtpClient, "i_credencialuser", item.CredencialUser);
                db.SetParameterValue(commandEmailSmtpClient, "i_credencialpass", item.CredencialPass);
                db.SetParameterValue(commandEmailSmtpClient, "i_port", item.Port);
                db.SetParameterValue(commandEmailSmtpClient, "i_host", item.Host);
                db.SetParameterValue(commandEmailSmtpClient, "i_enablessl", item.Enablessl);
                db.SetParameterValue(commandEmailSmtpClient, "i_nombre", item.Nombre);
                db.SetParameterValue(commandEmailSmtpClient, "i_email", item.Email);
                db.SetParameterValue(commandEmailSmtpClient, "i_maximoenvios", item.MaximoEnvios);
                db.SetParameterValue(commandEmailSmtpClient, "i_estado", item.Estado);

                dr = db.ExecuteReader(commandEmailSmtpClient);

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
