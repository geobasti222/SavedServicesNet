using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CentroOperacionInfo
    {

        private int id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string codigocentroop;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCentroOperacion
        {
            get { return codigocentroop; }
            set { codigocentroop = value; }
        }

        private string nombrecentroop;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCentroOperacion
        {
            get { return nombrecentroop; }
            set { nombrecentroop = value; }
        }
            
        private string textoempresaria;
        /// <summary>
        /// 
        /// </summary>
        public string TextoEmpresaria
        {
            get { return textoempresaria; }
            set { textoempresaria = value; }
        }

        private bool entregarensitio;
        /// <summary>
        /// 
        /// </summary>
        public bool EntregarEnSitio
        {
            get { return entregarensitio; }
            set { entregarensitio = value; }
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
