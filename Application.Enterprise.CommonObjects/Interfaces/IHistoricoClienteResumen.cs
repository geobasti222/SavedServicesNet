using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Historico Cliente Resumen
    /// </summary>
    public interface IHistoricoClienteResumen
    {
        #region "Metodos de Historico Cliente Resumen"

        /// <summary>
        /// Cantidad de registros en Historico Resumen
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        HistoricoClienteResumenInfo CantidadRegistros(DateTime fecha);

        /// <summary>
        /// Insercion de los campos que se encuentran en SVDN_CLIENTES_HISTORICO y no se encuentran en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool InsertFromHistoricoToResumen(DateTime fecha);

        /// <summary>
        /// Se realiza reseteo de registros de prospectos campaña actual en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool ResetProspectosResumen(DateTime fecha);

        /// <summary>
        /// Actualizacion de los agrupamientos de estados en SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateCantidadEstados(DateTime fecha);

        /// <summary>
        /// Se eliminan los registros duplicados, dejando en todas las combinaciones una sola existencia de la tabla SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool DeleteRegistrosDuplicados(DateTime fecha);

        /// <summary>
        /// Eliminacion de todos los registros del resumen de la campaña  actual
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool VaciadoResumenCampanaActual(DateTime fecha);

        #endregion
    }
}
