using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PuntoReorden
    /// </summary>
    public interface IPuntoReorden
    {
        #region "Metodos de PuntoReorden"

        /// <summary>
        /// Lista todas las configuraciones de punto de reorden.
        /// </summary>
        /// <returns></returns>
        List<PuntoReordenInfo> List();

        /// <summary>
        /// Lista la configuracion de un punto de reorden x plu.
        /// </summary>
        /// <param name="Plu"></param>
        /// <returns></returns>
        PuntoReordenInfo ListxPlu(int Plu);

        /// <summary>
        /// Realiza el bloqueo de los plus por punto de reorden.
        /// </summary>
        /// <returns></returns>
        bool BloquearxPuntoReorden();

        /// <summary>
        /// Realiza la actualizacion de un punto de reorden.
        /// </summary>
        /// <param name="Plu"></param>
        /// <returns></returns>
        bool Update(PuntoReordenInfo item);

        #endregion
    }
}

