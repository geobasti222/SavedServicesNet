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
    public class Auditoria
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAuditoria;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Auditoria(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Auditoria()
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
            commandAuditoria = db.GetStoredProcCommand("PRC_SVDN_AUDITORIA");

            db.AddInParameter(commandAuditoria, "i_operation", DbType.String);
            db.AddInParameter(commandAuditoria, "i_option", DbType.String);
            db.AddInParameter(commandAuditoria, "i_aud_id", DbType.Int32);
            db.AddInParameter(commandAuditoria, "i_aud_fechasistema", DbType.DateTime);
            db.AddInParameter(commandAuditoria, "i_aud_usuario", DbType.String);
            db.AddInParameter(commandAuditoria, "i_aud_proceso", DbType.String);
            

            db.AddOutParameter(commandAuditoria, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandAuditoria, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Auditoria

        /// <summary>
        /// lista todos las Auditorias existentes.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaInfo> List()
        {
            db.SetParameterValue(commandAuditoria, "i_operation", 'S');
            db.SetParameterValue(commandAuditoria, "i_option", 'A');

            List<AuditoriaInfo> col = new List<AuditoriaInfo>();

            IDataReader dr = null;

            AuditoriaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAuditoria);

                while (dr.Read())
                {
                    m = Factory.GetAuditoria(dr);

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
        /// Guarda un proceso de auditoria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(AuditoriaInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAuditoria, "i_operation", 'I');
                db.SetParameterValue(commandAuditoria, "i_option", 'A');

                db.SetParameterValue(commandAuditoria, "i_aud_fechasistema", item.FechaSistema);
                db.SetParameterValue(commandAuditoria, "i_aud_usuario", item.Usuario);
                db.SetParameterValue(commandAuditoria, "i_aud_proceso", item.Proceso);

                dr = db.ExecuteReader(commandAuditoria);

                okTrans = true;
            }
            catch (Exception ex)
            {
                okTrans = false;

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
            return okTrans;
        }

        #endregion
    }
}