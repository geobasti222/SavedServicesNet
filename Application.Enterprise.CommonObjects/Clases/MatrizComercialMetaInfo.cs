using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
   /// <summary>
    /// 
    /// </summary>
    
    public class MatrizComercialMetaInfo
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

        private int npedidos;
        /// <summary>
        /// 
        /// </summary>
        public int Npedidos
        {
            get { return npedidos; }
            set { npedidos = value; }
        }

        private int consecutivas;
        /// <summary>
        /// 
        /// </summary>
        public int Consecutivas
        {
            get { return consecutivas; }
            set { consecutivas = value; }
        }

        private int retenidas;
        /// <summary>
        /// 
        /// </summary>
        public int Retenidas
        {
            get { return retenidas; }
            set { retenidas = value; }
        }

        private int nuevas;
        /// <summary>
        /// 
        /// </summary>
        public int Nuevas
        {
            get { return nuevas; }
            set { nuevas = value; }
        }

        private int activas;
        /// <summary>
        /// 
        /// </summary>
        public int Activas
        {
            get { return activas; }
            set { activas = value; }
        }

        private decimal facturacion;
        /// <summary>
        /// 
        /// </summary>
        public decimal Facturacion
        {
            get { return facturacion; }
            set { facturacion = value; }
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
