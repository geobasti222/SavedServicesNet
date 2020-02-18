using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class DesmanteladasInfo
    {
        private string _numeropedido;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroPedido
        {
            get { return _numeropedido; }
            set { _numeropedido = value; }
        }

        private string _nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return _nit; }
            set { _nit  = value; }
        }

        private string _cliente;
        /// <summary>
        /// 
        /// </summary>
        public string Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private string _zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return _zona; }
            set { _zona = value; }
        }

        private string _descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion= value; }
        }
        
        private string _campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return _campana; }
            set { _campana= value; }
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
