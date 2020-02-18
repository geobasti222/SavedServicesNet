using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class GrupoProductoInfo
    {
        private string grp_id;
        /// <summary>
        /// 
        /// </summary>
        public string GrupoProducto
        {
            get { return grp_id; }
            set { grp_id = value; }
        }

        private string grp_nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return grp_nombre; }
            set { grp_nombre = value; }
        }

      
    }
}
