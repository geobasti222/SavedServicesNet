using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de IPremiosPuntosValor
    /// </summary>
    public interface IPremiosPuntosValor
    {
        #region "Metodos de IPremiosPuntosValor"

        /// <summary>
        /// Lista todos los valores para los puntos
        /// </summary>
        /// <returns></returns>
        List<PremiosPuntosValorInfo> List();


        #endregion
    }
}

