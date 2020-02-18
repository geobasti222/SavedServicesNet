using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de PremiosPuntosConf
    /// </summary>
    public interface IPremiosPuntosConf
    {
        #region "Metodos de PremiosPuntosConf"

         /// <summary>
        /// Realiza el registro de una configuracion de puntos.
        /// </summary>
        /// <param name="item"></param>
        int Insert(PremiosPuntosConfInfo item);        

        /// <summary>
        ///Lista todos los puntos configuracion
        /// </summary>
        /// <returns></returns>
        List<PremiosPuntosConfInfo> List();

        /// <summary>
        /// muestra la configuracion de los puntos por id de configuracion.
        /// </summary>
        /// <param name="IdConfiguracion"></param>
        /// <returns></returns>
        PremiosPuntosConfInfo ListxIdConfiguracion(int IdConfiguracion);

        /// <summary>
        /// muestra la configuracion de los puntos por id del campo.
        /// </summary>
        /// <param name="IdCampo"></param>
        /// <returns></returns>
        PremiosPuntosConfInfo ListxIdCampo(int IdCampo);

        #endregion
    }
}

