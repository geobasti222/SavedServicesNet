using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class IntermediarioInfo
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
            get { return nombre.ToUpper(); }
            set { nombre = value; }
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
