using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Flete Lider
    /// </summary>
    public interface IFleteLider
    {
        #region "Metodos de Flete Lider"

        /// <summary>
        /// lista todas los Fletes por Lider.
        /// </summary>
        /// <returns></returns>
        FleteLiderInfo List(string lider);
       

        #endregion
    }
}
