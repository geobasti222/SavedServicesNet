using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Pedidos Detalle Cliente
    /// </summary>
    public class PedidosDetalleCliente : IPedidosDetalleCliente
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PedidosDetalleCliente module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PedidosDetalleCliente()
        {
            module = new Application.Enterprise.Data.PedidosDetalleCliente();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PedidosDetalleCliente(string databaseName)
        {
            module = new Application.Enterprise.Data.PedidosDetalleCliente(databaseName);
        }


        #region Miembros de IPedidosDetalleCliente

        /// <summary>
        /// Lista todos los Pedidos Detalle Cliente existentes.
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista el encabezado de un pedido especifico.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoDetallexId(string IdPedido)
        {
            return module.ListPedidoDetallexId(IdPedido);
        }


 

        /// <summary>
        /// Lista el detalle de un pedido especifico realizado por reserva en linea.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoDetallexIdxReserva(string IdPedido)
        {
            return module.ListPedidoDetallexIdxReserva(IdPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico con un flete asignado.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoFlete(string IdPedido)
        {
            return module.ListPedidoFlete(IdPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumero(string NumeroPedido)
        {
            return module.ListDetallePedidoxNumero(NumeroPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico para enviar email de auditoria.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroMailAuditoria(string NumeroPedido)
        {
            return module.ListDetallePedidoxNumeroMailAuditoria(NumeroPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico para procesar con SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroProcesamiento(string NumeroPedido)
        {
            return module.ListDetallePedidoxNumero(NumeroPedido);
        }

        /// <summary>
        /// Lista el detalle x id especifico.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PedidosDetalleClienteInfo ListxId(string Id)
        {
            return module.ListxId(Id);
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroSimulador(string NumeroPedido)
        {
            return module.ListDetallePedidoxNumeroSimulador(NumeroPedido);
        }


        /// <summary>
        /// Lista el encabezado de un pedido especifico para el simulador.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPedidoDetallexIdSimulador(string IdPedido)
        {
            return module.ListPedidoDetallexIdSimulador(IdPedido);
        }

        /// <summary>
        /// Trae el resultado de los pedidos procesados para analizar por el area de demanda
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListxPedidosResultadoProcesamiento()
        {
            return module.ListxPedidosResultadoProcesamiento();
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico y totaliza cada detalle
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoTotalizado(string IdPedido)
        {
            return module.ListDetallePedidoTotalizado(IdPedido);
        }

        /// <summary>
        /// Lista el detalle de los pedidos realizados por la reserva en linea que se encuentran en G&G
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoReservaGYG(string IdPedido)
        {
            return module.ListDetallePedidoReservaGYG(IdPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico que no se realizo por reserva en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroSinReserva(string NumeroPedido)
        {
            return module.ListDetallePedidoxNumeroSinReserva(NumeroPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido especifico para el procesamiento.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroProcesamientoExportar(string NumeroPedido)
        {
            return module.ListDetallePedidoxNumeroProcesamientoExportar(NumeroPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido digitado especifico con relacion al kardex.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoKardex(string NumeroPedido)
        {
            return module.ListDetallePedidoKardex(NumeroPedido);
        }

        /// <summary>
        /// Lista el detalle de un pedido digitado especifico con relacion al kardex, si es facturado o no para el detalle del historico.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListDetallePedidoKardexFacturado(string NumeroPedido)
        {
            return module.ListDetallePedidoKardexFacturado(NumeroPedido);
        }


        /// <summary>
        /// Lista todos los  premios de bienvenida para adicionar al detalle del pedido.
        /// </summary>
        /// <param name="UnidadNegocio"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListPremiosBienvenidaActivos(string UnidadNegocio)
        {
            return module.ListPremiosBienvenidaActivos(UnidadNegocio);
        }

        /// <summary>
        /// Lista todos los  catalogos siguientes a la campaña seleccionada.
        /// </summary>
        /// <param name="CampanaActual"></param>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListCatalogosSiguientes(string CampanaActual)
        {
            return module.ListCatalogosSiguientes(CampanaActual);
        }

        /// <summary>
        /// Lista todos los catalogos siguientes.
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListCatalogosSiguientesConfiguracion()
        {
            return module.ListCatalogosSiguientesConfiguracion();
        }

        /// <summary>
        /// Lista todos los impuestos activos para aplicar a los pedidos.
        /// </summary>
        /// <returns></returns>
        public List<PedidosDetalleClienteInfo> ListImpuestos()
        {
            return module.ListImpuestos();
        }

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public string Insert(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }

        /// <summary>
        /// Guarda el detalle de pedidos en MKT que tienen premio.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InsertPremiosMkt(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.InsertPremiosMkt(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }

        /// <summary>
        /// Guarda el detalle de un pedido listo para facturar en la tabla de nivi.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertDetalleFacturar(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.InsertDetalleFacturar(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente desde un XML.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertXML(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.InsertXML(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente para el detalle de los fletes.
        /// </summary>
        /// <param name="item"></param>
        public string InsertFlete(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.InsertFlete(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente para el SIMULADOR.
        /// </summary>
        /// <returns></returns>
        public bool InsertSimulador()
        {
            try
            {
                return module.InsertSimulador();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente para el SIMULADOR.
        /// </summary>
        /// <param name="item"></param>
        public string InsertDetalleSimulador(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.InsertDetalleSimulador(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }

        /// <summary>
        /// Realiza el registro de un detalle de catalogo siguiente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InsertCatalogo(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.InsertCatalogo(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return null;
            }
        }

        /// <summary>
        /// Realiza la actualizacion del registro de un detalle de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(PedidosDetalleClienteInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de a cantidad del detalle del pedido.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidad(string Id, decimal Cantidad)
        {
            try
            {
                return module.UpdateCantidad(Id, Cantidad);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de a cantidad del detalle del pedido para el simulador.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool UpdateCantidadSimulador(string Id, decimal Cantidad)
        {
            try
            {
                return module.UpdateCantidadSimulador(Id, Cantidad);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


        /// <summary>
        /// Realiza la actualizacion de a cantidad del nivel de servicio del detalle del pedido.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CantidadNivelS"></param>
        /// <returns></returns>
        public bool UpdateCantidadNivelServicio(string Id, decimal CantidadNivelS)
        {
            try
            {
                return module.UpdateCantidadNivelServicio(Id, CantidadNivelS);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de a cantidad del nivel de servicio del detalle del pedido para el simulador.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CantidadNivelS"></param>
        /// <returns></returns>
        public bool UpdateCantidadNivelServicioSimulador(string Id, decimal CantidadNivelS)
        {
            try
            {
                return module.UpdateCantidadNivelServicioSimulador(Id, CantidadNivelS);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Se Acutualiza el estado de  Los catalogos siguientes
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public bool UpdateEstado(string Id, bool Estado, string usuario)
        {
            try
            {
                return module.UpdateEstado(Id, Estado, usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina todos los articulos de un pedido detalle.
        /// </summary>
        /// <param name="numero">Numero del Pedido.</param>
        /// <returns></returns>
        public bool DeleteArticulos(string numero)
        {
            try
            {
                return module.DeleteArticulos(numero);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina la configuracion de un catalogo siguiente por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteCatalago(string Id, string Usuario)
        {
            try
            {
                return module.DeleteCatalago(Id, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        #endregion
    }
}
