namespace Application.Enterprise.Business
{
    using Application.Enterprise.CommonObjects.Interfaces;
    using Application.Enterprise.CommonObjects;
    using Application.Enterprise.Data;
    using System;
    using System.Collections.Generic;

    public class PuntosBo : IPuntos
    {
        private PuntosDao module;

        public PuntosBo()
        {
            this.module = new PuntosDao();
        }

        public PuntosBo(string databaseName)
        {
            this.module = new PuntosDao(databaseName);
        }

        public void actualizarDetalleGananciaPuntos(string idpedido, string cedula, int puntos)
        {
            this.module.actualizarDetalleGananciaPuntos(idpedido, cedula, puntos);
        }

        public void actualizarEncabezadoPuntosCliente(string cedula)
        {
            this.module.actualizarEncabezadoPuntosCliente(cedula);
        }

        public void actualizarParametrocampaniasperderpuntos(string valor)
        {
            this.module.actualizarParametrocampaniasperderpuntos(valor);
        }

        public void actualizarParametropedidominimoganarpuntos(string valor)
        {
            this.module.actualizarParametropedidominimoganarpuntos(valor);
        }

        public void actualizarParametrovalorpuntos(string valor)
        {
            this.module.actualizarParametrovalorpuntos(valor);
        }

        public void actualizarpuntosEfectivo(int puntosganados, int puntosgastados, string cedula)
        {
            this.module.actualizarpuntosEfectivo(puntosganados, puntosgastados, cedula);
        }

        public void actualizarpuntosPedido(int puntosganados, int puntosgastados, string cedula)
        {
            this.module.actualizarpuntosPedido(puntosganados, puntosgastados, cedula);
        }

        public void actualizarRegla(PuntosInfo punto)
        {
            this.module.actualizarRegla(punto);
        }

        public void agregarConcepto(string concepto)
        {
            this.module.agregarConcepto(concepto);
        }

        public void agregarDescuento100(string idPedido)
        {
            this.module.agregarDescuento100(idPedido);
        }

        public void agregarDescuentoPuntos(string IdPedido, decimal totalDescuentoPuntos)
        {
            this.module.agregarDescuentoPuntos(IdPedido, totalDescuentoPuntos);
        }

        public void agregarNivelPuntos(string dolares, string punto)
        {
            this.module.agregarNivelPuntos(dolares, punto);
        }

        public void agregarNivelPuntosCantidad(string cantidad, string punto)
        {
            this.module.agregarNivelPuntosCantidad(cantidad, punto);
        }

        public void borrarPuntosAnulados()
        {
            this.module.borrarPuntosAnulados();
        }

        public void borrarPuntosDevol()
        {
            this.module.borrarPuntosDevol();
        }

        public void borrarPuntosEmpresariasInactivas()
        {
            this.module.borrarPuntosEmpresariasInactivas();
        }

        public void efectuarPuntosPagos()
        {
            this.module.efectuarPuntosPagos();
        }

        public string ejecutarConsulta(string consulta) => 
            this.module.ejecutarConsulta(consulta);

        public void eliminarCatalogo(string catalogo)
        {
            this.module.eliminarCatalogo(catalogo);
        }

        public void eliminarNivelPuntos(string regla)
        {
            this.module.eliminarNivelPuntos(regla);
        }

        public void eliminarNivelPuntosCantidad(string regla)
        {
            this.module.eliminarNivelPuntosCantidad(regla);
        }

        public void eliminarRegla(int valorunidadesa, int categoria_regla)
        {
            this.module.eliminarRegla(valorunidadesa, categoria_regla);
        }

        public int getcantdiasparaReprogramacion() => 
            this.module.getcantdiasparaReprogramacion();

        public decimal getCantidadCampanasInactiva() => 
            this.module.getCantidadCampanasInactiva();

        public int getcantidadpuntoporCategoria(int unidad_a, int regla) => 
            this.module.getcantidadpuntoporCategoria(unidad_a, regla);

        public int getcantRegistroxCatalogo(string catalogo) => 
            this.module.getcantRegistroxCatalogo(catalogo);

        public List<PLUInfo> getCatalogo(string catalogo) => 
            this.module.getCatalogo(catalogo);

        public List<PuntosInfo> getCatalogoActualYPreventa() => 
            this.module.getCatalogoActualYPreventa();

        public List<PuntosInfo> getcategoriasReglasPuntos() => 
            this.module.getcategoriasReglasPuntos();

        public string getClaveLider(string nit) => 
            this.module.getClaveLider(nit);

        public List<PuntosInfo> getConceptos() => 
            this.module.getConceptos();

        public PuntosInfo getdetallepuntoporCategoria(int unidad_a, int regla) => 
            this.module.getdetallepuntoporCategoria(unidad_a, regla);

        public List<PuntosInfo> getDetallePuntosxPedido(string numero) => 
            this.module.getDetallePuntosxPedido(numero);

        public List<PuntosInfo> getEstadosEmpresaria() => 
            this.module.getEstadosEmpresaria();

        public List<PuntosInfo> getListaPedidosAnulados() => 
            this.module.getListaPedidosAnulados();

        public List<PuntosInfo> getListaPedidosDevueltos() => 
            this.module.getListaPedidosDevueltos();

        public List<PuntosInfo> getListaPedidosPagos() => 
            this.module.getListaPedidosPagos();

        public List<PuntosInfo> getListaPuntosEmpresariasInctivas() => 
            this.module.getListaPuntosEmpresariasInctivas();

        public List<PuntosInfo> getNivelesPuntos() => 
            this.module.getNivelesPuntos();

        public List<PuntosInfo> getNivelesPuntosCantidad() => 
            this.module.getNivelesPuntosCantidad();

        public string getPedidoActivo(string nit) => 
            this.module.getPedidoActivo(nit);

        public decimal getPedidoMinimoGanarPuntos() => 
            this.module.getPedidoMinimoGanarPuntos();

        public int getPrecioPuntosProducto(string id_corto, string campana) => 
            this.module.getPrecioPuntosProducto(id_corto, campana);

        public int getPuntosEfectivoEmpresaria(string nit) => 
            this.module.getPuntosEfectivoEmpresaria(nit);

        public int getPuntosGanadosxPedido(string nit, string idpedido) => 
            this.module.getPuntosGanadosxPedido(nit, idpedido);

        public PuntosInfo getpuntosganarxestadoxempresaria(string nit) => 
            this.module.getpuntosganarxestadoxempresaria(nit);

        public int getPuntosGanarXProducto(string id_corto) => 
            this.module.getPuntosGanarXProducto(id_corto);

        public List<PuntosInfo> getPuntosxPedido(string nit, string idpedido) => 
            this.module.getPuntosxPedido(nit, idpedido);

        public PuntosInfo getSiguienteNivelPuntos(decimal monto) => 
            this.module.getSiguienteNivelPuntos(monto);

        public List<PuntosInfo> gettodasCampanasCod() => 
            this.module.gettodasCampanasCod();

        public List<PuntosInfo> getTodaslasreglasPuntosporCategoria(int categoria) => 
            this.module.getTodaslasreglasPuntosporCategoria(categoria);

        public List<PuntosInfo> getTodosMovimientoEncabezados() => 
            this.module.getTodosMovimientoEncabezados();

        public List<PuntosInfo> getTodosMovimientoPuntosPorEmpresaria(string nit) => 
            this.module.getTodosMovimientoPuntosPorEmpresaria(nit);

        public List<PuntosInfo> getTodosMovimientoPuntosPorEmpresariayCampana(string nit, string campana) => 
            this.module.getTodosMovimientoPuntosPorEmpresariayCampana(nit, campana);

        public PuntosInfo getTotalPuntosPorEmpresaria(string nit) => 
            this.module.getTotalPuntosPorEmpresaria(nit);

        public decimal getvalorPuntoEnSoles() => 
            this.module.getvalorPuntoEnSoles();

        public void insertarDetalleGananciaPuntos(string idpedido, string cedula, int puntos, decimal monto, int portal)
        {
            this.module.insertarDetalleGananciaPuntos(idpedido, cedula, puntos, monto, portal);
        }

        public void insertarDetalleGastoPuntos(string idpedido, string cedula, int puntos)
        {
            this.module.insertarDetalleGastoPuntos(idpedido, cedula, puntos);
        }

        public void insertarGastoFlete(string idpedido, string cedula, int puntos)
        {
            this.module.insertarGastoFlete(idpedido, cedula, puntos);
        }

        public void insertarMovimientoPuntosExpirados(string cedula)
        {
            this.module.insertarMovimientoPuntosExpirados(cedula);
        }

        public void insertarMovimientoPuntosGenerico(string idpedido, string cedula, int puntos, string tipo, string concepto)
        {
            this.module.insertarMovimientoPuntosGenerico(idpedido, cedula, puntos, tipo, concepto);
        }

        public void insertarNuevaRegla(PuntosInfo punto)
        {
            this.module.insertarNuevaRegla(punto);
        }

        public List<PuntosInfo> listarCatalogosTodos() => 
            this.module.listarCatalogosTodos();
    }
}

