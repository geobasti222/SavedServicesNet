using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AmarresInfo
    {
        /**
         * id INTEGER IDENTITY(1,1) not null,
  id_regla INTEGER ,
         
  pinta INTEGER,
  amarre INTEGER, 
  xreferencia INTEGER,
  xcodigorapido INTEGER,
  xfecha  INTEGER,
  xcampana INTEGER,
  
  descripcion varchar(max),
  idproducto varchar(50),
  idamarre varchar(50),
  campana varchar(50),
  fechaini datetime,
  fechafin datetime,		
  precio numeric(18,2),
  descuento	numeric(18,2),   
         * 
         * */

        private int pinta; 
        public int  Pinta
        {
            get { return pinta; }
            set { pinta= value; } 
        }

        private int amarre;
        public int Amarre
        {
            get { return amarre; }
            set { amarre = value; }
        }

        private int xreferencia;
        public int xReferencia
        {
            get { return xreferencia; }
            set { xreferencia = value; }
        }

        private int xcodigo;
        public int xCodigo
        {
            get { return xcodigo; }
            set { xcodigo = value; }
        }
        
        private int xfecha;
        public int xFecha
        {
            get { return xfecha; }
            set { xfecha = value; }
        }

        private int xcampana;
        public int xCampana
        {
            get { return xcampana; }
            set { xcampana = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string idamarre; 
        public string Idamarre
        {
            get { return idamarre; }
            set { idamarre = value; }
        }

        private string idproducto;
        public string Idproducto
        {
            get { return idproducto; }
            set { idproducto = value; }
        }

        private int id_regla;
        public int Id_regla
        {
            get { return id_regla; }
            set { id_regla = value; }
        }

        private int descartado_escoger;
        public int Descartado_escoger
        {
            get { return descartado_escoger; }
            set { descartado_escoger = value; }
        }

        private int descartado_detallado;
        public int Descartado_detallado
        {
            get { return descartado_detallado; }
            set { descartado_detallado = value; }
        }

        
        private int descartado_amarres_pedido;
        public int Descartado_amarres_pedido
        {
            get { return descartado_amarres_pedido; }
            set { descartado_amarres_pedido = value; }
        }

        private bool aplicadescuento;
        public bool Aplicadescuento
        {
            get { return aplicadescuento; }
            set { aplicadescuento = value; }
        }


        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        private int cantidadproductos;
        public int Cantidadproductos
        {
            get { return cantidadproductos; }
            set { cantidadproductos = value; }
        }
        

        private int cantidadamarres;
        public int Cantidadamarres
        {
            get { return cantidadamarres; }
            set { cantidadamarres = value; }
        }

        private string precioreal;
        public string Precioreal
        {
            get { return precioreal; }
            set { precioreal = value; }
        }

    


        private string campana;
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private DateTime fechainicial;
        public DateTime Fechainicial
        {
            get { return fechainicial; }
            set { fechainicial = value; }
        }

        private DateTime fechafinal;
        public DateTime Fechafinal
        {
            get { return fechafinal; }
            set { fechafinal = value; }
        }

        private decimal precio;
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }


        private decimal preciopro;
        public decimal Preciopro
        {
            get { return preciopro; }
            set { preciopro = value; }
        }

        private decimal precioamarre;
        public decimal Precioamarre
        {
            get { return precioamarre; }
            set { precioamarre = value; }
        }

        private decimal preciopinta;
        public decimal Preciopinta
        {
            get { return preciopinta; }
            set { preciopinta = value; }
        }



        private decimal descuento;
        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }



        
    }
}
