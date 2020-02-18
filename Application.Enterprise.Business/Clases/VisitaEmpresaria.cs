using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para VisitaEmpresaria
    /// </summary>
    public class VisitaEmpresaria : IVisitaEmpresaria
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.VisitaEmpresaria module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public VisitaEmpresaria()
        {
            module = new Application.Enterprise.Data.VisitaEmpresaria();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public VisitaEmpresaria(string databaseName)
        {
            module = new Application.Enterprise.Data.VisitaEmpresaria(databaseName);
        }

        #region Miembros de IVisitaEmpresaria
        /// <summary>
        /// Lista todos las visitas de empresarias existentes.
        /// </summary>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos las visitas de empresarias existentes x zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxZona(string Zona)
        {
            return module.ListxZona(Zona);
        }

        /// <summary>
        /// Reporte General de visitas a empresarias x fecha.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReporteGeneral(DateTime FechaDesde, DateTime FechaHasta)
        {
            return module.ListxReporteGeneral(FechaDesde, FechaHasta);
        }

        /// <summary>
        /// Reporte General de visitas a empresarias x fecha.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReporteFiltrosGeneral(VisitaEmpresariaInfo item)
        {
            return module.ListxReporteFiltrosGeneral(item);
        }

        /// <summary>
        /// Lista todos las visitas de empresarias para todos los filtros sin seleccionar uno solo.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReporteSinFiltros(VisitaEmpresariaInfo item)
        {
            return module.ListxReporteSinFiltros(item);
        }

        /// <summary>
        /// Lista todos las visitas de empresarias x estados de empresarias
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexEstadoEmpresaria(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexEstadoEmpresaria(item);
        }

         /// <summary>
        /// Lista todos las visitas de empresarias x campañas
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexCampanas(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexCampanas(item);
        }

         /// <summary>
        /// Lista todos las visitas de empresarias x Zona
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexZona(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexZona(item);
        }

         /// <summary>
        /// Lista todos las visitas de empresarias x Division
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivision(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexDivision(item);
        }

        /// <summary>
        /// Lista todos las visitas de empresarias x Division x Campaña
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivisionxCampana(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexDivisionxCampana(item);
        }

             /// <summary>
        /// Lista todos las visitas de empresarias x Division x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivisionxEstado(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexDivisionxEstado(item);
        }

        /// <summary>
        /// Lista todos las visitas de empresarias x Zona x Campaña
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexZonaxCampana(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexZonaxCampana(item);
        }

            /// <summary>
        /// Lista todos las visitas de empresarias x Zona x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexZonaxEstado(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexZonaxEstado(item);
        }

         /// <summary>
        /// Lista todos las visitas de empresarias x Campaña x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexCampanaxEstado(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexCampanaxEstado(item);
        }

        /// <summary>
        /// Lista todos las visitas de empresarias x Division x Zona x Campaña x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivisionxZonaxCampanaxEstado(VisitaEmpresariaInfo item)
        {
            return module.ListxReportexDivisionxZonaxCampanaxEstado(item);
        }

        /// <summary>
        /// Guarda una visita a empresaria.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(VisitaEmpresariaInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return 0;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de una visita a empresaria.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(VisitaEmpresariaInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Elimina una visita a empresaria.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool Delete(int Id, string Usuario)
        {
            try
            {
                return module.Delete(Id, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        #endregion
    }
}
