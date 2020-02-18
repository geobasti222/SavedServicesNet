using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    public class EmailMensajes : IEmailMensajes
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.EmailMensajes module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>

        public EmailMensajes()
        {
            module = new Application.Enterprise.Data.EmailMensajes();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public EmailMensajes(string databaseName)
        {
            module = new Application.Enterprise.Data.EmailMensajes(databaseName);
        }

        public List<EmailMensajesInfo> List() {
            return module.List();
        }

        public EmailMensajesInfo ListXCod(string cod)
        {
            return module.ListXCod(cod);
        }

        /// <summary>
        /// Insertar un cliente smtp
        /// </summary>
        /// <returns></returns>
        public bool Insert(EmailMensajesInfo item)
        {
            return module.Insert(item);
        }

        /// <summary>
        /// Actualizar un cliente smtp
        /// </summary>
        /// <returns></returns>
        public bool Update(EmailMensajesInfo item)
        {
            return module.Update(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensajecod"></param>
        /// <param name="nit"></param>
        /// <returns></returns>
        public bool Enviar(string mensajecod, string stmpclient_cod, string nit, string usuario)
        {
            SmtpClient client;
            MailMessage mensaje = new MailMessage();
            EmailMensajesInfo mensajeInfo;
            EmailSmtpClientInfo smtpclienteInfo;
            EmailEnviadosInfo enviadoInfo;
            ClienteInfo cliente;

            String[] result;
            
            try {
                mensajeInfo = module.ListXCod(mensajecod);
                EmailSmtpClient module2 = new EmailSmtpClient("conexion");
                Cliente module3 = new Cliente("conexion");
                smtpclienteInfo = module2.ListXCod(stmpclient_cod);

                client = new SmtpClient();

                client.Credentials = new NetworkCredential(smtpclienteInfo.CredencialUser, smtpclienteInfo.CredencialPass);
                client.Port = smtpclienteInfo.Port;
                client.Host = smtpclienteInfo.Host;
                client.EnableSsl = (smtpclienteInfo.Enablessl == "0")?false:true;

                mensaje.From = new MailAddress(smtpclienteInfo.Email, smtpclienteInfo.Nombre, Encoding.UTF8);

                mensaje.Body = mensajeInfo.Contenido_html;

                mensaje.BodyEncoding = Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                mensaje.Subject = mensajeInfo.Asunto;
                mensaje.SubjectEncoding = Encoding.UTF8;

                AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mensajeInfo.Contenido_txt, null, "text/plain");
                AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(mensajeInfo.Contenido_html, null, "text/html");

                mensaje.AlternateViews.Add(plainView);
                mensaje.AlternateViews.Add(htmlView);

                result = mensajeInfo.Adjuntos.Split(';');
                foreach (string adjunto in result)
                {
                    if (File.Exists(adjunto)) mensaje.Attachments.Add(new Attachment(adjunto));
                }

                mensaje.Headers.Add("MIME-Version", "1.0");
                mensaje.Headers.Add("Content-type", "text/html; charset=utf-8");
                mensaje.Headers.Add("From", mensaje.From.DisplayName + "<" + mensaje.From.Address + ">");
                mensaje.Headers.Add("X-Sender", mensaje.From.DisplayName);
                mensaje.Headers.Add("X_Mailer", "DOT NET");
                mensaje.Headers.Add("Return-Path", mensaje.From.Address);

                cliente = module3.ListxNIT(nit);

                string nombrecompleto = cliente.Nombre1 + ((cliente.Nombre2.Length > 0) ? " " + cliente.Nombre2 : String.Empty) + " " + cliente.Apellido1 + ((cliente.Nombre2.Length > 0) ? " " + cliente.Nombre2 : String.Empty);

                mensaje.To.Add(new MailAddress(cliente.Email, nombrecompleto, Encoding.UTF8));

                client.Send(mensaje);

                EmailEnviados module4 = new EmailEnviados("conexion");

                enviadoInfo = new EmailEnviadosInfo();
                enviadoInfo.MensajeCod = mensajeInfo.Cod;
                enviadoInfo.SmtpclientCod = smtpclienteInfo.Cod;
                enviadoInfo.Destinatario = cliente.Email + ":"+ nombrecompleto;
                enviadoInfo.Copia = String.Empty;
                enviadoInfo.CopiaOculta = String.Empty;
                enviadoInfo.ClientesNit = cliente.Nit;
                enviadoInfo.MensajeCod = mensajeInfo.Cod;
                enviadoInfo.SVDNSUSUARIOSUsuario = usuario;

                module4.Insert(enviadoInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateCopyMessage(): {0}", ex.ToString());
            }

            return true;
        }

    }
}
