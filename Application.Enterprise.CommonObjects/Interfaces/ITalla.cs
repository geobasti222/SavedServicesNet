using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Talla
    /// </summary>
    public interface ITalla
    {
        #region "Metodos de Talla"

        /// <summary>
        /// Lista todos las Tallas
        /// </summary>
        /// <returns></returns>
        List<TallaInfo> List();

        /// <summary>
        /// Lista una talla por referencia y color de articulo.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        List<TallaInfo> ListxReferenciaxColor(string Referencia, string CodigoColor, string Catalogo);

        /// <summary>
        /// Lista una talla por referencia y color de articulo para el catalogo outlet.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        List<TallaInfo> ListxReferenciaxColorOutlet(string Referencia, string CodigoColor, string Catalogo);


        #endregion
    }
}

