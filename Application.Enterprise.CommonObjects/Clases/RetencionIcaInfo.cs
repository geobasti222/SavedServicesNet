using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class RetencionIcaInfo
    {
        private string reteica;
        /// <summary>
        /// 
        /// </summary>
        public string ReteIca
        {
            get { return reteica; }
            set { reteica = value; }
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

        private double porcentaje;
        /// <summary>
        /// 
        /// </summary>
        public double Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        private string cuentacontable;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaContable
        {
            get { return cuentacontable; }
            set { cuentacontable = value; }
        }

        private string cuentadb;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaDB
        {
            get { return cuentadb; }
            set { cuentadb = value; }
        }

         private string cuentacr;
        /// <summary>
        /// 
        /// </summary>
        public string CuentaCR
        {
            get { return cuentacr; }
            set { cuentacr = value; }
        }

        private string detalledb;
        /// <summary>
        /// 
        /// </summary>
        public string DetalleDB
        {
            get { return detalledb; }
            set { detalledb = value; }
        }

        private string detallecr;
        /// <summary>
        /// 
        /// </summary>
        public string DetalleCR
        {
            get { return detallecr; }
            set { detallecr = value; }
        }
    }
}
