using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class TransportistaInfo
    {
        private string idtrlz;
        /// <summary>
        /// 
        /// </summary>
        public string IdTransportista
        {
            get { return idtrlz; }
            set { idtrlz = value; }
        }

        private string razonsocial;
        /// <summary>
        /// 
        /// </summary>
        public string RazonSocial
        {
            get { return razonsocial.Trim(); }
            set { razonsocial = value; }
        }

        private string razonsocialdireccion;
        /// <summary>
        /// 
        /// </summary>
        public string RazonSocialDireccion
        {
            get
            {
                return RazonSocial.ToUpper() + ", DIRECCIÓN: " + Direccion.ToUpper();
            }
            set { razonsocialdireccion = value; }
        }

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string NIT
        {
            get { return nit; }
            set { nit = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
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

        private string telefono;
        /// <summary>
        /// 
        /// </summary>
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
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

        private int tipolitr;
        /// <summary>
        /// 
        /// </summary>
        public int TipoLitr
        {
            get { return tipolitr; }
            set { tipolitr = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
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

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }


    }
}
