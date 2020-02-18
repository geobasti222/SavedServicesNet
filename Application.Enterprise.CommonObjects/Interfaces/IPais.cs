using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Pais
    /// </summary>
    public interface IPais
    {
        #region "Metodos de Pais"

        /// <summary>
        /// lista todos los Paises existentes.
        /// </summary>
        /// <returns></returns>
        List<PaisInfo> List();    
              
        #endregion
    }
}

