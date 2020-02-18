using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ClasificacionXValorProceso
    /// </summary>
    public interface IClasificacionXValorProceso
    {
        #region "Metodos de ClasificacionXValorProceso"

        /// <summary>
        /// Traer todas las empresarias por campaña
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        List<ClasificacionXValorProcesoInfo> List(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Traer las empresarias por campaña y nit
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ClasificacionXValorProcesoInfo ListXNit(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Traer promedios por campaña primera division
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ClasificacionXValorProcesoInfo ListXPrimerCuadrante(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Traer promedios por campaña segunda division
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ClasificacionXValorProcesoInfo ListXSegundoCuadrante(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Trae orden promedio Maximo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        ClasificacionXValorProcesoInfo ListXOrdenPromedioMaximo(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        List<ClasificacionXValorProcesoInfo> ListConFiltro(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        List<ClasificacionXValorProcesoInfo> ListConFiltroEstados(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        List<ClasificacionXValorProcesoInfo> ListConFiltroCount(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Realiza la ejecucion de la clasificacion por valores de todos los empresarios.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(ClasificacionXValorProcesoInfo item);

        /// <summary>
        /// Trae cantidades de empresarias por clasificacion filtradas por region y zona 
        /// </summary>
        /// <returns></returns>
        ClasificacionXValorProcesoInfo ListXNitUltimaCampana(ClasificacionXValorProcesoInfo item);

        #endregion
    }
}
