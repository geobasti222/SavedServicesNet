using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de CxC
    /// </summary>
    public interface ICxC
    {
        #region "Metodos de CxC"

        /// <summary>
        /// Lista todas las cuentas por cobrar (CxC).
        /// </summary>
        /// <returns></returns>
        List<CxCInfo> List();

        /// <summary>
        /// Lista el saldo de cartera de una empresaria por nit y por mes.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Mes"></param>
        /// <returns></returns>
        CxCInfo ListxNitxMes(string Nit, string Mes);

        #endregion
    }
}

