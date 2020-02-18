using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class EstadosPremiosInfo
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

        private int idregla;
        /// <summary>
        /// 
        /// </summary>
        public int IdRegla
        {
            get { return idregla; }
            set { idregla = value; }
        }

        private int estado;
        /// <summary>
        /// 
        /// </summary>
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int tipoestado;
        /// <summary>
        /// 
        /// </summary>
        public int TipoEstado
        {
            get { return tipoestado; }
            set { tipoestado = value; }
        }

        private int cantidad;
        /// <summary>
        /// 
        /// </summary>
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}
