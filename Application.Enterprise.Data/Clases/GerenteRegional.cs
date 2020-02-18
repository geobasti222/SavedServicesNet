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
    /// Clase DAO JA
    /// </summary>
    public class GerenteRegional
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandGerenteRegional;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public GerenteRegional(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public GerenteRegional()
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
            commandGerenteRegional = db.GetStoredProcCommand("PRC_SVDN_GERENTEREGIONAL");

            db.AddInParameter(commandGerenteRegional, "i_operation", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_option", DbType.String);

            db.AddInParameter(commandGerenteRegional, "i_codgereg", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_nombreuno", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_nombredos", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_apellidouno", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_apellidodos", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_direccion", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_mail", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_telefonouno", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_telefonodos", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_telefonotres", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_ciudad", DbType.String);
            db.AddInParameter(commandGerenteRegional, "i_Cod_Rango", DbType.String);

            db.AddOutParameter(commandGerenteRegional, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandGerenteRegional, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de GerenteRegional

        /// <summary>
        /// lista todos los GerenteRegional existentes.
        /// </summary>
        /// <returns></returns>
        public List<GerenteRegionalInfo> List()
        {
            db.SetParameterValue(commandGerenteRegional, "i_operation", 'S');
            db.SetParameterValue(commandGerenteRegional, "i_option", 'A');

            List<GerenteRegionalInfo> col = new List<GerenteRegionalInfo>();

            IDataReader dr = null;

            GerenteRegionalInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGerenteRegional);

                while (dr.Read())
                {
                    m = Factory.GetGerenteRegional(dr);

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
        /// Lista el GerenteRegional especifico
        /// </summary>
        /// <returns></returns>
        public GerenteRegionalInfo ListxGerente(string Gerente)
        {
            db.SetParameterValue(commandGerenteRegional, "i_operation", 'S');
            db.SetParameterValue(commandGerenteRegional, "i_option", 'B');
            db.SetParameterValue(commandGerenteRegional, "i_codgereg", Gerente);
          
            IDataReader dr = null;
            GerenteRegionalInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGerenteRegional);

                while (dr.Read())
                {
                    m = Factory.GetGerenteRegional(dr);                   
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
        /// Guarda un GerenteRegional nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(GerenteRegionalInfo item)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandGerenteRegional, "i_operation", 'I');
                db.SetParameterValue(commandGerenteRegional, "i_option", 'A');

                db.SetParameterValue(commandGerenteRegional, "i_codgereg", item.CodGeReg);

                db.SetParameterValue(commandGerenteRegional, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandGerenteRegional, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandGerenteRegional, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandGerenteRegional, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandGerenteRegional, "i_direccion", item.Direccion);
                db.SetParameterValue(commandGerenteRegional, "i_mail", item.Email);
                db.SetParameterValue(commandGerenteRegional, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandGerenteRegional, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandGerenteRegional, "i_telefonotres", item.TelefonoTres);
                db.SetParameterValue(commandGerenteRegional, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandGerenteRegional, "i_Cod_Rango", item.Cod_Rango);

                dr = db.ExecuteReader(commandGerenteRegional);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de un Gerente regional.  codigo:" + item.CodGeReg + ",  nombre:" + item.NombreUno + " "+item.NombreDos+" "+item.ApellidoUno+" "+item.ApellidoDos+". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de un GerenteRegional existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(GerenteRegionalInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandGerenteRegional, "i_operation", 'U');
                db.SetParameterValue(commandGerenteRegional, "i_option", 'A');

                db.SetParameterValue(commandGerenteRegional, "i_codgereg", item.CodGeReg);

                db.SetParameterValue(commandGerenteRegional, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandGerenteRegional, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandGerenteRegional, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandGerenteRegional, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandGerenteRegional, "i_direccion", item.Direccion);
                db.SetParameterValue(commandGerenteRegional, "i_mail", item.Email);
                db.SetParameterValue(commandGerenteRegional, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandGerenteRegional, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandGerenteRegional, "i_telefonotres", item.TelefonoTres);
                db.SetParameterValue(commandGerenteRegional, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandGerenteRegional, "i_Cod_Rango", item.Cod_Rango);

                dr = db.ExecuteReader(commandGerenteRegional);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se actualizo un Gerente regional.  codigo:" + item.CodGeReg + ",  nombre:" + item.NombreUno + " " + item.NombreDos + " " + item.ApellidoUno + " " + item.ApellidoDos + ". Acción Realizada por el Usuario: " + item.Usuario;

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
       
        #endregion


        
    }
}