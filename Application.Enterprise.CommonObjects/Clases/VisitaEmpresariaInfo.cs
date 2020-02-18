using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class VisitaEmpresariaInfo
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

        private string nit;
        /// <summary>
        /// 
        /// </summary>
        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        private int tipovisita;
        /// <summary>
        /// 
        /// </summary>
        public int TipoVisita
        {
            get { return tipovisita; }
            set { tipovisita = value; }
        }


        private string tipovisitanombre;
        /// <summary>
        /// 
        /// </summary>
        public string TipoVisitaNombre
        {
            get { return tipovisitanombre; }
            set { tipovisitanombre = value; }
        }

        private DateTime fechavisita;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaVisita
        {
            get { return fechavisita; }
            set { fechavisita = value; }
        }

        private string horavisita;
        /// <summary>
        /// 
        /// </summary>
        public string HoraVisita
        {
            get { return horavisita; }
            set { horavisita = value; }
        }

        private string campana;
        /// <summary>
        /// 
        /// </summary>
        public string Campana
        {
            get { return campana; }
            set { campana = value; }
        }

        private string observacion;
        /// <summary>
        /// 
        /// </summary>
        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
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

        private string zona;
        /// <summary>
        /// 
        /// </summary>
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }

        private string vendedor;
        /// <summary>
        /// 
        /// </summary>
        public string Vendedor
        {
            get { return vendedor; }
            set { vendedor = value; }
        }

        private bool estado;
        /// <summary>
        /// 
        /// </summary>
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string nombrecliente;
        /// <summary>
        /// 
        /// </summary>
        public string NombreCliente
        {
            get { return nombrecliente; }
            set { nombrecliente = value; }
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

        private int idestadocliente;
        /// <summary>
        /// 
        /// </summary>
        public int IdEstadoCliente
        {
            get { return idestadocliente; }
            set { idestadocliente = value; }
        }

        private string estadocliente;
        /// <summary>
        /// 
        /// </summary>
        public string EstadoCliente
        {
            get { return estadocliente; }
            set { estadocliente = value; }
        }

        private string telefonoprincipal;
        /// <summary>
        /// 
        /// </summary>
        public string TelefonoPrincipal
        {
            get { return telefonoprincipal; }
            set { telefonoprincipal = value; }
        }

        private string celularprincipal;
        /// <summary>
        /// 
        /// </summary>
        public string CelularPrincipal
        {
            get { return celularprincipal; }
            set { celularprincipal = value; }
        }

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

        private string coddepartamento;
        /// <summary>
        /// 
        /// </summary>
        public string CodDepartamento
        {
            get { return coddepartamento; }
            set { coddepartamento = value; }
        }

        private string nombredepartamento;
        /// <summary>
        /// 
        /// </summary>
        public string NombreDepartamento
        {
            get { return nombredepartamento; }
            set { nombredepartamento = value; }
        }

        private int coddivision;
        /// <summary>
        /// 
        /// </summary>
        public int CodDivision
        {
            get { return coddivision; }
            set { coddivision = value; }
        }

        private string nombredivision;
        /// <summary>
        /// 
        /// </summary>
        public string NombreDivision
        {
            get { return nombredivision; }
            set { nombredivision = value; }
        }

        private int idvisitapositiva;
        /// <summary>
        /// 
        /// </summary>
        public int IdVisitaPositiva
        {
            get { return idvisitapositiva; }
            set { idvisitapositiva = value; }
        }

        private string nombrevisitapositiva;
        /// <summary>
        /// 
        /// </summary>
        public string NombreVisitaPositiva
        {
            get { return nombrevisitapositiva; }
            set { nombrevisitapositiva = value; }
        }

        private int iddivisional;
        /// <summary>
        /// 
        /// </summary>
        public int IdDivisional
        {
            get { return iddivisional; }
            set { iddivisional = value; }
        }

        private DateTime fechainicio;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaInicio
        {
            get { return fechainicio; }
            set { fechainicio = value; }
        }

        private DateTime fechafin;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaFin
        {
            get { return fechafin; }
            set { fechafin = value; }
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

        private decimal numerovisitas;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalVisitas
        {
            get { return numerovisitas; }
            set { numerovisitas = value; }
        }

        private decimal totalfacturasefectivas;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalFacturasEfectivas
        {
            get { return totalfacturasefectivas; }
            set { totalfacturasefectivas = value; }
        }

        private decimal porcentajeefectividad;
        /// <summary>
        /// 
        /// </summary>
        public decimal PorcentajeEfectividad
        {
            get { return porcentajeefectividad; }
            set { porcentajeefectividad = value; }
        }

        private decimal totalvisitaspositivas;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalVisitasPositivas
        {
            get { return totalvisitaspositivas; }
            set { totalvisitaspositivas = value; }
        }

        private decimal totaldiferenciavisitas;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalDiferenciaVisitas
        {
            get { return totaldiferenciavisitas; }
            set { totaldiferenciavisitas = value; }
        }

    }
}
