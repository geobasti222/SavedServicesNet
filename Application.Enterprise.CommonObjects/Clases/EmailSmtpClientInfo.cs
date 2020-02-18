using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class EmailSmtpClientInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private string cod;

        public string Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string credencialuser;

        public string CredencialUser
        {
            get { return credencialuser; }
            set { credencialuser = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string credencialpass;

        public string CredencialPass
        {
            get { return credencialpass; }
            set { credencialpass = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int port;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string host;

        public string Host
        {
            get { return host; }
            set { host = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string enablessl;

        public string Enablessl
        {
            get { return enablessl; }
            set { enablessl = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int maximoenvios;

        public int MaximoEnvios
        {
            get { return maximoenvios; }
            set { maximoenvios = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
