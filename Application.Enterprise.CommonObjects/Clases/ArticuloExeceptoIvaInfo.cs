using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ArticuloExeceptoIvaInfo
    {
        //,plu, nombreciudad,referencia, nombreArticulo,estado
        private string _codciudad;
        /// <summary>
        /// 
        /// </summary>
        public string Codciudad
        {
            get { return _codciudad; }
            set { _codciudad  = value; }
        }

        private string _nombreciudad;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCiudad
        {
            get { return _nombreciudad; }
            set { _nombreciudad = value; }
        }

        private int _plu;
        /// <summary>
        /// 
        /// </summary>
        public int PLU
        {
            get { return _plu; }
            set { _plu = value; }
        }

        private string _referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }

        private string  _nombreproducto;
        /// <summary>
        /// 
        /// </summary>
        public string  NombreProducto
        {
            get { return _nombreproducto; }
            set { _nombreproducto = value; }
        }

        private bool _estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        
        private string  _usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

       
    }
    
  
}
