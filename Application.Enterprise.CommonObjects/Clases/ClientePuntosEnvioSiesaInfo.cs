using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ClientePuntosEnvioSiesaInfo
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
        /// 2 | Tipo de registro | Valor fijo = 215 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
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

        private string f_actualiza_reg;
        /// <summary>
        /// 6 | Indica si remplaza la información del punto de envió cuando este ya existe | 0=No, 1=Si |  Obligatorio: Si | Inicio:19 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F_ACTUALIZA_REG
        {
            get { return f_actualiza_reg.PadLeft(1, '0'); }
            set { f_actualiza_reg = value; }
        }

        private string f215_id_tercero;
        /// <summary>
        /// 7 | Código del cliente | Código del cliente |  Obligatorio: Si | Inicio:20 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F215_ID_TERCERO
        {
            get { return f215_id_tercero.PadRight(15, ' '); }
            set { f215_id_tercero = value; }
        }

        private string f215_id_sucursal;
        /// <summary>
        /// 8 | Sucursal del cliente | Sucursal del cliente |  Obligatorio: Si | Inicio:35 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F215_ID_SUCURSAL
        {
            get { return f215_id_sucursal.PadRight(3, ' '); }
            set { f215_id_sucursal = value; }
        }

        private string f215_id;
        /// <summary>
        /// 9 | Código del punto de envió | Código del punto de envió debe ser diferente de 000 |  Obligatorio: Si | Inicio:38 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F215_ID
        {
            get { return f215_id.PadRight(3, ' '); }
            set { f215_id = value; }
        }

        private string f215_descripcion;
        /// <summary>
        /// 10 | Descripción del punto de envió | Descripción del punto de envió |  Obligatorio: Si | Inicio:41 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F215_DESCRIPCION
        {
            get { return f215_descripcion.PadRight(40, ' '); }
            set { f215_descripcion = value; }
        }

        private string f215_id_vendedor;
        /// <summary>
        /// 11 | Código de vendedor | Valida en maestro, código de vendedor asignado al punto de envió. |  Obligatorio: No | Inicio:81 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F215_ID_VENDEDOR
        {
            get { return f215_id_vendedor.PadRight(4, ' '); }
            set { f215_id_vendedor = value; }
        }

        private string f015_contacto;
        /// <summary>
        /// 12 | Contacto | Nombre de la persona de contacto |  Obligatorio: No | Inicio:85 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F015_CONTACTO
        {
            get { return f015_contacto.PadRight(50, ' '); }
            set { f015_contacto = value; }
        }

        private string f015_direccion1;
        /// <summary>
        /// 13 | Dirección 1 | Renglón 1 de la dirección del contacto |  Obligatorio: No | Inicio:135 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_DIRECCION1
        {
            get { return f015_direccion1.PadRight(40, ' '); }
            set { f015_direccion1 = value; }
        }

        private string f015_direccion2;
        /// <summary>
        /// 14 | Dirección 2 | Renglón 2 de la dirección del contacto |  Obligatorio: No | Inicio:175 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_DIRECCION2
        {
            get { return f015_direccion2.PadRight(40, ' '); }
            set { f015_direccion2 = value; }
        }

        private string f015_direccion3;
        /// <summary>
        /// 15 | Dirección 3 | Renglón 3 de la dirección del contacto |  Obligatorio: No | Inicio:215 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_DIRECCION3
        {
            get { return f015_direccion3.PadRight(40, ' '); }
            set { f015_direccion3 = value; }
        }

        private string f015_id_pais;
        /// <summary>
        /// 16 | País | Valida en maestro, código del país |  Obligatorio: No | Inicio:255 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_PAIS
        {
            get { return f015_id_pais.PadRight(3, ' '); }
            set { f015_id_pais = value; }
        }

        private string f015_id_depto;
        /// <summary>
        /// 17 | Departamento | Valida en maestro, código del departamento, solo se debe usar si existe país |  Obligatorio: Dep | Inicio:258 | Tamaño:2 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_DEPTO
        {
            get { return f015_id_depto.PadRight(2, ' '); }
            set { f015_id_depto = value; }
        }

        private string f015_id_ciudad;
        /// <summary>
        /// 18 | Ciudad | Valida en maestro, código de la ciudad, solo se debe usar si existe depto |  Obligatorio: Dep | Inicio:260 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_CIUDAD
        {
            get { return f015_id_ciudad.PadRight(3, ' '); }
            set { f015_id_ciudad = value; }
        }

        private string f015_id_barrio;
        /// <summary>
        /// 19 | Barrio | Barrio  |  Obligatorio: No | Inicio:263 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_BARRIO
        {
            get { return f015_id_barrio.PadRight(40, ' '); }
            set { f015_id_barrio = value; }
        }

        private string f015_telefono;
        /// <summary>
        /// 20 | Teléfono | Teléfono |  Obligatorio: No | Inicio:303 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F015_TELEFONO
        {
            get { return f015_telefono.PadRight(20, ' '); }
            set { f015_telefono = value; }
        }

        private string f015_fax;
        /// <summary>
        /// 21 | Fax | Fax |  Obligatorio: No | Inicio:323 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F015_FAX
        {
            get { return f015_fax.PadRight(20, ' '); }
            set { f015_fax = value; }
        }

        private string f015_cod_postal;
        /// <summary>
        /// 22 | Código postal | código postal o apartado aéreo |  Obligatorio: No | Inicio:343 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F015_COD_POSTAL
        {
            get { return f015_cod_postal.PadRight(10, ' '); }
            set { f015_cod_postal = value; }
        }

        private string f015_email;
        /// <summary>
        /// 23 | Dirección de correo electrónico | dirección de correo electrónico |  Obligatorio: No | Inicio:353 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F015_EMAIL
        {
            get { return f015_email.PadRight(50, ' '); }
            set { f015_email = value; }
        }

        private string f015_id_parametro_edi;
        /// <summary>
        /// 24 | Parametro EDI | Código del parametro EDI, valida en maestro de parametros EDI. |  Obligatorio: No | Inicio:403 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_PARAMETRO_EDI
        {
            get { return f015_id_parametro_edi.PadRight(4, ' '); }
            set { f015_id_parametro_edi = value; }
        }

        private string f015_codigo_ean;
        /// <summary>
        /// 25 | Código EAN | Código EAN del cliente |  Obligatorio: No | Inicio:407 | Tamaño:35 | Tipo:Alfanumérico
        /// </summary>
        public string F015_CODIGO_EAN
        {
            get { return f015_codigo_ean.PadRight(35, ' '); }
            set { f015_codigo_ean = value; }
        }

    }
}
