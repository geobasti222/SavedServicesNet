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
    public class EmailEnviados
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEmailEnviados;

        
        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public EmailEnviados(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public EmailEnviados()
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
            commandEmailEnviados = db.GetStoredProcCommand("PRC_SVDN_EMAIL_ENVIADOS");

            db.AddInParameter(commandEmailEnviados, "i_operation", DbType.String);
            db.AddInParameter(commandEmailEnviados, "i_option", DbType.String);

            db.AddInParameter(commandEmailEnviados, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandEmailEnviados, "i_mensaje_cod", DbType.String);
            db.AddInParameter(commandEmailEnviados, "i_smtpclient_cod", DbType.String);
            db.AddInParameter(commandEmailEnviados, "i_destinatario", DbType.String);
            db.AddInParameter(commandEmailEnviados, "i_copia", DbType.String);
            db.AddInParameter(commandEmailEnviados, "i_copia_oculta", DbType.String);
            db.AddInParameter(commandEmailEnviados, "i_clientes_nit", DbType.String);
            db.AddInParameter(commandEmailEnviados, "i_SVDN_SUSUARIOS_usuario", DbType.String);

            db.AddOutParameter(commandEmailEnviados, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEmailEnviados, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Clientes Smtp

        /// <summary>
        /// lista todos los clientes smtp
        /// </summary>
        /// <returns></returns>
        public List<EmailEnviadosInfo> List()
        {
            db.SetParameterValue(commandEmailEnviados, "i_operation", 'S');
            db.SetParameterValue(commandEmailEnviados, "i_option", 'A');

            List<EmailEnviadosInfo> col = new List<EmailEnviadosInfo>();

            IDataReader dr = null;

            EmailEnviadosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEmailEnviados);

                while (dr.Read())
                {
                    m = Factory.GetEmailEnviados(dr);

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
        /// lista todos los clientes smtp
        /// </summary>
        /// <returns></returns>
        public List<EmailEnviadosInfo> ListXFechaMensaje(DateTime fecha, string mensajecod)
        {
            db.SetParameterValue(commandEmailEnviados, "i_operation", 'S');
            db.SetParameterValue(commandEmailEnviados, "i_option", 'B');

            db.SetParameterValue(commandEmailEnviados, "i_fecha", fecha);
            db.SetParameterValue(commandEmailEnviados, "i_mensaje_cod", mensajecod);

            List<EmailEnviadosInfo> col = new List<EmailEnviadosInfo>();

            IDataReader dr = null;

            EmailEnviadosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEmailEnviados);

                while (dr.Read())
                {
                    m = Factory.GetEmailEnviados(dr);

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
        /// Insertar un cliente smtp
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(EmailEnviadosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandEmailEnviados, "i_operation", 'I');
                db.SetParameterValue(commandEmailEnviados, "i_option", 'A');

                db.SetParameterValue(commandEmailEnviados, "i_fecha", item.Fecha);
                db.SetParameterValue(commandEmailEnviados, "i_mensaje_cod", item.MensajeCod);
                db.SetParameterValue(commandEmailEnviados, "i_smtpclient_cod", item.SmtpclientCod);
                db.SetParameterValue(commandEmailEnviados, "i_destinatario", item.Destinatario);
                db.SetParameterValue(commandEmailEnviados, "i_copia", item.Copia);
                db.SetParameterValue(commandEmailEnviados, "i_copia_oculta", item.CopiaOculta);
                db.SetParameterValue(commandEmailEnviados, "i_clientes_nit", item.ClientesNit);
                db.SetParameterValue(commandEmailEnviados, "i_SVDN_SUSUARIOS_usuario", item.SVDNSUSUARIOSUsuario);
                
                dr = db.ExecuteReader(commandEmailEnviados);

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
        public bool Update(EmailEnviadosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandEmailEnviados, "i_operation", 'U');
                db.SetParameterValue(commandEmailEnviados, "i_option", 'A');

                db.SetParameterValue(commandEmailEnviados, "i_fecha", item.Fecha);
                db.SetParameterValue(commandEmailEnviados, "i_mensaje_cod", item.MensajeCod);
                db.SetParameterValue(commandEmailEnviados, "i_smtpclient_cod", item.SmtpclientCod);
                db.SetParameterValue(commandEmailEnviados, "i_destinatario", item.Destinatario);
                db.SetParameterValue(commandEmailEnviados, "i_copia", item.Copia);
                db.SetParameterValue(commandEmailEnviados, "i_copia_oculta", item.CopiaOculta);
                db.SetParameterValue(commandEmailEnviados, "i_clientes_nit", item.ClientesNit);
                db.SetParameterValue(commandEmailEnviados, "i_SVDN_SUSUARIOS_usuario", item.SVDNSUSUARIOSUsuario);

                dr = db.ExecuteReader(commandEmailEnviados);

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
