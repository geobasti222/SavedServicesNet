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
    public class Asistente
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAsistente;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Asistente(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Asistente()
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
            commandAsistente = db.GetStoredProcCommand("PRC_SVDN_ASISTENTES");

            db.AddInParameter(commandAsistente, "i_operation", DbType.String);
            db.AddInParameter(commandAsistente, "i_option", DbType.String);

            db.AddInParameter(commandAsistente, "i_zona", DbType.String);
            db.AddInParameter(commandAsistente, "i_asistente", DbType.String);
            db.AddInParameter(commandAsistente, "i_nombres", DbType.String);
            db.AddInParameter(commandAsistente, "i_fechaingreso", DbType.DateTime );
            db.AddInParameter(commandAsistente, "i_fechanacimiento", DbType.DateTime);
            db.AddInParameter(commandAsistente, "i_Sexo", DbType.String);
            db.AddInParameter(commandAsistente, "i_codciudad", DbType.String);
            db.AddInParameter(commandAsistente, "i_nombreuno", DbType.String);
            db.AddInParameter(commandAsistente, "i_nombredos", DbType.String);
            db.AddInParameter(commandAsistente, "i_apellidouno", DbType.String);
            db.AddInParameter(commandAsistente, "i_apellidodos", DbType.String);
            db.AddInParameter(commandAsistente, "i_direccion", DbType.String);
            db.AddInParameter(commandAsistente, "i_email", DbType.String);
            db.AddInParameter(commandAsistente, "i_telefonouno", DbType.String);
            db.AddInParameter(commandAsistente, "i_telefonodos", DbType.String);
            db.AddInParameter(commandAsistente, "i_emailnivi", DbType.String);
            db.AddInParameter(commandAsistente, "i_activo", DbType.Int32);


            db.AddOutParameter(commandAsistente, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandAsistente, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Asistente

        public bool InsertAsistente(AsistenteInfo item, string Usuario)
        {
            bool oktrans = false;
            string Nombres="";

            Nombres= item.NombreUno  + " " + item.NombreDos  + " " + item.ApellidoUno    + " " + item.ApellidoDos;   

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAsistente, "i_operation", 'I');
                db.SetParameterValue(commandAsistente, "i_option", 'A');


                db.SetParameterValue(commandAsistente, "i_asistente", item.Asistente);
                db.SetParameterValue(commandAsistente, "i_nombres", Nombres);
                db.SetParameterValue(commandAsistente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandAsistente, "i_Sexo", item.Sexo);
                db.SetParameterValue(commandAsistente, "i_codciudad", item.Codciudad );
                db.SetParameterValue(commandAsistente, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandAsistente, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandAsistente, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandAsistente, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandAsistente, "i_direccion", item.Direccion);
                db.SetParameterValue(commandAsistente, "i_email", item.Email);
                db.SetParameterValue(commandAsistente, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandAsistente, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandAsistente, "i_emailnivi", item.EmailNivi);
                db.SetParameterValue(commandAsistente, "i_activo", item.Activo );

                dr = db.ExecuteReader(commandAsistente);

                oktrans = true;
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //Guardar auditoria 
                    try
                    {
                        Auditoria objAuditoria = new Auditoria("conexion");
                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                        objAuditoriaInfo.Usuario = Usuario;
                        objAuditoriaInfo.Proceso = "Se realizó la creación de Asistente:Cedula Asistente: " + item.Asistente + " nombre : " + Nombres + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// GAVL  INSERTA ASISTENTES X ZONAS
        /// </summary>
        /// <param name="Asistente"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertAsistenteXZona(string Asistente, string Zona, string Usuario)
        {
            bool oktrans = false;


            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAsistente, "i_operation", 'I');
                db.SetParameterValue(commandAsistente, "i_option", 'B');


                db.SetParameterValue(commandAsistente, "i_asistente", Asistente);
                db.SetParameterValue(commandAsistente, "i_zona", Zona);

                dr = db.ExecuteReader(commandAsistente);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación de AsistenteXZona:Cedula Asistente: " + Asistente + " Zona: " + Zona + ". Acción Realizada por el Usuario: " + Usuario;

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



        public bool UpdateAsistente(AsistenteInfo item, string Usuario)
        {
            bool oktrans = false;
            string Nombres = "";

            Nombres = item.NombreUno + " " + item.NombreDos + " " + item.ApellidoUno + " " + item.ApellidoDos;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAsistente, "i_operation", 'U');
                db.SetParameterValue(commandAsistente, "i_option", 'A');


                db.SetParameterValue(commandAsistente, "i_asistente", item.Asistente);
                db.SetParameterValue(commandAsistente, "i_nombres", Nombres);
                db.SetParameterValue(commandAsistente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandAsistente, "i_Sexo", item.Sexo);
                db.SetParameterValue(commandAsistente, "i_codciudad", item.Codciudad);
                db.SetParameterValue(commandAsistente, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandAsistente, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandAsistente, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandAsistente, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandAsistente, "i_direccion", item.Direccion);
                db.SetParameterValue(commandAsistente, "i_email", item.Email);
                db.SetParameterValue(commandAsistente, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandAsistente, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandAsistente, "i_emailnivi", item.EmailNivi);
                db.SetParameterValue(commandAsistente, "i_activo", item.Activo);

                dr = db.ExecuteReader(commandAsistente);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó una actualizacion de Asistente:Cedula Asistente: " + item.Asistente + " nombre : " + Nombres + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// lista todos los Paises existentes.
        /// </summary>
        /// <returns></returns>
        public List<AsistenteInfo> List()
        {
            db.SetParameterValue(commandAsistente, "i_operation", 'S');
            db.SetParameterValue(commandAsistente, "i_option", 'A');

            List<AsistenteInfo> col = new List<AsistenteInfo>();

            IDataReader dr = null;

            AsistenteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAsistente);

                while (dr.Read())
                {
                    m = Factory.GetAsistente(dr);

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


        public AsistenteInfo ListXAsistenteXZona(string Zona, string asistente)
        {
            db.SetParameterValue(commandAsistente, "i_operation", 'S');
            db.SetParameterValue(commandAsistente, "i_option", 'B');
            db.SetParameterValue(commandAsistente, "i_zona", Zona);
            db.SetParameterValue(commandAsistente, "i_asistente", asistente);

            

            IDataReader dr = null;

            AsistenteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAsistente);

                while (dr.Read())
                {
                    m = Factory.GetAsistente(dr);

                    
                }
                if (m == null)
                {
                    m = new AsistenteInfo(); 
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
        /// 
        /// </summary>
        /// <param name="asistente"></param>
        /// <returns></returns>
        public AsistenteInfo ListXAsistente(string asistente)
        {
            db.SetParameterValue(commandAsistente, "i_operation", 'S');
            db.SetParameterValue(commandAsistente, "i_option", 'C');
            db.SetParameterValue(commandAsistente, "i_asistente", asistente);

            IDataReader dr = null;

            AsistenteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAsistente);

                while (dr.Read())
                {
                    m = Factory.GetAsistente(dr);
                }
                if (m == null)
                {
                    m = new AsistenteInfo();
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
        /// Lista todos los asistentes X Zona Asistente
        /// </summary>
        /// <returns></returns>
        public List<AsistenteInfo> ListAsiszona()
        {
            db.SetParameterValue(commandAsistente, "i_operation", 'S');
            db.SetParameterValue(commandAsistente, "i_option", 'D');

            List<AsistenteInfo> col = new List<AsistenteInfo>();

            IDataReader dr = null;

            AsistenteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAsistente);

                while (dr.Read())
                {
                    m = Factory.GetAsistente(dr);

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



        public AsistenteInfo AsistenteXZona(string Zona)
        {
            db.SetParameterValue(commandAsistente, "i_operation", 'S');
            db.SetParameterValue(commandAsistente, "i_option", 'E');
            db.SetParameterValue(commandAsistente, "i_zona", Zona);
            



            IDataReader dr = null;

            AsistenteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAsistente);

                while (dr.Read())
                {
                    m = Factory.GetAsistente(dr);


                }
                if (m == null)
                {
                    m = new AsistenteInfo();
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
        /// Busca la zona para revisar las fecha de apertura y cierre
        /// </summary>
        /// <returns></returns>
        public string ListZona(string Asistente)
        {

            string Zona="";

            db.SetParameterValue(commandAsistente, "i_operation", 'S');
            db.SetParameterValue(commandAsistente, "i_option", 'F');
            db.SetParameterValue(commandAsistente, "i_asistente", Asistente);

            
            IDataReader dr = null;

            AsistenteInfo m = new AsistenteInfo();

            try
            {
                dr = db.ExecuteReader(commandAsistente);

                while (dr.Read())
                {
                    m = Factory.GetAsistente(dr);
                }

                Zona = m.Zona;
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

            return Zona;
        }

       


        /// <summary>
        /// GAVL  ELIMINA ASISTENTES X ZONAS
        /// </summary>
        /// <param name="Asistente"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteAsistenteXZona(string Asistente, string Zona, string Usuario)
        {
            bool oktrans = false;


            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAsistente, "i_operation", 'D');
                db.SetParameterValue(commandAsistente, "i_option", 'A');


                db.SetParameterValue(commandAsistente, "i_asistente", Asistente);
                db.SetParameterValue(commandAsistente, "i_zona", Zona);

                dr = db.ExecuteReader(commandAsistente);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la eliminacion de AsistenteXZona:Cedula Asistente: " + Asistente + " Zona: " + Zona + ". Acción Realizada por el Usuario: " + Usuario;

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



        



        #endregion
    }
}