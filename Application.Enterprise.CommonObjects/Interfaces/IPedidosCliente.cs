using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Pedidos Cliente
    /// </summary>
    public interface IPedidosCliente
    {
        #region "Metodos de Pedidos Cliente"

        /// <summary>
        /// lista todos los Pedidos Cliente existentes.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> List();

        /// <summary>
        /// lista todos los Pedidos de empresaria por una campaña.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxEmpresaria(string Nit, string Campana);

        /// <summary>
        /// --Lista todos los pedidos de una empresaria por una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxEmpresariaxCampanaxCatalogo(string Nit, string Campana, string Catalogo);

        /// <summary>
        /// Lista todos los pedidos sin facturar una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidoSinFacturar(string Nit, string Campana, string Catalogo);

        /// <summary>
        /// Lista todos los pedidos sin facturar una campaña x catalogo de la reserva y como borrador.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidoSinFacturarxReserva(string Nit, string Campana, string Catalogo, string NumeroPedido);

        /// <summary>
        /// lista todos los Pedidos de una gerente de zona por una campaña.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZona(string Vendedor, string Campana);

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaReservados(string Vendedor, string Campana);

        /// <summary>
        /// lista todos los Pedidos de una empresaria por una campaña, para el portal de empresarias.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxEmpresariaPortal(string Nit, string Campana);

        /// <summary>
        /// Lista el encabezado de un pedido especifico.
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        PedidosClienteInfo ListPedidoxId(string IdPedido);

        /// <summary>
        /// Selecciona de la tabla temporal los registros filtrados por la regla.
        /// </summary>
        /// <param name="QueryRegla"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxRegla(string QueryRegla);

        /// <summary>
        /// Selecciona de la tabla temporal los registros filtrados por la regla para PREMIOS.
        /// </summary>
        /// <param name="QueryReglaPremios"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxReglaPremios(string QueryReglaPremios);

        /// <summary>
        /// lista todos los Pedidos Cliente existentes en la tabla temporal.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListTablaTemporal();

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampana(string Zona, string Campana);

        /// <summary>
        /// --Lista un pedido especifico de un cliente x camapana x catalogo
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        PedidosClienteInfo ListxNitxCampanaxCatalogo(string Nit, string Campana, string Catalogo);


        /// <summary>
        /// Lista los pedidos no bloqueados que corresponden a una zona y una campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueado(string Zona, string Campana);

        /// <summary>
        /// Lista los pedidos no bloqueados que deben contener un premio.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueadoPremio(string Zona, string Campana);

        /// <summary>
        /// Lista todos los pedidos de la tabla temporal.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListTemporal();

        /// <summary>
        ///  lista todos los Pedidos Cliente con premios existentes en la tabla temporal.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListTablaPremiosTemporal();

        /// <summary>
        /// Lista el Pedido de un Cliente para asignar premio en la tabla temporal.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListTablaPremiosTemporalxNit(string Nit);

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña y por orden asignado.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaxOrden(string Zona, string Campana, int Orden);

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña ordenados por las reglas asignadas.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaxOrdenProcesado(string Zona, string Campana);

        /// <summary>
        /// Lista los pedidos procesados con premios y flete listos para facturar.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidoFacturar(string Zona, string Campana);

        /// <summary>
        /// Lista el encabezado de un pedido por numero.
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        PedidosClienteInfo ListEncabezadoPedidoxNumero(string Numero);

        /// <summary>
        /// Lista si existe un pedido especifico en MKT.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        PedidosClienteInfo ListPedidosMkt(string NumeroPedido);

        /// <summary>
        /// lista un Pedido por numero de la tabla temporal de premios .
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        PedidosClienteInfo ListTablaPremiosTemporalxNumero(string NumeroPedido);

        /// <summary>
        /// Lista los pedidos y sus estados depues de procesados.
        /// </summary>
        /// <param name="Mailgroup"></param>
        /// <param name="Zona"></param>
        /// <param name="IdEstado"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosProcesados(string Mailgroup, string Zona, int IdEstado);

        /// <summary>
        /// Lista los pedidos disponibles para anular sin estado en produccion.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosAnular();

        /// <summary>
        /// Lista un pedido especifico de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        PedidosClienteInfo ListxNitxCampana(string Nit, string Campana);

        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosxEmpresaria(string Nit, string Campana);

        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña sin procesar.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosxEmpresariaSinProcesar(string Nit, string Campana);

        /// <summary>
        /// Lista los pedidos para sumarle el valor del felte luego que estan en produccion
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaSumarFlete(string Zona, string Campana);

        /// <summary>
        /// Lista los pedidos bloqueados de algun tipo de catalogo nivi.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosBloqueados(string Zona, string Campana);

        /// <summary>
        /// Lista los pedidos especificos de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosxNitxCampana(string Nit, string Campana);

        /// <summary>
        /// Lista los pedidos de una empresaria por una campaña del catalogo outlet y de hogar.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosxEmpresariaOuletHogar(string Nit, string Campana);

        /// <summary>
        /// Lista los pedidos del catalogo nivi para procesar por zona y campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosProcesarNivi(string Zona, string Campana);

        /// <summary>
        /// lista todos los Pedidos de una gerente regional por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteRegional(string CedulaRegional, string Campana);


        /// <summary>
        /// Lista los pedidos de una empresaria por una campaña del catalogo outlet y de hogar para el simulador.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosxEmpresariaOuletHogarSimulador(string Nit, string Campana);

        /// <summary>
        /// Lista los pedidos no bloqueados que corresponden a una zona y una campaña para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueadoSimulador(string Zona, string Campana);

        /// <summary>
        /// Lista los pedidos bloqueados de algun tipo de catalogo nivi para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosBloqueadosSimulador(string Zona, string Campana);

        /// <summary>
        /// Lista los pedidos especificos de un cliente para el simulador
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosxNitxCampanaSimulador(string Nit, string Campana);

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaSimulador(string Zona, string Campana);

        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña y por orden asignado para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaxOrdenSimulador(string Zona, string Campana, int Orden);


        /// <summary>
        /// Lista los pedidos correspondientes a una zona y una campaña ordenados por las reglas asignadas para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaxCampanaxOrdenProcesadoSimulador(string Zona, string Campana);

        /// <summary>
        /// lista todos los Pedidos de una gerente de zona por una campaña facturados.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaFacturados(string Vendedor, string Campana);

        /// <summary>
        /// lista todos los Pedidos de una gerente de zona por una campaña facturados ecuador.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaFacturadosEc(string Vendedor, string Campana);

        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxEmpresariaFacturados(string Nit, string Campana);

        /// <summary>
        /// lista todos los Pedidos Facturados de una gerente regional por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteRegionalFacturados(string CedulaRegional, string Campana);

        /// <summary>
        /// Muestra el resumen de los valores NETO y flete+iva de una campaña y un vendedor de los pedidos facturados y sin facturar.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxResumenTotalPedidos(string Vendedor, string Campana);

        /// <summary>
        /// El resumen de pedidos para una gerente regional
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxResumenTotalPedidosGerenteRegional(string CedulaRegional, string Campana);

        /// <summary>
        /// Trae los pedidos de los mailgroups activos para facturar
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidosActivosFacturar();


        /// <summary>
        ///  Consulta el nivel de servicio resultado del procesamiento
        /// </summary>
        /// <returns></returns>
        PedidosClienteInfo ListxTotalNivelServicio();
        /// <summary>
        /// Consulta las empresarias que ganaron premio de bienvenida
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxTotalEmpresariasNuevas();
        /// <summary>
        ///  Consulta la cantidad de fletes asignados despues del procesamiento
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxTotalFletesAsignados();
        /// <summary>
        /// lista el total de pedidos sin facturar
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxTotalPedidosProcesados();

        /// <summary>
        ///  lista los pedidos detallados para exportar a excel o pdf
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidosExportar(string Vendedor);

        /// <summary>
        /// lista los pedidos detallados de una empresaria para exportar a excel o pdf
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidosExportarxNit(string Nit);

        /// <summary>
        /// lista un pedido para saber en que mes se encuentra.
        /// </summary>
        /// <returns></returns>
        PedidosClienteInfo ListPedidoConsultarMes();

        /// <summary>
        ///  lista todos los pedidos de todos los mailgroup x campaña asin bloqueos y sin procesar.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListTodosPedidoSinProcesarSinBloqueo();

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosRetenidos(string Campana, string IdVendedor);

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana x Empresaria
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosRetenidosxEmpresaria(string Campana, string Nit);

        /// <summary>
        /// Lista los pedidos anulados
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosAnulados(string Campana, string IdVendedor);

        /// <summary>
        /// Lista todos los pedidos anulados categorizados.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListTodosPedidosAnulados();

        /// <summary>
        /// Lista los pedidos anulados de una empresaria.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosAnuladosxNit(string Campana, string Nit);

        /// <summary>
        ///  Lista los pedidos anulados de una empresaria del portal.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosAnuladosxEmpresariaPortal(string Campana, string Nit);

        /// <summary>
        /// lista los pedidos de un cliente facturados para saber si se cobra flete
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxNitxCampanaPedidosGYG(string Nit, string Campana);

        /// <summary>
        /// Lista la informacion de los pedidos para el modulo de SAC.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosSAC(string Nit, string NumeroPedido);

        /// <summary>
        /// Lista los pedidos que se encuentran en un estado que no esten bloqueados de una campaña.
        /// </summary>
        /// <param name="EstadoPedido"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxEstadoPedido(int EstadoPedido, string Campana);


        ///// <summary>
        ///// Lista de pedidos que no han sido procesados en SVDN_CLIENTES_HISTORICO
        ///// </summary>
        ///// <returns></returns>
        //List<PedidosClienteInfo> PedidosProcesadosClienteHistorico();

        /// <summary>
        /// Lista todos los pedidos de una empresaria de zona por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxNitFacturados(string Nit, string Campana);

        /// <summary>
        /// lista todos los Pedidos de un lider x zona por una campaña facturados.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosFacturadosLider(string IdLider, string Campana);

        /// <summary>
        /// Lista los pedidos anulados de un lider.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosAnuladosLider(string Campana, string IdLider);

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana de un lider.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosRetenidosLider(string Campana, string IdLider);

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una empresaria.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosRetenidosxEmpresariaPortal(string Campana, string Nit);

        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxNitFacturadosEmpresarias(string Nit, string Campana);

        /// <summary>
        /// Lista todos los pedidos proximos a vencer para anular en el dia actual.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidosProximosAnular();

        /// <summary>
        /// Lista todos los pedidos para cambio de campaña.
        /// </summary>
        /// <param name="CampanaActual"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidosCambioCampana(string CampanaActual);

        /// <summary>
        /// Consulta si un cliente realizo un pedido en la campaña.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidoxNitxCampana(string Nit, string Campana, string NumeroPedidoCreado);

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportista(string Vendedor, string Campana);

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista x Divisional.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportistaxDivisional(string CedulaDivisional, string Campana);

        /// <summary>
        /// lista todos los Pedidos de una zona maestra por una campaña.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxZonaMaestra(string ZonaMaestra, string Campana);

        /// <summary>
        /// Lista todos los pedidos de una gerente de zona por una campaña facturados en G&G para Zona Maestra.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaFacturadosZonaMaestra(string ZonaMaestra, string Campana);

        /// <summary>
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora para Zona Maestra.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="ZonaMaestra"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosRetenidosZonaMaestra(string Campana, string ZonaMaestra);

        /// <summary>
        /// Lista los pedidos anulados para Zona Maestra.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="ZonaMaestra"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosAnuladosZonaMaestra(string Campana, string ZonaMaestra);

        /// <summary>
        /// Lista la informacion de los pedidos para el modulo de SAC para una Zona Maestra.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <param name="ZonaMestra"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListPedidosSACZonaMaestra(string Nit, string NumeroPedido, string ZonaMestra);

        /// <summary>
        /// Lista todos los pedidos en reserva guardados por una gerente para Zona Maestra.
        /// </summary>
        /// <param name="ZonaMaestra"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaReservadosZonaMaestra(string ZonaMaestra, string Campana);

        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        string Insert(PedidosClienteInfo item);

        /// <summary>
        /// Guarda los registros filtrados por una regla en la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        void InsertxRegla(PedidosClienteInfo item);

        /// <summary>
        /// Guarda los pedidos que fueron seleccionados para asignar premio en la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        void InsertxReglaxPremio(PedidosClienteInfo item);

        /// <summary>
        /// Guarda los encabezados de pedidos en MKT que tienen premio.
        /// </summary>
        /// <param name="item"></param>
        bool InsertPremiosMkt(PedidosClienteInfo item);

        /// <summary>
        /// Guarda los encabezados de pedidos en Nivi listos para facturar.
        /// </summary>
        /// <param name="item"></param>
        bool InsertFacturar(PedidosClienteInfo item);

        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente cargado con un XML.
        /// </summary>
        /// <param name="item"></param>
        bool InsertXML(PedidosClienteInfo item);

        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente en las tablas de SIMULACION.
        /// </summary>
        /// <param name="item"></param>
        bool InsertSimulador();

        /// <summary>
        /// Realiza la actualizacion del registro de un encabezado de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        bool Update(PedidosClienteInfo item);

        /// <summary>
        /// Realiza la actualizacion del orden  de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        bool UpdateOrden(string NumeroPedido, int Orden);

        /// <summary>
        /// Realiza la actualizacion del estado procesado del pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool UpdateProcesado(string NumeroPedido, bool Procesado);

        /// <summary>
        /// Realiza la actualizacion del nivel de servicio y estado.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="NivelServicioEstado"></param>
        /// <param name="NivelServicioEstimado"></param>
        /// <param name="NivelServicioReal"></param>
        /// <param name="NivelServicioTipo"></param>
        /// <returns></returns>
        bool UpdateNivelServicio(string NumeroPedido, bool NivelServicioEstado, decimal NivelServicioEstimado, decimal NivelServicioReal, string NivelServicioTipo);

        /// <summary>
        /// Realiza la actualizacion del estado de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EstadoPedido">0 =	Sin Estado, 1 =	Normal, 2 =	Agotado, 3 = Retenido Premios, 4 = Nivel Servicio, 5 =	Cartera, 6 = Desmanteladora</param>
        /// <returns></returns>
        bool UpdateEstadoPedido(string NumeroPedido, int EstadoPedido);

        /// <summary>
        /// Realiza la actualizacion del tipo query de un pedido temporal para verificar en la asignacion de premios.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="TipoQuery"></param>
        /// <returns></returns>
        bool UpdateTipoQuery(string NumeroPedido, string TipoQuery);

        /// <summary>
        /// Realiza la actualizacion del estado en produccion, para que en los premios no repita los pedidos de las tablas de nivi y las svdn.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        bool UpdateEnProduccion(string NumeroPedido, bool EnProduccion);

        /// <summary>
        /// Realiza la anulacion de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool UpdateAnularPedido(string NumeroPedido);

        /// <summary>
        /// Realiza la anulacion de un pedido de reserva en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool UpdateAnularPedidoReserva(string NumeroPedido, string motivo, string codmotivo, string Usuario);

        /// <summary>
        /// Realiza la des-anulacion de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool UpdateDesAnularPedido(string NumeroPedido);

        /// <summary>
        ///  Realiza la actualizacion del valor de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        bool UpdateValorPedido(string NumeroPedido, decimal Valor, decimal IVA);

        /// <summary>
        ///  Realiza la actualizacion del valor de un pedido en SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        bool UpdateValorPedidoSVDN(string NumeroPedido, decimal Valor, decimal IVA);

        /// <summary>
        ///  Realiza el bloqueo temporal de los pedidos de un mailgroup por campaña
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Pedido"></param>
        /// <returns></returns>
        bool BloquearPedidosxMailgroupSVDN(string Campana, string Pedido);

        /// <summary>
        /// Realiza la actualizacion del estado de los pedidos que se encuentran bloqueados por nivel de servicio por camapaña actual.
        /// </summary>
        /// <returns></returns>
        bool UpdateBloqueadosNivelServicio();

        /// <summary>
        /// Realiza la actualizacion del estado de los pedidos que se encuentran excluidos del procesamiento por camapaña actual.
        /// </summary>
        /// <returns></returns>
        bool UpdateBloqueadosExcluidos();

        /// <summary>
        /// Realiza la actualizacion del estado de los pedidos que se encuentran bloqueados por cartera.
        /// </summary>
        /// <returns></returns>
        bool UpdateBloqueadosCartera();

        /// <summary>
        /// Realiza la actualizacion del mes de un pedido
        /// </summary>
        /// <param name="Numero"></param>
        /// <param name="Mes"></param>
        /// <returns></returns>
        bool UpdateMes(string Numero, string Mes);

        /// <summary>
        ///  Realiza la actualizacion del valor de un pedido en SVDN simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        bool UpdateValorPedidoSVDNSimulador(string NumeroPedido, decimal Valor, decimal IVA);

        /// <summary>
        /// Realiza la actualizacion del estado de un pedido en el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EstadoPedido">0 =	Sin Estado, 1 =	Normal, 2 =	Agotado, 3 = Retenido Premios, 4 = Nivel Servicio, 5 =	Cartera, 6 = Desmanteladora</param>
        /// <returns></returns>
        bool UpdateEstadoPedidoSimulador(string NumeroPedido, int EstadoPedido);

        /// <summary>
        /// Realiza la actualizacion del estado en produccion, para que en los premios no repita los pedidos de las tablas de nivi y las svdn en el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        bool UpdateEnProduccionSimulador(string NumeroPedido, bool EnProduccion);

        /// <summary>
        /// Realiza la actualizacion del nivel de servicio y estado simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="NivelServicioEstado"></param>
        /// <param name="NivelServicioEstimado"></param>
        /// <param name="NivelServicioReal"></param>
        /// <param name="NivelServicioTipo"></param>
        /// <returns></returns>
        bool UpdateNivelServicioSimulador(string NumeroPedido, bool NivelServicioEstado, decimal NivelServicioEstimado, decimal NivelServicioReal, string NivelServicioTipo);

        /// <summary>
        /// Realiza la actualizacion del estado de la variable "procesado_cliente_historico" a True
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        bool UpdateValorClienteHistorico(DateTime fecha);

        /// <summary>
        /// Realiza la actualizacion del orden  de un pedido para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        bool UpdateOrdenSimulador(string NumeroPedido, int Orden);

        /// <summary>
        /// Realiza la actualizacion del estado procesado del pedido para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool UpdateProcesadoSimulador(string NumeroPedido, bool Procesado);

        /// <summary>
        /// Realiza la suma de un dia adicional a un pedido que se encuentra por anular.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool UpdateDiaAdicionalPedido(string NumeroPedido, string Usuario);

        /// <summary>
        /// Realiza la liberacion de pedidos por zona seleccionada de facturacion semanal.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        bool UpdateLiberarZonasPedidosFactSemanal(string Campana, string Zona);

        /// <summary>
        /// Actualiza la ciudad de despacho de un pedido.
        /// </summary>
        /// <param name="CiudadDespacho"></param>
        /// <returns></returns>
        bool UpdateCiudadDespacho(string CiudadDespacho);

        /// <summary>
        /// SIESA: actualiza datos del pedido despues de enviado a siesa.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool UpdatePedidoEnSiesa(string NumeroPedido);

        /// <summary>
        /// Elimina todos los pedidos de la tabla temporal
        /// </summary>
        /// <returns></returns>
        bool DeleteTemporal();

        /// <summary>
        /// Elimina todos los pedidos con premios de la tabla temporal
        /// </summary>
        /// <returns></returns>
        bool DeletePremiosTemporal();

        /// <summary>
        /// Elimina todos los pedidos de la tabla temporal de una campaña y una zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        bool DeleteTemporalxZonaxCampana(string Zona, string Campana);

        /// <summary>
        /// Elimina un pedido especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool DeletexNumeroPedido(string NumeroPedido);

        /// <summary>
        /// Elimina un pedido de premio temporal especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        bool DeletePedidoPremioTemporal(string NumeroPedido);

        /// <summary>
        /// Elimina un pedido de premio temporal especifico por numero, tipo query y id articulo.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="IdArticulo"></param>
        /// <param name="TipoQuery"></param>
        /// <returns></returns>
        bool DeletePedidoPremioTemporalSimple(string NumeroPedido, int IdArticulo, string TipoQuery);


        #region "METODOS DE RESERVA EN LINEA"

        /// <summary>
        /// Lista todos los pedidos en reserva en linea sin facturar una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidoEnReservaxCampanaxCatalogo(string Nit, string Campana, string Catalogo);

        /// <summary>
        /// Valida si existe un pedido borrador en SVDN.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidoBorradorSVDN(string Nit, string Campana);


        /// <summary>
        /// Lista todos los pedidos sin facturar una campaña x catalogo y como borrador para reservar.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidoSinFacturarxParaReservar(string Nit, string Campana, string Catalogo, string NumeroPedido);

        /// <summary>
        /// Lista la fecha de cierre de un pedido para la devolucion en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        PedidosClienteInfo ListFechaCierreDevolucion(string NumeroPedido);

        /// <summary>
        /// Lista todos los pedidos en reserva x campaña.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxPedidosReservados(string Campana);

        /// <summary>
        /// Lista todos los pedidos en reserva de una empresaria especifica.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxEmpresariaReservados(string Nit, string Campana);

        /// <summary>
        /// Lista un pedido de reserva en linea de la campaña actual.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        PedidosClienteInfo ListxGerenteZonaReservadosCPActual(string Nit);

        /// <summary>
        /// -Lista todos los pedidos en reserva guardados por una lider.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxGerenteZonaReservadosxLider(string Lider, string Campana);

        /// <summary>
        /// Reporte de pedidos digitados por servicio al cliente.
        /// </summary>
        /// <returns></returns>
        List<PedidosClienteInfo> ListxReportePedidosCCN();

        #endregion


        #region Desmanteladora
        bool UpdateEstadoDesmanteladoPedido(string NumeroPedido, string Nit, string Zona, string Usuario);
        #endregion

        /// <summary>
       /// obtiene un pedido de los pedidos de siesa por el numero
       /// </summary>
       /// <param name="NumeroPedido"></param>
       /// <returns></returns>
        PedidosClienteInfo ObtenerunPedidoSiesa(string NumeroPedido);

        /// <summary>
        /// obtiene un detalle pedido de los pedidos de siesa por el numero
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        PedidosDetallesSIESA_SVDNinfo ObtenerunPedidoDetalleSiesa(string NumeroPedido);
        
        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente. dependiendo de la bodega asigna el prefijo
        /// </summary>
        /// <param name="item"></param>
        string InsertBODEGAPREFIJO(PedidosClienteInfo item, string bodega);

         /// JUTA
        /// 
        /// <summary>
        /// Lista pedido preventa
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>      
        /// <returns></returns>
         PedidosClienteInfo ListxPedidoPreventa(string Nit, string Campana);
        
        /// <summary>
        /// Lista pedidos para guardado masivo
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
         List<PedidosClienteInfo> ListPedidosMasivo(string Campana);

        #endregion
    }
}

