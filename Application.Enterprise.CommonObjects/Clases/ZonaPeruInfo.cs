using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ZonaPeruInfo
    {
        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona.Trim(); }
            set { zona = value; }
        }

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion.Trim(); }
            set { descripcion = value; }
        }

        private string codlocalidad;
        /// <summary>
        /// 
        /// </summary>
        public string CodLocalidad
        {
            get { return codlocalidad.Trim(); }
            set { codlocalidad = value; }
        }

        private string nitcliente;
        /// <summary>
        /// 
        /// </summary>
        public string NitCliente
        {
            get { return nitcliente.Trim(); }
            set { nitcliente = value; }
        }

        private string nitproveedor;
        /// <summary>
        /// 
        /// </summary>
        public string NitProveedor
        {
            get { return nitproveedor.Trim(); }
            set { nitproveedor = value; }
        }

        private string contacto;
        /// <summary>
        /// 
        /// </summary>
        public string Contacto
        {
            get { return contacto.Trim(); }
            set { contacto = value; }
        }

        private string direccion;
        /// <summary>
        /// 
        /// </summary>
        public string Direccion
        {
            get { return direccion.Trim(); }
            set { direccion = value; }
        }

        private string telefonos;
        /// <summary>
        /// 
        /// </summary>
        public string Telefonos
        {
            get { return telefonos.Trim(); }
            set { telefonos = value; }
        }

        private string fax;
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string email;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return email.Trim(); }
            set { email = value; }
        }

        private string codgereg;
        /// <summary>
        /// 
        /// </summary>
        public string CodGereg
        {
            get { return codgereg.Trim(); }
            set { codgereg = value; }
        }

        private string localizacion;
        /// <summary>
        /// 
        /// </summary>
        public string Localizacion
        {
            get { return localizacion.Trim(); }
            set { localizacion = value; }
        }

        private string mailgroup;
        /// <summary>
        /// 
        /// </summary>
        public string MailGroup
        {
            get { return mailgroup.Trim(); }
            set { mailgroup = value; }
        }

        private int excluido;
        /// <summary>
        /// 
        /// </summary>
        public int Excluido
        {
            get { return excluido; }
            set { excluido = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudad
        {
            get { return codciudad.Trim(); }
            set { codciudad = value; }
        }

        private string codsector;
        /// <summary>
        /// 
        /// </summary>
        public string CodSector
        {
            get { return codsector.Trim(); }
            set { codsector = value; }
        }

        private decimal valorflete;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFlete
        {
            get { return valorflete; }
            set { valorflete = value; }
        }

        private decimal valorflete1;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFlete1
        {
            get { return valorflete1; }
            set { valorflete1 = value; }
        }

        private DateTime fechacreacion;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCreacion
        {
            get { return fechacreacion; }
            set { fechacreacion = value; }
        }

        private string idvendedor;
        /// <summary>
        /// 
        /// </summary>
        public string IdVendedor
        {
            get { return idvendedor; }
            set { idvendedor = value; }
        }
    }
}
