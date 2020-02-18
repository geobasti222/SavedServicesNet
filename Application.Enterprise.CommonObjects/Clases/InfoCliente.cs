using System;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// Provee información sobre un cliente
    /// </summary>
    
    public class InfoCliente
    {
        /// <summary>
        /// Identificador único del cliente
        /// </summary>
        public string Id;

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string Nombre;

		/// <summary>
		/// Nombre del Ordenante
		/// </summary>
		public string NombreOrdenante;

        /// <summary>
        /// Cupo asignado al cliente
        /// </summary>
        public decimal Cupo;

		/// <summary>
		/// Saldo disponible para Repos
		/// </summary>
		public decimal DisponibleRepos;

		/// <summary>
		/// Valor disponible del cupo para realizar operaciones
		/// </summary>
		public decimal Disponible;

		/// <summary>
		/// Saldo disponible en cuenta corriente
		/// </summary>
		public decimal Saldo;

		/// <summary>
		/// Valor de las órdenes pendientes por cumplir
		/// </summary>
		public decimal Congelado;

		/// <summary>
		/// Valor para indicar si se le aplica o no IVA al cliente
		/// </summary>
		public bool AplicaIVA;

        /// <summary>
        /// Dato del Segmento de Comision Variable al que pertenece
        /// </summary>
        public string ClasificacionVariable;

		/// <summary>
		/// Dato del Segmento de Comision Fija al que pertenece
		/// </summary>
		public string ClasificacionFija;

		/// <summary>
		/// Dato del Segmento de Comision para Repos del cliente
		/// </summary>
		public string ClasificacionRepo;
		
		/// <summary>
		/// Dato del Segmento de Comision Fija al que pertenece
		/// </summary>
		public string ClasificacionFijaRepos;

		/// <summary>
        /// Porcentaje de comisión que se cobrará al cliente
        /// </summary>
        public float PorcentajeComision;

		/// <summary>
		/// Tipo de Documento del Cliente
		/// </summary>
		//public TipoDocumento TipoDoc ;

		/// <summary>
		/// Número de Documento del Cliente
		/// </summary>
		public string NumeroDocumento ;

		/// <summary>
		/// Saldo disponible en cuenta corriente
		/// </summary>
		public decimal MontoMaximoAOperar;

        /// <summary>
        /// Indica el Login del Usuario de Soporte del Cliente
        /// </summary>
        public int consecutivoDeceval;

        /// <summary>
        /// Indica el Login del Usuario de Soporte del Cliente
        /// </summary>
        public decimal Deceval;

        /// <summary>
        /// Dato del Segmento de Comision Fija al que pertenece
        /// </summary>
        public string ClasificacionCobro;

        /// <summary>
        /// Dato del Segmento de Comision Fija al que pertenece
        /// </summary>
        public string CuentaDerivados;

        public string IdAppExtern;

        /// <summary>
        /// Inicializa una instancia vacía de la clase InfoCliente
        /// </summary>
        public InfoCliente()
        {
        }

        /// <summary>
        /// Inicializa una instancia de la clase InfoCliente
        /// </summary>
        /// <param name="id">Identificador único del cliente</param>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="cupo">Cupo asignado al cliente</param>
        /// <param name="disponible">Valor disponible del cupo para realizar operaciones</param>
        /// <param name="saldo">Saldo disponible en cuenta corriente</param>
        /// <param name="congelado">Valor de las órdenes pendientes por cumplir</param>
        /// <param name="clasificacionVariable">Segmento variable del cliente</param>
        /// <param name="clasificacionFija">Segmento fijo del cliente</param>
        /// <param name="porcentajeComision">Porcentaje de comisión que se cobrará al cliente</param>
        /// <param name="montomaximoaoperar">Monto Maximo para operar un institucional</param>
        public InfoCliente(string id, string nombre, decimal cupo, decimal disponible, decimal saldo, decimal congelado, string clasificacionVariable, string clasificacionFija, float porcentajeComision, decimal montomaximoaoperar)
        {
            this.Id						= id;
            this.Nombre					= nombre;
            this.Cupo					= cupo;
			this.Disponible				= disponible;
			this.Saldo					= saldo;
			this.Congelado				= congelado;
            this.ClasificacionVariable  = ClasificacionVariable;
			this.ClasificacionFija      = ClasificacionFija;
            this.PorcentajeComision		= porcentajeComision;
			this.MontoMaximoAOperar		= montomaximoaoperar;
        }
    }
}