using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class EstadoInfo
    {
        private string codestado;
        /// <summary>
        /// 
        /// </summary>
        public string CodEstado
        {
            get { return codestado; }
            set { codestado = value; }
        }

        private string nombreestado;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEstado
        {
            get { return nombreestado; }
            set { nombreestado = value; }
        }

        private string codpais;
        /// <summary>
        /// 
        /// </summary>
        public string CodPais
        {
            get { return codpais; }
            set { codpais = value; }
        }

         private string codigoestado;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoEstado
        {
            get { return codigoestado; }
            set { codigoestado = value; }
        }     
        
    }
}
