using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Catalogo  JA
    /// </summary>
    public interface ICatalogo
    {
        #region "Metodos de Catalogo"

        /// <summary>
        /// Lista todos los catalogos.
        /// </summary>
        /// <returns></returns>
        List<CatalogoInfo> List();

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        CatalogoInfo ListCatalogoActual();

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        List<CatalogoInfo> ListCatalogoFechaActual();

        /// <summary>
        /// Lista el catalogo de NIVI de la fecha actual.
        /// </summary>
        /// <returns></returns>
        CatalogoInfo ListCatalogoNIVIxFechaActual();

        /// <summary>
        /// Lista un catalogo x id.
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        List<CatalogoInfo> ListxId(string Catalogo);

        /// <summary>
        /// Lista un catalogo x campana.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        CatalogoInfo ListCatalogoxCampana(string Campana);

        /// <summary>
        /// Guarda un catalogo nuevo.
        /// </summary>
        /// <param name="item"></param>
        int Insert(CatalogoInfo item);

        /// <summary>
        /// Realiza la actualizacion de un catalogo existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(CatalogoInfo item);

        /// <summary>
        /// Realiza la consulta de las campañas que se interponen con otras.
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechafin"></param>
        /// <returns></returns>
        List<CatalogoInfo> ListCatalogoTrasponen(DateTime fechaini, DateTime fechafin);

        /// <summary>
        /// Busca el catalogo por codigo
        /// </summary>
        /// <param name="catalogo"></param>
        /// <returns></returns>
        CatalogoInfo ListxCodigo(string Catalogo);

        #endregion
    }
}

