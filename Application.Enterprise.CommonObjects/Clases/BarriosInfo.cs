using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class BarriosInfo
    {
        private int codbarrio;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoBarrio
        {
            get { return codbarrio; }
            set { codbarrio = value; }
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

        private int codciudad;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
        }


      
    }
}
