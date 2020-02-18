using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ZonasPremiosInfo

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

        private int idregla;
        /// <summary>
        /// 
        /// </summary>
        public int IdRegla
        {
            get { return idregla; }
            set { idregla = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }
    }
}
