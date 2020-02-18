using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// JA
    /// </summary>
    
    public class clasificacionPorValorInfo
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

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private string clasificacion;
        /// <summary>
        /// 
        /// </summary>
        public string Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private int fc;
        /// <summary>
        /// 
        /// </summary>
        public int FC
        {
            get { return fc; }
            set { fc = value; }
        }

        private int op;
        /// <summary>
        /// 
        /// </summary>
        public int OP
        {
            get { return op; }
            set { op = value; }
        }

        private int fcesc;
        /// <summary>
        /// 
        /// </summary>
        public int FCesc
        {
            get { return fcesc; }
            set { fcesc = value; }
        }

        private int opesc;
        /// <summary>
        /// 
        /// </summary>
        public int OPesc
        {
            get { return opesc; }
            set { opesc = value; }
        }

        private int cxv_total;
        /// <summary>
        /// 
        /// </summary>
        public int Cxv_Total
        {
            get { return cxv_total; }
            set { cxv_total = value; }
        }

    }
}
