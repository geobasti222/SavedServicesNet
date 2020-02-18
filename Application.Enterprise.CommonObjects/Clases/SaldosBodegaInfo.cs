using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class SaldosBodegaInfo
    {
        private string bodega;
        /// <summary>
        /// 
        /// </summary>
        public string Bodega
        {
            get { return bodega; }
            set { bodega = value; }
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

        private string ccostos;
        /// <summary>
        /// 
        /// </summary>
        public string CCostos
        {
            get { return ccostos; }
            set { ccostos = value; }
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

        private decimal ventas;
        /// <summary>
        /// 
        /// </summary>
        public decimal Ventas
        {
            get { return ventas; }
            set { ventas = value; }
        }

        private decimal compras;
        /// <summary>
        /// 
        /// </summary>
        public decimal Compras
        {
            get { return compras; }
            set { compras = value; }
        }

        private decimal entradas_especiales;
        /// <summary>
        /// 
        /// </summary>
        public decimal EntradasEspeciales
        {
            get { return entradas_especiales; }
            set { entradas_especiales = value; }
        }

        private decimal salidas_especiales;
        /// <summary>
        /// 
        /// </summary>
        public decimal SalidasEspeciales
        {
            get { return salidas_especiales; }
            set { salidas_especiales = value; }
        }

        private decimal valor_ventas;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorVentas
        {
            get { return valor_ventas; }
            set { valor_ventas = value; }
        }

        private decimal valor_compras;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorCompras
        {
            get { return valor_compras; }
            set { valor_compras = value; }
        }

        private decimal costo_ponderado_final;
        /// <summary>
        /// 
        /// </summary>
        public decimal CostoPonderadoFinal
        {
            get { return costo_ponderado_final; }
            set { costo_ponderado_final = value; }
        }

        private string proveedor_ultima_compra;
        /// <summary>
        /// 
        /// </summary>
        public string ProveedorUltimaCompra
        {
            get { return proveedor_ultima_compra; }
            set { proveedor_ultima_compra = value; }
        }

        private DateTime fecha_ultima_compra;
        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaUltimaCompra
        {
            get { return fecha_ultima_compra; }
            set { fecha_ultima_compra = value; }
        }

        private decimal valor_ultima_compra;
        /// <summary>
        /// 
        /// </summary>
        public decimal ValorUltimaCompra
        {
            get { return valor_ultima_compra; }
            set { valor_ultima_compra = value; }
        }

        private decimal reservascliente;
        /// <summary>
        /// 
        /// </summary>
        public decimal ReservasCliente
        {
            get { return reservascliente; }
            set { reservascliente = value; }
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

        private decimal costo_ponderado_final_ajustado;
        /// <summary>
        /// 
        /// </summary>
        public decimal CostoPonderadoFinalAjustado
        {
            get { return costo_ponderado_final_ajustado; }
            set { costo_ponderado_final_ajustado = value; }
        }

        private decimal reservas_inicial;
        /// <summary>
        /// 
        /// </summary>
        public decimal ReservasInicial
        {
            get { return reservas_inicial; }
            set { reservas_inicial = value; }
        }

        private decimal costo_inicial_ajustado_mes;
        /// <summary>
        /// 
        /// </summary>
        public decimal CostoInicialAjustadoMes
        {
            get { return costo_inicial_ajustado_mes; }
            set { costo_inicial_ajustado_mes = value; }
        }
    }
}
