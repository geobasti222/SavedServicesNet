using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para NivelServicio
    /// </summary>
    public class NivelServicio : INivelServicio
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.NivelServicio module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public NivelServicio()
        {
            module = new Application.Enterprise.Data.NivelServicio();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public NivelServicio(string databaseName)
        {
            module = new Application.Enterprise.Data.NivelServicio(databaseName);
        }

        #region Miembros de INivelServicio
        /// <summary>
        /// Lista todos los niveles de servicio.
        /// </summary>
        /// <returns></returns>
        public List<NivelServicioInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un nivel de servicio por fecha actual
        /// </summary>
        /// <returns></returns>
        public NivelServicioInfo ListxFecha()
        {
            return module.ListxFecha();
        }

        /// <summary>
        /// Calcula el nivel de servicio de la campaña actual x zona.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<NivelServicioInfo> ListxCampanaxZona(string zona)
        {
            return module.ListxCampanaxZona(zona);
        }

        /// <summary>
        /// Calcula el nivel de servicio de la campaña actual para todas las zonas.
        /// </summary>
        /// <returns></returns>
        public List<NivelServicioInfo> ListxCampanaxTodasZonas()
        {
            return module.ListxCampanaxTodasZonas();
        }

        #endregion
    }
}
