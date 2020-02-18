using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    ///
    /// </summary>
    
    public class DespachosInfo
    {
        private string numerodespacho;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroDespacho
        {
            get { return numerodespacho; }
            set { numerodespacho = value; }
        }

        private DateTime fechadespacho;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaDespacho
        {
            get { return fechadespacho; }
            set { fechadespacho = value; }
        }

        private string numeroaduanaje;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroAduanaje
        {
            get { return numeroaduanaje; }
            set { numeroaduanaje = value; }
        }

        private DateTime fechaaduanaje;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaAduanaje
        {
            get { return fechaaduanaje; }
            set { fechaaduanaje = value; }
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

        private string numerofactura;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroFactura
        {
            get { return numerofactura; }
            set { numerofactura = value; }
        }

        private string aduanadecargueconguia;
        /// <summary>
        /// 
        /// </summary>
        public string AduanaDeCargueConGuia
        {
            get { return aduanadecargueconguia; }
            set { aduanadecargueconguia = value; }
        }

        private DateTime fechacargueconguia;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCargueConGuia
        {
            get { return fechacargueconguia; }
            set { fechacargueconguia = value; }
        }

        private string aduanadecargueconcodigo;
        /// <summary>
        /// 
        /// </summary>
        public string AduanaDeCargueConCodigo
        {
            get { return aduanadecargueconcodigo; }
            set { aduanadecargueconcodigo = value; }
        }

        private DateTime fechacargueconcodigo;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCargueConCodigo
        {
            get { return fechacargueconcodigo; }
            set { fechacargueconcodigo = value; }
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

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        private string razon_social;
        /// <summary>
        /// 
        /// </summary>
        public string RazonSocial
        {
            get { return razon_social; }
            set { razon_social = value; }
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

        private string nombreciudad;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiudad
        {
            get { return nombreciudad; }
            set { nombreciudad = value; }
        }

        private decimal uds_aduanadas;
        /// <summary>
        /// 
        /// </summary>
        public decimal UnidadesAduanadas
        {
            get { return uds_aduanadas; }
            set { uds_aduanadas = value; }
        }

        private string numeropedido;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroPedido
        {
            get { return numeropedido; }
            set { numeropedido = value; }
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

        private string nombrevendedor;
        /// <summary>
        /// 
        /// </summary>
        public string NombreVendedor
        {
            get { return nombrevendedor; }
            set { nombrevendedor = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private string nombrequienaduano;
        /// <summary>
        /// 
        /// </summary>
        public string NombreQuienAduano
        {
            get { return nombrequienaduano; }
            set { nombrequienaduano = value; }
        }

        private string facturadespacho;
        /// <summary>
        /// 
        /// </summary>
        public string FacturaDespacho
        {
            get { return facturadespacho; }
            set { facturadespacho = value; }
        }

        private string nombrequiendespacho;
        /// <summary>
        /// 
        /// </summary>
        public string NombreQuienDespacho
        {
            get { return nombrequiendespacho; }
            set { nombrequiendespacho = value; }
        }

        private string transportadora;
        /// <summary>
        /// 
        /// </summary>
        public string Transportadora
        {
            get { return transportadora; }
            set { transportadora = value; }
        }
    }
}
