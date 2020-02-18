using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de CicloxPlu
    /// </summary>
    public interface ICicloxPlu
    {
        #region "Metodos de CicloxPlu"

        /// <summary>
        /// Lista todos los Ciclos x Plu.
        /// </summary>
        /// <returns></returns>
        List<CicloxPluInfo> List();

        /// <summary>
        /// Lista el consolidado de los plu e ciclo de vida.
        /// </summary>
        /// <returns></returns>
        List<CicloxPluInfo> ListConsolidado();

        /// <summary>
        /// Guarda un Ciclo x Plu nuevo.
        /// </summary>
        /// <param name="item"></param>
        int Insert(CicloxPluInfo item);


        #endregion
    }
}

