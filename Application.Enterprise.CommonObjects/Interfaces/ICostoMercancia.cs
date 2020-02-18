using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ICostoMercancia
    /// </summary>
    public interface ICostoMercancia
    {
        #region "Metodos de CostoMercancia"

        /// <summary>
        /// Lista todos los costos de mercancia.
        /// </summary>
        /// <returns></returns>
        List<CostoMercanciaInfo> List();

        #endregion
    }
}

