using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SectorxBarrioInfo
    {
        private int bar_codbarrio;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoBarrio
        {
            get { return bar_codbarrio; }
            set { bar_codbarrio = value; }
        }

        private string sec_codsector;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoSector
        {
            get { return sec_codsector; }
            set { sec_codsector = value; }
        }

        private string nombresector;
        /// <summary>
        /// 
        /// </summary>
        public string NombreSector
        {
            get { return nombresector; }
            set { nombresector = value; }
        }

      
    }
}
