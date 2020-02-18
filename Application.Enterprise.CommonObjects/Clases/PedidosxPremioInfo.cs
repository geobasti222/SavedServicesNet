using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PedidosxPremioInfo
    {
        private int idpremio;
        /// <summary>
        /// 
        /// </summary>
        public int IdPremio
        {
            get { return idpremio; }
            set { idpremio = value; }
        }

        private string numero;
        /// <summary>
        /// 
        /// </summary>
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }      
    }
}
