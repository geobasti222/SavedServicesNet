using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class PremiosPuntosWinformsInfo
    {
        /// <summary>
        /// 
        /// </summary>

        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        private string referencia;

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int puntos;

        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string campana;

        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string refcontenedora;

        public string RefContenedora
        {
            get { return refcontenedora; }
            set { refcontenedora = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string sumarpuntos;

        public string SumarPuntos
        {
            get { return sumarpuntos; }
            set { sumarpuntos = value; }
        }

        private string campana_entrega;

        public string Campana_Entrega
        {
            get { return campana_entrega; }
            set { campana_entrega = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int nivel;

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }
                
        /// <summary>
        /// 
        /// </summary>
        private string nombre_producto;

        public string Nombre_Producto
        {
            get { return nombre_producto; }
            set { nombre_producto = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool guardarauditoria;

        public bool GuardarAuditoria
        {
            get { return guardarauditoria; }
            set { guardarauditoria = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}
