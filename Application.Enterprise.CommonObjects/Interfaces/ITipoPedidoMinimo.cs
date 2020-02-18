using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de TipoPedidoMinimo
    /// </summary>
    public interface ITipoPedidoMinimo
    {
        #region "Metodos de Tipo Pedido Minimo"

        /// <summary>
        /// -Lista todos los tipos de pedido minimo.
        /// </summary>
        /// <returns></returns>
        List<TipoPedidoMinimoInfo> List();

        /// <summary>
        /// Lista un tipo de pedido minimo x id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TipoPedidoMinimoInfo ListxId(int Id);
                  
        /// <summary>
        /// Realiza la actualizacion de los valores de un tipo de pedido minimo.
        /// </summary>
        /// <param name="objTipoPedidoMinimoInfo"></param>
        /// <returns></returns>
        bool Update(TipoPedidoMinimoInfo objTipoPedidoMinimoInfo);        

        #endregion
    }
}

