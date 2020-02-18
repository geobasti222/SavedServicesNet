using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ParametrosInfo
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

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string valor;
        /// <summary>
        /// 
        /// </summary>
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private string concepto;
        /// <summary>
        /// 
        /// </summary>
        public string Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        private string tipo;
        /// <summary>
        /// 
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
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

    }
}
