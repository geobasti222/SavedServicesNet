using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class GruposInfo
    {
        private string grupo;
        /// <summary>
        /// 
        /// </summary>
        public string IdGrupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string tarifaiva;
        /// <summary>
        /// 
        /// </summary>
        public string IdTarifaIVA
        {
            get { return tarifaiva; }
            set { tarifaiva = value; }
        }

        private string retencion;
        /// <summary>
        /// 
        /// </summary>
        public string Retencion
        {
            get { return retencion; }
            set { retencion = value; }
        }

        private string reteica;
        /// <summary>
        /// 
        /// </summary>
        public string ReteICA
        {
            get { return reteica; }
            set { reteica = value; }
        }      
    }
}
