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
    /// <summary>
    /// 
    /// </summary>
    public class RegionxZona
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandRegionxZona;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public RegionxZona(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public RegionxZona()
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
            commandRegionxZona = db.GetStoredProcCommand("PRC_SVDN_REGIONXZONA");

            db.AddInParameter(commandRegionxZona, "i_operation", DbType.String);
            db.AddInParameter(commandRegionxZona, "i_option", DbType.String);

            db.AddInParameter(commandRegionxZona, "i_reg_codregional", DbType.Int32);
            db.AddInParameter(commandRegionxZona, "i_zona", DbType.String);
            db.AddInParameter(commandRegionxZona, "i_codgereg", DbType.String);

            db.AddOutParameter(commandRegionxZona, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandRegionxZona, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Region x Zona

        /// <summary>
        /// Lista todos las zonas y regiones existentes.
        /// </summary>
        /// <returns></returns>
        public List<RegionxZonaInfo> List()
        {
            db.SetParameterValue(commandRegionxZona, "i_operation", 'S');
            db.SetParameterValue(commandRegionxZona, "i_option", 'A');

            List<RegionxZonaInfo> col = new List<RegionxZonaInfo>();

            IDataReader dr = null;

            RegionxZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionxZona);

                while (dr.Read())
                {
                    m = Factory.GetRegionxZona(dr);

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
        /// Lista todas las zonas de una region especifica.
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<RegionxZonaInfo> ListxRegional(int CodigoRegional)
        {
            db.SetParameterValue(commandRegionxZona, "i_operation", 'S');
            db.SetParameterValue(commandRegionxZona, "i_option", 'B');
            db.SetParameterValue(commandRegionxZona, "i_reg_codregional", CodigoRegional);

            List<RegionxZonaInfo> col = new List<RegionxZonaInfo>();

            IDataReader dr = null;

            RegionxZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionxZona);

                while (dr.Read())
                {
                    m = Factory.GetRegionxZona(dr);

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
        /// Lista la region de una zona especifica.
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        public RegionxZonaInfo ListRegionalxZona(string CodigoZona)
        {
            db.SetParameterValue(commandRegionxZona, "i_operation", 'S');
            db.SetParameterValue(commandRegionxZona, "i_option", 'C');
            db.SetParameterValue(commandRegionxZona, "i_zona", CodigoZona);
            
            IDataReader dr = null;

            RegionxZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionxZona);

                while (dr.Read())
                {
                    m = Factory.GetRegionesxZona(dr);                   
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
        /// Lista la region de una zona especifica (MISMO METODO QUE EL ANTERIOR PERO CON EL FACTORY COMPLETO)
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        public RegionxZonaInfo ListRegionalxZonaFactoryCompleto(string CodigoZona)
        {
            db.SetParameterValue(commandRegionxZona, "i_operation", 'S');
            db.SetParameterValue(commandRegionxZona, "i_option", 'C');
            db.SetParameterValue(commandRegionxZona, "i_zona", CodigoZona);

            IDataReader dr = null;

            RegionxZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionxZona);

                while (dr.Read())
                {
                    m = Factory.GetRegionxZona(dr);
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
        /// Lista todas las zonas de una regional especifica.
        /// </summary>
        /// <param name="IdRegional"></param>
        /// <returns></returns>
        public List<RegionxZonaInfo> ListxIdRegional(string IdRegional)
        {
            db.SetParameterValue(commandRegionxZona, "i_operation", 'S');
            db.SetParameterValue(commandRegionxZona, "i_option", 'D');
            db.SetParameterValue(commandRegionxZona, "i_codgereg", IdRegional);

            List<RegionxZonaInfo> col = new List<RegionxZonaInfo>();

            IDataReader dr = null;

            RegionxZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionxZona);

                while (dr.Read())
                {
                    m = Factory.GetRegionxZona(dr);

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
        /// Inserta Regiones por Zona ya que solo puede haber una zona por region.
        /// </summary>
        /// <param name="codzon"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool InsertaRegionXzona(RegionxZonaInfo item,  string usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandRegionxZona, "i_operation", 'I');
                db.SetParameterValue(commandRegionxZona, "i_option", 'A');

                db.SetParameterValue(commandRegionxZona, "i_reg_codregional", item.CodigoRegion );
                db.SetParameterValue(commandRegionxZona, "i_zona", item.Zona);
                db.SetParameterValue(commandRegionxZona, "i_codgereg", item.IdRegional);


                dr = db.ExecuteReader(commandRegionxZona);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se insertó un registro de la Tabla RegionxZona: Codregional:" + item.CodigoRegion + ", Zona: " + item.Zona + ", Codgereg: " + item.IdRegional  + ". Acción Realizada por el Usuario: " + usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

                okTrans = true;


            }
            catch (SqlException ex)
            {
                okTrans = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));


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
        /// Elimina Regiones por Zona ya que solo puede haber una zona por region.
        /// </summary>
        /// <param name="codzon"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ElminarRegionXzona(string codzon, string usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandRegionxZona, "i_operation", 'D');
                db.SetParameterValue(commandRegionxZona, "i_option", 'A');

                
                db.SetParameterValue(commandRegionxZona, "i_zona", codzon);
                

                dr = db.ExecuteReader(commandRegionxZona);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se elimino un registro de la Tabla RegionxZona: Zona " + codzon  + ". Acción Realizada por el Usuario: " + usuario;

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

        #endregion
    }
}