using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ClienteEntidadDinamicaSiesaInfo
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
        /// 3 | Subtipo de registro | Valor fijo = 08 |  Obligatorio: Si | Inicio:12 | Tamaño:2 | Tipo:Numérico
        /// </summary>
        public string F_SUBTIPO_REG
        {
            get { return f_subtipo_reg.PadLeft(2, '0'); }
            set { f_subtipo_reg = value; }
        }

        private string f_version_reg;
        /// <summary>
        /// 4 | Versión del tipo de registro | Versión = 03 |  Obligatorio: Si | Inicio:14 | Tamaño:2 | Tipo:Numérico
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
        /// 6 | Indica si remplaza la información de la entidad dinámica  cuando este ya exista en el maestro.. | 0= No;  1 = Si |  Obligatorio: Si | Inicio:19 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F_ACTUALIZA_REG
        {
            get { return f_actualiza_reg.PadLeft(1, '0'); }
            set { f_actualiza_reg = value; }
        }

        private string f201_id_tercero;
        /// <summary>
        /// 7 | ID del tercero | Valida en maestro, código del tercero cliente |  Obligatorio: Si | Inicio:20 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F201_ID_TERCERO
        {
            get { return f201_id_tercero.PadRight(15, ' '); }
            set { f201_id_tercero = value; }
        }

        private string f201_id_sucursal;
        /// <summary>
        /// 8 | ID sucursal | Valida en maestro, código de la sucursal del tercero |  Obligatorio: Si | Inicio:35 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F201_ID_SUCURSAL
        {
            get { return f201_id_sucursal.PadRight(3, ' '); }
            set { f201_id_sucursal = value; }
        }

        private string espacioenblanco;
        /// <summary>
        /// 9 | Espacio reservado para futuras implementaciones | Espacio reservado para futuras implementaciones |  Obligatorio: No | Inicio:38 | Tamaño:182 | Tipo:Alfanumérico
        /// </summary>
        public string ESPACIOENBLANCO
        {
            get { return espacioenblanco.PadRight(182, ' '); }
            set { espacioenblanco = value; }
        }

        private string f753_id_grupo_entidad;
        /// <summary>
        /// 10 | Código del grupo entidad | Valida en maestro, código del grupo entidad |  Obligatorio: Si | Inicio:220 | Tamaño:30 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_GRUPO_ENTIDAD
        {
            get { return f753_id_grupo_entidad.PadRight(30, ' '); }
            set { f753_id_grupo_entidad = value; }
        }

        private string f753_id_entidad;
        /// <summary>
        /// 11 | Código de la entidad | Valida en maestro, código de la entidad |  Obligatorio: Si | Inicio:250 | Tamaño:30 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_ENTIDAD
        {
            get { return f753_id_entidad.PadRight(30, ' '); }
            set { f753_id_entidad = value; }
        }

        private string f753_id_atributo;
        /// <summary>
        /// 12 | Código del atriburo | Valida en maestro, código del atributo |  Obligatorio: Si | Inicio:280 | Tamaño:30 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_ATRIBUTO
        {
            get { return f753_id_atributo.PadRight(30, ' '); }
            set { f753_id_atributo = value; }
        }

        private string f753_dato_numerico;
        /// <summary>
        /// 13 | Información númerica para la entidad | Obligatorio si el  tipo de control es Número o Moneda.  formato debe ser 17 enteros + punto + 10 decimales (00000000000000000.0000000000) |  Obligatorio: Dep | Inicio:310 | Tamaño:28 | Tipo:Numérico
        /// </summary>
        public string F753_DATO_NUMERICO
        {
            get { return f753_dato_numerico.PadRight(28, ' '); }
            set { f753_dato_numerico = value; }
        }

        private string f753_dato_texto;
        /// <summary>
        /// 14 | Información de tipo texto para la entidad | Obligatorio si el  tipo de control es Texto ó Caja de verificación.  En caso de ser caja de verificación se debe colocar la palabra "Si " ó "No". |  Obligatorio: Dep | Inicio:338 | Tamaño:2000 | Tipo:Alfanumérico
        /// </summary>
        public string F753_DATO_TEXTO
        {
            get { return f753_dato_texto.PadRight(2000, ' '); }
            set { f753_dato_texto = value; }
        }

        private string f753_dato_fecha_hora;
        /// <summary>
        /// 15 | Información de tipo fecha para la entidad | Obligatorio si el  tipo de control es Fecha ú Hora.  El formato debe ser AAAAMMDD ó HH:MM (Hora militar). En caso de ser fecha se debe enviar de la siguiente forma ej: 20110715, en caso de ser Hora se debe enviar de la siguiente forma ej: 10:15 si es en el día ó 20:15 si es en la noche. |  Obligatorio: Dep | Inicio:2338 | Tamaño:8 | Tipo:Alfanumérico
        /// </summary>
        public string F753_DATO_FECHA_HORA
        {
            get { return f753_dato_fecha_hora.PadRight(8, ' '); }
            set { f753_dato_fecha_hora = value; }
        }

        private string f753_id_maestro;
        /// <summary>
        /// 16 | Código del maestro | Valida en maestro.  Obligatirio si el tipo de control es Maestros Genéricos. |  Obligatorio: Dep | Inicio:2346 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_MAESTRO
        {
            get { return f753_id_maestro.PadRight(10, ' '); }
            set { f753_id_maestro = value; }
        }

        private string f753_id_maestro_detalle;
        /// <summary>
        /// 17 | Detalle del maestro | Valida en maestro. Obligatirio si el tipo de control es Maestros Genéricos. |  Obligatorio: Dep | Inicio:2356 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_MAESTRO_DETALLE
        {
            get { return f753_id_maestro_detalle.PadRight(20, ' '); }
            set { f753_id_maestro_detalle = value; }
        }

        private string f753_id_tipo_entidad;
        /// <summary>
        /// 18 | Tipo de entidad | Valor fijo: M201 |  Obligatorio: Si | Inicio:2376 | Tamaño:8 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_TIPO_ENTIDAD
        {
            get { return f753_id_tipo_entidad.PadRight(8, ' '); }
            set { f753_id_tipo_entidad = value; }
        }

        private string f753_nro_fila;
        /// <summary>
        /// 19 | Número de fila | Valor fijo cero (0) si la entidad no es captura en grilla.  Si la captura es en grilla numerar los resgistros correspondientes a los datos de la grilla y poder determinar los datos de un registro de la grilla. |  Obligatorio: Dep | Inicio:2384 | Tamaño:4 | Tipo:Numérico
        /// </summary>
        public string F753_NRO_FILA
        {
            get { return f753_nro_fila.PadLeft(4, '0'); }
            set { f753_nro_fila = value; }
        }

        private string f753_id_maestro_interno;
        /// <summary>
        /// "20 | Código del maestro interno | Valida en maestro, mestro interno, debe de ir uno de estos valores.
        ///T010 = Compañias
        ///T013 = Ciudades
        ///T016 = Bancos
        ///T017 = Monedas
        ///T020 = Familias de documentos
        ///T021 = Tipos de documentos
        ///T025 = Medios de pago
        ///T026 = Cuentas bancarias
        ///T037 = Llaves de impuestos
        ///T040 = Llaves de retenciones
        ///T080 = Tipos de calendario
        ///T101 = Unidades de medida
        ///T102 = Posiciones arancelarias
        ///T107 = Proyectos
        ///T112 = Lista de precios
        ///T113 = Grupos impositivos
        ///T120 = Items
        ///T131 = Codigo de barras
        ///T136 = Portafolio
        ///T149 = Tipos de inventario
        ///T150 = Bodegas
        ///T157 = Instalaciones
        ///T159 = Descuentos de compras
        ///T163 = Vehiculos
        ///T164 = Tipos de vehiculos
        ///T200 = Terceros
        ///T203 = Tipos de identificación
        ///T209 = Clases de proveedor
        ///T225 = Pronto pago
        ///T250 = Plan de cuentas
        ///T253 = Cuentas auxiliares
        ///T273 = Flujo de efectivo mayores
        ///T274 = Flujo de efectivo conceptos
        ///T277 = Tipos de proveedor
        ///T278 = Tipos de cliente
        ///T280 = Regionales
        ///T281 = Unidades de negocio
        ///T284 = Centro Costo
        ///T285 = CO
        ///T403 = Lotes
        ///T417 = Seriales
        ///T5790 = Rutas de visitas |  Obligatorio: No | Inicio:2388 | Tamaño:10 | Tipo:Alfanumérico"
        /// </summary>
        public string F753_ID_MAESTRO_INTERNO
        {
            get { return f753_id_maestro_interno.PadRight(10, ' '); }
            set { f753_id_maestro_interno = value; }
        }

        private string f753_id_maestro_interno_detalle;
        /// <summary>
        /// 21 | Detalle del maestro interno | Valida en maestro. Obligatirio si el tipo de control es Maestros Genéricos. |  Obligatorio: Dep | Inicio:2398 | Tamaño:100 | Tipo:Alfanumérico
        /// </summary>
        public string F753_ID_MAESTRO_INTERNO_DETALLE
        {
            get { return f753_id_maestro_interno_detalle.PadRight(100, ' '); }
            set { f753_id_maestro_interno_detalle = value; }
        }

    }
}
