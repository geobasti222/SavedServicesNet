using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class LideresInfo
    {
        private string cedula;
        /// <summary>
        /// 
        /// </summary>
        public string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }

        private string nombres;
        /// <summary>
        /// 
        /// </summary>
        public string Nombres
        {
            get { return nombres.Trim().ToUpper(); }
            set { nombres = value; }
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

        private string sexo;
        /// <summary>
        /// 
        /// </summary>
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
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

        private string nombreuno;
        /// <summary>
        /// 
        /// </summary>
        public string NombreUno
        {
            get { return nombreuno.Trim().ToUpper(); }
            set { nombreuno = value; }
        }

        private string nombredos;
        /// <summary>
        /// 
        /// </summary>
        public string NombreDos
        {
            get { return nombredos.Trim().ToUpper(); }
            set { nombredos = value; }
        }

        private string apellidouno;
        /// <summary>
        /// 
        /// </summary>
        public string ApellidoUno
        {
            get { return apellidouno.Trim().ToUpper(); }
            set { apellidouno = value; }
        }

        private string apellidodos;
        /// <summary>
        /// 
        /// </summary>
        public string ApellidoDos
        {
            get { return apellidodos.Trim().ToUpper(); }
            set { apellidodos = value; }
        }

        private string direccion;
        /// <summary>
        /// 
        /// </summary>
        public string Direccion
        {
            get { return direccion.Trim().ToUpper(); }
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

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
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

        private int idtipored;
        /// <summary>
        /// 
        /// </summary>
        public int IdTipoRed
        {
            get { return idtipored; }
            set { idtipored = value; }
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


        private string tiporednombre;
        /// <summary>
        /// 
        /// </summary>
        public string TipoRedNombre
        {
            get { return tiporednombre; }
            set { tiporednombre = value; }
        }

        private string descripcioncombos;
        /// <summary>
        /// 
        /// </summary>
        public string DescripcionCombos
        {
            get
            {
                descripcioncombos = Nombres.Trim() + " - " + TipoRedNombre.Trim();
                return descripcioncombos;
            }
            set { descripcioncombos = value; }
        }
    }
}
