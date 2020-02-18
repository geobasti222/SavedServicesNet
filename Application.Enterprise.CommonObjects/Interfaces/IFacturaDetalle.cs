using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Factura Detalle
    /// </summary>
    public interface IFacturaDetalle
    {
        #region "Metodos de Factura"

        /// <summary>
        /// Se obtiene todo el objeto del detalle de una factura a partir de un numero de factura
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        List<FacturaDetalleInfo> ListxNumero(string NumeroFactura);

        #endregion
    }
}
