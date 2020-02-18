using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CicloxPluInfo
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
        
        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos; }
            set { ccostos = value; }
        }

        private int plu;
        /// <summary>
        /// 
        /// </summary>
        public int PLU
        {
            get { return plu; }
            set { plu = value; }
        }

        private string ciclo;
        /// <summary>
        /// 
        /// </summary>
        public string Ciclo
        {
            get { return ciclo; }
            set { ciclo = value; }
        }

        private string nombreciclo;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiclo
        {
            get { return nombreciclo; }
            set { nombreciclo = value; }
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

        private string codigorapido;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoRapido
        {
            get { return codigorapido; }
            set { codigorapido = value; }
        }


        private string usuariodigito;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuariodigito.Trim(); }
            set { usuariodigito = value; }
        }

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

        private int cantidad;
        /// <summary>
        /// 
        /// </summary>
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private string nombreproducto;
        /// <summary>
        /// 
        /// </summary>
        public string NombreProducto
        {
            get { return nombreproducto.Trim(); }
            set { nombreproducto = value; }
        }
    }
}
