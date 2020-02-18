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
    public class TipoPedidoMinimo
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTipoPedidoMinimo;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TipoPedidoMinimo(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TipoPedidoMinimo()
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
            commandTipoPedidoMinimo = db.GetStoredProcCommand("PRC_SVDN_TIPOPEDIDOMINIMO");

            db.AddInParameter(commandTipoPedidoMinimo, "i_operation", DbType.String);
            db.AddInParameter(commandTipoPedidoMinimo, "i_option", DbType.String);
            db.AddInParameter(commandTipoPedidoMinimo, "i_tpm_id", DbType.Int32);
            db.AddInParameter(commandTipoPedidoMinimo, "i_tpm_nombre", DbType.String);
            db.AddInParameter(commandTipoPedidoMinimo, "i_tpm_valor", DbType.Decimal);
            db.AddInParameter(commandTipoPedidoMinimo, "i_tpm_valoroutletnivi", DbType.Decimal);
            db.AddInParameter(commandTipoPedidoMinimo, "i_tpm_valoroutletpisame", DbType.Decimal);
            db.AddInParameter(commandTipoPedidoMinimo, "i_tmp_textoamostrar", DbType.Decimal);

            db.AddOutParameter(commandTipoPedidoMinimo, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTipoPedidoMinimo, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de TipoPedidoMinimo

        /// <summary>
        /// -Lista todos los tipos de pedido minimo.
        /// </summary>
        /// <returns></returns>
        public List<TipoPedidoMinimoInfo> List()
        {
            db.SetParameterValue(commandTipoPedidoMinimo, "i_operation", 'S');
            db.SetParameterValue(commandTipoPedidoMinimo, "i_option", 'A');

            List<TipoPedidoMinimoInfo> col = new List<TipoPedidoMinimoInfo>();

            IDataReader dr = null;

            TipoPedidoMinimoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTipoPedidoMinimo);

                while (dr.Read())
                {
                    m = Factory.GetTipoPedidoMinimo(dr);

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
        /// Lista un tipo de pedido minimo x id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public TipoPedidoMinimoInfo ListxId(int Id)
        {
            db.SetParameterValue(commandTipoPedidoMinimo, "i_operation", 'S');
            db.SetParameterValue(commandTipoPedidoMinimo, "i_option", 'B');
            db.SetParameterValue(commandTipoPedidoMinimo, "i_tpm_id", Id);

            IDataReader dr = null;

            TipoPedidoMinimoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTipoPedidoMinimo);

                while (dr.Read())
                {
                    m = Factory.GetTipoPedidoMinimo(dr);
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
        /// Realiza la actualizacion de los valores de un tipo de pedido minimo.
        /// </summary>
        /// <param name="objTipoPedidoMinimoInfo"></param>
        /// <returns></returns>
        public bool Update(TipoPedidoMinimoInfo objTipoPedidoMinimoInfo)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandTipoPedidoMinimo, "i_operation", 'U');
                db.SetParameterValue(commandTipoPedidoMinimo, "i_option", 'A');
                db.SetParameterValue(commandTipoPedidoMinimo, "i_tpm_id", objTipoPedidoMinimoInfo.Id);
                db.SetParameterValue(commandTipoPedidoMinimo, "i_tpm_valor", objTipoPedidoMinimoInfo.Valor);
                db.SetParameterValue(commandTipoPedidoMinimo, "i_tpm_valoroutletnivi", objTipoPedidoMinimoInfo.ValorOutletNivi);
                db.SetParameterValue(commandTipoPedidoMinimo, "i_tpm_valoroutletpisame", objTipoPedidoMinimoInfo.ValorOutletPisame);
                db.SetParameterValue(commandTipoPedidoMinimo, "i_tmp_textoamostrar", objTipoPedidoMinimoInfo.TextoAMostrar);

                dr = db.ExecuteReader(commandTipoPedidoMinimo);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = objTipoPedidoMinimoInfo.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó cambio de valor del tipo de pedido minimo.  Tipo:" + objTipoPedidoMinimoInfo.Id + " (1 = Nivi)(2 = Pisame)(3 = Mixto),   Valor: " + objTipoPedidoMinimoInfo.Valor + ", Valor Outlet Nivi: " + objTipoPedidoMinimoInfo.ValorOutletNivi + ", Valor Outlet Pisame:" + objTipoPedidoMinimoInfo.ValorOutletPisame + ", Texto a Mostrar:" + objTipoPedidoMinimoInfo.TextoAMostrar + ". Acción Realizada por el Usuario: " + objTipoPedidoMinimoInfo.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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