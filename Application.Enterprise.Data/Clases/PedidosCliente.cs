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
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class PedidosCliente
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPedidosCliente;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PedidosCliente(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PedidosCliente()
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
            commandPedidosCliente = db.GetStoredProcCommand("PRC_SVDN_PEDIDOSC1_2020");

            db.AddInParameter(commandPedidosCliente, "i_operation", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_option", DbType.String);
            db.AddParameter(commandPedidosCliente, "i_numero", DbType.String, 12, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandPedidosCliente, "i_mes", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_fecha", DbType.DateTime);
            db.AddInParameter(commandPedidosCliente, "i_anulado", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_espera", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_despacho", DbType.DateTime);
            db.AddInParameter(commandPedidosCliente, "i_nit", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_vendedor", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_iva", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_valor", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_fechacreacion", DbType.DateTime);
            db.AddInParameter(commandPedidosCliente, "i_claveusuario", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_zona", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_codigo_numeracion", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_transmitido", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_campana", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_numeroenvio", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_nofacturado", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_facturar", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_codtipo", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_devol", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_factura", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_str_query", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_orden", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_procesado", DbType.Boolean);
            db.AddInParameter(commandPedidosCliente, "i_nivelservicioestimado", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_nivelservicioreal", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_nivelservicioestado", DbType.Boolean);
            db.AddInParameter(commandPedidosCliente, "i_nivelserviciotipo", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_valor_premio", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_fecha_ultimamodificacion", DbType.DateTime);
            db.AddInParameter(commandPedidosCliente, "i_valor_premioniveles", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_esp_id", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_idarticulopremio", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_tipoquery", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_enproduccion", DbType.Boolean);
            db.AddInParameter(commandPedidosCliente, "i_ivapreciocatalogo", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_valorpreciocatalogo", DbType.Decimal);
            db.AddInParameter(commandPedidosCliente, "i_catalogo", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_generapremios", DbType.Boolean);
            db.AddInParameter(commandPedidosCliente, "i_anexo", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_idlider", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_reserva", DbType.Boolean);
            db.AddInParameter(commandPedidosCliente, "i_borrador", DbType.Boolean);
            db.AddInParameter(commandPedidosCliente, "i_fechacierreborrador", DbType.DateTime);
            db.AddInParameter(commandPedidosCliente, "i_fechacierrereserva", DbType.DateTime);
            db.AddInParameter(commandPedidosCliente, "i_portal", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_tipoenvio", DbType.Int32);
            db.AddInParameter(commandPedidosCliente, "i_codciudaddespacho", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_factusemanal", DbType.Boolean);
            db.AddInParameter(commandPedidosCliente, "i_motivo", DbType.String); 
            db.AddInParameter(commandPedidosCliente, "i_codmotivo", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_asistente", DbType.String); 
            db.AddInParameter(commandPedidosCliente, "i_NombreAnulo", DbType.String);
            db.AddInParameter(commandPedidosCliente, "i_puntosusados", DbType.Int32);
            // QUITAR PARA QUE FUNCIONE PERU Y ECUADOR
            //db.AddInParameter(commandPedidosCliente, "i_claseventa", DbType.String);                        

            db.AddOutParameter(commandPedidosCliente, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPedidosCliente, "o_err_msg", DbType.String, 1000);

            commandPedidosCliente.CommandTimeout = 1200;

        }
        #endregion

        #region Metodos de Pedidos Cliente

        /// <summary>
        /// lista todos los Pedidos Cliente existentes.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> List()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'A');

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// lista todos los Pedidos de empresaria por una campaña.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresaria(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'B');
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// lista todos los Pedidos de una gerente de zona por una campaña.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZona(string zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RW");
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosReservados(dr);

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
        /// lista todos los Pedidos de una gerente de subzona por una campaña.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteSubZona(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "C1");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista el encabezado de un pedido especifico.
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListPedidoxId(string IdPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'D');
            db.SetParameterValue(commandPedidosCliente, "i_numero", IdPedido);

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                if (dr.Read())
                {
                    m = Factory.GetPedidosClientexId(dr);
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
        /// GAVL 10/04/2013 BUSQUEDA DE PEDIDOS INTERBLOQUEADOS
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosInterbloqueados()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RR");


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Selecciona de la tabla temporal los registros filtrados por la regla.
        /// </summary>
        /// <param name="QueryRegla"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxRegla(string QueryRegla)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'E');
            db.SetParameterValue(commandPedidosCliente, "i_str_query", QueryRegla);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// lista todos los Pedidos Cliente existentes en la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTablaTemporal()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'F');

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// lista todos los Pedidos Cliente con premios existentes en la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTablaPremiosTemporal()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'M');

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista el Pedido de un Cliente para asignar premio en la tabla temporal.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTablaPremiosTemporalxNit(string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'N');
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos correspondientes a una zona y una campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampana(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'G');
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos no bloqueados que corresponden a una zona y una campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueado(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'Q');
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos no bloqueados que deben contener un premio.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueadoPremio(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'T');
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista todos los pedidos de la tabla temporal.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTemporal()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'H');

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos correspondientes a una zona y una campaña y por orden asignado.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrden(string Zona, string Campana, int Orden)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'J');
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_orden", Orden);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos correspondientes a una zona y una campaña ordenados por las reglas asignadas.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrdenProcesado(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'K');
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Selecciona de la tabla temporal los registros filtrados por la regla para PREMIOS.
        /// </summary>
        /// <param name="QueryReglaPremios"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxReglaPremios(string QueryReglaPremios)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'L');
            db.SetParameterValue(commandPedidosCliente, "i_str_query", QueryReglaPremios);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista si existe un pedido especifico en MKT.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListPedidosMkt(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'O');
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                if (dr.Read())
                {
                    m = Factory.GetPedidosMkt(dr);
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
        /// lista un Pedido por numero de la tabla temporal de premios .
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListTablaPremiosTemporalxNumero(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'P');
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);
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
        /// Lista los pedidos procesados con premios y flete listos para facturar.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidoFacturar(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'R');
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyFacturar(dr);

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
        /// Lista los pedidos y sus estados depues de procesados.
        /// </summary>
        /// <param name="Mailgroup"></param>
        /// <param name="Zona"></param>
        /// <param name="IdEstado"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosProcesados(string Mailgroup, string Zona, int IdEstado)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'S');

            if (IdEstado == 0)
            {
                db.SetParameterValue(commandPedidosCliente, "i_esp_id", null);
            }
            else
            {
                db.SetParameterValue(commandPedidosCliente, "i_esp_id", IdEstado);
            }

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// Lista los pedidos disponibles para anular sin estado en produccion.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnular()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'U');


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// Lista un pedido especifico de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListxNitxCampana(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'V');
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);
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
        /// lista todos los Pedidos de una zona maestra por una campaña.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaMaestra(string ZonaMaestra, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SA");
            db.SetParameterValue(commandPedidosCliente, "i_zona", ZonaMaestra);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Realiza el registro de un encabezado de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public string Insert(PedidosClienteInfo item)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'A');

                db.SetParameterValue(commandPedidosCliente, "i_numero", 0); //Se debe inicializar la variable con 0.
                db.SetParameterValue(commandPedidosCliente, "i_mes", item.Mes);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosCliente, "i_espera", item.Espera);
                db.SetParameterValue(commandPedidosCliente, "i_despacho", item.Despacho);
                db.SetParameterValue(commandPedidosCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandPedidosCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosCliente, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandPedidosCliente, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandPedidosCliente, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandPedidosCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_nofacturado", item.NoFacturado);
                db.SetParameterValue(commandPedidosCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandPedidosCliente, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandPedidosCliente, "i_devol", item.Devol);
                db.SetParameterValue(commandPedidosCliente, "i_factura", item.Factura);
                db.SetParameterValue(commandPedidosCliente, "i_orden", item.Orden);
                db.SetParameterValue(commandPedidosCliente, "i_procesado", item.Procesado);
                db.SetParameterValue(commandPedidosCliente, "i_ivapreciocatalogo", item.IVAPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_valorpreciocatalogo", item.ValorPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_catalogo", item.Codigo);
                db.SetParameterValue(commandPedidosCliente, "i_generapremios", item.GeneraPremios);
                db.SetParameterValue(commandPedidosCliente, "i_idlider", item.IdLider);
                db.SetParameterValue(commandPedidosCliente, "i_reserva", item.Reserva);
                db.SetParameterValue(commandPedidosCliente, "i_borrador", item.Borrador);
                db.SetParameterValue(commandPedidosCliente, "i_fechacierreborrador", item.FechaCierreBorrador);
                db.SetParameterValue(commandPedidosCliente, "i_portal", item.Portal);
                db.SetParameterValue(commandPedidosCliente, "i_tipoenvio", item.TipoEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_codciudaddespacho", item.CiudadDespacho);
                db.SetParameterValue(commandPedidosCliente, "i_factusemanal", item.FacturacionSemanal);
                db.SetParameterValue(commandPedidosCliente, "i_asistente", item.Asistente);

                db.SetParameterValue(commandPedidosCliente, "i_puntosusados", item.PuntosUsar);
                //COMENTAR PARA QUE FUNCIONE PERU Y ECUADOR
                //db.SetParameterValue(commandPedidosCliente, "i_claseventa", item.Claseventa);

                dr = db.ExecuteReader(commandPedidosCliente);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandPedidosCliente, "i_numero")).Trim();

                //****************************************************************************************************************************************
                //Si el perfil es de un usuario interno de nivi se debe guardar la auditoria.
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
                        objAuditoriaInfo.Proceso = "Se realizó la creación de Pedido Número: " + strid + " Campaña: " + item.Campana + " Cedula Empresaria: " + item.Nit + " Zona: " + item.Zona + " . Acción Realizada por el Usuario: " + item.Usuario;

                        objAuditoria.Insert(objAuditoriaInfo);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------                
                }
                //****************************************************************************************************************************************


            }
            catch (Exception ex)
            {
                strid = null;

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
            return strid;
        }



        /// <summary>
        /// Guarda los registros filtrados por una regla en la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        public void InsertxRegla(PedidosClienteInfo item)
        {
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'B');

                db.SetParameterValue(commandPedidosCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosCliente, "i_mes", item.Mes);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosCliente, "i_espera", item.Espera);
                db.SetParameterValue(commandPedidosCliente, "i_despacho", item.Despacho);
                db.SetParameterValue(commandPedidosCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandPedidosCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosCliente, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandPedidosCliente, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandPedidosCliente, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandPedidosCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_nofacturado", item.NoFacturado);
                db.SetParameterValue(commandPedidosCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandPedidosCliente, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandPedidosCliente, "i_devol", item.Devol);
                db.SetParameterValue(commandPedidosCliente, "i_factura", item.Factura);
                db.SetParameterValue(commandPedidosCliente, "i_orden", item.Orden);
                db.SetParameterValue(commandPedidosCliente, "i_procesado", item.Procesado);
                db.SetParameterValue(commandPedidosCliente, "i_catalogo", item.Codigo);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        }

        /// <summary>
        /// Guarda los pedidos que fueron seleccionados para asignar premio en la tabla temporal.
        /// </summary>
        /// <param name="item"></param>
        public void InsertxReglaxPremio(PedidosClienteInfo item)
        {
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'C');

                db.SetParameterValue(commandPedidosCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosCliente, "i_mes", item.Mes);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosCliente, "i_espera", item.Espera);
                db.SetParameterValue(commandPedidosCliente, "i_despacho", item.Despacho);
                db.SetParameterValue(commandPedidosCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandPedidosCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosCliente, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandPedidosCliente, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandPedidosCliente, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandPedidosCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_nofacturado", item.NoFacturado);
                db.SetParameterValue(commandPedidosCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandPedidosCliente, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandPedidosCliente, "i_devol", item.Devol);
                db.SetParameterValue(commandPedidosCliente, "i_factura", item.Factura);
                db.SetParameterValue(commandPedidosCliente, "i_orden", item.Orden);
                db.SetParameterValue(commandPedidosCliente, "i_procesado", item.Procesado);
                db.SetParameterValue(commandPedidosCliente, "i_idarticulopremio", item.IdArticuloPremio);
                db.SetParameterValue(commandPedidosCliente, "i_tipoquery", item.TipoQuery);
                db.SetParameterValue(commandPedidosCliente, "i_catalogo", item.Codigo);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        }

        /// <summary>
        /// Guarda los encabezados de pedidos en MKT que tienen premio.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertPremiosMkt(PedidosClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'D');

                db.SetParameterValue(commandPedidosCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosCliente, "i_mes", item.Mes);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosCliente, "i_espera", item.Espera);
                db.SetParameterValue(commandPedidosCliente, "i_despacho", item.Despacho);
                db.SetParameterValue(commandPedidosCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandPedidosCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosCliente, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandPedidosCliente, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandPedidosCliente, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandPedidosCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_nofacturado", item.NoFacturado);
                db.SetParameterValue(commandPedidosCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandPedidosCliente, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandPedidosCliente, "i_devol", item.Devol);
                db.SetParameterValue(commandPedidosCliente, "i_factura", item.Factura);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Guarda los encabezados de pedidos en Nivi listos para facturar.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertFacturar(PedidosClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'E');

                db.SetParameterValue(commandPedidosCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosCliente, "i_mes", item.Mes);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosCliente, "i_espera", item.Espera);
                db.SetParameterValue(commandPedidosCliente, "i_despacho", item.Despacho);
                db.SetParameterValue(commandPedidosCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandPedidosCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosCliente, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandPedidosCliente, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandPedidosCliente, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandPedidosCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_nofacturado", item.NoFacturado);
                db.SetParameterValue(commandPedidosCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandPedidosCliente, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandPedidosCliente, "i_devol", item.Devol);
                db.SetParameterValue(commandPedidosCliente, "i_factura", item.Factura);
                db.SetParameterValue(commandPedidosCliente, "i_catalogo", item.Codigo);
                db.SetParameterValue(commandPedidosCliente, "i_generapremios", true);
                db.SetParameterValue(commandPedidosCliente, "i_anexo", item.Anexo);
                db.SetParameterValue(commandPedidosCliente, "i_ivapreciocatalogo", item.IVAPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_valorpreciocatalogo", item.ValorPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_idlider", item.IdLider);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));


                bool okTrasnEstadoPed = this.UpdateEstadoPedido(item.Numero, (int)EstadosPedidoEnum.ErrorProcesamiento);


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
        /// Realiza el registro de un encabezado de pedido de cliente cargado con un XML.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertXML(PedidosClienteInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'F');

                db.SetParameterValue(commandPedidosCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosCliente, "i_mes", item.Mes);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosCliente, "i_espera", item.Espera);
                db.SetParameterValue(commandPedidosCliente, "i_despacho", item.Despacho);
                db.SetParameterValue(commandPedidosCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandPedidosCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosCliente, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandPedidosCliente, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandPedidosCliente, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandPedidosCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_nofacturado", item.NoFacturado);
                db.SetParameterValue(commandPedidosCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandPedidosCliente, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandPedidosCliente, "i_devol", item.Devol);
                db.SetParameterValue(commandPedidosCliente, "i_factura", item.Factura);
                db.SetParameterValue(commandPedidosCliente, "i_orden", item.Orden);
                db.SetParameterValue(commandPedidosCliente, "i_procesado", item.Procesado);
                db.SetParameterValue(commandPedidosCliente, "i_catalogo", item.Codigo);

                dr = db.ExecuteReader(commandPedidosCliente);

                okTrans = true;

            }
            catch (Exception ex)
            {
                okTrans = false;

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
        /// Realiza el registro de un encabezado de pedido de cliente en las tablas de SIMULACION.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertSimulador()
        {
            bool okTrans = false;


            db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'G');

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                okTrans = true;

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
        /// Realiza la actualizacion del registro de un encabezado de pedido de cliente.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(PedidosClienteInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'A');

                db.SetParameterValue(commandPedidosCliente, "i_numero", item.Numero);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_ivapreciocatalogo", item.IVAPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_valorpreciocatalogo", item.ValorPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_tipoenvio", item.TipoEnvio);
                //Esto solo es para peru JUTA
                db.SetParameterValue(commandPedidosCliente, "i_orden", item.Orden);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //****************************************************************************************************************************************
                //Si el perfil es de un usuario interno de nivi se debe guardar la auditoria.
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
                        objAuditoriaInfo.Proceso = "Se realizó la actualización del Pedido Número: " + item.Numero + " . Acción Realizada por el Usuario: " + item.Usuario;

                        objAuditoria.Insert(objAuditoriaInfo);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------                
                }
                //****************************************************************************************************************************************

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
        /// Realiza la actualizacion del orden  de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public bool UpdateOrden(string NumeroPedido, int Orden)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'B');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_orden", Orden);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado procesado del pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateProcesado(string NumeroPedido, bool Procesado)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'C');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_procesado", Procesado);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del nivel de servicio y estado.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="NivelServicioEstado"></param>
        /// <param name="NivelServicioEstimado"></param>
        /// <param name="NivelServicioReal"></param>
        /// <param name="NivelServicioTipo"></param>
        /// <returns></returns>
        public bool UpdateNivelServicio(string NumeroPedido, bool NivelServicioEstado, decimal NivelServicioEstimado, decimal NivelServicioReal, string NivelServicioTipo)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'D');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_nivelservicioestado", NivelServicioEstado);
                db.SetParameterValue(commandPedidosCliente, "i_nivelservicioestimado", NivelServicioEstimado);
                db.SetParameterValue(commandPedidosCliente, "i_nivelservicioreal", NivelServicioReal);
                db.SetParameterValue(commandPedidosCliente, "i_nivelserviciotipo", NivelServicioTipo);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EstadoPedido">0 =	Sin Estado, 1 =	Normal, 2 =	Agotado, 3 = Retenido Premios, 4 = Nivel Servicio, 5 =	Cartera, 6 = Desmanteladora</param>
        /// <returns></returns>
        public bool UpdateEstadoPedido(string NumeroPedido, int EstadoPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'E');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_esp_id", EstadoPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = "Demanda";
                    objAuditoriaInfo.Proceso = "Se realizó la actualización del estado de Pedido Número:  " + NumeroPedido + " Estado: " + EstadoPedido + " . Acción Realizada por el Usuario: " + "Demanda";

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
        /// Realiza la actualizacion del tipo query de un pedido temporal para verificar en la asignacion de premios.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="TipoQuery"></param>
        /// <returns></returns>
        public bool UpdateTipoQuery(string NumeroPedido, string TipoQuery)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'F');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_tipoquery", TipoQuery);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la anulacion de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateAnularPedido(string NumeroPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'H');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = "Demanda";
                    objAuditoriaInfo.Proceso = "Se realizó anulación de Pedido Número:  " + NumeroPedido + ". Acción Realizada por el Usuario: " + "Demanda";

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
        /// Realiza la anulacion de un pedido de reserva en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateAnularPedidoReserva(string NumeroPedido, string motivo, string codmotivo, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'Z');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                //INICIO GAVL  
                db.SetParameterValue(commandPedidosCliente, "i_motivo", motivo);
                db.SetParameterValue(commandPedidosCliente, "i_codmotivo", codmotivo);
                db.SetParameterValue(commandPedidosCliente, "i_NombreAnulo", Usuario);
                //FIN GAVL                 

                dr = db.ExecuteReader(commandPedidosCliente);
                //string strid;

                //strid = System.Convert.ToString(db.GetParameterValue(commandPedidosCliente, "o_err_cod")).Trim();
                //if (strid == "1")
                //{
                transOk = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó anulación de Pedido Reserva en Linea Número:  " + NumeroPedido + ". Acción Realizada por el Usuario: " + Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------
                //}
                //else
                //{
                //    //-----------------------------------------------------------------------------------------------------------------------------
                //    //Guardar auditoria 
                //    try
                //    {
                //        Auditoria objAuditoria = new Auditoria("conexion");
                //        AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                //        objAuditoriaInfo.FechaSistema = DateTime.Now;
                //        objAuditoriaInfo.Usuario = Usuario;
                //        objAuditoriaInfo.Proceso = "No Se realizó anulación de Pedido Reserva en Linea Número:  " + NumeroPedido + " por que ya se facturo el pedido. Acción Realizada por el Usuario: " + Usuario;

                //        objAuditoria.Insert(objAuditoriaInfo);
                //    }
                //    catch (Exception ex)
                //    {
                //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                //    }
                //-----------------------------------------------------------------------------------------------------------------------------
                //}




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
        /// Realiza la anulacion de un pedido En borrador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateAnularPedidoBorrador(string NumeroPedido, string motivo, string codmotivo, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AD");
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_codmotivo", codmotivo);
                db.SetParameterValue(commandPedidosCliente, "i_motivo", motivo);
                db.SetParameterValue(commandPedidosCliente, "i_NombreAnulo", Usuario);


                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó anulación de Pedido Borrador  Número:  " + NumeroPedido + ". Acción Realizada por el Usuario: " + Usuario;

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
        /// Realiza la actualizacion del estado en produccion, para que en los premios no repita los pedidos de las tablas de nivi y las svdn.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        public bool UpdateEnProduccion(string NumeroPedido, bool EnProduccion)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'G');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_enproduccion", EnProduccion);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        ///  Realiza la actualizacion del valor de un pedido en NIVI.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        public bool UpdateValorPedido(string NumeroPedido, decimal Valor, decimal IVA)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_valor", Valor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", IVA);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        ///  Realiza la actualizacion del valor de un pedido en SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        public bool UpdateValorPedidoSVDN(string NumeroPedido, decimal Valor, decimal IVA)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'J');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_valor", Valor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", IVA);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        ///  Realiza la actualizacion del valor de un pedido en SVDN simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="ValorIVA"></param>
        /// <returns></returns>
        public bool UpdateValorPedidoSVDNSimulador(string NumeroPedido, decimal Valor, decimal IVA)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'K');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_valor", Valor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", IVA);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado de un pedido en el simulador
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EstadoPedido">0 =	Sin Estado, 1 =	Normal, 2 =	Agotado, 3 = Retenido Premios, 4 = Nivel Servicio, 5 =	Cartera, 6 = Desmanteladora</param>
        /// <returns></returns>
        public bool UpdateEstadoPedidoSimulador(string NumeroPedido, int EstadoPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'L');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_esp_id", EstadoPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado en produccion, para que en los premios no repita los pedidos de las tablas de nivi y las svdn en el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="EnProduccion"></param>
        /// <returns></returns>
        public bool UpdateEnProduccionSimulador(string NumeroPedido, bool EnProduccion)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'M');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_enproduccion", EnProduccion);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del nivel de servicio y estado simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="NivelServicioEstado"></param>
        /// <param name="NivelServicioEstimado"></param>
        /// <param name="NivelServicioReal"></param>
        /// <param name="NivelServicioTipo"></param>
        /// <returns></returns>
        public bool UpdateNivelServicioSimulador(string NumeroPedido, bool NivelServicioEstado, decimal NivelServicioEstimado, decimal NivelServicioReal, string NivelServicioTipo)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'N');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_nivelservicioestado", NivelServicioEstado);
                db.SetParameterValue(commandPedidosCliente, "i_nivelservicioestimado", NivelServicioEstimado);
                db.SetParameterValue(commandPedidosCliente, "i_nivelservicioreal", NivelServicioReal);
                db.SetParameterValue(commandPedidosCliente, "i_nivelserviciotipo", NivelServicioTipo);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del orden  de un pedido para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public bool UpdateOrdenSimulador(string NumeroPedido, int Orden)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'O');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_orden", Orden);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado procesado del pedido para el simulador.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateProcesadoSimulador(string NumeroPedido, bool Procesado)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'P');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_procesado", Procesado);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado de los pedidos que se encuentran bloqueados por nivel de servicio y por desmanteladora por camapaña actual.
        /// </summary>
        /// <returns></returns>
        public bool UpdateBloqueadosNivelServicio()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'R');

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado de los pedidos que se encuentran excluidos del procesamiento por camapaña actual.
        /// </summary>
        /// <returns></returns>
        public bool UpdateBloqueadosExcluidos()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'S');

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado de los pedidos que se encuentran bloqueados por cartera.
        /// </summary>
        /// <returns></returns>
        public bool UpdateBloqueadosCartera()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'T');

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del mes de un pedido
        /// </summary>
        /// <param name="Numero"></param>
        /// <param name="Mes"></param>
        /// <returns></returns>
        public bool UpdateMes(string Numero, string Mes)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_mes", Mes);
                db.SetParameterValue(commandPedidosCliente, "i_numero", Numero);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// /Realiza la actualizacion del valor precio catalogo de un pedido en SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="ValorPreCatalogo"></param>
        /// <param name="IVAPreCatalogo"></param>
        /// <returns></returns>
        public bool UpdateValorPrecioCatalogoPedidoSVDN(string NumeroPedido, decimal ValorPreCatalogo, decimal IVAPreCatalogo)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'V');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_valorpreciocatalogo", ValorPreCatalogo);
                db.SetParameterValue(commandPedidosCliente, "i_ivapreciocatalogo", IVAPreCatalogo);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado de la variable "procesado_cliente_historico	" a True
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public bool UpdateValorClienteHistorico(DateTime fecha)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'W');
                db.SetParameterValue(commandPedidosCliente, "i_fecha", fecha.ToShortDateString());

                dr = db.ExecuteReader(commandPedidosCliente);

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
        ///  Realiza el bloqueo temporal de los pedidos de un mailgroup por campaña
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Pedido"></param>
        /// <returns></returns>
        public bool BloquearPedidosxMailgroupSVDN(string Campana, string Pedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'X');
                db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numero", Pedido);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la actualizacion del estado de la variable "procesado_cliente_historico" a True
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdateProcesadoClienteHistorico(string NumeroPedido, string Nit)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'W');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);


                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la des-anulacion de un pedido.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateDesAnularPedido(string NumeroPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'Y');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la suma de un dia adicional a un pedido que se encuentra por anular.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdateDiaAdicionalPedido(string NumeroPedido, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AA");
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se adiciono 1 dia al Pedido Número:  " + NumeroPedido + "  . Acción Realizada por el Usuario: " + Usuario;

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
        /// Realiza la actualizacion del valor precio catalogo de un pedido en G&G y en SVDN.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Valor"></param>
        /// <param name="IVA"></param>
        /// <returns></returns>
        public bool UpdateValoresPrecioCatalogo(string NumeroPedido, decimal Valor, decimal IVA)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AB");
                db.SetParameterValue(commandPedidosCliente, "i_valor", Valor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", IVA);
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Realiza la liberacion de pedidos por zona seleccionada de facturacion semanal.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool UpdateLiberarZonasPedidosFactSemanal(string Campana, string Zona)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AC");
                db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
                db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// GAVL 11/04/2014 LIBERA LOS PEDIDOS QUE ESTEN INTERBLOQUEADOS 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateLiberarPedidosInterbloqueados(string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AH");

                dr = db.ExecuteReader(commandPedidosCliente);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó una actualización de liberación de pedidos interbloqueados por el Usuario: " + Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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
        /// Actualiza la ciudad de despacho de un pedido.
        /// </summary>
        /// <param name="CiudadDespacho"></param>
        /// <returns></returns>
        public bool UpdateCiudadDespacho(string CiudadDespacho)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AI");
                db.SetParameterValue(commandPedidosCliente, "i_codciudaddespacho", CiudadDespacho);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// SIESA: actualiza datos del pedido despues de enviado a siesa.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool UpdatePedidoEnSiesa(string NumeroPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AJ");
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Elimina todos los pedidos de la tabla temporal
        /// </summary>
        /// <returns></returns>
        public bool DeleteTemporal()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'A');

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Elimina todos los pedidos con premios de la tabla temporal
        /// </summary>
        /// <returns></returns>
        public bool DeletePremiosTemporal()
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'D');

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Elimina todos los pedidos de la tabla temporal de una campaña y una zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public bool DeleteTemporalxZonaxCampana(string Zona, string Campana)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'B');
                db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
                db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Elimina un pedido especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletexNumeroPedido(string NumeroPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'C');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Elimina un pedido de premio temporal especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletePedidoPremioTemporal(string NumeroPedido)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'E');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// Elimina un pedido de premio temporal especifico por numero, tipo query y id articulo.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="IdArticulo"></param>
        /// <param name="TipoQuery"></param>
        /// <returns></returns>
        public bool DeletePedidoPremioTemporalSimple(string NumeroPedido, int IdArticulo, string TipoQuery)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'D');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'F');
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
                db.SetParameterValue(commandPedidosCliente, "i_idarticulopremio", IdArticulo);
                db.SetParameterValue(commandPedidosCliente, "i_tipoquery", TipoQuery);

                dr = db.ExecuteReader(commandPedidosCliente);

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
        /// --Lista todos los pedidos de una empresaria por una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaxCampanaxCatalogo(string Nit, string Campana, string Catalogo)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'W');
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_catalogo", Catalogo);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// --Lista un pedido especifico de un cliente x camapana x catalogo
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListxNitxCampanaxCatalogo(string Nit, string Campana, string Catalogo)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'X');
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_catalogo", Catalogo);

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);
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
        /// Lista todos los pedidos de una empresaria por una campaña.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresaria(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'Y');
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista el encabezado de un pedido por numero.
        /// </summary>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListEncabezadoPedidoxNumero(string Numero)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", 'Z');
            db.SetParameterValue(commandPedidosCliente, "i_numero", Numero);

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);
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
        /// Lista los pedidos para sumarle el valor del felte luego que estan en produccion.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaSumarFlete(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AB");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyFlete(dr);

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
        /// Lista los pedidos bloqueados de algun tipo de catalogo nivi.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosBloqueados(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AC");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyCatalogos(dr);

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
        /// Lista los pedidos especificos de un cliente
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxNitxCampana(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AD");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyCatalogos(dr);

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
        /// Lista los pedidos de una empresaria por una campaña del catalogo outlet y de hogar.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresariaOuletHogar(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AE");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos del catalogo nivi para procesar por zona y campaña.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosProcesarNivi(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AF");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyCatalogos(dr);

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
        /// lista todos los Pedidos de una gerente regional por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteRegional(string codvendedor, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RP");
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", codvendedor);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCNDIV(dr);
                    //GetPedidosCliente
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
        /// Lista los pedidos de una empresaria por una campaña del catalogo outlet y de hogar para el simulador.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresariaOuletHogarSimulador(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AH");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos no bloqueados que corresponden a una zona y una campaña para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaNoBloqueadoSimulador(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AI");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos bloqueados de algun tipo de catalogo nivi.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosBloqueadosSimulador(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AJ");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyCatalogos(dr);

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
        /// Lista los pedidos especificos de un cliente para el simulador
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxNitxCampanaSimulador(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AK");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyCatalogos(dr);

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
        /// Lista los pedidos correspondientes a una zona y una campaña para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaSimulador(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AL");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos correspondientes a una zona y una campaña y por orden asignado para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrdenSimulador(string Zona, string Campana, int Orden)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AM");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_orden", Orden);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos correspondientes a una zona y una campaña ordenados por las reglas asignadas para el simulador.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxZonaxCampanaxOrdenProcesadoSimulador(string Zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AN");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// lista todos los Pedidos de una gerente de zona por una campaña facturados.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        ///  public List<PedidosClienteInfo> List()
        public List<PedidosClienteInfo> ListxGerenteZonaFacturados(string Zona, string Campana, string Lider, string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AO");
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_idlider", Lider);
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosFacturados(dr);

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
        /// lista todos los Pedidos de una gerente de zona por una campaña facturados.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaFacturadosEc(string Vendedor, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AO");
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", Vendedor);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteFacturadosEc(dr);

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
        /// lista todos los Pedidos Facturados de una gerente regional por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteRegionalFacturados(string CedulaRegional, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AP");
            db.SetParameterValue(commandPedidosCliente, "i_nit", CedulaRegional);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Muestra el resumen de los valores NETO y flete+iva de una campaña y un vendedor de los pedidos facturados y sin facturar.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxResumenTotalPedidos(string Vendedor, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AQ");
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", Vendedor);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetResumenPedidosCliente(dr);

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
        /// Trae los pedidos de los mailgroups activos para facturar
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosActivosFacturar()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AR");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosActivosFacturar(dr);


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
        ///  Consulta el nivel de servicio resultado del procesamiento
        /// </summary>
        /// <returns></returns>
        public PedidosClienteInfo ListxTotalNivelServicio()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AS");

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetTotalNivelServicio(dr);
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
        /// Consulta las empresarias que ganaron premio de bienvenida
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxTotalEmpresariasNuevas()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AT");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetTotalEmpresariasNuevas(dr);

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
        ///  Consulta la cantidad de fletes asignados despues del procesamiento
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxTotalFletesAsignados()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AU");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetTotalFletesAsignado(dr);

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
        /// lista el total de pedidos sin facturar
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxTotalPedidosProcesados()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AV");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetTotalPedidosProcesados(dr);

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
        /// El resumen de pedidos para una gerente regional
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxResumenTotalPedidosGerenteRegional(string CedulaRegional, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AX");
            db.SetParameterValue(commandPedidosCliente, "i_nit", CedulaRegional);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetResumenPedidosCliente(dr);

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
        ///  lista los pedidos detallados para exportar a excel o pdf
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosExportar(string Vendedor)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AY");
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", Vendedor);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosExportar(dr);

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
        /// lista un pedido para saber en que mes se encuentra.
        /// </summary>
        /// <returns></returns>
        public PedidosClienteInfo ListPedidoConsultarMes()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "AZ");

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);
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
        ///  lista todos los pedidos de todos los mailgroup x campaña asin bloqueos y sin procesar.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTodosPedidoSinProcesarSinBloqueo()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BA");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// lista los pedidos de un cliente facturados para saber si se cobra flete
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxNitxCampanaPedidosGYG(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BB");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnly(dr);

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
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidos(string Campana, string zona)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BC");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", zona);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// Lista la informacion de los pedidos para el modulo de SAC.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosSAC(string Nit, string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BD");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);



            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosSAC(dr);

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
        /// GAVL Sobrecarga para buscar los pedidos  con parametro de zona
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosSAC(string Nit, string NumeroPedido, string Zona)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BD");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
            db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosSAC(dr);

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
        /// Lista los pedidos anulados
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnulados(string Campana, string zona)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BE");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", zona);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosAnulados(dr);

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

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public List<PedidosClienteInfo> PedidosProcesadosClienteHistorico()
        //{
        //    db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
        //    db.SetParameterValue(commandPedidosCliente, "i_option", "BF");

        //    List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

        //    IDataReader dr = null;

        //    PedidosClienteInfo m = null;

        //    try
        //    {
        //        dr = db.ExecuteReader(commandPedidosCliente);

        //        while (dr.Read())
        //        {
        //            m = Factory.GetPedidosProcesadosClienteHistorico(dr);

        //            col.Add(m);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

        //        bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

        //        if (rethrow)
        //        {
        //            throw;
        //        }
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }

        //    return col;
        //}

        /// <summary>
        /// Lista todos los pedidos de una empresaria por una campaña sin procesar.
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxEmpresariaSinProcesar(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BG");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos que se encuentran en un estado que no esten bloqueados de una campaña.
        /// </summary>
        /// <param name="EstadoPedido"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEstadoPedido(int EstadoPedido, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BJ");
            db.SetParameterValue(commandPedidosCliente, "i_esp_id", EstadoPedido);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteOnlyCatalogos(dr);

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
        /// Lista todos los pedidos de una empresaria de zona por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxNitFacturados(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BK");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteFacturaEmpresariaEc(dr);

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
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana x Empresaria
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosxEmpresaria(string Campana, string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BL");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// Lista los pedidos anulados de una empresaria.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosxNit(string Campana, string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BU");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosAnulados(dr);

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
        /// lista todos los Pedidos de un lider de zona por una campaña.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxLider(string IdLider, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RX");
            db.SetParameterValue(commandPedidosCliente, "i_idlider", IdLider);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosReservados(dr);

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
        /// lista todos los Pedidos de un lider x zona por una campaña facturados.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosFacturadosLider(string IdLider, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BO");
            db.SetParameterValue(commandPedidosCliente, "i_idlider", IdLider);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos anulados de un lider.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosLider(string Campana, string IdLider)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BP");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
                db.SetParameterValue(commandPedidosCliente, "i_idlider", IdLider);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosAnulados(dr);

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
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una campana de un lider.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdLider"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosLider(string Campana, string IdLider)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BQ");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_idlider", IdLider);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// lista todos los Pedidos de una empresaria por una campaña, para el portal de empresarias.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaPortal(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BR");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista todos los pedidos de una empresaria por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaFacturados(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BS");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora de una empresaria.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosxEmpresariaPortal(string Campana, string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BT");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        ///  Lista los pedidos anulados de una empresaria del portal.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosxEmpresariaPortal(string Campana, string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BU");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// lista los pedidos detallados de una empresaria para exportar a excel o pdf
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosExportarxNit(string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BX");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosExportar(dr);

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
        /// Lista todos los pedidos de una empresaria por una campaña facturados en G&G.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxNitFacturadosEmpresarias(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BY");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista todos los pedidos sin facturar una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoSinFacturar(string Nit, string Campana, string Catalogo)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "BZ");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_catalogo", Catalogo);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista todos los pedidos en reserva en linea sin facturar una campaña x catalogo.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoEnReservaxCampanaxCatalogo(string Nit, string Campana, string Catalogo)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RA");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_catalogo", Catalogo);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Valida si existe un pedido borrador en SVDN.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoBorradorSVDN(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RB");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// -Lista todos los pedidos en reserva guardados por una gerente.
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservados(string zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RC");
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Lista todos los pedidos sin facturar una campaña x catalogo de la reserva y como borrador.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoSinFacturarxReserva(string Nit, string Campana, string Catalogo, string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RD");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_catalogo", Catalogo);
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista todos los pedidos sin facturar una campaña x catalogo y como borrador para reservar.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <param name="Catalogo"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoSinFacturarxParaReservar(string Nit, string Campana, string Catalogo, string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RE");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_catalogo", Catalogo);
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista la fecha de cierre de un pedido para la devolucion en linea.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListFechaCierreDevolucion(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RF");
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetFechaCierrePedido(dr);
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
        /// Lista todos los pedidos en reserva x campaña.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosReservados(string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RG");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Lista todos los pedidos en reserva de una empresaria especifica.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxEmpresariaReservados(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RH");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Lista un pedido de reserva en linea de la campaña actual.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public PedidosClienteInfo ListxGerenteZonaReservadosCPActual(string Nit)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RI");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReserva(dr);
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
        /// Lista todos los pedidos anulados categorizados.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListTodosPedidosAnulados()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RJ");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesadosAnulados(dr);

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
        /// Lista todos los pedidos proximos a vencer para anular en el dia actual.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosProximosAnular()
        {
            commandPedidosCliente.CommandTimeout = 600;
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RK");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Lista todos los pedidos proximos a vencer para anular en el dia actual BORRADOR.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosProximosAnularBorrador()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RO");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Lista todos los pedidos para cambio de campaña.
        /// </summary>
        /// <param name="CampanaActual"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidosCambioCampana(string CampanaActual)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RSS");
            db.SetParameterValue(commandPedidosCliente, "i_campana", CampanaActual);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// -Lista todos los pedidos en reserva guardados por una Lider.
        /// </summary>
        /// <param name="Lider"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosxLider(string Lider, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RL");
            db.SetParameterValue(commandPedidosCliente, "i_idlider", Lider);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Consulta si un cliente realizo un pedido en la campaña.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxPedidoxNitxCampana(string Nit, string Campana, string NumeroPedidoCreado)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RM");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedidoCreado);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Reporte de pedidos digitados por servicio al cliente.
        /// </summary>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxReportePedidosCCN()
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RN");

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetReportePedidosCCN(dr);

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
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista.
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportista(string zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RT");
            db.SetParameterValue(commandPedidosCliente, "i_zona", zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista x Divisional.
        /// </summary>
        /// <param name="CedulaDivisional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportistaxDivisional(string CedulaDivisional, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RTD");
            db.SetParameterValue(commandPedidosCliente, "i_idlider", CedulaDivisional);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// Lista todos los pedidos de una gerente de zona por una campaña facturados en G&G para Zona Maestra.
        /// </summary>
        /// <param name="Zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaFacturadosZonaMaestra(string ZonaMaestra, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SB");
            db.SetParameterValue(commandPedidosCliente, "i_zona", ZonaMaestra);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora para Zona Maestra.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="ZonaMaestra"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosZonaMaestra(string Campana, string ZonaMaestra)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SC");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_zona", ZonaMaestra);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// Lista los pedidos anulados para Zona Maestra.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="ZonaMaestra"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosZonaMaestra(string Campana, string ZonaMaestra)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SD");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_zona", ZonaMaestra);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// Lista la informacion de los pedidos para el modulo de SAC para una Zona Maestra.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <param name="ZonaMestra"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosSACZonaMaestra(string Nit, string NumeroPedido, string ZonaMestra)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SE");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);
            db.SetParameterValue(commandPedidosCliente, "i_zona", ZonaMestra);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosSAC(dr);

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
        /// Lista todos los pedidos en reserva guardados por una gerente para Zona Maestra.
        /// </summary>
        /// <param name="ZonaMaestra"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosZonaMaestra(string ZonaMaestra, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SF");
            db.SetParameterValue(commandPedidosCliente, "i_zona", ZonaMaestra);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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

        #region DESMANTELADORA

        /// <summary>
        /// Realiza Actualizacion de los pedido con Empresaria estado Desmantelada.
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Nit"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool UpdateEstadoDesmanteladoPedido(string NumeroPedido, string Nit, string Zona, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'U');
                db.SetParameterValue(commandPedidosCliente, "i_option", "AE");
                db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
                db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Actualizacion del pedido Número:  " + NumeroPedido + " por empresaria con Estado Desmantelada. Acción Realizada por el Usuario: " + Usuario;

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
        ///  Realiza liberacion del pedido con Empresaria estado Desmantelada
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool LiberaEstadoDesmanteladoPedido(string NumeroPedido, string Zona, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", "U");
                db.SetParameterValue(commandPedidosCliente, "i_option", "AF");
                db.SetParameterValue(commandPedidosCliente, "i_zona", Zona);
                db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Liberacion del pedido Número:  " + NumeroPedido + " por empresaria con Estado Desmantelada. Acción Realizada por el Usuario: " + Usuario;

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
        /// GAVL 31/03/2014 PEDIDOS RESERVARDOS  CON BLOQUEO DE DESMANTELADORAS
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosDesmanteladora(string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RQ");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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

        #region Anula Todos los pedidos Borrador
        /// <summary>
        /// Anula todos los pedidos borrador a la fecha-hora Actual
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateAnulaTodosPedidosBo(string Usuario, string motivo, string codmotivo)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", "U");
                db.SetParameterValue(commandPedidosCliente, "i_option", "AG");
                db.SetParameterValue(commandPedidosCliente, "i_motivo", motivo);
                db.SetParameterValue(commandPedidosCliente, "i_codmotivo", codmotivo);
                db.SetParameterValue(commandPedidosCliente, "i_NombreAnulo", Usuario);

                dr = db.ExecuteReader(commandPedidosCliente);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se Anularón todos los pedidos Borrador. Acción Realizada por el Usuario: " + Usuario;

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
        #endregion

        #region Busca Pedidos por Mes para anular
        public PedidosClienteInfo ListPedidosxMesAnular(string numeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RS");
            db.SetParameterValue(commandPedidosCliente, "i_numero", numeroPedido);

            IDataReader dr = null;

            PedidosClienteInfo m = new PedidosClienteInfo();

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);
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

        #region Asistentes
        /// <summary>
        /// GAVL Lista todos los pedidos en reserva guardados por los ASISTENTES
        /// </summary>
        /// <param name="codvendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosxAsistente(string codvendedor, string Campana)
        {
            commandPedidosCliente.CommandTimeout = 600;
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RT");
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", codvendedor);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCNDIV(dr);
                    //GetPedidosCliente
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
        /// lista todos los Pedidos Facturados de una gerente regional por una campaña.
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxAsistenteFacturados(string CedulaRegional, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RU");
            db.SetParameterValue(commandPedidosCliente, "i_nit", CedulaRegional);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos retenidos por cartera, nivel de servicio, desmanteladora por Asistentes
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosxAsistentes(string Campana, string IdVendedor)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RV");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", IdVendedor);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// --Lista los pedidos anulados X ASISTENTE
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="IdVendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosXAsistente(string Campana, string IdVendedor)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RW");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_vendedor", IdVendedor);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// obtiene un pedido de los pedidos de siesa por el numero
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosClienteInfo ObtenerunPedidoSiesa(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SG");
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);


            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                if (dr.Read())
                {
                    m = Factory.GetPedidosAnularSiesa(dr);
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
        /// obtiene un detalle pedido de los pedidos de siesa por el numero
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public PedidosDetallesSIESA_SVDNinfo ObtenerunPedidoDetalleSiesa(string NumeroPedido)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SH");
            db.SetParameterValue(commandPedidosCliente, "i_numero", NumeroPedido);


            IDataReader dr = null;

            PedidosDetallesSIESA_SVDNinfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                if (dr.Read())
                {
                    m = Factory.GetPedidosDetalleSIESA_SVDN(dr);
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

        //--SIESA SUBZONAS

        /// <summary>
        /// lista todos los Pedidos de una gerente de subzona por una campaña facturados.
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteSubZonaFacturados(string zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "A1");
            db.SetParameterValue(commandPedidosCliente, "i_zona", zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
        /// Lista los pedidos retenidos por cartera, nivel de servicio, por subzona, desmanteladora de una campana
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosRetenidosSubzona(string Campana, string zona)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "B1");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_zona", zona);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// Lista los pedidos anulados por subzona
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosAnuladosSubzona(string Campana, string zona)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "B2");
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);
            db.SetParameterValue(commandPedidosCliente, "i_zona", zona);


            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosProcesados(dr);

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
        /// -Lista todos los pedidos en reserva guardados por una gerente subzona.
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteSubZonaReservados(string zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "R2");
            db.SetParameterValue(commandPedidosCliente, "i_zona", zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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
        /// -Lista todos los pedidos en reserva guardados por una gerente SIN Transportista. por subzona
        /// </summary>
        /// <param name="zona"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListxGerenteZonaReservadosSinTransportistasubzona(string zona, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "R1");
            db.SetParameterValue(commandPedidosCliente, "i_zona", zona);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosClienteReservaCCN(dr);

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


        ////COSAS NUEVAS JUTA
        /// <summary>
        /// Realiza el registro de un encabezado de pedido de cliente. dependiendo de la bodega asigna el prefijo
        /// </summary>
        /// <param name="item"></param>
        public string InsertBODEGAPREFIJO(PedidosClienteInfo item,string bodega)
        {
            string strid = "";

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPedidosCliente, "i_operation", 'I');
                db.SetParameterValue(commandPedidosCliente, "i_option", 'A');

                db.SetParameterValue(commandPedidosCliente, "i_numero", 0); //Se debe inicializar la variable con 0.
                db.SetParameterValue(commandPedidosCliente, "i_mes", item.Mes);
                db.SetParameterValue(commandPedidosCliente, "i_fecha", item.Fecha);
                db.SetParameterValue(commandPedidosCliente, "i_anulado", item.Anulado);
                db.SetParameterValue(commandPedidosCliente, "i_espera", item.Espera);
                db.SetParameterValue(commandPedidosCliente, "i_despacho", item.Despacho);
                db.SetParameterValue(commandPedidosCliente, "i_nit", item.Nit);
                db.SetParameterValue(commandPedidosCliente, "i_vendedor", item.Vendedor);
                db.SetParameterValue(commandPedidosCliente, "i_iva", item.IVA);
                db.SetParameterValue(commandPedidosCliente, "i_valor", item.Valor);
                db.SetParameterValue(commandPedidosCliente, "i_descuento", item.Descuento);
                db.SetParameterValue(commandPedidosCliente, "i_fechacreacion", item.FechaCreacion);
                db.SetParameterValue(commandPedidosCliente, "i_claveusuario", item.ClaveUsuario);
                db.SetParameterValue(commandPedidosCliente, "i_zona", item.Zona);
                db.SetParameterValue(commandPedidosCliente, "i_codigo_numeracion", item.CodigoNumeracion);
                db.SetParameterValue(commandPedidosCliente, "i_transmitido", item.Transmitido);
                db.SetParameterValue(commandPedidosCliente, "i_campana", item.Campana);
                db.SetParameterValue(commandPedidosCliente, "i_numeroenvio", item.NumeroEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_nofacturado", item.NoFacturado);
                db.SetParameterValue(commandPedidosCliente, "i_facturar", item.Facturar);
                db.SetParameterValue(commandPedidosCliente, "i_codtipo", item.CodTipo);
                db.SetParameterValue(commandPedidosCliente, "i_devol", item.Devol);
                db.SetParameterValue(commandPedidosCliente, "i_factura", item.Factura);
                db.SetParameterValue(commandPedidosCliente, "i_orden", item.Orden);
                db.SetParameterValue(commandPedidosCliente, "i_procesado", item.Procesado);
                db.SetParameterValue(commandPedidosCliente, "i_ivapreciocatalogo", item.IVAPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_valorpreciocatalogo", item.ValorPrecioCat);
                db.SetParameterValue(commandPedidosCliente, "i_catalogo", item.Codigo);
                db.SetParameterValue(commandPedidosCliente, "i_generapremios", item.GeneraPremios);
                db.SetParameterValue(commandPedidosCliente, "i_idlider", item.IdLider);
                db.SetParameterValue(commandPedidosCliente, "i_reserva", item.Reserva);
                db.SetParameterValue(commandPedidosCliente, "i_borrador", item.Borrador);
                db.SetParameterValue(commandPedidosCliente, "i_fechacierreborrador", item.FechaCierreBorrador);
                db.SetParameterValue(commandPedidosCliente, "i_portal", item.Portal);
                db.SetParameterValue(commandPedidosCliente, "i_tipoenvio", item.TipoEnvio);
                db.SetParameterValue(commandPedidosCliente, "i_codciudaddespacho", item.CiudadDespacho);
                db.SetParameterValue(commandPedidosCliente, "i_factusemanal", item.FacturacionSemanal);
                db.SetParameterValue(commandPedidosCliente, "i_asistente", item.Asistente);
                //COMENTAR PARA QUE FUNCIONE PERU Y ECUADOR
                //db.SetParameterValue(commandPedidosCliente, "i_claseventa", item.Claseventa);               

                dr = db.ExecuteReader(commandPedidosCliente);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandPedidosCliente, "i_numero")).Trim();

                //****************************************************************************************************************************************
                //Si el perfil es de un usuario interno de nivi se debe guardar la auditoria.
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
                        objAuditoriaInfo.Proceso = "Se realizó la creación de Pedido Número: " + strid + " Campaña: " + item.Campana + " Cedula Empresaria: " + item.Nit + " Zona: " + item.Zona + " . Acción Realizada por el Usuario: " + item.Usuario;

                        objAuditoria.Insert(objAuditoriaInfo);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }
                    //-----------------------------------------------------------------------------------------------------------------------------                
                }
                //****************************************************************************************************************************************


            }
            catch (Exception ex)
            {
                strid = null;

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
            return strid;
        }






        /// JUTA
        /// 
        /// <summary>
        /// Lista pedido preventa
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>      
        /// <returns></returns>
        public PedidosClienteInfo ListxPedidoPreventa(string Nit, string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "RT");
            db.SetParameterValue(commandPedidosCliente, "i_nit", Nit);
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);                      

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);                    
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
        /// Lista los pedidos borrador para reserva masiva
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<PedidosClienteInfo> ListPedidosMasivo(string Campana)
        {
            db.SetParameterValue(commandPedidosCliente, "i_operation", 'S');
            db.SetParameterValue(commandPedidosCliente, "i_option", "SG");           
            db.SetParameterValue(commandPedidosCliente, "i_campana", Campana);

            List<PedidosClienteInfo> col = new List<PedidosClienteInfo>();

            IDataReader dr = null;

            PedidosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPedidosCliente);

                while (dr.Read())
                {
                    m = Factory.GetPedidosCliente(dr);

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
    }
}