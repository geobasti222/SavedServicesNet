using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IPremiosWinform
    {
        #region "Metodos de PremiosWinform"
                
        /// <summary>
        /// Lista todos los premioswinform
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="MinimoPuntos"></param>
        /// <param name="lReferenciasCorrea"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <returns></returns>
        List<PremiosWinformInfo> List(string Campana, string MinimoPuntos, List<string> lReferenciasCorrea, List<string> lPLUExcluidas, string CampanaEntrega);       

        /// <summary>
        /// Lista la cantidad solicitada de resultados
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="MinimoPuntos"></param>
        /// <param name="CantResults"></param>
        /// <param name="lReferenciasCorrea"></param>
        /// <param name="RefContenedora"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <returns></returns>
        List<PremiosWinformInfo> ListCantidadSolicitada(string Campana, string MinimoPuntos, string CantResults, List<string> lReferenciasCorrea, string RefContenedora, List<string> lPLUExcluidas, string CampanaEntrega);        

        /// <summary>
        /// Lista todos los premioswinform adicionando puntos sobrantes
        /// </summary>
        /// <param name="lReferenciasCorrea"></param>
        /// <param name="CampanaPremio"></param>
        /// <param name="MinimoPuntos"></param>
        /// <param name="ReferenciaPremio"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <returns></returns>
        List<PremiosWinformInfo> ListSobrantes(List<string> lReferenciasCorrea, string CampanaPremio, string MinimoPuntos, string ReferenciaPremio, List<string> lPLUExcluidas, string CampanaEntrega, string PedidoMinimo);                
                
        /// <summary>
        /// Lista todos los premioswinform adicionando puntos acumulados
        /// </summary>
        /// <param name="lReferenciasCorrea"></param>
        /// <param name="MinimoPuntos"></param>
        /// <param name="RefContenedora"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <returns></returns>
        List<PremiosWinformInfo> ListAcumulados(char opcAcum, string MinimoPuntos, List<string> lReferenciasCorrea, string RefContenedora, string CampanaPremio, List<string> lPLUExcluidas, string CampanaEntrega, string PedidoMinimo, bool IncluyePadre);        

        /// <summary>
        /// Lista los detalles de un pedido de acuerdo a una cedula y  campaña, se incluyen las referencias a excluir
        /// </summary>
        /// <param name="CampanaPremio"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        List<PremiosWinformPedidoInfo> ListPedidoDetalle(string CampanaPremio, List<string> lPLUExcluidas, string Cedula, string NroPedido);        

        /// <summary>
        /// Lista los detalles de unan devolucion de acuerdo a una cedula y campaña, se incluyen las referencias a excluir
        /// </summary>
        /// <param name="CampanaPremio"></param>
        /// <param name="lReferenciasExcluidas"></param>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        List<PremiosWinformPedidoInfo> ListDevolucionDetalle(string CampanaPremio, List<string> lPLUExcluidas, string Cedula);        

        #endregion
    }
}
