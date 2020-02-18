using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class ClienteSaldo:IClienteSaldo
    {

        private Application.Enterprise.Data.ClienteSaldo module;

        public ClienteSaldo()
        {
            module = new Application.Enterprise.Data.ClienteSaldo();
        }

        public ClienteSaldo(string databaseName)
        {
            module = new Application.Enterprise.Data.ClienteSaldo(databaseName);
        }

        #region Miembros de IClienteSaldo

        public ClienteSaldoInfo ListXNit(string nit, string mes)
        {
            return module.ListXNit(nit, mes);
        }

        #endregion
    }
}
