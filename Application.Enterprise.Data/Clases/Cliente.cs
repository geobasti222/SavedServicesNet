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
    public class Cliente
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCliente;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Cliente(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Cliente()
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
            commandCliente = db.GetStoredProcCommand("PRC_SVDN_CLIENTE_2020");

            db.AddInParameter(commandCliente, "i_operation", DbType.String);
            db.AddInParameter(commandCliente, "i_option", DbType.String);
            //db.AddParameter(commandServicioConfig, "i_nit", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);
            db.AddInParameter(commandCliente, "i_nit", DbType.String);
            db.AddInParameter(commandCliente, "i_zona", DbType.String);
            db.AddInParameter(commandCliente, "i_razonsocial", DbType.String);
            db.AddInParameter(commandCliente, "i_contacto", DbType.String);
            db.AddInParameter(commandCliente, "i_direccion", DbType.String);
            db.AddInParameter(commandCliente, "i_ciudad", DbType.String);
            db.AddInParameter(commandCliente, "i_telefonos", DbType.String);
            db.AddInParameter(commandCliente, "i_fax", DbType.String);
            db.AddInParameter(commandCliente, "i_email", DbType.String);
            db.AddInParameter(commandCliente, "i_plazo_credito", DbType.Int32);
            db.AddInParameter(commandCliente, "i_cupo_asignado", DbType.Int32);
            db.AddInParameter(commandCliente, "i_precio_de_venta", DbType.Decimal);
            db.AddInParameter(commandCliente, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandCliente, "i_activo", DbType.Int32);
            db.AddInParameter(commandCliente, "i_vendedor", DbType.String);
            db.AddInParameter(commandCliente, "i_grancontribuyen", DbType.Int32);
            db.AddInParameter(commandCliente, "i_retenedorfuente", DbType.Int32);
            db.AddInParameter(commandCliente, "i_retenedorica", DbType.Int32);
            db.AddInParameter(commandCliente, "i_cuentacontable", DbType.String);
            db.AddInParameter(commandCliente, "i_localizacion", DbType.String);
            db.AddInParameter(commandCliente, "i_clasificacion", DbType.String);
            db.AddInParameter(commandCliente, "i_persona", DbType.String);
            db.AddInParameter(commandCliente, "i_sector", DbType.String);
            db.AddInParameter(commandCliente, "i_fechanacimiento", DbType.DateTime);
            db.AddInParameter(commandCliente, "i_codciudad", DbType.String);
            db.AddInParameter(commandCliente, "i_categoria", DbType.String);
            db.AddInParameter(commandCliente, "i_sexo", DbType.String);
            db.AddInParameter(commandCliente, "i_cuentacrm", DbType.Int32);
            db.AddInParameter(commandCliente, "i_tipodocumento", DbType.Int32);
            db.AddInParameter(commandCliente, "i_apellido1", DbType.String);
            db.AddInParameter(commandCliente, "i_apellido2", DbType.String);
            db.AddInParameter(commandCliente, "i_nombre1", DbType.String);
            db.AddInParameter(commandCliente, "i_nombre2", DbType.String);
            db.AddInParameter(commandCliente, "i_dv", DbType.String);
            db.AddInParameter(commandCliente, "i_simplificado", DbType.Int32);
            db.AddInParameter(commandCliente, "i_autoretenedor", DbType.Int32);
            db.AddInParameter(commandCliente, "i_departamento", DbType.String);
            db.AddInParameter(commandCliente, "i_codmediosmagneticos", DbType.String);
            db.AddInParameter(commandCliente, "i_pais", DbType.String);
            db.AddInParameter(commandCliente, "i_desmantelados", DbType.Decimal);
            db.AddInParameter(commandCliente, "i_telefonodos", DbType.String);
            db.AddInParameter(commandCliente, "i_fechaingreso", DbType.DateTime);
            db.AddInParameter(commandCliente, "i_suspender_credito", DbType.Int32);
            db.AddInParameter(commandCliente, "i_tipotercero", DbType.Int32);
            db.AddInParameter(commandCliente, "i_barrio", DbType.String);
            db.AddInParameter(commandCliente, "i_codlista", DbType.String);
            db.AddInParameter(commandCliente, "i_fpago", DbType.String);
            db.AddInParameter(commandCliente, "i_facturar", DbType.Int32);
            db.AddInParameter(commandCliente, "i_celular1", DbType.String);
            db.AddInParameter(commandCliente, "i_celular2", DbType.String);
            db.AddInParameter(commandCliente, "i_tid_id", DbType.Int32);
            db.AddInParameter(commandCliente, "i_direccionresidencia", DbType.String);
            db.AddInParameter(commandCliente, "i_esc_id", DbType.Int32);
            db.AddInParameter(commandCliente, "i_sec_codsector", DbType.String);
            db.AddInParameter(commandCliente, "i_id_referidor", DbType.String);
            db.AddInParameter(commandCliente, "i_cli_enproduccion", DbType.Boolean);
            db.AddInParameter(commandCliente, "i_str_query", DbType.String);
            db.AddInParameter(commandCliente, "i_bar_codbarrio", DbType.Int32);
            db.AddInParameter(commandCliente, "i_codigoregional", DbType.String);
            db.AddInParameter(commandCliente, "i_campana", DbType.String);
            db.AddInParameter(commandCliente, "i_iddistribuidor", DbType.Int32);
            db.AddInParameter(commandCliente, "i_documentodistribuidor", DbType.String);
            db.AddInParameter(commandCliente, "i_creadopor", DbType.String);
            db.AddInParameter(commandCliente, "i_aprobadoccn", DbType.Boolean);
            db.AddInParameter(commandCliente, "i_comoteenteraste", DbType.Int32);
            db.AddInParameter(commandCliente, "i_termycond", DbType.Boolean);
            db.AddInParameter(commandCliente, "i_fechaaceptacionterm", DbType.DateTime);
            db.AddInParameter(commandCliente, "i_mostrartermycond", DbType.Boolean);
            db.AddInParameter(commandCliente, "i_tipopedidominimo", DbType.Int32);
            db.AddInParameter(commandCliente, "i_id_lider", DbType.String);
            db.AddInParameter(commandCliente, "i_idcatalogointeres", DbType.Int32);
            db.AddInParameter(commandCliente, "i_catalogointeres", DbType.String);
            db.AddInParameter(commandCliente, "i_tipoenvio", DbType.Int32);
            db.AddInParameter(commandCliente, "i_codciudaddespacho", DbType.String);

            db.AddInParameter(commandCliente, "i_idtransportista", DbType.String);
            db.AddInParameter(commandCliente, "i_idtipored", DbType.Int32);

            db.AddInParameter(commandCliente, "i_privilegio", DbType.Boolean);

            db.AddOutParameter(commandCliente, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCliente, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Clientes

        /// <summary>
        /// lista todos los Clientes existentes.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> List()
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'A');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'B');
            db.SetParameterValue(commandCliente, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'C');
            db.SetParameterValue(commandCliente, "i_esc_id", EstadoCliente);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
                db.SetParameterValue(commandCliente, "i_operation", 'I');
                db.SetParameterValue(commandCliente, "i_option", 'A');

                db.SetParameterValue(commandCliente, "i_fechaingreso", item.FechaIngreso);
                db.SetParameterValue(commandCliente, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandCliente, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_activo", item.Activo);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_pais", item.CodPais);
                db.SetParameterValue(commandCliente, "i_dv", item.DV);
                db.SetParameterValue(commandCliente, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandCliente, "i_documentodistribuidor", item.DocumentoDistribuidor);
                db.SetParameterValue(commandCliente, "i_creadopor", item.CreadoPor);

                db.SetParameterValue(commandCliente, "i_comoteenteraste", item.ComoTeEnteraste);

                db.SetParameterValue(commandCliente, "i_termycond", item.TerminosyCondiciones);
                db.SetParameterValue(commandCliente, "i_fechaaceptacionterm", item.FechaAceptacionTerminos);
                db.SetParameterValue(commandCliente, "i_mostrartermycond", item.MostrarTerminosyCondiciones);

                db.SetParameterValue(commandCliente, "i_categoria", item.Categoria);

                db.SetParameterValue(commandCliente, "i_id_lider", item.Lider);

                db.SetParameterValue(commandCliente, "i_tipopedidominimo", item.TipoPedidoMinimo);

                db.SetParameterValue(commandCliente, "i_idcatalogointeres", item.IdCatalogoInteres);
                db.SetParameterValue(commandCliente, "i_catalogointeres", item.CatalogoInteres);

                db.SetParameterValue(commandCliente, "i_idtransportista", item.IdTransportista);

                db.SetParameterValue(commandCliente, "i_idtipored", item.IdTipoRed);

                dr = db.ExecuteReader(commandCliente);

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
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'A');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);
                db.SetParameterValue(commandCliente, "i_aprobadoccn", item.AprobadoCCN);
                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandCliente, "i_documentodistribuidor", item.DocumentoDistribuidor);

                dr = db.ExecuteReader(commandCliente);

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
        /// Realiza la actualizacion de un usuario en el sistema.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateCliente(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'D');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandCliente, "i_documentodistribuidor", item.DocumentoDistribuidor);

                db.SetParameterValue(commandCliente, "i_codciudaddespacho", item.CodCiudadDespacho);

                db.SetParameterValue(commandCliente, "i_idtransportista", item.IdTransportista);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    //objAuditoriaInfo.Proceso = "Se realizó actualización de información general de empresaria: C.C. " + item.Nit + " " + (item.Nombre1 + " " + item.Nombre2 + " " + item.Apellido1 + " " + item.Apellido2) + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoriaInfo.Proceso = "Se realizó actualización de información general de empresaria: C.C. " + item.Nit + " " + (item.Nombre1 + " " + item.Nombre2 + " " + item.Apellido1 + " " + item.Apellido2) + ". Acción Realizada por el Usuario: " + item.Usuario + ", Nuevos Valores ( " +
                        " Nit: " + item.Nit +
                        ", Nombre1: " + item.Nombre1 +
                        ", Nombre2: " + item.Nombre2 +
                        ", Apellido1: " + item.Apellido1 +
                        ", Apellido2: " + item.Apellido2 +
                        ", FechaNacimiento: " + item.FechaNacimiento +
                        ", DireccionResidencia: " + item.DireccionResidencia +
                        ", Barrio: " + item.Barrio +
                        ", CodCiudad: " + item.CodCiudad +
                        ", Ciudad: " + item.Ciudad +
                        ", DireccionPedidos: " + item.DireccionPedidos +
                        ", Telefono1: " + item.Telefono1 +
                        ", Telefono2: " + item.Telefono2 +
                        ", Celular1: " + item.Celular1 +
                        ", Celular2: " + item.Celular2 +
                        ", Email: " + item.Email +
                        ", Zona: " + item.Zona +
                        ", TipoDocumento: " + item.TipoDocumento +
                        ", CodSector: " + item.CodSector +
                        ", CodigoBarrio: " + item.CodigoBarrio +
                        ", IdReferidor: " + item.IdReferidor +
                        ", IdDistribuidor: " + item.IdDistribuidor +
                        ", DocumentoDistribuidor: " + item.DocumentoDistribuidor +
                        ", CodCiudadDespacho: " + item.CodCiudadDespacho +
                        " )";

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
        /// Este es igual al Update "A" pero se le agrega vendedor
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AprobarEmpresariaConVendedor(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'G');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);
                db.SetParameterValue(commandCliente, "i_aprobadoccn", item.AprobadoCCN);

                db.SetParameterValue(commandCliente, "i_vendedor", item.Vendedor);

                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandCliente, "i_documentodistribuidor", item.DocumentoDistribuidor);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó aprobación de empresaria: C.C. " + item.Nit + " " + (item.Nombre1 + " " + item.Nombre2 + " " + item.Apellido1 + " " + item.Apellido2) + ", se modificó información general y se cambio el estado de PROSPECTO SIN APROBACION a PROSPECTO APROBADO POR CCN. Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de la aceptacion de terminos y condiciones.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdateAceptoTerminosyCondiciones(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'H');
                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_termycond", item.TerminosyCondiciones);
                db.SetParameterValue(commandCliente, "i_fechaaceptacionterm", item.FechaAceptacionTerminos);
                db.SetParameterValue(commandCliente, "i_mostrartermycond", item.MostrarTerminosyCondiciones);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Nit;
                    objAuditoriaInfo.Proceso = "Se realizó aceptación de terminos y condiciones empresaria: C.C. " + item.Nit + ". Acción Realizada por el Usuario: " + item.Nit;

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
        /// Realiza la actualizacion de una empresaria en Peru.
        /// </summary>
        /// <param name="item"></param>
        public bool UpdateClientePeru(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {

                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'J');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandCliente, "i_documentodistribuidor", item.DocumentoDistribuidor);

                db.SetParameterValue(commandCliente, "i_localizacion", item.Localizacion);

                dr = db.ExecuteReader(commandCliente);

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
        /// Realiza la aprobacion de CCN de una empresaria en Peru.
        /// </summary>
        /// <param name="item"></param>
        public bool AprobarEmpresariaProspectoPeru(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'L');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandCliente, "i_documentodistribuidor", item.DocumentoDistribuidor);

                db.SetParameterValue(commandCliente, "i_localizacion", item.Localizacion);

                db.SetParameterValue(commandCliente, "i_aprobadoccn", item.AprobadoCCN);
                db.SetParameterValue(commandCliente, "i_vendedor", item.Vendedor);

                dr = db.ExecuteReader(commandCliente);

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
                db.SetParameterValue(commandCliente, "i_operation", 'I');
                db.SetParameterValue(commandCliente, "i_option", 'B');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandCliente, "i_contacto", item.Contacto);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_fax", item.Fax);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_plazo_credito", item.PlazoCredito);
                db.SetParameterValue(commandCliente, "i_cupo_asignado", item.CupoAsignado);
                db.SetParameterValue(commandCliente, "i_precio_de_venta", item.PrecioVenta);
                db.SetParameterValue(commandCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandCliente, "i_activo", item.Activo);
                db.SetParameterValue(commandCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandCliente, "i_grancontribuyen", item.Grancontribuyen);
                db.SetParameterValue(commandCliente, "i_retenedorfuente", item.RetenedorFuente);
                db.SetParameterValue(commandCliente, "i_retenedorica", item.RetenedorIca);
                db.SetParameterValue(commandCliente, "i_cuentacontable", item.CuentaContable);
                db.SetParameterValue(commandCliente, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandCliente, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandCliente, "i_persona", item.Persona);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_categoria", item.Categoria);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_cuentacrm", item.CuentaCRM);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_dv", item.DV);
                db.SetParameterValue(commandCliente, "i_simplificado", item.Simplificado);
                db.SetParameterValue(commandCliente, "i_autoretenedor", item.Autoretenedor);
                db.SetParameterValue(commandCliente, "i_departamento", item.Departamento);
                db.SetParameterValue(commandCliente, "i_codmediosmagneticos", item.CodMediosMagneticos);
                db.SetParameterValue(commandCliente, "i_pais", item.CodPais);
                db.SetParameterValue(commandCliente, "i_desmantelados", item.Desmantelados);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_fechaingreso", DateTime.Now);
                db.SetParameterValue(commandCliente, "i_suspender_credito", item.SuspenderCredito);
                db.SetParameterValue(commandCliente, "i_tipotercero", item.TipoTercero);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codlista", item.CodLista);
                db.SetParameterValue(commandCliente, "i_fpago", item.Fpago);
                db.SetParameterValue(commandCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                dr = db.ExecuteReader(commandCliente);

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
                db.SetParameterValue(commandCliente, "i_operation", 'I');
                db.SetParameterValue(commandCliente, "i_option", 'C');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandCliente, "i_contacto", item.Contacto);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_fax", item.Fax);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_plazo_credito", item.PlazoCredito);
                db.SetParameterValue(commandCliente, "i_cupo_asignado", item.CupoAsignado);
                db.SetParameterValue(commandCliente, "i_precio_de_venta", item.PrecioVenta);
                db.SetParameterValue(commandCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandCliente, "i_activo", item.Activo);
                db.SetParameterValue(commandCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandCliente, "i_grancontribuyen", item.Grancontribuyen);
                db.SetParameterValue(commandCliente, "i_retenedorfuente", item.RetenedorFuente);
                db.SetParameterValue(commandCliente, "i_retenedorica", item.RetenedorIca);
                db.SetParameterValue(commandCliente, "i_cuentacontable", item.CuentaContable);
                db.SetParameterValue(commandCliente, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandCliente, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandCliente, "i_persona", item.Persona);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_categoria", item.Categoria);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_cuentacrm", item.CuentaCRM);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_dv", item.DV);
                db.SetParameterValue(commandCliente, "i_simplificado", item.Simplificado);
                db.SetParameterValue(commandCliente, "i_autoretenedor", item.Autoretenedor);
                db.SetParameterValue(commandCliente, "i_departamento", item.Departamento);
                db.SetParameterValue(commandCliente, "i_codmediosmagneticos", item.CodMediosMagneticos);
                db.SetParameterValue(commandCliente, "i_pais", item.CodPais);
                db.SetParameterValue(commandCliente, "i_desmantelados", item.Desmantelados);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_fechaingreso", item.FechaIngreso);
                db.SetParameterValue(commandCliente, "i_suspender_credito", item.SuspenderCredito);
                db.SetParameterValue(commandCliente, "i_tipotercero", item.TipoTercero);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codlista", item.CodLista);
                db.SetParameterValue(commandCliente, "i_fpago", item.Fpago);
                db.SetParameterValue(commandCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                dr = db.ExecuteReader(commandCliente);

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
                db.SetParameterValue(commandCliente, "i_operation", 'I');
                db.SetParameterValue(commandCliente, "i_option", 'D');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandCliente, "i_contacto", item.Contacto);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_fax", item.Fax);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_plazo_credito", item.PlazoCredito);
                db.SetParameterValue(commandCliente, "i_cupo_asignado", item.CupoAsignado);
                db.SetParameterValue(commandCliente, "i_precio_de_venta", item.PrecioVenta);
                db.SetParameterValue(commandCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandCliente, "i_activo", item.Activo);
                db.SetParameterValue(commandCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandCliente, "i_grancontribuyen", item.Grancontribuyen);
                db.SetParameterValue(commandCliente, "i_retenedorfuente", item.RetenedorFuente);
                db.SetParameterValue(commandCliente, "i_retenedorica", item.RetenedorIca);
                db.SetParameterValue(commandCliente, "i_cuentacontable", item.CuentaContable);
                db.SetParameterValue(commandCliente, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandCliente, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandCliente, "i_persona", item.Persona);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_categoria", item.Categoria);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_cuentacrm", item.CuentaCRM);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_dv", item.DV);
                db.SetParameterValue(commandCliente, "i_simplificado", item.Simplificado);
                db.SetParameterValue(commandCliente, "i_autoretenedor", item.Autoretenedor);
                db.SetParameterValue(commandCliente, "i_departamento", item.Departamento);
                db.SetParameterValue(commandCliente, "i_codmediosmagneticos", item.CodMediosMagneticos);
                db.SetParameterValue(commandCliente, "i_pais", item.CodPais);
                db.SetParameterValue(commandCliente, "i_desmantelados", item.Desmantelados);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_fechaingreso", DateTime.Now);
                db.SetParameterValue(commandCliente, "i_suspender_credito", item.SuspenderCredito);
                db.SetParameterValue(commandCliente, "i_tipotercero", item.TipoTercero);
                //db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codlista", item.CodLista);
                db.SetParameterValue(commandCliente, "i_fpago", item.Fpago);
                db.SetParameterValue(commandCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_cli_enproduccion", item.EnProduccion);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);


                dr = db.ExecuteReader(commandCliente);

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
        /// Realiza el registro de una empresaria de peru.
        /// </summary>
        /// <param name="item"></param>
        public bool RegistrarEmpresariaPeru(ClienteInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'I');
                db.SetParameterValue(commandCliente, "i_option", 'E');

                db.SetParameterValue(commandCliente, "i_fechaingreso", item.FechaIngreso);
                db.SetParameterValue(commandCliente, "i_tid_id", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_nombre1", item.Nombre1);
                db.SetParameterValue(commandCliente, "i_nombre2", item.Nombre2);
                db.SetParameterValue(commandCliente, "i_apellido1", item.Apellido1);
                db.SetParameterValue(commandCliente, "i_apellido2", item.Apellido2);
                db.SetParameterValue(commandCliente, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandCliente, "i_direccionresidencia", item.DireccionResidencia);
                db.SetParameterValue(commandCliente, "i_barrio", item.Barrio);
                db.SetParameterValue(commandCliente, "i_codciudad", item.CodCiudad);
                db.SetParameterValue(commandCliente, "i_sexo", item.Sexo);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);
                db.SetParameterValue(commandCliente, "i_telefonodos", item.Telefono2);
                db.SetParameterValue(commandCliente, "i_celular1", item.Celular1);
                db.SetParameterValue(commandCliente, "i_celular2", item.Celular2);
                db.SetParameterValue(commandCliente, "i_email", item.Email);
                db.SetParameterValue(commandCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandCliente, "i_razonsocial", item.RazonSocial);
                db.SetParameterValue(commandCliente, "i_ciudad", item.Ciudad);
                db.SetParameterValue(commandCliente, "i_activo", item.Activo);
                db.SetParameterValue(commandCliente, "i_tipodocumento", item.TipoDocumento);
                db.SetParameterValue(commandCliente, "i_pais", item.CodPais);
                db.SetParameterValue(commandCliente, "i_dv", item.DV);
                db.SetParameterValue(commandCliente, "i_esc_id", item.IdEstadosCliente);
                db.SetParameterValue(commandCliente, "i_sec_codsector", item.CodSector);
                db.SetParameterValue(commandCliente, "i_bar_codbarrio", item.CodigoBarrio);

                db.SetParameterValue(commandCliente, "i_id_referidor", item.IdReferidor);

                db.SetParameterValue(commandCliente, "i_iddistribuidor", item.IdDistribuidor);
                db.SetParameterValue(commandCliente, "i_documentodistribuidor", item.DocumentoDistribuidor);
                db.SetParameterValue(commandCliente, "i_creadopor", item.CreadoPor);

                db.SetParameterValue(commandCliente, "i_comoteenteraste", item.ComoTeEnteraste);

                db.SetParameterValue(commandCliente, "i_termycond", item.TerminosyCondiciones);
                db.SetParameterValue(commandCliente, "i_fechaaceptacionterm", item.FechaAceptacionTerminos);
                db.SetParameterValue(commandCliente, "i_mostrartermycond", item.MostrarTerminosyCondiciones);

                db.SetParameterValue(commandCliente, "i_localizacion", item.Localizacion);

                db.SetParameterValue(commandCliente, "i_categoria", item.Categoria);

                db.SetParameterValue(commandCliente, "i_id_lider", item.Lider);

                db.SetParameterValue(commandCliente, "i_tipopedidominimo", item.TipoPedidoMinimo);

                db.SetParameterValue(commandCliente, "i_idcatalogointeres", item.IdCatalogoInteres);
                db.SetParameterValue(commandCliente, "i_catalogointeres", item.CatalogoInteres);


                dr = db.ExecuteReader(commandCliente);

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
        /// Realiza la actualizacion de direccion y telefono de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        public bool ActualizarDireccionTelefono(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'B');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);

                db.SetParameterValue(commandCliente, "i_codciudaddespacho", item.CodCiudadDespacho);

                dr = db.ExecuteReader(commandCliente);

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
                        objAuditoriaInfo.Proceso = "Se realizó actualización de dirección y telefono de empresaria: C.C. " + item.Nit + " Dirección: " + item.DireccionPedidos + " Telefono: " + item.Telefono1 + " Ciudad Despacho:" + item.CodCiudadDespacho + ". Acción Realizada por el Usuario: " + item.Usuario;

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
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'C');
                db.SetParameterValue(commandCliente, "i_nit", Nit);
                db.SetParameterValue(commandCliente, "i_cli_enproduccion", EnProduccion);

                dr = db.ExecuteReader(commandCliente);

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
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'E');
                db.SetParameterValue(commandCliente, "i_nit", Nit);
                db.SetParameterValue(commandCliente, "i_zona", Zona);

                dr = db.ExecuteReader(commandCliente);

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
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'F');
                db.SetParameterValue(commandCliente, "i_nit", Nit);
                db.SetParameterValue(commandCliente, "i_esc_id", EstadoCliente);

                dr = db.ExecuteReader(commandCliente);

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
        /// Realiza la actualizacion del email de un cliente.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoCliente"></param>
        /// <returns></returns>
        public bool UpdateEmailCliente(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'I');
                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_email", item.Email);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.RazonSocial;
                    objAuditoriaInfo.Proceso = "Se realizó recuperación de clave y actualización de E-Mail de empresaria: C.C. " + item.Nit + ", Nuevo E-Mail: " + item.Email + ". Acción Realizada por el Usuario: C.C. " + item.Nit + ", " + item.RazonSocial;

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
        /// Realiza la actualizacion del estado de la asignacion de premio de bienvenida.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdateEstadoPremioCliente(string Nit)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'K');
                db.SetParameterValue(commandCliente, "i_nit", Nit);

                dr = db.ExecuteReader(commandCliente);

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
        /// GAVL Realiza la actualizacion del estado del cliente  
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoCliente"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateClienteEstado(string Nit, int EstadoCliente, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'M');
                db.SetParameterValue(commandCliente, "i_nit", Nit);
                db.SetParameterValue(commandCliente, "i_activo", EstadoCliente);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó  actualizacion del estado de la empresaria: C.C. " + Nit + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// Realiza la actualizacion de ciudad de despacho una empresaria.
        /// </summary>
        /// <param name="item"></param>
        public bool ActualizarCiudadDespacho(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'L');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //Se pregunta si se debe guardar la auditoria.
                if (true)
                {
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //Guardar auditoria 
                    try
                    {
                        Auditoria objAuditoria = new Auditoria("conexion");
                        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                        objAuditoriaInfo.FechaSistema = DateTime.Now;
                        objAuditoriaInfo.Usuario = item.Usuario;
                        objAuditoriaInfo.Proceso = "Se realizó actualización de ciudad de despacho de empresaria: C.C. " + item.Nit + ", Ciudad Despacho" + item.CodCiudadDespacho + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de la red de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdLider"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateModificarRed(string Nit, string IdLider, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'N');
                db.SetParameterValue(commandCliente, "i_nit", Nit);
                db.SetParameterValue(commandCliente, "i_id_lider", IdLider);

                dr = db.ExecuteReader(commandCliente);

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
        /// Realiza la actualizacion de una empresaria si es del plan privilegio o no.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="EstadoPrivilegio"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateEstadoPrivilegio(string Nit, bool EstadoPrivilegio, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'M');
                db.SetParameterValue(commandCliente, "i_nit", Nit);
                db.SetParameterValue(commandCliente, "i_privilegio", EstadoPrivilegio);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualización de estado privilegio de empresaria: C.C. " + Nit + ", Se actualiza a Estado (1= Tiene Privilegio, 0= NO tiene Privielgio). Estado Establecido :" + EstadoPrivilegio + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// lista todas las empresarias.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListTodasEmpresarias()
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'E');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'F');
            db.SetParameterValue(commandCliente, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'G');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'H');
            db.SetParameterValue(commandCliente, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'I');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'J');
            db.SetParameterValue(commandCliente, "i_nit", Nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'O');
            db.SetParameterValue(commandCliente, "i_nit", Nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'K');
            db.SetParameterValue(commandCliente, "i_nit", Nit);



            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'L');
            db.SetParameterValue(commandCliente, "i_zona", IdZona);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'M');
            db.SetParameterValue(commandCliente, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                if (dr.Read())
                {
                    m = Factory.GetClienteEditProspecto(dr);
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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'N');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteMisEmpresarias(dr);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'P');
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'Q');
            db.SetParameterValue(commandCliente, "i_fechaingreso", FechaIngreso);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'R');
            db.SetParameterValue(commandCliente, "i_nit", Nit);

            List<string> col = new List<string>();

            IDataReader dr = null;

            string m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'S');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'T');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'U');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'V');

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'W');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'X');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'Y');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'Z');
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AA");
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AB");

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AC");
            db.SetParameterValue(commandCliente, "i_nit", cedula);
            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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

        //Lista las empresarias Inactivas de acuerdo a una campaña especifica        
        public List<ClienteInfo> ListEmpresariasInactivasXCampana(string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AD");
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
        /// lista las empresarias prospecto de la zona 9106
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasProspectoVPN()
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AE");

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                while (dr.Read())
                {
                    m = Factory.GetClientesProspecto(dr);

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
        /// Lista las empresarias Inactivas de acuerdo a una campaña especifica - Para gerentes divisionales
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="CodigoRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasInactivasXCampanaDivisional(string Zona, string CodigoRegional, string Campana)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AF");
            db.SetParameterValue(commandCliente, "i_zona", Zona);
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
        /// Lista si el cliente debe ver los terminos y condiciones de la plataforma.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo MostrarTerminosyCondiciones(string nit)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AG");
            db.SetParameterValue(commandCliente, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                if (dr.Read())
                {
                    m = Factory.GetMostrarTerminosyCondiciones(dr);
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
        /// Lista las empresarias de un lider.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxLider(string IdLider)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AH");
            db.SetParameterValue(commandCliente, "i_id_lider", IdLider);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimpleEdit(string nit)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AI");
            db.SetParameterValue(commandCliente, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
        /// Lista si una empresaria corresponde a un lider.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="idlider"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITxLider(string nit, string idlider)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AJ");
            db.SetParameterValue(commandCliente, "i_nit", nit);
            db.SetParameterValue(commandCliente, "i_id_lider", idlider);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
        /// Lista la informacion de un cliente sin barrios, ciudad2, estado.
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ClienteInfo ListxNITSimpleEditEc(string nit)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AK");
            db.SetParameterValue(commandCliente, "i_nit", nit);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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

        #region Metodos del Buscador

        /// <summary>
        /// Mapea los campos de consulta de la base de datos a nombres 
        /// entendibles por el usuario y asociados a la aplicaciòn
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public TableMapping SearchMapping(string language)
        {
            TableMapping searchMapping = new TableMapping("PRC_SVDN_CLIENTE", "NIVI.Application.Enterprise.CommonObjects.ClienteInfo");

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

            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", 'D');
            db.SetParameterValue(commandCliente, "i_str_query", lstItem);

            try
            {
                dr = db.ExecuteReader(commandCliente);

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


        #endregion



        #region DESMANTELADORAS

        /// <summary>
        /// List cliente que sea demanteladora para cambiar estado del pedido
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool BuscaDemanteladora(string Nit, string Zona)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", "S");
                db.SetParameterValue(commandCliente, "i_option", "AL");
                db.SetParameterValue(commandCliente, "i_nit", Nit);
                db.SetParameterValue(commandCliente, "i_zona", Zona);


                dr = db.ExecuteReader(commandCliente);

                if (dr.Read())
                {

                    if (!dr.IsDBNull(dr.GetOrdinal("Desmantelado")))
                    {
                        if (dr.GetInt32(dr.GetOrdinal("Desmantelado")) > 0)
                        {
                            transOk = true;
                        }
                    }
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
        #endregion

        #region ASISTENTES

        /// <summary>
        /// GAVL  Lista las empresarias de un asistente
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxAsistente(string CodigoRegional)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AM");
            db.SetParameterValue(commandCliente, "i_codigoregional", CodigoRegional);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
        #endregion


        /// <summary>
        /// Lista todos los estados de los clientes.
        /// </summary>
        /// <returns></returns>
        public List<ClienteInfo> ListEstadosEmpresarias()
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AN");

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                while (dr.Read())
                {
                    m = Factory.GetEstadosEmpresarias(dr);

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
        /// Lista el reporte de estados de las empresarias x campaña.
        /// </summary>
        /// <param name="IdEstado"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEstadosEmpresariasxCampana(int IdEstado, string Campana)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AO");
            db.SetParameterValue(commandCliente, "i_esc_id", IdEstado);
            db.SetParameterValue(commandCliente, "i_campana", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteMisEmpresarias(dr);

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
        /// Lista los clientes de una zona especifica con privilegio.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxZonaPrivilegio(string IdZona)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "AP");
            db.SetParameterValue(commandCliente, "i_zona", IdZona);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                while (dr.Read())
                {
                    m = Factory.GetClientesNiviPrivilegio(dr);

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
        /// Lista las empresarias de una gerente que pertenece a una zona maestra.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEmpresariasxGerenteSimpleZonaMaestra(string Zona)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "SA");
            db.SetParameterValue(commandCliente, "i_vendedor", Zona);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteMisEmpresarias(dr);

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
        /// Lista un cliente especifico de la bd de svdn que corresponda a una zona de vendedor o lider 
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public ClienteInfo ListClienteSVDNxNitxVendedorxLider(string Nit, string IdVendedor, string IdLider)
        {
            db.SetParameterValue(commandCliente, "i_operation", 'S');
            db.SetParameterValue(commandCliente, "i_option", "ED");
            db.SetParameterValue(commandCliente, "i_nit", Nit);
            db.SetParameterValue(commandCliente, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandCliente, "i_id_lider", IdLider);

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCliente);

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
       
        

    }
}
