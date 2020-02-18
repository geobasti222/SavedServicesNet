using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de AuditoriaPedidos
    /// </summary>
    public interface IAuditoriaPedidos
    {
        #region "Metodos de AuditoriaPedidos"

        /// <summary>
        /// Lista todos errores de pedidos sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        List<AuditoriaPedidosInfo> ListErroresSinConfirmar();

        /// <summary>
        /// Guarda si existe un pedido en la auditoria marcada sin confirmar.
        /// </summary>
        /// <returns></returns>
        bool InsertarPedidos();

        /// <summary>
        /// Realiza la actualizacion de la auditoria enviada por correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateIdConfirmado(int Id);

        #endregion
    }
}

