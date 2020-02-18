using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Color
    /// </summary>
    public interface IColor
    {
        #region "Metodos de Color"

        /// <summary>
        /// Lista todos los colores
        /// </summary>
        /// <returns></returns>
        List<ColorInfo> List();

         /// <summary>
        /// Lista los colores por referencia de articulo.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        List<ColorInfo> ListxRefencia(string Referencia, string Catalogo);

        /// <summary>
        /// Lista los colores por referencia de articulo para el catalogo outlet.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        List<ColorInfo> ListxRefenciaOutlet(string Referencia, string Catalogo);
        

        #endregion
    }
}

