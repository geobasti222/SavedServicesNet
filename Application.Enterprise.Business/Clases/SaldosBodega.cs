using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para SaldosBodega
    /// </summary>
    public class SaldosBodega : ISaldosBodega
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.SaldosBodega module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public SaldosBodega()
        {
            module = new Application.Enterprise.Data.SaldosBodega();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public SaldosBodega(string databaseName)
        {
            module = new Application.Enterprise.Data.SaldosBodega(databaseName);
        }

        #region Miembros de ISaldosBodega
        /// <summary>
        /// Lista todos los saldos bodega existentes.
        /// </summary>
        /// <returns></returns>
        public List<SaldosBodegaInfo> List()
        {
            return module.List();
        }     

        #endregion
    }
}
