using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;


namespace Application.Enterprise.Business
{
    /// <summary>
    /// JA
    /// </summary>
    public class ClasificacionPorValor : IClasificacionPorValor
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ClasificacionPorValor module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ClasificacionPorValor()
        {
            module = new Application.Enterprise.Data.ClasificacionPorValor();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ClasificacionPorValor(string databaseName)
        {
            module = new Application.Enterprise.Data.ClasificacionPorValor(databaseName);
        }

        // <summary>
        /// Traer las campanas completas
        /// </summary>
        /// <returns></returns>
        public DataTable traerCampanas()
        {
            return module.traerCampanas();
        }

        /// <summary>
        /// Traer divisionales completas
        /// </summary>
        /// <returns></returns>
        public DataTable traerDivisionales()
        {
            return module.traerDivisionales();
        }

        /// <summary>
        /// Traer zonas por divisional seleccionada
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerZonasXDivisionales(String division)
        {
            return module.traerZonasXDivisionales(division);
        }

        /// <summary>
        /// lista todos las nits por zona campana
        /// </summary>
        /// <returns></returns>
        public List<CxVNitsInfo> ListxLosnits(string zona, string campana)
        {
            return module.ListxLosnits(zona, campana);
        }

         /// <summary>
        /// trae promedio por agrupado y campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public clasificacionPorValorInfo traePromedio(string campana)
        {
            return module.traePromedio(campana);
        }

        /// <summary>
        /// trae promedio por agrupado y campana AA
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public clasificacionPorValorInfo traePromedioAA(string campana)
        {
            return module.traePromedioAA(campana);
        }


        /// <summary>
        /// trae todos los datos por campana detallado
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxCampana(string campana,string zona)
        {
            return module.traeDatosxCampana(campana, zona);
        }


        /// <summary>
        /// trae todos los totales
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxCampanaValores(string campana)
        {
            return module.traeDatosxCampanaValores(campana);
        }

        /// <summary>
        /// trae max de OP
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public clasificacionPorValorInfo traeMAXOP(string campana)
        {
            return module.traeMAXOP(campana);
        }

        /// <summary>
        /// trae todos los totales por region
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxRegion(string campana, string region)
        {
            return module.traeDatosxRegion(campana, region);
        }

        /// <summary>
        /// Trae las  ultimas campañas actuales
        /// </summary>
        /// <returns></returns>
        public DataTable traerInformacionDeCampanaParaProcesar()
        {
            return module.traerInformacionDeCampanaParaProcesar();
        }


        /// <summary>
        /// proceso clasificacion x valor
        /// </summary>
        /// <returns></returns>
        public bool proceso(string campana)
        {
            return module.proceso(campana);
        }

        /// <summary>
        /// trae todos los datos por campana detallado region
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxCampanaRegion(string campana, string region)
        {
            return module.traeDatosxCampanaRegion(campana, region);
        }


        /// <summary>
        /// lista todos las campañas existentes.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> List()
        {
            return module.List();
        }

         /// <summary>
        /// trae todos los orncejtaes por zona
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxPorcentajeZona(string campana, string zona)
        {
            return module.traeDatosxPorcentajeZona(campana, zona);
        }
    }
}
