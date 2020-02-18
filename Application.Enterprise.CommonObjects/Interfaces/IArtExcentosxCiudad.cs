using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de rtExcentosxCiudad
    /// </summary>
    public interface IArtExcentosxCiudad
    {
        #region "Metodos de Articulos Excentos x Ciudad"

        /// <summary>
        /// Lista todos los articulos exentos x ciudad.
        /// </summary>
        /// <returns></returns>
        List<ArtExcentosxCiudadInfo> List();

        /// <summary>
        /// Lista todos los articulos exentos x ciudad.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <param name="Plu"></param>
        /// <returns></returns>
        ArtExcentosxCiudadInfo ListxCiudadxPlu(string CodigoCiudad, int Plu);

        #endregion
    }
}

