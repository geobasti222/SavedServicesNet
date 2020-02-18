using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class TallaInfo
    {
        private string codtalla;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoTalla
        {
            get { return codtalla; }
            set { codtalla = value; }
        }

        private string nombretalla;
        /// <summary>
        /// 
        /// </summary>
        public string NombreTalla
        {
            get { return nombretalla.Trim(); }
            set { nombretalla = value; }
        }

        private string catalogo;
        /// <summary>
        /// 
        /// </summary>
        public string Catalogo
        {
            get { return catalogo.Trim(); }
            set { catalogo = value; }
        }         
    }
}
