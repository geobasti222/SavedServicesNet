using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    class EmailSmtpClient:IEmailSmtpClient
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.EmailSmtpClient module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>

        public EmailSmtpClient()
        {
            module = new Application.Enterprise.Data.EmailSmtpClient();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public EmailSmtpClient(string databaseName)
        {
            module = new Application.Enterprise.Data.EmailSmtpClient(databaseName);
        }

        public List<EmailSmtpClientInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        public EmailSmtpClientInfo ListXCod(string cod)
        {
            return module.ListXCod(cod);
        }

        /// <summary>
        /// Insertar un cliente smtp
        /// </summary>
        /// <returns></returns>
        public bool Insert(EmailSmtpClientInfo item)
        {
            return module.Insert(item);
        }

        /// <summary>
        /// Actualizar un cliente smtp
        /// </summary>
        /// <returns></returns>
        public bool Update(EmailSmtpClientInfo item)
        {
            return module.Update(item);
        }
    }
}
