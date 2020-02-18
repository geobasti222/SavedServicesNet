using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PremiosPuntosConfInfo
    {
        private int id;
        /// <summary>
        /// 
        /// </summary>
        public int IdConfiguracion
        {
            get { return id; }
            set { id = value; }
        }

        private int idcampo;
        /// <summary>
        /// 
        /// </summary>
        public int IdCampo
        {
            get { return idcampo; }
            set { idcampo = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }


        private string tipoprecio;
        /// <summary>
        /// 
        /// </summary>
        public string TipoPrecio
        {
            get { return tipoprecio; }
            set { tipoprecio = value; }
        }

        private int puntos;
        /// <summary>
        /// 
        /// </summary>
        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

      
    }
}
