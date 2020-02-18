using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Catalogo de Interes
    /// </summary>
    public interface ICatalogoInteres
    {
        #region "Metodos de Catalogo de Interes"

       /// <summary>
        /// lista todos los catalogos de interes existentes activos.
        /// </summary>
        /// <returns></returns>
        List<CatalogoInteresInfo> List();
              
        #endregion
    }
}
