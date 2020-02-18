using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Kardex
    /// </summary>
    public class Kardex : IKardex
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Kardex module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Kardex()
        {
            module = new Application.Enterprise.Data.Kardex();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Kardex(string databaseName)
        {
            module = new Application.Enterprise.Data.Kardex(databaseName);
        }

        #region Miembros de IKardex
        /// <summary>
        /// Lista todos los kardex
        /// </summary>
        /// <returns></returns>
        public List<KardexInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los kardex de un catalogo especifico
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogo(string Catalogo)
        {
            return module.ListxCatalogo(Catalogo);
        }

        /// <summary>
        /// Lista todos los kardex del catalogo actual
        /// </summary>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoActual()
        {
            return module.ListxCatalogoActual();
        }

        /// <summary>
        /// Consulta de los articulos por una referencia talla y color
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoTalla"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxArticuloxRefxTalxCol(string Referencia, string CodigoTalla, string CodigoColor, string Catalogo)
        {
            return module.ListxArticuloxRefxTalxCol(Referencia, CodigoTalla, CodigoColor, Catalogo);
        }

        /// <summary>
        /// Lista el nombre de un producto por referencia.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public KardexInfo ListxNombrexReferencia(string Referencia)
        {
            return module.ListxNombrexReferencia(Referencia);
        }

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo actual para el Outlet
        /// </summary>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoActualOutlet()
        {
            return module.ListxCatalogoActualOutlet();
        }

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo seleccionado
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoPedidos(string Catalogo)
        {
            return module.ListxCatalogoPedidos(Catalogo);
        }

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo seleccionado x catalogo y x Referencia
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoPedidosxReferencia(string Catalogo, string Referencia)
        {
            return module.ListxCatalogoPedidosxReferencia(Catalogo, Referencia);
        }

        /// <summary>
        /// Lista todos los kardex (referencias) del catalogo seleccionado x catalogo y x Referencia de MKT
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<KardexInfo> ListReferenciasXCatalogoEspecificoMKT(string Catalogo)
        {
            return module.ListReferenciasXCatalogoEspecificoMKT(Catalogo);
        }

        /// <summary>
        /// Consulta de los articulos por una PLU
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxArticuloxPLU(int PLU)
        {
            return module.ListxArticuloxPLU(PLU);
        }

        /// <summary>
        /// Consulta de los articulos por una PLU para ver valor catalogoplus
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxArticuloxPLUJUTA(int PLU)
        {
            return module.ListxArticuloxPLUJUTA(PLU);
        }

        /// <summary>
        /// Consulta si exite el grupo de prodcuto de un articulo por un PLU para que sume al valor de descuento 
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxGrupoProductoxPLU(int PLU)
        {
            return module.ListxGrupoProductoxPLU(PLU);
        }

        /// <summary>
        /// Consulta si exite el articulo es agotado anunciado.
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxVisiblePOS(int PLU)
        {
            return module.ListxVisiblePOS(PLU);
        }

        /// <summary>
        /// Consulta de los articulos por una PLU
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxArticuloxPLUExtensiones(int PLU)
        {
            return module.ListxArticuloxPLUExtensiones(PLU);
        }

        #region Actualiza Unidad de Negocio Configuracion Descuentos NIVI Especial

        /// <summary>
        /// Actualiza campo unidadad de negocio Segun la referencia para Activa 50% NIVI ESPECIAL
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaUnidadXReferencia(string Referencia, string UnidadNegocio, string usuario)
        {
            return module.ActualizaUnidadXReferencia(Referencia, UnidadNegocio, usuario);
        }

        #endregion

        #endregion

        #region Metodos del Buscador

        /// <summary>
        ///  Mapeo de los criterios de busqueda seleccionados por el usuario con los campos originales de la base de datos
        /// </summary>
        /// <param name="language">Idioma</param>
        /// <returns>Lista de mapero para el buscador</returns>
        public TableMapping SearchMapping(string language)
        {
            return module.SearchMapping(language);

        }

        /// <summary>
        /// Consulta los articulos existentes.
        /// </summary>
        /// <param name="lstItem">lista de condiciones a buscar.</param>
        /// <returns>resultado de los articulos encontrados.</returns>
        public List<KardexInfo> ListSearch(List<SearchCondition> lstItem)
        {
            string filter = SearchCondition.GetFilterQueryList(lstItem);
            return module.ListSearch(filter);
        }

        /// <summary>
        /// Consulta los articulos de premios existentes.
        /// </summary>
        /// <param name="lstItem">lista de condiciones a buscar.</param>
        /// <returns>resultado de los articulos de premios encontrados.</returns>
        public List<KardexInfo> ListSearchPremios(List<SearchCondition> lstItem)
        {
            string filter = SearchCondition.GetFilterQueryList(lstItem);
            return module.ListSearchPremios(filter);
        }

        #endregion
    }
}
