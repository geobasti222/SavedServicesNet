using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PremiosPremiosInfo
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

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string plu;
        /// <summary>
        /// 
        /// </summary>
        public string Plu
        {
            get { return plu; }
            set { plu = value; }
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

        private int tipopremio;
        /// <summary>
        /// 
        /// </summary>
        public int TipoPremio
        {
            get { return tipopremio; }
            set { tipopremio = value; }
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
