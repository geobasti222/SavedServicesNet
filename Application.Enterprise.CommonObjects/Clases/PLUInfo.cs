using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>

    public class PLUInfo
    {
        private int plu;
        /// <summary>
        /// 
        /// </summary>
        public int PLU
        {
            get { return plu; }
            set { plu = value; }
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

        private string codigocolor;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoColor
        {
            get { return codigocolor; }
            set { codigocolor = value; }
        }

        private string nombrecolor;
        /// <summary>
        /// 
        /// </summary>
        public string NombreColor
        {
            get { return nombrecolor; }
            set { nombrecolor = value; }
        }

        private string codigotalla;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoTalla
        {
            get { return codigotalla; }
            set { codigotalla = value; }
        }

        private string nombretalla;
        /// <summary>
        /// 
        /// </summary>
        public string NombreTalla
        {
            get { return nombretalla; }
            set { nombretalla = value; }
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

        private string codigobarras;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoBarras
        {
            get { return codigobarras; }
            set { codigobarras = value; }
        }

        private string nombreproducto;
        /// <summary>
        /// 
        /// </summary>
        public string NombreProducto
        {
            get { return nombreproducto; }
            set { nombreproducto = value; }
        }

        private decimal preciosiniva;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioSinIVA
        {
            get { return preciosiniva; }
            set { preciosiniva = value; }
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

        private decimal precioconiva;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioConIVA
        {
            get { return precioconiva; }
            set { precioconiva = value; }
        }

        private decimal porcentajeiva;
        /// <summary>
        /// 
        /// </summary>
        public decimal PorcentajeIVA
        {
            get { return porcentajeiva; }
            set { porcentajeiva = value; }
        }

        private decimal preciototalconiva;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioTotalConIVA
        {
            get { return preciototalconiva; }
            set { preciototalconiva = value; }
        }

        private string codigorapido;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoRapido
        {
            get { return codigorapido; }
            set { codigorapido = value; }
        }

        private int cantidad;
        /// <summary>
        /// 
        /// </summary>
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
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


        private decimal preciocatalogosiniva;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioCatalogoSinIVA
        {
            get { return preciocatalogosiniva; }
            set { preciocatalogosiniva = value; }
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


        private decimal preciocatalogototalconiva;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioCatalogoTotalConIVA
        {
            get { return preciocatalogototalconiva; }
            set { preciocatalogototalconiva = value; }
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

        private string codigorapidosustituto;

        public string CodigoRapidoSustituto
        {
            get { return codigorapidosustituto; }
            set { codigorapidosustituto = value; }
        }

        private int plusustituto;
        /// <summary>
        /// 
        /// </summary>
        public int PLUSustituto
        {
            get { return plusustituto; }
            set { plusustituto = value; }
        }


        private string campana;

        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private string idzona;

        public string IdZona
        {
            get { return idzona; }
            set { idzona = value; }
        }       

        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }


        private decimal precioempresaria;
        public decimal PrecioEmpresaria
        {
            get { return precioempresaria; }
            set { precioempresaria = value; }
        }

        private int precioPuntos;
        public int PrecioPuntos
        {
            get { return precioPuntos; }
            set { precioPuntos = value; }
        }

        private decimal pagopuntos;
        public decimal Pagopuntos
        {
            get { return pagopuntos; }
            set { pagopuntos = value; }
        }


        private int activo;
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }


        private bool disponible;
        public bool Disponible
        {
            get { return disponible; }
            set { disponible = value; }
        }

        private decimal porcentajedescuento;
        public decimal PorcentajeDescuento
        {
            get { return porcentajedescuento; }
            set { porcentajedescuento = value; }
        }


        private string imagen;

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        private bool excentoiva;
        public bool ExcentoIVA
        {
            get { return excentoiva; }
            set { excentoiva = value; }
        }

        private decimal precioempresariasiniva;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioEmpresariaSinIVA
        {
            get { return precioempresariasiniva; }
            set { precioempresariasiniva = value; }
        }

        private decimal valoriva;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorIVA
        {
            get { return valoriva; }
            set { valoriva = value; }
        }

        private decimal ivaprecioempresaria;
        /// <summary>
        /// 
        /// </summary>
        public decimal IVAPrecioEmpresaria
        {
            get { return ivaprecioempresaria; }
            set { ivaprecioempresaria = value; }
        }

        private int puntosganados;
        public int PuntosGanados
        {
            get { return puntosganados; }
            set { puntosganados = value; }
        }

        private int cantidadpedida;
        public int CantidadPedida
        {
            get { return cantidadpedida; }
            set { cantidadpedida = value; }
        }

        public virtual SessionEmpresariaInfo SessionEmpresaria
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
