using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AmarreReglaInfo
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

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
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

        private int tipoamarre;
        /// <summary>
        /// 
        /// </summary>
        public int Tipoamarre
        {
            get { return tipoamarre; }
            set { tipoamarre = value; }
        }

        private int tipoamarrepremio;
        /// <summary>
        /// 
        /// </summary>
        public int Tipoamarrepremio
        {
            get { return tipoamarrepremio; }
            set { tipoamarrepremio = value; }
        }

        private int porvalor;
        /// <summary>
        /// 
        /// </summary>
        public int Porvalor
        {
            get { return porvalor; }
            set { porvalor = value; }
        }

        private int porfecha;
        /// <summary>
        /// 
        /// </summary>
        public int Porfecha
        {
            get { return porfecha; }
            set { porfecha = value; }
        }
        

        private DateTime fechaini;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fechaini
        {
            get { return fechaini; }
            set { fechaini = value; }
        }

        private DateTime fechafin;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fechafin
        {
            get { return fechafin; }
            set { fechafin = value; }
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

        private int valormax;
        /// <summary>
        /// 
        /// </summary>
        public int Valormax
        {
            get { return valormax; }
            set { valormax = value; }
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
