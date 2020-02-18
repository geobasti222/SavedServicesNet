using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ReglasOperadoresInfo
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
            get { return nombre.ToUpper(); }
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

        private int idcampo;
        /// <summary>
        /// 
        /// </summary>
        public int IdCampo
        {
            get { return idcampo; }
            set { idcampo = value; }
        }

        private int simple;
        /// <summary>
        /// 
        /// </summary>
        public int Simple
        {
            get { return simple; }
            set { simple = value; }
        }
    }
}
