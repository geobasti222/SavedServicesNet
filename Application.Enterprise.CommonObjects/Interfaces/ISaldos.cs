using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Saldos
    /// </summary>
    public interface ISaldos
    {
        #region "Metodos de Saldos"
        /// <summary>
        /// Lista todos los saldos de una empresaria x campana detallado.
        /// </summary>
        /// <param name="objSaldos"></param>
        /// <returns></returns>
        List<SaldosInfo> ListxNitxCampana(SaldosInfo objSaldos);

        #endregion
    }
}

