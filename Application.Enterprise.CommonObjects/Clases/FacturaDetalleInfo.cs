using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class FacturaDetalleInfo
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string referencia;

        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private decimal cantidad;

        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private decimal descuento;

        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        private decimal tarifaiva;

        public decimal TarifaIva
        {
            get { return tarifaiva; }
            set { tarifaiva = value; }
        }

        private string numeroremision;

        public string NumeroRemision
        {
            get { return numeroremision; }
            set { numeroremision = value; }
        }

        private int ensamblado;

        public int Ensamblado
        {
            get { return ensamblado; }
            set { ensamblado = value; }
        }

        private int anulado;

        public int Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }

        private string numeropedido;

        public string NumeroPedido
        {
            get { return numeropedido; }
            set { numeropedido = value; }
        }

        private string ccostos;

        public string Ccostos
        {
            get { return ccostos; }
            set { ccostos = value; }
        }

        private string conceptocontable;

        public string ConceptoContable
        {
            get { return conceptocontable; }
            set { conceptocontable = value; }
        }

        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        private decimal impoconsumo;

        public decimal ImpoConsumo
        {
            get { return impoconsumo; }
            set { impoconsumo = value; }
        }

        private string centrocostos;

        public string CentroCostos
        {
            get { return centrocostos; }
            set { centrocostos = value; }
        }

        private string iddocfuente;

        public string IddocFuente
        {
            get { return iddocfuente; }
            set { iddocfuente = value; }
        }

        private string codigobarras;

        public string CodigoBarras
        {
            get { return codigobarras; }
            set { codigobarras = value; }
        }

        private decimal valorconiva;

        public decimal ValorconIva
        {
            get { return valorconiva; }
            set { valorconiva = value; }
        }

        private string codigoubicacion;

        public string CodigoUbicacion
        {
            get { return codigoubicacion; }
            set { codigoubicacion = value; }
        }

        private decimal plu;

        public decimal Plu
        {
            get { return plu; }
            set { plu = value; }
        }


        private string idcodigocorto;

        public string IdCodigoCorto
        {
            get { return idcodigocorto; }
            set { idcodigocorto = value; }
        }


        private string pedidonesac;

        public string PedidoneSac
        {
            get { return pedidonesac; }
            set { pedidonesac = value; }
        }

        private decimal cantidadpedida;

        public decimal CantidadPedida
        {
            get { return cantidadpedida; }
            set { cantidadpedida = value; }
        }

        private decimal valorpreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPrecioCatalogo
        {
            get { return valorpreciocatalogo; }
            set { valorpreciocatalogo = value; }
        }

        private decimal ivapreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal IVAPrecioCatalogo
        {
            get { return ivapreciocatalogo; }
            set { ivapreciocatalogo = value; }
        }

        private decimal totalpreciocatalogo;
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrecioCatalogo
        {
            get
            {
                totalpreciocatalogo = ValorPrecioCatalogo + IVAPrecioCatalogo;
                return totalpreciocatalogo;
            }
            set { totalpreciocatalogo = value; }
        }

        private string grupo;
        /// <summary>
        /// 
        /// </summary>
        public string Grupo
        {
            get { return grupo.Trim(); }
            set { grupo = value; }
        }
    }
}
