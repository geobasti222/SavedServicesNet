using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PremiosPuntosTotal
    /// </summary>
    public interface IPremiosPuntosTotal
    {
        #region "Metodos de PremiosPuntosTotal"

        /// <summary>
        /// Lista los puntos totales de un premio especifico
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        List<PremiosPuntosTotalInfo> ListxPremio(int IdPremio);

        /// <summary>
        /// actualiza los puntos de un cliente a 0 (cero) por que ya se le asigno un premio.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        bool UpdatePuntos(string Nit);

        #endregion
    }
}

