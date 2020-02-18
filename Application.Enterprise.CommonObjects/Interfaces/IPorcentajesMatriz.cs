using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Porcentajes Matriz
    /// </summary>
    public interface IPorcentajesMatriz
    {
        #region "Metodos de Porcentajes Matriz"

        /// <summary>
        /// lista todos los Porcentanjes de Matriz existentes.
        /// </summary>
        /// <returns></returns>
        List<PorcentajesMatrizInfo> List();

        /// <summary>
        /// Lista el procentaje de un concept especifico de la matriz comercial por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PorcentajesMatrizInfo ListxId(int Id);

        #endregion
    }
}

