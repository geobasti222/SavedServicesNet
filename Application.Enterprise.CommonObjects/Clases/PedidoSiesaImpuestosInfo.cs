using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    /// <summary>
    /// 
    /// </summary>
    
    public class PedidoSiesaImpuestosInfo
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
        ///2 | Tipo de registro | Valor fijo = 433 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
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
        ///6 | Centro de operación del documento | Valida en maestro, código de centro de operación del documento |  Obligatorio: Si | Inicio:19 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_CO
        {
            get { return f430_id_co.PadRight(3, ' '); }
            set { f430_id_co = value; }
        }

        private string f430_id_tipo_docto;
        /// <summary>
        ///7 | Tipo de documento | Valida en maestro, código de tipo de documento |  Obligatorio: Si | Inicio:22 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F430_ID_TIPO_DOCTO
        {
            get { return f430_id_tipo_docto.PadRight(3, ' '); }
            set { f430_id_tipo_docto = value; }
        }

        private string f430_consec_docto;
        /// <summary>
        ///8 | Numero de documento | Numero de documento |  Obligatorio: Si | Inicio:25 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F430_CONSEC_DOCTO
        {
            get { return f430_consec_docto.PadLeft(8, '0'); }
            set { f430_consec_docto = value; }
        }

        private string f430_nro_registro;
        /// <summary>
        ///9 | Numero de registro | Numero de registro del movimiento |  Obligatorio: Si | Inicio:33 | Tamaño:10 | Tipo:Numérico
        /// </summary>
        public string F431_NRO_REGISTRO
        {
            get { return f430_consec_docto.PadLeft(10, '0'); }
            set { f430_consec_docto = value; }
        }

        private string f430_id_llave_impuesto;
        /// <summary>
        ///10 | Llave de impuesto | Valida en maestro, código de llave de impuesto |  Obligatorio: Si | Inicio:43 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F433_ID_LLAVE_IMPUESTO
        {
            get { return f430_id_llave_impuesto.PadRight(4, ' '); }
            set { f430_id_llave_impuesto = value; }
        }

        private string f430_porcentaje_base;
        /// <summary>
        ///11 | Porcentaje base | Porcentaje base para liquidar impuesto, el formato debe ser (3 enteros + punto + 4 decimales) (000.0000), debe ser 0 si F433_vlr_uni > 0 |  Obligatorio: Si | Inicio:47 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F433_PORCENTAJE_BASE
        {
            get { return f430_porcentaje_base.PadLeft(8, '0'); }
            set { f430_porcentaje_base = value; }
        }

        private string f430_tasa;
        /// <summary>
        ///12 | Tasa | Porcentaje para liquidar impuesto, el formato debe ser (3 enteros + punto + 4 decimales) (000.0000), debe ser 0 si F433_vlr_uni > 0 |  Obligatorio: Dep. | Inicio:55 | Tamaño:8 | Tipo:Numérico
        /// </summary>
        public string F433_TASA
        {
            get { return f430_tasa.PadLeft(8, '0'); }
            set { f430_tasa = value; }
        }

        private string f430_vlr_uni;
        /// <summary>
        ///13 | Valor unitario | Valor impuesto unitario en la moneda del documento. El formato debe ser (15 enteros + punto + 4 decimales).(000000000000000.0000).El número de decimales se deben reportar teniendo en cuenta el número de decimales configurados en la moneda (decimales unidades). Debe ser 0 si F433_tasa > 0 |  Obligatorio: Dep. | Inicio:63 | Tamaño:20 | Tipo:Numérico"
        /// </summary>
        public string F433_VLR_UNI
        {
            get { return f430_vlr_uni.PadLeft(20, '0'); }
            set { f430_vlr_uni = value; }
        }

        private string f430_ind_descontable;
        /// <summary>
        ///14 | Indicador de descontable | 0=No, 1=Si |  Obligatorio: Si | Inicio:83 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F433_IND_DESCONTABLE
        {
            get { return f430_ind_descontable.PadLeft(1, '0'); }
            set { f430_ind_descontable = value; }
        }

        private string f430_ind_accion;
        /// <summary>
        ///15 | Indicador de acción | 0=No aplica, 1=Aumenta la CxP, 2=Disminuye la CxP, 3=Aplica, no afecta la CxP y contabiliza, 4=Aplica, no afecta la CxP y no Contabiliza |  Obligatorio: Si | Inicio:84 | Tamaño:1 | Tipo:Numérico"
        /// </summary>
        public string F433_IND_ACCION
        {
            get { return f430_ind_accion.PadLeft(1, '0'); }
            set { f430_ind_accion = value; }
        }

        private string f430_ind_calculo;
        /// <summary>
        ///16 | Indicador de cálculo | 1=Impuesto en Tasa, 2=Impuesto en Valor |  Obligatorio: Si | Inicio:85 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F433_IND_CALCULO
        {
            get { return f430_ind_calculo.PadLeft(1, '0'); }
            set { f430_ind_calculo = value; }
        }

        private string f430_id_llave_impuesto_desc;
        /// <summary>
        ///17 | Llave de impuesto descontable | Si F433_Ind_descontable = 1, Valida en maestro, código de llave de impuesto descontable |  Obligatorio: Dep. | Inicio:86 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F433_ID_LLAVE_IMPUESTO_DESC
        {
            get { return f430_id_llave_impuesto_desc.PadRight(4, ' '); }
            set { f430_id_llave_impuesto_desc = value; }
        }

        private string f430_porcentaje_base_desc;
        /// <summary>
        ///18 | Porcentaje base descontable | Porcentaje para liquidar impuesto descontable, el formato debe ser (3 enteros + punto + 4 decimales).(000.0000).Debe ser > 0 si f433_ind_descontable = 1 |  Obligatorio: Dep. | Inicio:90 | Tamaño:8 | Tipo:Numérico"
        /// </summary>
        public string F433_PORCENTAJE_BASE_DESC
        {
            get { return f430_porcentaje_base_desc.PadLeft(8, '0'); }
            set { f430_porcentaje_base_desc = value; }
        }

        private string f430_tasa_desc;
        /// <summary>
        ///19 | Tasa descontable | Porcentaje de impuesto descontable, el formato debe ser (3 enteros + punto + 4 decimales).(000.0000).Debe ser > 0 si F433_ind_descontable = 1 |  Obligatorio: Dep. | Inicio:98 | Tamaño:8 | Tipo:Numérico"
        /// </summary>
        public string F433_TASA_DESC
        {
            get { return f430_tasa_desc.PadLeft(8, '0'); }
            set { f430_tasa_desc = value; }
        }

        private string f430_porc_imp_valor_desc;
        /// <summary>
        ///20 | Porcentaje Valor unitario descon. | Porcentaje descontable cuando el impuesto es en valor, el formato debe ser (3 enteros + punto + 4 decimales).(000.0000).Debe ser > 0 si F433_ind_descontable = 1 |  Obligatorio: Dep. | Inicio:106 | Tamaño:8 | Tipo:Numérico"
        /// </summary>
        public string F433_PORC_IMP_VALOR_DESC
        {
            get { return f430_porc_imp_valor_desc.PadLeft(8, '0'); }
            set { f430_porc_imp_valor_desc = value; }
        }
    }
}
