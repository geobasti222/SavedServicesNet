using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PremiosCamposInfo
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

        private string nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion.ToUpper(); }
            set { descripcion = value; }
        }

        private string tipo;
        /// <summary>
        /// 
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string tblpadre;
        /// <summary>
        /// 
        /// </summary>
        public string TablaPadre
        {
            get { return tblpadre; }
            set { tblpadre = value; }
        }

        private string campopadre;
        /// <summary>
        /// 
        /// </summary>
        public string CampoTablaPadre
        {
            get { return campopadre; }
            set { campopadre = value; }
        }

        private string campopadrenombre;
        /// <summary>
        /// 
        /// </summary>
        public string CampoTablaPadreNombre
        {
            get { return campopadrenombre; }
            set { campopadrenombre = value; }
        }

        private string idcombogenerico;
        /// <summary>
        /// 
        /// </summary>
        public string IdComboGenerico
        {
            get { return idcombogenerico; }
            set { idcombogenerico = value; }
        }

        private string valuecombogenerico;
        /// <summary>
        /// 
        /// </summary>
        public string ValueComboGenerico
        {
            get { return valuecombogenerico.ToUpper(); }
            set { valuecombogenerico = value; }
        }

        private string queryinicial;
        /// <summary>
        /// 
        /// </summary>
        public string QueryInicial
        {
            get { return queryinicial; }
            set { queryinicial = value; }
        }

        private int tipowhere;
        /// <summary>
        /// 
        /// </summary>
        public int TipoWhere
        {
            get { return tipowhere; }
            set { tipowhere = value; }
        }

        private string msjrequerido;
        /// <summary>
        /// 
        /// </summary>
        public string MensajeRequerido
        {
            get { return msjrequerido; }
            set { msjrequerido = value; }
        }

        private int idtipocampo;
        /// <summary>
        /// 
        /// </summary>
        public int IdTipoCampo
        {
            get { return idtipocampo; }
            set { idtipocampo = value; }
        }
    }
}
