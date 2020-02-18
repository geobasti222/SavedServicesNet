using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using Application.Enterprise.CommonObjects;
using Application.Enterprise.CommonObjects.Interfaces;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// Realiza el manejo del rango de todos los pedidos.
    /// </summary>
    public class PedidosManager
    {
        #region Variables Privadas
        /// <summary>
        /// timer
        /// </summary>
        private System.Timers.Timer timer;

        /// <summary>
        /// Porpiedad para verificar la ejecuacion del procesamiento.
        /// </summary>
        private bool inProcess;

        private bool finishProcess;

        #endregion

        #region Eventos

        /// <summary>
        /// Evento que dispara el procesamiento de pedido.
        /// </summary>
        public event OnPedidoEventHandler OnPedidoEvent;
        /// <summary>
        /// Evento que confirma la finalizacion de procesamiento.
        /// </summary>
        public event OnEndEventHandler OnEndEvent;
        /// <summary>
        /// Evento que se lanza antes de iniciar un proceso de procesamiento
        /// </summary>
        public event OnStartEventHandler OnStartEvent;
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor de la clase que configura los objetos para el procesamiento de pedidos.
        /// </summary>
        public PedidosManager()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: PedidosManager()"));
            timer = new System.Timers.Timer();
            timer.Interval = (1000) * (30); //120 = 2 mins  //60 = 1 min
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);                    

            inProcess = false;

            finishProcess = false;
        }
        #endregion


        #region Metodos Publicos
        /// <summary>
        /// Detiene el procesamiento de los pedidos.
        /// </summary>
        public void Stop()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: Stop()"));
            if (timer.Enabled)
            {
                timer.Stop();
            }

            if (inProcess)
            {
                inProcess = false;
            }
        }

        /// <summary>
        /// Inicia el proceso de los hilos.
        /// <param name="runNow"></param>
        /// </summary>
        public void Start(bool runNow)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: Start(bool runNow)"));
            if (runNow)
            {
                inProcess = true;
                Process();
            }
            else
            {
                //Solo lo arranca si esta detenido
                if (!timer.Enabled && !inProcess)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: INICIO TEMPORIZADOR "));
                    timer.Start();
                }
            }
        }
        #endregion

        #region Metodos Privados
        /// <summary>
        /// Timer para el inicio del procesamiento de los pedidos.
        /// </summary>
        /// <param name="sender">objeto sender.</param>
        /// <param name="e">Argumentos de Evento.</param>
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: timer_Elapsed"));
            //Detiene el temporizador para que no contabilice mas tiempo
            timer.Enabled = false;

            Process();
        }

        /// <summary>
        /// Recorre el rango de pedidos y realiza el procesamiento.
        /// </summary>
        private void Process()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: Process()"));
            
            OnStart();

            inProcess = true;
            finishProcess = false; //se reinicia la bandera de finalizacion del proceso.

            int i = 0;

            while (i < 100)
            {
                //Agregar logica de asignacion de inventarios de los pedidos.
                //añadir a la lista de pedidos procesada
                System.Diagnostics.Trace.WriteLine(string.Format("PROCESO i: {0}", i));

                PedidosReviewer module = new PedidosReviewer();

                module.OnProcessEvent += new OnProcessEventHandler(module_OnProcessEvent);              
                module.NumeroProcesoEjecutado = i;
                module.Start();
                i++;

                if (i == 99)
                {
                    finishProcess = true;
                }
            }

           // finishProcess = true;
            // System.Diagnostics.Trace.WriteLine(string.Format("ANM BUSINESS DISCOVERYMANAGER: TOTAL DISPOSITIVOS A DESCUBRIR {0}", this.totalDevices));
        }

        /// <summary>
        /// Procesamiento de pedidos.
        /// </summary>
        /// <param name="source">Objeto que contiene el procesamiento de un pedido.</param>
        /// <param name="item">Contiene las propiedades de un pedido.</param>
        private void module_OnProcessEvent(PedidosReviewer source, PedidosProcessInfo item)
        {
            lock (this)
            {
                OnDiscovery(item);

                System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: module_OnProcessEvent"));

                if (finishProcess)
                {
                    //Evita que envie muchos eventos OnEnd varias veces si discovery manager esta deshabilitado
                    if (inProcess)
                    {
                        OnEnd();                       
                    }
                   
                    inProcess = false;
                }               

            }
        }

        /// <summary>
        /// Detiene el procesamiento de un pedido.
        /// </summary>
        /// <param name="s">Objeto que contiene el procesamiento de un pedido.</param>
        private static void StopDevice(PedidosReviewer s)
        {
            s.Stop();
        }

        /// <summary>
        /// Evento que dispara el procesamiento de un pedido.
        /// </summary>
        /// <param name="item">Contiene las propiedades de un pedido.</param>
        protected virtual void OnDiscovery(PedidosProcessInfo item)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: OnDiscovery()"));
            OnPedidoEventHandler handler = OnPedidoEvent;
            if (handler != null)
            {
                handler(item);
            }
        }
        /// <summary>
        /// Evento que confirma la finalizacion del procesamiento de un pedido.
        /// </summary>
        protected virtual void OnEnd()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: OnEnd()"));
            
            //Al terminar todo el proceso volver a contabilizar otro periodo de procesamiento

            timer.Enabled = true;
            //System.Diagnostics.Trace.WriteLine(string.Format("ANM BUSINESS DISCOVERYMANAGER: ONEND TEMPORIZADOR ACTIVADO {0}ms", this._configuratorinfo.TimeDiscovery));
            
            OnEndEventHandler handler = OnEndEvent;
            if (handler != null)
            {
                handler();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnStart()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("SVDN PedidosManager: OnStart()"));
            OnStartEventHandler handler = OnStartEvent;
            if (handler != null)
            {
                handler();
            }
        }
        #endregion
    }
}
