using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Pedidos Detalle Cliente
    /// </summary>
    public interface IPedidosDetalleCliente
    {
        #region "Metodos de Pedidos Detalle Cliente"

        /// <summary>
        /// Lista todos los Pedidos Detalle Cliente existentes.
        /// </summary>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> List();

        /// <summary>
        /// Lista el encabezado de un pedido especifico.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListPedidoDetallexId(string IdPedido);

        /// <summary>
        /// Lista el detalle de un pedido especifico con un flete asignado.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListPedidoFlete(string IdPedido);

        /// <summary>
        /// Lista el detalle de un pedido especifico.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoxNumero(string NumeroPedido);

        /// <summary>
        /// Lista el detalle x id especifico.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PedidosDetalleClienteInfo ListxId(string Id);

        /// <summary>
        /// Lista el detalle de un pedido especifico para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroSimulador(string NumeroPedido);


        /// <summary>
        /// Lista el encabezado de un pedido especifico para el simulador.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListPedidoDetallexIdSimulador(string IdPedido);

        /// <summary>
        /// Trae el resultado de los pedidos procesados para analizar por el area de demanda
        /// </summary>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListxPedidosResultadoProcesamiento();

        /// <summary>
        /// Lista el detalle de un pedido especifico y totaliza cada detalle
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoTotalizado(string IdPedido);

        /// <summary>
        /// Lista el detalle de los pedidos realizados por la reserva en linea que se encuentran en G&G
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoReservaGYG(string IdPedido);

        /// <summary>
        /// Lista el detalle de un pedido especifico realizado por reserva en linea.
        /// </summary>
        /// <param name="IdPedido">Id del pedido</param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListPedidoDetallexIdxReserva(string IdPedido);

        /// <summary>
        /// Lista el detalle de un pedido especifico que no se realizo por reserva en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroSinReserva(string NumeroPedido);

        /// <summary>
        /// Lista el detalle de un pedido especifico para procesar con SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroProcesamiento(string NumeroPedido);

        /// <summary>
        /// Lista el detalle de un pedido especifico para el procesamiento.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroProcesamientoExportar(string NumeroPedido);

        /// <summary>
        /// Lista el detalle de un pedido digitado especifico con relacion al kardex.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoKardex(string NumeroPedido);

        /// <summary>
        /// Lista el detalle de un pedido digitado especifico con relacion al kardex, si es facturado o no para el detalle del historico.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoKardexFacturado(string NumeroPedido);

        /// <summary>
        /// Lista el detalle de un pedido especifico para enviar email de auditoria.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListDetallePedidoxNumeroMailAuditoria(string NumeroPedido);

        /// <summary>
        /// Lista todos los  premios de bienvenida para adicionar al detalle del pedido.
        /// </summary>
        /// <param name="UnidadNegocio"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListPremiosBienvenidaActivos(string UnidadNegocio);

        /// <summary>
        /// Lista todos los  catalogos siguientes a la campaña seleccionada.
        /// </summary>
        /// <param name="CampanaActual"></param>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListCatalogosSiguientes(string CampanaActual);

        /// <summary>
        /// Lista todos los catalogos siguientes.
        /// </summary>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListCatalogosSiguientesConfiguracion();

        /// <summary>
        /// Lista todos los impuestos activos para aplicar a los pedidos.
        /// </summary>
        /// <returns></returns>
        List<PedidosDetalleClienteInfo> ListImpuestos();

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        string Insert(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Guarda el detalle de pedidos en MKT que tienen premio.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string InsertPremiosMkt(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Guarda el detalle de un pedido listo para facturar en la tabla de nivi.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool InsertDetalleFacturar(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente desde un XML.
        /// </summary>
        /// <param name="item"></param>
        bool InsertXML(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente para el detalle de los fletes.
        /// </summary>
        /// <param name="item"></param>
        string InsertFlete(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente para el SIMULADOR.
        /// </summary>
        /// <returns></returns>
        bool InsertSimulador();

        /// <summary>
        /// Realiza el registro de un detalle de pedido de cliente para el SIMULADOR.
        /// </summary>
        /// <param name="item"></param>
        string InsertDetalleSimulador(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Realiza el registro de un detalle de catalogo siguiente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string InsertCatalogo(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Realiza la actualizacion del registro de un detalle de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        bool Update(PedidosDetalleClienteInfo item);

        /// <summary>
        /// Realiza la actualizacion de a cantidad del detalle del pedido.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        bool UpdateCantidad(string Id, decimal Cantidad);

        /// <summary>
        /// Realiza la actualizacion de a cantidad del nivel de servicio del detalle del pedido.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CantidadNivelS"></param>
        /// <returns></returns>
        bool UpdateCantidadNivelServicio(string Id, decimal CantidadNivelS);


        /// <summary>
        /// Realiza la actualizacion de a cantidad del nivel de servicio del detalle del pedido para el simulador.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="CantidadNivelS"></param>
        /// <returns></returns>
        bool UpdateCantidadNivelServicioSimulador(string Id, decimal CantidadNivelS);

        /// <summary>
        /// Realiza la actualizacion de a cantidad del detalle del pedido para el simulador.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        bool UpdateCantidadSimulador(string Id, decimal Cantidad);

        /// <summary>
        /// Se Acutualiza el estado de  Los catalogos siguientes
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        bool UpdateEstado(string Id, bool Estado,string usuario);

        /// <summary>
        /// Elimina todos los articulos de un pedido detalle.
        /// </summary>
        /// <param name="numero">Numero del Pedido.</param>
        /// <returns></returns>
        bool DeleteArticulos(string numero);

        /// <summary>
        /// Elimina la configuracion de un catalogo siguiente por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool DeleteCatalago(string Id, string Usuario);

        #endregion
    }
}

