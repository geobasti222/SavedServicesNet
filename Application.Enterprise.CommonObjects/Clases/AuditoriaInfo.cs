using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AuditoriaInfo
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

        private DateTime fechasistema;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaSistema
        {
            get { return fechasistema; }
            set { fechasistema = value; }
        }

        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string proceso;
        /// <summary>
        /// 
        /// </summary>
        public string Proceso
        {
            get { return proceso; }
            set { proceso = value; }
        }      
    }
}
