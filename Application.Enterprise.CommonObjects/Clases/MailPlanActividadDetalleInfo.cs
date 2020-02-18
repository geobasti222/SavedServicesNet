using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    public class MailPlanActividadDetalleInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private int mpa_id;

        public int Id
        {
            get { return mpa_id; }
            set { mpa_id = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int MAILGROUP;

        public int MailGroup
        {
            get { return MAILGROUP; }
            set { MAILGROUP = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string zona;

        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private DateTime mpad_comienzo;

        public DateTime Comienzo
        {
            get { return mpad_comienzo; }
            set { mpad_comienzo = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private DateTime mpad_fin;

        public DateTime Fin
        {
            get { return mpad_fin; }
            set { mpad_fin = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string mpad_repeticion;

        public string Repeticion
        {
            get { return mpad_repeticion; }
            set { mpad_repeticion = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int mpa_id_anterior;

        public int Anterior
        {
            get { return mpa_id_anterior; }
            set { mpa_id_anterior = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int mpa_id_siguiente;

        public int Siguiente
        {
            get { return mpa_id_siguiente; }
            set { mpa_id_siguiente = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string mpad_notas;

        public string Notas
        {
            get { return mpad_notas; }
            set { mpad_notas = value; }
        }
    }
}
