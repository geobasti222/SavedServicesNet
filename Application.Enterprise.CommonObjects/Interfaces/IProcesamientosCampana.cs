using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IProcesamientosCampana
    {
        #region "Metodos de Procesamientos de Campañas"


        /// <summary>
        /// Mostrar todos los elementos de la tabla SVDN_PROCESAMIENTOS_CAMPANA de acuerdo a un tipo de Procesamiento
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>
        List<ProcesamientosCampanaInfo> List(int idPrc);

        /// <summary>
        /// Mostrar el ultimo elemento de la tabla SVDN_PROCESAMIENTOS_CAMPANA de acuerdo a un tipo de Procesamiento y ordenado por fecha
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>
        ProcesamientosCampanaInfo ListUltima(int idPrc);

        /// <summary>
        /// Mostrar el primer elemento de la tabla SVDN_PROCESAMIENTOS_CAMPANA de acuerdo a un tipo de Procesamiento y ordenado por fecha
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>
        ProcesamientosCampanaInfo ListPrimera(int idPrc);

        /// <summary>
        /// Lista cantidad definida de Campanas de un tipo de procesamiento especifico
        /// </summary>
        /// <param name="idPrc">Tipo de Procesamiento</param>
        /// <param name="top">Cantidad de Campañas</param>
        /// <returns></returns>
        List<ProcesamientosCampanaInfo> ListCantidadDefinida(int idPrc, int top);

        /// <summary>
        /// Lista todos los elementos de la tabla SVDN_PROCESAMIENTOS_CAMPANA del año presente
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>
        List<ProcesamientosCampanaInfo> ListCampanasXAno(int idPrc);

        /// <summary>
        /// La fecha de cierre de campaña anterior
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        ProcesamientosCampanaInfo FechaFinCampanaAnterior(DateTime fecha);

        /// <summary>
        /// Ejecucion de la funcion de Procesamientos_Campana filtronumerico:
        /// 1. Campaña actual
        /// 2. Campaña anterior
        /// 3. Dos campañas anteriores
        /// 4. Proxima campaña
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="filtronumerico"></param>
        /// <returns></returns>
        ProcesamientosCampanaInfo ProcesoCampanaFnc(DateTime fecha, int filtronumerico);

        /// <summary>
        /// Lista de campañas de SVDN_PROCESAMIENTOS_CAMPANA que existan en SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <returns></returns>
        List<ProcesamientosCampanaInfo> ListCampanasHistorico();

        /// <summary>
        /// Lista las ultimas X campañas que defina el usuario
        /// </summary>
        /// <param name="top">cantidad de campañas desde la ultima para atras</param>
        /// <returns></returns>
        List<ProcesamientosCampanaInfo> ListUltimasCampanas(int top, DateTime fechafin);
        
        /// <summary>
        /// Realiza insercion de la informacion de la campaña actual en un determinado proceso
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string InsertProcesamientoCampana(ProcesamientosCampanaInfo item);


        /// <summary>
        /// Actualiza la fechas de SVDN_PROCESAMIENTOS_CAMPANA
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateProcesamientoCampana(ProcesamientosCampanaInfo item);

        /// <summary>
        /// Actualiza las fechas de un proceso sobre la campaña que esta corriendo actualmente
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateProcesamientoCampanaActual(ProcesamientosCampanaInfo item);

        /// <summary>
        /// Mostrar el ultimo elemento de la tabla SVDN_PROCESAMIENTOS_CAMPANA de acuerdo a un tipo de Procesamiento y ordenado por fecha
        /// </summary>
        /// <param name="idPrc"></param>
        /// <returns></returns>
        ProcesamientosCampanaInfo ListSegunFecha(DateTime fechaini);

        #endregion
    }
}
