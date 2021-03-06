﻿using System;
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
    public class Mail
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMail;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Mail(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Mail()
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
            commandMail = db.GetStoredProcCommand("PRC_SVDN_MAIL");

            db.AddInParameter(commandMail, "i_operation", DbType.String);
            db.AddInParameter(commandMail, "i_option", DbType.String);
            db.AddInParameter(commandMail, "i_mai_id", DbType.Int32);
            db.AddInParameter(commandMail, "i_mai_emailpara", DbType.String);
            db.AddInParameter(commandMail, "i_mai_emailparanivi", DbType.String);
            db.AddInParameter(commandMail, "i_mai_emaildesde", DbType.String);
            db.AddInParameter(commandMail, "i_mai_asunto", DbType.String);
            db.AddInParameter(commandMail, "i_mai_cuerpomsj", DbType.String);
            db.AddInParameter(commandMail, "i_mai_servidorcorreo", DbType.String);
            db.AddInParameter(commandMail, "i_mai_puerto", DbType.Int32);
            db.AddInParameter(commandMail, "i_mai_usuario", DbType.String);
            db.AddInParameter(commandMail, "i_mai_password", DbType.String);
            db.AddInParameter(commandMail, "i_mai_autenticacion", DbType.Boolean);
            db.AddInParameter(commandMail, "i_mai_host", DbType.String);
            db.AddInParameter(commandMail, "i_mai_activo", DbType.Int32);
            db.AddInParameter(commandMail, "i_mti_id", DbType.Int32);

            db.AddOutParameter(commandMail, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMail, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Mail


        /// <summary>
        /// Lista la configuracion para enviar correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SmtpMailInfo ListxId(int Id)
        {
            db.SetParameterValue(commandMail, "i_operation", 'S');
            db.SetParameterValue(commandMail, "i_option", 'A');
            db.SetParameterValue(commandMail, "i_mai_id", Id);

            IDataReader dr = null;

            SmtpMailInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMail);

                if (dr.Read())
                {
                    m = Factory.GetMail(dr);
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
        /// Lista la configuracion de un mail por tipo
        /// </summary>
        /// <param name="IdTipoMensaje"></param>
        /// <returns></returns>
        public SmtpMailInfo ListxTipoMensaje(int IdTipoMensaje)
        {
            db.SetParameterValue(commandMail, "i_operation", 'S');
            db.SetParameterValue(commandMail, "i_option", 'B');
            db.SetParameterValue(commandMail, "i_mti_id", IdTipoMensaje);

            IDataReader dr = null;

            SmtpMailInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMail);

                if (dr.Read())
                {
                    m = Factory.GetMail(dr);
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