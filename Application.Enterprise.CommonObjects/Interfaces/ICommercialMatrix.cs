using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de CommercialMatrix
    /// </summary>
    public interface ICommercialMatrix
    {
        #region "Metodos de CommercialMatrix"

        /// <summary>
        /// Traer la Matriz Comercial Completa
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        DataTable MatrizComercialCompleta(string cpini, string cpfin, int vista);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="cpfin"></param>
        /// <param name="vista"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable MatrizComercialCompletaXDivision(string cpini, string cpfin, int vista, int division);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="cpfin"></param>
        /// <param name="vista"></param>
        /// <param name="mailgroup"></param>
        /// <returns></returns>
        DataTable MatrizComercialCompletaXMailgroup(string cpini, string cpfin, int vista, int mailgroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="cpfin"></param>
        /// <param name="vista"></param>
        /// <param name="asistente"></param>
        /// <returns></returns>
        DataTable MatrizComercialCompletaXAsistente(string cpini, string cpfin, int vista, string asistente);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="cpfin"></param>
        /// <param name="vista"></param>
        /// <param name="zona"></param>
        /// <returns></returns>
        DataTable MatrizComercialCompletaXZona(string cpini, string cpfin, int vista, string zona);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="vista"></param>
        /// <returns></returns>
        DataTable MatrizComercialDivision(string cpini, int vista);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="vista"></param>
        /// <returns></returns>
        DataTable MatrizComercialMailgroup(string cpini, int vista);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="vista"></param>
        /// <returns></returns>
        DataTable MatrizComercialAsistente(string cpini, int vista);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="vista"></param>
        /// <returns></returns>
        DataTable MatrizComercialZona(string cpini, int vista);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="vista"></param>
        /// <returns></returns>
        DataTable MatrizComercialZonaConDivisional(string cpini, int vista, int division);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpini"></param>
        /// <param name="vista"></param>
        /// <param name="asistente"></param>
        /// <returns></returns>
        DataTable MatrizComercialZonaConAsistente(string cpini, int vista, string asistente);

        /// <summary>
        /// Traer Campañas
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        DataTable ClasificacionXValorCompleta(string cpini);

        DataTable ClasificacionXValorDivision(string cpini, int division);

        DataTable ClasificacionXValorMailGroup(string cpini, int mailgroup);

        DataTable ClasificacionXValorZona(string cpini, string zona);

        DataTable traerCampanas(int vistaCampanas);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataTable traerMailgroups();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataTable traerAsistentes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DataTable traerDivisiones();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable traerZonasXDivisiones(int division);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailgroup"></param>
        /// <returns></returns>
        DataTable traerZonasXMailgroups(int mailgroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailgroup"></param>
        /// <returns></returns>
        DataTable traerZonasXAsistentes(string asistente);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<decimal> MatrizComercialPorcentajes(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        DataTable ListaEmpresariasCampanaZonaEstado(string campana, string zona, int estado, string TipoAgrupamiento);

        // ***********************************************************************************************************
        // INICIO: METODOS DEL PROCESO
        // ***********************************************************************************************************

        DataTable traerCampanasParaProcesar();
        
        DataTable traerInformacionDeCampanaParaProcesar(string campana);

        void proceso01(string campana_actual, string campana_anterior, DateTime fecha_inicio, DateTime fecha_fin);
        
        void proceso02(string campana_actual);
        
        void proceso03(string campana_actual, string campana_anterior);
        
        void proceso04(string campana_actual);

        void proceso04_extendido(string campana_actual, string opcion);
        
        void proceso05(string campana_actual, string campana_anterior);

        void proceso05_extendido(string campana_actual, string campana_anterior, string opcion);
        
        void proceso06(string campana_actual, string campana_anterior);
        
        void proceso07(string campana_actual);
        
        void proceso08(string campana_actual);

        void proceso09();

        // ***********************************************************************************************************
        // FIN: METODOS DEL PROCESO
        // ***********************************************************************************************************

        #endregion
    }
}
