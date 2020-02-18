using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class PremiosWinformPedidoInfo
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

        private int cantidadpedida;
        /// <summary>
        /// 
        /// </summary>
        public int CantidadPedida
        {
            get { return cantidadpedida; }
            set { cantidadpedida = value; }
        }

        private decimal tarifaiva;
        /// <summary>
        /// 
        /// </summary>
        public decimal TarifaIva
        {
            get { return tarifaiva; }
            set { tarifaiva = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
