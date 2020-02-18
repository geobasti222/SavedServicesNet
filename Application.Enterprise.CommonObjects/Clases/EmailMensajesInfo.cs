using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    public class EmailMensajesInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private string cod;

        public string Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string asunto;

        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string contenido_html;

        public string Contenido_html
        {
            get { return contenido_html; }
            set { contenido_html = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string contenido_txt;

        public string Contenido_txt
        {
            get { return contenido_txt; }
            set { contenido_txt = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string adjuntos;

        public string Adjuntos
        {
            get { return adjuntos; }
            set { adjuntos = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}
