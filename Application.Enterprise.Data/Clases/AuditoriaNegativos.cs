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
    public class AuditoriaNegativos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAuditoriaNegativos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public AuditoriaNegativos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public AuditoriaNegativos()
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
            commandAuditoriaNegativos = db.GetStoredProcCommand("PRC_SVDN_AUDITORIA_NEGATIVOS");

            db.AddInParameter(commandAuditoriaNegativos, "i_operation", DbType.String);
            db.AddInParameter(commandAuditoriaNegativos, "i_option", DbType.String);
            db.AddInParameter(commandAuditoriaNegativos, "i_aun_id", DbType.Int32);

            db.AddOutParameter(commandAuditoriaNegativos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandAuditoriaNegativos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Auditoria de Negativos

        /// <summary>
        /// Lista todos errores de negativos sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaNegativosInfo> ListErroresSinConfirmar()
        {
            db.SetParameterValue(commandAuditoriaNegativos, "i_operation", 'S');
            db.SetParameterValue(commandAuditoriaNegativos, "i_option", 'A');

            List<AuditoriaNegativosInfo> col = new List<AuditoriaNegativosInfo>();

            IDataReader dr = null;

            AuditoriaNegativosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAuditoriaNegativos);

                while (dr.Read())
                {
                    m = Factory.GetAuditoriaNegativos(dr);

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
        /// Guarda si existe un negativo en la auditoria marcada sin confirmar.
        /// </summary>
        /// <returns></returns>
        public bool InsertarNegativos()
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAuditoriaNegativos, "i_operation", 'I');
                db.SetParameterValue(commandAuditoriaNegativos, "i_option", 'A');

                dr = db.ExecuteReader(commandAuditoriaNegativos);

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
        /// Realiza la actualizacion de la auditoria enviada por correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateIdConfirmado(int Id)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAuditoriaNegativos, "i_operation", 'U');
                db.SetParameterValue(commandAuditoriaNegativos, "i_option", 'A');
                db.SetParameterValue(commandAuditoriaNegativos, "i_aun_id", Id);

                dr = db.ExecuteReader(commandAuditoriaNegativos);

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