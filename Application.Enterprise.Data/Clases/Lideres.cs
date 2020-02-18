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
    public class Lideres
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandLideres;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Lideres(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Lideres()
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
            commandLideres = db.GetStoredProcCommand("PRC_SVDN_LIDERES");

            db.AddInParameter(commandLideres, "i_operation", DbType.String);
            db.AddInParameter(commandLideres, "i_option", DbType.String);
            db.AddInParameter(commandLideres, "i_cedula", DbType.String);
            db.AddInParameter(commandLideres, "i_nombres", DbType.String);
            db.AddInParameter(commandLideres, "i_fechaingreso", DbType.DateTime);
            db.AddInParameter(commandLideres, "i_fechanacimiento", DbType.DateTime);
            db.AddInParameter(commandLideres, "i_localizacion", DbType.String);
            db.AddInParameter(commandLideres, "i_sexo", DbType.String);
            db.AddInParameter(commandLideres, "i_codciudad", DbType.String);
            db.AddInParameter(commandLideres, "i_nombreuno", DbType.String);
            db.AddInParameter(commandLideres, "i_nombredos", DbType.String);
            db.AddInParameter(commandLideres, "i_apellidouno", DbType.String);
            db.AddInParameter(commandLideres, "i_apellidodos", DbType.String);
            db.AddInParameter(commandLideres, "i_direccion", DbType.String);
            db.AddInParameter(commandLideres, "i_email", DbType.String);
            db.AddInParameter(commandLideres, "i_telefonouno", DbType.String);
            db.AddInParameter(commandLideres, "i_telefonodos", DbType.String);
            db.AddInParameter(commandLideres, "i_telefonotres", DbType.String);
            db.AddInParameter(commandLideres, "i_emailnivi", DbType.String);
            db.AddInParameter(commandLideres, "i_zona", DbType.String);
            db.AddInParameter(commandLideres, "i_activo", DbType.Int32);
            db.AddInParameter(commandLideres, "i_tpr_id", DbType.Int32);

            db.AddOutParameter(commandLideres, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandLideres, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Lideres


        /// <summary>
        /// Guarda un descuento nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(LideresInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandLideres, "i_operation", 'I');
                db.SetParameterValue(commandLideres, "i_option", 'A');

                db.SetParameterValue(commandLideres, "i_cedula", item.Cedula);
                db.SetParameterValue(commandLideres, "i_nombres", item.Nombres);
                db.SetParameterValue(commandLideres, "i_fechaingreso", item.FechaIngreso);
                db.SetParameterValue(commandLideres, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandLideres, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandLideres, "i_sexo", item.Sexo);
                db.SetParameterValue(commandLideres, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandLideres, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandLideres, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandLideres, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandLideres, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandLideres, "i_direccion", item.Direccion);
                db.SetParameterValue(commandLideres, "i_email", item.Email);
                db.SetParameterValue(commandLideres, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandLideres, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandLideres, "i_telefonotres", item.TelefonoTres);
                db.SetParameterValue(commandLideres, "i_emailnivi", item.EmailNivi);
                db.SetParameterValue(commandLideres, "i_zona", item.Zona);
                db.SetParameterValue(commandLideres, "i_activo", item.Activo);
                db.SetParameterValue(commandLideres, "i_tpr_id", item.IdTipoRed);

                dr = db.ExecuteReader(commandLideres);

                //Obtiene el identificador (consecutivo) del insert
                id = 1; //1 = OK Trans.


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de lider.  Cedula:" + item.Cedula+ ",   Nombre Completo: " + item.Nombres + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de un lider existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(LideresInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandLideres, "i_operation", 'U');
                db.SetParameterValue(commandLideres, "i_option", 'A');

                db.SetParameterValue(commandLideres, "i_cedula", item.Cedula);
                db.SetParameterValue(commandLideres, "i_nombres", item.Nombres);
                db.SetParameterValue(commandLideres, "i_fechaingreso", item.FechaIngreso);
                db.SetParameterValue(commandLideres, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandLideres, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandLideres, "i_sexo", item.Sexo);
                db.SetParameterValue(commandLideres, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandLideres, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandLideres, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandLideres, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandLideres, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandLideres, "i_direccion", item.Direccion);
                db.SetParameterValue(commandLideres, "i_email", item.Email);
                db.SetParameterValue(commandLideres, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandLideres, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandLideres, "i_telefonotres", item.TelefonoTres);
                db.SetParameterValue(commandLideres, "i_emailnivi", item.EmailNivi);
                db.SetParameterValue(commandLideres, "i_zona", item.Zona);
                db.SetParameterValue(commandLideres, "i_activo", item.Activo);
                db.SetParameterValue(commandLideres, "i_tpr_id", item.IdTipoRed);

                dr = db.ExecuteReader(commandLideres);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualización de lider. Nuevos Valores para Cedula:" + item.Cedula  + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Elimina un lider.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public bool Delete(string Cedula, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandLideres, "i_operation", 'D');
                db.SetParameterValue(commandLideres, "i_option", 'A');

                db.SetParameterValue(commandLideres, "cedula", Cedula);

                dr = db.ExecuteReader(commandLideres);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la eliminación de lider. Cedula :" + Cedula + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// Lista todos las lideres.
        /// </summary>
        /// <returns></returns>
        public List<LideresInfo> List()
        {
            db.SetParameterValue(commandLideres, "i_operation", 'S');
            db.SetParameterValue(commandLideres, "i_option", 'A');

            List<LideresInfo> col = new List<LideresInfo>();

            IDataReader dr = null;

            LideresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLideres);

                while (dr.Read())
                {
                    m = Factory.GetLideres(dr);

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
        /// Lista todos las lideres x zona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<LideresInfo> ListxZona(string IdZona)
        {
            db.SetParameterValue(commandLideres, "i_operation", 'S');
            db.SetParameterValue(commandLideres, "i_option", 'B');
            db.SetParameterValue(commandLideres, "i_zona", IdZona);

            List<LideresInfo> col = new List<LideresInfo>();

            IDataReader dr = null;

            LideresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLideres);

                while (dr.Read())   
                {
                    m = Factory.GetLideres(dr);

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
        /// Lista todos las lideres x zona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<LideresInfo> ListLideresxZona(string IdZona)
        {
            db.SetParameterValue(commandLideres, "i_operation", 'S');
            db.SetParameterValue(commandLideres, "i_option", 'C');
            db.SetParameterValue(commandLideres, "i_zona", IdZona);

            List<LideresInfo> col = new List<LideresInfo>();

            IDataReader dr = null;

            LideresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLideres);

                while (dr.Read())
                {
                    m = Factory.GetLideres(dr);

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
        /// Lista todos las lideres x subzona activos.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<LideresInfo> ListLideresxSubZona(string IdZona)
        {
            db.SetParameterValue(commandLideres, "i_operation", 'S');
            db.SetParameterValue(commandLideres, "i_option", "C1");
            db.SetParameterValue(commandLideres, "i_zona", IdZona);

            List<LideresInfo> col = new List<LideresInfo>();

            IDataReader dr = null;

            LideresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLideres);

                while (dr.Read())
                {
                    m = Factory.GetLideres(dr);

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
        /// Lista un lider x cedula.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public LideresInfo ListxCedula(string Cedula)
        {
            db.SetParameterValue(commandLideres, "i_operation", 'S');
            db.SetParameterValue(commandLideres, "i_option", 'D');
            db.SetParameterValue(commandLideres, "i_cedula", Cedula);

            IDataReader dr = null;

            LideresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLideres);

                while (dr.Read())
                {
                    m = Factory.GetLideres(dr);
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
        /// Lista la ciudad de un lider por usuario.
        /// </summary>
        /// <param name="clave_acce"></param>
        /// <returns></returns>
        public LideresInfo ListxCiudadxUsuario(string clave_acce)
        {
            db.SetParameterValue(commandLideres, "i_operation", 'S');
            db.SetParameterValue(commandLideres, "i_option", 'F');
            db.SetParameterValue(commandLideres, "i_direccion", clave_acce); //OJO: lo mando al parametro direccion xq es el unico que tiene 200 caracteres como la clave.

            IDataReader dr = null;

            LideresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLideres);

                while (dr.Read())
                {
                    m = Factory.GetLideres(dr);
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