using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class CostoMercanciaInfo
    {
        private string id;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string bodega;
        /// <summary>
        /// 
        /// </summary>
        public string Bodega
        {
            get { return bodega; }
            set { bodega = value; }
        }

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos; }
            set { ccostos = value; }
        }

        private string mes;
        /// <summary>
        /// 
        /// </summary>
        public string Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        private string referencia;
        /// <summary>
        /// 
        /// </summary>
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; }
        }

        private string numero;
        /// <summary>
        /// 
        /// </summary>
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private int ensamblado;
        /// <summary>
        /// 
        /// </summary>
        public int Ensamblado
        {
            get { return ensamblado; }
            set { ensamblado = value; }
        }

        private DateTime fecha;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private decimal saldo_inicial;
        /// <summary>
        /// 
        /// </summary>
        public decimal SaldoInicial
        {
            get { return saldo_inicial; }
            set { saldo_inicial = value; }
        }

        private decimal costo_inicial;
        /// <summary>
        /// 
        /// </summary>
        public decimal CostoInicial
        {
            get { return costo_inicial; }
            set { costo_inicial = value; }
        }

        private decimal saldo_acumulado;
        /// <summary>
        /// 
        /// </summary>
        public decimal SaldoAcumulado
        {
            get { return saldo_acumulado; }
            set { saldo_acumulado = value; }
        }

        private decimal cantidad;
        /// <summary>
        /// 
        /// </summary>
        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private decimal valor;
        /// <summary>
        /// 
        /// </summary>
        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private decimal descuento;
        /// <summary>
        /// 
        /// </summary>
        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        private decimal costo_mercancia;
        /// <summary>
        /// 
        /// </summary>
        public decimal CostoMercancia
        {
            get { return costo_mercancia; }
            set { costo_mercancia = value; }
        }

        private decimal ultimo_costo;
        /// <summary>
        /// 
        /// </summary>
        public decimal UltimoCosto
        {
            get { return ultimo_costo; }
            set { ultimo_costo = value; }
        }

        private int orden;
        /// <summary>
        /// 
        /// </summary>
        public int Orden
        {
            get { return orden; }
            set { orden = value; }
        }

        private int anulado;
        /// <summary>
        /// 
        /// </summary>
        public int Anulado
        {
            get { return anulado; }
            set { anulado = value; }
        }

        private decimal costo_inicial_ajustado;
        /// <summary>
        /// 
        /// </summary>
        public decimal CostoInicialAjustado
        {
            get { return costo_inicial_ajustado; }
            set { costo_inicial_ajustado = value; }
        }

        private decimal costo_mercancia_ajustado;
        /// <summary>
        /// 
        /// </summary>
        public decimal CostoMercanciaAjustado
        {
            get { return costo_mercancia_ajustado; }
            set { costo_mercancia_ajustado = value; }
        }

        private decimal ultimo_costo_ajustado;
        /// <summary>
        /// 
        /// </summary>
        public decimal UltimoCostoAjustado
        {
            get { return ultimo_costo_ajustado; }
            set { ultimo_costo_ajustado = value; }
        }

        private DateTime fechadoc;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaDoc
        {
            get { return fechadoc; }
            set { fechadoc = value; }
        }
    }
}
