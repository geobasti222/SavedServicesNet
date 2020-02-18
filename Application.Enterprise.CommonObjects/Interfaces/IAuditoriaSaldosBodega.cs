using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de AuditoriaSaldosBodega
    /// </summary>
    public interface IAuditoriaSaldosBodega
    {
        #region "Metodos de AuditoriaSaldosBodega"

        /// <summary>
        /// Lista todos errores de saldos bodega sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        List<AuditoriaSaldosBodegaInfo> ListErroresSinConfirmar();
        
        /// <summary>
        /// Realiza la actualizacion de la auditoria enviada por correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateIdConfirmado(int Id);

        #endregion
    }
}

