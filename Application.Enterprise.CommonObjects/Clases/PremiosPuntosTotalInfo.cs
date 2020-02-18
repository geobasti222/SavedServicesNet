using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PremiosPuntosTotalInfo
    {
        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit.Trim(); }
            set { nit = value; }
        }

        private int puntostotal;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosTotal
        {
            get { return puntostotal; }
            set { puntostotal = value; }
        }

        private int idpremio;
        /// <summary>
        /// 
        /// </summary>
        public int IdPremio
        {
            get { return idpremio; }
            set { idpremio = value; }
        }      
    }
}
