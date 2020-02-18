using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class LocalidadInfo
    {
        private string codlocalidad;
        /// <summary>
        /// 
        /// </summary>
        public string CodLocalidad
        {
            get { return codlocalidad.Trim(); }
            set { codlocalidad = value; }
        }

        private string nombrelocalidad;
        /// <summary>
        /// 
        /// </summary>
        public string NombreLocalidad
        {
            get { return nombrelocalidad.Trim(); }
            set { nombrelocalidad = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudad
        {
            get { return codciudad.Trim(); }
            set { codciudad = value; }
        }    	
        
    }
}
