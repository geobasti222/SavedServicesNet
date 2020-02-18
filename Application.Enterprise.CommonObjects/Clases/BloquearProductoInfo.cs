using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// JA
    /// </summary>
    
    public class BloquearProductoInfo
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

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana.Trim(); }
            set { campana = value; }
        }

        private string codigorapido;
        /// <summary>
        /// 
        /// </summary>
        public string CodigoRapido
        {
            get { return codigorapido.Trim(); }
            set { codigorapido = value; }
        }

        private string descripcion;
        /// <summary>
        /// 
        /// </summary>
        public string Descripcion
        {
            get { return descripcion.Trim(); }
            set { descripcion = value; }
        }

        private bool eliminado;
        /// <summary>
        /// 
        /// </summary>
        public bool Eliminado
        {
            get { return eliminado; }
            set { eliminado = value; }
        }

        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario.Trim(); }
            set { usuario = value; }
        }
    }
}
