using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Catalogo Plu
    /// </summary>
    public interface ICatalogoPlu
    {
        #region "Metodos de CatalogoPlu"

        /// <summary>
        /// Lista todos los catalogos x plus.
        /// </summary>
        /// <returns></returns>
        List<CatalogoPluInfo> List();

        /// <summary>
        /// Lista un catalogo x plus x id Codigo Rapido x catalogo unico.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        CatalogoPluInfo ListxIdCodigoRapidoUnico(string IdCodigoRapido, string Catalogo);

        /// <summary>
        /// Lista todos los catalogos x plus x catalogo
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        List<CatalogoPluInfo> ListxIdCodigoRapidoxCatalogo(string Catalogo);

        /// <summary>
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        CatalogoPluInfo ListxCodigoRapidoSinCatalogo(string IdCodigoRapido);

        /// <summary>
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo sin bloqueo de visible POS.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        CatalogoPluInfo ListxCodigoRapidoSinCatalogoSinBloqueo(string IdCodigoRapido);


        /// <summary>
        /// Listar todos los catalogos
        /// </summary>
        /// <returns></returns>
        List<CatalogoPluInfo> ListCatalogos();

        /// <summary>
        /// Lista un articulo por codigo rapido digitado sin dependencia de catalogo inactivo x agotado anunciado.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        CatalogoPluInfo ListxCodigoRapidoSinCatalogoAgotadoAnunciado(string IdCodigoRapido);

        /// <summary>
        /// Lista un articulo por codigo rapido digitado con dependencia de catalogo x zona.
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        CatalogoPluInfo ListxCodigoRapidoSinCatalogoxZona(string IdCodigoRapido, string Zona);

        /// <summary>
        /// Actualiza campo activo x plus Por catalog
        /// </summary>
        /// <param name="catalogo"></param>
        /// <param name="plu"></param>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool ActualizaXPlu(string catalogo, int plu, int estado, string usuario);

        /// <summary>
        /// Actualiza campo activo de todos los catalogos
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool ActualizaTodo(int estado, string usuario);

             /// <summary>
        /// Guarda cargue catalogo
        /// </summary>
        /// <param name="item"></param>
        int Insert(CatalogoPluInfo item,String usuario);
        
         /// <summary>
      /// obtener critero o unineg de siesa de un item.
      /// </summary>
      /// <param name="IdCodigoRapido"></param>
      /// <returns></returns>
        CatalogoPluInfo itemcriterio(string IdCodigoRapido);


        /// <summary>
        /// obtiene un catalogoplu con los puntos
        /// </summary>
        /// <param name="IdCodigoRapido"></param>
        /// <returns></returns>
        CatalogoPluInfo catalogoPlupuntos(string idcorto);
        
        
        #endregion
    }
}

