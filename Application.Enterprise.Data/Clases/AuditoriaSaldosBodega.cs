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
    public class AuditoriaSaldosBodega
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAuditoriaSaldosBodega;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public AuditoriaSaldosBodega(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public AuditoriaSaldosBodega()
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
            commandAuditoriaSaldosBodega = db.GetStoredProcCommand("PRC_SVDN_AUDITORIA_SALDOSBODEGA");

            db.AddInParameter(commandAuditoriaSaldosBodega, "i_operation", DbType.String);
            db.AddInParameter(commandAuditoriaSaldosBodega, "i_option", DbType.String);
            db.AddInParameter(commandAuditoriaSaldosBodega, "i_aud_id", DbType.Int32);

            db.AddOutParameter(commandAuditoriaSaldosBodega, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandAuditoriaSaldosBodega, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Auditoria de Saldos Bodega

        /// <summary>
        /// Lista todos errores de saldos bodega sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaSaldosBodegaInfo> ListErroresSinConfirmar()
        {
            db.SetParameterValue(commandAuditoriaSaldosBodega, "i_operation", 'S');
            db.SetParameterValue(commandAuditoriaSaldosBodega, "i_option", 'A');

            List<AuditoriaSaldosBodegaInfo> col = new List<AuditoriaSaldosBodegaInfo>();

            IDataReader dr = null;

            AuditoriaSaldosBodegaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAuditoriaSaldosBodega);

                while (dr.Read())
                {
                    m = Factory.GetAuditoriaSaldosBodega(dr);

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
                db.SetParameterValue(commandAuditoriaSaldosBodega, "i_operation", 'U');
                db.SetParameterValue(commandAuditoriaSaldosBodega, "i_option", 'A');
                db.SetParameterValue(commandAuditoriaSaldosBodega, "i_aud_id", Id);

                dr = db.ExecuteReader(commandAuditoriaSaldosBodega);

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