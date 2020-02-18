using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Descuento Privilegio
    /// </summary>
    public interface IDescuentoPrivilegio
    {
        #region "Metodos de Descuento Privilegio"

        /// <summary>
        /// Lista todos los descuentos.
        /// </summary>
        /// <returns></returns>
        List<DescuentoPrivilegioInfo> List();

        /// <summary>
        /// Lista un descuento x id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        DescuentoPrivilegioInfo ListxId(int Id);

         /// <summary>
        /// Lista un descuento x rango de valor del pedido y unidad de negocio de un articulo con privilegio con producto estrella.
        /// </summary>
        /// <param name="ValorPedido"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="GrupoProducto"></param>
        /// <param name="Campana"></param>
        /// <param name="ProdEstrella"></param>
        /// <returns></returns>
        DescuentoPrivilegioInfo ListxValorPedidoPrivilegio(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella);
        
        /// <summary>
        /// Guarda un descuento nuevo.
        /// </summary>
        /// <param name="item"></param>
        int Insert(DescuentoPrivilegioInfo item);

        /// <summary>
        /// Realiza la actualizacion de un descuento existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(DescuentoPrivilegioInfo item);

        /// <summary>
        /// Elimina un Descuento.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool Delete(int Id, string Usuario);

        /// <summary>
        /// Lista un descuento x rango de valor del pedido y unidad de negocio de un articulo.
        /// </summary>
        /// <param name="ValorPedido"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="GrupoProducto"></param>
        /// <returns></returns>
        DescuentoPrivilegioInfo ListxValorPedido(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana);


        #endregion
    }
}

