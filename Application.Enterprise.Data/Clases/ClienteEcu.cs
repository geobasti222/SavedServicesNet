using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Diagnostics;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ClienteEcu
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandClienteEcu;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ClienteEcu(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ClienteEcu()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        /// <summary>
        ///  Metodo para configurar el comando de la DatabaseFactory
        /// </summary>
        private void Config()
        {
            commandClienteEcu = db.GetStoredProcCommand("PRC_SVDN_CLIENTE_2020");

            db.AddInParameter(commandClienteEcu, "i_operation", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_option", DbType.String);
            //db.AddParameter(commandServicioConfig, "i_nit", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);
            db.AddInParameter(commandClienteEcu, "i_nit", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_zona", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_razonsocial", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_contacto", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_direccion", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_ciudad", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_telefonos", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_fax", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_email", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_plazo_credito", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_cupo_asignado", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_precio_de_venta", DbType.Decimal);
            db.AddInParameter(commandClienteEcu, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandClienteEcu, "i_activo", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_vendedor", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_grancontribuyen", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_retenedorfuente", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_retenedorica", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_cuentacontable", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_localizacion", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_clasificacion", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_persona", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_sector", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_fechanacimiento", DbType.DateTime);
            db.AddInParameter(commandClienteEcu, "i_codciudad", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_categoria", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_sexo", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_cuentacrm", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_tipodocumento", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_apellido1", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_apellido2", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_nombre1", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_nombre2", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_dv", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_simplificado", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_autoretenedor", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_departamento", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_codmediosmagneticos", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_pais", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_desmantelados", DbType.Decimal);
            db.AddInParameter(commandClienteEcu, "i_telefonodos", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_fechaingreso", DbType.DateTime);
            db.AddInParameter(commandClienteEcu, "i_suspender_credito", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_tipotercero", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_barrio", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_codlista", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_fpago", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_facturar", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_celular1", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_celular2", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tid_id", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_direccionresidencia", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_esc_id", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_sec_codsector", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_id_referidor", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_cli_enproduccion", DbType.Boolean);
            db.AddInParameter(commandClienteEcu, "i_str_query", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_bar_codbarrio", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_codigoregional", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_campana", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_iddistribuidor", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_documentodistribuidor", DbType.String);

            db.AddInParameter(commandClienteEcu, "i_codparroquia", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_nomparroquia", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_calles", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_numerocasa", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_comollegar", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_referenciafamiliar", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_telefonoreferenciaf", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_nombrereferidor", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_operadorcelular", DbType.String);
            //db.AddInParameter(commandClienteEcu, "i_id_lider", DbType.String);

            db.AddInParameter(commandClienteEcu, "i_creadopor", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_aprobadoccn", DbType.Boolean);
            db.AddInParameter(commandClienteEcu, "i_comoteenteraste", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_termycond", DbType.Boolean);
            db.AddInParameter(commandClienteEcu, "i_fechaaceptacionterm", DbType.DateTime);
            db.AddInParameter(commandClienteEcu, "i_mostrartermycond", DbType.Boolean);
            db.AddInParameter(commandClienteEcu, "i_tipopedidominimo", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_id_lider", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_idcatalogointeres", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_catalogointeres", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tipoenvio", DbType.Int32);

            db.AddInParameter(commandClienteEcu, "i_codciudaddespacho", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_idtransportista", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_idtipored", DbType.Int32);

            db.AddInParameter(commandClienteEcu, "i_privilegio", DbType.Boolean);
            db.AddInParameter(commandClienteEcu, "i_Solicita_Credito", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_cupo_credito", DbType.Decimal);
            db.AddInParameter(commandClienteEcu, "i_mpago", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_saldo", DbType.Decimal);
            db.AddInParameter(commandClienteEcu, "i_actudatos", DbType.Int32);
            db.AddInParameter(commandClienteEcu, "i_fechactudatos", DbType.DateTime);
            db.AddInParameter(commandClienteEcu, "i_ultimacompra", DbType.DateTime);
            db.AddInParameter(commandClienteEcu, "i_empresaria", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tiempocontacto", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_whatsapp", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tipocliente", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tallaprendasuperior", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tallaprendainferior", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tallacalzado", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_tarjetacd", DbType.String);
            db.AddInParameter(commandClienteEcu, "i_codestado", DbType.String);

            db.AddOutParameter(commandClienteEcu, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandClienteEcu, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Clientes

        /// <summary>
        /// lista todos los Clientes existentes.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> List()
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'A');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// lista un cliente especifico por nit.
        /// </summary>
        /// <returns></returns>
        public ClienteInfo ListxNIT(string nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'B');
            db.SetParameterValue(commandClienteEcu, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                if (dr.Read())
                {
                    m = Factory.GetCliente(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }

        /// <summary>
        /// lista las empresarias con un estado de cliente.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListxEstadosCliente(int EstadoCliente)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'C');
            db.SetParameterValue(commandClienteEcu, "i_esc_id", EstadoCliente);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Realiza el pre-registro de una empresaria
        /// </summary>
        /// <param name="item"></param>
        public bool RegistrarEmpresaria(ClienteInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'I');
                db.SetParameterValue(commandClienteEcu, "i_option", 'A');

                db.SetParameterValue(commandClienteEcu, "i_fechaingreso", item.FechaIngreso);
                db.SetParameterValue(commandClienteEcu, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_celular2", item.Celular2);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandClienteEcu, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_activo", item.Activo);
                db.SetParameterValue(commandClienteEcu, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_pais", item.CodPais);
                db.SetParameterValue(commandClienteEcu, "i_dv", item.DV);
                db.SetParameterValue(commandClienteEcu, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandClienteEcu, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandClienteEcu, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandClienteEcu, "i_documentodistribuidor", item.DocumentoDistribuidor);


                db.SetParameterValue(commandClienteEcu, "i_codparroquia", item.CodigoParroquia);
                db.SetParameterValue(commandClienteEcu, "i_nomparroquia", item.NombreParroquia);
                db.SetParameterValue(commandClienteEcu, "i_calles", item.Calles);
                db.SetParameterValue(commandClienteEcu, "i_numerocasa", item.NumeroCasa);
                db.SetParameterValue(commandClienteEcu, "i_comollegar", item.ComoLlegar);
                db.SetParameterValue(commandClienteEcu, "i_referenciafamiliar", item.ReferenciaFamiliar);
                db.SetParameterValue(commandClienteEcu, "i_telefonoreferenciaf", item.TelefonoReferenciaFamiliar);
                db.SetParameterValue(commandClienteEcu, "i_nombrereferidor", item.NombreReferidor);
                db.SetParameterValue(commandClienteEcu, "i_operadorcelular", item.OperadorCelular);
                //db.SetParameterValue(commandClienteEcu, "i_id_lider", item.Lider);

                //Actualizacion 31/10/2013
                db.SetParameterValue(commandClienteEcu, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandClienteEcu, "i_documentodistribuidor", item.DocumentoDistribuidor);
                db.SetParameterValue(commandClienteEcu, "i_creadopor", item.CreadoPor);

                db.SetParameterValue(commandClienteEcu, "i_comoteenteraste", item.ComoTeEnteraste);

                db.SetParameterValue(commandClienteEcu, "i_termycond", item.TerminosyCondiciones);
                db.SetParameterValue(commandClienteEcu, "i_fechaaceptacionterm", item.FechaAceptacionTerminos);
                db.SetParameterValue(commandClienteEcu, "i_mostrartermycond", item.MostrarTerminosyCondiciones);

                db.SetParameterValue(commandClienteEcu, "i_categoria", item.Categoria);

                db.SetParameterValue(commandClienteEcu, "i_id_lider", item.Lider);

                db.SetParameterValue(commandClienteEcu, "i_tipopedidominimo", item.TipoPedidoMinimo);

                db.SetParameterValue(commandClienteEcu, "i_idcatalogointeres", item.IdCatalogoInteres);
                db.SetParameterValue(commandClienteEcu, "i_catalogointeres", item.CatalogoInteres);

                db.SetParameterValue(commandClienteEcu, "i_tipoenvio", item.TipoEnvio);

                db.SetParameterValue(commandClienteEcu, "i_whatsapp", item.Whatsapp);
                db.SetParameterValue(commandClienteEcu, "i_tipocliente", item.TipoCliente);
                db.SetParameterValue(commandClienteEcu, "i_tallaprendasuperior", item.TallaPrendaSuperior);
                db.SetParameterValue(commandClienteEcu, "i_tallaprendainferior", item.TallaPrendaInferior);
                db.SetParameterValue(commandClienteEcu, "i_tallacalzado", item.TallaCalzado);
                db.SetParameterValue(commandClienteEcu, "i_tarjetacd", item.TarjetaCD);


                dr = db.ExecuteReader(commandClienteEcu);

                okTrans = true;


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro de empresaria: C.C. " + item.Nit + " " + item.RazonSocial + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return okTrans;
        }

        /// <summary>
        /// Realiza la aprobacion de una empresaria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool AprobarEmpresaria(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'A');

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_celular2", item.Celular2);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_bar_codbarrio", item.CodigoBarrio);
                db.SetParameterValue(commandClienteEcu, "i_esc_id", item.IdEstadosCliente);

                db.SetParameterValue(commandClienteEcu, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandClienteEcu, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandClienteEcu, "i_documentodistribuidor", item.DocumentoDistribuidor);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó aprobación de empresaria: C.C. " + item.Nit + " " + (item.Nombre1 + " " + item.Nombre2 + " " + item.Apellido1 + " " + item.Apellido2) + ", se modificó información general y se cambio el estado de PROSPECTO a NUEVA. Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// -Realiza la actualizacion de una empresaria prospecto aprobada por CCN.
        /// </summary>
        /// <param name="item"></param>
        public bool AprobarEmpresariaProspecto(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'L');

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_celular2", item.Celular2);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandClienteEcu, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandClienteEcu, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandClienteEcu, "i_documentodistribuidor", item.DocumentoDistribuidor);

                db.SetParameterValue(commandClienteEcu, "i_codparroquia", item.CodigoParroquia);
                db.SetParameterValue(commandClienteEcu, "i_nomparroquia", item.NombreParroquia);
                db.SetParameterValue(commandClienteEcu, "i_calles", item.Calles);
                db.SetParameterValue(commandClienteEcu, "i_numerocasa", item.NumeroCasa);
                db.SetParameterValue(commandClienteEcu, "i_comollegar", item.ComoLlegar);
                db.SetParameterValue(commandClienteEcu, "i_referenciafamiliar", item.ReferenciaFamiliar);
                db.SetParameterValue(commandClienteEcu, "i_telefonoreferenciaf", item.TelefonoReferenciaFamiliar);
                db.SetParameterValue(commandClienteEcu, "i_nombrereferidor", item.NombreReferidor);
                db.SetParameterValue(commandClienteEcu, "i_operadorcelular", item.OperadorCelular);
                db.SetParameterValue(commandClienteEcu, "i_id_lider", item.Lider);
                db.SetParameterValue(commandClienteEcu, "i_tipoenvio", item.TipoEnvio);

                db.SetParameterValue(commandClienteEcu, "i_aprobadoccn", item.AprobadoCCN);
                db.SetParameterValue(commandClienteEcu, "i_vendedor", item.Vendedor);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualización de información general de empresaria: C.C. " + item.Nit + " " + (item.Nombre1 + " " + item.Nombre2 + " " + item.Apellido1 + " " + item.Apellido2) + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateCliente(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'D');

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_celular2", item.Celular2);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandClienteEcu, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandClienteEcu, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandClienteEcu, "i_documentodistribuidor", item.DocumentoDistribuidor);

                db.SetParameterValue(commandClienteEcu, "i_codparroquia", item.CodigoParroquia);
                db.SetParameterValue(commandClienteEcu, "i_nomparroquia", item.NombreParroquia);
                db.SetParameterValue(commandClienteEcu, "i_calles", item.Calles);
                db.SetParameterValue(commandClienteEcu, "i_numerocasa", item.NumeroCasa);
                db.SetParameterValue(commandClienteEcu, "i_comollegar", item.ComoLlegar);
                db.SetParameterValue(commandClienteEcu, "i_referenciafamiliar", item.ReferenciaFamiliar);
                db.SetParameterValue(commandClienteEcu, "i_telefonoreferenciaf", item.TelefonoReferenciaFamiliar);
                db.SetParameterValue(commandClienteEcu, "i_nombrereferidor", item.NombreReferidor);
                db.SetParameterValue(commandClienteEcu, "i_operadorcelular", item.OperadorCelular);
                db.SetParameterValue(commandClienteEcu, "i_id_lider", item.Lider);
                db.SetParameterValue(commandClienteEcu, "i_tipoenvio", item.TipoEnvio);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualización de información general de empresaria: C.C. " + item.Nit + " " + (item.Nombre1 + " " + item.Nombre2 + " " + item.Apellido1 + " " + item.Apellido2) + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }



        /// <summary>
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateEmpresariaLider(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", "GB");

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_pais", item.CodPais);
                db.SetParameterValue(commandClienteEcu, "i_bar_codbarrio", item.CodigoBarrio);


                db.SetParameterValue(commandClienteEcu, "i_codparroquia", item.CodigoParroquia);
                db.SetParameterValue(commandClienteEcu, "i_nomparroquia", item.NombreParroquia);

                db.SetParameterValue(commandClienteEcu, "i_operadorcelular", item.OperadorCelular);
                //db.SetParameterValue(commandClienteEcu, "i_id_lider", item.Lider);

                //Actualizacion 31/10/2013



                db.SetParameterValue(commandClienteEcu, "i_whatsapp", item.Whatsapp);

                db.SetParameterValue(commandClienteEcu, "i_tallaprendasuperior", item.TallaPrendaSuperior);
                db.SetParameterValue(commandClienteEcu, "i_tallaprendainferior", item.TallaPrendaInferior);
                db.SetParameterValue(commandClienteEcu, "i_tallacalzado", item.TallaCalzado);


                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualización de información general de empresaria: C.C. " + item.Nit + " " + (item.Nombre1 + " " + item.Nombre2 + " " + item.Apellido1 + " " + item.Apellido2) + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }


        /// <summary>
        /// Guarda los datos de un cliente en la tabla de Nivi en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDNivi(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'I');
                db.SetParameterValue(commandClienteEcu, "i_option", 'B');

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandClienteEcu, "i_contacto", item.Contacto);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_fax", item.Fax);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_plazo_credito", item.PlazoCredito);
                db.SetParameterValue(commandClienteEcu, "i_cupo_asignado", item.CupoAsignado);
                db.SetParameterValue(commandClienteEcu, "i_precio_de_venta", item.PrecioVenta);
                db.SetParameterValue(commandClienteEcu, "i_descuento", item.Descuento);
                db.SetParameterValue(commandClienteEcu, "i_activo", item.Activo);
                db.SetParameterValue(commandClienteEcu, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandClienteEcu, "i_grancontribuyen", item.Grancontribuyen);
                db.SetParameterValue(commandClienteEcu, "i_retenedorfuente", item.RetenedorFuente);
                db.SetParameterValue(commandClienteEcu, "i_retenedorica", item.RetenedorIca);
                db.SetParameterValue(commandClienteEcu, "i_cuentacontable", item.CuentaContable);
                db.SetParameterValue(commandClienteEcu, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandClienteEcu, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandClienteEcu, "i_persona", item.Persona);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_categoria", item.Categoria);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_cuentacrm", item.CuentaCRM);
                db.SetParameterValue(commandClienteEcu, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_dv", item.DV);
                db.SetParameterValue(commandClienteEcu, "i_simplificado", item.Simplificado);
                db.SetParameterValue(commandClienteEcu, "i_autoretenedor", item.Autoretenedor);
                db.SetParameterValue(commandClienteEcu, "i_departamento", item.Departamento);
                db.SetParameterValue(commandClienteEcu, "i_codmediosmagneticos", item.CodMediosMagneticos);
                db.SetParameterValue(commandClienteEcu, "i_pais", item.CodPais);
                db.SetParameterValue(commandClienteEcu, "i_desmantelados", item.Desmantelados);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_fechaingreso", DateTime.Now);
                db.SetParameterValue(commandClienteEcu, "i_suspender_credito", item.SuspenderCredito);
                db.SetParameterValue(commandClienteEcu, "i_tipotercero", item.TipoTercero);
                db.SetParameterValue(commandClienteEcu, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codlista", item.CodLista);
                db.SetParameterValue(commandClienteEcu, "i_fpago", item.Fpago);
                db.SetParameterValue(commandClienteEcu, "i_facturar", item.Facturar);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_celular2", item.Celular2);
                db.SetParameterValue(commandClienteEcu, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_id_referidor", item.IdReferidor);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de MKT en produccion para el paso de pedidos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDMkt(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'I');
                db.SetParameterValue(commandClienteEcu, "i_option", 'C');

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandClienteEcu, "i_contacto", item.Contacto);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_fax", item.Fax);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_plazo_credito", item.PlazoCredito);
                db.SetParameterValue(commandClienteEcu, "i_cupo_asignado", item.CupoAsignado);
                db.SetParameterValue(commandClienteEcu, "i_precio_de_venta", item.PrecioVenta);
                db.SetParameterValue(commandClienteEcu, "i_descuento", item.Descuento);
                db.SetParameterValue(commandClienteEcu, "i_activo", item.Activo);
                db.SetParameterValue(commandClienteEcu, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandClienteEcu, "i_grancontribuyen", item.Grancontribuyen);
                db.SetParameterValue(commandClienteEcu, "i_retenedorfuente", item.RetenedorFuente);
                db.SetParameterValue(commandClienteEcu, "i_retenedorica", item.RetenedorIca);
                db.SetParameterValue(commandClienteEcu, "i_cuentacontable", item.CuentaContable);
                db.SetParameterValue(commandClienteEcu, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandClienteEcu, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandClienteEcu, "i_persona", item.Persona);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_categoria", item.Categoria);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_cuentacrm", item.CuentaCRM);
                db.SetParameterValue(commandClienteEcu, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_dv", item.DV);
                db.SetParameterValue(commandClienteEcu, "i_simplificado", item.Simplificado);
                db.SetParameterValue(commandClienteEcu, "i_autoretenedor", item.Autoretenedor);
                db.SetParameterValue(commandClienteEcu, "i_departamento", item.Departamento);
                db.SetParameterValue(commandClienteEcu, "i_codmediosmagneticos", item.CodMediosMagneticos);
                db.SetParameterValue(commandClienteEcu, "i_pais", item.CodPais);
                db.SetParameterValue(commandClienteEcu, "i_desmantelados", item.Desmantelados);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_fechaingreso", item.FechaIngreso);
                db.SetParameterValue(commandClienteEcu, "i_suspender_credito", item.SuspenderCredito);
                db.SetParameterValue(commandClienteEcu, "i_tipotercero", item.TipoTercero);
                db.SetParameterValue(commandClienteEcu, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codlista", item.CodLista);
                db.SetParameterValue(commandClienteEcu, "i_fpago", item.Fpago);
                db.SetParameterValue(commandClienteEcu, "i_facturar", item.Facturar);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_celular2", item.Celular2);
                db.SetParameterValue(commandClienteEcu, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_id_referidor", item.IdReferidor);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// Guarda los datos de un cliente en la tabla de SVDN para iniciar el procesamiento.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool InsertClienteBDSVDN(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'I');
                db.SetParameterValue(commandClienteEcu, "i_option", 'D');

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandClienteEcu, "i_contacto", item.Contacto);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandClienteEcu, "i_fax", item.Fax);
                db.SetParameterValue(commandClienteEcu, "i_email", item.Email);
                db.SetParameterValue(commandClienteEcu, "i_plazo_credito", item.PlazoCredito);
                db.SetParameterValue(commandClienteEcu, "i_cupo_asignado", item.CupoAsignado);
                db.SetParameterValue(commandClienteEcu, "i_precio_de_venta", item.PrecioVenta);
                db.SetParameterValue(commandClienteEcu, "i_descuento", item.Descuento);
                db.SetParameterValue(commandClienteEcu, "i_activo", item.Activo);
                db.SetParameterValue(commandClienteEcu, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandClienteEcu, "i_grancontribuyen", item.Grancontribuyen);
                db.SetParameterValue(commandClienteEcu, "i_retenedorfuente", item.RetenedorFuente);
                db.SetParameterValue(commandClienteEcu, "i_retenedorica", item.RetenedorIca);
                db.SetParameterValue(commandClienteEcu, "i_cuentacontable", item.CuentaContable);
                db.SetParameterValue(commandClienteEcu, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandClienteEcu, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandClienteEcu, "i_persona", item.Persona);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandClienteEcu, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandClienteEcu, "i_categoria", item.Categoria);
                db.SetParameterValue(commandClienteEcu, "i_sexo", item.Sexo);
                db.SetParameterValue(commandClienteEcu, "i_cuentacrm", item.CuentaCRM);
                db.SetParameterValue(commandClienteEcu, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandClienteEcu, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandClienteEcu, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandClienteEcu, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandClienteEcu, "i_dv", item.DV);
                db.SetParameterValue(commandClienteEcu, "i_simplificado", item.Simplificado);
                db.SetParameterValue(commandClienteEcu, "i_autoretenedor", item.Autoretenedor);
                db.SetParameterValue(commandClienteEcu, "i_departamento", item.Departamento);
                db.SetParameterValue(commandClienteEcu, "i_codmediosmagneticos", item.CodMediosMagneticos);
                db.SetParameterValue(commandClienteEcu, "i_pais", item.CodPais);
                db.SetParameterValue(commandClienteEcu, "i_desmantelados", item.Desmantelados);
                db.SetParameterValue(commandClienteEcu, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandClienteEcu, "i_fechaingreso", DateTime.Now);
                db.SetParameterValue(commandClienteEcu, "i_suspender_credito", item.SuspenderCredito);
                db.SetParameterValue(commandClienteEcu, "i_tipotercero", item.TipoTercero);
                //db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandClienteEcu, "i_codlista", item.CodLista);
                db.SetParameterValue(commandClienteEcu, "i_fpago", item.Fpago);
                db.SetParameterValue(commandClienteEcu, "i_facturar", item.Facturar);
                db.SetParameterValue(commandClienteEcu, "i_celular1", item.Celular1);
                db.SetParameterValue(commandClienteEcu, "i_celular2", item.Celular2);
                db.SetParameterValue(commandClienteEcu, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandClienteEcu, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandClienteEcu, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandClienteEcu, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandClienteEcu, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandClienteEcu, "i_cli_enproduccion", item.EnProduccion);
                db.SetParameterValue(commandClienteEcu, "i_bar_codbarrio", item.CodigoBarrio);


                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// Realiza la actualizacion de direccion y telefono de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        public bool ActualizarDireccionTelefono(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'B');

                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandClienteEcu, "i_telefonos", item.Telefono1);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

                //Se pregunta si se debe guardar la auditoria.
                if (item.GuardarAuditoria)
                {
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //Guardar auditoria 
                    try
                    {
                        Auditoria objAuditoria = new Auditoria("conexion");
                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                        objAuditoriaInfo.Usuario = item.Usuario;
                        objAuditoriaInfo.Proceso = "Se realizó actualización de dirección y telefono de empresaria: C.C. " + item.Nit + " Dirección: " + item.DireccionPedidos + " Telefono: " + item.Telefono1 + ". Acción Realizada por el Usuario: " + item.Usuario;

                        objAuditoria.Insert(objAuditoriaInfo);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                    }
                    //-----------------------------------------------------------------------------------------------------------------------------
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// Realiza la actualizacion del estado de migracion del cliente a produccion en la BD de Nivi y MKT.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        public bool UpdateClienteEnProduccion(string Nit, bool EnProduccion)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'C');
                db.SetParameterValue(commandClienteEcu, "i_nit", Nit);
                db.SetParameterValue(commandClienteEcu, "i_cli_enproduccion", EnProduccion);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// Realiza la actualizacion de la zona de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool UpdateZona(string Nit, string Zona)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'E');
                db.SetParameterValue(commandClienteEcu, "i_nit", Nit);
                db.SetParameterValue(commandClienteEcu, "i_zona", Zona);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = "Comercial";
                    objAuditoriaInfo.Proceso = "Se realizó actualización de zona de empresaria: C.C. " + Nit + " a la Zona: " + Zona + ". Acción Realizada por el Usuario: " + "Comercial";

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }


        /// <summary>
        /// Realiza la actualizacion del estado de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoCliente"></param>
        /// <returns></returns>
        public bool UpdateEstadoCliente(string Nit, int EstadoCliente)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'F');
                db.SetParameterValue(commandClienteEcu, "i_nit", Nit);
                db.SetParameterValue(commandClienteEcu, "i_esc_id", EstadoCliente);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }


        /// <summary>
        /// Realiza la actualizacion de la red de una empresaria inactiva a posible reingreso.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateEstadoClienteCambioZona(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandClienteEcu, "i_operation", 'U');
                db.SetParameterValue(commandClienteEcu, "i_option", 'M');
                db.SetParameterValue(commandClienteEcu, "i_nit", item.Nit);
                db.SetParameterValue(commandClienteEcu, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandClienteEcu, "i_zona", item.Zona);
                db.SetParameterValue(commandClienteEcu, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandClienteEcu, "i_id_lider", item.Lider);
                db.SetParameterValue(commandClienteEcu, "i_categoria", item.Categoria);

                dr = db.ExecuteReader(commandClienteEcu);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return transOk;
        }

        /// <summary>
        /// lista todas las empresarias.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListTodasEmpresarias()
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'E');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// lista un cliente especifico por nit para un encabezado de pedido.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITxEncabezadoPedido(string nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'F');
            db.SetParameterValue(commandClienteEcu, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                if (dr.Read())
                {
                    m = Factory.GetClientexEncabezadoPedido(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }


        /// <summary>
        /// lista las empresarias de una gerente de zona.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerente(string IdVendedor)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'G');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista la direccion y telefono principal de una empresaria.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListTelefonoDireccionxNIT(string nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'H');
            db.SetParameterValue(commandClienteEcu, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                if (dr.Read())
                {
                    m = Factory.GetTelefonoDireccionxNIT(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }

        /// <summary>
        /// lista todos los Clientes de SVDN existentes.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListClientesSVDN()
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'I');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientesSVDN(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// lista un Cliente de nivi especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteNivixNit(string Nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'J');
            db.SetParameterValue(commandClienteEcu, "i_nit", Nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientesNivi(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }


        /// <summary>
        /// lista un Cliente de SVDN especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteSVDNxNit(string Nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'O');
            db.SetParameterValue(commandClienteEcu, "i_nit", Nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientesNivi(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }

        /// <summary>
        /// lista un Cliente de MKT especifico por nit.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteMktxNit(string Nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'K');
            db.SetParameterValue(commandClienteEcu, "i_nit", Nit);



            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientesMkt(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }

        /// <summary>
        /// Lista los clientes de una zona especifica.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxZona(string IdZona)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'L');
            db.SetParameterValue(commandClienteEcu, "i_zona", IdZona);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientesNivi(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimple(string nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'M');
            db.SetParameterValue(commandClienteEcu, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                if (dr.Read())
                {
                    m = Factory.GetCliente(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }


        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteSimple(string IdVendedor)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'N');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerentexEstado(string IdVendedor, int EstadoCliente)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "EG");
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_esc_id", EstadoCliente);


            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        ///Lista las empresarias de una gerente de zona simple.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasActivasxGerenteSimple(string IdVendedor)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "EF");
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista las empresarias de una gerente regional
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteRegional(string CodigoRegional)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'P');
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// listado de clientes de bienvenida.
        /// </summary>
        /// <param name="FechaIngreso"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListClienteBienvenida(DateTime FechaIngreso)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'Q');
            db.SetParameterValue(commandClienteEcu, "i_fechaingreso", FechaIngreso);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientesBienvenida(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// Lista la consecutividad de campañas de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<string> ListConsecutividadCliente(string Nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'R');
            db.SetParameterValue(commandClienteEcu, "i_nit", Nit);

            List<string> col = new List<string>();

            IDataReader dr = null;

            string m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetCampanasConsecutividad(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista el listado de clientes por estado egreso.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoEgreso(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'S');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// Lista el listado de clientes por estado Nuevas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoNuevas(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'T');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresos(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'U');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista los clientes con estado prospecto
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListClientesProspecto()
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'V');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientesNivi(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista el listado de clientes por estado Activas.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoActivas(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'W');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }



        /// <summary>
        /// Lista el listado de clientes por estado egreso para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoEgresoRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'X');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista el listado de clientes por estado nuevas para regionales.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoNuevasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'Y');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// Lista el listado de clientes por estado Posibles Egresos para gerente regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoPosiblesEgresosRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'Z');
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// Lista el listado de clientes por estado Activas para regional.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxEstadoActivasRegionales(string IdVendedor, string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "AA");
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandClienteEcu, "i_zona", Zona);
            db.SetParameterValue(commandClienteEcu, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandClienteEcu, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista todos los nit y estados de las empresarias que no hayan generado pedido en la campaña anterior a la actual
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariaSinPedido()
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "AB");

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetEmpresariaPedido(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        public List<ClienteInfo> ListInformacionEmpresarias(string cedula)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "AC");
            db.SetParameterValue(commandClienteEcu, "i_nit", cedula);
            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetCliente(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimpleEdit(string nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "AD");
            db.SetParameterValue(commandClienteEcu, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                if (dr.Read())
                {
                    m = Factory.GetClienteEditar(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }


        /// <summary>
        ///Lista las empresarias de una gerente de zona simple edit.
        /// </summary>
        /// <param name="IdVendedor">Id del gerente de zona.</param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteSimpleEdit(string IdVendedor)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "AE");
            db.SetParameterValue(commandClienteEcu, "i_vendedor", IdVendedor);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteEdit(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }


        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLider(string IdLider)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "AH");
            db.SetParameterValue(commandClienteEcu, "i_id_lider", IdLider);
       

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteEdit(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <param name="CodEstado"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLiderEstado(string IdLider, int EstadoCliente)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "EH");
            db.SetParameterValue(commandClienteEcu, "i_id_lider", IdLider);
            db.SetParameterValue(commandClienteEcu, "i_esc_id", EstadoCliente);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteEdit(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }

        /// <summary>
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <param name="CodEstado"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLiderActivas(string IdLider)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "EE");
            db.SetParameterValue(commandClienteEcu, "i_id_lider", IdLider);


            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteEdit(dr);

                    col.Add(m);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return col;
        }



        /// <summary>
        /// Lista el estado de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListEstadoxNit(string Nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "EA");
            db.SetParameterValue(commandClienteEcu, "i_nit", Nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosCliente(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }



        /// <summary>
        /// Lista el estado de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ConsultaClienteNit(string Nit)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "GB");
            db.SetParameterValue(commandClienteEcu, "i_nit", Nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    m = Factory.GetClienteActualizacion(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }



        #endregion

        #region Metodos del Buscador

        /// <summary>
        /// Mapea los campos de consulta de la base de datos a nombres 
        /// entendibles por el usuario y asociados a la aplicaciòn
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public TableMapping SearchMapping(string language)
        {
            TableMapping searchMapping = new TableMapping("PRC_SVDN_CLIENTE", "Application.Enterprise.CommonObjects.ClienteInfo");

            searchMapping.Fields.Add(new FieldMapping("nit", DbType.String, "identificacion", "103"));
            searchMapping.Fields.Add(new FieldMapping("razon_social", DbType.String, "nombre", "103"));
            searchMapping.Fields.Add(new FieldMapping("ciudad", DbType.String, "Ciudad", "103"));

            return searchMapping;
        }

        /// <summary>
        /// Buscador de Clientes.
        /// </summary>
        /// <param Name="filter">parametros de filtro para la busqueda.</param>
        /// <returns>Lista de Clientes.</returns>
        public List<ClienteInfo> ListSearch(string lstItem)
        {
            List<ClienteInfo> res = new List<ClienteInfo>();
            ClienteInfo item = null;
            IDataReader dr = null;

            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", 'D');
            db.SetParameterValue(commandClienteEcu, "i_str_query", lstItem);

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                while (dr.Read())
                {
                    item = Factory.GetClientexSearch(dr);

                    res.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return res;
        }

        /// <summary>
        /// Lista si una empresaria corresponde a un lider.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="idlider"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITxLider(string nit, string idlider)
        {
            db.SetParameterValue(commandClienteEcu, "i_operation", 'S');
            db.SetParameterValue(commandClienteEcu, "i_option", "AG");
            db.SetParameterValue(commandClienteEcu, "i_nit", nit);
            db.SetParameterValue(commandClienteEcu, "i_id_lider", idlider);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClienteEcu);

                if (dr.Read())
                {
                    m = Factory.GetClienteEditar(dr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return m;
        }


        #endregion
    }
}