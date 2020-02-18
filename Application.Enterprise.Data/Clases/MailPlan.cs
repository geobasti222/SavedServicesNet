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
    public class MailPlan
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMailPlan;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MailPlan(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MailPlan()
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
            commandMailPlan = db.GetStoredProcCommand("PRC_SVDN_MAILPLAN");

            db.AddInParameter(commandMailPlan, "i_operation", DbType.String);
            db.AddInParameter(commandMailPlan, "i_option", DbType.String);
            db.AddInParameter(commandMailPlan, "i_mpl_id", DbType.Int32);
            db.AddInParameter(commandMailPlan, "i_mpl_fechaapertura", DbType.DateTime);
            db.AddInParameter(commandMailPlan, "i_mpl_fechacierre", DbType.DateTime);
            db.AddInParameter(commandMailPlan, "i_MAILGROUP", DbType.Int32);
            db.AddInParameter(commandMailPlan, "i_CAMPANA", DbType.String);
            db.AddInParameter(commandMailPlan, "i_mpl_estado", DbType.Boolean);
            db.AddInParameter(commandMailPlan, "i_mpl_horacierre", DbType.String);
            db.AddInParameter(commandMailPlan, "i_zona", DbType.String);
            db.AddInParameter(commandMailPlan, "i_catalogo", DbType.String);

            db.AddOutParameter(commandMailPlan, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMailPlan, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de MailPlan

        /// <summary>
        /// lista todos los MailPlan existentes.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanInfo> List()
        {
            db.SetParameterValue(commandMailPlan, "i_operation", 'S');
            db.SetParameterValue(commandMailPlan, "i_option", 'A');

            List<MailPlanInfo> col = new List<MailPlanInfo>();

            IDataReader dr = null;

            MailPlanInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlan);

                while (dr.Read())
                {
                    m = Factory.GetMailPlan(dr);

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
        /// Lista un mailplan x id
        /// </summary>
        /// <param name="IdMailPlan"></param>
        /// <returns></returns>
        public MailPlanInfo ListxId(int IdMailPlan)
        {
            db.SetParameterValue(commandMailPlan, "i_operation", 'S');
            db.SetParameterValue(commandMailPlan, "i_option", 'B');
            db.SetParameterValue(commandMailPlan, "i_mpl_id", IdMailPlan);

            IDataReader dr = null;

            MailPlanInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlan);

                while (dr.Read())
                {
                    m = Factory.GetMailPlan(dr);
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
        /// Lista un mailplan x fecha y zona si esta activo para ingresar pedidos.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public MailPlanInfo ListxZonaxId(string Zona)
        {
            db.SetParameterValue(commandMailPlan, "i_operation", 'S');
            db.SetParameterValue(commandMailPlan, "i_option", 'C');
            db.SetParameterValue(commandMailPlan, "i_zona", Zona);

            IDataReader dr = null;

            MailPlanInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlan);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanxZona(dr);
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
        /// lista todos los MailPlan existentes para facturacion.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanInfo> ListMailPlanFacturacion()
        {
            db.SetParameterValue(commandMailPlan, "i_operation", 'S');
            db.SetParameterValue(commandMailPlan, "i_option", 'D');

            List<MailPlanInfo> col = new List<MailPlanInfo>();

            IDataReader dr = null;

            MailPlanInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlan);

                while (dr.Read())
                {
                    m = Factory.GetMailPlan(dr);

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
        ///--Lista un mailplan de facturacion diaria x fecha y zona si esta activo para ingresar pedidos.
        ///-- si hay mas de un mail plan activo solo se trae 1 que es el ultimo de la fecha configurado.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public MailPlanInfo ListxZonaxIdxFacturacionDiaria(string Zona)
        {
            db.SetParameterValue(commandMailPlan, "i_operation", 'S');
            db.SetParameterValue(commandMailPlan, "i_option", 'E');
            db.SetParameterValue(commandMailPlan, "i_zona", Zona);

            IDataReader dr = null;

            MailPlanInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlan);

                while (dr.Read())
                {
                    m = Factory.GetMailPlanxZona(dr);
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
        /// Lista todos los mailplan de facturacion diaria.
        /// </summary>
        /// <returns></returns>
        public List<MailPlanInfo> ListMailPlanFacturacionDiaria()
        {
            db.SetParameterValue(commandMailPlan, "i_operation", 'S');
            db.SetParameterValue(commandMailPlan, "i_option", 'F');

            List<MailPlanInfo> col = new List<MailPlanInfo>();

            IDataReader dr = null;

            MailPlanInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlan);

                while (dr.Read())
                {
                    m = Factory.GetMailPlan(dr);

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
        /// Lista un mailplan de facturacion diaria x id
        /// </summary>
        /// <param name="IdMailPlan"></param>
        /// <returns></returns>
        public MailPlanInfo ListxIdFacturacionDiaria(int IdMailPlan)
        {
            db.SetParameterValue(commandMailPlan, "i_operation", 'S');
            db.SetParameterValue(commandMailPlan, "i_option", 'G');
            db.SetParameterValue(commandMailPlan, "i_mpl_id", IdMailPlan);

            IDataReader dr = null;

            MailPlanInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailPlan);

                while (dr.Read())
                {
                    m = Factory.GetMailPlan(dr);
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
        /// Guarda un mailplan nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(MailPlanInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailPlan, "i_operation", 'I');
                db.SetParameterValue(commandMailPlan, "i_option", 'A');

                db.SetParameterValue(commandMailPlan, "i_mpl_fechaapertura", item.FechaApertura);
                db.SetParameterValue(commandMailPlan, "i_mpl_fechacierre", item.FechaCierre);
                db.SetParameterValue(commandMailPlan, "i_MAILGROUP", item.MailGroup);
                db.SetParameterValue(commandMailPlan, "i_CAMPANA", item.Campana);
                db.SetParameterValue(commandMailPlan, "i_mpl_estado", item.Estado);
                db.SetParameterValue(commandMailPlan, "i_mpl_horacierre", item.HoraCierre);
                db.SetParameterValue(commandMailPlan, "i_catalogo", item.Catalogo);

                dr = db.ExecuteReader(commandMailPlan);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se inserto un mail plan Nuevo: Mailgroupo: " + item.MailGroup + ", Campaña: " + item.Campana + ", Catalogo " + item.Catalogo + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Guarda un mailplan de facturacion diaria nuevo.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertFacturacionDiaria(MailPlanInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailPlan, "i_operation", 'I');
                db.SetParameterValue(commandMailPlan, "i_option", 'B');

                db.SetParameterValue(commandMailPlan, "i_mpl_fechaapertura", item.FechaApertura);
                db.SetParameterValue(commandMailPlan, "i_mpl_fechacierre", item.FechaCierre);
                db.SetParameterValue(commandMailPlan, "i_MAILGROUP", item.MailGroup);
                db.SetParameterValue(commandMailPlan, "i_CAMPANA", item.Campana);
                db.SetParameterValue(commandMailPlan, "i_mpl_estado", item.Estado);
                db.SetParameterValue(commandMailPlan, "i_mpl_horacierre", item.HoraCierre);
                db.SetParameterValue(commandMailPlan, "i_catalogo", item.Catalogo);

                dr = db.ExecuteReader(commandMailPlan);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se inserto un mail plan Nuevo facturacion Diaria: Mailgroupo: " + item.MailGroup + ", Campaña: " + item.Campana + ", Catalogo " + item.Catalogo + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de un mailplan existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(MailPlanInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailPlan, "i_operation", 'U');
                db.SetParameterValue(commandMailPlan, "i_option", 'A');

                db.SetParameterValue(commandMailPlan, "i_mpl_id", item.Id);
                db.SetParameterValue(commandMailPlan, "i_mpl_fechaapertura", item.FechaApertura);
                db.SetParameterValue(commandMailPlan, "i_mpl_fechacierre", item.FechaCierre);
                db.SetParameterValue(commandMailPlan, "i_MAILGROUP", item.MailGroup);
                db.SetParameterValue(commandMailPlan, "i_CAMPANA", item.Campana);
                db.SetParameterValue(commandMailPlan, "i_mpl_estado", item.Estado);
                db.SetParameterValue(commandMailPlan, "i_mpl_horacierre", item.HoraCierre);
                db.SetParameterValue(commandMailPlan, "i_catalogo", item.Catalogo);


                dr = db.ExecuteReader(commandMailPlan);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se Actualizo  mail plan : Mailgroupo: " + item.MailGroup + ", Campaña: " + item.Campana + ", Catalogo " + item.Catalogo + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de un mailplan de facturacion diaria existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateFacturacionDiaria(MailPlanInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailPlan, "i_operation", 'U');
                db.SetParameterValue(commandMailPlan, "i_option", 'B');

                db.SetParameterValue(commandMailPlan, "i_mpl_id", item.Id);
                db.SetParameterValue(commandMailPlan, "i_mpl_fechaapertura", item.FechaApertura);
                db.SetParameterValue(commandMailPlan, "i_mpl_fechacierre", item.FechaCierre);
                db.SetParameterValue(commandMailPlan, "i_MAILGROUP", item.MailGroup);
                db.SetParameterValue(commandMailPlan, "i_CAMPANA", item.Campana);
                db.SetParameterValue(commandMailPlan, "i_mpl_estado", item.Estado);
                db.SetParameterValue(commandMailPlan, "i_mpl_horacierre", item.HoraCierre);
                db.SetParameterValue(commandMailPlan, "i_catalogo", item.Catalogo);


                dr = db.ExecuteReader(commandMailPlan);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se Actualizo  mail plan facturacion Diaria : Mailgroupo: " + item.MailGroup + ", Campaña: " + item.Campana + ", Catalogo " + item.Catalogo + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza Actualizacion para Cerrar o Abrir todos los Mailplan
        /// </summary>
        /// <param name="Option">1 tabla mailplan - 2 tabla  MAILPLAN_FACTURACION_D</param>
        /// <returns></returns>
        public bool UpdateCerrarTodos(int Option, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailPlan, "i_operation", 'U');

                if (Option == 1)
                {
                    db.SetParameterValue(commandMailPlan, "i_option", 'C');
                }
                else
                {
                    db.SetParameterValue(commandMailPlan, "i_option", 'D');
                }

                dr = db.ExecuteReader(commandMailPlan);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se actualiza el Estado de la tabla" + ((Option == 1)? "Mailplan" : "Mailplan Facturacion Diaria") + "  . Acción Realizada por el Usuario: " + Usuario;

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



        #endregion
    }
}