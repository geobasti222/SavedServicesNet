using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PremiosCondicionesInfo
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

        private int idpremio;
        /// <summary>
        /// 
        /// </summary>
        public int IdPremio
        {
            get { return idpremio; }
            set { idpremio = value; }
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


        private string query;
        /// <summary>
        /// 
        /// </summary>
        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        private int orden;
        /// <summary>
        /// 
        /// </summary>
        public int Orden
        {
            get { return orden; }
            set { orden = value; }
        }


        private int idarticulo;
        /// <summary>
        /// 
        /// </summary>
        public int IdArticulo
        {
            get { return idarticulo; }
            set { idarticulo = value; }
        }
    }
}
