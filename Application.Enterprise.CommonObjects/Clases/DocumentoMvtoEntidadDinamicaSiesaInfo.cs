using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class DocumentoMvtoEntidadDinamicaSiesaInfo
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
        /// 2 | Tipo de registro | Valor fijo = 753 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
        /// </summary>
        public string F_TIPO_REG
        {
            get { return f_tipo_reg.PadLeft(4, '0'); }
            set { f_tipo_reg = value; }
        }

        private string f_subtipo_reg;
        /// <summary>
        /// 3 | Subtipo de registro | Valor fijo = 10 |  Obligatorio: Si | Inicio:12 | Tamaño:2 | Tipo:Numérico
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

        private string f_actualiza_reg;
        /// <summary>
        /// 6 | Adiciona la entidad dinámica al documento. | 0 ò 1= Actualiza la entidad dinamica. 2= Elimina la entidad dinamica |  Obligatorio: Si | Inicio:19 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F_ACTUALIZA_REG
        {
            get { return f_actualiza_reg.PadLeft(1, '0'); }
            set { f_actualiza_reg = value; }
        }

        private string f350_id_co;
        /// <summary>
        /// 7 | Centro de operación | Valida en maestro, código de centro de operación del documento |  Obligatorio: Si | Inicio:20 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F350_ID_CO
        {
            get { return f350_id_co.PadRight(3, ' '); }
            set { f350_id_co = value; }
        }

        private string f350_id_tipo_docto;
        /// <summary>
        /// 8 | Tipo de documento  | Valida en maestro, código de tipo de documento |  Obligatorio: Si | Inicio:23 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F350_ID_TIPO_DOCTO
        {
            get { return f350_id_tipo_docto.PadRight(3, ' '); }
            set { f350_id_tipo_docto = value; }
        }

        private string f350_consec_docto;
        /// <summary>
        /// 9 | Consecutivo de documento  | Numero de documento |  Obligatorio: Si | Inicio:26 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F350_CONSEC_DOCTO
        {
            get { return f350_consec_docto.PadLeft(8, '0'); }
            set { f350_consec_docto = value; }
        }

        private string f350_id_clase_docto;
        /// <summary>
        /// 10 | Clase de documento | Valida en maestro, clase del documento.       
        /// 0=Documento contable (Adicionada para versión 1.14.215)
        /// 30=Importar documento contabla(Adicionada para versión 1.14.215)
        /// 21 =Factura de servicio compra (Adicionada para versión 1.14.718)
        /// 22 = Factura de servicio venta
        /// 24 Nota débito de servicios - compra (Adicionada para versión 1.14.718)
        /// 25 = Nota crédito de servicios - venta
        /// 26 = Factura de servicio desde orden compra (Adicionada para versión 1.14.718)
        /// 27 = Factura de servicio desde orden de venta
        /// 28 = Factura de servicios desde contrato (Adicionada para versión 1.14.718)
        /// 29 = Factura de servicio de reg.fijo compra (Adicionada para versión 1.14.718)
        /// 31 = Factura de servicio, legalizacion gastos (Adicionada para versión 1.14.718)
        /// 40 = Ordenes de compra de servicios-directa (Adicionada para versión 1.14.718)
        /// 41 = Ordenes de compra de servicios-reg.fijo (Adicionada para versión 1.14.718)
        /// 42 = Registros fijos de compra de servicios (Adicionada para versión 1.14.718)
        /// 43 = Ordenes de venta de servicios-directa
        /// 44 = Ordenes de venta de servicios-reg.fijo
        /// 45 = Ordenes de venta de servicios-cotización
        /// 46 = Registros fijos de venta de servicios      
        /// 47 = Cotizaciones de venta de servicios
        /// 48 = Factura de servicio de reg.fijo venta
        /// 701 = Orden de producción directa.                   
        /// 702 = Orden de producción desde MPS/MRP.       
        /// 404 = Orden de compra directa                            
        /// 405 = Orden de compra desde solicitud              
        /// 502 = Pedido de venta directo.                              
        /// 503 = Pedido de venta desde cotización
        /// 408 = Entrada por compra 
        /// 409 = Entrada desde orden de compra                                                                                                                                                415= Facturas de proveedor                                                                                                                                                                          501 = Cotizaciones de venta                                                                                                                                                                                         550 = Planilla de cuadre                                                                                                                                                                                                502 = Pedido de venta directo.                              
        /// 511= Remisión desde pedidos
        /// 512 = Remisión directa.
        /// 514= Remisión no facturable
        /// 519= Remisión desde pedido no facturable
        /// 520 = Factura desde remisión
        /// 522 = Factura directa
        /// 523 = Factura desde pedido
        /// 525 = Nota crédito directa 
        /// 526 = Nota crédito desde factura 
        /// 534 = Nota crédito desde pedido para devolución 
        /// 401 = Solicitudes de compra.        
        /// |  Obligatorio: Si | Inicio:34 | Tamaño:4 | Tipo:Numérico"
        /// </summary>
        public string F350_ID_CLASE_DOCTO
        {
            get { return f350_id_clase_docto.PadLeft(4, '0'); }
            set { f350_id_clase_docto = value; }
        }

        private string f350_rowid_movto;
        /// <summary>
        /// 11 | Rowid del movimiento | Rowid del movimiento, es requerido si las entidades a guardar son de un movimiento de un documento. |  Obligatorio: Dep | Inicio:38 | Tamaño:10 | Tipo:Numérico
        /// </summary>
        public string F350_ROWID_MOVTO
        {
            get { return f350_rowid_movto.PadLeft(10, '0'); }
            set { f350_rowid_movto = value; }
        }

        private string f753_id_grupo_entidad;
        /// <summary>
        /// 12 | Código del grupo entidad | Valida en maestro, código del grupo entidad |  Obligatorio: Si | Inicio:48 | Tamaño:30 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_GRUPO_ENTIDAD
        {
            get { return f753_id_grupo_entidad.PadRight(30, ' '); }
            set { f753_id_grupo_entidad = value; }
        }

        private string f753_id_entidad;
        /// <summary>
        /// 13 | Código de la entidad | Valida en maestro, código de la entidad |  Obligatorio: Si | Inicio:78 | Tamaño:30 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_ENTIDAD
        {
            get { return f753_id_entidad.PadRight(30, ' '); }
            set { f753_id_entidad = value; }
        }

        private string f753_id_atributo;
        /// <summary>
        /// 14 | Código del atriburo | Valida en maestro, código del atributo |  Obligatorio: Si | Inicio:108 | Tamaño:30 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_ATRIBUTO
        {
            get { return f753_id_atributo.PadRight(30, ' '); }
            set { f753_id_atributo = value; }
        }

        private string f753_dato_numerico;
        /// <summary>
        /// 15 | Información númerica para la entidad | Obligatorio si el  tipo de control es Número o Moneda.  formato debe ser 17 enteros + punto + 10 decimales (00000000000000000.0000000000) |  Obligatorio: Dep | Inicio:138 | Tamaño:28 | Tipo:Numérico
        /// </summary>
        public string F753_DATO_NUMERICO
        {
            get { return f753_dato_numerico.PadLeft(28, '0'); }
            set { f753_dato_numerico = value; }
        }

        private string f753_dato_texto;
        /// <summary>
        /// 16 | Información de tipo texto para la entidad | Obligatorio si el  tipo de control es Texto ó Caja de verificación.  En caso de ser caja de verificación se debe colocar la palabra "Si " ó "No". |  Obligatorio: Dep | Inicio:166 | Tamaño:2000 | Tipo:Alfanumérico
        /// </summary>
        public string F753_DATO_TEXTO
        {
            get { return f753_dato_texto.PadRight(2000, ' '); }
            set { f753_dato_texto = value; }
        }

        private string f753_dato_fecha_hora;
        /// <summary>
        /// 17 | Información de tipo fecha para la entidad | Obligatorio si el  tipo de control es Fecha ú Hora.  El formato debe ser AAAAMMDD ó HH:MM (Hora militar). En caso de ser fecha se debe enviar de la siguiente forma ej: 20110715, en caso de ser Hora se debe enviar de la siguiente forma ej: 10:15 si es en el día ó 20:15 si es en la noche. |  Obligatorio: Dep | Inicio:2166 | Tamaño:8 | Tipo:Alfanumérico
        /// </summary>
        public string F753_DATO_FECHA_HORA
        {
            get { return f753_dato_fecha_hora.PadRight(8, ' '); }
            set { f753_dato_fecha_hora = value; }
        }

        private string f753_id_maestro;
        /// <summary>
        /// 18 | Código del maestro | Valida en maestro. Obligatorio si el tipo de control es Maestros Genéricos. |  Obligatorio: Dep | Inicio:2174 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_MAESTRO
        {
            get { return f753_id_maestro.PadRight(10, ' '); }
            set { f753_id_maestro = value; }
        }

        private string f753_id_maestro_detalle;
        /// <summary>
        /// 19 | Detalle del maestro | Valida en maestro. Obligatorio si el tipo de control es Maestros Genéricos. |  Obligatorio: Dep | Inicio:2184 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_MAESTRO_DETALLE
        {
            get { return f753_id_maestro_detalle.PadRight(20, ' '); }
            set { f753_id_maestro_detalle = value; }
        }

        private string f753_id_tipo_entidad;
        /// <summary>
        /// 20 | Tipo de entidad | G203_1 = Cuando se requiere entidades para documento de Factura de servicio ventas (FSV) 
        /// G203_2 = Cuando se requiere entidades para ítems de FSV
        /// G204_1 = Cuando se requiere entidades para documento de Ordenes de venta de servicios (OVS)
        /// G204_2 = Cuando se requiere entidades para ítems de OVS
        /// G205_1 = Cuando se requiere entidades para documento de Cotizaciones de venta de servicios (CVS)
        /// G205_2 = Cuando se requiere entidades para ítems de CVS
        /// G206_1 = Cuando se requiere entidades para documento de Registros fijos de venta de servicios (RFVS)
        /// G206_2 = Cuando se requiere entidades para ítems de RFVS
        /// G304_1 = Cuando se requiere entidades para documentos de compras (FSC)
        /// G304_2 = Cuando se requiere entidades para items FSC
        /// G305_1 = Cuando se requiere entidades para ordenes de compra (OCS)
        /// G305_2 = Cuando se requiere entidades para items OCS
        /// G306_1 = Cuando se requiere entidades para registros fijos de compra (RFCS)
        /// G306_2 = Cuando se requiere entidades para items RFCS
        /// G701_1 = cuando se requiere entidades para documento de ordenes de producción. 
        /// G701_2 = cuando se requiere entidades para ítem OP.                                                                           
        /// G701_3 = cuando se requiere entidades para componentes de ítems OP.                                       
        /// G701_4 = cuando se requiere entidades para operaciones de ítrms OP.                                                                        
        /// G402_1 = cuando se requiere entidades para documento de ordenes de compra.                     
        /// G402_2 = cuando se requiere entidades para items de OC.                                                                                           G404_1 = cuando se requiere entidades para documentos de facturas de proveedor
        /// G502_1 = cuando se requiere entidades para documento de pedidos de venta.                    
        /// G502_2 = cuando se requiere entidades para items de PV.             
        /// G403_1 = cuando se requiere entidades para documento de entradas de almacen - EA.
        /// G403_2 = cuando se requiere entidades para items de entradas de almacen - EA.
        /// G460_1  = cuando se requiere entidades para documento de remisiones y devoluciones de ventas   
        /// G460_2 = cuando se requiere entidades para items de remisiones y devoluciones de ventas      
        /// G501_1 =  cuando se requiere entidades para documento de cotizaciones de venta.   
        /// G501_2 =  cuando se requiere entidades para items de cotizaciones de venta.   
        /// G504_1 =  cuando se requiere entidades para documento de facturas y notas de venta. 
        /// G504_2 = cuando se requiere entidades para items de facturas y notas de venta.   
        /// G505_1 = cuando se requiere entidades para documentos de planilla de cuadre.    
        /// G101_1 = cuando se requiere entidades para documentos contables - DC .     
        /// G101_2 = cuando se requiere entidades para los movimientos del documento contable - DC.   
        /// G401_1 = cuando se requiere entidades para  el documento Solicitudes de compra - SC       
        /// G401_2 = cuando se requiere entidades para los movimientos del documento Solicitudes de compra - SC 
        /// |  Obligatorio: Si | Inicio:2204 | Tamaño:8 | Tipo:Alfanumérico"
        /// </summary>
        public string F753_ID_TIPO_ENTIDAD
        {
            get { return f753_id_tipo_entidad.PadRight(8, ' '); }
            set { f753_id_tipo_entidad = value; }
        }

        private string f753_nro_fila;
        /// <summary>
        /// 21 | Número de fila | Valor fijo cero (0) si la entidad no es captura en grilla.  Si la captura es en grilla numerar los registros correspondientes a los datos de la grilla y poder determinar los datos de un registro de la grilla. |  Obligatorio: Dep | Inicio:2212 | Tamaño:4 | Tipo:Numérico
        /// </summary>
        public string F753_NRO_FILA
        {
            get { return f753_nro_fila.PadLeft(4, '0'); }
            set { f753_nro_fila = value; }
        }

        private string f753_id_maestro_interno;
        /// <summary>
        /// 22 | Código del maestro interno | Valida en maestro, mestro interno, debe de ir uno de estos valores.
        /// T010 = Compañias
        /// T013 = Ciudades
        /// T016 = Bancos
        /// T017 = Monedas
        /// T020 = Familias de documentos
        /// T021 = Tipos de documentos
        /// T025 = Medios de pago
        /// T026 = Cuentas bancarias
        /// T037 = Llaves de impuestos
        /// T040 = Llaves de retenciones
        /// T080 = Tipos de calendario
        /// T101 = Unidades de medida
        /// T102 = Posiciones arancelarias
        /// T107 = Proyectos
        /// T112 = Lista de precios
        /// T113 = Grupos impositivos
        /// T120 = Items
        /// T131 = Codigo de barras
        /// T136 = Portafolio
        /// T149 = Tipos de inventario
        /// T150 = Bodegas
        /// T157 = Instalaciones
        /// T159 = Descuentos de compras
        /// T163 = Vehiculos
        /// T164 = Tipos de vehiculos
        /// T200 = Terceros
        /// T203 = Tipos de identificación
        /// T209 = Clases de proveedor
        /// T225 = Pronto pago
        /// T250 = Plan de cuentas
        /// T253 = Cuentas auxiliares
        /// T273 = Flujo de efectivo mayores
        /// T274 = Flujo de efectivo conceptos
        /// T277 = Tipos de proveedor
        /// T278 = Tipos de cliente
        /// T280 = Regionales
        /// T281 = Unidades de negocio
        /// T284 = Centro Costo
        /// T285 = CO
        /// T403 = Lotes
        /// T417 = Seriales
        /// T5790 = Rutas de visitas |  Obligatorio: No | Inicio:2216 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_MAESTRO_INTERNO
        {
            get { return f753_id_maestro_interno.PadRight(10, ' '); }
            set { f753_id_maestro_interno = value; }
        }

        private string f753_id_maestro_interno_detalle;
        /// <summary>
        /// 23 | Detalle del maestro interno | Valida en maestro. Obligatirio si el tipo de control es Maestros Genéricos. |  Obligatorio: Dep | Inicio:2226 | Tamaño:100 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_MAESTRO_INTERNO_DETALLE
        {
            get { return f753_id_maestro_interno_detalle.PadRight(100, ' '); }
            set { f753_id_maestro_interno_detalle = value; }
        }
    }
}
