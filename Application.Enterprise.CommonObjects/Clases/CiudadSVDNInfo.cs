using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CiudadSVDNInfo
    {
        private int codigociudad;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoCiudad
        {
            get { return codigociudad; }
            set { codigociudad = value; }
        }

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre.ToUpper(); }
            set { nombre = value; }
        }


        private int codregional;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoRegional
        {
            get { return codregional; }
            set { codregional = value; }
        }

        private string codigociudaddane;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCiudadDane
        {
            get { return codigociudaddane; }
            set { codigociudaddane = value; }
        }

      
    }
}
