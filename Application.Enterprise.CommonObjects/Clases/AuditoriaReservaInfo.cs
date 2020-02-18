using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AuditoriaReservaInfo
    {
        private int aur_id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return aur_id; }
            set { aur_id = value; }
        }

        private string aur_numeroerror;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroError
        {
            get { return aur_numeroerror; }
            set { aur_numeroerror = value; }
        }

        private string aur_mensajeerror;
        /// <summary>
        /// 
        /// </summary>
        public string MensajeError
        {
            get { return aur_mensajeerror; }
            set { aur_mensajeerror = value; }
        }

        private DateTime aur_sysdate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Sysdate
        {
            get { return aur_sysdate; }
            set { aur_sysdate = value; }
        }

        private bool aur_confirmado;
        /// <summary>
        /// 
        /// </summary>
        public bool Confirmado
        {
            get { return aur_confirmado; }
            set { aur_confirmado = value; }
        }

        private string aur_numeropedido;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroPedido
        {
            get { return aur_numeropedido; }
            set { aur_numeropedido = value; }
        }
    }
}
