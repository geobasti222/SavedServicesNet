using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{

    public class VendedorInfo
    {
        private string codpais;
        /// <summary>
        /// 
        /// </summary>
        public string CodPais
        {
            get { return codpais; }
            set { codpais = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string IdVendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string cedula;
        /// <summary>
        /// 
        /// </summary>
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private DateTime fechaingreso;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaIngreso
        {
            get { return fechaingreso; }
            set { fechaingreso = value; }
        }

        private decimal comision;
        /// <summary>
        /// 
        /// </summary>
        public decimal Comision
        {
            get { return comision; }
            set { comision = value; }
        }

        private decimal recaudo_0;
        /// <summary>
        /// 
        /// </summary>
        public decimal Recaudo_0
        {
            get { return recaudo_0; }
            set { recaudo_0 = value; }
        }

        private decimal recaudo_30;
        /// <summary>
        /// 
        /// </summary>
        public decimal Recaudo_30
        {
            get { return recaudo_30; }
            set { recaudo_30 = value; }
        }

        private decimal recaudo_60;
        /// <summary>
        /// 
        /// </summary>
        public decimal Recaudo_60
        {
            get { return recaudo_60; }
            set { recaudo_60 = value; }
        }

        private decimal recaudo_90;
        /// <summary>
        /// 
        /// </summary>
        public decimal Recaudo_90
        {
            get { return recaudo_90; }
            set { recaudo_90 = value; }
        }

        private DateTime fechanacimiento;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaNacimiento
        {
            get { return fechanacimiento; }
            set { fechanacimiento = value; }
        }

        private string localizacion;
        /// <summary>
        /// 
        /// </summary>
        public string Localizacion
        {
            get { return localizacion; }
            set { localizacion = value; }
        }

        private string clasificacion;
        /// <summary>
        /// 
        /// </summary>
        public string Clasificacion
        {
            get { return clasificacion; }
            set { clasificacion = value; }
        }

        private string persona;
        /// <summary>
        /// 
        /// </summary>
        public string Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        private string sexo;
        /// <summary>
        /// 
        /// </summary>
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private string categoria;
        /// <summary>
        /// 
        /// </summary>
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
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

        private string nombreuno;
        /// <summary>
        /// 
        /// </summary>
        public string NombreUno
        {
            get { return nombreuno; }
            set { nombreuno = value; }
        }

        private string nombredos;
        /// <summary>
        /// 
        /// </summary>
        public string NombreDos
        {
            get { return nombredos; }
            set { nombredos = value; }
        }

        private string apellidouno;
        /// <summary>
        /// 
        /// </summary>
        public string ApellidoUno
        {
            get { return apellidouno; }
            set { apellidouno = value; }
        }

        private string apellidodos;
        /// <summary>
        /// 
        /// </summary>
        public string ApellidoDos
        {
            get { return apellidodos; }
            set { apellidodos = value; }
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

        private string email;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string telefonouno;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoUno
        {
            get { return telefonouno; }
            set { telefonouno = value; }
        }

        private string telefonodos;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoDos
        {
            get { return telefonodos; }
            set { telefonodos = value; }
        }

        private string telefonotres;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoTres
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

        private DateTime fechavigenciainicio;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaVigenciaInicio
        {
            get { return fechavigenciainicio; }
            set { fechavigenciainicio = value; }
        }

        private DateTime fechavigenciafin;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaVigenciaFin
        {
            get { return fechavigenciafin; }
            set { fechavigenciafin = value; }
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

        //--------------------------
        private string nombrepais;
        /// <summary>
        /// 
        /// </summary>
        public string NombrePais
        {
            get { return nombrepais; }
            set { nombrepais = value; }
        }

        private string codestado;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoEstado
        {
            get { return codestado; }
            set { codestado = value; }
        }

        private string nombreestado;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEstado
        {
            get { return nombreestado; }
            set { nombreestado = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
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

        private string sec_codsector;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoSector
        {
            get { return sec_codsector; }
            set { sec_codsector = value; }
        }

        private string sec_nomsector;
        /// <summary>
        /// 
        /// </summary>
        public string NombreSector
        {
            get { return sec_nomsector; }
            set { sec_nomsector = value; }
        }

        private string codzona;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoZona
        {
            get { return codzona; }
            set { codzona = value; }
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


        private string codigoregional;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoRegional
        {
            get { return codigoregional; }
            set { codigoregional = value; }
        }


        private string mailgroup;
        /// <summary>
        /// 
        /// </summary>
        public string MailGroup
        {
            get { return mailgroup; }
            set { mailgroup = value; }
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
        
        private bool termycond;
        /// <summary>
        /// 
        /// </summary>
        public bool TerminosyCondiciones
        {
            get { return termycond; }
            set { termycond = value; }
        }

        private DateTime fechaaceptacionterm;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaAceptacionTerminos
        {
            get { return fechaaceptacionterm; }
            set { fechaaceptacionterm = value; }
        }
        
        private bool mostrartermycond;
        /// <summary>
        /// 
        /// </summary>
        public bool MostrarTerminosyCondiciones
        {
            get { return mostrartermycond; }
            set { mostrartermycond = value; }
        }

        private int director;
        /// <summary>
        /// 
        /// </summary>
        public int Director
        {
            get { return director; }
            set { director = value; }
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
