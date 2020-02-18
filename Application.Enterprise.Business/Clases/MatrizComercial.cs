using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para MatrizComercial
    /// </summary>
    public class MatrizComercial : IMatrizComercial
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.MatrizComercial module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public MatrizComercial()
        {
            module = new Application.Enterprise.Data.MatrizComercial();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public MatrizComercial(string databaseName)
        {
            module = new Application.Enterprise.Data.MatrizComercial(databaseName);
        }

        #region Miembros de IMatrizComercial
        /// <summary>
        /// lista el estado del stencil con informacion resumida.
        /// </summary>
        /// <param name="item">Objeto Tipo MatrizComercialInfo</param>
        /// <param name="TipoAgrupamiento">1) por Zona,  2) por Region,  3) Sin Agrupamiento(todos los registros)</param>
        /// <returns></returns>
        public MatrizComercialInfo ListEstadoStencilResumen(MatrizComercialInfo item, int TipoAgrupamiento, string mailgroup = null)
        {
            if (mailgroup != null)
                return module.ListEstadoStencilResumen(item, TipoAgrupamiento, mailgroup);
            else
                return module.ListEstadoStencilResumen(item, TipoAgrupamiento);
        }

        /// <summary>
        /// Lista el informe de estado del stencil con el resumen del Historico_Clientes por cada Zona de una Campaña especifica.
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<MatrizComercialInfo> ListEstadoStencilResumenZonas(string campana, string mailgroup, int CodReg)
        {
            return module.ListEstadoStencilResumenZonas(campana, mailgroup, CodReg);
        }

        /// <summary>
        /// Lista de Matriz Comercial agrupada por Regional vista por columnas
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<MatrizComercialInfo> ListEstadoStencilResumenRegional(string campana)
        {
            return module.ListEstadoStencilResumenRegional(campana);
        }

        /// <summary>
        /// Lista de Matriz Comercial agrupada por Mailgroup vista por columnas
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<MatrizComercialInfo> ListEstadoStencilResumenMailgroup(string campana)
        {
            return module.ListEstadoStencilResumenMailgroup(campana);
        }

        #endregion
    }
}
