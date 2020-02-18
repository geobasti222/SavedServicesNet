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
    public class BloqueaDesmanteladoras
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandDesmanteladoras;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public BloqueaDesmanteladoras(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public BloqueaDesmanteladoras()
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
            commandDesmanteladoras = db.GetStoredProcCommand("PRC_SVDN_BLOQUEODESMANTELADORA");

            db.AddInParameter(commandDesmanteladoras, "i_operation", DbType.String);
            db.AddInParameter(commandDesmanteladoras, "i_option", DbType.String);

            db.AddParameter(commandDesmanteladoras, "i_resultado", DbType.Int32, 0, ParameterDirection.InputOutput, false, 32, 32,string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandDesmanteladoras, "i_fecha", DbType.String);

            db.AddOutParameter(commandDesmanteladoras, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandDesmanteladoras, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Bloqueo

        /// <summary>
        /// Bloquea Desmanteladora
        /// </summary>
        /// <returns></returns>
        public int  BloquearDesmanteladoras(string Usuario)
        {
            int Resultado = 0;
           
             
            db.SetParameterValue(commandDesmanteladoras, "i_operation", 'S');
            db.SetParameterValue(commandDesmanteladoras, "i_option", 'A');

            db.SetParameterValue(commandDesmanteladoras, "i_resultado", 0); //Se debe inicializar la variable con 0.

            IDataReader dr = null;

            try
            {
                
                dr = db.ExecuteReader(commandDesmanteladoras);
                Resultado = System.Convert.ToInt32(db.GetParameterValue(commandDesmanteladoras, "i_resultado"));

                if (Resultado != 0)
                {
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //Guardar auditoria 
                    try
                    {
                        Auditoria objAuditoria = new Auditoria("conexion");
                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                        objAuditoriaInfo.Usuario = Usuario;
                        objAuditoriaInfo.Proceso = "Se insertaron registros  de los clientes desmanteladoras. Acción Realizada por el Usuario: " + Usuario;

                        objAuditoria.Insert(objAuditoriaInfo);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    }
                    //-----------------------------------------------------------------------------------------------------------------------------

                    
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

            return Resultado;
        }



        /// <summary>
        /// Lista Las clientes Desmanteladas
        /// </summary>
        /// <returns></returns>
        public List<DesmanteladasInfo> ListDesmanteladas()
        {
            db.SetParameterValue(commandDesmanteladoras, "i_operation", 'S');
            db.SetParameterValue(commandDesmanteladoras, "i_option", 'B');

            

            List<DesmanteladasInfo> col = new List<DesmanteladasInfo>();

            IDataReader dr = null;

            DesmanteladasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDesmanteladoras);

                while (dr.Read())
                {
                    m = Factory.GetDesmantelados(dr);

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
        /// Lista Las clientes Desmanteladas
        /// </summary>
        /// <returns></returns>
        public List<DesmanteladasInfo> ListDesmanteladasXFecha(string Fecha)
        {
            db.SetParameterValue(commandDesmanteladoras, "i_operation", 'S');
            db.SetParameterValue(commandDesmanteladoras, "i_option", 'C');
            db.SetParameterValue(commandDesmanteladoras, "i_fecha", Fecha); 

            List<DesmanteladasInfo> col = new List<DesmanteladasInfo>();

            IDataReader dr = null;

            DesmanteladasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDesmanteladoras);

                while (dr.Read())
                {
                    m = Factory.GetDesmantelados(dr);

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
    }
}