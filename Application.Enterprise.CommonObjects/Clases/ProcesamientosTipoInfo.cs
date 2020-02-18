using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ProcesamientosTipoInfo
    {
        private int procesoid;
        /// <summary>
        /// 
        /// </summary>
        public int ProcesoId
        {
            get { return procesoid; }
            set { procesoid = value; }
        }

        private string procesodescripcion;
        /// <summary>
        /// 
        /// </summary>
        public string ProcesoDescripcion
        {
            get { return procesodescripcion; }
            set { procesodescripcion = value; }
        }
    }
}
