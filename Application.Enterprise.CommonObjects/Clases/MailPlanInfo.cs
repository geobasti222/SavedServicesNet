using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class MailPlanInfo
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

        private DateTime fechaapertura;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaApertura
        {
            get 
            { return fechaapertura; }
            set { fechaapertura = value; }
        }

        private DateTime fechacierre;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaCierre
        {
            get { return fechacierre; }
            set { fechacierre = value; }
        }

        private int mailgroup;
        /// <summary>
        /// 
        /// </summary>
        public int MailGroup
        {
            get { return mailgroup; }
            set { mailgroup = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }


        private bool estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string horacierre;
        /// <summary>
        /// 
        /// </summary>
        public string HoraCierre
        {
            get { return horacierre; }
            set { horacierre = value; }
        }


        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private string catalogo;
        /// <summary>
        /// 
        /// </summary>
        public string Catalogo
        {
            get { return catalogo.Trim(); }
            set { catalogo = value; }
        }

        private string _usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return _usuario.Trim(); }
            set { _usuario  = value; }
        }

    }
}
