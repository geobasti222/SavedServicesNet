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
    /// DAO Catalogo JA
    /// </summary>
    public class Catalogo
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCatalogo;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Catalogo(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Catalogo()
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
            commandCatalogo = db.GetStoredProcCommand("PRC_SVDN_CATALOGO");

            db.AddInParameter(commandCatalogo, "i_operation", DbType.String);
            db.AddInParameter(commandCatalogo, "i_option", DbType.String);
            db.AddInParameter(commandCatalogo, "i_codigo", DbType.String);
            db.AddInParameter(commandCatalogo, "i_nombre", DbType.String);
            db.AddInParameter(commandCatalogo, "i_ano", DbType.String);
            db.AddInParameter(commandCatalogo, "i_fechaini", DbType.DateTime);
            db.AddInParameter(commandCatalogo, "i_fechafin", DbType.DateTime);
            db.AddInParameter(commandCatalogo, "i_grupocatalogo", DbType.String);
            db.AddInParameter(commandCatalogo, "i_estado", DbType.Boolean);
            //--comentar para hacer funcionar ecuador
            //db.AddInParameter(commandCatalogo, "i_unineg", DbType.String);

            db.AddOutParameter(commandCatalogo, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCatalogo, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Catalogo

        /// <summary>
        /// Lista todos los catalogos.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInfo> List()
        {
            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'A');

            List<CatalogoInfo> col = new List<CatalogoInfo>();

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);

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
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public CatalogoInfo ListCatalogoActual()
        {
            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'B');

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoActual(dr);

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
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInfo> ListCatalogoFechaActual()
        {

            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'C');

            List<CatalogoInfo> col = new List<CatalogoInfo>();

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);

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
        /// Lista el catalogo de NIVI de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public CatalogoInfo ListCatalogoNIVIxFechaActual()
        {

            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'D');

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);
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
        /// Lista la cantidad de catalogos de NIVI solicitados ordenados de mayor a menor
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInfo> ListUltimosCatalogoNIVI()
        {
            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'E');

            List<CatalogoInfo> col = new List<CatalogoInfo>();

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);

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
        /// Lista un catalogo x id.
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<CatalogoInfo> ListxId(string Catalogo)
        {
            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'F');
            db.SetParameterValue(commandCatalogo, "i_codigo", Catalogo);

            List<CatalogoInfo> col = new List<CatalogoInfo>();

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);

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
        /// Lista un catalogo x campana.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public CatalogoInfo ListCatalogoxCampana(string Campana)
        {
            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'G');
            db.SetParameterValue(commandCatalogo, "i_codigo", Campana);
           
            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);

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
        /// Guarda un catalogo nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CatalogoInfo item)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCatalogo, "i_operation", 'I');
                db.SetParameterValue(commandCatalogo, "i_option", 'A');

                db.SetParameterValue(commandCatalogo, "i_codigo", item.Codigo);
                db.SetParameterValue(commandCatalogo, "i_nombre", item.Nombre);
                db.SetParameterValue(commandCatalogo, "i_ano", item.Ano);
                db.SetParameterValue(commandCatalogo, "i_fechaini", item.FechaInicial);
                db.SetParameterValue(commandCatalogo, "i_fechafin", item.FechaFin);
                db.SetParameterValue(commandCatalogo, "i_grupocatalogo", item.GrupoCatalogo);
                db.SetParameterValue(commandCatalogo, "i_estado", item.Estado);
                db.SetParameterValue(commandCatalogo, "i_unineg", item.Unineg);


                dr = db.ExecuteReader(commandCatalogo);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de un catalogo.  Codigo:" + item.Codigo + ",  Nombre:" + item.Nombre + ",   Desde: " + item.FechaInicial + ", Hasta: " + item.FechaFin + ", Estado:" + item.Estado + ",. Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de un catalogo existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(CatalogoInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCatalogo, "i_operation", 'U');
                db.SetParameterValue(commandCatalogo, "i_option", 'A');

                db.SetParameterValue(commandCatalogo, "i_codigo", item.Codigo);
                db.SetParameterValue(commandCatalogo, "i_nombre", item.Nombre);
                db.SetParameterValue(commandCatalogo, "i_ano", item.Ano);
                db.SetParameterValue(commandCatalogo, "i_fechaini", item.FechaInicial);
                db.SetParameterValue(commandCatalogo, "i_fechafin", item.FechaFin);
                db.SetParameterValue(commandCatalogo, "i_grupocatalogo", item.GrupoCatalogo);
                db.SetParameterValue(commandCatalogo, "i_estado", item.Estado);
                db.SetParameterValue(commandCatalogo, "i_unineg", item.Unineg);


                dr = db.ExecuteReader(commandCatalogo);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la actualización de un catalogo.  Codigo:" + item.Codigo + ",  Nombre:" + item.Nombre + ",   Desde: " + item.FechaInicial + ", Hasta: " + item.FechaFin + ", Estado:" + item.Estado + ",. Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Lista los catalogos que se trasponen al ingreso
        /// </summary>
        ///  <param name="fechaini"></param>
        ///  <param name="fechafin"></param>
        /// <returns></returns>
        public List<CatalogoInfo> ListCatalogoTrasponen(DateTime fechaini, DateTime fechafin)
        {
            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'H');

            db.SetParameterValue(commandCatalogo, "i_fechaini", fechaini);
            db.SetParameterValue(commandCatalogo, "i_fechafin", fechafin);

            List<CatalogoInfo> col = new List<CatalogoInfo>();

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);

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
        /// Lista los catalogos por codigo
        /// </summary>
        /// <param name="catalogo"></param>
        /// 
        /// <returns></returns>
        public CatalogoInfo ListxCodigo(string Catalogo)
        {
            db.SetParameterValue(commandCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandCatalogo, "i_option", 'F');
            db.SetParameterValue(commandCatalogo, "i_codigo", Catalogo);

          

            IDataReader dr = null;

            CatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetCatalogo(dr);

                  
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

        #endregion
    }
}