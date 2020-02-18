using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ProcesamientosCampanaInfo
    {
        private int processcampanaid;
        /// <summary>
        /// 
        /// </summary>
        public int ProcessCampanaId
        {
            get { return processcampanaid; }
            set { processcampanaid = value; }
        }

        private int processid;
        /// <summary>
        /// 
        /// </summary>
        public int ProcessId
        {
            get { return processid; }
            set { processid = value; }
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

        private DateTime fechainicial;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaInicial
        {
            get { return fechainicial; }
            set { fechainicial = value; }
        }

        private DateTime fechafinal;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaFinal
        {
            get { return fechafinal; }
            set { fechafinal = value; }
        }
    }
}
