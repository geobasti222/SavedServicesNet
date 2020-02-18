using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class KardexInfo
    {
        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia.Trim(); }
            set { referencia = value; }
        }

        private string nombreproducto;
        /// <summary>
        /// 
        /// </summary>
        public string NombreProducto
        {
            get { return nombreproducto.Trim(); }
            set { nombreproducto = value; }
        }

        private int tipo;
        /// <summary>
        /// 
        /// </summary>
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string subgrupo;
        /// <summary>
        /// 
        /// </summary>
        public string SubGrupo
        {
            get { return subgrupo; }
            set { subgrupo = value; }
        }

        private string unidadmedida;
        /// <summary>
        /// 
        /// </summary>
        public string UnidadMedida
        {
            get { return unidadmedida; }
            set { unidadmedida = value; }
        }

        private string referenciaproveedor;
        /// <summary>
        /// 
        /// </summary>
        public string ReferenciaProveedor
        {
            get { return referenciaproveedor; }
            set { referenciaproveedor = value; }
        }

        private decimal stockminimo;
        /// <summary>
        /// 
        /// </summary>
        public decimal StockMinimo
        {
            get { return stockminimo; }
            set { stockminimo = value; }
        }

        private decimal stockmaximo;
        /// <summary>
        /// 
        /// </summary>
        public decimal StockMaximo
        {
            get { return stockmaximo; }
            set { stockmaximo = value; }
        }

        private decimal preciobaseventa;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioBaseVenta
        {
            get { return preciobaseventa; }
            set { preciobaseventa = value; }
        }

        private decimal precioventa1;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioVenta1
        {
            get { return precioventa1; }
            set { precioventa1 = value; }
        }

        private decimal precioventa2;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioVenta2
        {
            get { return precioventa2; }
            set { precioventa2 = value; }
        }

        private decimal precioventa3;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioVenta3
        {
            get { return precioventa3; }
            set { precioventa3 = value; }
        }

        private string ubicacion;
        /// <summary>
        /// 
        /// </summary>
        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        private decimal nuevopbv;
        /// <summary>
        /// 
        /// </summary>
        public decimal NuevoPBV
        {
            get { return nuevopbv; }
            set { nuevopbv = value; }
        }

        private DateTime fechanuevopbv;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaNuevoPBV
        {
            get { return fechanuevopbv; }
            set { fechanuevopbv = value; }
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

        private string departamento;
        /// <summary>
        /// 
        /// </summary>
        public string Departamento
        {
            get { return departamento; }
            set { departamento = value; }
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

        private string referenciabase;
        /// <summary>
        /// 
        /// </summary>
        public string ReferenciaBase
        {
            get { return referenciabase; }
            set { referenciabase = value; }
        }

        private decimal equivalebase;
        /// <summary>
        /// 
        /// </summary>
        public decimal EquivaleBase
        {
            get { return equivalebase; }
            set { equivalebase = value; }
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

        private int tipocosteo;
        /// <summary>
        /// 
        /// </summary>
        public int TipoCosteo
        {
            get { return tipocosteo; }
            set { tipocosteo = value; }
        }

        private int visiblepos;
        /// <summary>
        /// 
        /// </summary>
        public int VisiblePOS
        {
            get { return visiblepos; }
            set { visiblepos = value; }
        }

        private int manejolotes;
        /// <summary>
        /// 
        /// </summary>
        public int ManejoLotes
        {
            get { return manejolotes; }
            set { manejolotes = value; }
        }

        private string foto;
        /// <summary>
        /// 
        /// </summary>
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        private int importado;
        /// <summary>
        /// 
        /// </summary>
        public int Importado
        {
            get { return importado; }
            set { importado = value; }
        }

        private string codarancel;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoArancel
        {
            get { return codarancel; }
            set { codarancel = value; }
        }

        private string codunidad;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoUnidad
        {
            get { return codunidad; }
            set { codunidad = value; }
        }

        private decimal preciouno;

        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioUno
        {
            get { return preciouno; }
            set { preciouno = value; }
        }

        private decimal preciodos;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioDos
        {
            get { return preciodos; }
            set { preciodos = value; }
        }

        private decimal preciotres;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioTres
        {
            get { return preciotres; }
            set { preciotres = value; }
        }

        private decimal preciocuatro;
        /// <summary>
        /// 
        /// </summary>
        public decimal PrecioCuatro
        {
            get { return preciocuatro; }
            set { preciocuatro = value; }
        }

        private decimal peso;
        /// <summary>
        /// 
        /// </summary>
        public decimal Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        private decimal volumen;
        /// <summary>
        /// 
        /// </summary>
        public decimal Volumen
        {
            get { return volumen; }
            set { volumen = value; }
        }

        private decimal diametro;
        /// <summary>
        /// 
        /// </summary>
        public decimal Diametro
        {
            get { return diametro; }
            set { diametro = value; }
        }

        private decimal alto;
        /// <summary>
        /// 
        /// </summary>
        public decimal Alto
        {
            get { return alto; }
            set { alto = value; }
        }

        private decimal ancho;
        /// <summary>
        /// 
        /// </summary>
        public decimal Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }

        private decimal largo;
        /// <summary>
        /// 
        /// </summary>
        public decimal Largo
        {
            get { return largo; }
            set { largo = value; }
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

        private string codigobarras;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoBarras
        {
            get { return codigobarras; }
            set { codigobarras = value; }
        }

        private int agotado;
        /// <summary>
        /// 
        /// </summary>
        public int Agotado
        {
            get { return agotado; }
            set { agotado = value; }
        }

        private decimal creditopersonal;
        /// <summary>
        /// 
        /// </summary>
        public decimal CreditoPersonal
        {
            get { return creditopersonal; }
            set { creditopersonal = value; }
        }

        private decimal detal;
        /// <summary>
        /// 
        /// </summary>
        public decimal Detal
        {
            get { return detal; }
            set { detal = value; }
        }

        private decimal mayorista;
        /// <summary>
        /// 
        /// </summary>
        public decimal Mayorista
        {
            get { return mayorista; }
            set { mayorista = value; }
        }

        private decimal libre;
        /// <summary>
        /// 
        /// </summary>
        public decimal Libre
        {
            get { return libre; }
            set { libre = value; }
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

        private string imagen;
        /// <summary>
        /// 
        /// </summary>
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        private string proveedor;
        /// <summary>
        /// 
        /// </summary>
        public string Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }

        private string uninegocio;
        /// <summary>
        /// 
        /// </summary>
        public string UnidadNegocio
        {
            get { return uninegocio; }
            set { uninegocio = value; }
        }

        private string posicion;
        /// <summary>
        /// 
        /// </summary>
        public string Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        private int plu;
        /// <summary>
        /// 
        /// </summary>
        public int PLU
        {
            get { return plu; }
            set { plu = value; }
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

        private string descripcioncolor;
        /// <summary>
        /// 
        /// </summary>
        public string DescripcionColor
        {
            get { return descripcioncolor; }
            set { descripcioncolor = value; }
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

        private string conceptocontable;
        /// <summary>
        /// 
        /// </summary>
        public string ConceptoContable
        {
            get { return conceptocontable; }
            set { conceptocontable = value; }
        }

        //------------------
        
        private int cantidad;
        /// <summary>
        /// Cantidad estimada para los premios.
        /// </summary>
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
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

        private bool prodestrella;
        /// <summary>
        /// 
        /// </summary>
        public bool ProdEstrella
        {
            get { return prodestrella; }
            set { prodestrella = value; }
        }

        private string idextension1;
        /// <summary>
        /// 
        /// </summary>
        public string IdExtension1
        {
            get { return idextension1; }
            set { idextension1 = value; }
        }

        private string idextension2;
        /// <summary>
        /// 
        /// </summary>
        public string IdExtension2
        {
            get { return idextension2; }
            set { idextension2 = value; }
        }

    }
}
