using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class MotivoDevolInfo
    {
        private string _codmotivo;
        /// <summary>
        /// 
        /// </summary>
        public string CodMotivo
        {
            get { return _codmotivo; }
            set { _codmotivo = value; }
        }

        private string _descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string DescripcionMotivo
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _pedido;
        /// <summary>
        /// 
        /// </summary>
        public int Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
        }

      
    }
}
