using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ArtExcentosxCiudadInfo
    {
        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
        }

        private int plu;
        /// <summary>
        /// 
        /// </summary>
        public int Plu
        {
            get { return plu; }
            set { plu = value; }
        }

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private bool estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }
      
    }
}
