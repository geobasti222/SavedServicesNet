using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Despachos
    /// </summary>
    public interface IDespachos
    {
        #region "Metodos de IDespachos"
        /// <summary>
        /// lista todos los despachos existentes.
        /// </summary>
        /// <returns></returns>
        List<DespachosInfo> List();

        /// <summary>
        /// Lista los despachos de un vendedor por campana.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<DespachosInfo> ListxVendedorxCampanaActual(string IdVendedor, string Campana);

        /// <summary>
        /// Lista los despachos x cedula de la empresaria o numero de pedido.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        List<DespachosInfo> ListxDespachoxCedulaxPedido(string Nit, string NumeroPedido);

         /// <summary>
        /// Lista los despachos de una empresaria por campana.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<DespachosInfo> ListxNitxCampanaActual(string Nit, string Campana);

         /// <summary>
        /// Lista los pedidos despachados de un lider x campaña.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<DespachosInfo> ListPedidosDespachadosxLider(string IdLider, string Campana);

        /// <summary>
        /// Ejecuta Consulta de informe de Despachos por MES
        /// </summary>
        /// <returns></returns>
        List<DespachosVInfo> ListXFecha(string Fecha);

        /// <summary>
        /// Lista los despachos de un vendedor por campana para Zona Maestra.
        /// </summary>
        /// <param name="ZonaMaestra"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        List<DespachosInfo> ListxVendedorxCampanaActualZonaMaestra(string ZonaMaestra, string Campana);

        #endregion
    }
}

