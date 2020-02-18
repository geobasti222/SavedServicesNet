using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de TipoRed
    /// </summary>
    public interface ITipoRed
    {
        #region "Metodos de TipoRed"

        /// <summary>
        /// lista todos los Tipo de Red existentes.
        /// </summary>
        /// <returns></returns>
        List<TipoRedInfo> List();    
              
        #endregion
    }
}

