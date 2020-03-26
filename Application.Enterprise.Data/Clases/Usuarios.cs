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
    public class Usuarios
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandUsuarios;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Usuarios(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Usuarios()
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
            commandUsuarios = db.GetStoredProcCommand("PRC_SVDN_SUSUARIOS");

            db.AddInParameter(commandUsuarios, "i_operation", DbType.String);
            db.AddInParameter(commandUsuarios, "i_option", DbType.String);
            db.AddInParameter(commandUsuarios, "i_usuario", DbType.String);
            db.AddInParameter(commandUsuarios, "i_clave_acce", DbType.String);
            db.AddInParameter(commandUsuarios, "i_descripcion", DbType.String);
            db.AddInParameter(commandUsuarios, "i_grupo", DbType.String);
            db.AddInParameter(commandUsuarios, "i_vencimiento", DbType.DateTime);
            db.AddInParameter(commandUsuarios, "i_activo", DbType.Int32);
            db.AddInParameter(commandUsuarios, "i_codigo", DbType.String);
            db.AddInParameter(commandUsuarios, "i_accesoweb", DbType.Boolean);
            db.AddInParameter(commandUsuarios, "i_email", DbType.String);
            db.AddInParameter(commandUsuarios, "i_clave_acce_nueva", DbType.String);
            db.AddInParameter(commandUsuarios, "i_vendedor", DbType.String);

            db.AddOutParameter(commandUsuarios, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandUsuarios, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Usuarios

        /// <summary>
        /// lista todos los Usuarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<UsuariosInfo> List()
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'A');

            List<UsuariosInfo> col = new List<UsuariosInfo>();

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                while (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);

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
        /// Lista un usuario especifico.
        /// </summary>
        /// <param name="Usuario">Usuario (NIT)</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuario(string Usuario)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'B');
            db.SetParameterValue(commandUsuarios, "i_usuario", Usuario);

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);
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
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioSVDN(string Clave)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'C');
            db.SetParameterValue(commandUsuarios, "i_clave_acce", Clave);

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);
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
        /// Lista un usuario especifico del sistema de administracion.
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioSVDN(string Clave, string Usuario)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'Q');
            db.SetParameterValue(commandUsuarios, "i_clave_acce", Clave);
            db.SetParameterValue(commandUsuarios, "i_usuario", Usuario);

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);
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
        /// Lista un usuario especifico del sistema de administracion. JUTA USU Y PASS
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioSVDNJUTAUSUYPASS(string Clave, string usu)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'K');
            db.SetParameterValue(commandUsuarios, "i_clave_acce", Clave);
            db.SetParameterValue(commandUsuarios, "i_usuario", usu);

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);
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
        /// Lista un usuario especifico del sistema de administracion. JUTA USU Y PASS
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioEmailFaceGoogle(string email)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'L');
            db.SetParameterValue(commandUsuarios, "i_email", email);
            

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);
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
        /// Lista un usuario especifico del sistema de G&G y SVDN
        /// </summary>
        /// <param name="Clave">Clave</param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioGYG(string Clave)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'F');
            db.SetParameterValue(commandUsuarios, "i_clave_acce", Clave);

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarioOnly(dr);
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
        /// Devuelve un usuario de gerente de zona consultado por cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioxCedula(string Cedula)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'I');
            db.SetParameterValue(commandUsuarios, "i_usuario", Cedula);

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);
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
        /// Devuelve un usuario de una empresaria web consultado por cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public UsuariosInfo ListxUsuarioEmpresariaxCedula(string Cedula)
        {
            db.SetParameterValue(commandUsuarios, "i_operation", 'S');
            db.SetParameterValue(commandUsuarios, "i_option", 'J');
            db.SetParameterValue(commandUsuarios, "i_usuario", Cedula);

            IDataReader dr = null;

            UsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandUsuarios);

                if (dr.Read())
                {
                    m = Factory.GetUsuarios(dr);
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
        /// Realiza el cambio de clave de una empresaria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePassword(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'U');
                db.SetParameterValue(commandUsuarios, "i_option", 'A');
                db.SetParameterValue(commandUsuarios, "i_usuario", item.Usuario);
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);

                dr = db.ExecuteReader(commandUsuarios);

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
        /// Realiza el cambio de clave de un usuario del sistema en G&G y SVDN en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordGYG(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'U');
                db.SetParameterValue(commandUsuarios, "i_option", 'B');
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_clave_acce_nueva", item.ClaveNueva);
                db.SetParameterValue(commandUsuarios, "i_vendedor", item.IdVendedor);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.NombreUsuario;
                    objAuditoriaInfo.Proceso = "Se realizó Actualización de Clave de Usuario: Clave Anterior: " + item.Clave + " , Nueva Clave:" + item.ClaveNueva + ". Acción Realizada por el Usuario: " + item.NombreUsuario;

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
        /// Realiza el cambio de clave de un usuario del sistema de una empresarias .
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordEmpresaria(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'U');
                db.SetParameterValue(commandUsuarios, "i_option", 'C');
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_clave_acce_nueva", item.ClaveNueva);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.NombreUsuario;
                    objAuditoriaInfo.Proceso = "Se realizó Actualización de Clave de Empresaria: Clave Anterior: " + item.Clave + " , Nueva Clave:" + item.ClaveNueva + ". Acción Realizada por el Usuario: " + item.NombreUsuario;

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
        /// Realiza el reinicio de clave de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordReiniciar(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'U');
                db.SetParameterValue(commandUsuarios, "i_option", 'E');
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_clave_acce_nueva", item.ClaveNueva);
                db.SetParameterValue(commandUsuarios, "i_vendedor", item.IdVendedor);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.NombreUsuario;
                    objAuditoriaInfo.Proceso = "Se realizó Actualización de Clave de Usuario: Clave Anterior: " + item.Clave + " , Nueva Clave:" + item.ClaveNueva + " , IdVendedor:" + item.IdVendedor + ". Acción Realizada por el Usuario: " + item.NombreUsuario;

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
        /// -Realiza la inactivacion de clave de un usuario del sistema en G&G y SVDN
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateInactivarUsuario(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'U');
                db.SetParameterValue(commandUsuarios, "i_option", 'F');
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_vendedor", item.IdVendedor);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.NombreUsuario;
                    objAuditoriaInfo.Proceso = "Se realizó inactivacion de Clave de Usuario: Clave Anterior: " + item.Clave + " , IdVendedor:" + item.IdVendedor + ". Acción Realizada por el Usuario: " + item.NombreUsuario;

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
        /// Realiza el reinicio de clave de una empresaria Web  en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordReiniciarEmpresaria(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'U');
                db.SetParameterValue(commandUsuarios, "i_option", 'G');
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_clave_acce_nueva", item.ClaveNueva);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.NombreUsuario;
                    objAuditoriaInfo.Proceso = "Se realizó Actualización de Clave de Usuario: Clave Anterior: " + item.Clave + " , Nueva Clave:" + item.ClaveNueva + " , IdVendedor:" + item.IdVendedor + ". Acción Realizada por el Usuario: " + item.NombreUsuario;

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
        /// Realiza el reinicio de clave de una empresaria Web  en el sistema x usaurio.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdatePasswordReiniciarEmpresariaxUsuario(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'U');
                db.SetParameterValue(commandUsuarios, "i_option", 'H');
                db.SetParameterValue(commandUsuarios, "i_usuario", item.Usuario);
                db.SetParameterValue(commandUsuarios, "i_clave_acce_nueva", item.ClaveNueva);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.NombreUsuario;
                    objAuditoriaInfo.Proceso = "Se realizó Actualización de Clave de Usuario: Nueva Clave:" + item.ClaveNueva + " , Usuario:" + item.Usuario + ". Acción Realizada por el Usuario: C.C. " + item.Usuario + " " + item.NombreUsuario;

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
        /// Alamacena la información de un usuario.
        /// </summary>
        /// <param name="item">objeto usuario info.</param>
        /// <returns>ok transaccion</returns>
        public bool Insert(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'I');
                db.SetParameterValue(commandUsuarios, "i_option", 'A');
                db.SetParameterValue(commandUsuarios, "i_usuario", item.Usuario);
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandUsuarios, "i_grupo", item.IdGrupo);
                db.SetParameterValue(commandUsuarios, "i_vencimiento", item.Vencimiento);
                db.SetParameterValue(commandUsuarios, "i_activo", item.Activo);
                db.SetParameterValue(commandUsuarios, "i_codigo", item.Codigo);
                db.SetParameterValue(commandUsuarios, "i_accesoweb", item.AccesoWeb);
                db.SetParameterValue(commandUsuarios, "i_email", item.Email);
                db.SetParameterValue(commandUsuarios, "i_vendedor", item.IdVendedor);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

            }
            catch (Exception ex)
            {
                transOk = false;

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
        /// Crea un usuario para una gerente zonal.
        /// </summary>
        /// <param name="item">objeto usuario info.</param>
        /// <returns>ok transaccion</returns>
        public bool InsertUsuarioGerenteZonal(UsuariosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'I');
                db.SetParameterValue(commandUsuarios, "i_option", 'B');
                db.SetParameterValue(commandUsuarios, "i_usuario", item.Usuario);
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandUsuarios, "i_grupo", item.IdGrupo);
                db.SetParameterValue(commandUsuarios, "i_vencimiento", item.Vencimiento);
                db.SetParameterValue(commandUsuarios, "i_activo", item.Activo);
                db.SetParameterValue(commandUsuarios, "i_codigo", item.Codigo);
                db.SetParameterValue(commandUsuarios, "i_accesoweb", item.AccesoWeb);
                db.SetParameterValue(commandUsuarios, "i_email", item.Email);
                db.SetParameterValue(commandUsuarios, "i_vendedor", item.IdVendedor);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

            }
            catch (Exception ex)
            {
                transOk = false;

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
        /// GAVL INGRESO DE USUSARIOS ASISTENTES Y NO PUEDEN REINICIAR CLAVE QUEDARA CON EL NUMERO DE CEDULA
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertSinReinciar(UsuariosInfo item, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandUsuarios, "i_operation", 'I');
                db.SetParameterValue(commandUsuarios, "i_option", 'C');
                db.SetParameterValue(commandUsuarios, "i_usuario", item.Usuario);
                db.SetParameterValue(commandUsuarios, "i_clave_acce", item.Clave);
                db.SetParameterValue(commandUsuarios, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandUsuarios, "i_grupo", item.IdGrupo);
                db.SetParameterValue(commandUsuarios, "i_vencimiento", item.Vencimiento);
                db.SetParameterValue(commandUsuarios, "i_activo", item.Activo);
                db.SetParameterValue(commandUsuarios, "i_codigo", item.Codigo);
                db.SetParameterValue(commandUsuarios, "i_accesoweb", item.AccesoWeb);
                db.SetParameterValue(commandUsuarios, "i_email", item.Email);
                db.SetParameterValue(commandUsuarios, "i_vendedor", item.IdVendedor);

                dr = db.ExecuteReader(commandUsuarios);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación de usuario Asistente:Ususario: " + item.Usuario + " nombre : " + item.Descripcion  + ". Acción Realizada por el Usuario: " + Usuario;

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
                transOk = false;

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