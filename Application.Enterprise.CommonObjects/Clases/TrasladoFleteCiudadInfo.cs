using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class TrasladoFleteCiudadinfo
    {
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

        private string nombreestado;
        /// <summary>
        /// 
        /// </summary>
        public string NombreEstado
        {
            get { return nombreestado; }
            set { nombreestado = value; }
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

        private decimal _iva;
        /// <summary>
        /// 
        /// </summary>
        public decimal Iva
        {
            get { return _iva; }
            set { _iva = value; }
        }

        private int _excluidoiva;
        /// <summary>
        /// 
        /// </summary>
        public int ExcluidoIVA
        {
            get { return _excluidoiva; }
            set { _excluidoiva = value; }
        }

        
        private decimal valorfletefull;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorFleteFull
        {
            get { return valorfletefull; }
            set { valorfletefull = value; }
        }

        private string _usuario;
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
