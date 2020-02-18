using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ReglasCondicionesInfo
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

        private int idregla;
        /// <summary>
        /// 
        /// </summary>
        public int IdRegla
        {
            get { return idregla; }
            set { idregla = value; }
        }

        private int idcampo;
        /// <summary>
        /// 
        /// </summary>
        public int IdCampo
        {
            get { return idcampo; }
            set { idcampo = value; }
        }

        private string nombrecampo;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCampo
        {
            get { return nombrecampo.ToUpper(); }
            set { nombrecampo = value; }
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

        private string valor;
        /// <summary>
        /// 
        /// </summary>
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private int idtabla;
        /// <summary>
        /// 
        /// </summary>
        public int IdTabla
        {
            get { return idtabla; }
            set { idtabla = value; }
        }

        private string idcadena;
        /// <summary>
        /// 
        /// </summary>
        public string IdCadena
        {
            get { return idcadena; }
            set { idcadena = value; }
        }

        private int idoperador;
        /// <summary>
        /// 
        /// </summary>
        public int IdOperador
        {
            get { return idoperador; }
            set { idoperador = value; }
        }

        private string nombreoperador;
        /// <summary>
        /// 
        /// </summary>
        public string NombreOperador
        {
            get { return nombreoperador.ToUpper(); }
            set { nombreoperador = value; }
        }

        private int idconcepto;
        /// <summary>
        /// 
        /// </summary>
        public int IdConcepto
        {
            get { return idconcepto; }
            set { idconcepto = value; }
        }

        private string nombreconcepto;
        /// <summary>
        /// 
        /// </summary>
        public string NombreConcepto
        {
            get { return nombreconcepto.ToUpper(); }
            set { nombreconcepto = value; }
        }               
    }
}
