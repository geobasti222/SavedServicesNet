using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PremiosQueryInfo
    {
        private int idcampo;
        /// <summary>
        /// 
        /// </summary>
        public int IdCampo
        {
            get { return idcampo; }
            set { idcampo = value; }
        }
        
        private string campo;
        /// <summary>
        /// 
        /// </summary>
        public string Campo
        {
            get { return campo; }
            set { campo = value; }
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

        private string operador;
        /// <summary>
        /// 
        /// </summary>
        public string Operador
        {
            get { return operador; }
            set { operador = value; }
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

        private string valoridcombo;
        /// <summary>
        /// 
        /// </summary>
        public string ValorIdCombo
        {
            get { return valoridcombo; }
            set { valoridcombo = value; }
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

      
    }
}
