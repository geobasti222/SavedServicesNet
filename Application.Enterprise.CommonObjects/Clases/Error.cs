using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enterprise.CommonObjects
{
    public class Error 
    {
        public virtual bool existError
        {
            get;
            set;
        }

		public string Descripcion
        {
            get;
            set;
        }

        public virtual int Id
        {
            get;
            set;
        }


    }
}
