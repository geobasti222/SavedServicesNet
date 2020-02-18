using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ISaldosBodega
    /// </summary>
    public interface ISaldosBodega
    {
        #region "Metodos de SaldosBodega"

        /// <summary>
        /// Lista todos los saldos bodega existentes.
        /// </summary>
        /// <returns></returns>
        List<SaldosBodegaInfo> List();

        #endregion
    }
}

