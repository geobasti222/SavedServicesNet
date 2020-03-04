using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public delegate void OnPedidoProcesamientoEventHandler(PedidosClienteInfo item); //1) Crear Delegado encima de  para que lo vean todas las clases.

    public delegate void OnClientesProcesamientoEventHandler(ClienteInfo item); //1) Crear Delegado encima de  para que lo vean todas las clases.


    /// <summary>
    /// 
    /// </summary>
    
    public class PedidosClienteInfo
    {
        private string numero;
        /// <summary>
        /// 
        /// </summary>
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string mes;
        /// <summary>
        /// 
        /// </summary>
        public string Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        private DateTime fecha;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int anulado;
        /// <summary>
        /// 
        /// </summary>
        public int Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }

        private int espera;
        /// <summary>
        /// 
        /// </summary>
        public int Espera
        {
            get { return espera; }
            set { espera = value; }
        }

        private DateTime despacho;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Despacho
        {
            get { return despacho; }
            set { despacho = value; }
        }

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private decimal iva;
        /// <summary>
        /// 
        /// </summary>
        public decimal IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        private decimal valor;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private decimal descuento;
        /// <summary>
        /// 
        /// </summary>
        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        private DateTime fechacreacion;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCreacion
        {
            get { return fechacreacion; }
            set { fechacreacion = value; }
        }

        private string claveusuario;
        /// <summary>
        /// 
        /// </summary>
        public string ClaveUsuario
        {
            get { return claveusuario; }
            set { claveusuario = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private string codigonumeracion;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoNumeracion
        {
            get { return codigonumeracion; }
            set { codigonumeracion = value; }
        }

        private int transmitido;
        /// <summary>
        /// 
        /// </summary>
        public int Transmitido
        {
            get { return transmitido; }
            set { transmitido = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private string numeroenvio;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroEnvio
        {
            get { return numeroenvio; }
            set { numeroenvio = value; }
        }

        private decimal nofacturado;
        /// <summary>
        /// 
        /// </summary>
        public decimal NoFacturado
        {
            get { return nofacturado; }
            set { nofacturado = value; }
        }

        private int facturar;
        /// <summary>
        /// 
        /// </summary>
        public int Facturar
        {
            get { return facturar; }
            set { facturar = value; }
        }

        private string codtipo;
        /// <summary>
        /// 
        /// </summary>
        public string CodTipo
        {
            get { return codtipo; }
            set { codtipo = value; }
        }

        private string devol;
        /// <summary>
        /// 
        /// </summary>
        public string Devol
        {
            get { return devol; }
            set { devol = value; }
        }

        private string factura;
        /// <summary>
        /// 
        /// </summary>
        public string Factura
        {
            get { return factura; }
            set { factura = value; }
        }

        private string nombrevendedor;
        /// <summary>
        /// 
        /// </summary>
        public string NombreVendedor
        {
            get { return nombrevendedor; }
            set { nombrevendedor = value; }
        }

        private string nombreempresaria;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEmpresaria
        {
            get { return nombreempresaria; }
            set { nombreempresaria = value; }
        }

        private string nombrezona;
        /// <summary>
        /// 
        /// </summary>
        public string NombreZona
        {
            get { return nombrezona; }
            set { nombrezona = value; }
        }

        private int idestado;
        /// <summary>
        /// 
        /// </summary>
        public int IdEstado
        {
            get { return idestado; }
            set { idestado = value; }
        }

        private string nombreestado;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEstado
        {
            get { return nombreestado; }
            set { nombreestado = value; }
        }

        private int orden;
        /// <summary>
        /// 
        /// </summary>
        public int Orden
        {
            get { return orden; }
            set { orden = value; }
        }

        private bool procesado;
        /// <summary>
        /// 
        /// </summary>
        public bool Procesado
        {
            get { return procesado; }
            set { procesado = value; }
        }

        private decimal nivelestimado;
        /// <summary>
        /// 
        /// </summary>
        public decimal NivelServicioEstimado
        {
            get { return nivelestimado; }
            set { nivelestimado = value; }
        }

        private decimal nivelreal;
        /// <summary>
        /// 
        /// </summary>
        public decimal NivelServicioReal
        {
            get { return nivelreal; }
            set { nivelreal = value; }
        }

        private bool nivelservicioestado;
        /// <summary>
        /// 
        /// </summary>
        public bool NivelServicioEstado
        {
            get { return nivelservicioestado; }
            set { nivelservicioestado = value; }
        }

        private string nivelserviciotipo;
        /// <summary>
        /// 
        /// </summary>
        public string NivelServicioTipo
        {
            get { return nivelserviciotipo; }
            set { nivelserviciotipo = value; }
        }

        //----------------------------------
        //otras variables
        private int totalpedidosprocesados;
        /// <summary>
        /// 
        /// </summary>
        public int TotalPedidosProcesados
        {
            get { return totalpedidosprocesados; }
            set { totalpedidosprocesados = value; }
        }

        private int totalpedidosnoprocesados;
        /// <summary>
        /// 
        /// </summary>
        public int TotalPedidosNoProcesados
        {
            get { return totalpedidosnoprocesados; }
            set { totalpedidosnoprocesados = value; }
        }

        private int totalpedidos;
        /// <summary>
        /// 
        /// </summary>
        public int TotalPedidos
        {
            get { return totalpedidos; }
            set { totalpedidos = value; }
        }

        private int consecutivo;
        /// <summary>
        /// 
        /// </summary>
        public int Consecutivo
        {
            get { return consecutivo; }
            set { consecutivo = value; }
        }

        private bool terminoprocess;
        /// <summary>
        /// 
        /// </summary>
        public bool TerminoProcess
        {
            get { return terminoprocess; }
            set { terminoprocess = value; }
        }


        private int totalsicumplennivelservicio;
        /// <summary>
        /// 
        /// </summary>
        public int TotalSiCumplenNivelServicio
        {
            get { return totalsicumplennivelservicio; }
            set { totalsicumplennivelservicio = value; }
        }

        private int totalnocumplennivelservicio;
        /// <summary>
        /// 
        /// </summary>
        public int TotalNoCumplenNivelServicio
        {
            get { return totalnocumplennivelservicio; }
            set { totalnocumplennivelservicio = value; }
        }

        private int totalsicumplenreglas;
        /// <summary>
        /// 
        /// </summary>
        public int TotalSiCumplenReglas
        {
            get { return totalsicumplenreglas; }
            set { totalsicumplenreglas = value; }
        }

        private int totalnocumplenreglas;
        /// <summary>
        /// 
        /// </summary>
        public int TotalNoCumplenReglas
        {
            get { return totalnocumplenreglas; }
            set { totalnocumplenreglas = value; }
        }

        private int totalsicumpleninventario;
        /// <summary>
        /// 
        /// </summary>
        public int TotalSiCumplenInventario
        {
            get { return totalsicumpleninventario; }
            set { totalsicumpleninventario = value; }
        }

        private int totalnocumpleninventario;
        /// <summary>
        /// 
        /// </summary>
        public int TotalNoCumplenInventario
        {
            get { return totalnocumpleninventario; }
            set { totalnocumpleninventario = value; }
        }


        private decimal valorpremio;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPremio
        {
            get { return valorpremio; }
            set { valorpremio = value; }
        }

        private decimal valorpremioniveles;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPremioNiveles
        {
            get { return valorpremioniveles; }
            set { valorpremioniveles = value; }
        }


        private decimal valorpremionivelessep;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPremioNivelesSep
        {
            get { return valorpremionivelessep; }
            set { valorpremionivelessep = value; }
        }

        private DateTime fechaultimamodificacion;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaUltimaModificacion
        {
            get { return fechaultimamodificacion; }
            set { fechaultimamodificacion = value; }
        }

        private int idarticulopremio;
        /// <summary>
        /// 
        /// </summary>
        public int IdArticuloPremio
        {
            get { return idarticulopremio; }
            set { idarticulopremio = value; }
        }

        private string tipoquery;
        /// <summary>
        /// 
        /// </summary>
        public string TipoQuery
        {
            get { return tipoquery; }
            set { tipoquery = value; }
        }

        private decimal valoriva;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorIva
        {
            get { return valoriva; }
            set { valoriva = value; }
        }

        private string mailgroup;
        /// <summary>
        /// 
        /// </summary>
        public string Mailgroup
        {
            get { return mailgroup; }
            set { mailgroup = value; }
        }

        private bool enproduccion;
        /// <summary>
        /// 
        /// </summary>
        public bool EnProduccion
        {
            get { return enproduccion; }
            set { enproduccion = value; }
        }


        private decimal ivapreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal IVAPrecioCat
        {
            get { return ivapreciocatalogo; }
            set { ivapreciocatalogo = value; }
        }

        private decimal valorpreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPrecioCat
        {
            get { return valorpreciocatalogo; }
            set { valorpreciocatalogo = value; }
        }

        private string codigo;
        /// <summary>
        /// 
        /// </summary>
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string grupocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public string GrupoCatalogo
        {
            get { return grupocatalogo; }
            set { grupocatalogo = value; }
        }


        private decimal totalpreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrecioCatalogo
        {
            get { return ValorPrecioCat + IVAPrecioCat; }
            set { totalpreciocatalogo = value; }
        }

        private bool generapremios;
        /// <summary>
        /// 
        /// </summary>
        public bool GeneraPremios
        {
            get { return generapremios; }
            set { generapremios = value; }
        }


        //------------------------------------------------

        private decimal valortotalneto;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorTotalNeto
        {
            get { return valortotalneto; }
            set { valortotalneto = value; }
        }


        private decimal valortotalivaflete;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorTotalIvaFlete
        {
            get { return valortotalivaflete; }
            set { valortotalivaflete = value; }
        }


        private decimal valortotalivafletefactura;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorTotalIvaFleteFactura
        {
            get { return valortotalivafletefactura; }
            set { valortotalivafletefactura = value; }
        }


        private string descripcionreferencia;
        /// <summary>
        /// 
        /// </summary>
        public string DescripcionReferencia
        {
            get { return descripcionreferencia; }
            set { descripcionreferencia = value; }
        }

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private decimal cantidadpedida;
        /// <summary>
        /// 
        /// </summary>
        public decimal CantidadPedida
        {
            get { return cantidadpedida; }
            set { cantidadpedida = value; }
        }

        private string codigototal;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoTotal
        {
            get { return codigototal; }
            set { codigototal = value; }
        }

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos; }
            set { ccostos = value; }
        }


        private bool guardarauditoria;
        /// <summary>
        /// 
        /// </summary>
        public bool GuardarAuditoria
        {
            get { return guardarauditoria; }
            set { guardarauditoria = value; }
        }

        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }


        //---------------------------------------


        private string direccionentregapedido;
        /// <summary>
        /// 
        /// </summary>
        public string DireccionEntregaPedido
        {
            get { return direccionentregapedido; }
            set { direccionentregapedido = value; }
        }


        private string codigociudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCiudad
        {
            get { return codigociudad; }
            set { codigociudad = value; }
        }

        private string nombreciudad;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiudad
        {
            get { return nombreciudad; }
            set { nombreciudad = value; }
        }

        private string telefonoprincipal;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoPrincipal
        {
            get { return telefonoprincipal; }
            set { telefonoprincipal = value; }
        }

        private string email;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string celular;
        /// <summary>
        /// 
        /// </summary>
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        private string sector;
        /// <summary>
        /// 
        /// </summary>
        public string Sector
        {
            get { return sector; }
            set { sector = value; }
        }

        private string referido;
        /// <summary>
        /// 
        /// </summary>
        public string Referido
        {
            get { return referido; }
            set { referido = value; }
        }

        private DateTime ultimamodificacionempresaria;
        /// <summary>
        /// 
        /// </summary>
        public DateTime UltimaModificacionEmpresaria
        {
            get { return ultimamodificacionempresaria; }
            set { ultimamodificacionempresaria = value; }
        }

        private int idestadocliente;
        /// <summary>
        /// 
        /// </summary>
        public int IdEstadoCliente
        {
            get { return idestadocliente; }
            set { idestadocliente = value; }
        }

        private string estadocliente;
        /// <summary>
        /// 
        /// </summary>
        public string EstadoCliente
        {
            get { return estadocliente; }
            set { estadocliente = value; }
        }

        private int idestadopedido;
        /// <summary>
        /// 
        /// </summary>
        public int IdEstadoPedido
        {
            get { return idestadopedido; }
            set { idestadopedido = value; }
        }

        private string estadopedido;
        /// <summary>
        /// 
        /// </summary>
        public string EstadoPedido
        {
            get { return estadopedido; }
            set { estadopedido = value; }
        }

        private string idvendedor;
        /// <summary>
        /// 
        /// </summary>
        public string IdVendedor
        {
            get { return idvendedor; }
            set { idvendedor = value; }
        }

        private string cedulavendedor;
        /// <summary>
        /// 
        /// </summary>
        public string CedulaVendedor
        {
            get { return cedulavendedor; }
            set { cedulavendedor = value; }
        }


        private string numerofactura;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroFactura
        {
            get { return numerofactura; }
            set { numerofactura = value; }
        }

        private int anexo;
        /// <summary>
        /// 
        /// </summary>
        public int Anexo
        {
            get { return anexo; }
            set { anexo = value; }
        }

        private bool procesadoclientehistorico;
        /// <summary>
        /// 
        /// </summary>
        public bool ProcesadoClienteHistorico
        {
            get { return procesadoclientehistorico; }
            set { procesadoclientehistorico = value; }
        }

        private string idlider;
        /// <summary>
        /// 
        /// </summary>
        public string IdLider
        {
            get { return idlider; }
            set { idlider = value; }
        }

        private decimal saldo;
        /// <summary>
        /// 
        /// </summary>
        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }


        private string numerofac;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroFac
        {
            get { return numerofac; }
            set { numerofac = value; }
        }

        private string idcodigocorto;
        /// <summary>
        /// 
        /// </summary>
        public string IdCodigoCorto
        {
            get { return idcodigocorto; }
            set { idcodigocorto = value; }
        }


        private bool reserva;
        /// <summary>
        /// 
        /// </summary>
        public bool Reserva
        {
            get { return reserva; }
            set { reserva = value; }
        }

        private bool borrador;
        /// <summary>
        /// 
        /// </summary>
        public bool Borrador
        {
            get { return borrador; }
            set { borrador = value; }
        }

        private DateTime fechacierreborrador;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCierreBorrador
        {
            get { return fechacierreborrador; }
            set { fechacierreborrador = value; }
        }

        private DateTime fechacierrereserva;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCierreReserva
        {
            get { return fechacierrereserva; }
            set { fechacierrereserva = value; }
        }

        private DateTime fechacierrereservareal;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCierreReservaReal
        {
            get { return fechacierrereservareal; }
            set { fechacierrereservareal = value; }
        }

        private string portal;
        /// <summary>
        /// 
        /// </summary>
        public string Portal
        {
            get { return portal; }
            set { portal = value; }
        }

        private string telefonodos;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoDos
        {
            get { return telefonodos; }
            set { telefonodos = value; }
        }

        private DateTime fechaingresocliente;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaIngresoCliente
        {
            get { return fechaingresocliente; }
            set { fechaingresocliente = value; }
        }

        private string celulardos;
        /// <summary>
        /// 
        /// </summary>
        public string CelularDos
        {
            get { return celulardos; }
            set { celulardos = value; }
        }

        private string clasificacioncliente;
        /// <summary>
        /// 
        /// </summary>
        public string ClasificacionCliente
        {
            get { return clasificacioncliente; }
            set { clasificacioncliente = value; }
        }

        private string clientecreadopor;
        /// <summary>
        /// 
        /// </summary>
        public string ClienteCreadoPor
        {
            get { return clientecreadopor; }
            set { clientecreadopor = value; }
        }

        private int tipoenvio;
        /// <summary>
        /// 
        /// </summary>
        public int TipoEnvio
        {
            get { return tipoenvio; }
            set { tipoenvio = value; }
        }

        private string ciudaddespacho;
        /// <summary>
        /// 
        /// </summary>
        public string CiudadDespacho
        {
            get { return ciudaddespacho; }
            set { ciudaddespacho = value; }
        }

        private bool facturacionsemanal;
        /// <summary>
        /// 
        /// </summary>
        public bool FacturacionSemanal
        {
            get { return facturacionsemanal; }
            set { facturacionsemanal = value; }
        }

        private string usuariodigito;
        /// <summary>
        /// 
        /// </summary>
        public string UsuarioDigito
        {
            get { return usuariodigito; }
            set { usuariodigito = value; }
        }

        private int cupo_asignado;
        /// <summary>
        /// 
        /// </summary>
        public int Cupo_asignado
        {
            get { return cupo_asignado; }
            set { cupo_asignado = value; }
        }

        private string claseventa;
        /// <summary>
        /// 
        /// </summary>  
        public string Claseventa
        {
            get { return claseventa; }
            set { claseventa = value; }
        }

        private string grupouser;
        /// <summary>
        /// 
        /// </summary>
        public string GrupoUser
        {
            get { return grupouser; }
            set { grupouser = value; }
        }

      
    
        #region campor motivos de anulacion

        //INICIO GAVL  
        private DateTime _fechaanulacion;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaAnulacion
        {
            get { return _fechaanulacion; }
            set { _fechaanulacion = value; }
        }

        private string _motivoAnulcion;
        /// <summary>
        /// 
        /// </summary>
        public string MotivoAnulacion
        {
            get { return _motivoAnulcion; }
            set { _motivoAnulcion = value; }
        }

        private string _descripcionanulcion;
        /// <summary>
        /// 
        /// </summary>
        public string DescripcionAnulacion
        {
            get { return _descripcionanulcion; }
            set { _descripcionanulcion = value; }
        }

        private string _asistente;
        /// <summary>
        /// 
        /// </summary>
        public string Asistente
        {
            get { return _asistente; }
            set { _asistente = value; }
        }

        private string _nombreanulo;
        /// <summary>
        /// 
        /// </summary>
        public string NombreAnulo
        {
            get { return _nombreanulo; }
            set { _nombreanulo = value; }
        }

        private bool excentoiva;
        /// <summary>
        /// 
        /// </summary>
        public bool ExcentoIVA
        {
            get { return excentoiva; }
            set { excentoiva = value; }
        }

        private string codciudadcliente;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudadCliente
        {
            get { return codciudadcliente; }
            set { codciudadcliente = value; }
        }

        private bool oktransencabezadopedido;
        /// <summary>
        /// 
        /// </summary>
        public bool okTransEncabezadoPedido
        {
            get { return oktransencabezadopedido; }
            set { oktransencabezadopedido = value; }
        }

        private bool oktransdetallepedido;
        /// <summary>
        /// 
        /// </summary>
        public bool okTransDetallePedido
        {
            get { return oktransdetallepedido; }
            set { oktransdetallepedido = value; }
        }

        private int puntosusar;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosUsar
        {
            get { return puntosusar; }
            set { puntosusar = value; }
        }

        //OJO MRG: SI RECIBE UN DECIMAL EN UN INT SE REVIENTA EL ENVIO AL API. LAS PROPIEDADES DEBEN SER DEL TIPO QUE SE ENVIAR DESDE ANGULAR.
        private decimal totalpuntospedido;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPuntosPedido
        {
            get { return totalpuntospedido; }
            set { totalpuntospedido = value; }
        }

        private string guia;
        /// <summary>
        /// 
        /// </summary>
        public string Guia
        {
            get { return guia; }
            set { guia = value; }
        }
        private string numerodespacho;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroDespacho
        {
            get { return numerodespacho; }
            set { numerodespacho = value; }
        }

        private bool pagarfletepuntos;
        /// <summary>
        /// 
        /// </summary>
        public bool PagarFletePuntos
        {
            get { return pagarfletepuntos; }
            set { pagarfletepuntos = value; }
        }
      

        public virtual Error Error
        {
            get;
            set;
        }
        #endregion

    }
}
