using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class DescuentoPrivilegioInfo
    {
        private int dsc_id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return dsc_id; }
            set { dsc_id = value; }
        }

        private string dsc_descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return dsc_descripcion; }
            set { dsc_descripcion = value; }
        }

        private decimal dsc_desde;
        /// <summary>
        /// 
        /// </summary>
        public decimal Desde
        {
            get { return dsc_desde; }
            set { dsc_desde = value; }
        }

        private decimal dsc_hasta;
        /// <summary>
        /// 
        /// </summary>
        public decimal Hasta
        {
            get { return dsc_hasta; }
            set { dsc_hasta = value; }
        }
       
        private decimal dsc_porcentaje;
        /// <summary>
        /// 
        /// </summary>
        public decimal Porcentaje
        {
            get { return dsc_porcentaje; }
            set { dsc_porcentaje = value; }
        }

        private decimal dsc_porcentajehogar;
        /// <summary>
        /// 
        /// </summary>
        public decimal PorcentajeHogar
        {
            get { return dsc_porcentajehogar; }
            set { dsc_porcentajehogar = value; }
        }

        private bool dsc_estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return dsc_estado; }
            set { dsc_estado = value; }
        }

        private DateTime dsc_sysdate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Sysdate
        {
            get { return dsc_sysdate; }
            set { dsc_sysdate = value; }
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

        private string dsc_unineg;
        /// <summary>
        /// 
        /// </summary>
        public string UnidadNegocio
        {
            get { return dsc_unineg; }
            set { dsc_unineg = value; }
        }


        private string dsc_grupoproducto;
        /// <summary>
        /// 
        /// </summary>
        public string GrupoProducto
        {
            get { return dsc_grupoproducto; }
            set { dsc_grupoproducto = value; }
        }

        private string dsc_campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return dsc_campana; }
            set { dsc_campana = value; }
        }

        private bool dsc_prodestrella;
        /// <summary>
        /// 
        /// </summary>
        public bool ProdEstrella
        {
            get { return dsc_prodestrella; }
            set { dsc_prodestrella = value; }
        }

    }
}
