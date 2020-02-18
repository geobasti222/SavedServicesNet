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
    public class AmarresDao_old
    {
        /// <summary>
        ///  CODIGO BY JUTA.
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAmarres;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public AmarresDao_old(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public AmarresDao_old()
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
            commandAmarres = db.GetStoredProcCommand("PRC_SVDN_AMARRES");

            db.AddInParameter(commandAmarres, "i_operation", DbType.String);
            db.AddInParameter(commandAmarres, "i_option", DbType.String);
            db.AddInParameter(commandAmarres, "i_id", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_campana", DbType.String);
            db.AddInParameter(commandAmarres, "i_estado", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_usuario", DbType.String);
            db.AddInParameter(commandAmarres, "i_referencia", DbType.String);
            db.AddInParameter(commandAmarres, "i_plu", DbType.String);
            db.AddInParameter(commandAmarres, "i_tipoamarrepremio", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_tipoamarre", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_porvalor", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_porfecha", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_cantidad", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_fechaini", DbType.DateTime);
            db.AddInParameter(commandAmarres, "i_fechafin", DbType.DateTime);
            db.AddInParameter(commandAmarres, "i_valormin", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_valormax", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_descripcion", DbType.String);
            db.AddInParameter(commandAmarres, "i_descripcionpremio", DbType.String);
            db.AddInParameter(commandAmarres, "i_descripcionamarre", DbType.String);
            db.AddInParameter(commandAmarres, "i_pinta", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_descuento", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_numeropedido", DbType.String);
            db.AddInParameter(commandAmarres, "i_catalogo", DbType.String);
            db.AddInParameter(commandAmarres, "i_catalogoreal", DbType.String);
            db.AddInParameter(commandAmarres, "i_nit", DbType.String);
           
        }
        #endregion

        /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        public List<AmarreReglaInfo> ListReglas(string campana)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '1');
            db.SetParameterValue(commandAmarres, "i_campana", campana);

            List<AmarreReglaInfo> col = new List<AmarreReglaInfo>();

            IDataReader dr = null;

            AmarreReglaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarreRegla(dr);

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
        /// lista todos los amarres de una regla
        /// </summary>
        /// <returns></returns>
        public List<AmarresInfo> ListAmarres(int regla)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '3');
            db.SetParameterValue(commandAmarres, "i_id", regla);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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
        /// lista todos los premios de una regla
        /// </summary>
        /// <returns></returns>
        public List<AmarrePremioInfo> ListAmarresPremios(int regla)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '4');
            db.SetParameterValue(commandAmarres, "i_id", regla);

            List<AmarrePremioInfo> col = new List<AmarrePremioInfo>();

            IDataReader dr = null;

            AmarrePremioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarrePremios(dr);

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
        public PLUInfo producto(string plu, string referencia)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '5');
            db.SetParameterValue(commandAmarres, "i_plu", plu);
            db.SetParameterValue(commandAmarres, "i_referencia", referencia);

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

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
        /// lista un producto premio
        /// </summary>
        /// <returns></returns>
        public PLUInfo productoPremio(string plu, string referencia)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '7');
            db.SetParameterValue(commandAmarres, "i_plu", plu);
            db.SetParameterValue(commandAmarres, "i_referencia", referencia);

            IDataReader dr = null;

            PLUInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

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
        /// lista regla consecutiva
        /// </summary>
        /// <returns></returns>
        public AmarreReglaInfo Reglaconse()
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '6');


            IDataReader dr = null;

            AmarreReglaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarreRegla(dr);
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
        /// Guarda una regla amarre nueva
        /// </summary>
        /// <param name="item"></param>
        public int InsertRegla(AmarreReglaInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'I');
                db.SetParameterValue(commandAmarres, "i_option", 'A');
                

                db.SetParameterValue(commandAmarres, "i_id", item.Id);
                db.SetParameterValue(commandAmarres, "i_campana", item.Campana);
                db.SetParameterValue(commandAmarres, "i_estado", item.Estado);      
                db.SetParameterValue(commandAmarres, "i_valormin", item.Valormin);
                db.SetParameterValue(commandAmarres, "i_valormax", item.Valormax);
                db.SetParameterValue(commandAmarres, "i_porvalor", item.Porvalor);
                db.SetParameterValue(commandAmarres, "i_porfecha", item.Porfecha);
                db.SetParameterValue(commandAmarres, "i_fechaini", item.Fechaini.ToString("u"));
                db.SetParameterValue(commandAmarres, "i_fechafin", item.Fechafin.ToString("u"));
                db.SetParameterValue(commandAmarres, "i_tipoamarre", item.Tipoamarre);
                db.SetParameterValue(commandAmarres, "i_tipoamarrepremio", item.Tipoamarrepremio);
                db.SetParameterValue(commandAmarres, "i_usuario", usuario);
                db.SetParameterValue(commandAmarres, "i_descripcion", item.Descripcion);   


                dr = db.ExecuteReader(commandAmarres);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de una regla Amarre.  campañas:" + item.Campana+ ",   Descripcion: " + item.Descripcion + ". Acción Realizada por el Usuario: " + usuario;

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
        /// Guarda un amarre nuevo
        /// </summary>
        /// <param name="item"></param>
        public int InsertAmarre(AmarresInfo item, string usuario)
        {
            int id = 1;
/*
            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'I');
                db.SetParameterValue(commandAmarres, "i_option", 'B');

                db.SetParameterValue(commandAmarres, "i_id", item.Id);
                db.SetParameterValue(commandAmarres, "i_id", item.Id_regla);
                db.SetParameterValue(commandAmarres, "i_referencia", item.Referencia);
                db.SetParameterValue(commandAmarres, "i_plu", item.Plu);
                db.SetParameterValue(commandAmarres, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandAmarres, "i_cantidad", item.Cantidad);
                db.SetParameterValue(commandAmarres, "i_pinta", item.Pinta);                

                dr = db.ExecuteReader(commandAmarres);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de un Amarre.  Id_regla:" + item.Id_regla + ",   Plu: " + item.Plu + ",  Referencia: " + item.Referencia+". Acción Realizada por el Usuario: " + usuario;

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
            }*/
           // return id;

            return 0; 
        }

        /// <summary>
        /// Guarda un amarre premio
        /// </summary>
        /// <param name="item"></param>
        public int InsertPremio(AmarrePremioInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'I');
                db.SetParameterValue(commandAmarres, "i_option", 'C');
                
                db.SetParameterValue(commandAmarres, "i_id", item.Id_regla);
                db.SetParameterValue(commandAmarres, "i_referencia", item.Referencia);
                db.SetParameterValue(commandAmarres, "i_plu", item.Plu);
                db.SetParameterValue(commandAmarres, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandAmarres, "i_descuento", item.Descuento);
                db.SetParameterValue(commandAmarres, "i_cantidad", item.Cantidad);                

                dr = db.ExecuteReader(commandAmarres);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de un Premio Amarre.  Id_regla:" + item.Id_regla + ",   Plu: " + item.Plu + ",  Referencia: " + item.Referencia + ". Acción Realizada por el Usuario: " + usuario;

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
                db.SetParameterValue(commandAmarres, "i_operation", 'D');
                db.SetParameterValue(commandAmarres, "i_option", 'A');
                db.SetParameterValue(commandAmarres, "i_id", id);

                dr = db.ExecuteReader(commandAmarres);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de Regla:Codigo Regla Amarre: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// "borra" el detalle de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteAmarrePremios(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'D');
                db.SetParameterValue(commandAmarres, "i_option", 'B');
                db.SetParameterValue(commandAmarres, "i_id", id);

                dr = db.ExecuteReader(commandAmarres);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de Amarre y premios para su edicion:Codigo Regla Amarre: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                db.SetParameterValue(commandAmarres, "i_operation", 'U');
                db.SetParameterValue(commandAmarres, "i_option", 'A');
                db.SetParameterValue(commandAmarres, "i_id", id);
                db.SetParameterValue(commandAmarres, "i_estado", activo);

                dr = db.ExecuteReader(commandAmarres);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una Edicion de activacion " + activo + " de Regla:Codigo Regla Amarre: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// lista una regla
        /// </summary>
        /// <returns></returns>
        public AmarreReglaInfo Reglas(string id)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '2');
            db.SetParameterValue(commandAmarres, "i_id", id);

            IDataReader dr = null;

            AmarreReglaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarreRegla(dr);
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
        /// actualiza una regla amarre 
        /// </summary>
        /// <param name="item"></param>
        public int UpdateRegla(AmarreReglaInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'U');
                db.SetParameterValue(commandAmarres, "i_option", 'B');

                db.SetParameterValue(commandAmarres, "i_id", item.Id);
                db.SetParameterValue(commandAmarres, "i_campana", item.Campana);
                db.SetParameterValue(commandAmarres, "i_estado", item.Estado);
                db.SetParameterValue(commandAmarres, "i_valormin", item.Valormin);
                db.SetParameterValue(commandAmarres, "i_valormax", item.Valormax);
                db.SetParameterValue(commandAmarres, "i_porvalor", item.Porvalor);
                db.SetParameterValue(commandAmarres, "i_porfecha", item.Porfecha);
                db.SetParameterValue(commandAmarres, "i_fechaini", item.Fechaini);
                db.SetParameterValue(commandAmarres, "i_fechafin", item.Fechafin);
                db.SetParameterValue(commandAmarres, "i_tipoamarre", item.Tipoamarre);
                db.SetParameterValue(commandAmarres, "i_tipoamarrepremio", item.Tipoamarrepremio);
                db.SetParameterValue(commandAmarres, "i_usuario", usuario);
                db.SetParameterValue(commandAmarres, "i_descripcion", item.Descripcion);


                dr = db.ExecuteReader(commandAmarres);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó edicion de una regla Amarre.  Id:" + item.Id + ",. Acción Realizada por el Usuario: " + usuario;

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
        /// Guarda una regla amarre nueva
        /// </summary>
        /// <param name="item"></param>
        public int InsertPedidoTEMP(string usuario, string plu, int cantidad, string catalogo, string catalogoreal)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'I');
                db.SetParameterValue(commandAmarres, "i_option", 'D');
                
                db.SetParameterValue(commandAmarres, "i_usuario", usuario);
                db.SetParameterValue(commandAmarres, "i_plu", plu);
                db.SetParameterValue(commandAmarres, "i_cantidad", cantidad);
                db.SetParameterValue(commandAmarres, "i_catalogo", catalogo);
                db.SetParameterValue(commandAmarres, "i_catalogoreal", catalogoreal);               
                
                dr = db.ExecuteReader(commandAmarres);
               
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
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeletePedidosTemporales(string usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'D');
                db.SetParameterValue(commandAmarres, "i_option", 'C');
                db.SetParameterValue(commandAmarres, "i_usuario", usuario);
              

                dr = db.ExecuteReader(commandAmarres);

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
        ///  procesa los amarres precio diferenciado
        /// </summary>
        /// <returns></returns>
        public DataTable procesar(string numero, string campana)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'P');
            db.SetParameterValue(commandAmarres, "i_option", '2');
            db.SetParameterValue(commandAmarres, "i_nit", numero);
            db.SetParameterValue(commandAmarres, "i_campana", campana);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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

            return dt;
        }



        /// <summary>
        /// Obtener cantidad de premio no descuento
        /// </summary>
        /// <param name="plu"></param>
        /// <returns></returns>
        public DataTable obtenerCantidad(string plu)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '8');
            db.SetParameterValue(commandAmarres, "i_plu", plu);

            DataTable dt = new DataTable();
            IDataReader dr = null;                      

            try
            {
                dr = db.ExecuteReader(commandAmarres);
                dt.Load(dr);
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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

            return dt;
        }
    }
}
