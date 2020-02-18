using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CiclosInfo
    {
        private string _ciclo;
        /// <summary>
        /// 
        /// </summary>
        public string Ciclo
        {
            get { return _ciclo; }
            set { _ciclo = value; }
        }

        private string _nombreciclo;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiclo
        {
            get { return _nombreciclo; }
            set { _nombreciclo  = value; }
        }

        private bool _estado;
        /// <summary>
        /// 
        /// </summary>
        public bool estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
