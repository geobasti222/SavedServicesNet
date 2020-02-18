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
    public class ReporteVentas : IReporteVentas
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReporteVentas module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReporteVentas()
        {
            module = new Application.Enterprise.Data.ReporteVentas();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReporteVentas(string databaseName)
        {
            module = new Application.Enterprise.Data.ReporteVentas(databaseName);
        }

        #region Miembros de IReporteVentas

        public List<ReporteVentasInfo> TraerRegistroDeVentasEIngresos(DateTime fecha_ini, DateTime fecha_fin)
        {
            return module.TraerRegistroDeVentasEIngresos(fecha_ini, fecha_fin);//, campana_actual, campana_anterior, region, zona, grupo
        }

        public List<ReporteVentasInfo> TraerRegistroDeVentasEIngresosM(DateTime fecha_ini, DateTime fecha_fin)
        {
            return module.TraerRegistroDeVentasEIngresosM(fecha_ini, fecha_fin);//, campana_actual, campana_anterior, region, zona, grupo
        }

        public List<ReporteVentasInfo> TraerRegistroDeVentasEIngresosIquitos(DateTime fecha_ini, DateTime fecha_fin)
        {
            return module.TraerRegistroDeVentasEIngresosIquitos(fecha_ini, fecha_fin);//, campana_actual, campana_anterior, region, zona, grupo
        }

        #endregion
    }
}
