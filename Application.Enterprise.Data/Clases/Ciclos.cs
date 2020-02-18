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
    public class Ciclos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCiclos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Ciclos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Ciclos()
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
            commandCiclos = db.GetStoredProcCommand("PRC_SVDN_CICLOS");

            db.AddInParameter(commandCiclos, "i_operation", DbType.String);
            db.AddInParameter(commandCiclos, "i_option", DbType.String);
            db.AddInParameter(commandCiclos, "i_ciclo", DbType.String);
            db.AddInParameter(commandCiclos, "i_nombreciclo", DbType.String);
            db.AddInParameter(commandCiclos, "i_estado", DbType.Int32 );
            db.AddOutParameter(commandCiclos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCiclos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Ciclos

        /// <summary>
        /// lista todos los ciclos existentes.
        /// </summary>
        /// <returns></returns>
        public List<CiclosInfo> List()
        {
            db.SetParameterValue(commandCiclos, "i_operation", 'S');
            db.SetParameterValue(commandCiclos, "i_option", 'A');

            List<CiclosInfo> col = new List<CiclosInfo>();

            IDataReader dr = null;

            CiclosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiclos);

                while (dr.Read())
                {
                    m = Factory.GetCiclos(dr);

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


        /// <summary>
        /// Retorna un objeto de Ciclos 
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public CiclosInfo CiclosXCiclo(string Codciclo)
        {
            db.SetParameterValue(commandCiclos, "i_operation", 'S');
            db.SetParameterValue(commandCiclos, "i_option", 'B');
            db.SetParameterValue(commandCiclos, "i_ciclo", Codciclo );

            IDataReader dr = null;

            CiclosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiclos);

                while (dr.Read())
                {
                    m = Factory.GetCiclos(dr);

                }
                if (m == null)
                {
                    m = new CiclosInfo();
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

        public bool InsertCiclos(CiclosInfo item, string Usuario)
        {
            bool oktrans = false;
            

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiclos, "i_operation", 'I');
                db.SetParameterValue(commandCiclos, "i_option", 'A');


                db.SetParameterValue(commandCiclos, "i_ciclo", item.Ciclo );
                db.SetParameterValue(commandCiclos, "i_nombreciclo", item.NombreCiclo);
                db.SetParameterValue(commandCiclos, "i_estado", item.estado);
                

                dr = db.ExecuteReader(commandCiclos);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación de un Ciclo de Vida:Codigo Ciclo: " + item.Ciclo + " Nombre Ciclo : " + item.NombreCiclo  + ". Acción Realizada por el Usuario: " + Usuario;

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

        public bool UpdateCiclos(CiclosInfo item, string Usuario)
        {
            bool oktrans = false;


            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiclos, "i_operation", 'U');
                db.SetParameterValue(commandCiclos, "i_option", 'A');


                db.SetParameterValue(commandCiclos, "i_ciclo", item.Ciclo);
                db.SetParameterValue(commandCiclos, "i_nombreciclo", item.NombreCiclo);
                db.SetParameterValue(commandCiclos, "i_estado", item.estado);


                dr = db.ExecuteReader(commandCiclos);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se Actualizó un Ciclo de Vida:Codigo Ciclo: " + item.Ciclo + " Nombre Ciclo : " + item.NombreCiclo + ". Acción Realizada por el Usuario: " + Usuario;

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

        public bool DeleteCiclos(string ciclo, string Usuario)
        {
            bool oktrans = false;


            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiclos, "i_operation", 'D');
                db.SetParameterValue(commandCiclos, "i_option", 'A');
                db.SetParameterValue(commandCiclos, "i_ciclo", ciclo);


                dr = db.ExecuteReader(commandCiclos);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se Eliminó un Ciclo de Vida:Codigo Ciclo: " + ciclo + ". Acción Realizada por el Usuario: " + Usuario;

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

    }
}