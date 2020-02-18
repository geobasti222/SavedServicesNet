using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Factura
    /// </summary>
    public class Factura : IFactura
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Factura module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Factura()
        {
            module = new Application.Enterprise.Data.Factura();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Factura(string databaseName)
        {
            module = new Application.Enterprise.Data.Factura(databaseName);
        }

        #region Miembros de IFactura
        /// <summary>
        /// -Consulta una factura especifica por numero.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public List<FacturaInfo> ListxNumero(string NumeroFactura)
        {
            return module.ListxNumero(NumeroFactura);
        }

        /// <summary>
        /// Consulta el detalle de una factura especifica por numero.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public List<FacturaInfo> ListDetallexNumero(string NumeroFactura)
        {
            return module.ListDetallexNumero(NumeroFactura);
        }

        /// <summary>
        /// Obtiene la lista de facturas por campaña y por nit de un cliente.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<FacturaInfo> ListFacturasxCampanaxNit(string Campana, string Nit)
        {
            return module.ListFacturasxCampanaxNit(Campana, Nit);
        }

        /// <summary>
        /// Obtiene el numero de pedido de una factura
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public string ListNumeroPedidoxFactura(string NumeroFactura)
        {
            return module.ListNumeroPedidoxFactura(NumeroFactura);
        }

        /// <summary>
        /// Obtiene el nombre de la factura en archivo XML.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public string ListNombreFacturaXML(string NumeroFactura)
        {
            return module.ListNombreFacturaXML(NumeroFactura);
        }


        /// <summary>
        /// informe facturas
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public DataTable informefacturasJuta(string zona, string campana)
        {
            return module.informefacturasJuta(zona, campana);
        }

        #endregion
    }
}
