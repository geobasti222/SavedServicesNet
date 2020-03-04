using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class NotificaInfo
    {
        private int mt_id;
        /// <summary>
        /// 
        /// </summary>
        public int Mt_Id
        {
            get { return mt_id ; }
            set { mt_id = value; }
        }

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit ; }
            set { nit = value; }
        }

        private bool estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return estado ; }
            set { estado = value; }
        }

        private string email;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string telefono;
        /// <summary>
        /// 
        /// </summary>
        public string Telefono
        {
            get { return telefono ; }
            set { telefono = value; }
        }

        private decimal valor;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private decimal saldo;
        /// <summary>
        /// 
        /// </summary>
        public decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        private DateTime fecha;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private DateTime vencimiento;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Vencimiento
        {
            get { return vencimiento; }
            set { vencimiento = value; }
        }

        private string razonsocial;
        /// <summary>
        /// 
        /// </summary>
        public string RazonSocial
        {
            get { return razonsocial; }
            set { razonsocial = value; }
        }

        private string nombre1;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre1
        {
            get { return nombre1 ; }
            set { nombre1 = value; }
        }

      
        
     
      

        private string nombrelider;
        /// <summary>
        /// 
        /// </summary>
        public string NombreLider
        {
            get { return nombrelider; }
            set { nombrelider = value; }
        }

        private string emailider;
        /// <summary>
        /// 
        /// </summary>
        public string EmaiLider
        {
            get { return emailider; }
            set { emailider = value; }
        }

        private string telefonolider;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoLider
        {
            get { return telefonolider; }
            set { telefonolider = value; }
        }


        private string documento;
        /// <summary>
        /// 
        /// </summary>
        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }


        private DateTime fechaenvio;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaEnvio
        {
            get { return fechaenvio; }
            set { fechaenvio = value; }
        }

        private string emailparaglod;
        /// <summary>
        /// 
        /// </summary>
        public string EmailParaGlod
        {
            get { return emailparaglod; }
            set { emailparaglod = value; }
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
        private string emailasunto;
        /// <summary>
        /// 
        /// </summary>
        public string EmailAsunto
        {
            get { return emailasunto; }
            set { emailasunto = value; }
        }
        private string emailcuerpo;
        /// <summary>
        /// 
        /// </summary>
        public string EmailCuerpo
        {
            get { return emailcuerpo; }
            set { emailcuerpo = value; }
        }

        private string emailpassword;
        /// <summary>
        /// 
        /// </summary>
        public string EmailPassword
        {
            get { return emailpassword; }
            set { emailpassword = value; }
        }
        private string emailusuario;
        /// <summary>
        /// 
        /// </summary>
        public string EmailUsuario
        {
            get { return emailusuario; }
            set { emailusuario = value; }
        }

        private int emailpuerto;
        /// <summary>
        /// 
        /// </summary>
        public int EmailPuerto
        {
            get { return emailpuerto; }
            set { emailpuerto = value; }
        }

        private bool emailssl;
        /// <summary>
        /// 
        /// </summary>
        public bool EmailSsl
        {
            get { return emailssl; }
            set { emailssl = value; }
        }

        private string  emailhost;
        /// <summary>
        /// 
        /// </summary>
        public string EmailHost
        {
            get { return emailhost; }
            set { emailhost = value; }
        }

        private string direccion;
        /// <summary>
        /// 
        /// </summary>
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string ciudad;
        /// <summary>
        /// 
        /// </summary>
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        private int puntos;
        /// <summary>
        /// 
        /// </summary>
        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

        private string guia;
        /// <summary>
        /// 
        /// </summary>
        public string Guia
        {
            get { return guia; }
            set { guia = value; }
        }

        private int tipoenvio;
        /// <summary>
        /// 
        /// </summary>
        public int TipoEnvio
        {
            get { return tipoenvio; }
            set { tipoenvio = value; }
        }
        private string factura;
        /// <summary>
        /// 
        /// </summary>
        public string Factura
        {
            get { return factura; }
            set { factura = value; }
        }

        public virtual Error Error
        {
            get;
            set;
        }

    }
}
