using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class RegionalesInfo
    {
        private int codigoregional;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoRegional
        {
            get { return codigoregional; }
            set { codigoregional = value; }
        }

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre.ToUpper().Trim(); }
            set { nombre = value; }
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


        private string codge;
        /// <summary>
        /// 
        /// </summary>
        public string Codgereg
        {
            get { if (codge == null) { return ""; } return codge.Trim(); }
            set { codge = value; }
        }

        private string _nombregerente;
        /// <summary>
        /// 
        /// </summary>
        public string NombreGerente
        {
            get { return _nombregerente.Trim(); }
            set { _nombregerente = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string usuario;

        public string Usuario
        {
            get { if (usuario == null) { return ""; } return usuario.Trim(); }
            set { usuario = value;       }
        }
    }
}
