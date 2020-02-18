using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CampanaListInfo
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

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }


        private string tipopuntos;
        /// <summary>
        /// 
        /// </summary>
        public string TipoPuntos
        {
            get { return tipopuntos; }
            set { tipopuntos = value; }
        }
    }
}
