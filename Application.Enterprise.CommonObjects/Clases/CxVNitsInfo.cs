using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
     /// <summary>
    /// 
    /// </summary>
    
    public class CxVNitsInfo
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

        private decimal ordenpromedio;
        /// <summary>
        /// 
        /// </summary>
        public decimal OrdenPromedio
        {
            get { return ordenpromedio; }
            set { ordenpromedio = value; }
        }

        private decimal frecuenciaesc;
        /// <summary>
        /// 
        /// </summary>
        public decimal FrecuenciaEsc
        {
            get { return frecuenciaesc; }
            set { frecuenciaesc = value; }
        }
    }
}
