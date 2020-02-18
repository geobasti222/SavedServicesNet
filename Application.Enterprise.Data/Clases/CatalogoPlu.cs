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
using System.Data.SqlClient;  

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogoPlu
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCatalogoPlu;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CatalogoPlu(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CatalogoPlu()
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
            commandCatalogoPlu = db.GetStoredProcCommand("PRC_SVDN_CATALOGOS_PLUS");

            db.AddInParameter(commandCatalogoPlu, "i_operation", DbType.String);
            db.AddInParameter(commandCatalogoPlu, "i_option", DbType.String);
            db.AddInParameter(commandCatalogoPlu, "i_catalogo", DbType.String);
            db.AddInParameter(commandCatalogoPlu, "i_referencia", DbType.String);
            db.AddInParameter(commandCatalogoPlu, "i_plu", DbType.Int32);
            db.AddInParameter(commandCatalogoPlu, "i_id_corto", DbType.String);
            db.AddInParameter(commandCatalogoPlu, "i_catalogoreal", DbType.String);
            db.AddInParameter(commandCatalogoPlu, "i_estado", DbType.Byte);
            db.AddInParameter(commandCatalogoPlu, "i_zona", DbType.String);
            

            db.AddOutParameter(commandCatalogoPlu, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCatalogoPlu, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de CatalogoPlu

        /// <summary>
        /// Lista todos los catalogos x plus.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoPluInfo> List()
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'A');

            List<CatalogoPluInfo> col = new List<CatalogoPluInfo>();

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLU(dr);

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
        /// Lista todos los catalogos x plus x id Codigo Rapido x catalogo
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListxIdCodigoRapido(string IdCodigoRapido, string Catalogo)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'B');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", IdCodigoRapido);
            db.SetParameterValue(commandCatalogoPlu, "i_catalogo", Catalogo);

            List<CatalogoPluInfo> col = new List<CatalogoPluInfo>();

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLU(dr);

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
        /// Lista un catalogo x plus x id Codigo Rapido x catalogo unico.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxIdCodigoRapidoUnico(string IdCodigoRapido, string Catalogo)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'C');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", IdCodigoRapido);
            db.SetParameterValue(commandCatalogoPlu, "i_catalogo", Catalogo);

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

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

        /// <summary>
        /// Lista todos los catalogos x plus x catalogo
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListxIdCodigoRapidoxCatalogo(string Catalogo)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'D');
            db.SetParameterValue(commandCatalogoPlu, "i_catalogo", Catalogo);

            List<CatalogoPluInfo> col = new List<CatalogoPluInfo>();

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLU(dr);

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
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogo(string IdCodigoRapido)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'E');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", IdCodigoRapido);

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

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

        /// <summary>
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo sin bloqueo de visible POS.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogoSinBloqueo(string IdCodigoRapido)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'F');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", IdCodigoRapido);

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

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

        /*******************************GAVL******************************/
        /// <summary>
        /// Lista todos los numeros de catalogos .
        /// </summary>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListCatalogos()
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'G');

            List<CatalogoPluInfo> col = new List<CatalogoPluInfo>();

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLU(dr);

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
        /// lista catalogos por numero de catalogo
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        public List<CatalogoPluInfo> ListXCatalogos(string catalogo)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'H');
            db.SetParameterValue(commandCatalogoPlu, "i_catalogo", catalogo );

            List<CatalogoPluInfo> col = new List<CatalogoPluInfo>();

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLU(dr);

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
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo inactivo x agotado anunciado.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogoAgotadoAnunciado(string IdCodigoRapido)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'J');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", IdCodigoRapido);

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

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



        /// <summary>
        /// Lista un articulo por codigo rapido digitado con dependencia de catalogo x zona.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public CatalogoPluInfo ListxCodigoRapidoSinCatalogoxZona(string IdCodigoRapido, string Zona)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'K');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", IdCodigoRapido);
            db.SetParameterValue(commandCatalogoPlu, "i_zona", Zona);

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

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


        /// <summary>
        /// Actualiza campo activo x plus Por catalog
        /// </summary>
        /// <param name="catalogo"></param>
        /// <param name="plu"></param>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaXPlu(string catalogo, int plu, int estado, string usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCatalogoPlu, "i_operation", 'U');
                db.SetParameterValue(commandCatalogoPlu, "i_option", 'A');

                db.SetParameterValue(commandCatalogoPlu, "i_plu", plu);
                db.SetParameterValue(commandCatalogoPlu, "i_estado", estado);
                db.SetParameterValue(commandCatalogoPlu, "i_catalogo", catalogo);

                dr = db.ExecuteReader(commandCatalogoPlu);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion al estado de la  Tabla CATALOGOS_PLUS: Catalogo: " + catalogo + ",plu: " + plu + ",estado: " + ((estado == 1)? "Activo" : "Inactivo") + ". Acción Realizada por el Usuario: " + usuario;

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
        /// Actualiza campo activo x plus Por catalog
        /// </summary>
        /// <param name="catalogo"></param>
        /// <param name="plu"></param>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaTodo(int estado, string usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCatalogoPlu, "i_operation", 'U');
                db.SetParameterValue(commandCatalogoPlu, "i_option", 'B');
                db.SetParameterValue(commandCatalogoPlu, "i_estado", ((estado==2)? 0:estado));
                dr = db.ExecuteReader(commandCatalogoPlu);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion al estado de la  Tabla CATALOGOS_PLUS: estado: " + ((estado == 1) ? "Activo" : "Inactivo") + ". Acción Realizada por el Usuario: " + usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

                okTrans = true;


            }
            catch (SqlException  Esx)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", Esx.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                okTrans = false;
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


        #region Activa 50% Descuentos por Plu

        public List<CatalogoPluInfo> ListCatalogosXplu(string catalogo, int plu)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'I');
            db.SetParameterValue(commandCatalogoPlu, "i_catalogo", catalogo);
            db.SetParameterValue(commandCatalogoPlu, "i_plu", plu);

            List<CatalogoPluInfo> col = new List<CatalogoPluInfo>();

            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLU(dr);

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
        /// Actualiza campo De CatalogoReal  segun Catalogo y Plu
        /// </summary>
        /// <param name="catalogoreal"></param>
        /// <param name="catalogo"></param>
        /// <param name="plu"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaCatalogoXPlu(string catalogoreal,string catalogo, int plu,  string usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCatalogoPlu, "i_operation", 'U');
                db.SetParameterValue(commandCatalogoPlu, "i_option", 'C');

                db.SetParameterValue(commandCatalogoPlu, "i_plu", plu);
                db.SetParameterValue(commandCatalogoPlu, "i_catalogo", catalogo);
                db.SetParameterValue(commandCatalogoPlu, "i_catalogoreal", catalogoreal);

                dr = db.ExecuteReader(commandCatalogoPlu);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion Del CatalogoReal por ActivacionDescuento NIviESP de la  Tabla CATALOGOS_PLUS: Catalogo: " + catalogo + ",plu: " + plu + ",catalogoReal: " + catalogoreal + ". Acción Realizada por el Usuario: " + usuario;

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



        #endregion


        /// <summary>
        /// Guarda cargue catalogo
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CatalogoPluInfo item,String usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCatalogoPlu, "i_operation", 'I');
                db.SetParameterValue(commandCatalogoPlu, "i_option", 'A');

         
                db.SetParameterValue(commandCatalogoPlu, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandCatalogoPlu, "i_catalogoreal", item.CatalogoReal);
                db.SetParameterValue(commandCatalogoPlu, "i_id_corto", item.IdCodigoCorto);
                db.SetParameterValue(commandCatalogoPlu, "i_plu", item.PLU);
                db.SetParameterValue(commandCatalogoPlu, "i_referencia", item.Referencia);


                dr = db.ExecuteReader(commandCatalogoPlu);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de cargue catalogo. Accion realizaada por el Usuario: " + usuario;

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
      /// obtener critero o unineg de siesa de un item.
      /// </summary>
      /// <param name="IdCodigoRapido"></param>
      /// <returns></returns>
        public CatalogoPluInfo itemcriterio(string IdCodigoRapido)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'L');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", IdCodigoRapido);


            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLUCRITERIO(dr);
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
        /// obtiene un catalogoplu con los puntos
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        public CatalogoPluInfo catalogoPlupuntos(string idcorto)
        {
            db.SetParameterValue(commandCatalogoPlu, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoPlu, "i_option", 'L');
            db.SetParameterValue(commandCatalogoPlu, "i_id_corto", idcorto);


            IDataReader dr = null;

            CatalogoPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoPlu);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoPLUPUNTOS(dr);
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