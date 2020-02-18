using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IClienteSaldo
    {
        #region "Metodos de ClienteSaldo"

        ClienteSaldoInfo ListXNit(string nit, string mes);

        #endregion
    }
}
