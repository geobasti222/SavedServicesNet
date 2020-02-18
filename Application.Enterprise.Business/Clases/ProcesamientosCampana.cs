using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcesamientosCampana : IProcesamientosCampana
    {
        private Application.Enterprise.Data.ProcesamientosCampana module;

        public ProcesamientosCampana()
        {
            module = new Application.Enterprise.Data.ProcesamientosCampana();
        }

        public ProcesamientosCampana(string databaseName)
        {
            module = new Application.Enterprise.Data.ProcesamientosCampana(databaseName);
        }

        #region Procesamientos Campana


        public List<ProcesamientosCampanaInfo> List(int idPrc)
        {
            return module.List(idPrc);
        }

        public ProcesamientosCampanaInfo ListUltima(int idPrc)
        {
            return module.ListUltima(idPrc);
        }

        public ProcesamientosCampanaInfo ListPrimera(int idPrc)
        {
            return module.ListPrimera(idPrc);
        }

        public List<ProcesamientosCampanaInfo> ListCantidadDefinida(int idPrc, int top)
        {
            return module.ListCantidadDefinida(idPrc, top);
        }

        public List<ProcesamientosCampanaInfo> ListCampanasXAno(int idPrc)
        {
            return module.ListCampanasXAno(idPrc);
        }

        /// <summary>
        ///  La fecha de cierre de campaña anterior
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public ProcesamientosCampanaInfo FechaFinCampanaAnterior(DateTime fecha)
        {
            return module.FechaFinCampanaAnterior(fecha);
        }

        /// <summary>
        /// Ejecucion de la funcion de Procesamientos_Campana filtronumerico:
        /// 1. campaña actual
        /// 2. campaña anterior
        /// 3. dos campañas anteriores
        /// 4. proxima campaña
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="filtronumerico"></param>
        /// <returns></returns>
        public ProcesamientosCampanaInfo ProcesoCampanaFnc(DateTime fecha, int filtronumerico)
        {
            return module.ProcesoCampanaFnc(fecha, filtronumerico);
        }

        /// <summary>
        /// Lista de campañas de SVDN_PROCESAMIENTOS_CAMPANA que existan en SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <returns></returns>
        public List<ProcesamientosCampanaInfo> ListCampanasHistorico()
        {
            return module.ListCampanasHistorico();
        }

        /// <summary>
        /// Lista las ultimas X campañas que defina el usuario
        /// </summary>
        /// <param name="top">cantidad de campañas desde la ultima para atras</param>
        /// <returns></returns>
        public List<ProcesamientosCampanaInfo> ListUltimasCampanas(int top, DateTime fechafin)
        {
            return module.ListUltimasCampanas(top, fechafin);
        }

        public string InsertProcesamientoCampana(ProcesamientosCampanaInfo item)
        {
            return module.InsertProcesamientoCampana(item);
        }

        public bool UpdateProcesamientoCampana(ProcesamientosCampanaInfo item)
        {
            return module.UpdateProcesamientoCampana(item);
        }

        public bool UpdateProcesamientoCampanaActual(ProcesamientosCampanaInfo item)
        {
            return module.UpdateProcesamientoCampanaActual(item);
        }

        public ProcesamientosCampanaInfo ListSegunFecha(DateTime fechaini)
        {
            return module.ListSegunFecha(fechaini);
        }



        #endregion
    }
}
