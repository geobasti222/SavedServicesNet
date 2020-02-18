using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para zona
    /// </summary>
    public class ReportePedidos : IReportePedidos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReportePedidos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReportePedidos()
        {
            module = new Application.Enterprise.Data.ReportePedidos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReportePedidos(string databaseName)
        {
            module = new Application.Enterprise.Data.ReportePedidos(databaseName);
        }

        #region Miembros de IGruposUsuarios
        /// <summary>
        /// lista todas las GruposUsuarios existentes.
        /// </summary>
        /// <returns></returns>
        public List<ReportePedidosInfo> TraerPedidos(string campana_actual, string campana_anterior, string region, string zona, string grupo)//, string campana_actual, string campana_anterior, int region, string zona, string grupo
        {
            return module.TraerPedidos(campana_actual, campana_anterior, region, zona, grupo);//, campana_actual, campana_anterior, region, zona, grupo
        }

         /// <summary>
        /// traer todos los pedidos por campana y grupo
        /// </summary>
        /// <param name="campana_actual"></param>
        /// <param name="campana_anterior"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<ReportePedidosInfo> TraerPedidosTodos(string campana_actual, string campana_anterior, string grupo)
        {
            return module.TraerPedidosTodos(campana_actual,campana_anterior,grupo);
        }

         /// <summary>
       /// trae todos los pedidos digitados por grupo y por divisional y por rango de campana
       /// </summary>
       /// <param name="campana_actual"></param>
       /// <param name="campana_anterior"></param>
       /// <param name="divisional"></param>
       /// <param name="grupo"></param>
       /// <returns></returns>
        public List<ReportePedidosInfo> TraerPedidosDivisional(string campana_actual, string campana_anterior, string divisional, string grupo)
        {
            return module.TraerPedidosDivisional(campana_actual, campana_anterior, divisional, grupo);
        }


        /// <summary>
        /// trae todas los pedidos por portal y por zona y campana rango
        /// </summary>
        /// <param name="campana_actual"></param>
        /// <param name="campana_anterior"></param>
        /// <param name="divisional"></param>
        /// <param name="zona"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<ReportePedidosInfo> TraerPedidosZona(string campana_actual, string campana_anterior, string divisional, string zona, string grupo)
        {
            return module.TraerPedidosZona(campana_actual, campana_anterior, divisional, zona, grupo);
        }

        #endregion
    }
}
