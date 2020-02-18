using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ClasificacionXValorAlarma
    /// </summary>
    public interface IClasificacionXValorAlarma
    {
        #region "Metodos de ClasificacionXValorAlarma"

        /// <summary>
        /// LISTA TODAS LAS ALARMAS DE UN ESTADO Y/O NIT Y/O CAMPAÑA ESPECIFICO(A)(S)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        List<ClasificacionXValorAlarmaInfo> ListX(ClasificacionXValorAlarmaInfo item);

        /// <summary>
       /// ACTUALIZACION DE ALARMA
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(ClasificacionXValorAlarmaInfo item);

        /// <summary>
        /// CREACION DE ALARMAS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Proceso(ClasificacionXValorAlarmaInfo item);

        #endregion
    }
}
