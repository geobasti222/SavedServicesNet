using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class HistoricoClienteResumenInfo
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

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private int estadoid;
        /// <summary>
        /// 
        /// </summary>
        public int EstadoId
        {
            get { return estadoid; }
            set { estadoid = value; }
        }

        private int numeroinactividades;
        /// <summary>
        /// 
        /// </summary>
        public int NumeroInactividades
        {
            get { return numeroinactividades; }
            set { numeroinactividades = value; }
        }

        private int numeroingreso;
        /// <summary>
        /// 
        /// </summary>
        public int NumeroIngreso
        {
            get { return numeroingreso; }
            set { numeroingreso = value; }
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
