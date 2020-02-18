using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AmarrePremioInfo
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

        private int id_regla;
        /// <summary>
        /// 
        /// </summary>
        public int Id_regla
        {
            get { return id_regla; }
            set { id_regla = value; }
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

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string plu;
        /// <summary>
        /// 
        /// </summary>
        public string Plu
        {
            get { return plu; }
            set { plu = value; }
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

        private int descuento;
        /// <summary>
        /// 
        /// </summary>
        public int Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
    }
}
