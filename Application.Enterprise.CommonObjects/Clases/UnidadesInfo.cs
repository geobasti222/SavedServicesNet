using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class UnidadesInfo
    {
        private string _unidad;
        /// <summary>
        /// 
        /// </summary>
        public string Unidad
        {
            get { return _unidad; }
            set { _unidad = value; }
        }

        private string _nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private decimal _valor;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

    }
}
