using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de BodegaxCentroOperacion
    /// </summary>
    public interface ICentroOperacion
    {
        #region "Metodos de CentroOperacion"

        /// <summary>
        /// lista todos los centro de operacion existentes activos.
        /// </summary>
        /// <returns></returns>
        List<CentroOperacionInfo> List();

        /// <summary>
        /// lista un centro de operacion especifico.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        CentroOperacionInfo ListxId(int Id);

        #endregion
    }
}

