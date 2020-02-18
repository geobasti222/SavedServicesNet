using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Barrios
    /// </summary>
    public interface IBarrios
    {
        #region "Metodos de Barrios"

        /// <summary>
        /// Lista todos los barrios
        /// </summary>
        /// <returns></returns>
        List<BarriosInfo> List();

        /// <summary>
        /// Lista todos los barrios de una ciudad especifica.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <returns></returns>
        List<BarriosInfo> ListxCiudad(int CodigoCiudad);


        #endregion
    }
}

