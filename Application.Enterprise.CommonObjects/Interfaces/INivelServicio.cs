using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de NivelServicio
    /// </summary>
    public interface INivelServicio
    {
        #region "Metodos de NivelServicio"

        /// <summary>
        /// Lista todos los niveles de servicio
        /// </summary>
        /// <returns></returns>
        List<NivelServicioInfo> List();

        /// <summary>
        /// Lista un nivel de servicio por fecha actual
        /// </summary>
        /// <returns></returns>
        NivelServicioInfo ListxFecha();

        /// <summary>
        /// Calcula el nivel de servicio de la campaña actual x zona.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        List<NivelServicioInfo> ListxCampanaxZona(string zona);

        /// <summary>
        /// Calcula el nivel de servicio de la campaña actual para todas las zonas.
        /// </summary>
        /// <returns></returns>
        List<NivelServicioInfo> ListxCampanaxTodasZonas(); 

        #endregion
    }
}

