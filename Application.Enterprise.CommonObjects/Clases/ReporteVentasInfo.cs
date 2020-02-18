using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class ReporteVentasInfo
    {
        private string numero_correlativo;

        public string NumeroCorrelativo
        {
            get { return numero_correlativo; }
            set { numero_correlativo = value; }
        }
        private DateTime fecha_emision;

        public DateTime FechaEmision
        {
            get { return fecha_emision; }
            set { fecha_emision = value; }
        }
        private DateTime fecha_vencimiento;

        public DateTime FechaVencimiento
        {
            get { return fecha_vencimiento; }
            set { fecha_vencimiento = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string serie_registradora;

        public string SerieRegistradora
        {
            get { return serie_registradora; }
            set { serie_registradora = value; }
        }
        private string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private string documento_tipo;

        public string DocumentoTipo
        {
            get { return documento_tipo; }
            set { documento_tipo = value; }
        }
        private string documento_numero;

        public string DocumentoNumero
        {
            get { return documento_numero; }
            set { documento_numero = value; }
        }
        private string razon_social;

        public string RazonSocial
        {
            get { return razon_social; }
            set { razon_social = value; }
        }
        private decimal base_imponible;

        public decimal BaseImponible
        {
            get { return base_imponible; }
            set { base_imponible = value; }
        }
        private decimal igv;

        public decimal Igv
        {
            get { return igv; }
            set { igv = value; }
        }
        private decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        private DateTime factura_fecha;

        public DateTime FacturaFecha
        {
            get { return factura_fecha; }
            set { factura_fecha = value; }
        }
        private string factura_tipo;

        public string FacturaTipo
        {
            get { return factura_tipo; }
            set { factura_tipo = value; }
        }
        private string factura_serie;

        public string FacturaSerie
        {
            get { return factura_serie; }
            set { factura_serie = value; }
        }
        private string factura_numero;

        public string FacturaNumero
        {
            get { return factura_numero; }
            set { factura_numero = value; }
        }

        //-------------------------------------------
        //variables nuevas Mauricio Ramos Gil

        private string valor_facturado_exportacion;

        public string ValorFacturadoExportacion
        {
            get { return valor_facturado_exportacion; }
            set { valor_facturado_exportacion = value; }
        }

        private string exonerada;

        public string Exonerada
        {
            get { return exonerada; }
            set { exonerada = value; }
        }

        private string inafecta;

        public string Inafecta
        {
            get { return inafecta; }
            set { inafecta = value; }
        }

        //Variables Mauricio reporte sheyla
        //Variables Mauricio reporte sheyla
        //Variables Mauricio reporte sheyla

        private string mes;

        public string Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        //private string numero;

        //public string Numero
        //{
        //    get { return numero; }
        //    set { numero = value; }
        //}

        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string vencimiento;

        public string Vencimiento
        {
            get { return vencimiento; }
            set { vencimiento = value; }
        }

        //private string tipo;

        //public string Tipo
        //{
        //    get { return tipo; }
        //    set { tipo = value; }
        //}

        private string serie;

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        private string numero_fact;

        public string Numero_fact
        {
            get { return numero_fact; }
            set { numero_fact = value; }
        }

        private int tip;

        public int Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        private string nit;

        public string Nit
        {
            get { return nit; }
            set { nit = value; }
        }

        //private string razon_social;

        //public string Razon_Social
        //{
        //    get { return razon_social; }
        //    set { razon_social = value; }
        //}

        private string vfe;

        public string VFE
        {
            get { return vfe; }
            set { vfe = value; }
        }

        private decimal base1;

        public decimal Base1
        {
            get { return base1; }
            set { base1 = value; }
        }


        //private string exonerada;

        //public string Exonerada
        //{
        //    get { return exonerada; }
        //    set { exonerada = value; }
        //}


        //private string inafecta;

        //public string Inafecta
        //{
        //    get { return inafecta; }
        //    set { inafecta = value; }
        //}


        //private string igv;

        //public string IGV
        //{
        //    get { return igv; }
        //    set { igv = value; }
        //}


        private decimal total;

        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        private string fecha_fd;

        public string Fecha_fd
        {
            get { return fecha_fd; }
            set { fecha_fd = value; }
        }

        private string tipo_fd;

        public string Tipo_fd
        {
            get { return tipo_fd; }
            set { tipo_fd = value; }
        }

        private string serie_fd;

        public string Serie_fd
        {
            get { return serie_fd; }
            set { serie_fd = value; }
        }

        private string numero_fd;

        public string Numero_fd
        {
            get { return numero_fd; }
            set { numero_fd = value; }
        }

        private int estado;

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

    }
}