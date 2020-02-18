using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class TipoPedidoMinimoInfo
    {
        private int tpm_id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return tpm_id; }
            set { tpm_id = value; }
        }

        private string tpm_nombre;
        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return tpm_nombre; }
            set { tpm_nombre = value; }
        }
        
        private decimal tpm_valor;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor
        {
            get { return tpm_valor; }
            set { tpm_valor = value; }
        }

        private decimal tpm_valoroutletnivi;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorOutletNivi
        {
            get { return tpm_valoroutletnivi; }
            set { tpm_valoroutletnivi = value; }
        }

        private decimal tpm_valoroutletpisame;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorOutletPisame
        {
            get { return tpm_valoroutletpisame; }
            set { tpm_valoroutletpisame = value; }
        }

        private decimal tmp_textoamostrar;
        /// <summary>
        /// 
        /// </summary>
        public decimal TextoAMostrar
        {
            get { return tmp_textoamostrar; }
            set { tmp_textoamostrar = value; }
        }

        private string usuario;
        /// <summary>
        /// 
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}
