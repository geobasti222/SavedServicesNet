using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class AuditoriaSaldosBodegaInfo
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

        private string mes;
        /// <summary>
        /// 
        /// </summary>
        public string Mes
        {
            get { return mes.Trim(); }
            set { mes = value; }
        }

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos.Trim(); }
            set { ccostos = value; }
        }

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia.Trim(); }
            set { referencia = value; }
        }

        private string cantidad;
        /// <summary>
        /// 
        /// </summary>
        public string Cantidad
        {
            get { return cantidad.Trim(); }
            set { cantidad = value; }
        }

        private string costomercancia;
        /// <summary>
        /// 
        /// </summary>
        public string CostoMercancia
        {
            get { return costomercancia.Trim(); }
            set { costomercancia = value; }
        }

        private string opcion;
        /// <summary>
        /// 
        /// </summary>
        public string Opcion
        {
            get { return opcion.Trim(); }
            set { opcion = value; }
        }
      
        private DateTime sysdate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Sysdate
        {
            get { return sysdate; }
            set { sysdate = value; }
        }

        private string numeropedido;
        /// <summary>
        /// 
        /// </summary>
        public string NumeroPedido
        {
            get { return numeropedido.Trim(); }
            set { numeropedido = value; }
        }
        
        private bool confirmado;
        /// <summary>
        /// 
        /// </summary>
        public bool Confirmado
        {
            get { return confirmado; }
            set { confirmado = value; }
        }       
    }
}
