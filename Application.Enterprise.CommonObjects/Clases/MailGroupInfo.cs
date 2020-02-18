using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class MailGroupInfo
    {
        private int mailgroup;
        /// <summary>
        /// 
        /// </summary>
        public int MailGroup
        {
            get { return mailgroup; }
            set { mailgroup = value; }
        }

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre.Trim(); }
            set { nombre = value; }
        }      
    }
}
