using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ReglasTablasInfo
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

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string key;
        /// <summary>
        /// 
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string concepto;
        /// <summary>
        /// 
        /// </summary>
        public string Concepto
        {
            get { return concepto.ToUpper(); }
            set { concepto = value; }
        }
    }
}
