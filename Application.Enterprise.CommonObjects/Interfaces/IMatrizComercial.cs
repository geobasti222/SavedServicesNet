using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Matriz Comercial
    /// </summary>
    public interface IMatrizComercial
    {
        #region "Metodos de Matriz Comercial"

        /// <summary>
        /// lista el estado del stencil con informacion resumida.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="TipoAgrupamiento">1) por Zona,  2) por Region,  3) Sin Agrupamiento(todos los registros)</param>
        /// <returns></returns>
        MatrizComercialInfo ListEstadoStencilResumen(MatrizComercialInfo item, int TipoAgrupamiento, string mailgroup = null);
                
        /// <summary>
        /// Lista el informe de estado del stencil con el resumen del Historico_Clientes por cada Zona de una Campaña especifica.
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        List<MatrizComercialInfo> ListEstadoStencilResumenZonas(string campana, string mailgroup, int CodReg);

        /// <summary>
        /// Lista de Matriz Comercial agrupada por Regional vista por columnas
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        List<MatrizComercialInfo> ListEstadoStencilResumenRegional(string campana);

        /// <summary>
        /// Lista de Matriz Comercial agrupada por Mailgroup vista por columnas
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        List<MatrizComercialInfo> ListEstadoStencilResumenMailgroup(string campana);

        ///// <summary>
        ///// Visualiza todas las zonas de un Mailgroup especifico
        ///// </summary>
        ///// <param name="campana"></param>
        ///// <param name="mailgroup"></param>
        ///// <returns></returns>
        //List<MatrizComercialInfo> ListEstadoStencilResumenZonasMG(string campana, string mailgroup);

        #endregion
    }
}

