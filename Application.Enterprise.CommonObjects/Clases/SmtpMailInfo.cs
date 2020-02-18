using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SmtpMailInfo
    {
        private int id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string emailpara;
        /// <summary>
        /// 
        /// </summary>
        public string EmailPara
        {
            get { return emailpara; }
            set { emailpara = value; }
        }
        
        private string emailparanivi;
        /// <summary>
        /// 
        /// </summary>
        public string EmailParaNivi
        {
            get { return emailparanivi; }
            set { emailparanivi = value; }
        }

        private string emaildesde;
        /// <summary>
        /// 
        /// </summary>
        public string EmailDesde
        {
            get { return emaildesde; }
            set { emaildesde = value; }
        }

        private string asunto;
        /// <summary>
        /// 
        /// </summary>
        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }

        private string cuerpomsj;
        /// <summary>
        /// 
        /// </summary>
        public string CuerpoMsj
        {
            get { return cuerpomsj; }
            set { cuerpomsj = value; }
        }

        private string servidorcorreo;
        /// <summary>
        /// 
        /// </summary>
        public string ServidorCorreo
        {
            get { return servidorcorreo; }
            set { servidorcorreo = value; }
        }

        private int puerto;
        /// <summary>
        /// 
        /// </summary>
        public int Puerto
        {
            get { return puerto; }
            set { puerto = value; }
        }

        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string password;
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private bool autenticacionssl;
        /// <summary>
        /// 
        /// </summary>
        public bool AutenticacionSSL
        {
            get { return autenticacionssl; }
            set { autenticacionssl = value; }
        }

        private string host;
        /// <summary>
        /// 
        /// </summary>
        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        private int activo;
        /// <summary>
        /// 
        /// </summary>
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private int idtipo;
        /// <summary>
        /// 
        /// </summary>
        public int IdTipoMensaje
        {
            get { return idtipo; }
            set { idtipo = value; }
        }

        private string tipomensaje;
        /// <summary>
        /// 
        /// </summary>
        public string TipoMensaje
        {
            get { return tipomensaje; }
            set { tipomensaje = value; }
        }

        private int activotipomensaje;
        /// <summary>
        /// 
        /// </summary>
        public int ActivoTipoMensaje
        {
            get { return activotipomensaje; }
            set { activotipomensaje = value; }
        }

    }
}
