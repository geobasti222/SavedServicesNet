using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IClasificacionPorValor
    {
        /// <summary>
        /// Traer las campanas completas
        /// </summary>
        /// <returns></returns>
        DataTable traerCampanas();

         /// <summary>
        /// Traer divisionales completas
        /// </summary>
        /// <returns></returns>
        DataTable traerDivisionales();

         /// <summary>
        /// Traer zonas por divisional seleccionada
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        DataTable traerZonasXDivisionales(String division);
        
        /// <summary>
        /// lista todos las nits por zona campana
        /// </summary>
        /// <returns></returns>
        List<CxVNitsInfo> ListxLosnits(string zona, string campana);

        /// <summary>
        /// trae promedio por agrupado y campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        clasificacionPorValorInfo traePromedio(string campana);
        
        /// <summary>
        /// trae promedio por agrupado y campana AA
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        clasificacionPorValorInfo traePromedioAA(string campana);
        
        /// <summary>
        /// trae todos los datos por campana detallado
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<clasificacionPorValorInfo> traeDatosxCampana(string campana,string zona);

        /// <summary>
        /// trae todos los totales
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<clasificacionPorValorInfo> traeDatosxCampanaValores(string campana);
        
        
        /// <summary>
        /// Trae las  ultimas campañas actuales
        /// </summary>
        /// <returns></returns>
        DataTable traerInformacionDeCampanaParaProcesar();

        /// <summary>
        /// proceso clasificacion x valor
        /// </summary>
        /// <returns></returns>
        bool proceso(string campana);
        
        /// <summary>
        /// trae todos los datos por campana detallado region
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<clasificacionPorValorInfo> traeDatosxCampanaRegion(string campana, string region);

        /// <summary>
        /// lista todos las campañas existentes.
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> List();
        
         /// <summary>
        /// trae todos los orncejtaes por zona
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        List<clasificacionPorValorInfo> traeDatosxPorcentajeZona(string campana, string zona);
        
    }
}
