using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PedidoSiesaMovtoPedidosInfo
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
        /// 2 | Tipo de registro | Valor fijo = 431 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
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
        /// 4 | Version del tipo de registro | Version = 02 |  Obligatorio: Si | Inicio:14 | Tamaño:2 | Tipo:Numérico
        /// </summary>
        public string F_VERSION_REG
        {
            get { return f_version_reg.PadLeft(2, '0'); }
            set { f_version_reg = value; }
        }

        private string f_cia;
        /// <summary>
        /// 5 | Compañía | Valida en maestro, código de la compañía a la cual pertenece la informacion del registro |  Obligatorio: Si | Inicio:16 | Tamaño:3 | Tipo:Numérico
        /// </summary>
        public string F_CIA
        {
            get { return f_cia.PadLeft(3, '0'); }
            set { f_cia = value; }
        }

        private string f431_id_co;
        /// <summary>
        /// 6 | Centro de operación | Valida en maestro, código de centro de operación del documento |  Obligatorio: Si | Inicio:19 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_CO
        {
            get { return f431_id_co.PadRight(3, ' '); }
            set { f431_id_co = value; }
        }

        private string f431_id_tipo_docto;
        /// <summary>
        /// 7 | Tipo de documento  | Valida en maestro, código de tipo de documento, tipo de documento del pedido |  Obligatorio: Si | Inicio:22 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_TIPO_DOCTO
        {
            get { return f431_id_tipo_docto.PadRight(3, ' '); }
            set { f431_id_tipo_docto = value; }
        }

        private string f431_consec_docto;
        /// <summary>
        /// 8 | Consecutivo de documento  | Numero de documento del pedido |  Obligatorio: Si | Inicio:25 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F431_CONSEC_DOCTO
        {
            get { return f431_consec_docto.PadLeft(8, '0'); }
            set { f431_consec_docto = value; }
        }

        private string f431_nro_registro;
        /// <summary>
        /// 9 | Numero de registro | Numero de registro del movimiento |  Obligatorio: Si | Inicio:33 | Tamaño:10 | Tipo:Numérico
        /// </summary>
        public string F431_NRO_REGISTRO
        {
            get { return f431_nro_registro.PadLeft(10, '0'); }
            set { f431_nro_registro = value; }
        }

        private string f431_id_item;
        /// <summary>
        /// 10 | Item | Codigo, es obligatorio si no va referencia ni codigo de barras |  Obligatorio: Dep | Inicio:43 | Tamaño:7 | Tipo:Numérico
        /// </summary>
        public string F431_ID_ITEM
        {
            get { return f431_id_item.PadLeft(7, '0'); }
            set { f431_id_item = value; }
        }

        private string f431_referencia_item;
        /// <summary>
        /// 11 | Referencia item | Codigo, es obligatorio si no va codigo de item ni codigo de barras |  Obligatorio: Dep | Inicio:50 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F431_REFERENCIA_ITEM
        {
            get { return f431_referencia_item.PadRight(50, ' '); }
            set { f431_referencia_item = value; }
        }

        private string f431_codigo_barras;
        /// <summary>
        /// 12 | Codigo de barras | Codigo, es obligatorio si no va codigo de item ni referencia |  Obligatorio: Dep | Inicio:100 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F431_CODIGO_BARRAS
        {
            get { return f431_codigo_barras.PadRight(20, ' '); }
            set { f431_codigo_barras = value; }
        }

        private string f431_id_ext1_detalle;
        /// <summary>
        /// 13 | Extension 1 | Es obligatorio si el ítem maneja extensión 1 |  Obligatorio: Dep | Inicio:120 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_EXT1_DETALLE
        {
            get { return f431_id_ext1_detalle.PadRight(20, ' '); }
            set { f431_id_ext1_detalle = value; }
        }

        private string f431_id_ext2_detalle;
        /// <summary>
        /// 14 | Extension 2 | Es obligatorio si el ítem maneja extensión 2 |  Obligatorio: Dep | Inicio:140 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_EXT2_DETALLE
        {
            get { return f431_id_ext2_detalle.PadRight(20, ' '); }
            set { f431_id_ext2_detalle = value; }
        }

        private string f431_id_bodega;
        /// <summary>
        /// 15 | Bodega | Valida en maestro, código de bodega |  Obligatorio: Si | Inicio:160 | Tamaño:5 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_BODEGA
        {
            get { return f431_id_bodega.PadRight(5, ' '); }
            set { f431_id_bodega = value; }
        }

        private string f431_id_concepto;
        /// <summary>
        /// 16 | Concepto | 501=Ventas, 502=Devolución de venta, 511 = Remisiones no facturables |  Obligatorio: Si | Inicio:165 | Tamaño:3 | Tipo:Numérico
        /// </summary>
        public string F431_ID_CONCEPTO
        {
            get { return f431_id_concepto.PadLeft(3, '0'); }
            set { f431_id_concepto = value; }
        }

        private string f431_id_motivo;
        /// <summary>
        /// 17 | Motivo | Valida en maestro, código de motivo |  Obligatorio: Si | Inicio:168 | Tamaño:2 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_MOTIVO
        {
            get { return f431_id_motivo.PadRight(2, ' '); }
            set { f431_id_motivo = value; }
        }

        private string f431_ind_obsequio;
        /// <summary>
        /// 18 | Indicador de obsequio | Indicador de obsequio 0=No, 1=Si |  Obligatorio: Si | Inicio:170 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F431_IND_OBSEQUIO
        {
            get { return f431_ind_obsequio.PadLeft(1, '0'); }
            set { f431_ind_obsequio = value; }
        }

        private string f431_id_co_movto;
        /// <summary>
        /// 19 | Centro de operación movimiento | Valida en maestro, código de centro de operación del movimiento |  Obligatorio: Si | Inicio:171 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_CO_MOVTO
        {
            get { return f431_id_co_movto.PadRight(3, ' '); }
            set { f431_id_co_movto = value; }
        }

        private string f431_id_un_movto;
        /// <summary>
        /// 20 | Unidad de negocio movimiento | Valida en maestro, código de unidad de negocio del movimiento. Si es vacio el sistema la calcula |  Obligatorio: No | Inicio:174 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_UN_MOVTO
        {
            get { return f431_id_un_movto.PadRight(20, ' '); }
            set { f431_id_un_movto = value; }
        }

        private string f431_id_ccosto_movto;
        /// <summary>
        /// 21 | Centro de costo movimiento | Obligatorio si la  cuenta contable exige ccosto. Valida en maestro, código de centro de costo del movimiento. |  Obligatorio: Dep | Inicio:194 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_CCOSTO_MOVTO
        {
            get { return f431_id_ccosto_movto.PadRight(15, ' '); }
            set { f431_id_ccosto_movto = value; }
        }

        private string f431_id_proyecto;
        /// <summary>
        /// 22 | Proyecto | Valida en maestro, código de proyecto del movimiento |  Obligatorio: No | Inicio:209 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_PROYECTO
        {
            get { return f431_id_proyecto.PadRight(15, ' '); }
            set { f431_id_proyecto = value; }
        }

        private string f431_fecha_entrega;
        /// <summary>
        /// 23 | Fecha entrega del pedido | El formato debe ser AAAAMMDD |  Obligatorio: Si | Inicio:224 | Tamaño:8 | Tipo:Fecha
        /// </summary>
        public string F431_FECHA_ENTREGA
        {
            get { return f431_fecha_entrega.PadRight(8, ' '); }
            set { f431_fecha_entrega = value; }
        }

        private string f431_num_dias_entrega;
        /// <summary>
        /// 24 | Nro. dias de entrega del documento | Valida Nro de dias en que se estima, la entrega del pedido |  Obligatorio: Si | Inicio:232 | Tamaño:3 | Tipo:Numérico
        /// </summary>
        public string F431_NUM_DIAS_ENTREGA
        {
            get { return f431_num_dias_entrega.PadLeft(3, '0'); }
            set { f431_num_dias_entrega = value; }
        }

        private string f431_id_lista_precio;
        /// <summary>
        /// 25 | Lista de precio | Valida en maestro, código de la lista de precio, obligatoio si indicador de precio es 1 ó 2. |  Obligatorio: No | Inicio:235 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_LISTA_PRECIO
        {
            get { return f431_id_lista_precio.PadRight(3, ' '); }
            set { f431_id_lista_precio = value; }
        }

        private string f431_id_unidad_medida;
        /// <summary>
        /// 26 | Unidad de medida | Valida en maestro, código de unidad de medida del movimiento |  Obligatorio: Si | Inicio:238 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F431_ID_UNIDAD_MEDIDA
        {
            get { return f431_id_unidad_medida.PadRight(4, ' '); }
            set { f431_id_unidad_medida = value; }
        }

        private string f431_cant_pedida_base;
        /// <summary>
        /// 27 | Cantidad base | Cantidad en unidad de captura, el formato debe ser (15 enteros + punto + 4 decimales). El número de decimales se deben reportar teniendo en cuenta el número de decimales configurados en la unidad de medidad.
        /// (000000000000000.0000) |  Obligatorio: Si | Inicio:242 | Tamaño:20 | Tipo:Numérico
        /// </summary>
        public string F431_CANT_PEDIDA_BASE
        {
            get { return f431_cant_pedida_base.PadLeft(20, '0'); }
            set { f431_cant_pedida_base = value; }
        }

        private string f431_cant2_pedida;
        /// <summary>
        /// 28 | Cantidad adicional | Cantidad adicional, es obligatorio si el item maneja unidad adicional, el formato debe ser (15 enteros + punto + 4 decimales). El número de decimales se deben reportar teniendo en cuenta el número de decimales configurados en la unidad de medidad.
        /// (000000000000000.0000) |  Obligatorio: Dep | Inicio:262 | Tamaño:20 | Tipo:Numérico
        /// </summary>
        public string F431_CANT2_PEDIDA
        {
            get { return f431_cant2_pedida.PadLeft(20, '0'); }
            set { f431_cant2_pedida = value; }
        }

        private string f431_precio_unitario;
        /// <summary>
        /// 29 | Precio unitario | Debe ser mayor a 0 si no es obsequio y si el indicador de precio es 2. El formato debe ser (15 enteros + punto + 4 decimales). El número de decimales se deben reportar teniendo en cuenta el número de decimales configurados en la moneda (decimales unidades). |  Obligatorio: Dep | Inicio:282 | Tamaño:20 | Tipo:Numérico
        /// </summary>
        public string F431_PRECIO_UNITARIO
        {
            get { return f431_precio_unitario.PadLeft(20, '0'); }
            set { f431_precio_unitario = value; }
        }

        private string f431_ind_impto_asumido;
        /// <summary>
        /// 30 | Impuestos asumidos | Se valida con el indicador de impuestos asumidos del  motivo. Debe ser 0=No liquida; 1=Asume compañía, 2=Asume cliente. |  Obligatorio: Si | Inicio:302 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F431_IND_IMPTO_ASUMIDO
        {
            get { return f431_ind_impto_asumido.PadLeft(1, '0'); }
            set { f431_ind_impto_asumido = value; }
        }

        private string f431_notas;
        /// <summary>
        /// 31 | Notas | Notas del movimiento |  Obligatorio: No | Inicio:303 | Tamaño:255 | Tipo:Alfanumérico
        /// </summary>
        public string F431_NOTAS
        {
            get { return f431_notas.PadRight(255, ' '); }
            set { f431_notas = value; }
        }

        private string f431_detalle;
        /// <summary>
        /// 32 | Descripcion | Descripcion del movimiento |  Obligatorio: No | Inicio:558 | Tamaño:2000 | Tipo:Alfanumérico
        /// </summary>
        public string F431_DETALLE
        {
            get { return f431_detalle.PadRight(2000, ' '); }
            set { f431_detalle = value; }
        }

        private string f431_ind_backorder;
        /// <summary>
        /// 33 | Indicador backorder del movimiento | 0=Disponible y lo demás pendiente, 1=Disponible y lo demás cancele, 5=por linea. Si f430_ind_backorder es diferente de 5 entonces f431_ind_backorder debe ser 5. |  Obligatorio: Si | Inicio:2558 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F431_IND_BACKORDER
        {
            get { return f431_ind_backorder.PadLeft(1, '0'); }
            set { f431_ind_backorder = value; }
        }

        private string f431_ind_precio;
        /// <summary>
        /// 34 | Indicador de precio | 0=Reliquida precio con lista de precio del cliente 1=Liquida precio con lista de precio del registro 2=Liquida con precio del registro. |  Obligatorio: Si | Inicio:2559 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F431_IND_PRECIO
        {
            get { return f431_ind_precio.PadLeft(1, '0'); }
            set { f431_ind_precio = value; }
        }

    }
}
