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
    public class ValidaClienteIquitos
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
        public ValidaClienteIquitos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ValidaClienteIquitos()
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
            commandCliente = db.GetStoredProcCommand("PRC_SVDN_VALINSERT_CLIENTE_PERU");

            db.AddInParameter(commandCliente, "i_operation", DbType.String);
            db.AddInParameter(commandCliente, "i_option", DbType.String);

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

            db.AddOutParameter(commandCliente, "i_resultado", DbType.Int32, 1000);

            db.AddOutParameter(commandCliente, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCliente, "o_err_msg", DbType.String, 1000);


        }
        #endregion

        #region "Validacion clientes iquitos"

        /// <summary>
        /// GAVL VALIDACION  DE CLIENTES EN IQUITOS
        /// </summary>
        /// <param name="vendedor"></param>
        /// <param name="zona"></param>
        /// <param name="codciudad"></param>
        /// <param name="nit"></param>
        /// <returns></returns>
        public bool ValidaClientesIquitos(string vendedor, string zona, string codciudad, string nit)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'S');
                db.SetParameterValue(commandCliente, "i_option", 'A');
                db.SetParameterValue(commandCliente, "i_nit", nit);
                db.SetParameterValue(commandCliente, "i_zona", zona);
                db.SetParameterValue(commandCliente, "i_vendedor", vendedor);
                db.SetParameterValue(commandCliente, "i_codciudad", codciudad);

                dr = db.ExecuteReader(commandCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = nit;
                    objAuditoriaInfo.Proceso = "Se realizó validacion e insercion de datos faltantes para la sucursal de iquitos,nit: " + nit + "zona: " + zona + "vendedor: " + vendedor + "codciudad: " + codciudad + ". Acción Realizada por el Usuario: " + nit;

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
        /// GAVL REGITRA EMPRESARIA DE PERU PARA IQUITOS
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool RegistrarEmpresariaPeru(string nit, string usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandCliente, "i_operation", 'I');
                db.SetParameterValue(commandCliente, "i_option", 'A');

                db.SetParameterValue(commandCliente, "i_nit", nit);



                dr = db.ExecuteReader(commandCliente);

                okTrans = true;


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro de empresaria: C.C. " + nit + " para iquitos. Acción Realizada por el Usuario: " + usuario;

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
        /// GAVL ACTUALIZA CLIENTE DE PERU EN IQUITOS 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateClientePeruIquitos(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                commandCliente.CommandTimeout = 600;
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
        /// Realiza la actualizacion de direccion y telefono de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        public bool ActualizarDireccionTelefonoIquito(ClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                commandCliente.CommandTimeout = 200;
                db.SetParameterValue(commandCliente, "i_operation", 'U');
                db.SetParameterValue(commandCliente, "i_option", 'B');

                db.SetParameterValue(commandCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandCliente, "i_direccion", item.DireccionPedidos);
                db.SetParameterValue(commandCliente, "i_telefonos", item.Telefono1);

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


        #endregion
    }
}