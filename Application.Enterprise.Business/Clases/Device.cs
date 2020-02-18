using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// Contiene las reglas de negocio para un dispositivo.
    /// </summary>
    public class Device
    {


        #region Constructor
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Device()
        {
            
        }
        /// <summary>
        /// Contructor de la clase.
        /// </summary>
        /// <param name="databaseName">nombre de la base de datos.</param>
        public Device(string databaseName)
        {
            

        }
        #endregion

        /// <summary>
        /// Inserta los dispositivos descubiertos en la red.
        /// </summary>
        /// <param name="device">objeto que contiene las propiedades de dispositivo.</param>
        /// <returns>verdadero si no ocurre un error en la adición del registro</returns>
        public int DiscoveryDevice(PedidosProcessInfo device)
        {
            return 0;
        }
        /// <summary>
        /// Obtiene el detalle de un dispositivo.
        /// </summary>
        /// <param name="devid">Identificador del dispositivo.</param>
        /// <returns>Detalle de un dispositivo.</returns>
        public string DeviceDetail(int devid)
        {
            return "";
        }
       
        /// <summary>
        /// Obtiene la configuracion del Poller de forma atomatica
        /// </summary>
        /// <param name="device">Dispositivo donde se instala el Poller.</param>
        /// <returns>Configuracion inicial del Poller.</returns>
        public string GetConfiguration(string device)
        {
            return "GetConfig";
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pollerId"></param>
        public void ResetStatus(int pollerId)
        {
            
        }

    }
}
