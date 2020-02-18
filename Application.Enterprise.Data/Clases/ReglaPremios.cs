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
    /// JA
    /// </summary>
    public class ReglaPremios
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandReglasPremios;

      

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReglaPremios(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReglaPremios()
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
            commandReglasPremios = db.GetStoredProcCommand("PRC_SVDN_REGLAS_PREMIOS");

            db.AddInParameter(commandReglasPremios, "i_operation", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_option", DbType.String);

            db.AddInParameter(commandReglasPremios, "i_id", DbType.Int32);
            db.AddInParameter(commandReglasPremios, "i_idregla", DbType.Int32);
            db.AddInParameter(commandReglasPremios, "i_plu", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_referencia", DbType.String);

            db.AddInParameter(commandReglasPremios, "i_campanaini", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_campanaentre", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_valormin", DbType.Int32);
            db.AddInParameter(commandReglasPremios, "i_valormax", DbType.Decimal);

            db.AddInParameter(commandReglasPremios, "i_formapag", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_descripcion", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_zonasB", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_estadosB", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_premiosB", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_totalizado", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_estadoregla", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_mensajevalor", DbType.String);

            db.AddInParameter(commandReglasPremios, "i_zona", DbType.String);

            db.AddInParameter(commandReglasPremios, "i_estado", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_tipoestado", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_cantidadest", DbType.String);

            db.AddInParameter(commandReglasPremios, "i_referenciai", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_plui", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_nombre", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_cantidadpremio", DbType.String);
            db.AddInParameter(commandReglasPremios, "i_tipopremio", DbType.String);

            db.AddInParameter(commandReglasPremios, "i_numeropedido", DbType.String);

            

            db.AddOutParameter(commandReglasPremios, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandReglasPremios, "o_err_msg", DbType.String, 1000);

        }



        /// <summary>
        /// lista todos las zonas de esa regla
        /// </summary>
        /// <returns></returns>
        public List<ZonasPremiosInfo> ListZonas(int regla)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'A');
            db.SetParameterValue(commandReglasPremios, "i_idregla", regla);

            List<ZonasPremiosInfo> col = new List<ZonasPremiosInfo>();

            IDataReader dr = null;

            ZonasPremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.getZonasPremios(dr);

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
        /// lista todos los estados de esa regla
        /// </summary>
        /// <returns></returns>
        public List<EstadosPremiosInfo> ListEstados(int regla)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'B');
            db.SetParameterValue(commandReglasPremios, "i_idregla", regla);

            List<EstadosPremiosInfo> col = new List<EstadosPremiosInfo>();

            IDataReader dr = null;

            EstadosPremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.getEstadoPremios(dr);

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
        /// lista todos los premois de esa regla
        /// </summary>
        /// <returns></returns>
        public List<PremiosPremiosInfo> ListPremios(int regla)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'C');
            db.SetParameterValue(commandReglasPremios, "i_idregla", regla);

            List<PremiosPremiosInfo> col = new List<PremiosPremiosInfo>();

            IDataReader dr = null;

            PremiosPremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.getPremiosPremios(dr);

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
        /// lista un producto 
        /// </summary>
        /// <returns></returns>
        public PLUInfo producto(string plu,string referencia)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'D');
            db.SetParameterValue(commandReglasPremios, "i_plu", plu);
            db.SetParameterValue(commandReglasPremios, "i_referencia", referencia);            

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.GetPLU(dr);                    
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
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglaPremiosInfo> ListReglas(string campana)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", '0');
            db.SetParameterValue(commandReglasPremios, "i_campanaentre", campana);  

            List<ReglaPremiosInfo> col = new List<ReglaPremiosInfo>();

            IDataReader dr = null;

            ReglaPremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.getReglaPremios(dr);

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
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        public ReglaPremiosInfo Reglas(string id)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'F');
            db.SetParameterValue(commandReglasPremios, "i_idregla", id);            

            IDataReader dr = null;

            ReglaPremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.getReglaPremios(dr);
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
        /// Guarda una regla premio nueva
        /// </summary>
        /// <param name="item"></param>
        public int InsertRegla(ReglaPremiosInfo item,string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'I');
                db.SetParameterValue(commandReglasPremios, "i_option", 'A');

                db.SetParameterValue(commandReglasPremios, "i_id", item.Id);
                db.SetParameterValue(commandReglasPremios, "i_campanaini", item.CampanaIni);
                db.SetParameterValue(commandReglasPremios, "i_campanaentre", item.CampanaEntre);
                db.SetParameterValue(commandReglasPremios, "i_valormin", item.ValorMin);
                db.SetParameterValue(commandReglasPremios, "i_valormax", item.ValorMax);
                db.SetParameterValue(commandReglasPremios, "i_formapag", item.FormaPag);
                db.SetParameterValue(commandReglasPremios, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandReglasPremios, "i_zonasB", item.Zonas);
                db.SetParameterValue(commandReglasPremios, "i_estadosB", item.Estados);
                db.SetParameterValue(commandReglasPremios, "i_PremiosB", item.Premios);
                db.SetParameterValue(commandReglasPremios, "i_totalizado", item.Totalizado);
                db.SetParameterValue(commandReglasPremios, "i_estadoregla", item.EstadoRegla);
                db.SetParameterValue(commandReglasPremios, "i_mensajevalor", item.Mensajevalor);


                dr = db.ExecuteReader(commandReglasPremios);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de una regla premio.  campañas:" + item.CampanaIni + "-"+item.CampanaEntre+",   Descripcion: " + item.Descripcion + ". Acción Realizada por el Usuario: " + usuario;

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
        /// Guarda zonas de la regla premio
        /// </summary>
        /// <param name="item"></param>
        public int Insertzonas(ZonasPremiosInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'I');
                db.SetParameterValue(commandReglasPremios, "i_option", 'B');

                db.SetParameterValue(commandReglasPremios, "i_idregla", item.IdRegla);
                db.SetParameterValue(commandReglasPremios, "i_zona", item.Zona);               


                dr = db.ExecuteReader(commandReglasPremios);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de zonas para la regla premio.  idregla:" + item.IdRegla + " zona" + item.Zona + ". Acción Realizada por el Usuario: " + usuario;

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
        /// Guarda estados de la regla premio
        /// </summary>
        /// <param name="item"></param>
        public int Insertestados(EstadosPremiosInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'I');
                db.SetParameterValue(commandReglasPremios, "i_option", 'C');

                db.SetParameterValue(commandReglasPremios, "i_idregla", item.IdRegla);
                db.SetParameterValue(commandReglasPremios, "i_estado", item.Estado);
                db.SetParameterValue(commandReglasPremios, "i_tipoestado", item.TipoEstado);
                db.SetParameterValue(commandReglasPremios, "i_cantidadest", item.Cantidad);


                dr = db.ExecuteReader(commandReglasPremios);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de estados para la regla premio.  idregla:" + item.IdRegla + " estado" + item.Estado + ". Acción Realizada por el Usuario: " + usuario;

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
        /// Guarda estados de la regla premio
        /// </summary>
        /// <param name="item"></param>
        public int Insertpremios(PremiosPremiosInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'I');
                db.SetParameterValue(commandReglasPremios, "i_option", 'D');

                db.SetParameterValue(commandReglasPremios, "i_idregla", item.IdRegla);
                db.SetParameterValue(commandReglasPremios, "i_referenciai", item.Referencia);
                db.SetParameterValue(commandReglasPremios, "i_plui", item.Plu);
                db.SetParameterValue(commandReglasPremios, "i_nombre", item.Nombre);
                db.SetParameterValue(commandReglasPremios, "i_cantidadpremio", item.Cantidad);
                db.SetParameterValue(commandReglasPremios, "i_tipopremio", item.TipoPremio);


                dr = db.ExecuteReader(commandReglasPremios);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de premios para la regla premio.  idregla:" + item.IdRegla + " referencia" + item.Referencia + "  plu" + item.Plu + " cantidad "+item.Cantidad+". Acción Realizada por el Usuario: " + usuario;

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
        /// lista regla consecutiva
        /// </summary>
        /// <returns></returns>
        public ReglaPremiosInfo Reglaconse()
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'E');
                      

            IDataReader dr = null;

            ReglaPremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.getReglaPremios(dr);                   
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
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public bool UpdateActivoRegla(int id, string Usuario, int activo)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'U');
                db.SetParameterValue(commandReglasPremios, "i_option", 'A');
                db.SetParameterValue(commandReglasPremios, "i_id", id);
                db.SetParameterValue(commandReglasPremios, "i_estadoregla", activo);

                dr = db.ExecuteReader(commandReglasPremios);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una Edicion de activacion " + activo + " de Regla:Codigo Regla Premio: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }


        /// <summary>
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteReglas(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'D');
                db.SetParameterValue(commandReglasPremios, "i_option", 'A');
                db.SetParameterValue(commandReglasPremios, "i_id", id);

                dr = db.ExecuteReader(commandReglasPremios);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de Regla:Codigo Regla Premio: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }



        /// <summary>
        /// actualiza una regla premio nueva
        /// </summary>
        /// <param name="item"></param>
        public int UpdateRegla(ReglaPremiosInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'U');
                db.SetParameterValue(commandReglasPremios, "i_option", 'B');

                db.SetParameterValue(commandReglasPremios, "i_id", item.Id);
                db.SetParameterValue(commandReglasPremios, "i_campanaini", item.CampanaIni);
                db.SetParameterValue(commandReglasPremios, "i_campanaentre", item.CampanaEntre);
                db.SetParameterValue(commandReglasPremios, "i_valormin", item.ValorMin);
                db.SetParameterValue(commandReglasPremios, "i_valormax", item.ValorMax);
                db.SetParameterValue(commandReglasPremios, "i_formapag", item.FormaPag);
                db.SetParameterValue(commandReglasPremios, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandReglasPremios, "i_zonasB", item.Zonas);
                db.SetParameterValue(commandReglasPremios, "i_estadosB", item.Estados);
                db.SetParameterValue(commandReglasPremios, "i_PremiosB", item.Premios);
                db.SetParameterValue(commandReglasPremios, "i_totalizado", item.Totalizado);
                db.SetParameterValue(commandReglasPremios, "i_estadoregla", item.EstadoRegla);
                db.SetParameterValue(commandReglasPremios, "i_mensajevalor", item.Mensajevalor);


                dr = db.ExecuteReader(commandReglasPremios);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion de una regla premio.  campañas:" + item.CampanaIni + "-" + item.CampanaEntre + ",   Descripcion: " + item.Descripcion + ". Acción Realizada por el Usuario: " + usuario;

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
        /// "borra" zonas de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteZonas(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'D');
                db.SetParameterValue(commandReglasPremios, "i_option", 'B');
                db.SetParameterValue(commandReglasPremios, "i_id", id);

                dr = db.ExecuteReader(commandReglasPremios);

                oktrans = true;              

            }
            catch (Exception ex)
            {
                oktrans = false;

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
            return oktrans;
        }

        /// <summary>
        /// "borra" estados de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteEstados(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'D');
                db.SetParameterValue(commandReglasPremios, "i_option", 'C');
                db.SetParameterValue(commandReglasPremios, "i_id", id);

                dr = db.ExecuteReader(commandReglasPremios);

                oktrans = true;

            }
            catch (Exception ex)
            {
                oktrans = false;

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
            return oktrans;
        }

        /// <summary>
        /// "borra" zonas de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeletePremios(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'D');
                db.SetParameterValue(commandReglasPremios, "i_option", 'D');
                db.SetParameterValue(commandReglasPremios, "i_id", id);

                dr = db.ExecuteReader(commandReglasPremios);

                oktrans = true;

            }
            catch (Exception ex)
            {
                oktrans = false;

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
            return oktrans;
        }

        /// <summary>
        /// procesa los premios
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool procesar(string numero, string campana)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglasPremios, "i_operation", 'P');
                db.SetParameterValue(commandReglasPremios, "i_numeropedido", numero);
                db.SetParameterValue(commandReglasPremios, "i_campanaEntre", campana);

                dr = db.ExecuteReader(commandReglasPremios);

                oktrans = true;

            }
            catch (Exception ex)
            {
                oktrans = false;

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
            return oktrans;
        }




        /// <summary>
        /// lista regla para mensaje
        /// </summary>
        /// <returns></returns>
        public ReglaPremiosInfo ReglaMensaje(string campana)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'G');
            db.SetParameterValue(commandReglasPremios, "i_campanaentre", campana);


            IDataReader dr = null;

            ReglaPremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.getReglaPremios(dr);
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
        /// Trae catalogo real de un producto
        /// </summary>
        /// <returns></returns>
        public CatalogoPluInfo ReglaTraerCatalogoReal(string idcorto, string catalogo)
        {
            db.SetParameterValue(commandReglasPremios, "i_operation", 'S');
            db.SetParameterValue(commandReglasPremios, "i_option", 'H');
            db.SetParameterValue(commandReglasPremios, "i_plu", idcorto);
            db.SetParameterValue(commandReglasPremios, "i_campanaEntre", catalogo);


            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglasPremios);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLU(dr);
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


    }
}
