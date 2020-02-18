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
    /// JA
    /// </summary>
    public class TrasladoPresupuestoMatriz
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPresupuesto;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TrasladoPresupuestoMatriz(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public TrasladoPresupuestoMatriz()
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
            commandPresupuesto = db.GetStoredProcCommand("PRC_SVDN_PRESUPUESTO_MATRIZ_TEMP");

            db.AddInParameter(commandPresupuesto, "i_operation", DbType.String);
            db.AddInParameter(commandPresupuesto, "i_option", DbType.String);

            db.AddInParameter(commandPresupuesto, "i_campana", DbType.String);
            db.AddInParameter(commandPresupuesto, "i_zona", DbType.String);          
            db.AddInParameter(commandPresupuesto, "i_Npedidos", DbType.Int32);           
            db.AddInParameter(commandPresupuesto, "i_Vlr_Presupuesto", DbType.Decimal);
            db.AddInParameter(commandPresupuesto, "i_Vlr_Presupuesto_Nivi", DbType.Decimal);
            db.AddInParameter(commandPresupuesto, "i_Vlr_Presupuesto_Pisame", DbType.Decimal);
            db.AddInParameter(commandPresupuesto, "i_Vlr_Presupuesto_Outlet", DbType.Decimal);

            db.AddInParameter(commandPresupuesto, "i_optcampo", DbType.String);

            	
	
            db.AddOutParameter(commandPresupuesto, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPresupuesto, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Traslado Presupuesto Matriz

        /// <summary>
        /// lista toda la vista previa de los presupuestos de la matriz.
        /// </summary>
        /// <returns></returns>
        public List<TrasladoPresupuestoMatrizInfo> List()
        {
            db.SetParameterValue(commandPresupuesto, "i_operation", 'S');
            db.SetParameterValue(commandPresupuesto, "i_option", 'A');

            List<TrasladoPresupuestoMatrizInfo> col = new List<TrasladoPresupuestoMatrizInfo>();

            IDataReader dr = null;

            TrasladoPresupuestoMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPresupuesto);

                while (dr.Read())
                {
                    m = Factory.GetTrasladosPrespuestoMatriz(dr);

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
        public List<TrasladoPresupuestoMatrizInfo> ListTemp()
        {
            db.SetParameterValue(commandPresupuesto, "i_operation", 'S');
            db.SetParameterValue(commandPresupuesto, "i_option", 'C');

            List<TrasladoPresupuestoMatrizInfo> col = new List<TrasladoPresupuestoMatrizInfo>();

            IDataReader dr = null;

            TrasladoPresupuestoMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPresupuesto);

                while (dr.Read())
                {
                    m = Factory.GetTrasladosPrespuestoMatriz(dr);

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
        public List<TrasladoPresupuestoMatrizInfo> ListXCampanaYZona(TrasladoPresupuestoMatrizInfo item)
        {
            db.SetParameterValue(commandPresupuesto, "i_operation", 'S');
            db.SetParameterValue(commandPresupuesto, "i_option", 'B');
            db.SetParameterValue(commandPresupuesto, "i_campana", item.Campana);
            db.SetParameterValue(commandPresupuesto, "i_zona", item.Zona);

            List<TrasladoPresupuestoMatrizInfo> col = new List<TrasladoPresupuestoMatrizInfo>();

            IDataReader dr = null;

            TrasladoPresupuestoMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPresupuesto);

                while (dr.Read())
                {
                    m = Factory.GetTrasladosPrespuestoMatriz(dr);

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
        /// Guarda los valores en cada tabla  temporal.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertaTablasTemporales(TrasladoPresupuestoMatrizInfo item, string Tipocampo)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPresupuesto, "i_operation", 'I');
                db.SetParameterValue(commandPresupuesto, "i_option", 'A');

                db.SetParameterValue(commandPresupuesto, "i_campana", item.Campana );
                db.SetParameterValue(commandPresupuesto, "i_zona", item.Zona );         
                db.SetParameterValue(commandPresupuesto, "i_Npedidos", item.NPedidos );
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto", item.Vlr_Presupuesto);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Nivi", item.Vlr_Presupuesto_Nivi);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Pisame", item.Vlr_Presupuesto_Pisame);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Outle", item.Vlr_Presupuesto_Outlet);
               

                db.SetParameterValue(commandPresupuesto, "i_optcampo", Tipocampo);

                dr = db.ExecuteReader(commandPresupuesto);

                


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro Tabla Temporal en las tablas Temporales De presupuesto Matriz: Campaña " + item.Campana + ",Zona " + item.Zona + ",Empresari " + item.Empresarias + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Insertar valores para los presupuestos de la matriz a la tabla temporal.
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertTablaTemporalPrincipal(string Usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPresupuesto, "i_operation", 'I');
                db.SetParameterValue(commandPresupuesto, "i_option", 'B');



                dr = db.ExecuteReader(commandPresupuesto);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro  en la  Tabla Temporal SVDN_PRESUPUESTO_MATRIZ_TEMP  de las tablas Temporales Matriz. Acción Realizada por el Usuario: " + Usuario;

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
        public bool InsertRegistroTemporalPrincipal(TrasladoPresupuestoMatrizInfo  item )
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPresupuesto, "i_operation", 'I');
                db.SetParameterValue(commandPresupuesto, "i_option", 'C');

                db.SetParameterValue(commandPresupuesto, "i_campana", item.Campana);
                db.SetParameterValue(commandPresupuesto, "i_zona", item.Zona);
                db.SetParameterValue(commandPresupuesto, "i_Npedidos", item.NPedidos);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto", item.Vlr_Presupuesto);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Nivi", item.Vlr_Presupuesto_Nivi);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Pisame", item.Vlr_Presupuesto_Pisame);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Outle", item.Vlr_Presupuesto_Outlet);

                dr = db.ExecuteReader(commandPresupuesto);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro en la tabla principal de  presupuesto Matriz: Campaña " + item.Campana + ",Zona " + item.Zona + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Inserta registros en tabla matriz presupuesto
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertRegistro(TrasladoPresupuestoMatrizInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPresupuesto, "i_operation", 'I');
                db.SetParameterValue(commandPresupuesto, "i_option", 'C');

                db.SetParameterValue(commandPresupuesto, "i_campana", item.Campana);
                db.SetParameterValue(commandPresupuesto, "i_zona", item.Zona);
                db.SetParameterValue(commandPresupuesto, "i_Npedidos", item.NPedidos);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto", item.Vlr_Presupuesto);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Nivi", item.Vlr_Presupuesto_Nivi);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Pisame", item.Vlr_Presupuesto_Pisame);
                db.SetParameterValue(commandPresupuesto, "i_Vlr_Presupuesto_Outlet", item.Vlr_Presupuesto_Outlet);

                dr = db.ExecuteReader(commandPresupuesto);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro en la tabla principal de  presupuesto Matriz: Campaña " + item.Campana + ",Zona " + item.Zona + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Elimina todos los elemnetos de la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public bool DeleteTempTransferPresupuesto()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPresupuesto, "i_operation", 'D');
                db.SetParameterValue(commandPresupuesto, "i_option", 'A');


                dr = db.ExecuteReader(commandPresupuesto);


               


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
        public bool DeleteTransferPresupuesto(string TipoCampo)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPresupuesto, "i_operation", 'D');
                db.SetParameterValue(commandPresupuesto, "i_option", 'B');
                db.SetParameterValue(commandPresupuesto, "i_optcampo", TipoCampo);


                dr = db.ExecuteReader(commandPresupuesto);

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
        /// Elimina Registro de la Tablar Original de Presupuesto
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="zona"></param>
        /// <param name="opt">Opcion  del Store</param>
        /// <returns></returns>
        public bool DeletePresupuesto(string Campana, string zona, string usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                    db.SetParameterValue(commandPresupuesto, "i_operation", 'D');
                    db.SetParameterValue(commandPresupuesto, "i_option", 'C');
                    db.SetParameterValue(commandPresupuesto, "i_campana", Campana);
                    db.SetParameterValue(commandPresupuesto, "i_zona", zona);
                
              


                dr = db.ExecuteReader(commandPresupuesto);


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se Eliminó un registro  de la tabla  SVDN_PRESUPUESTO_MATRIZ. Campaña " + Campana + ", Zona: " + zona + ". Acción Realizada por el Usuario: " + usuario;
                    

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
        /// Actualiza los valores de la tabla Presupuesto Matriz con la temporal de Matriz
        /// </summary>
        /// <returns></returns>
        public bool ActualizaTransferPresupuesto(string Usuario, TrasladoPresupuestoMatrizInfo  item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPresupuesto, "i_operation", 'U');
                db.SetParameterValue(commandPresupuesto, "i_option", 'A');
            
                db.SetParameterValue(commandPresupuesto, "i_campana", item.Campana);
                db.SetParameterValue(commandPresupuesto, "i_zona", item.Zona);

                db.SetParameterValue(commandPresupuesto, "i_activo", item.Activo);
                db.SetParameterValue(commandPresupuesto, "i_empresariaspedido", item.Empresarias);
                db.SetParameterValue(commandPresupuesto, "i_nuevas", item.Nuevas);
                db.SetParameterValue(commandPresupuesto, "i_posibles_egresos", item.PEgresos);
                db.SetParameterValue(commandPresupuesto, "i_retenidas", item.Retenidas);
                db.SetParameterValue(commandPresupuesto, "i_egresos", item.Egresos);
                db.SetParameterValue(commandPresupuesto, "i_inactivas", item.Inactivas);
                db.SetParameterValue(commandPresupuesto, "i_reingresos", item.Reingresos);
                db.SetParameterValue(commandPresupuesto, "i_facturacion", item.Facturacion);


                dr = db.ExecuteReader(commandPresupuesto);


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion de los Presupuesto de la matriz de la tabla SVDN_PRESUPUESTO_MATRIZ. Acción Realizada por el Usuario: " + Usuario;

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
        /// lista el presupuesto matriz usando distinct en campana
        /// </summary>
        /// <returns></returns>
        public List<TrasladoPresupuestoMatrizInfo> ListCampana()
        {
            db.SetParameterValue(commandPresupuesto, "i_operation", 'S');
            db.SetParameterValue(commandPresupuesto, "i_option", 'D');

            List<TrasladoPresupuestoMatrizInfo> col = new List<TrasladoPresupuestoMatrizInfo>();

            IDataReader dr = null;

            TrasladoPresupuestoMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPresupuesto);

                while (dr.Read())
                {
                    m = Factory.GetTrasladosPrespuestoMatrizCampana(dr);

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
       /// Lista presupuesto por una campana
       /// </summary>
       /// <param name="campana"></param>
       /// <returns></returns>
        public List<TrasladoPresupuestoMatrizInfo> ListxCampana(String campana)
        {
            db.SetParameterValue(commandPresupuesto, "i_operation", 'S');
            db.SetParameterValue(commandPresupuesto, "i_option", 'E');
            db.SetParameterValue(commandPresupuesto, "i_Campana", campana);

            List<TrasladoPresupuestoMatrizInfo> col = new List<TrasladoPresupuestoMatrizInfo>();

            IDataReader dr = null;

            TrasladoPresupuestoMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPresupuesto);

                while (dr.Read())
                {
                   m = Factory.GetTrasladosPrespuestoMatriz(dr);

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
        /// obtiene una Zona existente mostrando los ultimos nuevos campos cor_rango,tipozona,sumagerente y exceptuando:NCLIENTE NPROVEEDOR,CONTACTO,DIRECCION TELEFONO, FAX, MAIL.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public TrasladoPresupuestoMatrizInfo ListxZona(String zona,String campana)
        {
            db.SetParameterValue(commandPresupuesto, "i_operation", 'S');
            db.SetParameterValue(commandPresupuesto, "i_option", 'F');
            db.SetParameterValue(commandPresupuesto, "i_zona", zona);
            db.SetParameterValue(commandPresupuesto, "i_campana", campana);

            IDataReader dr = null;

            TrasladoPresupuestoMatrizInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPresupuesto);

                while (dr.Read())
                {
                    m = Factory.GetTrasladosPrespuestoMatriz(dr);

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