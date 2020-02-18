using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class DevolucionReservaEnLineaInfo
    {
        private int pedidos;
        /// <summary>
        /// 
        /// </summary>
        public int Pedidos
        {
            get { return pedidos; }
            set { pedidos = value; }
        }

        private DateTime fechatransaccion;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaTransaccion
        {
            get { return fechatransaccion; }
            set { fechatransaccion = value; }
        }
    }
}
