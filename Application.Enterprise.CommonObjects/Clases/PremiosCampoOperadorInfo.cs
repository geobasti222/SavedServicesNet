using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PremiosCampoOperadorInfo
    {
        private int idcampo;
        /// <summary>
        /// 
        /// </summary>
        public int IdCampo
        {
            get { return idcampo; }
            set { idcampo = value; }
        }

        private int idoperador;
        /// <summary>
        /// 
        /// </summary>
        public int IdOperador
        {
            get { return idoperador; }
            set { idoperador = value; }
        }      
    }
}
