using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Agotados
    /// </summary>
    public class ReglasPremios : IReglasPremios
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglaPremios module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasPremios()
        {
            module = new Application.Enterprise.Data.ReglaPremios();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasPremios(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglaPremios(databaseName);
        }

        /// <summary>
        /// lista todos las zonas de esa regla
        /// </summary>
        /// <returns></returns>
        public List<ZonasPremiosInfo> ListZonas(int regla)
        {
            return module.ListZonas(regla);
        }


        /// <summary>
        /// lista todos los estados de esa regla
        /// </summary>
        /// <returns></returns>
        public List<EstadosPremiosInfo> ListEstados(int regla)
        {
            return module.ListEstados(regla);
        }


        /// <summary>
        /// lista todos los estados de esa regla
        /// </summary>
        /// <returns></returns>
        public List<PremiosPremiosInfo> ListPremios(int regla)
        {
            return module.ListPremios(regla);
        }


         /// <summary>
        /// lista un producto 
        /// </summary>
        /// <returns></returns>
        public PLUInfo producto(string plu, string referencia)
        {
            return module.producto(plu, referencia);
        }

        /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglaPremiosInfo> ListReglas(string campana)
        {
            return module.ListReglas(campana);
        }


        /// <summary>
        /// Guarda una regla premio nueva
        /// </summary>
        /// <param name="item"></param>
        public int InsertRegla(ReglaPremiosInfo item, string usuario) {
            return module.InsertRegla(item, usuario);
        }


        /// <summary>
        /// Guarda zonas de la regla premio
        /// </summary>
        /// <param name="item"></param>
        public int Insertzonas(ZonasPremiosInfo item, string usuario) {
            return module.Insertzonas(item, usuario);
        }


        /// <summary>
        /// Guarda estados de la regla premio
        /// </summary>
        /// <param name="item"></param>
        public int Insertestados(EstadosPremiosInfo item, string usuario)
        {
            return module.Insertestados(item, usuario);
        }


        /// <summary>
        /// Guarda estados de la regla premio
        /// </summary>
        /// <param name="item"></param>
        public int Insertpremios(PremiosPremiosInfo item, string usuario) {
            return module.Insertpremios(item, usuario);
        }


         /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        public ReglaPremiosInfo Reglaconse()
        {
            return module.Reglaconse();
        }

        /// <summary>
        /// lista todos las reglas
        /// </summary>
        /// <returns></returns>
        public ReglaPremiosInfo Reglas(string id)
        {
            return module.Reglas(id);
        }

        /// <summary>
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public bool UpdateActivoRegla(int id, string Usuario, int activo)
        {
            return module.UpdateActivoRegla(id, Usuario, activo);
        }

        /// <summary>
        /// "borra" una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteReglas(int id, string Usuario)
        {
            return module.DeleteReglas(id, Usuario);
        }

        /// <summary>
        /// actualiza una regla premio nueva
        /// </summary>
        /// <param name="item"></param>
        public int UpdateRegla(ReglaPremiosInfo item, string usuario)
        {
            return module.UpdateRegla(item, usuario);
        }

        /// <summary>
        /// "borra" zonas de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteZonas(int id, string Usuario) {
            return module.DeleteZonas(id, Usuario);
        }

        /// <summary>
        /// "borra" estados de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteEstados(int id, string Usuario) {
            return module.DeleteEstados(id, Usuario);
        }

        /// <summary>
        /// "borra" zonas de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeletePremios(int id, string Usuario)
        {
            return module.DeletePremios(id, Usuario);
        }


        /// <summary>
        /// procesa los premios
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool procesar(string numero, string campana)
        {
            return module.procesar(numero, campana);
        }


         /// <summary>
        /// lista regla para mensaje
        /// </summary>
        /// <returns></returns>
        public ReglaPremiosInfo ReglaMensaje(string campana)
        {
            return module.ReglaMensaje(campana);
        }
        
         /// <summary>
        /// Trae catalogo real de un producto
        /// </summary>
        /// <returns></returns>
        public CatalogoPluInfo ReglaTraerCatalogoReal(string idcorto, string catalogo)
        {
            return module.ReglaTraerCatalogoReal(idcorto, catalogo);
        }
    }
}
