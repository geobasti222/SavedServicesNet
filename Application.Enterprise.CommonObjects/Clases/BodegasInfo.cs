using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class BodegasInfo
    {

        private string bodega;
        /// <summary>
        /// 
        /// </summary>
        public string Bodega
        {
            get { return bodega; }
            set { bodega = value; }
        }

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre.ToUpper(); }
            set { nombre = value; }
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

        private int estado;
        /// <summary>
        /// 
        /// </summary>
        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        private string centrocostos;
        /// <summary>
        /// 
        /// </summary>
        public string CentroCostos
        {
            get { return centrocostos; }
            set { centrocostos = value; }
        }



        private int visibleinv;
        /// <summary>
        /// 
        /// </summary>
        public int VisibleInv
        {
            get { return visibleinv; }
            set { visibleinv = value; }
        }
    }
}
