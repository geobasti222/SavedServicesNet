using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class MailPlanEventoInfo
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

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string CodCiudad
        {
            get { return codciudad; }
            set { codciudad = value; }
        }

        private string nombreciudad;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiudad
        {
            get { return nombreciudad; }
            set { nombreciudad = value; }
        }

        private DateTime fechainicial;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaInicial
        {
            get { return fechainicial; }
            set { fechainicial = value; }
        }

        private DateTime fechafinal;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaFinal
        {
            get { return fechafinal; }
            set { fechafinal = value; }
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
