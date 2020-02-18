using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class PedidoSiesaInfo
    {

        private string f_numero_reg;
        /// <summary>
        /// 1 | Numero de registro | Numero consecutivo |  Obligatorio: Si | Inicio:1 | Tamaño:7 | Tipo:Numérico
        /// </summary>
        public string F_NUMERO_REG
        {
            get { return f_numero_reg.PadLeft(7, '0'); }
            set { f_numero_reg = value; }
        }

        private string f_tipo_reg;
        /// <summary>
        /// 2 | Tipo de registro | Valor fijo = 430 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
        /// </summary>
        public string F_TIPO_REG
        {
            get { return f_tipo_reg.PadLeft(4, '0'); }
            set { f_tipo_reg = value; }
        }

        private string f_subtipo_reg;
        /// <summary>
        /// 3 | Subtipo de registro | Valor fijo = 00 |  Obligatorio: Si | Inicio:12 | Tamaño:2 | Tipo:Numérico
        /// </summary>
        public string F_SUBTIPO_REG
        {
            get { return f_subtipo_reg.PadLeft(2, '0'); }
            set { f_subtipo_reg = value; }
        }

        private string f_version_reg;
        /// <summary>
        /// 4 | Versión del tipo de registro | Versión = 02 |  Obligatorio: Si | Inicio:14 | Tamaño:2 | Tipo:Numérico
        /// </summary>
        public string F_VERSION_REG
        {
            get { return f_version_reg.PadLeft(2, '0'); }
            set { f_version_reg = value; }
        }

        private string f_cia;
        /// <summary>
        /// 5 | Compañía | Valida en maestro, código de la compañía a la cual pertenece la información del registro |  Obligatorio: Si | Inicio:16 | Tamaño:3 | Tipo:Numérico
        /// </summary>
        public string F_CIA
        {
            get { return f_cia.PadLeft(3, '0'); }
            set { f_cia = value; }
        }

        private string f_liquida_impuesto;
        /// <summary>
        /// 6 | Indicador para liquidar impuestos | 0=No liquida impuestos, respeta los que estan en el plano.
        /// 1=Liquida impuestos con los parámetros del sistema. Este indicador no se tendra en cuenta cuando los movimientos son paquetes. |  Obligatorio: Si | Inicio:19 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F_LIQUIDA_IMPUESTO
        {
            get { return f_liquida_impuesto.PadLeft(1, '0'); }
            set { f_liquida_impuesto = value; }
        }

        private string f_consec_auto_reg;
        /// <summary>
        /// 7 | Indica si el numero consecutivo de docto es manual o automático | 0=Manual, significa que respecta el consecutivo asignado en el plano, 1=Automático, significa que el consecutivo es recalculado con base en la tabla de consecutivos de docto. |  Obligatorio: Si | Inicio:20 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F_CONSEC_AUTO_REG
        {
            get { return f_consec_auto_reg.PadLeft(1, '0'); }
            set { f_consec_auto_reg = value; }
        }

        private string f_ind_contacto;
        /// <summary>
        /// 8 | Indicador de contacto | 0=Respeta la información del contacto contenida en el archivo plano.
        /// 1=Al importar el sistema lee el contacto automaticamente del punto de envio |  Obligatorio: Si | Inicio:21 | Tamaño:1 | Tipo:Numérico"
        /// </summary>
        public string F_IND_CONTACTO
        {
            get { return f_ind_contacto.PadLeft(1, '0'); }
            set { f_ind_contacto = value; }
        }

        private string f430_id_co;
        /// <summary>
        /// 9 | Centro de operación del documento | Valida en maestro, código de centro de operación del documento |  Obligatorio: Si | Inicio:22 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_CO
        {
            get { return f430_id_co.PadRight(3, ' '); }
            set { f430_id_co = value; }
        }

        private string f430_id_tipo_docto;
        /// <summary>
        /// 10 | Tipo de documento | Valida en maestro, código de tipo de documento |  Obligatorio: Si | Inicio:25 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_TIPO_DOCTO
        {
            get { return f430_id_tipo_docto.PadRight(3, ' '); }
            set { f430_id_tipo_docto = value; }
        }

        private string f430_consec_docto;
        /// <summary>
        /// 11 | Numero de documento | Numero de documento |  Obligatorio: Si | Inicio:28 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F430_CONSEC_DOCTO
        {
            get { return f430_consec_docto.PadLeft(8, '0'); }
            set { f430_consec_docto = value; }
        }

        private string f430_id_fecha;
        /// <summary>
        /// 12 | Fecha del documento | El formato debe ser AAAAMMDD |  Obligatorio: Si | Inicio:36 | Tamaño:8 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_FECHA
        {
            get { return f430_id_fecha.PadRight(8, ' '); }
            set { f430_id_fecha = value; }
        }

        private string f430_id_clase_docto;
        /// <summary>
        /// 13 | Clase interna del documento | Pedido directo = 502, Pedido no facturable = 506, Pedido para devolución = 508 |  Obligatorio: Si | Inicio:44 | Tamaño:3 | Tipo:Numérico
        /// </summary>
        public string F430_ID_CLASE_DOCTO
        {
            get { return f430_id_clase_docto.PadLeft(3, '0'); }
            set { f430_id_clase_docto = value; }
        }

        private string f430_ind_estado;
        /// <summary>
        /// 14 | Estado del documento | 0=Elaboración; 1=Aprobado cartera; 2=Aprobado; 9=Anulado |  Obligatorio: Si | Inicio:47 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F430_IND_ESTADO
        {
            get { return f430_ind_estado.PadLeft(1, '0'); }
            set { f430_ind_estado = value; }
        }

        private string f430_ind_backorder;
        /// <summary>
        /// 15 | Indicador backorder del documento | 0=Despachar solo lo disponible, 1=Despachar solo lo disponible y lo demás cancele, 2=Despachar sólo lineas completas y demas pendientes, 3=Despachar sólo lineas completas y demás cancele, 4=Despachar sólo pedido completo, 5=por linea, 6=Facturación diferida |  Obligatorio: Si | Inicio:48 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F430_IND_BACKORDER
        {
            get { return f430_ind_backorder.PadLeft(1, '0'); }
            set { f430_ind_backorder = value; }
        }

        private string f430_id_tercero_fact;
        /// <summary>
        /// 16 | Tercero cliente a facturar | Valida en maestro, código de tercero cliente |  Obligatorio: Si | Inicio:49 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_TERCERO_FACT
        {
            get { return f430_id_tercero_fact.PadRight(15, ' '); }
            set { f430_id_tercero_fact = value; }
        }

        private string f430_id_sucursal_fact;
        /// <summary>
        /// 17 | Sucursal cliente a facturar | Valida en maestro el codigo de la sucursal del cliente a facturar |  Obligatorio: Si | Inicio:64 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_SUCURSAL_FACT
        {
            get { return f430_id_sucursal_fact.PadRight(3, ' '); }
            set { f430_id_sucursal_fact = value; }
        }

        private string f430_id_tercero_rem;
        /// <summary>
        /// 18 | Tercero cliente a despachar | valida en maestro , codigo del tercero del cliente a despachar |  Obligatorio: Si | Inicio:67 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_TERCERO_REM
        {
            get { return f430_id_tercero_rem.PadRight(15, ' '); }
            set { f430_id_tercero_rem = value; }
        }

        private string f430_id_sucursal_rem;
        /// <summary>
        /// 19 | Sucursal cliente a despachar | Valida en maestro el codigo de la sucursal del cliente a despachar |  Obligatorio: Si | Inicio:82 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_SUCURSAL_REM
        {
            get { return f430_id_sucursal_rem.PadRight(3, ' '); }
            set { f430_id_sucursal_rem = value; }
        }

        private string f430_id_tipo_cli_fact;
        /// <summary>
        /// 20 | Tipo de cliente | Valida en maestro, tipo de clientes. Si es vacio la trae del cliente a facturar |  Obligatorio: No | Inicio:85 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_TIPO_CLI_FACT
        {
            get { return f430_id_tipo_cli_fact.PadRight(4, ' '); }
            set { f430_id_tipo_cli_fact = value; }
        }

        private string f430_id_co_fact;
        /// <summary>
        /// 21 | Centro de operación de la factura | Valida en maestro, código de centro de operación del documento |  Obligatorio: Si | Inicio:89 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_CO_FACT
        {
            get { return f430_id_co_fact.PadRight(3, ' '); }
            set { f430_id_co_fact = value; }
        }

        private string f430_fecha_entrega;
        /// <summary>
        /// 22 | Fecha entrega del pedido | El formato debe ser AAAAMMDD |  Obligatorio: Si | Inicio:92 | Tamaño:8 | Tipo:Fecha
        /// </summary>
        public string F430_FECHA_ENTREGA
        {
            get { return f430_fecha_entrega.PadRight(8, ' '); }
            set { f430_fecha_entrega = value; }
        }

        private string f430_num_dias_entrega;
        /// <summary>
        /// 23 | Nro. dias de entrega del documento | Valida Nro de dias en que se estima, la entrega del pedido |  Obligatorio: Si | Inicio:100 | Tamaño:3 | Tipo:Numérico
        /// </summary>
        public string F430_NUM_DIAS_ENTREGA
        {
            get { return f430_num_dias_entrega.PadLeft(3, '0'); }
            set { f430_num_dias_entrega = value; }
        }

        private string f430_num_docto_referencia;
        /// <summary>
        /// 24 | Orden de compra del Documento | Valida la orden de compra del documento |  Obligatorio: No | Inicio:103 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F430_NUM_DOCTO_REFERENCIA
        {
            get { return f430_num_docto_referencia.PadRight(15, ' '); }
            set { f430_num_docto_referencia = value; }
        }

        private string f430_referencia;
        /// <summary>
        /// 25 | Referencia del documento | Valida la referencia del documento |  Obligatorio: No | Inicio:118 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F430_REFERENCIA
        {
            get { return f430_referencia.PadRight(10, ' '); }
            set { f430_referencia = value; }
        }

        private string f430_id_cargue;
        /// <summary>
        /// 26 | Codigo de cargue del documento | Valida numero de cargue del documento |  Obligatorio: No | Inicio:128 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_CARGUE
        {
            get { return f430_id_cargue.PadRight(10, ' '); }
            set { f430_id_cargue = value; }
        }

        private string f430_id_moneda_docto;
        /// <summary>
        /// 27 | Codigo de moneda del documento | Valida moneda del documento |  Obligatorio: Si | Inicio:138 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_MONEDA_DOCTO
        {
            get { return f430_id_moneda_docto.PadRight(3, ' '); }
            set { f430_id_moneda_docto = value; }
        }

        private string f430_id_moneda_conv;
        /// <summary>
        /// 28 | Moneda base de conversión | Valida en maestro, código de moneda base definida en la compañía.  |  Obligatorio: Si | Inicio:141 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_MONEDA_CONV
        {
            get { return f430_id_moneda_conv.PadRight(3, ' '); }
            set { f430_id_moneda_conv = value; }
        }

        private string f430_tasa_conv;
        /// <summary>
        /// 29 | Tasa de conversión | Coloque 1 si la moneda del documento es igual a la moneda local o a la moneda base de conversion de lo contrario coloque la tasa de conversion.
        /// El formato debe ser (8 enteros + punto + 4 decimales) (00000000.0000) |  Obligatorio: Si | Inicio:144 | Tamaño:13 | Tipo:Numérico"
        /// </summary>
        public string F430_TASA_CONV
        {
            get { return f430_tasa_conv.PadLeft(13, '0'); }
            set { f430_tasa_conv = value; }
        }

        private string f430_id_moneda_local;
        /// <summary>
        /// 30 | Moneda local | Valida en maestro, código de moneda local definida en la compañía. |  Obligatorio: Si | Inicio:157 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_MONEDA_LOCAL
        {
            get { return f430_id_moneda_local.PadRight(3, ' '); }
            set { f430_id_moneda_local = value; }
        }

        private string f430_tasa_local;
        /// <summary>
        /// 31 | Tasa local  | Coloque 1 si la moneda del documento es igual a la moneda local de lo contrario coloque la tasa de cambio.
        /// El formato debe ser (8 enteros + punto + 4 decimales) (00000000.0000) |  Obligatorio: Si | Inicio:160 | Tamaño:13 | Tipo:Numérico"
        /// </summary>
        public string F430_TASA_LOCAL
        {
            get { return f430_tasa_local.PadLeft(13, '0'); }
            set { f430_tasa_local = value; }
        }

        private string f430_id_cond_pago;
        /// <summary>
        /// 32 | Condicion de pago | Valida en maestro, condiciones de pago |  Obligatorio: Si | Inicio:173 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_COND_PAGO
        {
            get { return f430_id_cond_pago.PadRight(3, ' '); }
            set { f430_id_cond_pago = value; }
        }

        private string f430_ind_impresion;
        /// <summary>
        /// 33 | Estado de impresión del documento | 0=No Impreso; 1=Impreso |  Obligatorio: Si | Inicio:176 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F430_IND_IMPRESION
        {
            get { return f430_ind_impresion.PadLeft(1, '0'); }
            set { f430_ind_impresion = value; }
        }

        private string f430_notas;
        /// <summary>
        /// 34 | Observaciones del documento | Observaciones |  Obligatorio: Si | Inicio:177 | Tamaño:2000 | Tipo:Alfanumérico
        /// </summary>
        public string F430_NOTAS
        {
            get { return f430_notas.PadRight(2000, ' '); }
            set { f430_notas = value; }
        }

        private string f430_id_cli_contado;
        /// <summary>
        /// 35 | Cliente de contado | Valida en maestro, clientes ocasional |  Obligatorio: No | Inicio:2177 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_CLI_CONTADO
        {
            get { return f430_id_cli_contado.PadRight(15, ' '); }
            set { f430_id_cli_contado = value; }
        }

        private string f430_id_punto_envio;
        /// <summary>
        /// 36 | Punto de envio | Valida en maestro de puntos de envio del cliente |  Obligatorio: Si | Inicio:2192 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_PUNTO_ENVIO
        {
            get { return f430_id_punto_envio.PadRight(3, ' '); }
            set { f430_id_punto_envio = value; }
        }

        private string f430_id_tercero_vendedor;
        /// <summary>
        /// 37 | Vendedor del pedido | Si es vacio lo trae del cliente a facturar |  Obligatorio: Si | Inicio:2195 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_TERCERO_VENDEDOR
        {
            get { return f430_id_tercero_vendedor.PadRight(15, ' '); }
            set { f430_id_tercero_vendedor = value; }
        }

        private string f419_contacto;
        /// <summary>
        /// 38 | Contacto | Obligatorio si el indicador de contacto es 0. Nombre de la persona de contacto |  Obligatorio: Dep | Inicio:2210 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F419_CONTACTO
        {
            get { return f419_contacto.PadRight(50, ' '); }
            set { f419_contacto = value; }
        }

        private string f419_direccion1;
        /// <summary>
        /// 39 | Direccion 1 | Obligatorio si el indicador de contacto es 0. Renglón 1 de la dirección del contacto |  Obligatorio: Dep | Inicio:2260 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F419_DIRECCION1
        {
            get { return f419_direccion1.PadRight(40, ' '); }
            set { f419_direccion1 = value; }
        }

        private string f419_direccion2;
        /// <summary>
        /// 40 | Direccion 2 | Renglón 2 de la dirección del contacto |  Obligatorio: No | Inicio:2300 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F419_DIRECCION2
        {
            get { return f419_direccion2.PadRight(40, ' '); }
            set { f419_direccion2 = value; }
        }

        private string f419_direccion3;
        /// <summary>
        /// 41 | Direccion 3 | Renglón 3 de la dirección del contacto |  Obligatorio: No | Inicio:2340 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F419_DIRECCION3
        {
            get { return f419_direccion3.PadRight(40, ' '); }
            set { f419_direccion3 = value; }
        }

        private string f419_id_pais;
        /// <summary>
        /// 42 | Pais | Valida en maestro, código del país |  Obligatorio: No | Inicio:2380 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F419_ID_PAIS
        {
            get { return f419_id_pais.PadRight(3, ' '); }
            set { f419_id_pais = value; }
        }

        private string f419_id_depto;
        /// <summary>
        /// 43 | Departamento/Estado | Obligatorio si el indicador de contacto es 0 y reportan codigo de pais. Valida en maestro, código del departamento |  Obligatorio: Dep | Inicio:2383 | Tamaño:2 | Tipo:Alfanumérico
        /// </summary>
        public string F419_ID_DEPTO
        {
            get { return f419_id_depto.PadRight(2, ' '); }
            set { f419_id_depto = value; }
        }

        private string f419_id_ciudad;
        /// <summary>
        /// 44 | Ciudad | Obligatorio si el indicador de contacto es 0 y reportan codigo de Departamento.Valida en maestro, código de la ciudad |  Obligatorio: Dep | Inicio:2385 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F419_ID_CIUDAD
        {
            get { return f419_id_ciudad.PadRight(3, ' '); }
            set { f419_id_ciudad = value; }
        }

        private string f419_id_barrio;
        /// <summary>
        /// 45 | Barrio | Barrio  |  Obligatorio: No | Inicio:2388 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F419_ID_BARRIO
        {
            get { return f419_id_barrio.PadRight(40, ' '); }
            set { f419_id_barrio = value; }
        }

        private string f419_telefono;
        /// <summary>
        /// 46 | Telefono | Teléfono |  Obligatorio: No | Inicio:2428 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F419_TELEFONO
        {
            get { return f419_telefono.PadRight(20, ' '); }
            set { f419_telefono = value; }
        }

        private string f419_fax;
        /// <summary>
        /// 47 | Fax | Fax |  Obligatorio: No | Inicio:2448 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F419_FAX
        {
            get { return f419_fax.PadRight(20, ' '); }
            set { f419_fax = value; }
        }

        private string f419_cod_postal;
        /// <summary>
        /// 48 | Codigo postal | código postal o apartado aéreo |  Obligatorio: No | Inicio:2468 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F419_COD_POSTAL
        {
            get { return f419_cod_postal.PadRight(10, ' '); }
            set { f419_cod_postal = value; }
        }

        private string f419_email;
        /// <summary>
        /// 49 | E-Mail | dirección de correo electrónico |  Obligatorio: No | Inicio:2478 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F419_EMAIL
        {
            get { return f419_email.PadRight(50, ' '); }
            set { f419_email = value; }
        }

        private string f419_ind_descuento;
        /// <summary>
        /// 50 | Indicador de descuento | 
        /// 0 = Reliquida descuentos.
        /// 1 = Liquida con descuentos del plano
        /// 2 = Descuentos manuales y automáticos  (primero se liquidaran los descuentos automaticos y despues los manuales.).
        /// 3 = Descuentos manuales y obsequios automáticos. |  Obligatorio: Si | Inicio:2528 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F419_IND_DESCUENTO
        {
            get { return f419_ind_descuento.PadLeft(1, '0'); }
            set { f419_ind_descuento = value; }
        }
    }
}
