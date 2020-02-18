using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ClienteSaldoInfo
    {
        private string nit;

        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        private decimal saldo;

        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
    }
}
