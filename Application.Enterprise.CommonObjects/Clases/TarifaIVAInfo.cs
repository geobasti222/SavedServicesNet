using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class TarifaIVAInfo
    {
        private string tarifaiva;
        /// <summary>
        /// 
        /// </summary>
        public string IdTarifaIVA
        {
            get { return tarifaiva; }
            set { tarifaiva = value; }
        }

        private decimal porcentaje;
        /// <summary>
        /// 
        /// </summary>
        public decimal Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        private string cuentacompras;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaCompras
        {
            get { return cuentacompras; }
            set { cuentacompras = value; }
        }

        private string detallecompras;
        /// <summary>
        /// 
        /// </summary>
        public string DetalleCompras
        {
            get { return detallecompras; }
            set { detallecompras = value; }
        }

        private string cuentaventas;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaVentas
        {
            get { return cuentaventas; }
            set { cuentaventas = value; }
        }

        private string detalleventas;
        /// <summary>
        /// 
        /// </summary>
        public string DetalleVentas
        {
            get { return detalleventas; }
            set { detalleventas = value; }
        }

        private string devolucionventas;
        /// <summary>
        /// 
        /// </summary>
        public string DevolucionVentas
        {
            get { return devolucionventas; }
            set { devolucionventas = value; }
        }

        private string detalledevventas;
        /// <summary>
        /// 
        /// </summary>
        public string DetalleDevVentas
        {
            get { return detalledevventas; }
            set { detalledevventas = value; }
        }

        private string devolucioncompras;
        /// <summary>
        /// 
        /// </summary>
        public string DevolucionCompras
        {
            get { return devolucioncompras; }
            set { devolucioncompras = value; }
        }

        private string detalledevcompras;
        /// <summary>
        /// 
        /// </summary>
        public string DetalleDevCompras
        {
            get { return detalledevcompras; }
            set { detalledevcompras = value; }
        }      
    }
}
