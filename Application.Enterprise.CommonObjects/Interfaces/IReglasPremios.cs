using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;


namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IReglasPremios
    {
        /// <summary>
        /// lista todos las zonas de esa regla
        /// </summary>
        /// <returns></returns>
        List<ZonasPremiosInfo> ListZonas(int regla);

        /// <summary>
        /// lista todos los estados de esa regla
        /// </summary>
        /// <returns></returns>
        List<EstadosPremiosInfo> ListEstados(int regla);


        /// <summary>
        /// lista todos los premios de esa regla
        /// </summary>
        /// <returns></returns>
        List<PremiosPremiosInfo> ListPremios(int regla);
        

         /// <summary>
        /// lista un producto 
        /// </summary>
        /// <returns></returns>
        PLUInfo producto(string plu, string referencia);

        /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        List<ReglaPremiosInfo> ListReglas(string campana);
        
        
        /// <summary>
        /// Guarda una regla premio nueva
        /// </summary>
        /// <param name="item"></param>
        int InsertRegla(ReglaPremiosInfo item, string usuario);

        /// <summary>
        /// Guarda zonas de la regla premio
        /// </summary>
        /// <param name="item"></param>
        int Insertzonas(ZonasPremiosInfo item, string usuario);

        /// <summary>
        /// Guarda estados de la regla premio
        /// </summary>
        /// <param name="item"></param>
         int Insertestados(EstadosPremiosInfo item, string usuario);

         /// <summary>
        /// Guarda estados de la regla premio
        /// </summary>
        /// <param name="item"></param>
         int Insertpremios(PremiosPremiosInfo item, string usuario);
        
         /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
         ReglaPremiosInfo Reglaconse();

        /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
         ReglaPremiosInfo Reglas(string id);

        /// <summary>
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
         bool UpdateActivoRegla(int id, string Usuario, int activo);


        /// <summary>
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool DeleteReglas(int id, string Usuario);

        /// <summary>
        /// actualiza una regla premio nueva
        /// </summary>
        /// <param name="item"></param>
        int UpdateRegla(ReglaPremiosInfo item, string usuario);

        /// <summary>
        /// "borra" zonas de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool DeleteZonas(int id, string Usuario);

        /// <summary>
        /// "borra" estados de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool DeleteEstados(int id, string Usuario);

        /// <summary>
        /// "borra" zonas de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool DeletePremios(int id, string Usuario);

        /// <summary>
        /// procesa los premios
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool procesar(string numero, string campana);

        /// <summary>
        /// lista regla para mensaje
        /// </summary>
        /// <returns></returns>
        ReglaPremiosInfo ReglaMensaje(string campana);
        
         /// <summary>
        /// Trae catalogo real de un producto
        /// </summary>
        /// <returns></returns>
        CatalogoPluInfo ReglaTraerCatalogoReal(string idcorto, string catalogo);
        
        
    }
}
