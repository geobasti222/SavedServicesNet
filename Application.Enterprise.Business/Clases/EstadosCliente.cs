using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para EstadosCliente
    /// </summary>
    public class EstadosCliente : IEstadosCliente
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.EstadosCliente module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public EstadosCliente()
        {
            module = new Application.Enterprise.Data.EstadosCliente();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public EstadosCliente(string databaseName)
        {
            module = new Application.Enterprise.Data.EstadosCliente(databaseName);
        }

        #region Miembros de IEstadosCliente
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EstadosClienteInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un estado especifico.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<EstadosClienteInfo> ListxId(int Id)
        {
            return module.ListxId(Id);
        }

        #endregion
                
    }
}
