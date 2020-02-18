using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class EstadosClienteInfo
    {
        private string id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
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
    }
}
