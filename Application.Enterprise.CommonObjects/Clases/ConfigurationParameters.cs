using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enterprise.CommonObjects
{
    public class ConfigurationParameters
    {
        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        public virtual String Error
        {
            get;
            set;
        }

    }
}
