using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ClienteSiesaInfo
    {
        private string f_numero_reg;
        /// <summary>
        /// 1 | Numero de registro | Numero consecutivo |  Obligatorio: Si | Inicio:1 | Tamaño:7 | Tipo: Numerico
        /// </summary>
        public string F_NUMERO_REG
        {
            get { return f_numero_reg.PadLeft(7, '0'); }
            set { f_numero_reg = value; }
        }

        private string f_tipo_reg;
        /// <summary>
        /// 2 | Tipo de registro | Valor fijo = 201 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo: Numerico
        /// </summary>
        public string F_TIPO_REG
        {
            get { return f_tipo_reg.PadLeft(4, '0'); }
            set { f_tipo_reg = value; }
        }

        private string f_subtipo_reg;
        /// <summary>
        /// 3 | Subtipo de registro | Valor fijo = 00 |  Obligatorio: Si | Inicio:12 | Tamaño:2 | Tipo: Numerico
        /// </summary>
        public string F_SUBTIPO_REG
        {
            get { return f_subtipo_reg.PadLeft(2, '0'); }
            set { f_subtipo_reg = value; }
        }

        private string f_version_reg;
        /// <summary>
        /// 4 | Versión del tipo de registro | Versión = 08 |  Obligatorio: Si | Inicio:14 | Tamaño:2 | Tipo: Numerico
        /// </summary>
        public string F_VERSION_REG
        {
            get { return f_version_reg.PadLeft(2, '0'); }
            set { f_version_reg = value; }
        }

        private string f_cia;
        /// <summary>
        /// 5 | Compañía | Valida en maestro, código de la compañía a la cual pertenece la información del registro |  Obligatorio: Si | Inicio:16 | Tamaño:3 | Tipo: Numerico
        /// </summary>
        public string F_CIA
        {
            get { return f_cia.PadLeft(3, '0'); }
            set { f_cia = value; }
        }

        private string f_actualiza_reg;
        /// <summary>
        /// 6 | Indica si remplaza la información del cliente cuando este ya existe | 0=No, 1=Si |  Obligatorio: Si | Inicio:19 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F_ACTUALIZA_REG
        {
            get { return f_actualiza_reg.PadLeft(1, '0'); }
            set { f_actualiza_reg = value; }
        }

        private string f201_id_tercero;
        /// <summary>
        /// 7 | Código del cliente | Código del cliente |  Obligatorio: Si | Inicio:20 | Tamaño:15 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_TERCERO
        {
            get { return f201_id_tercero.PadRight(15, ' '); }
            set { f201_id_tercero = value; }
        }

        private string f201_id_sucursal;
        /// <summary>
        /// 8 | Sucursal del cliente | Sucursal del cliente |  Obligatorio: Si | Inicio:35 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_SUCURSAL
        {
            get { return f201_id_sucursal.PadRight(3, ' '); }
            set { f201_id_sucursal = value; }
        }

        private string f201_ind_estado_activo;
        /// <summary>
        /// 9 | Estado del cliente | 1=Activo; 0=Inactivo |  Obligatorio: Si | Inicio:38 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F201_IND_ESTADO_ACTIVO
        {
            get { return f201_ind_estado_activo.PadLeft(1, '0'); }
            set { f201_ind_estado_activo = value; }
        }

        private string f201_descripcion_sucursal;
        /// <summary>
        /// 10 | Razón social del cliente | Razón social para la sucursal del cliente. |  Obligatorio: Si | Inicio:39 | Tamaño:40 | Tipo: Alfanumerico
        /// </summary>
        public string F201_DESCRIPCION_SUCURSAL
        {
            get { return f201_descripcion_sucursal.PadRight(40, ' '); }
            set { f201_descripcion_sucursal = value; }
        }

        private string f201_id_moneda;
        /// <summary>
        /// 11 | Moneda | Valida en maestro, código de moneda por defecto del cliente. |  Obligatorio: Si | Inicio:79 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_MONEDA
        {
            get { return f201_id_moneda.PadRight(3, ' '); }
            set { f201_id_moneda = value; }
        }

        private string f201_id_vendedor;
        /// <summary>
        /// 12 | Código de vendedor | Valida en maestro, código de vendedor asignado al cliente. |  Obligatorio: No | Inicio:82 | Tamaño:4 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_VENDEDOR
        {
            get { return f201_id_vendedor.PadRight(4, ' '); }
            set { f201_id_vendedor = value; }
        }

        private string f201_ind_calificacion;
        /// <summary>
        /// 13 | Calificación | Campo para calificar al cliente, aquí debe ir 'A', 'B' o 'C'. |  Obligatorio: Si | Inicio:86 | Tamaño:1 | Tipo: Alfanumerico
        /// </summary>
        public string F201_IND_CALIFICACION
        {
            get { return f201_ind_calificacion.PadRight(1, ' '); }
            set { f201_ind_calificacion = value; }
        }

        private string f201_id_cond_pago;
        /// <summary>
        /// 14 | Condición de pago | Valida en maestro, código de condición de pago asignada a este cliente |  Obligatorio: No | Inicio:87 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_COND_PAGO
        {
            get { return f201_id_cond_pago.PadRight(3, ' '); }
            set { f201_id_cond_pago = value; }
        }

        private string f201_dias_gracia;
        /// <summary>
        /// 15 | Días de gracia | Días de gracia otorgados al cliente |  Obligatorio: No | Inicio:90 | Tamaño:3 | Tipo: Numerico
        /// </summary>
        public string F201_DIAS_GRACIA
        {
            get { return f201_dias_gracia.PadLeft(3, '0'); }
            set { f201_dias_gracia = value; }
        }

        private string f201_cupo_credito;
        /// <summary>
        /// 16 | Cupo de crédito | Cupo de crédito otorgado al cliente, el formato debe ser (signo + 15 enteros + punto + 4 decimales) (+000000000000000.0000), se debe dejar en cero si se maneja cliente corporativo. Nota: El máximo valor a importar en el cupo crédito es de 99999999999.9999 |  Obligatorio: No | Inicio:93 | Tamaño:21 | Tipo: Numerico
        /// </summary>
        public string F201_CUPO_CREDITO
        {
            get { return f201_cupo_credito.PadLeft(21, '0'); }
            set { f201_cupo_credito = value; }
        }

        private string f201_id_cliente_corp;
        /// <summary>
        /// 17 | Código del cliente corporativo | Código del cliente, junto con la sucursal debe ser diferentes a f201_id_tercero / f201_id_sucursal |  Obligatorio: No | Inicio:114 | Tamaño:15 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_CLIENTE_CORP
        {
            get { return f201_id_cliente_corp.PadRight(15, ' '); }
            set { f201_id_cliente_corp = value; }
        }

        private string f201_id_sucursal_corp;
        /// <summary>
        /// 18 | Sucursal del cliente corporativo | Sucursal del cliente,  junto con el tercero debe ser diferentes a f201_id_tercero / f201_id_sucursal |  Obligatorio: No | Inicio:129 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_SUCURSAL_CORP
        {
            get { return f201_id_sucursal_corp.PadRight(3, ' '); }
            set { f201_id_sucursal_corp = value; }
        }

        private string f201_id_tipo_cli;
        /// <summary>
        /// 19 | Tipo de cliente | Valida en maestro, tipo de cliente asignado al cliente |  Obligatorio: Si | Inicio:132 | Tamaño:4 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_TIPO_CLI
        {
            get { return f201_id_tipo_cli.PadRight(4, ' '); }
            set { f201_id_tipo_cli = value; }
        }

        private string f201_id_grupo_dscto;
        /// <summary>
        /// 20 | Grupo de descuento | Solo se requiere si tiene el sistema comercial, valida en maestro de grupos de descuento (TR=109) |  Obligatorio: No | Inicio:136 | Tamaño:4 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_GRUPO_DSCTO
        {
            get { return f201_id_grupo_dscto.PadRight(4, ' '); }
            set { f201_id_grupo_dscto = value; }
        }

        private string f201_id_lista_precio;
        /// <summary>
        /// 21 | Lista de precios | Solo se requiere si tiene el sistema comercial, valida en maestro de listas de precios (TR=112) |  Obligatorio: Dep | Inicio:140 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_LISTA_PRECIO
        {
            get { return f201_id_lista_precio.PadRight(3, ' '); }
            set { f201_id_lista_precio = value; }
        }


        private string f201_ind_pedido_backorder;
        /// <summary>
        /// 22 | Indicador de backorder | Solo se requiere si tiene el sistema comercial 
        /// 0=Despachar solo lo disponible y lo demás pendiente
        /// 1=Despachar solo lo disponible y lo demás cancele
        /// 2=Despachar solo líneas completas y lo demás pendiente
        /// 3=Despachar solo líneas completas y lo demás cancele   
        /// 4=Despachar pedido completo                                       
        /// 5=Por linea                                                                  
        /// 6=Facturación diferida 
        /// |  Obligatorio: Dep | Inicio:143 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F201_IND_PEDIDO_BACKORDER
        {
            get { return f201_ind_pedido_backorder.PadLeft(1, '0'); }
            set { f201_ind_pedido_backorder = value; }
        }

        private string f201_porc_exceso_venta;
        /// <summary>
        /// 23 | Porcentaje para poder vender por encima de lo pedido | Solo se requiere si tiene el sistema comercial, porcentaje para poder vender por encima de lo pedido, debe estar entre 0 y 9999, el formato debe ser (4 enteros + punto + 2 decimales) (0000.00) |  Obligatorio: Dep | Inicio:144 | Tamaño:7 | Tipo: Numerico
        /// </summary>
        public string F201_PORC_EXCESO_VENTA
        {
            get { return f201_porc_exceso_venta.PadLeft(7, '0'); }
            set { f201_porc_exceso_venta = value; }
        }

        private string f201_porc_min_margen;
        /// <summary>
        /// 24 | Porcentaje de margen mínimo | Solo se requiere si tiene el sistema comercial, porcentaje de margen mínimo, debe estar entre 0 y 9999, el formato debe ser (4 enteros + punto + 2 decimales) (0000.00) |  Obligatorio: Dep | Inicio:151 | Tamaño:7 | Tipo: Numerico
        /// </summary>
        public string F201_PORC_MIN_MARGEN
        {
            get { return f201_porc_min_margen.PadLeft(7, '0'); }
            set { f201_porc_min_margen = value; }
        }

        private string f201_porc_max_margen;
        /// <summary>
        /// 25 | Porcentaje de margen máximo | Solo se requiere si tiene el sistema comercial, porcentaje de margen máximo debe estar entre porcentaje mínimo y 9999, el formato debe ser (4 enteros + punto + 2 decimales) (0000.00) |  Obligatorio: Dep | Inicio:158 | Tamaño:7 | Tipo: Numerico
        /// </summary>
        public string F201_PORC_MAX_MARGEN
        {
            get { return f201_porc_max_margen.PadLeft(7, '0'); }
            set { f201_porc_max_margen = value; }
        }

        private string f201_ind_bloqueado;
        /// <summary>
        /// 26 | Indicador de bloqueado | Solo se requiere si tiene el sistema comercial, 1=Activo; 0=Bloqueado |  Obligatorio: Dep | Inicio:165 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F201_IND_BLOQUEADO
        {
            get { return f201_ind_bloqueado.PadLeft(1, '0'); }
            set { f201_ind_bloqueado = value; }
        }

        private string f201_ind_bloqueo_cupo;
        /// <summary>
        /// 27 | Indicador de bloquea por cupo | Solo se requiere si tiene el sistema comercial, 0=No, 1=Si |  Obligatorio: Dep | Inicio:166 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F201_IND_BLOQUEO_CUPO
        {
            get { return f201_ind_bloqueo_cupo.PadLeft(1, '0'); }
            set { f201_ind_bloqueo_cupo = value; }
        }

        private string f201_ind_bloqueo_mora;
        /// <summary>
        /// 28 | Indicador de bloquea por mora | Solo se requiere si tiene el sistema comercial, 0=No, 1=Si |  Obligatorio: Dep | Inicio:167 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F201_IND_BLOQUEO_MORA
        {
            get { return f201_ind_bloqueo_mora.PadLeft(1, '0'); }
            set { f201_ind_bloqueo_mora = value; }
        }

        private string f201_ind_factura_unificada;
        /// <summary>
        /// 29 | Indicador de factura unificada | Solo se requiere si tiene el sistema comercial, 0=No, 1=Si |  Obligatorio: Dep | Inicio:168 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F201_IND_FACTURA_UNIFICADA
        {
            get { return f201_ind_factura_unificada.PadLeft(1, '0'); }
            set { f201_ind_factura_unificada = value; }
        }

        private string f201_id_co_factura;
        /// <summary>
        /// 30 | Centro de operación por defecto para facturación | Solo se requiere si tiene el sistema comercial, Valida en maestro de centros de operación (TR=285) |  Obligatorio: No | Inicio:169 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_CO_FACTURA
        {
            get { return f201_id_co_factura.PadRight(3, ' '); }
            set { f201_id_co_factura = value; }
        }

        private string f201_notas;
        /// <summary>
        /// 31 | Observaciones | Observaciones |  Obligatorio: No | Inicio:172 | Tamaño:255 | Tipo: Alfanumerico
        /// </summary>
        public string F201_NOTAS
        {
            get { return f201_notas.PadRight(255, ' '); }
            set { f201_notas = value; }
        }

        private string f015_contacto;
        /// <summary>
        /// 32 | Contacto | Nombre de la persona de contacto |  Obligatorio: No | Inicio:427 | Tamaño:50 | Tipo: Alfanumerico
        /// </summary>
        public string F015_CONTACTO
        {
            get { return f015_contacto.PadRight(50, ' '); }
            set { f015_contacto = value; }
        }

        private string f015_direccion1;
        /// <summary>
        /// 33 | Dirección 1 | Renglón 1 de la dirección del contacto |  Obligatorio: No | Inicio:477 | Tamaño:40 | Tipo: Alfanumerico
        /// </summary>
        public string F015_DIRECCION1
        {
            get { return f015_direccion1.PadRight(40, ' '); }
            set { f015_direccion1 = value; }
        }

        private string f015_direccion2;
        /// <summary>
        /// 34 | Dirección 2 | Renglón 2 de la dirección del contacto |  Obligatorio: No | Inicio:517 | Tamaño:40 | Tipo: Alfanumerico
        /// </summary>
        public string F015_DIRECCION2
        {
            get { return f015_direccion2.PadRight(40, ' '); }
            set { f015_direccion2 = value; }
        }

        private string f015_direccion3;
        /// <summary>
        /// 35 | Dirección 3 | Renglón 3 de la dirección del contacto |  Obligatorio: No | Inicio:557 | Tamaño:40 | Tipo: Alfanumerico
        /// </summary>
        public string F015_DIRECCION3
        {
            get { return f015_direccion3.PadRight(40, ' '); }
            set { f015_direccion3 = value; }
        }

        private string f015_id_pais;
        /// <summary>
        /// 36 | País | Valida en maestro, código del país |  Obligatorio: No | Inicio:597 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F015_ID_PAIS
        {
            get { return f015_id_pais.PadRight(3, ' '); }
            set { f015_id_pais = value; }
        }

        private string f015_id_depto;
        /// <summary>
        /// 37 | Departamento | Valida en maestro, código del departamento, solo se debe usar si existe país |  Obligatorio: Dep | Inicio:600 | Tamaño:2 | Tipo: Alfanumerico
        /// </summary>
        public string F015_ID_DEPTO
        {
            get { return f015_id_depto.PadRight(2, ' '); }
            set { f015_id_depto = value; }
        }

        private string f015_id_ciudad;
        /// <summary>
        /// 38 | Ciudad | Valida en maestro, código de la ciudad, solo se debe usar si existe depto |  Obligatorio: Dep | Inicio:602 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F015_ID_CIUDAD
        {
            get { return f015_id_ciudad.PadRight(3, ' '); }
            set { f015_id_ciudad = value; }
        }

        private string f015_id_barrio;
        /// <summary>
        /// 39 | Barrio | Barrio  |  Obligatorio: No | Inicio:605 | Tamaño:40 | Tipo: Alfanumerico
        /// </summary>
        public string F015_ID_BARRIO
        {
            get { return f015_id_barrio.PadRight(40, ' '); }
            set { f015_id_barrio = value; }
        }

        private string f015_telefono;
        /// <summary>
        /// 40 | Teléfono | Teléfono |  Obligatorio: No | Inicio:645 | Tamaño:20 | Tipo: Alfanumerico
        /// </summary>
        public string F015_TELEFONO
        {
            get { return f015_telefono.PadRight(20, ' '); }
            set { f015_telefono = value; }
        }

        private string f015_fax;
        /// <summary>
        /// 41 | Fax | Fax |  Obligatorio: No | Inicio:665 | Tamaño:20 | Tipo: Alfanumerico
        /// </summary>
        public string F015_FAX
        {
            get { return f015_fax.PadRight(20, ' '); }
            set { f015_fax = value; }
        }

        private string f015_cod_postal;
        /// <summary>
        /// 42 | Código postal | código postal o apartado aéreo |  Obligatorio: No | Inicio:685 | Tamaño:10 | Tipo: Alfanumerico
        /// </summary>
        public string F015_COD_POSTAL
        {
            get { return f015_cod_postal.PadRight(10, ' '); }
            set { f015_cod_postal = value; }
        }

        private string f015_email;
        /// <summary>
        /// 43 | Dirección de correo electrónico | dirección de correo electrónico |  Obligatorio: No | Inicio:695 | Tamaño:50 | Tipo: Alfanumerico
        /// </summary>
        public string F015_EMAIL
        {
            get { return f015_email.PadRight(50, ' '); }
            set { f015_email = value; }
        }

        private string f201_fecha_ingreso;
        /// <summary>
        /// 44 | Fecha de ingreso | Fecha de ingreso AAAAMMDD |  Obligatorio: Si | Inicio:745 | Tamaño:8 | Tipo: Alfanumerico
        /// </summary>
        public string F201_FECHA_INGRESO
        {
            get { return f201_fecha_ingreso.PadRight(8, ' '); }
            set { f201_fecha_ingreso = value; }
        }

        private string f201_id_co_movto_factura;
        /// <summary>
        /// 45 | Centro de operación por defecto para el movimiento de ventas. | Solo se requiere si tiene el sistema comercial, Valida en maestro de centros de operación (TR=285) |  Obligatorio: No | Inicio:753 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_CO_MOVTO_FACTURA
        {
            get { return f201_id_co_movto_factura.PadRight(3, ' '); }
            set { f201_id_co_movto_factura = value; }
        }

        private string f201_id_un_movto_factura;
        /// <summary>
        /// 46 | Unidad de negocios por defecto para el movimiento de ventas. | Solo se requiere si tiene el sistema comercial, Valida en maestro de unidades de negocio (TR=285) |  Obligatorio: No | Inicio:756 | Tamaño:20 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_UN_MOVTO_FACTURA
        {
            get { return f201_id_un_movto_factura.PadRight(20, ' '); }
            set { f201_id_un_movto_factura = value; }
        }

        private string f201_id_parametro_edi;
        /// <summary>
        /// 47 | Parametro EDI | Código del parametro EDI, valida en maestro de parametros EDI. |  Obligatorio: No | Inicio:776 | Tamaño:4 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_PARAMETRO_EDI
        {
            get { return f201_id_parametro_edi.PadRight(4, ' '); }
            set { f201_id_parametro_edi = value; }
        }

        private string f201_codigo_ean;
        /// <summary>
        /// 48 | Código EAN | Código EAN del cliente |  Obligatorio: No | Inicio:780 | Tamaño:35 | Tipo: Alfanumerico
        /// </summary>
        public string F201_CODIGO_EAN
        {
            get { return f201_codigo_ean.PadRight(35, ' '); }
            set { f201_codigo_ean = value; }
        }

        private string f201_fecha_cupo;
        /// <summary>
        /// 49 | Fecha vigencia cupo | Fecha vigencia cupo AAAAMMDD |  Obligatorio: No | Inicio:815 | Tamaño:8 | Tipo: Alfanumerico
        /// </summary>
        public string F201_FECHA_CUPO
        {
            get { return f201_fecha_cupo.PadRight(8, ' '); }
            set { f201_fecha_cupo = value; }
        }

        private string f201_porc_tolerancia;
        /// <summary>
        /// 50 | Porcentaje de tolerancia | Porcentaje de tolerancia el cual permite ampliar el cupo del cliente. Debe estar entre 0 y 100 el formato debe ser (4 enteros + punto + 2 decimales) (0000.00) |  Obligatorio: No | Inicio:823 | Tamaño:7 | Tipo: Numerico
        /// </summary>
        public string F201_PORC_TOLERANCIA
        {
            get { return f201_porc_tolerancia.PadLeft(7, '0'); }
            set { f201_porc_tolerancia = value; }
        }

        private string f201_dia_maximo_factura;
        /// <summary>
        /// 51 | Día máximo para realizar la facturación. | Día máximo para realizar la facturación. |  Obligatorio: No | Inicio:830 | Tamaño:2 | Tipo: Numerico
        /// </summary>
        public string F201_DIA_MAXIMO_FACTURA
        {
            get { return f201_dia_maximo_factura.PadLeft(2, '0'); }
            set { f201_dia_maximo_factura = value; }
        }

        private string f201_id_motivo_bloqueo;
        /// <summary>
        /// 52 | Motivo de bloqueo | Motivo de bloqueo |  Obligatorio: No | Inicio:832 | Tamaño:3 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_MOTIVO_BLOQUEO
        {
            get { return f201_id_motivo_bloqueo.PadRight(3, ' '); }
            set { f201_id_motivo_bloqueo = value; }
        }

        private string f201_id_cobrador;
        /// <summary>
        /// 53 | Código de cobrador | Valida en maestro, código de cobrador asignado al cliente. |  Obligatorio: No | Inicio:835 | Tamaño:4 | Tipo: Alfanumerico
        /// </summary>
        public string F201_ID_COBRADOR
        {
            get { return f201_id_cobrador.PadRight(4, ' '); }
            set { f201_id_cobrador = value; }
        }

        private string f201_ind_compromiso_um_emp;
        /// <summary>
        /// 54 | Indicador para compromiso con unidad de empaque principal | Solo se requiere si tiene el sistema comercial, 0=No, 1=Si |  Obligatorio: No | Inicio:839 | Tamaño:1 | Tipo: Numerico
        /// </summary>
        public string F201_IND_COMPROMISO_UM_EMP
        {
            get { return f201_ind_compromiso_um_emp.PadLeft(1, '0'); }
            set { f201_ind_compromiso_um_emp = value; }
        }

    }
}
