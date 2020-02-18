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
    public class HistoricoCliente
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandHistoricoCliente;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public HistoricoCliente(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public HistoricoCliente()
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
            commandHistoricoCliente = db.GetStoredProcCommand("PRC_SVDN_CLIENTES_HISTORICO");

            db.AddInParameter(commandHistoricoCliente, "i_operation", DbType.String);
            db.AddInParameter(commandHistoricoCliente, "i_option", DbType.String);
            db.AddInParameter(commandHistoricoCliente, "i_campana", DbType.String);
            db.AddInParameter(commandHistoricoCliente, "i_nit", DbType.String);
            db.AddInParameter(commandHistoricoCliente, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandHistoricoCliente, "i_esc_id", DbType.Int32);
            db.AddInParameter(commandHistoricoCliente, "i_vendedor", DbType.String);
            db.AddInParameter(commandHistoricoCliente, "i_zona", DbType.String);
            db.AddInParameter(commandHistoricoCliente, "i_reg_codregional", DbType.Int32);
            db.AddInParameter(commandHistoricoCliente, "i_duracion_est", DbType.Int32);
            db.AddInParameter(commandHistoricoCliente, "i_tienepedido", DbType.Boolean);
            db.AddInParameter(commandHistoricoCliente, "i_id_campana_orig", DbType.Int32);
            db.AddInParameter(commandHistoricoCliente, "i_id_campana_dest", DbType.Int32);
            db.AddInParameter(commandHistoricoCliente, "i_proceso", DbType.Int32);
            //db.AddInParameter(commandHistoricoCliente, "i_activo", DbType.Int32);

            db.AddOutParameter(commandHistoricoCliente, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandHistoricoCliente, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Historico Clientes

        /// <summary>
        /// Guarda un historico de clientes nuevo.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(HistoricoClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'A');

                db.SetParameterValue(commandHistoricoCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandHistoricoCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandHistoricoCliente, "i_esc_id", item.EstadoCliente);
                db.SetParameterValue(commandHistoricoCliente, "i_proceso", item.Proceso);
                db.SetParameterValue(commandHistoricoCliente, "i_activo", item.Activo);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Insercion de todos los campos en la tabla SVDN_CLIENTES_HISTORICO-
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool FullInsert(HistoricoClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'B');

                db.SetParameterValue(commandHistoricoCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandHistoricoCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandHistoricoCliente, "i_esc_id", item.EstadoCliente);
                db.SetParameterValue(commandHistoricoCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandHistoricoCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandHistoricoCliente, "i_reg_codregional", item.CodigoRegional);
                db.SetParameterValue(commandHistoricoCliente, "i_proceso", item.Proceso);
                db.SetParameterValue(commandHistoricoCliente, "i_activo", item.Activo);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Clonacion del historico de una campaña en campaña siguiente
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="id_campana_orig">Origen: 1. Actual  -  2. Una atras  -  3. Dos atras  -  4 Proxima</param>
        /// <param name="id_campana_dest">Destino: 1. Actual  -  2. Una atras  -  3. Dos atras  -  4 Proxima</param>
        /// <returns></returns>
        public bool InsCopyPasteHistoricoEntreCampanas(DateTime fecha, int id_campana_orig, int id_campana_dest)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'C');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);
                db.SetParameterValue(commandHistoricoCliente, "i_id_campana_orig", id_campana_orig);
                db.SetParameterValue(commandHistoricoCliente, "i_id_campana_dest", id_campana_dest);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);
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
        /// Realiza insercion de los clientes que son prospectos en la tabla de SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertNuevoProspecto(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'D');
                //db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha.ToShortDateString());
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Insercion de Nuevas, Activas, Retenidas y Reingresos
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertEstadosIngresos(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'E');
                //db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha.ToShortDateString());
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Insercion de Posibles Egresos, Egresos e Inactivas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertEstadosInactividades(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'F');
                //db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha.ToShortDateString());
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Insercion de prospectos de campaña anterior en nueva campaña
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool InsertProspectosCampAnterior(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'I');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'G');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Elimina los registros de SVDN_CLIENTES_HISTORICO que hayan anulado todos sus pedidos
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool EliminarPedidosAnulados(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'D');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'A');
                //db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha.ToShortDateString());
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Fix del Bug que se genera al insertar nuevos prospectos
        /// Este procedimiento se encarga de eliminar los prospectos que se insertaron despues
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool EliminarProspectosFix(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'D');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'B');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Realiza la actualizacion del estado activo de un historico existente.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateEstadoActivo(HistoricoClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'U');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'A');

                db.SetParameterValue(commandHistoricoCliente, "i_activo", item.Activo);
                db.SetParameterValue(commandHistoricoCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandHistoricoCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandHistoricoCliente, "i_esc_id", item.EstadoCliente);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Actualizacion de empresarias que haya realizado pedido
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateEmpresariasEstadoConPedido(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'U');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'B');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Actualizacion de empresarias que NO haya realizado pedido
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateEmpresariasEstadoSinPedido(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'U');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'C');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Actualizacion de campos de empresarias prospectos que puedan tener inconsistencias
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateProspectosIncompletos(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'U');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'E');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Se actualizan todos los estados de empresarias que realizan anulacion de pedido
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateAnulaciones(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'U');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'F');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// ACTUALIZACION DE ESTADOS EN LA TABLA CLIENTES
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateTablaClientes(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandHistoricoCliente, "i_operation", 'U');
                db.SetParameterValue(commandHistoricoCliente, "i_option", 'G');
                db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

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
        /// Lista todos los historicos de clientes
        /// </summary>
        /// <returns></returns>
        public List<HistoricoClienteInfo> List()
        {
            db.SetParameterValue(commandHistoricoCliente, "i_operation", 'S');
            db.SetParameterValue(commandHistoricoCliente, "i_option", 'A');

            List<HistoricoClienteInfo> col = new List<HistoricoClienteInfo>();

            IDataReader dr = null;

            HistoricoClienteInfo m = null;

            try
            {
                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

                while (dr.Read())
                {
                    m = Factory.GetHistoricoCliente(dr);

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
        /// Lista de informe comparativo de variables de la tabla de historicos de clientes entre campañas actual, anterior y año pasado
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<HistoricoClienteComparacionInfo> HistoricoComparacion(DateTime fecha)
        {
            db.SetParameterValue(commandHistoricoCliente, "i_operation", 'S');
            db.SetParameterValue(commandHistoricoCliente, "i_option", 'B');
            db.SetParameterValue(commandHistoricoCliente, "i_fecha", fecha);

            List<HistoricoClienteComparacionInfo> col = new List<HistoricoClienteComparacionInfo>();

            IDataReader dr = null;

            HistoricoClienteComparacionInfo m = null;

            try
            {
                commandHistoricoCliente.CommandTimeout = 360;
                dr = db.ExecuteReader(commandHistoricoCliente);

                while (dr.Read())
                {
                    m = Factory.GetHistoricoClienteComparacion(dr);

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