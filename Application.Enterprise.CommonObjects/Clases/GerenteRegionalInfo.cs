using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// Gerente Regional JA
    /// </summary>
    
    public class GerenteRegionalInfo
    {
        private string codgereg;
        /// <summary>
        /// 
        /// </summary>
        public string CodGeReg
        {
            get { return codgereg; }
            set { codgereg = value; }
        }

        private string cod_rango;
        /// <summary>
        /// 
        /// </summary>
        public string Cod_Rango
        {
            get { return cod_rango; }
            set { cod_rango = value; }
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

      
        private string ciudad;
        /// <summary>
        /// 
        /// </summary>
        public string Ciudad
        {
            get { return ciudad.Trim(); }
            set { ciudad = value; }
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

