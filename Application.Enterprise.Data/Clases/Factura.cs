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
    public class Factura
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandFactura;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Factura(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Factura()
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
            commandFactura = db.GetStoredProcCommand("PRC_SVDN_FACTURA");

            db.AddInParameter(commandFactura, "i_operation", DbType.String);
            db.AddInParameter(commandFactura, "i_option", DbType.String);
            db.AddInParameter(commandFactura, "i_numero", DbType.String);
            db.AddInParameter(commandFactura, "i_fecha_a", DbType.String);
            db.AddInParameter(commandFactura, "i_vencimiento", DbType.String);
            db.AddInParameter(commandFactura, "i_nit", DbType.String);
            db.AddInParameter(commandFactura, "i_vendedor", DbType.String);
            db.AddInParameter(commandFactura, "i_valor_a", DbType.String);
            db.AddInParameter(commandFactura, "i_descuento_b", DbType.String);
            db.AddInParameter(commandFactura, "i_codigoretencion", DbType.String);
            db.AddInParameter(commandFactura, "i_retefuente", DbType.String);
            db.AddInParameter(commandFactura, "i_anticipoiva", DbType.String);
            db.AddInParameter(commandFactura, "i_retencionica", DbType.String);
            db.AddInParameter(commandFactura, "i_iva", DbType.String);
            db.AddInParameter(commandFactura, "i_referencia", DbType.String);
            db.AddInParameter(commandFactura, "i_producto", DbType.String);
            db.AddInParameter(commandFactura, "i_valor", DbType.String);
            db.AddInParameter(commandFactura, "i_cantidad", DbType.String);
            db.AddInParameter(commandFactura, "i_descuento", DbType.String);
            db.AddInParameter(commandFactura, "i_tarifaiva", DbType.String);
            db.AddInParameter(commandFactura, "i_razon_social", DbType.String);
            db.AddInParameter(commandFactura, "i_direccion", DbType.String);
            db.AddInParameter(commandFactura, "i_ciudad", DbType.String);
            db.AddInParameter(commandFactura, "i_ciudadempresaria", DbType.String);
            db.AddInParameter(commandFactura, "i_telefonos", DbType.String);
            db.AddInParameter(commandFactura, "i_telefonodos", DbType.String);
            db.AddInParameter(commandFactura, "i_gerentezonal", DbType.String);
            db.AddInParameter(commandFactura, "i_unidad_de_medida", DbType.String);
            db.AddInParameter(commandFactura, "i_zona", DbType.String);
            db.AddInParameter(commandFactura, "i_nombrezona", DbType.String);
            db.AddInParameter(commandFactura, "i_codgereg", DbType.String);
            db.AddInParameter(commandFactura, "i_nombreuno", DbType.String);
            db.AddInParameter(commandFactura, "i_nombredos", DbType.String);
            db.AddInParameter(commandFactura, "i_apellidouno", DbType.String);
            db.AddInParameter(commandFactura, "i_apellidodos", DbType.String);
            db.AddInParameter(commandFactura, "i_codregion", DbType.String);
            db.AddInParameter(commandFactura, "i_nombreregion", DbType.String);
            db.AddInParameter(commandFactura, "i_bodega", DbType.String);
            db.AddInParameter(commandFactura, "i_campana", DbType.String);
            db.AddInParameter(commandFactura, "i_codigocolor", DbType.String);
            db.AddInParameter(commandFactura, "i_codigotalla", DbType.String);
            db.AddInParameter(commandFactura, "i_nomtalla", DbType.String);
            db.AddInParameter(commandFactura, "i_codubicacion", DbType.String);
            db.AddInParameter(commandFactura, "i_posicion", DbType.String);
            db.AddInParameter(commandFactura, "i_prefijo", DbType.String);
            db.AddInParameter(commandFactura, "i_desde", DbType.String);
            db.AddInParameter(commandFactura, "i_hasta", DbType.String);
            db.AddInParameter(commandFactura, "i_inicial", DbType.String);
            db.AddInParameter(commandFactura, "i_resolucion", DbType.String);
            db.AddInParameter(commandFactura, "i_fecha", DbType.String);
            db.AddInParameter(commandFactura, "i_numeropedido", DbType.String);
            db.AddInParameter(commandFactura, "i_nomcolor", DbType.String);
            db.AddInParameter(commandFactura, "i_cedula", DbType.String);
            db.AddInParameter(commandFactura, "i_telefonouno", DbType.String);
            db.AddInParameter(commandFactura, "i_telefono2", DbType.String);
            db.AddInParameter(commandFactura, "i_telefonotres", DbType.String);
            db.AddInParameter(commandFactura, "i_saldo", DbType.String);
            db.AddInParameter(commandFactura, "i_barrio", DbType.String);
            db.AddInParameter(commandFactura, "i_boletas", DbType.String);
            db.AddInParameter(commandFactura, "i_codestado", DbType.String);
            db.AddInParameter(commandFactura, "i_nombreestado", DbType.String);

            db.AddOutParameter(commandFactura, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandFactura, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Factura

        /// <summary>
        /// -Consulta una factura especifica por numero.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public List<FacturaInfo> ListxNumero(string NumeroFactura)
        {
            db.SetParameterValue(commandFactura, "i_operation", 'S');
            db.SetParameterValue(commandFactura, "i_option", 'A');
            db.SetParameterValue(commandFactura, "i_numero", NumeroFactura);

            List<FacturaInfo> col = new List<FacturaInfo>();

            IDataReader dr = null;

            FacturaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandFactura);

                while (dr.Read())
                {
                    m = Factory.GetFactura(dr);

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
        /// Consulta el detalle de una factura especifica por numero.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public List<FacturaInfo> ListDetallexNumero(string NumeroFactura)
        {
            db.SetParameterValue(commandFactura, "i_operation", 'S');
            db.SetParameterValue(commandFactura, "i_option", 'B');
            db.SetParameterValue(commandFactura, "i_numero", NumeroFactura);

            List<FacturaInfo> col = new List<FacturaInfo>();

            IDataReader dr = null;

            FacturaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandFactura);

                while (dr.Read())
                {
                    m = Factory.GetFactura(dr);

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
        /// Obtiene la lista de facturas por campaña y por nit de un cliente.
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public List<FacturaInfo> ListFacturasxCampanaxNit(string Campana, string Nit)
        {
            db.SetParameterValue(commandFactura, "i_operation", 'S');
            db.SetParameterValue(commandFactura, "i_option", 'C');
            db.SetParameterValue(commandFactura, "i_campana", Campana);
            db.SetParameterValue(commandFactura, "i_nit", Nit);

            List<FacturaInfo> col = new List<FacturaInfo>();

            IDataReader dr = null;

            FacturaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandFactura);

                while (dr.Read())
                {
                    m = Factory.GetFactura(dr);

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
        /// Obtiene el numero de pedido de una factura
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public string ListNumeroPedidoxFactura(string NumeroFactura)
        {
            db.SetParameterValue(commandFactura, "i_operation", 'S');
            db.SetParameterValue(commandFactura, "i_option", 'D');
            db.SetParameterValue(commandFactura, "i_numero", NumeroFactura);

            IDataReader dr = null;

            string m = "";

            try
            {
                dr = db.ExecuteReader(commandFactura);

                while (dr.Read())
                {
                    m = dr["numeropedido"].ToString();
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
        /// Obtiene el nombre de la factura en archivo XML.
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public string ListNombreFacturaXML(string NumeroFactura)
        {
            db.SetParameterValue(commandFactura, "i_operation", 'S');
            db.SetParameterValue(commandFactura, "i_option", 'F');
            db.SetParameterValue(commandFactura, "i_numero", NumeroFactura);

            IDataReader dr = null;

            string m = "";

            try
            {
                dr = db.ExecuteReader(commandFactura);

                while (dr.Read())
                {
                    m = dr["FacturaXML"].ToString();
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
        /// informe facturas
        /// </summary>
        /// <param name="NumeroFactura"></param>
        /// <returns></returns>
        public DataTable informefacturasJuta(string zona, string campana)
        {
            commandFactura = db.GetStoredProcCommand("PRC_SVDN_INF_FACTURAS");
            db.AddInParameter(commandFactura, "zona", DbType.String);
            db.AddInParameter(commandFactura, "campana", DbType.String);
            db.SetParameterValue(commandFactura, "zona", zona);
            db.SetParameterValue(commandFactura, "campana", campana);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandFactura);

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

                if (rethrow)
                {
                    throw;
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }

            return dt;
        }


        #endregion
    }
}