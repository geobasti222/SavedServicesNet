using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Centros De Costos
    /// </summary>
    public interface ICentroCostos
    {
        #region "Metodos de Centro Costos"

        /// <summary>
        /// lista todos los centros de costos existentes.
        /// </summary>
        /// <returns></returns>
        List<CentroCostosInfo> List();

        /// <summary>
        /// Lista un Centros de Costos por ccostos
        /// </summary>
        /// <param name="CCostos"></param>
        /// <returns></returns>
        CentroCostosInfo ListxCCostos(string CCostos);

        /// <summary>
        ///Guarda un centro de costos nuevo.
        /// </summary>
        /// <param name="item"></param>
        bool Insert(CentroCostosInfo item);

        #endregion
    }
}

