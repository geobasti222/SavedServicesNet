using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de EstadosCliente
    /// </summary>
    public interface IEstadosCliente
    {
        #region "Metodos de EstadosCliente"

        /// <summary>
        /// Lista todos los estados de cliente.
        /// </summary>
        /// <returns></returns>
        List<EstadosClienteInfo> List();

        /// <summary>
        /// Lista un estado especifico
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<EstadosClienteInfo> ListxId(int Id);

        #endregion
    }
}