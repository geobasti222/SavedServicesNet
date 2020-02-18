using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ZonaInfo
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

        private string codgereg1;
        /// <summary>
        /// 
        /// </summary>
        public string CodGereg1
        {
            get { return codgereg1; }
            set { codgereg1 = value; }
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
            get { if (codciudad == null) { return ""; } return codciudad.Trim(); }
            set { codciudad = value; }
        }

        private string codsector;
        /// <summary>
        /// 
        /// </summary>
        public string CodSector
        {
            get { if (codsector == null) { return ""; } return codsector.Trim(); }
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

        private int activo;
        /// <summary>
        /// 
        /// </summary>
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private string activonombre;
        /// <summary>
        /// 
        /// </summary>
        public string ActivoNombre
        {
            get { return activonombre; }
            set { activonombre = value; }
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

        private int diasborrador;
        /// <summary>
        /// 
        /// </summary>
        public int DiasBorrador
        {
            get { return diasborrador; }
            set { diasborrador = value; }
        }

        private int diasreserva;
        /// <summary>
        /// 
        /// </summary>
        public int DiasReserva
        {
            get { return diasreserva; }
            set { diasreserva = value; }
        }

        private int diasdegracia;
        /// <summary>
        /// 
        /// </summary>
        public int DiasDeGracia
        {
            get { return diasdegracia; }
            set { diasdegracia = value; }
        }

        private decimal valorfleteconiva;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFleteConIVA
        {
            get { return valorfleteconiva; }
            set { valorfleteconiva = value; }
        }



        private string nombreregional;
        /// <summary>
        /// 
        /// </summary>
        public string NombreRegional
        {
            get { return nombreregional; }
            set { nombreregional = value; }
        }

        private string telefuno;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoUnoRegional
        {
            get { return telefuno; }
            set { telefuno = value; }
        }

        private string telefdos;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoDosRegional
        {
            get { return telefdos; }
            set { telefdos = value; }
        }

        private string nombreregion;
        /// <summary>
        /// 
        /// </summary>
        public string NombreRegion
        {
            get { return nombreregion; }
            set { nombreregion = value; }
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

        private string cedulavendedor;
        /// <summary>
        /// 
        /// </summary>
        public string CedulaVendedor
        {
            get { return cedulavendedor; }
            set { cedulavendedor = value; }
        }

        private DateTime fechaingresovendedor;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaIngresoVendedor
        {
            get { return fechaingresovendedor; }
            set { fechaingresovendedor = value; }
        }

        private string telefonouno;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoUnoVendedor
        {
            get { return telefonouno; }
            set { telefonouno = value; }
        }

        private string telefonodos;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoDosVendedor
        {
            get { return telefonodos; }
            set { telefonodos = value; }
        }

        private string telefonotres;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoTresVendedor
        {
            get { return telefonotres; }
            set { telefonotres = value; }
        }

        private string emailnivi;
        /// <summary>
        /// 
        /// </summary>
        public string EmailNivi
        {
            get { return emailnivi; }
            set { emailnivi = value; }
        }

        private string razonsocial;
        /// <summary>
        /// 
        /// </summary>
        public string NombreTransportista
        {
            get { return razonsocial; }
            set { razonsocial = value; }
        }

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string NitTransportista
        {
            get { return nit; }
            set { nit = value; }
        }

        private string direcciontra;
        /// <summary>
        /// 
        /// </summary>
        public string DireccionTransportista
        {
            get { return direcciontra; }
            set { direcciontra = value; }
        }

        private string telefono;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoTransportista
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string emailtra;
        /// <summary>
        /// 
        /// </summary>
        public string EmailTransportista
        {
            get { return emailtra; }
            set { emailtra = value; }
        }

        private int tipolitr;
        /// <summary>
        /// 
        /// </summary>
        public int TipoLiTransportista
        {
            get { return tipolitr; }
            set { tipolitr = value; }
        }

        private int pre_codigo;
        /// <summary>
        /// 
        /// </summary>
        public int IdPromesa
        {
            get { return pre_codigo; }
            set { pre_codigo = value; }
        }

        private string pre_depto;
        /// <summary>
        /// 
        /// </summary>
        public string Departamento
        {
            get { return pre_depto; }
            set { pre_depto = value; }
        }

        private string pre_municipio;
        /// <summary>
        /// 
        /// </summary>
        public string Municipio
        {
            get { return pre_municipio; }
            set { pre_municipio = value; }
        }

        private int pre_tiempo;
        /// <summary>
        /// 
        /// </summary>
        public int TiempoEntrega
        {
            get { return pre_tiempo; }
            set { pre_tiempo = value; }
        }

        private decimal pre_1_20;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor_1_20
        {
            get { return pre_1_20; }
            set { pre_1_20 = value; }
        }

        private decimal pre_21_45;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor_21_45
        {
            get { return pre_21_45; }
            set { pre_21_45 = value; }
        }

        private decimal pre_46_85;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor_46_85
        {
            get { return pre_46_85; }
            set { pre_46_85 = value; }
        }

        private string pre_transportadora;
        /// <summary>
        /// 
        /// </summary>
        public string Transportadora
        {
            get { return pre_transportadora; }
            set { pre_transportadora = value; }
        }

        private bool mai;
        /// <summary>
        /// 
        /// </summary>
        public bool MAI
        {
            get { return mai; }
            set { mai = value; }
        }

        private bool mrl;
        /// <summary>
        /// 
        /// </summary>
        public bool MRL
        {
            get { return mrl; }
            set { mrl = value; }
        }

        private bool diaria;
        /// <summary>
        /// 
        /// </summary>
        public bool FacturacionDiaria
        {
            get { return diaria; }
            set { diaria = value; }
        }

        private bool veintedias;
        /// <summary>
        /// 
        /// </summary>
        public bool Facturacion21Dias
        {
            get { return veintedias; }
            set { veintedias = value; }
        }

        private string unineg;
        /// <summary>
        /// 
        /// </summary>
        public string UnidadNegocio
        {
            get { return unineg.Trim(); }
            set { unineg = value; }
        }

        private string idzonamaestra;
        /// <summary>
        /// 
        /// </summary>
        public string IdZonaMaestra
        {
            get { if (idzonamaestra == null) { return ""; } return idzonamaestra.Trim(); }
            set { idzonamaestra = value; }
        }

        private string cod_rango;
        /// <summary>
        /// 
        /// </summary>
        public string Cod_Rango
        {
            get { if (cod_rango == null) { return ""; } return cod_rango.Trim(); }
            set { cod_rango = value; }
        }

        private string tipozona;
        /// <summary>
        /// 
        /// </summary>
        public string TipoZona
        {
            get { if (tipozona == null) { return ""; } return tipozona.Trim(); }
            set { tipozona = value; }
        }

        private int sumagerente;
        /// <summary>
        /// 
        /// </summary>
        public int SumaGerente
        {
            get { return sumagerente; }
            set { sumagerente = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { if (vendedor == null) { return ""; } return vendedor.Trim(); }
            set { vendedor = value; }
        }

        private string zona_mtra;
        /// <summary>
        /// 
        /// </summary>
        public string Zona_Mtra
        {
            get { if (zona_mtra == null) { return ""; } return zona_mtra.Trim(); }
            set { zona_mtra = value; }
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
       
    }
}
