using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    public class MailPlanActividadInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int mailgroup;

        public int MailGroup
        {
            get { return mailgroup; }
            set { mailgroup = value; }
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //private string zona;

        //public string Zona
        //{
        //    get { return zona; }
        //    set { zona = value; }
        //}
        /// <summary>
        /// 
        /// </summary>
        private DateTime fechacomienzo;

        public DateTime FechaComienzo
        {
            get { return fechacomienzo; }
            set { fechacomienzo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private DateTime fechafin;

        public DateTime FechaFin
        {
            get { return fechafin; }
            set { fechafin = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string observacion;
        /// <summary>
        /// 
        /// </summary>
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
    }
}
