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
    public class ReglaPuntos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandReglaPunto;
        

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReglaPuntos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReglaPuntos()
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
            commandReglaPunto = db.GetStoredProcCommand("PRC_SVDN_REGLASPUNTOS");

            db.AddInParameter(commandReglaPunto, "i_operation", DbType.String);
            db.AddInParameter(commandReglaPunto, "i_option", DbType.String);
            db.AddInParameter(commandReglaPunto, "i_campana", DbType.String);
            db.AddInParameter(commandReglaPunto, "i_campanafin", DbType.String);
            db.AddInParameter(commandReglaPunto, "i_cantidadconse", DbType.Int32);
            db.AddInParameter(commandReglaPunto, "i_cantidadest", DbType.Int32);  
            db.AddInParameter(commandReglaPunto, "i_descripcion", DbType.String);
            db.AddInParameter(commandReglaPunto, "i_usuario", DbType.String);
            db.AddInParameter(commandReglaPunto, "i_numero", DbType.String);
            db.AddInParameter(commandReglaPunto, "i_valormin", DbType.Int32);
            db.AddInParameter(commandReglaPunto, "i_puntosad", DbType.Int32);
            db.AddInParameter(commandReglaPunto, "i_idxcampana", DbType.Int32);
            db.AddInParameter(commandReglaPunto, "i_id", DbType.Int32);
            db.AddInParameter(commandReglaPunto, "i_estado", DbType.Boolean);
            db.AddInParameter(commandReglaPunto, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandReglaPunto, "i_tipoestadop", DbType.Int32);  
        }

        /// <summary>
        /// lista todos las reglas puntos existentes
        /// </summary>
        /// <returns></returns>
        public List<ReglaPuntoInfo> List(string campana)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '1');
            db.SetParameterValue(commandReglaPunto, "i_campana", campana);

            List<ReglaPuntoInfo> col = new List<ReglaPuntoInfo>();

            IDataReader dr = null;

            ReglaPuntoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                while (dr.Read())
                {
                    m = Factory.getReglaPuntos(dr);

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
        /// lista todos las reglas puntos existentes por campana
        /// </summary>
        /// <returns></returns>
        public List<ReglaPuntoInfo> ListxCampana(string campana)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '2');
            db.SetParameterValue(commandReglaPunto, "i_campana", campana);

            List<ReglaPuntoInfo> col = new List<ReglaPuntoInfo>();

            IDataReader dr = null;

            ReglaPuntoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                while (dr.Read())
                {
                    m = Factory.getReglaPuntos(dr);

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
        /// lista uno las reglas puntos existentes por campana order by idxcampana desc
        /// </summary>
        /// <returns></returns>
        public ReglaPuntoInfo ListUnoxCampana(string campana)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '3');
            db.SetParameterValue(commandReglaPunto, "i_campana", campana);         

            IDataReader dr = null;

            ReglaPuntoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                while (dr.Read())
                {
                    m = Factory.getReglaPuntos(dr);                    
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
        /// Prcesa los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool PorcesoPuntos(string campana,string numero)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglaPunto, "i_operation", 'P');
                db.SetParameterValue(commandReglaPunto, "i_option", '1');

                db.SetParameterValue(commandReglaPunto, "i_campana", campana);
                db.SetParameterValue(commandReglaPunto, "i_numero", numero);              

                dr = db.ExecuteReader(commandReglaPunto);

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
        /// Anula los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool AnularPuntos( string numero)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglaPunto, "i_operation", 'P');
                db.SetParameterValue(commandReglaPunto, "i_option", '2');
                
                db.SetParameterValue(commandReglaPunto, "i_numero", numero);

                dr = db.ExecuteReader(commandReglaPunto);

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
        /// Inserta los datos del reglas puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool Insert(ReglaPuntoInfo item, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglaPunto, "i_operation", 'I');
                db.SetParameterValue(commandReglaPunto, "i_option", '1');

                db.SetParameterValue(commandReglaPunto, "i_id", item.Id);
                db.SetParameterValue(commandReglaPunto, "i_campana", item.Campana);
                db.SetParameterValue(commandReglaPunto, "i_cantidadconse", item.CantidadConse);
                db.SetParameterValue(commandReglaPunto, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandReglaPunto, "i_usuario", item.Usuario);
                db.SetParameterValue(commandReglaPunto, "i_fecha", item.Fecha);
                db.SetParameterValue(commandReglaPunto, "i_estado", item.Estado);
                db.SetParameterValue(commandReglaPunto, "i_valormin", item.Valormin);                
                db.SetParameterValue(commandReglaPunto, "i_idxcampana", item.IdxCampana);
                db.SetParameterValue(commandReglaPunto, "i_puntosad", item.PuntosAd);

                dr = db.ExecuteReader(commandReglaPunto);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación de Regla punto: Campana: " + item.Campana + " Estado : " + item.Estado + " valormin : " + item.Valormin + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerMisPuntos(String nit)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '4');
            db.SetParameterValue(commandReglaPunto, "i_usuario", nit);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                //while (dr.Read())
                //{
                //    System.Diagnostics.Trace.WriteLine("h1");
                //}

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
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerMisPuntosTotal(String nit)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '5');
            db.SetParameterValue(commandReglaPunto, "i_usuario", nit);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                //while (dr.Read())
                //{
                //    System.Diagnostics.Trace.WriteLine("h1");
                //}

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
        /// Motor de los puntos
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public void MotorPuntos(string campana)
        {            
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglaPunto, "i_operation", 'P');
                db.SetParameterValue(commandReglaPunto, "i_option", '3');
                db.SetParameterValue(commandReglaPunto, "i_campana", campana);

                dr = db.ExecuteReader(commandReglaPunto);               

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
        }

        /// <summary>
        /// lista por una campaña especifica.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public CampanaInfo ListxCampana()
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '6');
            

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                if (dr.Read())
                {
                    m = Factory.GetCampana(dr);
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
        /// borra una regla
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
                db.SetParameterValue(commandReglaPunto, "i_operation", 'D');
                db.SetParameterValue(commandReglaPunto, "i_option", 'A');
                db.SetParameterValue(commandReglaPunto, "i_id", id);

                dr = db.ExecuteReader(commandReglaPunto);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de Regla:Codigo Regla: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
        ///  acutaliza una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateEstadoReglas(int id, string Usuario, int estado)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglaPunto, "i_operation", 'U');
                db.SetParameterValue(commandReglaPunto, "i_option", 'A');
                db.SetParameterValue(commandReglaPunto, "i_id", id);
                db.SetParameterValue(commandReglaPunto, "i_estado", estado);

                dr = db.ExecuteReader(commandReglaPunto);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó el cambio de estado de una regla:Codigo Regla: " + id + " Estado: " + estado + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// lista uno las reglas puntos existentes por campana order by idxcampana desc
        /// </summary>
        /// <returns></returns>
        public ReglaPuntoInfo ListUnoxidCampana(string campana,string id)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '8');
            db.SetParameterValue(commandReglaPunto, "i_campana", campana);
            db.SetParameterValue(commandReglaPunto, "i_idxcampana", id);

            IDataReader dr = null;

            ReglaPuntoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                while (dr.Read())
                {
                    m = Factory.getReglaPuntos(dr);
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
        /// Prcesa los puntos para el 90% nivel servicio
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool PorcesoPuntos90(string numero)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandReglaPunto, "i_operation", 'P');
                db.SetParameterValue(commandReglaPunto, "i_option", '1');
                
                db.SetParameterValue(commandReglaPunto, "i_numero", numero);

                dr = db.ExecuteReader(commandReglaPunto);

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
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public PuntosTotalEmpreInfo traerMisPuntosTotalEmp(String nit)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '5');
            db.SetParameterValue(commandReglaPunto, "i_usuario", nit);

            IDataReader dr = null;
            PuntosTotalEmpreInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                while (dr.Read())
                {
                    m = Factory.getpuntosTotalEmpre(dr);
                }
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

            return m;
        }


        /// <summary>
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerMisPuntosCampana(String nit, string campana, string campanafin)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", '9');
            db.SetParameterValue(commandReglaPunto, "i_usuario", nit);
            db.SetParameterValue(commandReglaPunto, "i_campana", campana);
            db.SetParameterValue(commandReglaPunto, "i_campanafin", campanafin);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                //while (dr.Read())
                //{
                //    System.Diagnostics.Trace.WriteLine("h1");
                //}

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
        /// Traer puntos de empresaria
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerPuntosEmpresariasGerente(String zona)
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", 'A');
            db.SetParameterValue(commandReglaPunto, "i_usuario", zona);
            

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                //while (dr.Read())
                //{
                //    System.Diagnostics.Trace.WriteLine("h1");
                //}

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
        /// Guarda estados de la regla puntos
        /// </summary>
        /// <param name="item"></param>
        public int Insertestados(EstadosPremiosInfo item, string usuario)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandReglaPunto, "i_operation", 'I');
                db.SetParameterValue(commandReglaPunto, "i_option", '2');

                db.SetParameterValue(commandReglaPunto, "i_id", item.IdRegla);               
                db.SetParameterValue(commandReglaPunto, "i_tipoestadop", item.TipoEstado);
                db.SetParameterValue(commandReglaPunto, "i_cantidadest", item.Cantidad);


                dr = db.ExecuteReader(commandReglaPunto);

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
        /// lista regla consecutiva
        /// </summary>
        /// <returns></returns>
        public ReglaPuntoInfo Reglaconse()
        {
            db.SetParameterValue(commandReglaPunto, "i_operation", 'S');
            db.SetParameterValue(commandReglaPunto, "i_option", 'B');


            IDataReader dr = null;

            ReglaPuntoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandReglaPunto);

                while (dr.Read())
                {
                    m = Factory.getReglaPuntos(dr);
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
