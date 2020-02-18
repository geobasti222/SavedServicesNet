using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// JA
    /// </summary>
    
    public class CatalogoInfo
    {
        private string codigo;
        /// <summary>
        /// 
        /// </summary>
        public string Codigo
        {
            get { return codigo.Trim(); }
            set { codigo = value; }
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

        private string ano;
        /// <summary>
        /// 
        /// </summary>
        public string Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        private DateTime fechaini;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaInicial
        {
            get { return fechaini; }
            set { fechaini = value; }
        }

        private DateTime fechafin;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaFin
        {
            get { return fechafin; }
            set { fechafin = value; }
        }

        private string grupocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public string GrupoCatalogo
        {
            get { return grupocatalogo.ToUpper(); }
            set { grupocatalogo = value; }
        }


        private bool estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        private string unineg;
        /// <summary>
        /// 
        /// </summary>
        public string Unineg
        {
            get { return unineg; }
            set { unineg = value; }
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

        public virtual Error Error
        {
            get;
            set;
        }


    }
}
