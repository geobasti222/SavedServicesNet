using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PedidosDetalleClienteInfo
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

        private string id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
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

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
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

        private decimal cantidad;
        /// <summary>
        /// 
        /// </summary>
        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
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

        private int anulado;
        /// <summary>
        /// 
        /// </summary>
        public int Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }

        private decimal tarifaiva;
        /// <summary>
        /// 
        /// </summary>
        public decimal TarifaIVA
        {
            get { return tarifaiva; }
            set { tarifaiva = value; }
        }

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CentroCostos
        {
            get { return ccostos; }
            set { ccostos = value; }
        }

        private string lote;
        /// <summary>
        /// 
        /// </summary>
        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }

        private int ensamblado;
        /// <summary>
        /// 
        /// </summary>
        public int Ensamblado
        {
            get { return ensamblado; }
            set { ensamblado = value; }
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

        private string id_doc_fuente;
        /// <summary>
        /// 
        /// </summary>
        public string IdDocumentoFuente
        {
            get { return id_doc_fuente; }
            set { id_doc_fuente = value; }
        }

        private string codubicacion;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoUbicacion
        {
            get { return codubicacion; }
            set { codubicacion = value; }
        }

        private decimal plu;
        /// <summary>
        /// 
        /// </summary>
        public decimal PLU
        {
            get { return plu; }
            set { plu = value; }
        }

        private decimal numeroenvio;
        /// <summary>
        /// 
        /// </summary>
        public decimal NumeroEnvio
        {
            get { return numeroenvio; }
            set { numeroenvio = value; }
        }

        private string conceptocontable;
        /// <summary>
        /// 
        /// </summary>
        public string ConceptoContable
        {
            get { return conceptocontable; }
            set { conceptocontable = value; }
        }

        private string imagen;
        /// <summary>
        /// 
        /// </summary>
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        private string grupo;
        /// <summary>
        /// 
        /// </summary>
        public string Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        private decimal cantidadnivelservicio;
        /// <summary>
        /// 
        /// </summary>
        public decimal CantidadNivelServicio
        {
            get { return cantidadnivelservicio; }
            set { cantidadnivelservicio = value; }
        }


        private decimal valorpreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPrecioCatalogo
        {
            get { return valorpreciocatalogo; }
            set { valorpreciocatalogo = value; }
        }

        private decimal ivapreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal IVAPrecioCatalogo
        {
            get { return ivapreciocatalogo; }
            set { ivapreciocatalogo = value; }
        }

        private string catalogo;
        /// <summary>
        /// 
        /// </summary>
        public string Catalogo
        {
            get { return catalogo; }
            set { catalogo = value; }
        }

        private string numeropedidopadre;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroPedidoPadre
        {
            get { return numeropedidopadre; }
            set { numeropedidopadre = value; }
        }


        private decimal totalpreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrecioCatalogo
        {
            get
            {
                totalpreciocatalogo = ValorPrecioCatalogo+((TarifaIVA / 100) * ValorPrecioCatalogo); // /+ IVAPrecioCatalogo;
                return totalpreciocatalogo;
            }
            set { totalpreciocatalogo = value; }
        }

        private string catalogoreal;
        /// <summary>
        /// 
        /// </summary>
        public string CatalogoReal
        {
            get { return catalogoreal; }
            set { catalogoreal = value; }
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

        private decimal valorunitario;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorUnitario
        {
            get { return valorunitario; }
            set { valorunitario = value; }
        }


        #region "Propiedades de Encabezado de Pedido"

        private string nit;

        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        private DateTime fechacreacion;

        public DateTime FechaCreacion
        {
            get { return fechacreacion; }
            set { fechacreacion = value; }
        }

        private string zona;

        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private string campana;

        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private bool procesado;

        public bool Procesado
        {
            get { return procesado; }
            set { procesado = value; }
        }

        private DateTime fechaultimamodificacion;

        public DateTime FechaUltimaModificacion
        {
            get { return fechaultimamodificacion; }
            set { fechaultimamodificacion = value; }
        }


        private string mailgroup;

        public string Mailgroup
        {
            get { return mailgroup; }
            set { mailgroup = value; }
        }

        #endregion
        
        private int total;
        /// <summary>
        /// 
        /// </summary>
        public int Total
        {
            get { return total; }
            set { total = value; }
        }


        private decimal totalpreciocatalogocantidad;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrecioCatalogoCantidad
        {
            get
            {                
                return totalpreciocatalogocantidad;
            }
            set { totalpreciocatalogocantidad = value; }
        }

        private string unineg;
        /// <summary>
        /// 
        /// </summary>
        public string UnidadNegocio
        {
            get { return unineg; }
            set { unineg = value; }
        }

        private decimal porcentajedescuento;
        /// <summary>
        /// 
        /// </summary>
        public decimal PorcentajeDescuento
        {
            get
            {
                return porcentajedescuento;
            }
            set { porcentajedescuento = value; }
        }

        private decimal valorpreciocatalogounitario;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPrecioCatalogoUnitario
        {
            get
            {
                return valorpreciocatalogounitario;
            }
            set { valorpreciocatalogounitario = value; }
        }

        private string grupoproducto;
        /// <summary>
        /// 
        /// </summary>
        public string GrupoProducto
        {
            get { return grupoproducto; }
            set { grupoproducto = value; }
        }

        private bool estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string campanainicio;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaInicio
        {
            get { return campanainicio; }
            set { campanainicio = value; }
        }

        private string catalogoenvio;
        /// <summary>
        /// 
        /// </summary>
        public string CatalogoEnvio
        {
            get { return catalogoenvio; }
            set { catalogoenvio = value; }
        }

        private decimal plusustituto;
        /// <summary>
        /// 
        /// </summary>
        public decimal PLUSustituto
        {
            get { return plusustituto; }
            set { plusustituto = value; }
        }

        private string codigorapidosustituto;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoRapidoSustituto
        {
            get { return codigorapidosustituto; }
            set { codigorapidosustituto = value; }
        }

        private bool prodestrella;
        /// <summary>
        /// 
        /// </summary>
        public bool ProdEstrella
        {
            get { return prodestrella; }
            set { prodestrella = value; }
        }

        //--------------------------------------------
        private decimal subtotal;
        public decimal SubTotal
        {
            get
            {
                return subtotal;
            }
            set { subtotal = value; }
        }

        private decimal subtotalpreciocat;
        public decimal SubTotalPrecioCat
        {
            get
            {
                return subtotalpreciocat;
            }
            set { subtotalpreciocat = value; }
        }

        private decimal iva;
        public decimal IVA
        {
            get
            {
                return iva;
            }
            set { iva = value; }
        }

        private decimal ivapreciocat;
        public decimal IVAPrecioCat
        {
            get
            {
                return ivapreciocat;
            }
            set { ivapreciocat = value; }
        }

        
        private decimal totalpreciocat;
        public decimal TotalPrecioCat
        {
            get
            {
                return totalpreciocat;
            }
            set { totalpreciocat = value; }
        }

        private int puntosganados;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosGanados
        {
            get
            {
                return puntosganados;
            }
            set { puntosganados = value; }
        }

        private decimal porcentajedescuentopuntos;
        /// <summary>
        /// 
        /// </summary>
        public decimal PorcentajeDescuentoPuntos
        {
            get
            {
                return porcentajedescuentopuntos;
            }
            set { porcentajedescuentopuntos = value; }
        }

        public virtual PedidosClienteInfo PedidosClienteInfo
        {
            get;
            set;
        }



        public virtual Error Error
        {
            get;
            set;
        }
    }
}

