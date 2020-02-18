namespace Application.Enterprise.CommonObjects.Interfaces
{
    using Application.Enterprise.CommonObjects;
    using System;
    using System.Collections.Generic;

    public interface IPuntos
    {
        void actualizarDetalleGananciaPuntos(string idpedido, string cedula, int puntos);
        void actualizarEncabezadoPuntosCliente(string cedula);
        void actualizarParametrocampaniasperderpuntos(string valor);
        void actualizarParametropedidominimoganarpuntos(string valor);
        void actualizarParametrovalorpuntos(string valor);
        void actualizarpuntosEfectivo(int puntosganados, int puntosgastados, string cedula);
        void actualizarpuntosPedido(int puntosganados, int puntosgastados, string cedula);
        void actualizarRegla(PuntosInfo punto);
        void agregarConcepto(string concepto);
        void agregarDescuento100(string idPedido);
        void agregarDescuentoPuntos(string IdPedido, decimal totalDescuentoPuntos);
        void agregarNivelPuntos(string dolares, string punto);
        void agregarNivelPuntosCantidad(string cantidad, string punto);
        void borrarPuntosAnulados();
        void borrarPuntosDevol();
        void borrarPuntosEmpresariasInactivas();
        void efectuarPuntosPagos();
        string ejecutarConsulta(string consulta);
        void eliminarNivelPuntos(string regla);
        void eliminarNivelPuntosCantidad(string regla);
        void eliminarRegla(int valorunidadesa, int categoria_regla);
        int getcantdiasparaReprogramacion();
        decimal getCantidadCampanasInactiva();
        int getcantidadpuntoporCategoria(int unidad_a, int regla);
        int getcantRegistroxCatalogo(string catalogo);
        List<PLUInfo> getCatalogo(string catalogo);
        List<PuntosInfo> getCatalogoActualYPreventa();
        List<PuntosInfo> getcategoriasReglasPuntos();
        string getClaveLider(string nit);
        List<PuntosInfo> getConceptos();
        PuntosInfo getdetallepuntoporCategoria(int unidad_a, int regla);
        List<PuntosInfo> getDetallePuntosxPedido(string numero);
        List<PuntosInfo> getEstadosEmpresaria();
        List<PuntosInfo> getListaPedidosAnulados();
        List<PuntosInfo> getListaPedidosDevueltos();
        List<PuntosInfo> getListaPedidosPagos();
        List<PuntosInfo> getListaPuntosEmpresariasInctivas();
        List<PuntosInfo> getNivelesPuntos();
        List<PuntosInfo> getNivelesPuntosCantidad();
        string getPedidoActivo(string nit);
        decimal getPedidoMinimoGanarPuntos();
        int getPrecioPuntosProducto(string id_corto, string campana);
        int getPuntosEfectivoEmpresaria(string nit);
        int getPuntosGanadosxPedido(string nit, string idpedido);
        PuntosInfo getpuntosganarxestadoxempresaria(string nit);
        int getPuntosGanarXProducto(string id_corto);
        List<PuntosInfo> getPuntosxPedido(string nit, string idpedido);
        PuntosInfo getSiguienteNivelPuntos(decimal monto);
        List<PuntosInfo> gettodasCampanasCod();
        List<PuntosInfo> getTodaslasreglasPuntosporCategoria(int categoria);
        List<PuntosInfo> getTodosMovimientoEncabezados();
        List<PuntosInfo> getTodosMovimientoPuntosPorEmpresaria(string nit);
        List<PuntosInfo> getTodosMovimientoPuntosPorEmpresariayCampana(string nit, string campana);
        decimal getvalorPuntoEnSoles();
        void insertarDetalleGananciaPuntos(string idpedido, string cedula, int puntos, decimal monto, int portal);
        void insertarDetalleGastoPuntos(string idpedido, string cedula, int puntos);
        void insertarGastoFlete(string idpedido, string cedula, int puntos);
        void insertarMovimientoPuntosGenerico(string idpedido, string cedula, int puntos, string tipo, string concepto);
        void insertarNuevaRegla(PuntosInfo punto);
        List<PuntosInfo> listarCatalogosTodos();
    }
}

