using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class FleteLiderInfo
    {
        private string _idlider;
        /// <summary>
        /// 
        /// </summary>
        public string IdLider
        {
            get { return _idlider; }
            set { _idlider = value; }
        }

        private decimal _valor;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private int _iva;
        /// <summary>
        /// 
        /// </summary>
        public int Iva
        {
            get { return _iva; }
            set { _iva = value; }
        }

        private int _excluido;
        /// <summary>
        /// 
        /// </summary>
        public int Excluido
        {
            get { return _excluido ; }
            set { _excluido = value; }
        }

        private decimal _valorfletefull;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFleteFull
        {
            get { return _valorfletefull; }
            set { _valorfletefull = value; }
        }
    }
    
    
}
