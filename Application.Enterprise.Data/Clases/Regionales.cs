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
    public class Regionales
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandRegionales;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Regionales(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Regionales()
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
            commandRegionales = db.GetStoredProcCommand("PRC_SVDN_REGIONALES");

            db.AddInParameter(commandRegionales, "i_operation", DbType.String);
            db.AddInParameter(commandRegionales, "i_option", DbType.String);
            db.AddInParameter(commandRegionales, "i_reg_codregional", DbType.Int32);
            db.AddInParameter(commandRegionales, "i_reg_nombre", DbType.String);
            db.AddInParameter(commandRegionales, "i_codgereg", DbType.String);
            
            db.AddInParameter(commandRegionales, "i_zona", DbType.String);
            //--comentar para que funcione peru y ecuador
            //db.AddInParameter(commandRegionales, "i_codgereg2", DbType.String);

            db.AddOutParameter(commandRegionales, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandRegionales, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Regionales

        /// <summary>
        /// Lista todos las regiones existentes.
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> List()
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'A');

            List<RegionalesInfo> col = new List<RegionalesInfo>();

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);

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
        /// Consulta una regional por id
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public RegionalesInfo ListxId(int CodigoRegional)
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'B');
            db.SetParameterValue(commandRegionales, "i_reg_codregional", CodigoRegional);

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);
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
        /// Lista una regional por zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public RegionalesInfo ListxZona(string Zona)
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'C');
            db.SetParameterValue(commandRegionales, "i_zona", Zona);

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);
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
        /// -Lista una regional por cedula de regional
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <returns></returns>
        public RegionalesInfo ListxCedulaRegional(string CedulaRegional)
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'D');
            db.SetParameterValue(commandRegionales, "i_codgereg", CedulaRegional);

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);
                }

                if (m == null)
                {
                    m = new RegionalesInfo();
                    m.IdRegional = "";

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
        /// Lista las regiones que comprenden al pais
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> ListRegionesPais()
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'E');

            List<RegionalesInfo> col = new List<RegionalesInfo>();

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);

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
        /// Se obtiene la regiones por codigo
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public RegionalesInfo ListxCedulaRegional(int CodigoRegional)
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'F');
            db.SetParameterValue(commandRegionales, "i_reg_codregional", CodigoRegional);

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);
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
        /// Lista una regional Y nombre de gerente
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> ListXGerente()
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'G');

            List<RegionalesInfo> col = new List<RegionalesInfo>();

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);

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
        /// Lista un los gerentesregionales
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> ListGerentesRegionales()
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'J');

            List<RegionalesInfo> col = new List<RegionalesInfo>();

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionalesGerente(dr);

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


        public bool InsertRegionales(RegionalesInfo item, string Usuario)
        {
            bool oktrans = false;
            

            

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandRegionales, "i_operation", 'I');
                db.SetParameterValue(commandRegionales, "i_option", 'A');


                db.SetParameterValue(commandRegionales, "i_reg_codregional", item.CodigoRegional );
                db.SetParameterValue(commandRegionales, "i_reg_nombre", item.Nombre );
                db.SetParameterValue(commandRegionales, "i_codgereg", item.IdRegional );
                dr = db.ExecuteReader(commandRegionales);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación de Regional:Codigo Regional: " + item.CodigoRegional + " Nombre Regional : " + item.Nombre + " Codigo Gerente : " + item.IdRegional  + ". Acción Realizada por el Usuario: " + Usuario;

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


        public bool DeleteRegionales(string CodigoRegional, string Usuario)
        {
            bool oktrans = false;




            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandRegionales, "i_operation", 'D');
                db.SetParameterValue(commandRegionales, "i_option", 'A');


                db.SetParameterValue(commandRegionales, "i_reg_codregional", CodigoRegional);
                
                dr = db.ExecuteReader(commandRegionales);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de Regional:Codigo Regional: " + CodigoRegional + ". Acción Realizada por el Usuario: " + Usuario;

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

        public List<RegionalesInfo> ListGerentes()
        {
            db.SetParameterValue(commandRegionales, "i_operation", 'S');
            db.SetParameterValue(commandRegionales, "i_option", 'J');

            List<RegionalesInfo> col = new List<RegionalesInfo>();

            IDataReader dr = null;

            RegionalesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandRegionales);

                while (dr.Read())
                {
                    m = Factory.GetRegionales(dr);

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
        /// Realiza la actualizacion de una divisional existente. // actualizando regionales,regionxzona y zona
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(RegionalesInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                ///
                db.SetParameterValue(commandRegionales, "i_operation", 'U');
                db.SetParameterValue(commandRegionales, "i_option", 'A');
                db.SetParameterValue(commandRegionales, "i_reg_codregional", item.CodigoRegional);

                db.SetParameterValue(commandRegionales, "i_reg_nombre", item.Nombre);
                db.SetParameterValue(commandRegionales, "i_codgereg", item.IdRegional);
                db.SetParameterValue(commandRegionales, "i_codgereg2", item.Codgereg);
                

                dr = db.ExecuteReader(commandRegionales);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la actualización de una regional.  codigo regional:" + item.CodigoRegional + ",  nombre:" + item.Nombre + ",   codigo gerente regional: " + item.IdRegional + ". Acción Realizada por el Usuario: " + item.Usuario;

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