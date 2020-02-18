using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Factura Detalle
    /// </summary>
    public class FacturaDetalle
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.FacturaDetalle module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public FacturaDetalle()
        {
            module = new Application.Enterprise.Data.FacturaDetalle();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public FacturaDetalle(string databaseName)
        {
            module = new Application.Enterprise.Data.FacturaDetalle(databaseName);
        }
        
        #region Miembros de IFactura

        /// <summary>
        /// Se obtiene todo el objeto del detalle de una factura a partir de un numero de factura
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public List<FacturaDetalleInfo> ListxNumero(string NumeroFactura)
        {
            return module.ListxNumero(NumeroFactura);
        }

        #endregion
    }
}
