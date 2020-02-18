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
    public class PuntosSaved
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPuntosSaved;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PuntosSaved(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PuntosSaved()
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
            commandPuntosSaved = db.GetStoredProcCommand("PRC_SVDN_PUNTOS_SAVED");

            db.AddInParameter(commandPuntosSaved, "i_operation", DbType.String);
            db.AddInParameter(commandPuntosSaved, "i_option", DbType.String);

            db.AddInParameter(commandPuntosSaved, "i_numeropedido", DbType.String);
            db.AddInParameter(commandPuntosSaved, "i_nit", DbType.String);
            db.AddInParameter(commandPuntosSaved, "i_campana", DbType.String);
            db.AddInParameter(commandPuntosSaved, "i_tipo", DbType.String);
            db.AddInParameter(commandPuntosSaved, "i_cantidad", DbType.Int32);
            db.AddInParameter(commandPuntosSaved, "i_movimiento", DbType.String);
            db.AddInParameter(commandPuntosSaved, "i_procesado", DbType.Int32);
            db.AddOutParameter(commandPuntosSaved, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPuntosSaved, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de PuntosSaved

        /// <summary>
        /// lista los puntos efectivos de una empresaria
        /// </summary>
        /// <returns></returns>
        public int ConsultarPuntosEfectivosEmpresaria(string nit)
        {
            db.SetParameterValue(commandPuntosSaved, "i_operation", 'S');
            db.SetParameterValue(commandPuntosSaved, "i_option", 'A');
            db.SetParameterValue(commandPuntosSaved, "i_nit", nit);

            int PuntosEmpresaria = 0;

            try
            {
                PuntosEmpresaria = (int)db.ExecuteScalar(commandPuntosSaved);
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

            return PuntosEmpresaria;
        }

        /// <summary>
        /// Guarda un PuntosSaved nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertDetallePuntos(PuntosSavedInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPuntosSaved, "i_operation", 'I');
                db.SetParameterValue(commandPuntosSaved, "i_option", 'A');
                db.SetParameterValue(commandPuntosSaved, "i_numeropedido", item.NumeroPedido);
                db.SetParameterValue(commandPuntosSaved, "i_nit", item.Nit);
                db.SetParameterValue(commandPuntosSaved, "i_tipo", item.Tipo);
                db.SetParameterValue(commandPuntosSaved, "i_cantidad", item.Cantidad);
                db.SetParameterValue(commandPuntosSaved, "i_movimiento", item.Movimiento);
                db.SetParameterValue(commandPuntosSaved, "i_procesado", item.Procesado);
                dr = db.ExecuteReader(commandPuntosSaved);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se inserto un detalle puntos saved nuevo nit: " + item.Nit + ", Campaña: " + item.Campana + ", NumeroPedido " + item.NumeroPedido + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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


        /// <summary>
        /// Guarda un PuntosSaved nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertPuntosTotal(PuntosSavedInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPuntosSaved, "i_operation", 'I');
                db.SetParameterValue(commandPuntosSaved, "i_option", 'B');
                db.SetParameterValue(commandPuntosSaved, "i_nit", item.Nit);
                dr = db.ExecuteReader(commandPuntosSaved);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se inserto un puntos total saved nuevo nit: " + item.Nit + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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


        /// <summary>
        /// Guarda un PuntosSaved Adicionales nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertDetallePuntosAdicionales(PuntosSavedInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPuntosSaved, "i_operation", 'I');
                db.SetParameterValue(commandPuntosSaved, "i_option", 'C');
                db.SetParameterValue(commandPuntosSaved, "i_numeropedido", item.NumeroPedido);
                db.SetParameterValue(commandPuntosSaved, "i_nit", item.Nit);

                dr = db.ExecuteReader(commandPuntosSaved);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se inserto un detalle puntos saved nuevo nit: " + item.Nit + ", Campaña: " + item.Campana + ", NumeroPedido " + item.NumeroPedido + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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