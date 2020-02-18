using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// JA
    /// </summary>
    
    public class CampanaInfo
    {
        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
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

        private string catalogo;
        /// <summary>
        /// 
        /// </summary>
        public string Catalogo
        {
            get { return catalogo; }
            set { catalogo = value; }
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

        private string ano;
        /// <summary>
        /// 
        /// </summary>
        public string Ano
        {
            get { return ano; }
            set { ano = value; }
        }


        private int campanafinal;
        /// <summary>
        /// 
        /// </summary>
        public int CampanaFinal
        {
            get { return campanafinal; }
            set { campanafinal = value; }
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
