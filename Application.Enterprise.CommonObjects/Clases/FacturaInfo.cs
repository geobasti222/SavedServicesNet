using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class FacturaInfo
    {
        private string numero;

        public string Numero
        {
            get { return numero.Trim(); }
            set { numero = value; }
        }

        private DateTime fecha_a;

        public DateTime Fecha_a
        {
            get { return fecha_a; }
            set { fecha_a = value; }
        }
        
        private DateTime vencimiento;
        public DateTime Vencimiento
        {
            get { return vencimiento; }
            set { vencimiento = value; }
        }

        private string nit;

        public string Nit
        {
            get { return nit.Trim(); }
            set { nit = value; }
        }
        private string vendedor;

        public string Vendedor
        {
            get { return vendedor.Trim(); }
            set { vendedor = value; }
        }
        
        private decimal valor_a;

        public decimal Valor_a
        {
            get { return valor_a; }
            set { valor_a = value; }
        }

        private decimal descuento_b;

        public decimal Descuento_b
        {
            get { return descuento_b; }
            set { descuento_b = value; }
        }
        private string codigoretencion;

        public string Codigoretencion
        {
            get { return codigoretencion.Trim(); }
            set { codigoretencion = value; }
        }
        private decimal retefuente;

        public decimal Retefuente
        {
            get { return retefuente; }
            set { retefuente = value; }
        }
        private decimal anticipoiva;

        public decimal Anticipoiva
        {
            get { return anticipoiva; }
            set { anticipoiva = value; }
        }
        private decimal retencionica;

        public decimal Retencionica
        {
            get { return retencionica; }
            set { retencionica = value; }
        }
        private decimal iva;

        public decimal Iva
        {
            get { return iva; }
            set { iva = value; }
        }
        private string referencia;

        public string Referencia
        {
            get { return referencia.Trim(); }
            set { referencia = value; }
        }
        private string producto;

        public string Producto
        {
            get { return producto.Trim(); }
            set { producto = value; }
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

        public decimal Tarifaiva
        {
            get { return tarifaiva; }
            set { tarifaiva = value; }
        }
        private string razon_social;

        public string Razon_social
        {
            get { return razon_social.Trim(); }
            set { razon_social = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion.Trim(); }
            set { direccion = value; }
        }
        private string ciudad;

        public string Ciudad
        {
            get { return ciudad.Trim(); }
            set { ciudad = value; }
        }
        private string ciudadempresaria;

        public string Ciudadempresaria
        {
            get { return ciudadempresaria.Trim(); }
            set { ciudadempresaria = value; }
        }
        private string telefonos;

        public string Telefonos
        {
            get { return telefonos.Trim(); }
            set { telefonos = value; }
        }
        private string telefonodos;

        public string Telefonodos
        {
            get { return telefonodos.Trim(); }
            set { telefonodos = value; }
        }
        private string gerentezonal;

        public string Gerentezonal
        {
            get { return gerentezonal.Trim(); }
            set { gerentezonal = value; }
        }
        private string unidad_de_medida;

        public string Unidad_de_medida
        {
            get { return unidad_de_medida.Trim(); }
            set { unidad_de_medida = value; }
        }
        private string zona;

        public string Zona
        {
            get { return zona.Trim(); }
            set { zona = value; }
        }
        private string nombrezona;

        public string Nombrezona
        {
            get { return nombrezona.Trim(); }
            set { nombrezona = value; }
        }
        private string codgereg;

        public string Codgereg
        {
            get { return codgereg.Trim(); }
            set { codgereg = value; }
        }
        private string nombreuno;

        public string Nombreuno
        {
            get { return nombreuno.Trim(); }
            set { nombreuno = value; }
        }
        private string nombredos;

        public string Nombredos
        {
            get { return nombredos.Trim(); }
            set { nombredos = value; }
        }
        private string apellidouno;

        public string Apellidouno
        {
            get { return apellidouno.Trim(); }
            set { apellidouno = value; }
        }
        private string apellidodos;

        public string Apellidodos
        {
            get { return apellidodos.Trim(); }
            set { apellidodos = value; }
        }
        private string codregion;

        public string Codregion
        {
            get { return codregion.Trim(); }
            set { codregion = value; }
        }
        private string nombreregion;

        public string Nombreregion
        {
            get { return nombreregion.Trim(); }
            set { nombreregion = value; }
        }
        private string bodega;

        public string Bodega
        {
            get { return bodega.Trim(); }
            set { bodega = value; }
        }
        private string campana;

        public string Campana
        {
            get { return campana.Trim(); }
            set { campana = value; }
        }
        private string codigocolor;

        public string Codigocolor
        {
            get { return codigocolor.Trim(); }
            set { codigocolor = value; }
        }
        private string codigotalla;

        public string Codigotalla
        {
            get { return codigotalla.Trim(); }
            set { codigotalla = value; }
        }
        private string nomtalla;

        public string Nomtalla
        {
            get { return nomtalla.Trim(); }
            set { nomtalla = value; }
        }
        private string codubicacion;

        public string Codubicacion
        {
            get { return codubicacion.Trim(); }
            set { codubicacion = value; }
        }
        private string posicion;

        public string Posicion
        {
            get { return posicion.Trim(); }
            set { posicion = value; }
        }
        private string prefijo;

        public string Prefijo
        {
            get { return prefijo.Trim(); }
            set { prefijo = value; }
        }
        private string desde;

        public string Desde
        {
            get { return desde.Trim(); }
            set { desde = value; }
        }
        private string hasta;

        public string Hasta
        {
            get { return hasta.Trim(); }
            set { hasta = value; }
        }
        private string inicial;

        public string Inicial
        {
            get { return inicial.Trim(); }
            set { inicial = value; }
        }
        private string resolucion;

        public string Resolucion
        {
            get { return resolucion.Trim(); }
            set { resolucion = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private string numeropedido;

        public string Numeropedido
        {
            get { return numeropedido.Trim(); }
            set { numeropedido = value; }
        }
        private string nomcolor;

        public string Nomcolor
        {
            get { return nomcolor.Trim(); }
            set { nomcolor = value; }
        }
        private string cedula;

        public string Cedula
        {
            get { return cedula.Trim(); }
            set { cedula = value; }
        }
        private string telefonouno;

        public string Telefonouno
        {
            get { return telefonouno.Trim(); }
            set { telefonouno = value; }
        }
        private string telefono2;

        public string Telefono2
        {
            get { return telefono2.Trim(); }
            set { telefono2 = value; }
        }
        private string telefonotres;

        public string Telefonotres
        {
            get { return telefonotres.Trim(); }
            set { telefonotres = value; }
        }
        private string saldo;

        public string Saldo
        {
            get { return saldo.Trim(); }
            set { saldo = value; }
        }
        private string barrio;

        public string Barrio
        {
            get { return barrio.Trim(); }
            set { barrio = value; }
        }
        private string boletas;

        public string Boletas
        {
            get { return boletas; }
            set { boletas = value; }
        }
        private string codestado;

        public string Codestado
        {
            get { return codestado.Trim(); }
            set { codestado = value; }
        }
        private string nombreestado;

        public string Nombreestado
        {
            get { return nombreestado.Trim(); }
            set { nombreestado = value; }
        }      
    }
}
