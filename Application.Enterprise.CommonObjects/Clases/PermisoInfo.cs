using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PermisoInfo
    {
        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string funcionId;
        /// <summary>
        /// 
        /// </summary>
        public string FuncionId
        {
            get { return funcionId; }
            set { funcionId = value; }
        }

        private string funcion;
        /// <summary>
        /// 
        /// </summary>
        public string Funcion
        {
            get { return funcion; }
            set { funcion = value; }
        }

        private string formulario;
        /// <summary>
        /// 
        /// </summary>
        public string Formulario
        {
            get { return formulario; }
            set { formulario = value; }
        }

        private string estado;
        /// <summary>
        /// 
        /// </summary>
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
