using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PedidosDetallesSIESA_SVDNinfo
    {
        private string numero;
        /// <summary>
        /// 
        /// </summary>
        public string Numero
        {
            get { return numero.Trim(); }
            set { numero = value; }
        }

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia.Trim(); }
            set { referencia = value; }
        }

        private string talla;
        /// <summary>
        /// 
        /// </summary>
        public string Talla
        {
            get { return talla.Trim(); }
            set { talla = value; }
        }

        private string color;
        /// <summary>
        /// 
        /// </summary>
        public string Color
        {
            get { return color.Trim(); }
            set { color = value; }
        }

        private DateTime fechaentrega;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaEntrega
        {
            get { return fechaentrega; }
            set { fechaentrega = value; }
        }

        private DateTime idfecha;
        /// <summary>
        /// 
        /// </summary>
        public DateTime IdFecha
        {
            get { return idfecha; }
            set { idfecha = value; }
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

        private int cantidad2;
        /// <summary>
        /// 
        /// </summary>
        public int Cantidad2
        {
            get { return cantidad2; }
            set { cantidad2 = value; }
        }

        private decimal precio;
        /// <summary>
        /// 
        /// </summary>
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }
}
