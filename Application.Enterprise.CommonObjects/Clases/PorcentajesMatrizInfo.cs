using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PorcentajesMatrizInfo
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

        private string concepto;
        /// <summary>
        /// 
        /// </summary>
        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        private decimal valormenor;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorMenor
        {
            get { return valormenor; }
            set { valormenor = value; }
        }

        private decimal valormayor;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorMayor
        {
            get { return valormayor; }
            set { valormayor = value; }
        }

        private int estado;
        /// <summary>
        /// 
        /// </summary>
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

      
    }
}
