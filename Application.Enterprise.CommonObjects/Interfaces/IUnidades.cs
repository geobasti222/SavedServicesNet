using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Unidades
    /// </summary>
    public interface IUnidades
    {
        #region "Metodos de Unidades"

        /// <summary>
        /// lista todas las Unidades
        /// </summary>
        /// <returns></returns>
        List<UnidadesInfo> List();

        #endregion
    }
}
