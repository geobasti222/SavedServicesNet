using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ClienteImpuestosRetencionesSiesaInfo
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
        /// 2 | Tipo de registro | Impuestos cliente = 46, retención cliente = 47, Impuestos proveedor = 49, retención proveedor = 50, |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
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
        /// 4 | Versión del tipo de registro | Versión = 01 |  Obligatorio: Si | Inicio:14 | Tamaño:2 | Tipo:Numérico
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
        /// 6 | Indica si remplaza la información  cuando esta ya existe | 0=No, 1=Si |  Obligatorio: Si | Inicio:19 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F_ACTUALIZA_REG
        {
            get { return f_actualiza_reg.PadLeft(1, '0'); }
            set { f_actualiza_reg = value; }
        }

        private string f_id_tercero;
        /// <summary>
        /// 7 | Código del cliente / proveedor | Código del cliente / proveedor |  Obligatorio: Si | Inicio:20 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F_ID_TERCERO
        {
            get { return f_id_tercero.PadRight(15, ' '); }
            set { f_id_tercero = value; }
        }

        private string f_id_sucursal;
        /// <summary>
        /// 8 | Sucursal del cliente / proveedor | Sucursal del cliente / proveedor |  Obligatorio: Si | Inicio:35 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F_ID_SUCURSAL
        {
            get { return f_id_sucursal.PadRight(3, ' '); }
            set { f_id_sucursal = value; }
        }

        private string f_id_clase;
        /// <summary>
        /// 9 | Código de la clase de impuesto / retención | Código de la clase de impuesto / retención. Ver anexo 1. |  Obligatorio: Si | Inicio:38 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F_ID_CLASE
        {
            get { return f_id_clase.PadRight(3, ' '); }
            set { f_id_clase = value; }
        }

        private string f_id_valor_tercero;
        /// <summary>
        /// 10 | Configuracion del tercero respecto al impuesto / retención |  Ver anexo 2. |  Obligatorio: Si | Inicio:41 | Tamaño:2 | Tipo:Alfanumérico
        /// </summary>
        public string F_ID_VALOR_TERCERO
        {
            get { return f_id_valor_tercero.PadRight(2, ' '); }
            set { f_id_valor_tercero = value; }
        }

        private string f_id_llave;
        /// <summary>
        /// 11 | Llave de impuesto / retención | Solo si la configuración de la llave lo requiere.  |  Obligatorio: No | Inicio:43 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F_ID_LLAVE
        {
            get { return f_id_llave.PadRight(4, ' '); }
            set { f_id_llave = value; }
        }

    }
}
