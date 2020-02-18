using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class HistoricoClienteInfo
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

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit; }
            set { nit = value; }
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

        private int estadocliente;
        /// <summary>
        /// 
        /// </summary>
        public int EstadoCliente
        {
            get { return estadocliente; }
            set { estadocliente = value; }
        }

        private int nInactividad;
        /// <summary>
        /// 
        /// </summary>
        public int NInactividad
        {
            get { return nInactividad; }
            set { nInactividad = value; }
        }

        private int nIngreso;
        /// <summary>
        /// 
        /// </summary>
        public int NIngreso
        {
            get { return nIngreso; }
            set { nIngreso = value; }
        }

        private int desmantelado;
        /// <summary>
        /// 
        /// </summary>
        public int Desmantelado
        {
            get { return desmantelado; }
            set { desmantelado = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private int codigoregional;
        /// <summary>
        /// 
        /// </summary>
        public int CodigoRegional
        {
            get { return codigoregional; }
            set { codigoregional = value; }
        }

        private int proceso;
        /// <summary>
        /// 
        /// </summary>
        public int Proceso
        {
            get { return proceso; }
            set { proceso = value; }
        }

        private int activo;
        /// <summary>
        /// 
        /// </summary>
        public int Activo
        {
            get { return activo; }
            set { activo = value; }
        }

    }
}
