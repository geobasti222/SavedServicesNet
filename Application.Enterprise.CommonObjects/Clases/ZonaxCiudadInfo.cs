using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ZonaxCiudadInfo
    {
        private int ciu_codciudad;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoCiudad
        {
            get { return ciu_codciudad; }
            set { ciu_codciudad = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona.Trim(); }
            set { zona = value; }
        }


        private string nombreciudad;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiudad
        {
            get { return nombreciudad.ToUpper(); }
            set { nombreciudad = value; }
        }

        private string ciu_codciudadstring;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCiudadString
        {
            get { return ciu_codciudadstring.Trim(); }
            set { ciu_codciudadstring = value; }
        }

        private string _sector;
        /// <summary>
        /// 
        /// </summary>
        public string Sector
        {
            get { return _sector; }
            set { _sector = value; }
        }

        private string _usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
    }
}
