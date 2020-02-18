using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Despachos
    /// </summary>
    public class Despachos : IDespachos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Despachos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Despachos()
        {
            module = new Application.Enterprise.Data.Despachos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Despachos(string databaseName)
        {
            module = new Application.Enterprise.Data.Despachos(databaseName);
        }

        #region Miembros de IDespachos
        /// <summary>
        /// lista todos los despachos existentes.
        /// </summary>
        /// <returns></returns>
        public List<DespachosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista los despachos de un vendedor por campana.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxVendedorxCampanaActual(string IdVendedor, string Campana)
        {
            return module.ListxVendedorxCampanaActual(IdVendedor, Campana);
        }

        /// <summary>
        /// Lista los despachos x cedula de la empresaria o numero de pedido.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxDespachoxCedulaxPedido(string Nit, string NumeroPedido)
        {
            return module.ListxDespachoxCedulaxPedido(Nit, NumeroPedido);
        }

         /// <summary>
        /// Lista los despachos de una empresaria por campana.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxNitxCampanaActual(string Nit, string Campana)
        {
            return module.ListxNitxCampanaActual(Nit, Campana);
        }

        
        /// <summary>
        /// Lista los pedidos despachados de un lider x campaña.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListPedidosDespachadosxLider(string IdLider, string Campana)
        {
            return module.ListPedidosDespachadosxLider(IdLider, Campana);
        }

        /// <summary>
        ///  Ejecuta Consulta de informe de Despachos por MES
        /// </summary>
        /// <returns></returns>
        public List<DespachosVInfo> ListXFecha(string Fecha)
        {
            return module.ListXFecha(Fecha);
        }

        /// <summary>
        /// Lista los despachos de un vendedor por campana para Zona Maestra.
        /// </summary>
        /// <param name="ZonaMaestra"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxVendedorxCampanaActualZonaMaestra(string ZonaMaestra, string Campana)
        {
            return module.ListxVendedorxCampanaActualZonaMaestra(ZonaMaestra, Campana);
        }

        #endregion

        #region Asistentes
        /// <summary>
        /// -- GAVL  Lista los despachos de un vendedor X Asistente por campana.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxVendedorxCampanaActualxAsistente(string IdVendedor, string Campana)
        {
            return module.ListxVendedorxCampanaActualxAsistente(IdVendedor, Campana);
        }
        #endregion
    }
}
