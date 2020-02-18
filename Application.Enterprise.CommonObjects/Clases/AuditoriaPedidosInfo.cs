using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AuditoriaPedidosInfo
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

        private string numero;
        /// <summary>
        /// 
        /// </summary>
        public string Numero
        {
            get { return numero.Trim(); }
            set { numero = value; }
        }

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit.Trim(); }
            set { nit = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona.Trim(); }
            set { zona = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana.Trim(); }
            set { campana = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { return vendedor.Trim(); }
            set { vendedor = value; }
        }

        private string portal;
        /// <summary>
        /// 
        /// </summary>
        public string Portal
        {
            get { return portal.Trim(); }
            set { portal = value; }
        }

        private string factusemanal;
        /// <summary>
        /// 
        /// </summary>
        public string FactuSemanal
        {
            get { return factusemanal.Trim(); }
            set { factusemanal = value; }
        }

        private string cantidadsvdn;
        /// <summary>
        /// 
        /// </summary>
        public string CantidadSVDN
        {
            get { return cantidadsvdn.Trim(); }
            set { cantidadsvdn = value; }
        }

        private string cantidadgyg;
        /// <summary>
        /// 
        /// </summary>
        public string CantidadGYG
        {
            get { return cantidadgyg.Trim(); }
            set { cantidadgyg = value; }
        }

        private string observacion;
        /// <summary>
        /// 
        /// </summary>
        public string Observacion
        {
            get { return observacion.Trim(); }
            set { observacion = value; }
        }

        private DateTime sysdate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Sysdate
        {
            get { return sysdate; }
            set { sysdate = value; }
        }
        
        private bool confirmado;
        /// <summary>
        /// 
        /// </summary>
        public bool Confirmado
        {
            get { return confirmado; }
            set { confirmado = value; }
        }                    
    }
}
