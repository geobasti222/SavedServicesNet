using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de AuditoriaNegativos
    /// </summary>
    public interface IAuditoriaNegativos
    {
        #region "Metodos de AuditoriaNegativos"

        /// <summary>
        /// Lista todos errores de negativos sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        List<AuditoriaNegativosInfo> ListErroresSinConfirmar();

        /// <summary>
        /// Guarda si existe un negativo en la auditoria marcada sin confirmar.
        /// </summary>
        /// <returns></returns>
        bool InsertarNegativos();

        /// <summary>
        /// Realiza la actualizacion de la auditoria enviada por correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateIdConfirmado(int Id);

        #endregion
    }
}

