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
    public class AuditoriaPedidos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAuditoriaPedidos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public AuditoriaPedidos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public AuditoriaPedidos()
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
            commandAuditoriaPedidos = db.GetStoredProcCommand("PRC_SVDN_AUDITORIA_PEDIDOS");

            db.AddInParameter(commandAuditoriaPedidos, "i_operation", DbType.String);
            db.AddInParameter(commandAuditoriaPedidos, "i_option", DbType.String);
            db.AddInParameter(commandAuditoriaPedidos, "i_id", DbType.Int32);

            db.AddOutParameter(commandAuditoriaPedidos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandAuditoriaPedidos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Auditoria de Pedidos

        /// <summary>
        /// Lista todos errores de pedidos sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaPedidosInfo> ListErroresSinConfirmar()
        {
            db.SetParameterValue(commandAuditoriaPedidos, "i_operation", 'S');
            db.SetParameterValue(commandAuditoriaPedidos, "i_option", 'A');

            List<AuditoriaPedidosInfo> col = new List<AuditoriaPedidosInfo>();

            IDataReader dr = null;

            AuditoriaPedidosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAuditoriaPedidos);

                while (dr.Read())
                {
                    m = Factory.GetAuditoriaPedidos(dr);

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
        public bool InsertarPedidos()
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAuditoriaPedidos, "i_operation", 'I');
                db.SetParameterValue(commandAuditoriaPedidos, "i_option", 'A');

                dr = db.ExecuteReader(commandAuditoriaPedidos);

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
                db.SetParameterValue(commandAuditoriaPedidos, "i_operation", 'U');
                db.SetParameterValue(commandAuditoriaPedidos, "i_option", 'A');
                db.SetParameterValue(commandAuditoriaPedidos, "i_id", Id);

                dr = db.ExecuteReader(commandAuditoriaPedidos);

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