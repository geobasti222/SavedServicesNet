using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    public class EmailEnviadosInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string mensaje_cod;

        public string MensajeCod
        {
            get { return mensaje_cod; }
            set { mensaje_cod = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string smtpclient_cod;

        public string SmtpclientCod
        {
            get { return smtpclient_cod; }
            set { smtpclient_cod = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string destinatario;

        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string copia;

        public string Copia
        {
            get { return copia; }
            set { copia = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string copia_oculta;

        public string CopiaOculta
        {
            get { return copia_oculta; }
            set { copia_oculta = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string clientes_nit;

        public string ClientesNit
        {
            get { return clientes_nit; }
            set { clientes_nit = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string SVDN_SUSUARIOS_usuario;

        public string SVDNSUSUARIOSUsuario
        {
            get { return SVDN_SUSUARIOS_usuario; }
            set { SVDN_SUSUARIOS_usuario = value; }
        }
    }
}
