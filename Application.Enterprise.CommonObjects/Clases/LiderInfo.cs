using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class LiderInfo
    {
        private string lider;
        /// <summary>
        /// 
        /// </summary>
        public string IdLider
        {
            get { return lider.Trim(); }
            set { lider = value; }
        }

        private string nombres;
        /// <summary>
        /// 
        /// </summary>
        public string Nombres
        {
            get { return nombres.Trim(); }
            set { nombres = value; }
        }

        private string cedula;
        /// <summary>
        /// 
        /// </summary>
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string IdVendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string Codciudad
        {
            get { return codciudad; }
            set { codciudad = value; }
        }
      
    }
}
