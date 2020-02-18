using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using Application.Enterprise.CommonObjects;


namespace Application.Enterprise.Business
{
    /// <summary>
    /// Evento que captura el proceso de pedido.
    /// </summary>
    /// <param name="source">Objeto que realiza el procesamiento de un pedido.</param>
    /// <param name="item">Contiene las propiedades de un pedido.</param>
    public delegate void OnProcessEventHandler(PedidosReviewer source, PedidosProcessInfo item);

    /// <summary>
    /// Realiza el procesmiento de un pedido basado en las reglas de negocio existentes.
    /// </summary>
    public class PedidosReviewer
    {
        #region Variables
        /// <summary>
        /// Evento para el procesamiento del pedido.
        /// </summary>
        public event OnProcessEventHandler OnProcessEvent;

        /// <summary>
        /// Contiene las propiedades de un pedido.
        /// </summary>
        private PedidosProcessInfo pedidoresult;

        private static bool abort;

        private int noprocejec;

        public int NumeroProcesoEjecutado
        {
            get { return noprocejec; }
            set { noprocejec = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public PedidosReviewer()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosReviewer: PedidosReviewer()"));
            this.pedidoresult = new PedidosProcessInfo();
        }
        #endregion

        #region Metodos publicos
        /// <summary>
        /// Inicia el procesamiento del pedido.
        /// </summary>
        public void Start()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosReviewer: Start()"));
            StartProcesamiento();
        }

        /// <summary>
        /// Detiene el procesamiento del pedido.
        /// </summary>
        public void Stop()
        {
            abort = true;
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosReviewer: Stop()"));
        }
        #endregion

        #region "Procesamiento"
        /// <summary>
        /// inicia el procesamiento del pedido.
        /// </summary>
        private void StartProcesamiento()
        {
            //aborta la operacion si se detiene el servicio con esta bandera.
            abort = false;

            //  Thread.CurrentThread.Name = "Equipo: " + "Nombre HILO_" + NumeroProcesoEjecutado.ToString() + DateTime.Now.ToString();

            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosReviewer StartProcesamiento(): {0}", NumeroProcesoEjecutado));

            //Tiempo de inicio del procesamiento
            pedidoresult.StartDate = DateTime.Now;

            if (abort) return;
            this.HacerProceso();

            pedidoresult.EndDate = DateTime.Now;

            OnProcessEventHandler handler = OnProcessEvent;
            if (handler != null)
            {
                handler(this, pedidoresult);
            }
        }
        #endregion

        #region Metodos de descubrimiento

        /// <summary>
        /// 
        /// </summary>
        private void HacerProceso()
        {
            try
            {
                System.Threading.Thread.Sleep(200);
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosReviewer:: HacerProceso()"));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosReviewer: No se pudo obtener valor."));
            }
        }

        #endregion
    }
}
