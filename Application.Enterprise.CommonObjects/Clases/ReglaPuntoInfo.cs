using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// JA
    /// </summary>
    
    public class ReglaPuntoInfo
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

        private int puntosad;
        /// <summary>
        /// 
        /// </summary>
        public int PuntosAd
        {
            get { return puntosad; }
            set { puntosad = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int cantidadconse;
        /// <summary>
        /// 
        /// </summary>
        public int CantidadConse
        {
            get { return cantidadconse; }
            set { cantidadconse = value; }
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

        private int valormin;
        /// <summary>
        /// 
        /// </summary>
        public int Valormin
        {
            get { return valormin; }
            set { valormin = value; }
        }

        private int idxcampana;
        /// <summary>
        /// 
        /// </summary>
        public int IdxCampana
        {
            get { return idxcampana; }
            set { idxcampana = value; }
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

        private DateTime fecha;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
