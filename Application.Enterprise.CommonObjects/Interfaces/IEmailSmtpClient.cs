using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de SmtpClient de Email
    /// </summary>
    public interface IEmailSmtpClient
    {
        #region "Metodos de SmtpClient"

        /// <summary>
        /// lista todos los clientes smtp
        /// </summary>
        /// <returns></returns>
        List<EmailSmtpClientInfo> List();

        /// <summary>
        /// Trae cliente smtp por codigo
        /// </summary>
        /// <returns></returns>
        EmailSmtpClientInfo ListXCod(string cod);

        /// <summary>
        /// Insertar un cliente smtp
        /// </summary>
        /// <returns></returns>
        bool Insert(EmailSmtpClientInfo item);

        /// <summary>
        /// Actualizar un cliente smtp
        /// </summary>
        /// <returns></returns>
        bool Update(EmailSmtpClientInfo item);
        
        #endregion
    }
}
