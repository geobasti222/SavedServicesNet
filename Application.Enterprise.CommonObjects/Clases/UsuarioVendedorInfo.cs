using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class UsuarioVendedorInfo
    {
        private string claveacceso;
        /// <summary>
        /// 
        /// </summary>
        public string ClaveAcceso
        {
            get { return claveacceso; }
            set { claveacceso = value; }
        }

        private string idvendedor;
        /// <summary>
        /// 
        /// </summary>
        public string IdVendedor
        {
            get { return idvendedor.Trim(); }
            set { idvendedor = value; }
        }

      
    }
}
