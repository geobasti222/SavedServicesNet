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
    public class ArticuloExeceptoIva
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandArticulos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ArticuloExeceptoIva(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ArticuloExeceptoIva()
        {
            string dataBase = "conexion"; 

            db = DatabaseFactory.CreateDatabase(dataBase); 
            Config();
        }

        /// <summary>
        ///  Metodo para configurar el comando de la DatabaseFactory
        /// </summary>
        private void Config()
        {
            commandArticulos = db.GetStoredProcCommand("PRC_SVDN_ARTEXENTOSXCIUDAD_TEMP");

            db.AddInParameter(commandArticulos, "i_operation", DbType.String);
            db.AddInParameter(commandArticulos, "i_option", DbType.String);

            db.AddInParameter(commandArticulos, "i_codciudad", DbType.String);
            db.AddInParameter(commandArticulos, "i_plu", DbType.Int32);
            db.AddInParameter(commandArticulos, "i_referencia", DbType.String);
            db.AddInParameter(commandArticulos, "i_estado", DbType.Boolean );

            db.AddInParameter(commandArticulos, "i_optcampo", DbType.String);



            db.AddOutParameter(commandArticulos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandArticulos, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Articulos Execeptos de Iva

        /// <summary>
        /// lista toda la vista previa de losArticulos Execeptos de Iva.
        /// </summary>
        /// <returns></returns>
        public List<ArticuloExeceptoIvaInfo> List()
        {
            db.SetParameterValue(commandArticulos, "i_operation", 'S');
            db.SetParameterValue(commandArticulos, "i_option", 'A');

            List<ArticuloExeceptoIvaInfo> col = new List<ArticuloExeceptoIvaInfo>();

            IDataReader dr = null;

            ArticuloExeceptoIvaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandArticulos);

                while (dr.Read())
                {
                    m = Factory.GetArticuloExeceptosIva(dr);

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
        /// lista toda la vista previa de los presupuestos de la matriz.
        /// </summary>
        /// <returns></returns>
        public List<ArticuloExeceptoIvaInfo> ListXCiudad(ArticuloExeceptoIvaInfo item)
        {
            db.SetParameterValue(commandArticulos, "i_operation", 'S');
            db.SetParameterValue(commandArticulos, "i_option", 'B');
            db.SetParameterValue(commandArticulos, "i_codciudad", item.Codciudad);
            db.SetParameterValue(commandArticulos, "i_plu", item.PLU);

            List<ArticuloExeceptoIvaInfo> col = new List<ArticuloExeceptoIvaInfo>();

            IDataReader dr = null;

            ArticuloExeceptoIvaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandArticulos);

                while (dr.Read())
                {
                    m = Factory.GetArticuloExeceptosIva(dr);

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
        /// Lista los datos que se van a actualizar en la tabla principal de la Temporal
        /// </summary>
        /// <returns></returns>
        public List<ArticuloExeceptoIvaInfo> ListTemp()
        {
            db.SetParameterValue(commandArticulos, "i_operation", 'S');
            db.SetParameterValue(commandArticulos, "i_option", 'C');

            List<ArticuloExeceptoIvaInfo> col = new List<ArticuloExeceptoIvaInfo>();

            IDataReader dr = null;

            ArticuloExeceptoIvaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandArticulos);

                while (dr.Read())
                {
                    m = Factory.GetArticuloExeceptosIva(dr);

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
        /// Insertar valores Exepcion de articulos con iva.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertaTablasTemporales(ArticuloExeceptoIvaInfo item, string Tipocampo)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {

                db.SetParameterValue(commandArticulos, "i_operation", 'I');
                db.SetParameterValue(commandArticulos, "i_option", 'A');

                db.SetParameterValue(commandArticulos, "i_codciudad", item.Codciudad );
                db.SetParameterValue(commandArticulos, "i_plu", item.PLU );
                db.SetParameterValue(commandArticulos, "i_referencia", item.Referencia );
                db.SetParameterValue(commandArticulos, "i_estado", item.Estado);
                

                db.SetParameterValue(commandArticulos, "i_optcampo", Tipocampo);

                dr = db.ExecuteReader(commandArticulos);



                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro Tabla Temporal en las tablas Temporales De Execepto de iva: Codciudad" + item.Codciudad  + ",PLU" + item.PLU + ",Referencia " + item.Referencia + ",Estado " + item.Estado   + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Insertar valores para los Valores de Execeptos de iva a la tabla temporal.
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertTablaTemporalPrincipal(string Usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandArticulos, "i_operation", 'I');
                db.SetParameterValue(commandArticulos, "i_option", 'B');



                dr = db.ExecuteReader(commandArticulos);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro  en la  Tabla Temporal SVDN_ARTEXENTOSXCIUDAD_TEMP  de las tablas Temporales. Acción Realizada por el Usuario: " + Usuario;

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
        /// 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertRegistroTemporalPrincipal(ArticuloExeceptoIvaInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandArticulos, "i_operation", 'I');
                db.SetParameterValue(commandArticulos, "i_option", 'C');

                db.SetParameterValue(commandArticulos, "i_codciudad", item.Codciudad);
                db.SetParameterValue(commandArticulos, "i_plu", item.PLU);
                db.SetParameterValue(commandArticulos, "i_referencia", item.Referencia);
                db.SetParameterValue(commandArticulos, "i_estado", item.Estado);

                dr = db.ExecuteReader(commandArticulos);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro Tabla Temporal en la tabla principal SVDN_ARTEXENTOSXCIUDAD: Codciudad" + item.Codciudad + ",PLU" + item.PLU + ",Referencia " + item.Referencia + ",Estado " + item.Estado + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Elimina todos los elementos de la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public bool DeleteTempArticulosExeptos ()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandArticulos, "i_operation", 'D');
                db.SetParameterValue(commandArticulos, "i_option", 'A');


                dr = db.ExecuteReader(commandArticulos);


               


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
        /// Elimina todos los elementos de la tabla temporaral.
        /// </summary>
        /// <returns></returns>
        public bool DeleteTempArticulosExeptosXCiudad(string TipoCampo)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandArticulos, "i_operation", 'D');
                db.SetParameterValue(commandArticulos, "i_option", 'B');
                db.SetParameterValue(commandArticulos, "i_optcampo", TipoCampo);


                dr = db.ExecuteReader(commandArticulos);

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


        public bool DeleteTempArticulosExeptosXRegistro(string codciudad, int PLU, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandArticulos, "i_operation", 'D');
                db.SetParameterValue(commandArticulos, "i_option", 'C');
                db.SetParameterValue(commandArticulos, "i_codciudad", codciudad);
                db.SetParameterValue(commandArticulos, "i_plu", PLU);


                dr = db.ExecuteReader(commandArticulos);


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se Eliminó  registro Tabla principal SVDN_ARTEXENTOSXCIUDAD: Codciudad" + codciudad + ",PLU" + PLU + ". Acción Realizada por el Usuario: " + Usuario;

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


        public bool ActualizaArticulosExceptos(ArticuloExeceptoIvaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandArticulos, "i_operation", 'U');
                db.SetParameterValue(commandArticulos, "i_option", 'A');
                db.SetParameterValue(commandArticulos, "i_codciudad", item.Codciudad);
                db.SetParameterValue(commandArticulos, "i_plu", item.PLU);
                db.SetParameterValue(commandArticulos, "i_referencia", item.Referencia);
                db.SetParameterValue(commandArticulos, "i_estado", item.Estado);


                dr = db.ExecuteReader(commandArticulos);


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion o ingreso  de los articulos Exceptos de iva por ciudad. Acción Realizada por el Usuario: " + item.Usuario;

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