using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Data
{
    public class ProcesamientosCampana
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandProcesamientosCampana;

        #region Constructor

        public ProcesamientosCampana(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        public ProcesamientosCampana()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        private void Config()
        {
            commandProcesamientosCampana = db.GetStoredProcCommand("PRC_SVDN_PROCESAMIENTOS_CAMPANA");

            db.AddInParameter(commandProcesamientosCampana, "i_operation", DbType.String);                  						
            db.AddInParameter(commandProcesamientosCampana, "i_option", DbType.String);                     						
            db.AddInParameter(commandProcesamientosCampana, "i_cprc_id", DbType.Int32);                     						
            db.AddInParameter(commandProcesamientosCampana, "i_prc_id", DbType.Int32);                      						
            db.AddInParameter(commandProcesamientosCampana, "CAMPANA", DbType.String);                      						
            db.AddInParameter(commandProcesamientosCampana, "FECHAINI", DbType.DateTime);                   						
            db.AddInParameter(commandProcesamientosCampana, "FECHAFIN", DbType.DateTime);                   						
            db.AddInParameter(commandProcesamientosCampana, "i_top", DbType.Int32);
            db.AddInParameter(commandProcesamientosCampana, "i_filtronumerico", DbType.Int32);
            db.AddOutParameter(commandProcesamientosCampana, "o_err_cod", DbType.Int32, 1000);              						
            db.AddOutParameter(commandProcesamientosCampana, "o_err_msg", DbType.String, 1000);             						
        }
        #endregion
        
        #region Metodos de ProcesamientosTipo

        public List<ProcesamientosCampanaInfo> List(int idPrc)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'A');
            db.SetParameterValue(commandProcesamientosCampana, "i_prc_id", idPrc);

            List<ProcesamientosCampanaInfo> col = new List<ProcesamientosCampanaInfo>();

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);

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
        /// Mostrar el ultimo elemento de la tabla SVDN_PROCESAMIENTOS_CAMPANA de acuerdo a un tipo de Procesamiento y ordenado por fecha
        /// </summary>
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>

        public ProcesamientosCampanaInfo ListUltima(int idPrc)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'B');
            db.SetParameterValue(commandProcesamientosCampana, "i_prc_id", idPrc);

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                if (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);
                }
                else
                {
                    m = null;
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
        /// Mostrar el primer elemento de la tabla SVDN_PROCESAMIENTOS_CAMPANA de acuerdo a un tipo de Procesamiento y ordenado por fecha
        /// </summary>
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>

        public ProcesamientosCampanaInfo ListPrimera(int idPrc)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'C');
            db.SetParameterValue(commandProcesamientosCampana, "i_prc_id", idPrc);

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                if (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);
                }
                else
                {
                    m = null;
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
        /// Lista cantidad definida de Campanas de un tipo de procesamiento especifico
        /// </summary>
        /// <param name="idPrc">Tipo de Procesamiento</param>
        /// <param name="top">Cantidad de Campañas</param>
        /// <returns></returns>
        public List<ProcesamientosCampanaInfo> ListCantidadDefinida(int idPrc, int top)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'D');
            db.SetParameterValue(commandProcesamientosCampana, "i_prc_id", idPrc);
            db.SetParameterValue(commandProcesamientosCampana, "i_top", top);

            List<ProcesamientosCampanaInfo> col = new List<ProcesamientosCampanaInfo>();

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosCampanaSinCprc_id(dr);

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
        /// lista las campañas del año vigente
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>
        public List<ProcesamientosCampanaInfo> ListCampanasXAno(int idPrc)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'E');
            db.SetParameterValue(commandProcesamientosCampana, "i_prc_id", idPrc);            

            List<ProcesamientosCampanaInfo> col = new List<ProcesamientosCampanaInfo>();

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);

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
        /// La fecha de cierre de campaña anterior
        /// </summary>
        public ProcesamientosCampanaInfo FechaFinCampanaAnterior(DateTime fecha)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'F');
            db.SetParameterValue(commandProcesamientosCampana, "FECHAINI", fecha);
            
            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);
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
        /// Ejecucion de la funcion de Procesamientos_Campana filtronumerico:
        /// 1. campaña actual
        /// 2. campaña anterior
        /// 3. dos campañas anteriores
        /// 4. proxima campaña
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="filtronumerico"></param>
        /// <returns></returns>
        public ProcesamientosCampanaInfo ProcesoCampanaFnc(DateTime fecha, int filtronumerico)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'G');
            db.SetParameterValue(commandProcesamientosCampana, "FECHAFIN", fecha);
            db.SetParameterValue(commandProcesamientosCampana, "i_filtronumerico", filtronumerico);                        

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);
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
        /// Lista de campañas de SVDN_PROCESAMIENTOS_CAMPANA que existan en SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="filtronumerico"></param>
        /// <returns></returns>
        public List<ProcesamientosCampanaInfo> ListCampanasHistorico()
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'H');

            List<ProcesamientosCampanaInfo> col = new List<ProcesamientosCampanaInfo>();

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);

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
        /// Lista las ultimas X campañas que defina el usuario
        /// </summary>
        /// <param name="cantidad">cantidad de campañas desde la ultima para atras</param>
        /// <returns></returns>
        public List<ProcesamientosCampanaInfo> ListUltimasCampanas(int top, DateTime fechafin)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'I');
            db.SetParameterValue(commandProcesamientosCampana, "i_top", top);
            db.SetParameterValue(commandProcesamientosCampana, "FECHAFIN", fechafin);

            List<ProcesamientosCampanaInfo> col = new List<ProcesamientosCampanaInfo>();

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                while (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);

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
        /// Realiza insercion de fechas de la campaña actual con respecto a un proceso determinado
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InsertProcesamientoCampana(ProcesamientosCampanaInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'I');
                db.SetParameterValue(commandProcesamientosCampana, "i_option", 'A');                
                db.SetParameterValue(commandProcesamientosCampana, "i_prc_id", item.ProcessId);

                dr = db.ExecuteReader(commandProcesamientosCampana);

                strid = System.Convert.ToString(db.GetParameterValue(commandProcesamientosCampana, "i_prc_id")).Trim();
                //Obtiene el identificador (consecutivo) del insert                

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

            return strid;
        }

        /// <summary>
        /// Actualiza la fechas de SVDN_PROCESAMIENTOS_CAMPANA
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateProcesamientoCampana(ProcesamientosCampanaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'U');
                db.SetParameterValue(commandProcesamientosCampana, "i_option", 'A');
                db.SetParameterValue(commandProcesamientosCampana, "@FECHAINI", item.FechaInicial);
                db.SetParameterValue(commandProcesamientosCampana, "@FECHAFIN", item.FechaFinal);

                dr = db.ExecuteReader(commandProcesamientosCampana);
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
        /// Capa Datos para Actualizar las fechas de un proceso sobre la campaña que esta corriendo actualmente
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateProcesamientoCampanaActual(ProcesamientosCampanaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'U');
                db.SetParameterValue(commandProcesamientosCampana, "i_option", 'B');
                db.SetParameterValue(commandProcesamientosCampana, "@i_prc_id", item.ProcessId);                

                dr = db.ExecuteReader(commandProcesamientosCampana);
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
        /// Mostrar el ultimo elemento de la tabla SVDN_PROCESAMIENTOS_CAMPANA de acuerdo a un tipo de Procesamiento y ordenado por fecha
        /// </summary>
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>

        public ProcesamientosCampanaInfo ListSegunFecha(DateTime fechaini)
        {
            db.SetParameterValue(commandProcesamientosCampana, "i_operation", 'S');
            db.SetParameterValue(commandProcesamientosCampana, "i_option", 'J');
            db.SetParameterValue(commandProcesamientosCampana, "FECHAINI", fechaini);

            IDataReader dr = null;

            ProcesamientosCampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProcesamientosCampana);

                if (dr.Read())
                {
                    m = Factory.GetProcesamientosCampana(dr);
                }
                else
                {
                    m = null;
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
