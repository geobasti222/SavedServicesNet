using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SectorZonaInfo
    {
        private string codsector;
        /// <summary>
        /// 
        /// </summary>
        public string CodSector
        {
            get { return codsector; }
            set { codsector = value; }
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
