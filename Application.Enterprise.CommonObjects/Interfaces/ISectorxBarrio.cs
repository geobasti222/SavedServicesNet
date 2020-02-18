using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de SectorxBarrio
    /// </summary>
    public interface ISectorxBarrio
    {
        #region "Metodos de SectorxBarrio"

        /// <summary>
        /// lista todos los sectores x barrios existentes.
        /// </summary>
        /// <returns></returns>
        List<SectorxBarrioInfo> List();
        
        /// <summary>
        /// lista el sector de un barrio especifico.
        /// </summary>
        /// <returns></returns>
        List<SectorxBarrioInfo> ListxBarrio(int CodigoBarrio);

        #endregion
    }
}

