using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PuntoReordenInfo
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

        private int valoragotado;
        /// <summary>
        /// 
        /// </summary>
        public int ValorAgotado
        {
            get { return valoragotado; }
            set { valoragotado = value; }
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
    }
}
