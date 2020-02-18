using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SectorInfo
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

        private string nombresector;
        /// <summary>
        /// 
        /// </summary>
        public string NombreSector
        {
            get { return nombresector; }
            set { nombresector = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
        }

        private string codzona;
        /// <summary>
        /// 
        /// </summary>
        public string CodZona
        {
            get { return codzona; }
            set { codzona = value; }
        }       
    }
}
