using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PremiosPuntosTotalSep
    /// </summary>
    public interface IPremiosPuntosTotalSep
    {
        #region "Metodos de PremiosPuntosTotal Separado"

        /// <summary>
        /// Lista los puntos totales de un premio especifico de niveles separados
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        List<PremiosPuntosTotalSepInfo> ListxPremio(int IdPremio);

        /// <summary>
        /// Lista los nit que contienen puntos de un premio y nivel
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        List<PremiosPuntosTotalSepInfo> ListNitPuntosxPremio(int IdPremio);

         /// <summary>
        /// Lista los puntos que contienen un nit por nivel.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdNivel"></param>
        /// <returns></returns>
        List<PremiosPuntosTotalSepInfo> ListPuntosxNitxNivel(string Nit, int IdNivel);

        /// <summary>
        ///  actualiza los puntos de un cliente a 0 (cero) por que ya se le asigno un premio.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdNivel"></param>
        /// <returns></returns>
        bool UpdatePuntos(string Nit, int IdNivel);

        #endregion
    }
}

