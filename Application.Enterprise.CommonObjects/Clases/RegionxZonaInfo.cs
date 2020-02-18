using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class RegionxZonaInfo
    {
        private int reg_codregional;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoRegion
        {
            get { return reg_codregional; }
            set { reg_codregional = value; }
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

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion.ToUpper(); }
            set { descripcion = value; }
        }

        private string idregional;
        /// <summary>
        /// 
        /// </summary>
        public string IdRegional
        {
            get { return idregional.Trim(); }
            set { idregional = value; }
        }

        private string _usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return _usuario.Trim(); }
            set { _usuario = value; }
        }
        
    }
}
