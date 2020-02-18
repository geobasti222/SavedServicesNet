using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class InventarioInfo
    {
        private string bodega;
        /// <summary>
        /// 
        /// </summary>
        public string Bodega
        {
            get { return bodega.Trim(); }
            set { bodega = value; }
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

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos.Trim(); }
            set { ccostos = value; }
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
    }
}
