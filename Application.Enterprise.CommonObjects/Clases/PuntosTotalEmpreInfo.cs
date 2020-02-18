using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PuntosTotalEmpreInfo
    {
        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        private int puntoped;
        /// <summary>
        /// 
        /// </summary>
        public int PuntoPed
        {
            get { return puntoped; }
            set { puntoped = value; }
        }

        private int puntoefec;
        /// <summary>
        /// 
        /// </summary>
        public int Puntoefec
        {
            get { return puntoefec; }
            set { puntoefec = value; }
        }

        private int puntored;
        /// <summary>
        /// 
        /// </summary>
        public int Puntored
        {
            get { return puntored; }
            set { puntored = value; }
        }

        private int total;
        /// <summary>
        /// 
        /// </summary>
        public int Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}
