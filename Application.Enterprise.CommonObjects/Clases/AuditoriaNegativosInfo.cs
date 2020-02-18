using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AuditoriaNegativosInfo
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

        private string bodega;
        /// <summary>
        /// 
        /// </summary>
        public string Bodega
        {
            get { return bodega.Trim(); }
            set { bodega = value; }
        }

        private string codigototal;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoTotal
        {
            get { return codigototal.Trim(); }
            set { codigototal = value; }
        }

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia.Trim(); }
            set { referencia = value; }
        }

        private string nombre_producto;
        /// <summary>
        /// 
        /// </summary>
        public string NombreProducto
        {
            get { return nombre_producto.Trim(); }
            set { nombre_producto = value; }
        }

        private string codigocolor;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoColor
        {
            get { return codigocolor.Trim(); }
            set { codigocolor = value; }
        }

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion.Trim(); }
            set { descripcion = value; }
        }

        private string codigotalla;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoTalla
        {
            get { return codigotalla.Trim(); }
            set { codigotalla = value; }
        }

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos.Trim(); }
            set { ccostos = value; }
        }

        private string saldo;
        /// <summary>
        /// 
        /// </summary>
        public string Saldo
        {
            get { return saldo.Trim(); }
            set { saldo = value; }
        }

        private string costo_ponderado_final;
        /// <summary>
        /// 
        /// </summary>
        public string CostoPonderadoFinal
        {
            get { return costo_ponderado_final.Trim(); }
            set { costo_ponderado_final = value; }
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


        private int cantidadnegativos;
        /// <summary>
        /// 
        /// </summary>
        public int CantidadNegativos
        {
            get { return cantidadnegativos; }
            set { cantidadnegativos = value; }
        }
       
    }
}
