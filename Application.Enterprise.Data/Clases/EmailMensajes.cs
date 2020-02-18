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
    public class EmailMensajes
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEmailMensajes;

        
        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public EmailMensajes(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public EmailMensajes()
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
            commandEmailMensajes = db.GetStoredProcCommand("PRC_SVDN_EMAIL_SMTPCLIENTS");

            db.AddInParameter(commandEmailMensajes, "i_operation", DbType.String);
            db.AddInParameter(commandEmailMensajes, "i_option", DbType.String);

            db.AddInParameter(commandEmailMensajes, "i_cod", DbType.String);
            db.AddInParameter(commandEmailMensajes, "i_asunto", DbType.String);
            db.AddInParameter(commandEmailMensajes, "i_contenido_html", DbType.String);
            db.AddInParameter(commandEmailMensajes, "i_contenido_txt", DbType.String);
            db.AddInParameter(commandEmailMensajes, "i_adjuntos", DbType.String);
            db.AddInParameter(commandEmailMensajes, "i_estado", DbType.String);

            db.AddOutParameter(commandEmailMensajes, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEmailMensajes, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Clientes Smtp

        /// <summary>
        /// lista todos los clientes smtp
        /// </summary>
        /// <returns></returns>
        public List<EmailMensajesInfo> List()
        {
            db.SetParameterValue(commandEmailMensajes, "i_operation", 'S');
            db.SetParameterValue(commandEmailMensajes, "i_option", 'A');

            List<EmailMensajesInfo> col = new List<EmailMensajesInfo>();

            IDataReader dr = null;

            EmailMensajesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEmailMensajes);

                while (dr.Read())
                {
                    m = Factory.GetEmailMensajes(dr);

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
        public EmailMensajesInfo ListXCod(string cod)
        {
            db.SetParameterValue(commandEmailMensajes, "i_operation", 'S');
            db.SetParameterValue(commandEmailMensajes, "i_option", 'B');
            db.SetParameterValue(commandEmailMensajes, "i_cod", cod);

            IDataReader dr = null;

            EmailMensajesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEmailMensajes);

                if (dr.Read())
                {
                    m = Factory.GetEmailMensajes(dr);
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
        public bool Insert(EmailMensajesInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandEmailMensajes, "i_operation", 'I');
                db.SetParameterValue(commandEmailMensajes, "i_option", 'A');

                db.SetParameterValue(commandEmailMensajes, "i_cod", item.Cod);
                db.SetParameterValue(commandEmailMensajes, "i_asunto", item.Asunto);
                db.SetParameterValue(commandEmailMensajes, "i_contenido_html", item.Contenido_html);
                db.SetParameterValue(commandEmailMensajes, "i_contenido_txt", item.Contenido_txt);
                db.SetParameterValue(commandEmailMensajes, "i_adjuntos", item.Adjuntos);
                db.SetParameterValue(commandEmailMensajes, "i_estado", item.Estado);
                
                dr = db.ExecuteReader(commandEmailMensajes);

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
        public bool Update(EmailMensajesInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandEmailMensajes, "i_operation", 'U');
                db.SetParameterValue(commandEmailMensajes, "i_option", 'A');

                db.SetParameterValue(commandEmailMensajes, "i_cod", item.Cod);
                db.SetParameterValue(commandEmailMensajes, "i_asunto", item.Asunto);
                db.SetParameterValue(commandEmailMensajes, "i_contenido_html", item.Contenido_html);
                db.SetParameterValue(commandEmailMensajes, "i_contenido_txt", item.Contenido_txt);
                db.SetParameterValue(commandEmailMensajes, "i_adjuntos", item.Adjuntos);
                db.SetParameterValue(commandEmailMensajes, "i_estado", item.Estado);

                dr = db.ExecuteReader(commandEmailMensajes);

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
