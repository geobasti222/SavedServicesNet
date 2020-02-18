using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// Evento para iniciar el descrubrimiento de un dispositivo.
    /// </summary>
    /// <param name="item">Contiene las propiedades del dispositivo descubierto</param>
    public delegate void OnPedidoEventHandler(PedidosProcessInfo item);
    /// <summary>
    /// Evento que detecta la terminacion del descubrimiento de un dispositivo.
    /// </summary>
    public delegate void OnEndEventHandler();
    /// <summary>
    /// 
    /// </summary>
    public delegate void OnStartEventHandler();
    /// <summary>
    /// 
    /// </summary>
    
    public class PedidosProcessInfo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        private DateTime endDate;

        /// <summary>
        /// Fecha de finalizacion del descubrimiento.
        /// </summary>
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private DateTime startDate;

        /// <summary>
        /// Fecha de inicio del descubrimiento.
        /// </summary>
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

      
    }
}
