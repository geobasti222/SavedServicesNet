using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de AuditoriaReserva
    /// </summary>
    public interface IAuditoriaReserva
    {
        #region "Metodos de AuditoriaReserva"

        /// <summary>
        /// Lista todos errores de reserva en linea sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        List<AuditoriaReservaInfo> ListErroresSinConfirmar();

        /// <summary>
        /// Realiza la actualizacion de la auditoria enviada por correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateIdConfirmado(int Id);

        #endregion
    }
}

