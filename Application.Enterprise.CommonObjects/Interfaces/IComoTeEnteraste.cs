using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de ComoTeEnteraste
    /// </summary>
    public interface IComoTeEnteraste
    {
        #region "Metodos de ComoTeEnteraste"

        /// <summary>
        /// lista todos los ComoTeEnteraste existentes.
        /// </summary>
        /// <returns></returns>
        List<ComoTeEnterasteInfo> List();    
              
        #endregion
    }
}
