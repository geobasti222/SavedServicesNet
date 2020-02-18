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
    public class ZonasModeloFacturacion
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandZonasModeloFacturacion;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ZonasModeloFacturacion(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ZonasModeloFacturacion()
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
            commandZonasModeloFacturacion = db.GetStoredProcCommand("PRC_SVDN_ZONAS_MODELO_FACTURACION");

            db.AddInParameter(commandZonasModeloFacturacion, "i_operation", DbType.String);
            db.AddInParameter(commandZonasModeloFacturacion, "i_option", DbType.String);
            db.AddInParameter(commandZonasModeloFacturacion, "i_zona", DbType.String);
            db.AddInParameter(commandZonasModeloFacturacion, "i_mai", DbType.Boolean);
            db.AddInParameter(commandZonasModeloFacturacion, "i_mrl", DbType.Boolean);
            db.AddInParameter(commandZonasModeloFacturacion, "i_diaria", DbType.Boolean);
            db.AddInParameter(commandZonasModeloFacturacion, "i_veintedias", DbType.Boolean);
            db.AddOutParameter(commandZonasModeloFacturacion, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandZonasModeloFacturacion, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Zona

        /// <summary>
        /// lista todas las ZonasModeloFacturacion existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonasModeloFacturacionInfo> List()
        {
            db.SetParameterValue(commandZonasModeloFacturacion, "i_operation", 'S');
            db.SetParameterValue(commandZonasModeloFacturacion, "i_option", 'A');

            List<ZonasModeloFacturacionInfo> col = new List<ZonasModeloFacturacionInfo>();

            IDataReader dr = null;

            ZonasModeloFacturacionInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasModeloFacturacion);

                while (dr.Read())
                {
                    m = Factory.GetZonasModeloFacturacion(dr);

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
        /// lista todas las ZonasModeloFacturacion existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonasModeloFacturacionInfo> ListModelosYReserva(string zona = null)
        {
            db.SetParameterValue(commandZonasModeloFacturacion, "i_operation", 'S');
            db.SetParameterValue(commandZonasModeloFacturacion, "i_option", 'B');
            db.SetParameterValue(commandZonasModeloFacturacion, "i_zona", zona);

            List<ZonasModeloFacturacionInfo> col = new List<ZonasModeloFacturacionInfo>();

            IDataReader dr = null;

            ZonasModeloFacturacionInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasModeloFacturacion);

                while (dr.Read())
                {
                    m = Factory.GetZonasModeloFacturacion(dr);

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
        /// Lista las zonas que no esten en los modelos de facturacion y reserva en linea
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<ZonasModeloFacturacionInfo> ZonasSinReservaNiModeloFacturacion()
        {
            db.SetParameterValue(commandZonasModeloFacturacion, "i_operation", 'S');
            db.SetParameterValue(commandZonasModeloFacturacion, "i_option", 'C');            

            List<ZonasModeloFacturacionInfo> col = new List<ZonasModeloFacturacionInfo>();

            IDataReader dr = null;

            ZonasModeloFacturacionInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasModeloFacturacion);

                while (dr.Read())
                {
                    m = Factory.GetZonasSinReservaNiModeloFacturacion(dr);

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
        /// Lista las zonas que tienen pedidos activos
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool ListZonasActivas(string Zona)
        {
            bool transOk = false;
            db.SetParameterValue(commandZonasModeloFacturacion, "i_operation", 'S');
            db.SetParameterValue(commandZonasModeloFacturacion, "i_option", 'D');
            db.SetParameterValue(commandZonasModeloFacturacion, "i_zona", Zona);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo  m = null;

            try
            {
                dr = db.ExecuteReader(commandZonasModeloFacturacion);

                
                while (dr.Read())
                {

                    m = Factory.GetNumero(dr);

                    col.Add(m);
                }

                if (col.Count > 0)
                {
                    transOk = true;
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


            return transOk;
        }


        /// <summary>
        /// Insercion del modelo de facturacion de una zona
        /// </summary>
        /// <param name="objZonasModeloFacturacion"></param>
        /// <returns></returns>
        public bool InsertZonasModeloFacturacion(ZonasModeloFacturacionInfo objZonasModeloFacturacion)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZonasModeloFacturacion, "i_operation", 'I');
                db.SetParameterValue(commandZonasModeloFacturacion, "i_option", 'A');
                db.SetParameterValue(commandZonasModeloFacturacion, "i_zona", objZonasModeloFacturacion.Zona);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_mai", objZonasModeloFacturacion.ModeloAsignacionInventario);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_mrl", objZonasModeloFacturacion.ModeloReservaLinea);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_diaria", objZonasModeloFacturacion.Diaria);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_veintedias", objZonasModeloFacturacion.VeinteDias);
                
                dr = db.ExecuteReader(commandZonasModeloFacturacion);

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
        /// Actualizacion del modelo de facturacion de una zona
        /// </summary>
        /// <param name="objZonasModeloFacturacion"></param>
        /// <returns></returns>
        public bool UpdateZonasModeloFacturacion(ZonasModeloFacturacionInfo objZonasModeloFacturacion)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZonasModeloFacturacion, "i_operation", 'U');
                db.SetParameterValue(commandZonasModeloFacturacion, "i_option", 'A');
                db.SetParameterValue(commandZonasModeloFacturacion, "i_zona", objZonasModeloFacturacion.Zona);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_mai", objZonasModeloFacturacion.ModeloAsignacionInventario);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_mrl", objZonasModeloFacturacion.ModeloReservaLinea);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_diaria", objZonasModeloFacturacion.Diaria);
                db.SetParameterValue(commandZonasModeloFacturacion, "i_veintedias", objZonasModeloFacturacion.VeinteDias);

                dr = db.ExecuteReader(commandZonasModeloFacturacion);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = objZonasModeloFacturacion.Usuario;
                    objAuditoriaInfo.Proceso = "Se modifico zona como reserva en linea facturacion diaria: " + objZonasModeloFacturacion.Zona + ". Acción Realizada por el Usuario: " + objZonasModeloFacturacion.Usuario;

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
        /// eliminacion de una zona de la tabla de modelos de facturacion y reserva en linea
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public bool EliminarZonasModeloFacturacion(string zona, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZonasModeloFacturacion, "i_operation", 'D');
                db.SetParameterValue(commandZonasModeloFacturacion, "i_option", 'A');
                db.SetParameterValue(commandZonasModeloFacturacion, "i_zona", zona);

                dr = db.ExecuteReader(commandZonasModeloFacturacion);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se elimino la zona del modelo de reserva en linea facturacion diaria y se convirtio en zona de facturacion semanal. Zona: " + zona + ". Acción Realizada por el Usuario: " + Usuario;

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
