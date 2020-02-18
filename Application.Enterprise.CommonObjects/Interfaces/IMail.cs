using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Mail
    /// </summary>
    public interface IMail
    {
        #region "Metodos de Mail"

        /// <summary>
        /// Lista la configuracion para enviar correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SmtpMailInfo ListxId(int Id);

        /// <summary>
        /// Lista la configuracion de un mail por tipo
        /// </summary>
        /// <param name="IdTipoMensaje"></param>
        /// <returns></returns>
        SmtpMailInfo ListxTipoMensaje(int IdTipoMensaje);


        #endregion
    }
}

