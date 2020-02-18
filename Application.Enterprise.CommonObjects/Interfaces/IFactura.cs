using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Factura
    /// </summary>
    public interface IFactura
    {
        #region "Metodos de Factura"

        /// <summary>
        /// -Consulta una factura especifica por numero.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        List<FacturaInfo> ListxNumero(string NumeroFactura);

        /// <summary>
        /// Consulta el detalle de una factura especifica por numero.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        List<FacturaInfo> ListDetallexNumero(string NumeroFactura);

        /// <summary>
        /// Obtiene la lista de facturas por campaña y por nit de un cliente.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        List<FacturaInfo> ListFacturasxCampanaxNit(string Campana, string Nit);

        /// <summary>
        /// Obtiene el numero de pedido de una factura
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        string ListNumeroPedidoxFactura(string NumeroFactura);

        /// <summary>
        /// Obtiene el nombre de la factura en archivo XML.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        string ListNombreFacturaXML(string NumeroFactura);


        #endregion
    }
}

