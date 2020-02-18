using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Enterprise.CommonObjects
{
    
    public class ClienteTerceroSiesaInfo
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
        /// 2 | Tipo de registro | Valor fijo = 200 |  Obligatorio: Si | Inicio:8 | Tamaño:4 | Tipo:Numérico
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
        /// 6 | Indica si remplaza la información del tercero cuando este ya existe | 0=No, 1=Si |  Obligatorio: Si | Inicio:19 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F_ACTUALIZA_REG
        {
            get { return f_actualiza_reg.PadLeft(1, '0'); }
            set { f_actualiza_reg = value; }
        }

        private string f200_id;
        /// <summary>
        /// 7 | Código del tercero | Código del Tercero |  Obligatorio: Si | Inicio:20 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F200_ID
        {
            get { return f200_id.PadRight(15, ' '); }
            set { f200_id = value; }
        }

        private string f200_nit;
        /// <summary>
        /// 8 | Numero de documento de identificación | Numero de documento de identificación del tercero |  Obligatorio: No | Inicio:35 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F200_NIT
        {
            get { return f200_nit.PadRight(15, ' '); }
            set { f200_nit = value; }
        }

        private string f200_dv_nit;
        /// <summary>
        /// 9 | Digito de verificación del TERC-NIT | Digito de verificación (calculado con modulo 11) |  Obligatorio: No | Inicio:50 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F200_DV_NIT
        {
            get { return f200_dv_nit.PadRight(3, ' '); }
            set { f200_dv_nit = value; }
        }

        private string f200_id_tipo_ident;
        /// <summary>
        /// 10 | Tipo de identificación | Solo se requiere si el tipo de tercero es diferente de '0'. Valida en maestro, Tipo de identificación del tercero |  Obligatorio: Dep | Inicio:53 | Tamaño:1 | Tipo:Alfanumérico
        /// </summary>
        public string F200_ID_TIPO_IDENT
        {
            get { return f200_id_tipo_ident.PadRight(1, ' '); }
            set { f200_id_tipo_ident = value; }
        }

        private string f200_ind_tipo_tercero;
        /// <summary>
        /// 11 | Tipo de tercero | 0' si es sin identificación, '1' si es persona natural, '2' si es persona jurídica. |  Obligatorio: Si | Inicio:54 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F200_IND_TIPO_TERCERO
        {
            get { return f200_ind_tipo_tercero.PadLeft(1, '0'); }
            set { f200_ind_tipo_tercero = value; }
        }

        private string f200_razon_social;
        /// <summary>
        /// 12 | Razón social | Solo se requiere si el tipo de tercero es persona juridica '2'. |  Obligatorio: Dep | Inicio:55 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F200_RAZON_SOCIAL
        {
            get { return f200_razon_social.PadRight(50, ' '); }
            set { f200_razon_social = value; }
        }

        private string f200_apellido1;
        /// <summary>
        /// 13 | Apellido 1 | Solo se requiere si el tercero es persona natural |  Obligatorio: Dep | Inicio:105 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F200_APELLIDO1
        {
            get { return f200_apellido1.PadRight(15, ' '); }
            set { f200_apellido1 = value; }
        }

        private string f200_apellido2;
        /// <summary>
        /// 14 | Apellido 2 | Solo se requiere si el tercero es persona natural |  Obligatorio: Dep | Inicio:120 | Tamaño:15 | Tipo:Alfanumérico
        /// </summary>
        public string F200_APELLIDO2
        {
            get { return f200_apellido2.PadRight(15, ' '); }
            set { f200_apellido2 = value; }
        }

        private string f200_nombres;
        /// <summary>
        /// 15 | Nombres | Solo se requiere si el tercero es persona natural |  Obligatorio: Dep | Inicio:135 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F200_NOMBRES
        {
            get { return f200_nombres.PadRight(20, ' '); }
            set { f200_nombres = value; }
        }

        private string f200_nombre_est;
        /// <summary>
        /// 16 | Nombre del establecimiento | Nombre del establecimiento |  Obligatorio: No | Inicio:155 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F200_NOMBRE_EST
        {
            get { return f200_nombre_est.PadRight(50, ' '); }
            set { f200_nombre_est = value; }
        }

        private string f200_ind_cliente;
        /// <summary>
        /// 17 | Indicador de tercero cliente | 0=No, 1=Si |  Obligatorio: Si | Inicio:205 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F200_IND_CLIENTE
        {
            get { return f200_ind_cliente.PadLeft(1, '0'); }
            set { f200_ind_cliente = value; }
        }

        private string f200_ind_proveedor;
        /// <summary>
        /// 18 | Indicador de tercero proveedor | 0=No, 1=Si |  Obligatorio: Si | Inicio:206 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F200_IND_PROVEEDOR
        {
            get { return f200_ind_proveedor.PadLeft(1, '0'); }
            set { f200_ind_proveedor = value; }
        }

        private string f200_ind_empleado;
        /// <summary>
        /// 19 | Indicador de tercero empleado | 0=No, 1=Si |  Obligatorio: Si | Inicio:207 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F200_IND_EMPLEADO
        {
            get { return f200_ind_empleado.PadLeft(1, '0'); }
            set { f200_ind_empleado = value; }
        }

        private string f200_ind_accionista;
        /// <summary>
        /// 20 | Indicador de tercero accionista | 0=No, 1=Si |  Obligatorio: Si | Inicio:208 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F200_IND_ACCIONISTA
        {
            get { return f200_ind_accionista.PadLeft(1, '0'); }
            set { f200_ind_accionista = value; }
        }

        private string f200_ind_otros;
        /// <summary>
        /// 21 | Indicador de tercero otros | 0=No, 1=Si |  Obligatorio: Si | Inicio:209 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F200_IND_OTROS
        {
            get { return f200_ind_otros.PadLeft(1, '0'); }
            set { f200_ind_otros = value; }
        }

        private string f200_ind_interno;
        /// <summary>
        /// 22 | Indicador de tercero interno | 0=No, 1=Si |  Obligatorio: Si | Inicio:210 | Tamaño:1 | Tipo:Numérico
        /// </summary>
        public string F200_IND_INTERNO
        {
            get { return f200_ind_interno.PadLeft(1, '0'); }
            set { f200_ind_interno = value; }
        }

        private string f015_contacto;
        /// <summary>
        /// 23 | Contacto | Nombre de la persona de contacto |  Obligatorio: No | Inicio:211 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F015_CONTACTO
        {
            get { return f015_contacto.PadRight(50, ' '); }
            set { f015_contacto = value; }
        }

        private string f015_direccion1;
        /// <summary>
        /// 24 | Dirección 1 | Renglón 1 de la dirección del contacto |  Obligatorio: No | Inicio:261 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_DIRECCION1
        {
            get { return f015_direccion1.PadRight(40, ' '); }
            set { f015_direccion1 = value; }
        }

        private string f015_direccion2;
        /// <summary>
        /// 25 | Dirección 2 | Renglón 2 de la dirección del contacto |  Obligatorio: No | Inicio:301 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_DIRECCION2
        {
            get { return f015_direccion2.PadRight(40, ' '); }
            set { f015_direccion2 = value; }
        }

        private string f015_direccion3;
        /// <summary>
        /// 26 | Dirección 3 | Renglón 3 de la dirección del contacto |  Obligatorio: No | Inicio:341 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_DIRECCION3
        {
            get { return f015_direccion3.PadRight(40, ' '); }
            set { f015_direccion3 = value; }
        }

        private string f015_id_pais;
        /// <summary>
        /// 27 | País | Valida en maestro, código del país |  Obligatorio: No | Inicio:381 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_PAIS
        {
            get { return f015_id_pais.PadRight(3, ' '); }
            set { f015_id_pais = value; }
        }

        private string f015_id_depto;
        /// <summary>
        /// 28 | Departamento | Valida en maestro, código del departamento, solo se debe usar si existe país |  Obligatorio: Dep | Inicio:384 | Tamaño:2 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_DEPTO
        {
            get { return f015_id_depto.PadRight(2, ' '); }
            set { f015_id_depto = value; }
        }

        private string f015_id_ciudad;
        /// <summary>
        /// 29 | Ciudad | Valida en maestro, código de la ciudad, solo se debe usar si existe depto |  Obligatorio: Dep | Inicio:386 | Tamaño:3 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_CIUDAD
        {
            get { return f015_id_ciudad.PadRight(3, ' '); }
            set { f015_id_ciudad = value; }
        }

        private string f015_id_barrio;
        /// <summary>
        /// 30 | Barrio | Barrio  |  Obligatorio: No | Inicio:389 | Tamaño:40 | Tipo:Alfanumérico
        /// </summary>
        public string F015_ID_BARRIO
        {
            get { return f015_id_barrio.PadRight(40, ' '); }
            set { f015_id_barrio = value; }
        }

        private string f015_telefono;
        /// <summary>
        /// 31 | Teléfono | Teléfono |  Obligatorio: No | Inicio:429 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F015_TELEFONO
        {
            get { return f015_telefono.PadRight(20, ' '); }
            set { f015_telefono = value; }
        }

        private string f015_fax;
        /// <summary>
        /// 32 | Fax | Fax |  Obligatorio: No | Inicio:449 | Tamaño:20 | Tipo:Alfanumérico
        /// </summary>
        public string F015_FAX
        {
            get { return f015_fax.PadRight(20, ' '); }
            set { f015_fax = value; }
        }

        private string f015_cod_postal;
        /// <summary>
        /// 33 | Código postal | código postal o apartado aéreo |  Obligatorio: No | Inicio:469 | Tamaño:10 | Tipo:Alfanumérico
        /// </summary>
        public string F015_COD_POSTAL
        {
            get { return f015_cod_postal.PadRight(10, ' '); }
            set { f015_cod_postal = value; }
        }

        private string f015_email;
        /// <summary>
        /// 34 | Dirección de correo electrónico | dirección de correo electrónico |  Obligatorio: No | Inicio:479 | Tamaño:50 | Tipo:Alfanumérico
        /// </summary>
        public string F015_EMAIL
        {
            get { return f015_email.PadRight(50, ' '); }
            set { f015_email = value; }
        }

        private string f200_fecha_nacimiento;
        /// <summary>
        /// 35 | Fecha nacimiento | El formato debe ser AAAAMMDD |  Obligatorio: Si | Inicio:529 | Tamaño:8 | Tipo:Alfanumérico
        /// </summary>
        public string F200_FECHA_NACIMIENTO
        {
            get { return f200_fecha_nacimiento.PadRight(8, ' '); }
            set { f200_fecha_nacimiento = value; }
        }

        private string f200_id_ciiu;
        /// <summary>
        /// 36 | Código actividad economica | Valida en maestro, código del actividad económica  |  Obligatorio: No | Inicio:537 | Tamaño:4 | Tipo:Alfanumérico
        /// </summary>
        public string F200_ID_CIIU
        {
            get { return f200_id_ciiu.PadRight(4, ' '); }
            set { f200_id_ciiu = value; }
        }


    }
}
