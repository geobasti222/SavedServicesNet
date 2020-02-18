using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Premios Articulos
    /// </summary>
    public interface IPremiosArticulos
    {
        #region "Metodos de Premios Articulos"

        /// <summary>
        /// Lista todos los articulos de los premios.
        /// </summary>
        /// <returns></returns>
        List<PremiosArticulosInfo> List();

        /// <summary>
        /// Lista un articulo de un id especifico.
        /// </summary>
        /// <param name="IdArticulo"></param>
        /// <returns></returns>
        PremiosArticulosInfo ListxId(int IdArticulo);

        /// <summary>
        /// Lista todos los articulos de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        List<PremiosArticulosInfo> ListxPremio(int IdPremio);

        /// <summary>
        /// Realiza el registro de articulo para un premio.
        /// </summary>
        /// <param name="item"></param>
        int Insert(PremiosArticulosInfo item);
        
        
        #endregion
    }
}

