using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PedidoSiesaDescuentosInfo
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
        ///2 | Tipo de registro | Valor fijo = 432 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
        /// </summary>
        public string F_TIPO_REG
        {
            get { return f_tipo_reg.PadLeft(4, '0'); }
            set { f_tipo_reg = value; }
        }

        private string f_subtipo_reg;
        /// <summary>
        ///3 | Subtipo de registro | Valor fijo = 00 |  Obligatorio: Si | Inicio:12 | Tamaño:2 | Tipo:Numérico
        /// </summary>
        public string F_SUBTIPO_REG
        {
            get { return f_subtipo_reg.PadLeft(2, '0'); }
            set { f_subtipo_reg = value; }
        }

        private string f_version_reg;
        /// <summary>
        ///4 | Version del tipo de registro | Version = 01 |  Obligatorio: Si | Inicio:14 | Tamaño:2 | Tipo:Numérico
        /// </summary>
        public string F_VERSION_REG
        {
            get { return f_version_reg.PadLeft(2, '0'); }
            set { f_version_reg = value; }
        }

        private string f_cia;
        /// <summary>
        ///5 | Compañía | Valida en maestro, código de la compañía a la cual pertenece la informacion del registro |  Obligatorio: Si | Inicio:16 | Tamaño:3 | Tipo:Numérico
        /// </summary>
        public string F_CIA
        {
            get { return f_cia.PadLeft(3, '0'); }
            set { f_cia = value; }
        }

        private string f430_id_co;
        /// <summary>
        ///6 | Centro de operación | Valida en maestro, código de centro de operación del documento |  Obligatorio: Si | Inicio:19 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_CO
        {
            get { return f430_id_co.PadRight(3, ' '); }
            set { f430_id_co = value; }
        }

        private string f430_id_tipo_docto;
        /// <summary>
        ///7 | Tipo de documento  | Valida en maestro, código de tipo de documento |  Obligatorio: Si | Inicio:22 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_TIPO_DOCTO
        {
            get { return f430_id_tipo_docto.PadRight(3, ' '); }
            set { f430_id_tipo_docto = value; }
        }

        private string f430_consec_docto;
        /// <summary>
        ///8 | Consecutivo de documento  | Numero de documento |  Obligatorio: Si | Inicio:25 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F430_CONSEC_DOCTO
        {
            get { return f430_consec_docto.PadLeft(8, '0'); }
            set { f430_consec_docto = value; }
        }

        private string f431_nro_registro;
        /// <summary>
        ///9 | Numero de registro | Numero de registro del movimiento |  Obligatorio: Si | Inicio:33 | Tamaño:10 | Tipo:Numérico
        /// </summary>
        public string F431_NRO_REGISTRO
        {
            get { return f431_nro_registro.PadLeft(10, '0'); }
            set { f431_nro_registro = value; }
        }

        private string f432_orden;
        /// <summary>
        ///10 | Orden | Orden en que se debe aplicar el descuento, debe ser consecutivo y en un rango de 1 a 9 por cada Tipo de descuento. |  Obligatorio: Si | Inicio:43 | Tamaño:2 | Tipo:Numérico
        /// </summary>
        public string F432_ORDEN
        {
            get { return f432_orden.PadLeft(2, '0'); }
            set { f432_orden = value; }
        }

        private string f432_ind_tipo_dscto;
        /// <summary>
        ///11 | Tipo de descuento | 1=Dscto por Línea. |  Obligatorio: Si | Inicio:45 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F432_IND_TIPO_DSCTO
        {
            get { return f432_ind_tipo_dscto.PadLeft(1, '0'); }
            set { f432_ind_tipo_dscto = value; }
        }

        private string f432_tasa;
        /// <summary>
        ///12 | Tasa | Tasa de descuento, el formato debe ser (3 enteros + punto + 4 decimales) (000.0000), debe ser 0 si f432_vlr_uni > 0 |  Obligatorio: Dep. | Inicio:46 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F432_TASA
        {
            get { return f432_tasa.PadLeft(8, '0'); }
            set { f432_tasa = value; }
        }

        private string f432_vlr_uni;
        /// <summary>
        ///13 | Valor unitario | Valor descuento unitario,  El formato debe ser (15 enteros + punto + 4 decimales). El número de decimales se deben reportar teniendo en cuenta el número de decimales configurados en la moneda (decimales unidades).  (000000000000000.0000).Debe ser 0 si f432_tasa > 0 |  Obligatorio: Dep. | Inicio:54 | Tamaño:20 | Tipo:Numérico"
        /// </summary>
        public string F432_VLR_UNI
        {
            get { return f432_vlr_uni.PadLeft(20, '0'); }
            set { f432_vlr_uni = value; }
        }
    }
}
