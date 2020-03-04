using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ClienteInfo
    {

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit; }
            set { nit = value; }
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

        private string zonadesc;
        /// <summary>
        /// 
        /// </summary>
        public string ZonaDesc
        {
            get { return zonadesc; }
            set { zonadesc = value; }
        }

        private string razonsocial;
        /// <summary>
        /// 
        /// </summary>
        public string RazonSocial
        {
            get { return razonsocial; }
            set { razonsocial = value; }
        }

        private string contacto;
        /// <summary>
        /// 
        /// </summary>
        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        private string direccionresidencia;
        /// <summary>
        /// 
        /// </summary>
        public string DireccionResidencia
        {
            get { return direccionresidencia; }
            set { direccionresidencia = value; }
        }

        private string direccionpedidos;
        /// <summary>
        /// 
        /// </summary>
        public string DireccionPedidos
        {
            get { return direccionpedidos; }
            set { direccionpedidos = value; }
        }

        private string ciudad;
        /// <summary>
        /// 
        /// </summary>
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        private string telefono1;
        /// <summary>
        /// 
        /// </summary>
        public string Telefono1
        {
            get { return telefono1; }
            set { telefono1 = value; }
        }

        private string fax;
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
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

        private int plazocredito;
        /// <summary>
        /// 
        /// </summary>
        public int PlazoCredito
        {
            get { return plazocredito; }
            set { plazocredito = value; }
        }

        private int cupoasignado;
        /// <summary>
        /// 
        /// </summary>
        public int CupoAsignado
        {
            get { return cupoasignado; }
            set { cupoasignado = value; }
        }

        private decimal precioventa;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioVenta
        {
            get { return precioventa; }
            set { precioventa = value; }
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

        private int activo;
        /// <summary>
        /// 
        /// </summary>
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
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

        private string vendedornombre;
        /// <summary>
        /// 
        /// </summary>
        public string VendedorNombre
        {
            get { return vendedornombre; }
            set { vendedornombre = value; }
        }

        private int grancontribuyen;
        /// <summary>
        /// 
        /// </summary>
        public int Grancontribuyen
        {
            get { return grancontribuyen; }
            set { grancontribuyen = value; }
        }

        private int retenedorfuente;
        /// <summary>
        /// 
        /// </summary>
        public int RetenedorFuente
        {
            get { return retenedorfuente; }
            set { retenedorfuente = value; }
        }

        private int retenedorica;
        /// <summary>
        /// 
        /// </summary>
        public int RetenedorIca
        {
            get { return retenedorica; }
            set { retenedorica = value; }
        }

        private string cuentacontable;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaContable
        {
            get { return cuentacontable; }
            set { cuentacontable = value; }
        }

        private string localizacion;
        /// <summary>
        /// 
        /// </summary>
        public string Localizacion
        {
            get { return localizacion; }
            set { localizacion = value; }
        }

        private string clasificacion;
        /// <summary>
        /// 
        /// </summary>
        public string Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }

        private string persona;
        /// <summary>
        /// 
        /// </summary>
        public string Persona
        {
            get { return persona; }
            set { persona = value; }
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

        private DateTime fechanacimiento;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaNacimiento
        {
            get { return fechanacimiento; }
            set { fechanacimiento = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
        }

        private string categoria;
        /// <summary>
        /// 
        /// </summary>
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private string sexo;
        /// <summary>
        /// 
        /// </summary>
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private int cuentacrm;
        /// <summary>
        /// 
        /// </summary>
        public int CuentaCRM
        {
            get { return cuentacrm; }
            set { cuentacrm = value; }
        }

        private int tipodocumento;
        /// <summary>
        /// 
        /// </summary>
        public int TipoDocumento
        {
            get { return tipodocumento; }
            set { tipodocumento = value; }
        }

        private string nombretipodocumento;
        /// <summary>
        /// 
        /// </summary>
        public string NombreTipoDocumento
        {
            get { return nombretipodocumento; }
            set { nombretipodocumento = value; }
        }

        private string apellido1;
        /// <summary>
        /// 
        /// </summary>
        public string Apellido1
        {
            get { return apellido1; }
            set { apellido1 = value; }
        }

        private string apellido2;
        /// <summary>
        /// 
        /// </summary>
        public string Apellido2
        {
            get { return apellido2; }
            set { apellido2 = value; }
        }

        private string nombre1;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre1
        {
            get { return nombre1; }
            set { nombre1 = value; }
        }

        private string nombre2;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre2
        {
            get { return nombre2; }
            set { nombre2 = value; }
        }

        private string dv;
        /// <summary>
        /// 
        /// </summary>
        public string DV
        {
            get { return dv; }
            set { dv = value; }
        }

        private int simplificado;
        /// <summary>
        /// 
        /// </summary>
        public int Simplificado
        {
            get { return simplificado; }
            set { simplificado = value; }
        }

        private int autoretenedor;
        /// <summary>
        /// 
        /// </summary>
        public int Autoretenedor
        {
            get { return autoretenedor; }
            set { autoretenedor = value; }
        }

        private string codmediosmagneticos;
        /// <summary>
        /// 
        /// </summary>
        public string CodMediosMagneticos
        {
            get { return codmediosmagneticos; }
            set { codmediosmagneticos = value; }
        }

        private decimal desmantelados;
        /// <summary>
        /// 
        /// </summary>
        public decimal Desmantelados
        {
            get { return desmantelados; }
            set { desmantelados = value; }
        }

        private string telefono2;
        /// <summary>
        /// 
        /// </summary>
        public string Telefono2
        {
            get { return telefono2; }
            set { telefono2 = value; }
        }

        private DateTime fechaingreso;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaIngreso
        {
            get { return fechaingreso; }
            set { fechaingreso = value; }
        }

        private DateTime ultimamodificacion;
        /// <summary>
        /// 
        /// </summary>
        public DateTime UltimaModificacion
        {
            get { return ultimamodificacion; }
            set { ultimamodificacion = value; }
        }

        private int suspendercredito;
        /// <summary>
        /// 
        /// </summary>
        public int SuspenderCredito
        {
            get { return suspendercredito; }
            set { suspendercredito = value; }
        }

        private int tipotercero;
        /// <summary>
        /// 
        /// </summary>
        public int TipoTercero
        {
            get { return tipotercero; }
            set { tipotercero = value; }
        }

        private string barrio;
        /// <summary>
        /// 
        /// </summary>
        public string Barrio
        {
            get { return barrio; }
            set { barrio = value; }
        }

        private string codlista;
        /// <summary>
        /// 
        /// </summary>
        public string CodLista
        {
            get { return codlista; }
            set { codlista = value; }
        }

        private string fpago;
        /// <summary>
        /// 
        /// </summary>
        public string Fpago
        {
            get { return fpago; }
            set { fpago = value; }
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

        private string celular1;
        /// <summary>
        /// 
        /// </summary>
        public string Celular1
        {
            get { return celular1; }
            set { celular1 = value; }
        }

        private string celular2;
        /// <summary>
        /// 
        /// </summary>
        public string Celular2
        {
            get { return celular2; }
            set { celular2 = value; }
        }

        private int idestadoscliente;
        /// <summary>
        /// 
        /// </summary>
        public int IdEstadosCliente
        {
            get { return idestadoscliente; }
            set { idestadoscliente = value; }
        }

        private string nombreestadoscliente;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEstadosCliente
        {
            get { return nombreestadoscliente; }
            set { nombreestadoscliente = value; }
        }

        private string coddepartamento;
        /// <summary>
        /// 
        /// </summary>
        public string CodDepartamento
        {
            get { return coddepartamento; }
            set { coddepartamento = value; }
        }

        private string departamento;
        /// <summary>
        /// 
        /// </summary>
        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        private string codpais;
        /// <summary>
        /// 
        /// </summary>
        public string CodPais
        {
            get { return codpais; }
            set { codpais = value; }
        }

        private string pais;
        /// <summary>
        /// 
        /// </summary>
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        private string codsector;
        /// <summary>
        /// 
        /// </summary>
        public string CodSector
        {
            get { return codsector; }
            set { codsector = value; }
        }

        private string idreferidor;
        /// <summary>
        /// 
        /// </summary>
        public string IdReferidor
        {
            get { return idreferidor; }
            set { idreferidor = value; }
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

        private bool terminoprocess;
        /// <summary>
        /// 
        /// </summary>
        public bool TerminoProcess
        {
            get { return terminoprocess; }
            set { terminoprocess = value; }
        }


        private int totalclientes;
        /// <summary>
        /// 
        /// </summary>
        public int TotalClientes
        {
            get { return totalclientes; }
            set { totalclientes = value; }
        }

        private int codigobarrio;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoBarrio
        {
            get { return codigobarrio; }
            set { codigobarrio = value; }
        }

        private string nombrebarrio;
        /// <summary>
        /// 
        /// </summary>
        public string NombreBarrio
        {
            get { return nombrebarrio; }
            set { nombrebarrio = value; }
        }

        private int codigociudad2;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoCiudad2
        {
            get { return codigociudad2; }
            set { codigociudad2 = value; }
        }

        private string nombreciudad2;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiudad2
        {
            get { return nombreciudad2; }
            set { nombreciudad2 = value; }
        }

        private int codigoregional;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoRegional
        {
            get { return codigoregional; }
            set { codigoregional = value; }
        }

        private string nombreregional;
        /// <summary>
        /// 
        /// </summary>
        public string NombreRegional
        {
            get { return nombreregional; }
            set { nombreregional = value; }
        }


        private string numeropedido;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroPedido
        {
            get
            {
                string strnumeropedido = "";
                if (numeropedido != null)
                {
                    strnumeropedido = numeropedido;
                }
                else
                {
                    strnumeropedido = "";
                }

                return strnumeropedido;
            }
            set { numeropedido = value; }
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


        private bool guardarauditoria;
        /// <summary>
        /// 
        /// </summary>
        public bool GuardarAuditoria
        {
            get { return guardarauditoria; }
            set { guardarauditoria = value; }
        }

        private int iddistribuidor;
        /// <summary>
        /// 
        /// </summary>
        public int IdDistribuidor
        {
            get { return iddistribuidor; }
            set { iddistribuidor = value; }
        }

        private string documentodistribuidor;
        /// <summary>
        /// 
        /// </summary>
        public string DocumentoDistribuidor
        {
            get { return documentodistribuidor; }
            set { documentodistribuidor = value; }
        }

        private string cxv_id_anterior;

        public string Cxv_Id_Anterior
        {
            get { return cxv_id_anterior; }
            set { cxv_id_anterior = value; }
        }

        private string cxv_nombre_anterior;

        public string Cxv_Nombre_Anterior
        {
            get { return cxv_nombre_anterior; }
            set { cxv_nombre_anterior = value; }
        }

        private string cxv_id_actual;

        public string Cxv_Id_Actual
        {
            get { return cxv_id_actual; }
            set { cxv_id_actual = value; }
        }

        private string cxv_nombre_actual;

        public string Cxv_Nombre_Actual
        {
            get { return cxv_nombre_actual; }
            set { cxv_nombre_actual = value; }
        }

        private decimal cxv_fr;

        public decimal Cxv_Fr
        {
            get { return cxv_fr; }
            set { cxv_fr = value; }
        }

        private decimal cxv_op;

        public decimal Cxv_Op
        {
            get { return cxv_op; }
            set { cxv_op = value; }
        }


        private string codparroquia;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoParroquia
        {
            get { return codparroquia; }
            set { codparroquia = value; }
        }


        private string nomparroquia;
        /// <summary>
        /// 
        /// </summary>
        public string NombreParroquia
        {
            get { return nomparroquia; }
            set { nomparroquia = value; }
        }

        private string calles;
        /// <summary>
        /// 
        /// </summary>
        public string Calles
        {
            get { return calles; }
            set { calles = value; }
        }

        private string numerocasa;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroCasa
        {
            get { return numerocasa; }
            set { numerocasa = value; }
        }

        private string comollegar;
        /// <summary>
        /// 
        /// </summary>
        public string ComoLlegar
        {
            get { return comollegar; }
            set { comollegar = value; }
        }

        private string referenciafamiliar;
        /// <summary>
        /// 
        /// </summary>
        public string ReferenciaFamiliar
        {
            get { return referenciafamiliar; }
            set { referenciafamiliar = value; }
        }

        private string telefonoreferenciaf;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoReferenciaFamiliar
        {
            get { return telefonoreferenciaf; }
            set { telefonoreferenciaf = value; }
        }

        private string nombrereferidor;
        /// <summary>
        /// 
        /// </summary>
        public string NombreReferidor
        {
            get { return nombrereferidor; }
            set { nombrereferidor = value; }
        }

        private string operadorcelular;
        /// <summary>
        /// 
        /// </summary>
        public string OperadorCelular
        {
            get { return operadorcelular; }
            set { operadorcelular = value; }
        }

        private string lider;
        /// <summary>
        /// 
        /// </summary>
        public string Lider
        {
            get { return lider; }
            set { lider = value; }
        }

        private string creadopor;
        /// <summary>
        /// 
        /// </summary>
        public string CreadoPor
        {
            get { return creadopor; }
            set { creadopor = value; }
        }

        private bool aprobadoccn;
        /// <summary>
        /// 
        /// </summary>
        public bool AprobadoCCN
        {
            get { return aprobadoccn; }
            set { aprobadoccn = value; }
        }

        private int comoteenteraste;
        /// <summary>
        /// 
        /// </summary>
        public int ComoTeEnteraste
        {
            get { return comoteenteraste; }
            set { comoteenteraste = value; }
        }

        private bool termycond;
        /// <summary>
        /// 
        /// </summary>
        public bool TerminosyCondiciones
        {
            get { return termycond; }
            set { termycond = value; }
        }

        private DateTime fechaaceptacionterm;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaAceptacionTerminos
        {
            get { return fechaaceptacionterm; }
            set { fechaaceptacionterm = value; }
        }

        private bool mostrartermycond;
        /// <summary>
        /// 
        /// </summary>
        public bool MostrarTerminosyCondiciones
        {
            get { return mostrartermycond; }
            set { mostrartermycond = value; }
        }
        
        private decimal pedidominimonivi;
        /// <summary>
        /// 
        /// </summary>
        public decimal PedidoMinimoNivi
        {
            get { return pedidominimonivi; }
            set { pedidominimonivi = value; }
        }

        private decimal pedidominimopisame;
        /// <summary>
        /// 
        /// </summary>
        public decimal PedidoMinimoPisame
        {
            get { return pedidominimopisame; }
            set { pedidominimopisame = value; }
        }

        private decimal pedidominimomixto;
        /// <summary>
        /// 
        /// </summary>
        public decimal PedidoMinimoMixto
        {
            get { return pedidominimomixto; }
            set { pedidominimomixto = value; }
        }

        private decimal pedidominimooutletnivi;
        /// <summary>
        /// 
        /// </summary>
        public decimal PedidoMinimoOutletNivi
        {
            get { return pedidominimooutletnivi; }
            set { pedidominimooutletnivi = value; }
        }
        
        private decimal pedidominimohogarnivi;
        /// <summary>
        /// 
        /// </summary>
        public decimal PedidoMinimoHogarNivi
        {
            get { return pedidominimohogarnivi; }
            set { pedidominimohogarnivi = value; }
        }

        private decimal pedidominimooutletpisame;
        /// <summary>
        /// 
        /// </summary>
        public decimal PedidoMinimoOutletPisame
        {
            get { return pedidominimooutletpisame; }
            set { pedidominimooutletpisame = value; }
        }

        private int tipopedidominimo;
        /// <summary>
        /// 
        /// </summary>
        public int TipoPedidoMinimo
        {
            get { return tipopedidominimo; }
            set { tipopedidominimo = value; }
        }

        private int idcatalogointeres;
        /// <summary>
        /// 
        /// </summary>
        public int IdCatalogoInteres
        {
            get { return idcatalogointeres; }
            set { idcatalogointeres = value; }
        }

        private string catalogointeres;
        /// <summary>
        /// 
        /// </summary>
        public string CatalogoInteres
        {
            get { return catalogointeres; }
            set { catalogointeres = value; }
        }

        private int premio;
        /// <summary>
        /// 
        /// </summary>
        public int Premio
        {
            get { return premio; }
            set { premio = value; }
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

        private string comoteenterastenombre;
        /// <summary>
        /// 
        /// </summary>
        public string ComoTeEnterasteNombre
        {
            get { return comoteenterastenombre; }
            set { comoteenterastenombre = value; }
        }

        private string codciudaddespacho;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudadDespacho
        {
            get { return codciudaddespacho; }
            set { codciudaddespacho = value; }
        }

        private string coddeptodespacho;
        /// <summary>
        /// 
        /// </summary>
        public string CodDeptoDespacho
        {
            get { return coddeptodespacho; }
            set { coddeptodespacho = value; }
        }

        private string idtransportista;
        /// <summary>
        /// 
        /// </summary>
        public string IdTransportista
        {
            get { return idtransportista; }
            set { idtransportista = value; }
        }

        private string idtipored;
        /// <summary>
        /// 
        /// </summary>
        public string IdTipoRed
        {
            get { return idtipored; }
            set { idtipored = value; }
        }

        private string nombretipored;
        /// <summary>
        /// 
        /// </summary>
        public string NombreTipoRed
        {
            get { return nombretipored; }
            set { nombretipored = value; }
        }

        private string nombrelideres;
        /// <summary>
        /// 
        /// </summary>
        public string NombreLider
        {
            get { return nombrelideres; }
            set { nombrelideres = value; }
        }

        private string nombretransportista;
        /// <summary>
        /// 
        /// </summary>
        public string NombreTransportista
        {
            get { return nombretransportista; }
            set { nombretransportista = value; }
        }


        private bool privilegio;
        /// <summary>
        /// 
        /// </summary>
        public bool Privilegio
        {
            get { return privilegio; }
            set { privilegio = value; }
        }

        private string solicitudcredito;
        /// <summary>
        /// 
        /// </summary>
        public string Solicitudcredito
        {
            get { return solicitudcredito; }
            set { solicitudcredito = value; }
        }

        private int cupo_credito;
        /// <summary>
        /// 
        /// </summary>
        public int Cupo_credito
        {
            get { return cupo_credito; }
            set { cupo_credito = value; }
        }

        private string mPago;
        /// <summary>
        /// 
        /// </summary>
        public string MPago
        {
            get { return mPago; }
            set { mPago = value; }
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


        private int actudatos;
        /// <summary>
        /// 
        /// </summary>
        public int Actudatos
        {
            get { return actudatos; }
            set { actudatos = value; }
        }


        private DateTime fechactudatos;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fechactudatos
        {
            get { return fechactudatos; }
            set { fechactudatos = value; }
        }

        //---------------------------------------
        private DateTime ultimacompra;
        /// <summary>
        /// 
        /// </summary>
        public DateTime UltimaCompra
        {
            get { return ultimacompra; }
            set { ultimacompra = value; }
        }


        private string empresaria;
        /// <summary>
        /// 
        /// </summary>
        public string Empresaria
        {
            get { return empresaria; }
            set { empresaria = value; }
        }

        private string tiempocontacto;
        /// <summary>
        /// 
        /// </summary>
        public string TiempoContacto
        {
            get { return tiempocontacto; }
            set { tiempocontacto = value; }
        }
        
        private string whatsapp;
        /// <summary>
        /// 
        /// </summary>
        public string Whatsapp
        {
            get { return whatsapp; }
            set { whatsapp = value; }
        }


        private string tipocliente;
        /// <summary>
        /// 
        /// </summary>
        public string TipoCliente
        {
            get { return tipocliente; }
            set { tipocliente = value; }
        }

        private string tallaprendasuperior;
        /// <summary>
        /// 
        /// </summary>
        public string TallaPrendaSuperior
        {
            get { return tallaprendasuperior; }
            set { tallaprendasuperior = value; }
        }

        private string tallaprendainferior;
        /// <summary>
        /// 
        /// </summary>
        public string TallaPrendaInferior
        {
            get { return tallaprendainferior; }
            set { tallaprendainferior = value; }
        }

        private string tallacalzado;
        /// <summary>
        /// 
        /// </summary>
        public string TallaCalzado
        {
            get { return tallacalzado; }
            set { tallacalzado = value; }
        }

        private string tipotarjeta;
        /// <summary>
        /// 
        /// </summary>
        public string TarjetaCD
        {
            get { return tipotarjeta; }
            set { tipotarjeta = value; }
        }


        private string nombreempresariacompleto;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEmpresariaCompleto
        {
            get {

                if (Nombre2 == null)
                {
                    if (Apellido2 == null)
                    {
                        nombreempresariacompleto = Nombre1 + ' ' + Apellido1;
                    }
                    else
                    {
                        nombreempresariacompleto = Nombre1 + ' ' + Apellido1 + ' ' + Apellido2;
                    }
                }
                else
                {
                    if (Apellido2 == null)
                    {
                        nombreempresariacompleto = Nombre1 + ' ' + Nombre2 + ' ' + Apellido1;
                    }
                    else
                    {
                        nombreempresariacompleto = Nombre1 + ' ' + Nombre2 + ' ' + Apellido1 + ' ' + Apellido2;
                    }
                }

                return nombreempresariacompleto;

            }
            set { nombreempresariacompleto = value; }
        }

        

        private decimal porcentajeivaflete;
        /// <summary>
        /// 
        /// </summary>
        public decimal PorcentajeIvaFlete
        {
            get { return porcentajeivaflete; }
            set { porcentajeivaflete = value; }
        }

        private decimal valorfletesiniva;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFleteSinIva
        {
            get { return valorfletesiniva; }
            set { valorfletesiniva = value; }
        }

        private decimal valorflete;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFlete
        {
            get { return valorflete; }
            set { valorflete = value; }
        }

        private string empresarialider;
        /// <summary>
        /// 
        /// </summary>
        public string EmpresariaLider
        {
            get { return empresarialider; }
            set { empresarialider = value; }
        }

        private string bodega;
        /// <summary>
        /// 
        /// </summary>
        public string Bodega
        {
            get { return bodega; }
            set { bodega = value; }
        }

        private string grupodescuentocliente;
        /// <summary>
        /// 
        /// </summary>
        public string GrupoDescuentoCliente
        {
            get { return grupodescuentocliente; }
            set { grupodescuentocliente = value; }
        }


        private string codestado;
        /// <summary>
        /// 
        /// </summary>
        public string CodEstado
        {
            get { return codestado; }
            set { codestado = value; }
        }
        
        private string correolider;
                /// <summary>
        /// 
        /// </summary>
        public string EmailLider
        {
            get { return correolider; }
            set { correolider = value; }
        }

        private string clasificacionc;
        /// <summary>
        /// 
        /// </summary>
        public string ClasificacionC
        {
            get { return clasificacionc; }
            set { clasificacionc = value; }
        }

        private bool contactada;
        /// <summary>
        /// 
        /// </summary>
        public bool Contactada
        {
            get { return contactada; }
            set { contactada = value; }
        }
        private bool interescredito;
        /// <summary>
        /// 
        /// </summary>
        public bool InteresCredito
        {
            get { return interescredito; }
            set { interescredito = value; }
        }


        public virtual Error Error
        {
            get;
            set;
        }
    }
}
