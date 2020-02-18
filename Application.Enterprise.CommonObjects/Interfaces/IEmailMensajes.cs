using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IEmailMensajes
    {
        #region "Metodos de SmtpClient"

        /// <summary>
        /// lista todos los clientes smtp
        /// </summary>
        /// <returns></returns>
        List<EmailMensajesInfo> List();

        /// <summary>
        /// Trae cliente smtp por codigo
        /// </summary>
        /// <returns></returns>
        EmailMensajesInfo ListXCod(string cod);

        /// <summary>
        /// Insertar un cliente smtp
        /// </summary>
        /// <returns></returns>
        bool Insert(EmailMensajesInfo item);

        /// <summary>
        /// Actualizar un cliente smtp
        /// </summary>
        /// <returns></returns>
        bool Update(EmailMensajesInfo item);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensajecod"></param>
        /// <param name="stmpclient_cod"></param>
        /// <param name="nit"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool Enviar(string mensajecod, string stmpclient_cod, string nit, string usuario);

        #endregion
    }
}
