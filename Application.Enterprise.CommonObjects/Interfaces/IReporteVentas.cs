using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ReporteVentas
    /// </summary>
    public interface IReporteVentas
    {
        #region "Metodos de ReportePedidos"

        List<ReporteVentasInfo> TraerRegistroDeVentasEIngresos(DateTime fecha_ini, DateTime fecha_fin);

        List<ReporteVentasInfo> TraerRegistroDeVentasEIngresosM(DateTime fecha_ini, DateTime fecha_fin);

        List<ReporteVentasInfo> TraerRegistroDeVentasEIngresosIquitos(DateTime fecha_ini, DateTime fecha_fin);
        
        #endregion
    }
}
