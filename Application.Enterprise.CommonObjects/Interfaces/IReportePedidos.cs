using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ReportePedidos
    /// </summary>
    public interface IReportePedidos
    {
        #region "Metodos de ReportePedidos"

        List<ReportePedidosInfo> TraerPedidos(string campana_actual, string campana_anterior, string region, string zona, string grupo);

         /// <summary>
        /// traer todos los pedidos por campana y grupo
        /// </summary>
        /// <param name="campana_actual"></param>
        /// <param name="campana_anterior"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        List<ReportePedidosInfo> TraerPedidosTodos(string campana_actual, string campana_anterior, string grupo);


         /// <summary>
       /// trae todos los pedidos digitados por grupo y por divisional y por rango de campana
       /// </summary>
       /// <param name="campana_actual"></param>
       /// <param name="campana_anterior"></param>
       /// <param name="divisional"></param>
       /// <param name="grupo"></param>
       /// <returns></returns>
        List<ReportePedidosInfo> TraerPedidosDivisional(string campana_actual, string campana_anterior, string divisional, string grupo);
        
        
        /// <summary>
        /// trae todas los pedidos por portal y por zona y campana rango
        /// </summary>
        /// <param name="campana_actual"></param>
        /// <param name="campana_anterior"></param>
        /// <param name="divisional"></param>
        /// <param name="zona"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        List<ReportePedidosInfo> TraerPedidosZona(string campana_actual, string campana_anterior, string divisional, string zona, string grupo);
        

        #endregion
    }
}
