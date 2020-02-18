using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// JA
    /// </summary>
    
    public class ReglaJAInfo
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

        private string categoria;
        /// <summary>
        /// 
        /// </summary>
        public string Categoria
        {
            get { return categoria.Trim(); }
            set { categoria = value; }
        }
        private bool activo;
        /// <summary>
        /// 
        /// </summary>
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private string consulta;
        /// <summary>
        /// 
        /// </summary>
        public string Consulta
        {
            get { return consulta.Trim(); }
            set { consulta = value; }
        }

        private string campanaPremio;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaPremio
        {
            get { return campanaPremio.Trim(); }
            set { campanaPremio = value; }
        }

        private string campanaAtras;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaAtras
        {
            get { return campanaAtras.Trim(); }
            set { campanaAtras = value; }
        }

        private string estado;
        /// <summary>
        /// 
        /// </summary>
        public string Estado
        {
            get { return estado.Trim(); }
            set { estado = value; }
        }

        private int valorPremio;
        /// <summary>
        /// 
        /// </summary>
        public int ValorPremio
        {
            get { return valorPremio; }
            set { valorPremio = value; }
        }

        private int valorAtras;
        /// <summary>
        /// 
        /// </summary>
        public int ValorAtras
        {
            get { return valorAtras; }
            set { valorAtras = value; }
        }

        private int cantidad;
        /// <summary>
        /// 
        /// </summary>
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private string productoPlug;
        /// <summary>
        /// 
        /// </summary>
        public string ProductoPlug
        {
            get { return productoPlug.Trim(); }
            set { productoPlug = value; }
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

        private string campanaAtras18;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaAtras18
        {
            get { return campanaAtras18.Trim(); }
            set { campanaAtras18 = value; }
        }

        private bool eliminar;
        /// <summary>
        /// 
        /// </summary>
        public bool Eliminar
        {
            get { return eliminar; }
            set { eliminar = value; }
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

        private string campanaAtras2;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaAtras2
        {
            get { return campanaAtras2.Trim(); }
            set { campanaAtras2 = value; }
        }

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona.Trim(); }
            set { zona = value; }
        }

        private int valordescuento;
        /// <summary>
        /// 
        /// </summary>
        public int ValorDescuento
        {
            get { return valordescuento; }
            set { valordescuento = value; }
        }

        private bool todouno;
        /// <summary>
        /// 
        /// </summary>
        public bool TodoUno
        {
            get { return todouno; }
            set { todouno = value; }
        }

        private string nivel;
        /// <summary>
        /// 
        /// </summary>
        public string Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }


        //ZONASREGLAS

        private int idregla;
        /// <summary>
        /// 
        /// </summary>
        public int IdRegla
        {
            get { return idregla; }
            set { idregla = value; }
        }

        private string zonas;
        /// <summary>
        /// 
        /// </summary>
        public string Zonas
        {
            get { return zonas.Trim(); }
            set { zonas = value; }
        }

        private string descripcionzona;
        /// <summary>
        /// 
        /// </summary>
        public string DescripcionZona
        {
            get { return descripcionzona.Trim(); }
            set { descripcionzona = value; }
        }
            
        private string campanapremiorango;
        /// <summary>
        /// 
        /// </summary>
        public string CampanaPremioRango
        {
            get { return campanapremiorango.Trim(); }
            set { campanapremiorango = value; }
        }

        private int valortotalrango;
        /// <summary>
        /// 
        /// </summary>
        public int ValorTotalRango
        {
            get { return valortotalrango; }
            set { valortotalrango = value; }
        }
    }
}
