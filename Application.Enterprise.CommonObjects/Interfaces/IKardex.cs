using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Kardex
    /// </summary>
    public interface IKardex
    {
        #region "Metodos de Kardex"

        /// <summary>
        /// Lista todos los kardex
        /// </summary>
        /// <returns></returns>
        List<KardexInfo> List();

        /// <summary>
        /// Lista todos los kardex de un catalogo especifico
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        List<KardexInfo> ListxCatalogo(string Catalogo);

        /// <summary>
        /// Lista todos los kardex del catalogo actual
        /// </summary>
        /// <returns></returns>
        List<KardexInfo> ListxCatalogoActual();

        /// <summary>
        /// Consulta de los articulos por una referencia talla y color
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoTalla"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        List<KardexInfo> ListxArticuloxRefxTalxCol(string Referencia, string CodigoTalla, string CodigoColor, string Catalogo);

        /// <summary>
        /// Lista el nombre de un producto por referencia.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        KardexInfo ListxNombrexReferencia(string Referencia);

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo actual para el Outlet
        /// </summary>
        /// <returns></returns>
        List<KardexInfo> ListxCatalogoActualOutlet();

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo seleccionado
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        List<KardexInfo> ListxCatalogoPedidos(string Catalogo);

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo seleccionado x catalogo y x Referencia
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        List<KardexInfo> ListxCatalogoPedidosxReferencia(string Catalogo, string Referencia);

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo seleccionado x catalogo y x Referencia de MKT
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        List<KardexInfo> ListReferenciasXCatalogoEspecificoMKT(string Catalogo);

        /// <summary>
        /// Consulta de los articulos por una PLU
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        KardexInfo ListxArticuloxPLU(int PLU);

        /// <summary>
        /// Consulta si exite el grupo de prodcuto de un articulo por un PLU para que sume al valor de descuento 
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        KardexInfo ListxGrupoProductoxPLU(int PLU);

        /// <summary>
        /// Consulta si exite el articulo es agotado anunciado.
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        KardexInfo ListxVisiblePOS(int PLU);

        /// <summary>
        /// Consulta de los articulos por una PLU
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        KardexInfo ListxArticuloxPLUExtensiones(int PLU);

        #endregion

        #region Metodos del Buscador

        /// <summary>
        /// Obtiene la tabla de mapeo para el buscador.
        /// </summary>
        /// <param name="language">Lenguaje.</param>
        /// <returns>Tabla de mapeo.</returns>
        TableMapping SearchMapping(string language);

        /// <summary>
        /// realiza la busqueda de los articulos por medio del buscador.
        /// </summary>
        /// <param name="lstItem">Lista de parametros para el filtro de busqueda.</param>
        /// <returns>Lista de articulos encontradas.</returns>
        List<KardexInfo> ListSearch(List<SearchCondition> lstItem);


        /// <summary>
        /// realiza la busqueda de los articulos de premios por medio del buscador.
        /// </summary>
        /// <param name="lstItem">Lista de parametros para el filtro de busqueda.</param>
        /// <returns>Lista de articulos de premios encontradas.</returns>
        List<KardexInfo> ListSearchPremios(List<SearchCondition> lstItem);


        #endregion
    }
}

