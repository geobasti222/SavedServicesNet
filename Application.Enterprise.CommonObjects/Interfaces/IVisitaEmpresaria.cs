using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de VisitaEmpresaria
    /// </summary>
    public interface IVisitaEmpresaria
    {
        #region "Metodos de VisitaEmpresaria"

        /// <summary>
        /// Lista todos las visitas de empresarias existentes.
        /// </summary>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> List();

        /// <summary>
        /// Lista todos las visitas de empresarias existentes x zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxZona(string Zona);

        /// <summary>
        /// Reporte General de visitas a empresarias x fecha.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReporteGeneral(DateTime FechaDesde, DateTime FechaHasta);

        /// <summary>
        /// Reporte General de visitas a empresarias x fecha.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReporteFiltrosGeneral(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias para todos los filtros sin seleccionar uno solo.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReporteSinFiltros(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x estados de empresarias
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexEstadoEmpresaria(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Zona
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexZona(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Division
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexDivision(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Division x Campaña
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexDivisionxCampana(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Division x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexDivisionxEstado(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Zona x Campaña
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexZonaxCampana(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Zona x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexZonaxEstado(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Campaña x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexCampanaxEstado(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x Division x Zona x Campaña x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        List<VisitaEmpresariaInfo> ListxReportexDivisionxZonaxCampanaxEstado(VisitaEmpresariaInfo item);

        /// <summary>
        /// Lista todos las visitas de empresarias x campañas
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        //List<VisitaEmpresariaInfo> ListxReportexCampanas(VisitaEmpresariaInfo item);

        /// <summary>
        /// Guarda una visita a empresaria.
        /// </summary>
        /// <param name="item"></param>
        int Insert(VisitaEmpresariaInfo item);

        /// <summary>
        /// Realiza la actualizacion de una visita a empresaria.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(VisitaEmpresariaInfo item);

        /// <summary>
        /// Elimina una visita a empresaria.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool Delete(int Id, string Usuario);

        #endregion
    }
}

