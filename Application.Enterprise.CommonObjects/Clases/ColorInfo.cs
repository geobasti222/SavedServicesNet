using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ColorInfo
    {
        private string codcolor;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoColor
        {
            get { return codcolor; }
            set { codcolor = value; }
        }

        private string nombrecolor;
        /// <summary>
        /// 
        /// </summary>
        public string NombreColor
        {
            get { return nombrecolor.Trim(); }
            set { nombrecolor = value; }
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
