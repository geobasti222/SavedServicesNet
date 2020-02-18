using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    ///
    /// </summary>
    
    public class DespachosVInfo
    {
        private string _numerodespacho;
        /// <summary>
        /// numero 
        /// </summary>
        public string NumeroDespacho
        {
            get { return _numerodespacho; }
            set { _numerodespacho  = value; }
        }

        private DateTime _fechadespacho;
        /// <summary>
        /// fecha 
        /// </summary>
        public DateTime FechaDespacho
        {
            get { return _fechadespacho; }
            set { _fechadespacho = value; }
        }

        private string _tipocaja;
        /// <summary>
        /// TIPOCAJA
        /// </summary>
        public string TipoCaja
        {
            get { return _tipocaja; }
            set { _tipocaja = value; }
        }

        private string _descripcion;
        /// <summary>
        /// DESCRIPCION
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _caja;
        /// <summary>
        /// CAJA
        /// </summary>
        public int Caja
        {
            get { return _caja; }
            set { _caja = value; }
        }

      
        private string guia;
        /// <summary>
        /// GUIA
        /// </summary>
        public string Guia
        {
            get { return guia; }
            set { guia = value; }
        }

        private string numerofactura;
        /// <summary>
        /// NUMEROFACTURA
        /// </summary>
        public string NumeroFactura
        {
            get { return numerofactura; }
            set { numerofactura = value; }
        }

        private decimal  _valor;
        /// <summary>
        /// valor
        /// </summary>
        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }


        private string _coddptoorigen;
        /// <summary>
        /// CodDeptoOrigen
        /// </summary>
        public string CodDptoOrigen
        {
            get { return _coddptoorigen; }
            set { _coddptoorigen = value; }
        }

        private string _dptoorigen;
        /// <summary>
        /// DeptoOrigen
        /// </summary>
        public string DptoOrigen
        {
            get { return _dptoorigen; }
            set { _dptoorigen = value; }
        }

        private string _codciudadorigen;
        /// <summary>
        /// CodCiudadOrigen
        /// </summary>
        public string CodCiudadOrigen
        {
            get { return _codciudadorigen; }
            set { _codciudadorigen = value; }
        }


        private string _ciudadorigen;
        /// <summary>
        /// CiudadOrigen
        /// </summary>
        public string CiudadOrigen
        {
            get { return _ciudadorigen; }
            set { _ciudadorigen = value; }
        }

        private string _coddptodestino;
        /// <summary>
        /// CodDeptoDestino
        /// </summary>
        public string CodDptoDestino
        {
            get { return _coddptodestino; }
            set { _coddptodestino = value; }
        }

        private string _dptodestino;
        /// <summary>
        /// DeptoDestino
        /// </summary>
        public string DptoDestino
        {
            get { return _dptodestino; }
            set { _dptodestino = value; }
        }

        private string _codciudaddestino;
        /// <summary>
        /// CodCiudadDestino
        /// </summary>
        public string CodCiudadDestino
        {
            get { return _codciudaddestino; }
            set { _codciudaddestino = value; }
        }

        private string _ciudaddestino;
        /// <summary>
        /// CiudadDestino
        /// </summary>
        public string CiudadDestino
        {
            get { return _ciudaddestino; }
            set { _ciudaddestino = value; }
        }

        private int _valorfletesiniva;
        /// <summary>
        /// ValorFleteSinIVA
        /// </summary>
        public int ValorFleteSinIVA
        {
            get { return _valorfletesiniva; }
            set { _valorfletesiniva = value; }
        }

        private string _codtranspo;
        /// <summary>
        /// CodTransportadora
        /// </summary>
        public string CodTransport
        {
            get { return _codtranspo; }
            set { _codtranspo = value; }
        }

        private string _nomtranspo;
        /// <summary>
        /// NomTransportadora
        /// </summary>
        public string NomTranspor
        {
            get { return _nomtranspo; }
            set { _nomtranspo = value; }
        }


        private string _zona;
        /// <summary>
        /// Zona
        /// </summary>
        public string CZona
        {
            get { return _zona; }
            set { _zona = value; }
        }

        private string _documento;
        /// <summary>
        /// Documento
        /// </summary>
        public string Documento
        {
            get { return _documento; }
            set { _documento  = value; }
        }

        private string _destinatario;
        /// <summary>
        /// Destinatario
        /// </summary>
        public string Destinatario
        {
            get { return _destinatario; }
            set { _destinatario = value; }
        }

        private string _direccion;
        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _telefono;
        /// <summary>
        /// Telefono
        /// </summary>
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _observaciones;
        /// <summary>
        /// Observaciones 
        /// </summary>
        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        private decimal _vlrdeclarado;
        /// <summary>
        /// Observaciones 
        /// </summary>
        public decimal VlrDeclarado
        {
            get { return _vlrdeclarado; }
            set { _vlrdeclarado = value; }
        }

    
        
       

    }
}
