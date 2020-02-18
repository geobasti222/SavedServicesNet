using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Intermediario
    /// </summary>
    public interface IIntermediario
    {
        #region "Metodos de Intermediario"

        /// <summary>
        /// lista todos los Intermediarios existentes.
        /// </summary>
        /// <returns></returns>
        List<IntermediarioInfo> List();    
              
        #endregion
    }
}

