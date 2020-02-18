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
    public class ZonasReservaEnLinea
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandZonasReservaEnLinea;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ZonasReservaEnLinea(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ZonasReservaEnLinea()
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
            commandZonasReservaEnLinea = db.GetStoredProcCommand("PRC_SVDN_ZONAS_RESERVAENLINEA");

            db.AddInParameter(commandZonasReservaEnLinea, "i_operation", DbType.String);
            db.AddInParameter(commandZonasReservaEnLinea, "i_option", DbType.String);
            db.AddInParameter(commandZonasReservaEnLinea, "i_zona", DbType.String);
            db.AddInParameter(commandZonasReservaEnLinea, "i_estado", DbType.String);

            db.AddOutParameter(commandZonasReservaEnLinea, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandZonasReservaEnLinea, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Zonas Multi Pedidos

        /// <summary>
        /// Lista todos las zonas que pueden hacer multiples pedidos.
        /// </summary>
        /// <returns></returns>
        public List<ZonasReservaEnLineaInfo> List()
        {
            db.SetParameterValue(commandZonasReservaEnLinea, "i_operation", 'S');
            db.SetParameterValue(commandZonasReservaEnLinea, "i_option", 'A');

            List<ZonasReservaEnLineaInfo> col = new List<ZonasReservaEnLineaInfo>();

            IDataReader dr = null;

            ZonasReservaEnLineaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasReservaEnLinea);

                while (dr.Read())
                {
                    m = Factory.GetZonasReservaEnLinea(dr);

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
        /// Consulta si existe una zona para digitar multiples pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public ZonasReservaEnLineaInfo ListxZona(string Zona)
        {
            db.SetParameterValue(commandZonasReservaEnLinea, "i_operation", 'S');
            db.SetParameterValue(commandZonasReservaEnLinea, "i_option", 'B');
            db.SetParameterValue(commandZonasReservaEnLinea, "i_zona", Zona);

            IDataReader dr = null;

            ZonasReservaEnLineaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasReservaEnLinea);

                while (dr.Read())
                {
                    m = Factory.GetZonasReservaEnLinea(dr);
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
        /// Actualizacion de una zona con reserva en linea
        /// </summary>
        /// <param name="objZonasModeloFacturacion"></param>
        /// <returns></returns>
        public bool UpdateZonasReservaEnLinea(ZonasReservaEnLineaInfo objZonasReservaEnLinea)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZonasReservaEnLinea, "i_operation", 'U');
                db.SetParameterValue(commandZonasReservaEnLinea, "i_option", 'A');
                db.SetParameterValue(commandZonasReservaEnLinea, "i_zona", objZonasReservaEnLinea.Zona);
                db.SetParameterValue(commandZonasReservaEnLinea, "i_estado", objZonasReservaEnLinea.Estado);

                dr = db.ExecuteReader(commandZonasReservaEnLinea);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = objZonasReservaEnLinea.Usuario;
                    objAuditoriaInfo.Proceso = "Se modifico zona como reserva en linea facturacion diaria: " + objZonasReservaEnLinea.Zona + ". Acción Realizada por el Usuario: " + objZonasReservaEnLinea.Usuario;

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

        /// <summary>
        /// Insercion de una zona con reserva en linea
        /// </summary>
        /// <param name="objZonasReservaEnLinea"></param>
        /// <returns></returns>
        public bool InsertZonasReservaEnLinea(ZonasReservaEnLineaInfo objZonasReservaEnLinea)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZonasReservaEnLinea, "i_operation", 'I');
                db.SetParameterValue(commandZonasReservaEnLinea, "i_option", 'A');
                db.SetParameterValue(commandZonasReservaEnLinea, "i_zona", objZonasReservaEnLinea.Zona);
                db.SetParameterValue(commandZonasReservaEnLinea, "i_estado", objZonasReservaEnLinea.Estado);

                dr = db.ExecuteReader(commandZonasReservaEnLinea);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = objZonasReservaEnLinea.Usuario;
                    objAuditoriaInfo.Proceso = "Se agrego zona como reserva en linea facturacion diaria: " + objZonasReservaEnLinea.Zona + ". Acción Realizada por el Usuario: " + objZonasReservaEnLinea.Usuario;

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