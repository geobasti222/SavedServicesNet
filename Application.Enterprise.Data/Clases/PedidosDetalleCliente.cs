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
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class PedidosDetalleCliente
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPedidosDetalleCliente;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PedidosDetalleCliente(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PedidosDetalleCliente()
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
            commandPedidosDetalleCliente = db.GetStoredProcCommand("PRC_SVDN_PEDIDOSC2_2020");

            db.AddInParameter(commandPedidosDetalleCliente, "i_operation", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_option", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_numero", DbType.String);
            db.AddParameter(commandPedidosDetalleCliente, "i_id", DbType.String, 22, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandPedidosDetalleCliente, "i_referencia", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_descripcion", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_valor", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_cantidad", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_anulado", DbType.Int32);
            db.AddInParameter(commandPedidosDetalleCliente, "i_tarifaiva", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_ccostos", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_ensamblado", DbType.Int32);
            db.AddInParameter(commandPedidosDetalleCliente, "i_cantidadpedida", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_id_doc_fuente", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_codubicacion", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_plu", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_numeroenvio", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_conceptocontable", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_centrocostos", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_grupo", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_imagen", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_cantidadnivels", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_ivapreciocatalogo", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_valorpreciocatalogo", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_catalogo", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_numeropedidopadre", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_vlr_unitario", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_catalogoreal", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_id_corto", DbType.String);

            db.AddInParameter(commandPedidosDetalleCliente, "i_plusustituto", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_codigorapidosustituto", DbType.String);

            db.AddInParameter(commandPedidosDetalleCliente, "i_unineg", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_porcentajedescuento", DbType.Decimal);
            db.AddInParameter(commandPedidosDetalleCliente, "i_valorpreciocatalogounitario", DbType.Decimal);

            db.AddInParameter(commandPedidosDetalleCliente, "i_campana", DbType.String);

            db.AddInParameter(commandPedidosDetalleCliente, "i_estado", DbType.Boolean);
            db.AddInParameter(commandPedidosDetalleCliente, "i_campanainicio", DbType.String);
            db.AddInParameter(commandPedidosDetalleCliente, "i_catalogoenvio", DbType.String);

            db.AddInParameter(commandPedidosDetalleCliente, "i_puntosganados", DbType.Int32);
            db.AddInParameter(commandPedidosDetalleCliente, "i_porcentajedctopuntos", DbType.Decimal);

            db.AddOutParameter(commandPedidosDetalleCliente, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPedidosDetalleCliente, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Pedidos Detalle Cliente

        /// <summary>
        /// lista todos los Pedidos Detalle Cliente existentes.
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> List()
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'A');

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el encabezado de un pedido especifico.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoDetallexId(string IdPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'B');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", IdPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle de un pedido especifico con un flete asignado.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoFlete(string IdPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'C');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", IdPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleClienteFlete(dr);

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
        /// Lista el detalle de un pedido especifico.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumero(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'D');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle x id especifico.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PedidosDetalleClienteInfo ListxId(string Id)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'E');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_id", Id);


            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);
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
        /// Lista el detalle de un pedido especifico para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroSimulador(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'F');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el encabezado de un pedido especifico para el simulador.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoDetallexIdSimulador(string IdPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'G');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", IdPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Trae el resultado de los pedidos procesados para analizar por el area de demanda
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListxPedidosResultadoProcesamiento()
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'H');

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosResultadoProcesamiento(dr);

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
        /// Lista el detalle de un pedido especifico y totaliza cada detalle
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoTotalizado(string IdPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'I');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", IdPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetDetallePedidoTotalizado(dr);

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
        /// Lista el detalle de los pedidos realizados por la reserva en linea que se encuentran en G&G
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoReservaGYG(string IdPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'J');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", IdPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetDetallePedidoReservaGYG(dr);

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
        /// Lista el detalle de un pedido especifico realizado por reserva en linea.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoDetallexIdxReserva(string IdPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'K');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", IdPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle de un pedido especifico que no se realizo por reserva en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroSinReserva(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'L');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle de un pedido especifico para procesar con SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroProcesamiento(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'M');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle de un pedido especifico para el procesamiento.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroProcesamientoExportar(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'N');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle de un pedido digitado especifico con relacion al kardex.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoKardex(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'O');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle de un pedido digitado especifico con relacion al kardex, si es facturado o no para el detalle del historico.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoKardexFacturado(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'P');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista el detalle de un pedido especifico para enviar email de auditoria.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroMailAuditoria(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'Q');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", NumeroPedido);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista todos los  premios de bienvenida para adicionar al detalle del pedido.
        /// </summary>
        /// <param name="UnidadNegocio"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPremiosBienvenidaActivos(string UnidadNegocio)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'R');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_unineg", UnidadNegocio);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleCliente(dr);

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
        /// Lista todos los  catalogos siguientes a la campaña seleccionada.
        /// </summary>
        /// <param name="CampanaActual"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListCatalogosSiguientes(string CampanaActual)
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_campana", CampanaActual);

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleClienteCatalogo(dr);

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
        /// Lista todos los catalogos siguientes.
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListCatalogosSiguientesConfiguracion()
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'T');

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleClienteCatalogo(dr);

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
        /// Lista todos los impuestos activos para aplicar a los pedidos.
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListImpuestos()
        {
            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'U');

            List<PedidosDetalleClienteInfo> col = new List<PedidosDetalleClienteInfo>();

            IDataReader dr = null;

            PedidosDetalleClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosDetalleClienteImpuestos(dr);

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
        /// Realiza el registro de un detalle de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public string Insert(PedidosDetalleClienteInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'A');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", 0); //Se debe inicializar la variable en 0.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion.Trim());
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad); //NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.Lote.Trim());
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_grupo", item.Grupo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_imagen", item.Imagen);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", item.CantidadNivelServicio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogo", item.ValorPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ivapreciocatalogo", item.IVAPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeropedidopadre", item.NumeroPedidoPadre);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_vlr_unitario", item.ValorUnitario);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogoreal", item.CatalogoReal);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_corto", item.IdCodigoCorto);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_unineg", item.UnidadNegocio);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_codigorapidosustituto", item.CodigoRapidoSustituto);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plusustituto", item.PLUSustituto);


                db.SetParameterValue(commandPedidosDetalleCliente, "i_porcentajedescuento", item.PorcentajeDescuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogounitario", item.ValorPrecioCatalogoUnitario);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_puntosganados", item.PuntosGanados);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_porcentajedctopuntos", item.PorcentajeDescuentoPuntos);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandPedidosDetalleCliente, "i_id")).Trim();

            }
            catch (Exception ex)
            {
                strid = null;

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
        /// Guarda el detalle de pedidos en MKT que tienen premio.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InsertPremiosMkt(PedidosDetalleClienteInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'B');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", 0); //Se debe inicializar la variable en 0.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad); //NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.Lote);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandPedidosDetalleCliente, "i_id")).Trim();

            }
            catch (Exception ex)
            {
                strid = null;

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
        /// Guarda el detalle de un pedido listo para facturar en la tabla de nivi.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertDetalleFacturar(PedidosDetalleClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'C');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", item.Id);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad); //NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.Lote);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeropedidopadre", item.NumeroPedidoPadre);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogoreal", item.CatalogoReal);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_unineg", item.UnidadNegocio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_corto", item.IdCodigoCorto);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_porcentajedescuento", item.PorcentajeDescuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogounitario", item.ValorPrecioCatalogoUnitario);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                Application.Enterprise.Data.PedidosCliente objPedidosCliente = new Application.Enterprise.Data.PedidosCliente("conexion");

                bool okTrasnEstadoPed = objPedidosCliente.UpdateEstadoPedido(item.Numero, (int)EstadosPedidoEnum.ErrorProcesamiento);

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
        /// Realiza el registro de un detalle de pedido de cliente desde un XML.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertXML(PedidosDetalleClienteInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'D');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", item.Id); //Se debe inicializar la variable en 0.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad); //NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.Lote);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_grupo", item.Grupo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_imagen", item.Imagen);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", item.CantidadNivelServicio);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

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
        /// Realiza el registro de un detalle de pedido de cliente para el detalle de los fletes.
        /// </summary>
        /// <param name="item"></param>
        public string InsertFlete(PedidosDetalleClienteInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'E');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", 0); //Se debe inicializar la variable en 0.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad); //NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.Lote.Trim());
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_grupo", item.Grupo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_imagen", item.Imagen);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", item.CantidadNivelServicio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogo", item.ValorPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ivapreciocatalogo", item.IVAPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeropedidopadre", item.NumeroPedidoPadre);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogoreal", item.CatalogoReal);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_unineg", item.UnidadNegocio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_corto", item.IdCodigoCorto);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_porcentajedescuento", item.PorcentajeDescuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogounitario", item.ValorPrecioCatalogoUnitario);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandPedidosDetalleCliente, "i_id")).Trim();

            }
            catch (Exception ex)
            {
                strid = null;

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
        /// Realiza el registro de un detalle de pedido de cliente para el SIMULADOR.
        /// </summary>
        /// <returns></returns>
        public bool InsertSimulador()
        {
            bool okTrans = false;

            db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
            db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'F');

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                okTrans = true;

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

            return okTrans;
        }




        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente para el SIMULADOR.
        /// </summary>
        /// <param name="item"></param>
        public string InsertDetalleSimulador(PedidosDetalleClienteInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'G');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", 0); //Se debe inicializar la variable en 0.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad); //NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.Lote);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_grupo", item.Grupo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_imagen", item.Imagen);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", item.CantidadNivelServicio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogo", item.ValorPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ivapreciocatalogo", item.IVAPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeropedidopadre", item.NumeroPedidoPadre);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandPedidosDetalleCliente, "i_id")).Trim();

            }
            catch (Exception ex)
            {
                strid = null;

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
        /// Realiza el registro de un detalle de catalogo siguiente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InsertCatalogo(PedidosDetalleClienteInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'H');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", item.Id); //Se debe inicializar la variable en 0.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion.Trim());
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad); //NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.Lote.Trim());
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_grupo", item.Grupo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_imagen", item.Imagen);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", item.CantidadNivelServicio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogo", item.ValorPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ivapreciocatalogo", item.IVAPrecioCatalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeropedidopadre", item.NumeroPedidoPadre);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_vlr_unitario", item.ValorUnitario);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogoreal", item.CatalogoReal);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_corto", item.IdCodigoCorto);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_unineg", item.UnidadNegocio);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_porcentajedescuento", item.PorcentajeDescuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valorpreciocatalogounitario", item.ValorPrecioCatalogoUnitario);

                db.SetParameterValue(commandPedidosDetalleCliente, "i_estado", item.Estado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_campanainicio", item.CampanaInicio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_catalogoenvio", item.CatalogoEnvio);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandPedidosDetalleCliente, "i_id")).Trim();

            }
            catch (Exception ex)
            {
                strid = null;

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
        /// Realiza la actualizacion del registro de un detalle de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(PedidosDetalleClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'A');

                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", item.Id);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_referencia", item.Referencia);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadpedida", item.Cantidad);//NOTA:se cambio a i_cantidadpedida  para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_tarifaiva", item.TarifaIVA);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ccostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_ensamblado", item.Ensamblado);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", item.CantidadPedida);//NOTA:se cambio a i_cantidad para asignar el inventario.
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id_doc_fuente", item.IdDocumentoFuente);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_codubicacion", item.CodigoUbicacion);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_plu", item.PLU);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_conceptocontable", item.ConceptoContable);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_centrocostos", item.CentroCostos);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_grupo", item.Grupo);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_imagen", item.Imagen);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", item.CantidadNivelServicio);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

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
        /// Realiza la actualizacion de a cantidad del detalle del pedido.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidad(string Id, decimal Cantidad)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'A');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", Id);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", Cantidad);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

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
        /// Realiza la actualizacion de a cantidad del nivel de servicio del detalle del pedido.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CantidadNivelS"></param>
        /// <returns></returns>
        public bool UpdateCantidadNivelServicio(string Id, decimal CantidadNivelS)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'B');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", Id);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", CantidadNivelS);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

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
        /// Realiza la actualizacion de a cantidad del nivel de servicio del detalle del pedido para el simulador.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CantidadNivelS"></param>
        /// <returns></returns>
        public bool UpdateCantidadNivelServicioSimulador(string Id, decimal CantidadNivelS)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'C');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", Id);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidadnivels", CantidadNivelS);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

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
        /// Se Acutualiza el estado de  Los catalogos siguientes
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public bool UpdateEstado(string Id, bool Estado, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'D');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", Id);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_Estado", Estado);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se Actualiza Estado de la Tabla SVDN_PEDIDOSC2_2000: id :" + Id + " Estado " + Estado + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// Elimina todos los articulos de un pedido detalle.
        /// </summary>
        /// <param name="numero">Numero del Pedido.</param>
        /// <returns></returns>
        public bool DeleteArticulos(string numero)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'A');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_numero", numero);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

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
        /// Elimina la configuracion de un catalogo siguiente por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteCatalago(string Id, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'B');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", Id);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la eliminación de Catalogo Envio. Catalogo Id:" + Id + ". Acción Realizada por el Usuario: " + Usuario;

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

        /// <summary>
        /// Realiza la actualizacion de a cantidad del detalle del pedido para el simulador.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidadSimulador(string Id, decimal Cantidad)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosDetalleCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_option", 'Q');
                db.SetParameterValue(commandPedidosDetalleCliente, "i_id", Id);
                db.SetParameterValue(commandPedidosDetalleCliente, "i_cantidad", Cantidad);

                dr = db.ExecuteReader(commandPedidosDetalleCliente);

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