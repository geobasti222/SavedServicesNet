using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de EPuntos
    /// </summary>
    public interface IEPuntos    {
        #region "Metodos de EPuntos"

        /// <summary>
        /// Lista todos los Puntos por Empresaria).
        /// </summary>
        /// <returns></returns>
        List<EPuntosInfo> ListPuntosEmpresarias(string Nit, string Lider, string Vendedor);

        /// <summary>
        /// Lista todos los Puntos por Empresaria).
        /// </summary>
        /// <returns></returns>
        List<EPuntosInfo> ListDetallePuntosEmpresarias(string Nit);


        #endregion
    }
}

