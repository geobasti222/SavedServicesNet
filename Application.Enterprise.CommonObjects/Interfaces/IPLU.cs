using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PLU
    /// </summary>
    public interface IPLU
    {
        #region "Metodos de PLU"

        /// <summary>
        /// Lista todos los PLU existentes
        /// </summary>
        /// <returns></returns>
        List<PLUInfo> List();

        /// <summary>
        /// Lista todos los PLU de una referencia existentes
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        List<PLUInfo> ListxReferencia(string Referencia);

        /// <summary>
        /// Consulta el articulo por medio del PLU.
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        PLUInfo ListxArticulosxPLU(int PLU);

        /// <summary>
        /// Consulta el articulo por medio del PLU por el tipo de precio. (Empresaria, Catalogo, Especial, Credito)
        /// </summary>
        /// <param name="PLU"></param>
        /// <param name="TipoPrecio"></param>
        /// <returns></returns>
        PLUInfo ListxArticulosxPLUxTipoPrecio(int PLU, string TipoPrecio);

        /// <summary>
        /// Lista todos los PLU de una referencia existentes
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        List<PLUInfoDto> ListCatalogoActual(string Campana);


        #endregion
    }
}

