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
    /// DAO zonas JA
    /// </summary>
    public class Zona
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandZona;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Zona(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Zona()
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
            commandZona = db.GetStoredProcCommand("PRC_SVDN_ZONA");

            db.AddInParameter(commandZona, "i_operation", DbType.String);
            db.AddInParameter(commandZona, "i_option", DbType.String);
            db.AddInParameter(commandZona, "i_zona", DbType.String);
            db.AddInParameter(commandZona, "i_descripcion", DbType.String);            
            db.AddInParameter(commandZona, "i_codlocalidad", DbType.String);
            db.AddInParameter(commandZona, "i_nit_cliente", DbType.String);
            db.AddInParameter(commandZona, "i_nit_proveedor", DbType.String);
            db.AddInParameter(commandZona, "i_contacto", DbType.String);
            db.AddInParameter(commandZona, "i_direccion", DbType.String);
            db.AddInParameter(commandZona, "i_telefonos", DbType.String);
            db.AddInParameter(commandZona, "i_fax", DbType.String);
            db.AddInParameter(commandZona, "i_email", DbType.String);
            db.AddInParameter(commandZona, "i_codgereg", DbType.String);
            db.AddInParameter(commandZona, "i_localizacion", DbType.String);
            db.AddInParameter(commandZona, "i_mailgroup", DbType.String);
            db.AddInParameter(commandZona, "i_excluido", DbType.Int32);            
            db.AddInParameter(commandZona, "i_codciudad", DbType.String);
            db.AddInParameter(commandZona, "i_codsector", DbType.String);
            db.AddInParameter(commandZona, "i_valor_flete", DbType.Decimal);                        
            db.AddInParameter(commandZona, "i_diasborrador", DbType.Int32);
            db.AddInParameter(commandZona, "i_diasreserva", DbType.Int32);
            db.AddInParameter(commandZona, "i_diasdegracia", DbType.Int32);
            db.AddInParameter(commandZona, "i_unineg", DbType.String);
            //--Valores nuevos que hay que documentar para poder funcionar en ecuador y hacer pruevbas
            //db.AddInParameter(commandZona, "i_cod_rango", DbType.String);
            //db.AddInParameter(commandZona, "i_tipozona", DbType.String);
            //db.AddInParameter(commandZona, "i_sumagerente", DbType.Int32);
            //db.AddInParameter(commandZona, "i_vendedor", DbType.String);
            //db.AddInParameter(commandZona, "i_valor_flete1", DbType.Decimal);
            //db.AddInParameter(commandZona, "i_activo", DbType.Int32);
            //db.AddInParameter(commandZona, "i_zona_mtra", DbType.String);

            db.AddOutParameter(commandZona, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandZona, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Zona

        /// <summary>
        /// lista todas las Zonas existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> List()
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'A');

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZona(dr);

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
        /// Lista las zonas de un sector.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListxSector(string CodSector)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'B');
            db.SetParameterValue(commandZona, "i_codsector", CodSector);

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZonaxSector(dr);

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
        /// Lista las zonas de un mailgroup.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListxMailGroup(string MailGroup)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'C');
            db.SetParameterValue(commandZona, "i_mailgroup", MailGroup);

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZona(dr);

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
        /// Lista una zona especifica por id de zona.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public ZonaInfo ListxIdZona(string IdZona)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'D');
            db.SetParameterValue(commandZona, "i_zona", IdZona);

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZona(dr);
                }
                if (m == null)
                {
                    m.Zona = "";
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
        /// Lista una zona especifica por id de zona con Flete1.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public ZonaPeruInfo ListxIdZonaYFlete1(string IdZona)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'E');
            db.SetParameterValue(commandZona, "i_zona", IdZona);

            IDataReader dr = null;

            ZonaPeruInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZonaYFlete1(dr);
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
        /// Lista las zonas de una gerente regional.
        /// </summary>
        /// <param name="Regional"></param>
        /// <returns></returns>
        public List<ZonaInfo> ListxRegional(string Regional)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'F');
            db.SetParameterValue(commandZona, "i_codgereg", Regional);

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZona(dr);

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
        /// Lista la informacion completa de todas las zonas existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListxInformacionZonas()
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'G');

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZonaInformacion(dr);

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
        /// Lista una zona especifica incluyendo zona maestra.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public ZonaInfo ListxIdZonaxZonaMaestra(string IdZona)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'H');
            db.SetParameterValue(commandZona, "i_zona", IdZona);

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZonaMaestra(dr);
                }
                if (m == null)
                {
                    m.Zona = "";
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
        /// Realiza la actualizacion del valor del flete de una zona .
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="ValorFlete"></param>
        /// <returns></returns>
        public bool UpdateValorFlete(string Zona, decimal ValorFlete, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZona, "i_operation", 'U');
                db.SetParameterValue(commandZona, "i_option", 'A');
                db.SetParameterValue(commandZona, "i_zona", Zona);
                db.SetParameterValue(commandZona, "i_valor_flete", ValorFlete);

                dr = db.ExecuteReader(commandZona);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se Actualizo Flete por zona : Zona: " + Zona + ", ValorFlete: " + ValorFlete + ". Acción Realizada por el Usuario: " + Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------



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
        /// Realiza la actualizacion de los dias borrador, reserva y de gracia.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="DiasBorrador"></param>
        /// <param name="DiasReserva"></param>
        /// <param name="DiasdeGracia"></param>
        /// <returns></returns>
        public bool UpdateDiasBorradoReservaGracia(string Zona, int DiasBorrador, int DiasReserva, int DiasdeGracia, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZona, "i_operation", 'U');
                db.SetParameterValue(commandZona, "i_option", 'B');
                db.SetParameterValue(commandZona, "i_zona", Zona);
                db.SetParameterValue(commandZona, "i_diasborrador", DiasBorrador);
                db.SetParameterValue(commandZona, "i_diasreserva", DiasReserva);
                db.SetParameterValue(commandZona, "i_diasdegracia", DiasdeGracia);

                dr = db.ExecuteReader(commandZona);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se modifico Dias de reserva por zona: Zona " + Zona + ",Dias de Borrador " + DiasBorrador + ", Dias de Reserva " + DiasReserva + ", Dias de  Gracia " + DiasdeGracia + " . Acción Realizada por el Usuario: " + Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------


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
        /// Guarda un Zona nueva.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(ZonaInfo item)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandZona, "i_operation", 'I');
                db.SetParameterValue(commandZona, "i_option", 'A');

                db.SetParameterValue(commandZona, "i_zona", item.Zona);
                db.SetParameterValue(commandZona, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandZona, "i_zona_mtra", item.Zona_Mtra);
                db.SetParameterValue(commandZona, "i_codlocalidad", item.CodLocalidad);
                db.SetParameterValue(commandZona, "i_codgereg", item.CodGereg);
                db.SetParameterValue(commandZona, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandZona, "i_mailgroup", item.MailGroup);
                db.SetParameterValue(commandZona, "i_excluido", item.Excluido);
                db.SetParameterValue(commandZona, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandZona, "i_valor_flete", item.ValorFlete);
                db.SetParameterValue(commandZona, "i_valor_flete1", item.ValorFlete1);
                db.SetParameterValue(commandZona, "i_activo", item.Activo);
                db.SetParameterValue(commandZona, "i_diasborrador", item.DiasBorrador);
                db.SetParameterValue(commandZona, "i_diasreserva", item.DiasReserva);
                db.SetParameterValue(commandZona, "i_diasdegracia", item.DiasDeGracia);
                db.SetParameterValue(commandZona, "i_unineg", item.UnidadNegocio);
                db.SetParameterValue(commandZona, "i_cod_rango", item.Cod_Rango);
                db.SetParameterValue(commandZona, "i_tipozona", item.TipoZona);
                db.SetParameterValue(commandZona, "i_sumagerente", item.SumaGerente);                                

                dr = db.ExecuteReader(commandZona);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de una zona.  Zona:" + item.Zona + ",  descripción:" + item.Descripcion + ",   vendedor: " + item.Vendedor + ", valor_flete: " + item.ValorFlete + ",. Acción Realizada por el Usuario: " + item.Usuario;

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
                id = 0;

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
            return id;
        }


        /// <summary>
        /// Realiza la actualizacion de una zona existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ZonaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandZona, "i_operation", 'U');
                db.SetParameterValue(commandZona, "i_option", 'C');

                db.SetParameterValue(commandZona, "i_zona", item.Zona);
                db.SetParameterValue(commandZona, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandZona, "i_zona_mtra", item.Zona_Mtra);
                db.SetParameterValue(commandZona, "i_codlocalidad", item.CodLocalidad);
                db.SetParameterValue(commandZona, "i_codgereg", item.CodGereg);
                db.SetParameterValue(commandZona, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandZona, "i_mailgroup", item.MailGroup);
                db.SetParameterValue(commandZona, "i_excluido", item.Excluido);
                db.SetParameterValue(commandZona, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandZona, "i_valor_flete", item.ValorFlete);
                db.SetParameterValue(commandZona, "i_valor_flete1", item.ValorFlete1);
                db.SetParameterValue(commandZona, "i_activo", item.Activo);
                db.SetParameterValue(commandZona, "i_diasborrador", item.DiasBorrador);
                db.SetParameterValue(commandZona, "i_diasreserva", item.DiasReserva);
                db.SetParameterValue(commandZona, "i_diasdegracia", item.DiasDeGracia);
                db.SetParameterValue(commandZona, "i_unineg", item.UnidadNegocio);
                db.SetParameterValue(commandZona, "i_cod_rango", item.Cod_Rango);
                db.SetParameterValue(commandZona, "i_tipozona", item.TipoZona);
                db.SetParameterValue(commandZona, "i_sumagerente", item.SumaGerente);      

                dr = db.ExecuteReader(commandZona);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la actualización de una zona.  Zona:" + item.Zona + ",  descripción:" + item.Descripcion + ",   vendedor: " + item.Vendedor + ", valor_flete: " + item.ValorFlete + ",. Acción Realizada por el Usuario: " + item.Usuario;

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
        /// lista todas las Zonas existentes mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> ListAll()
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'I');

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZonaAll(dr);

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
        /// obtiene una Zona existente mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public ZonaInfo ListxZona(String zona)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'J');
            db.SetParameterValue(commandZona, "i_zona", zona);

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZonaAll(dr);

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
        /// obtiene una lista buscada por vendedor mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>       
        public List<ZonaInfo> ListxVendedor(string vendedor)
        {
            db.SetParameterValue(commandZona, "i_operation", 'S');
            db.SetParameterValue(commandZona, "i_option", 'K');
            db.SetParameterValue(commandZona, "i_vendedor", vendedor);

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZona);

                while (dr.Read())
                {
                    m = Factory.GetZonaAll(dr);

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
        #endregion
    }
}