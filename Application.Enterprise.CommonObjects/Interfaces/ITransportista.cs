using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Transportista
    /// </summary>
    public interface ITransportista
    {
        #region "Metodos de Transportista"

        /// <summary>
        /// Lista todos los trasnportistas.
        /// </summary>
        /// <returns></returns>
        List<TransportistaInfo> List();

        /// <summary>
        /// Lista los transportistas de una zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        List<TransportistaInfo> ListxZona(string Zona);

        /// <summary>
        /// Lista un transportista x id.
        /// </summary>
        /// <param name="IdTransportista"></param>
        /// <returns></returns>
        TransportistaInfo ListxId(string IdTransportista);

        /// <summary>
        /// Lista todos los transportistas de una IdZona.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        List<TransportistaInfo> ListxIdZona(string IdZona);

        #endregion
    }
}

