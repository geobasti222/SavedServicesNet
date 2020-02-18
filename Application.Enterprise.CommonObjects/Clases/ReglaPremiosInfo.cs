using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ReglaPremiosInfo
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

        private string campanaini;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaIni
        {
            get { return campanaini; }
            set { campanaini = value; }
        }

        private string campanaentre;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaEntre
        {
            get { return campanaentre; }
            set { campanaentre = value; }
        }

        private int valormin;
        /// <summary>
        /// 
        /// </summary>
        public int ValorMin
        {
            get { return valormin; }
            set { valormin = value; }
        }

        private decimal valormax;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorMax
        {
            get { return valormax; }
            set { valormax = value; }
        }

        private int formapag;
        /// <summary>
        /// 
        /// </summary>
        public int FormaPag
        {
            get { return formapag; }
            set { formapag = value; }
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

        private int zonas;
        /// <summary>
        /// 
        /// </summary>
        public int Zonas
        {
            get { return zonas; }
            set { zonas = value; }
        }

        private int estados;
        /// <summary>
        /// 
        /// </summary>
        public int Estados
        {
            get { return estados; }
            set { estados = value; }
        }

        private int premios;
        /// <summary>
        /// 
        /// </summary>
        public int Premios
        {
            get { return premios; }
            set { premios = value; }
        }

        private int totalizado;
        /// <summary>
        /// 
        /// </summary>
        public int Totalizado
        {
            get { return totalizado; }
            set { totalizado = value; }
        }

        private int estadoRegla;
        /// <summary>
        /// 
        /// </summary>
        public int EstadoRegla
        {
            get { return estadoRegla; }
            set { estadoRegla = value; }
        }

        private int mensajevalor;
        /// <summary>
        /// 
        /// </summary>
        public int Mensajevalor
        {
            get { return mensajevalor; }
            set { mensajevalor = value; }
        }
    }
}
