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
    public class Kardex
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandKardex;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Kardex(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Kardex()
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
            commandKardex = db.GetStoredProcCommand("PRC_SVDN_KARDEX");

            db.AddInParameter(commandKardex, "i_operation", DbType.String);
            db.AddInParameter(commandKardex, "i_option", DbType.String);
            db.AddInParameter(commandKardex, "i_referencia", DbType.String);
            db.AddInParameter(commandKardex, "i_nombre_producto", DbType.String);
            db.AddInParameter(commandKardex, "i_tipo", DbType.Int32);
            db.AddInParameter(commandKardex, "i_subgrupo", DbType.String);
            db.AddInParameter(commandKardex, "i_unidad_de_medida", DbType.String);
            db.AddInParameter(commandKardex, "i_referencia_proveedor", DbType.String);
            db.AddInParameter(commandKardex, "i_stock_minimo", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_stock_maximo", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_precio_base_venta", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_precio_venta_1", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_precio_venta_2", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_precio_venta_3", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_ubicacion", DbType.String);
            db.AddInParameter(commandKardex, "i_nuevopbv", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_fechanuevopbv", DbType.DateTime);
            db.AddInParameter(commandKardex, "i_grupo", DbType.String);
            db.AddInParameter(commandKardex, "i_departamento", DbType.String);
            db.AddInParameter(commandKardex, "i_ccostos", DbType.String);
            db.AddInParameter(commandKardex, "i_referenciabase", DbType.String);
            db.AddInParameter(commandKardex, "i_equivalebase", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_ensamblado", DbType.Int32);
            db.AddInParameter(commandKardex, "i_tipocosteo", DbType.Int32);
            db.AddInParameter(commandKardex, "i_visiblepos", DbType.Int32);
            db.AddInParameter(commandKardex, "i_manejolotes", DbType.Int32);
            db.AddInParameter(commandKardex, "i_foto", DbType.String);
            db.AddInParameter(commandKardex, "i_importado", DbType.Int32);
            db.AddInParameter(commandKardex, "i_codarancel", DbType.String);
            db.AddInParameter(commandKardex, "i_codunidad", DbType.String);
            db.AddInParameter(commandKardex, "i_preciouno", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_preciodos", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_preciotres", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_preciocuatro", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_peso", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_volumen", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_diametro", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_alto", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_ancho", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_largo", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_catalogo", DbType.String);
            db.AddInParameter(commandKardex, "i_codigobarras", DbType.String);
            db.AddInParameter(commandKardex, "i_agotado", DbType.Int32);
            db.AddInParameter(commandKardex, "i_creditopersonal", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_detal", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_mayorista", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_libre", DbType.Decimal);
            db.AddInParameter(commandKardex, "i_categoria", DbType.String);
            db.AddInParameter(commandKardex, "i_imagen", DbType.String);
            db.AddInParameter(commandKardex, "i_proveedor", DbType.String);
            db.AddInParameter(commandKardex, "i_uni_negocio", DbType.String);
            db.AddInParameter(commandKardex, "i_str_query", DbType.String);
            db.AddInParameter(commandKardex, "i_codigocolor", DbType.String);
            db.AddInParameter(commandKardex, "i_codigotalla", DbType.String);
            db.AddInParameter(commandKardex, "i_plu", DbType.Int32);

            db.AddOutParameter(commandKardex, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandKardex, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Kardex

        /// <summary>
        /// Lista todos los kardex
        /// </summary>
        /// <returns></returns>
        public List<KardexInfo> List()
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'A');

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardex(dr);

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
        /// Lista todos los kardex de un catalogo especifico
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogo(string Catalogo)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'B');
            db.SetParameterValue(commandKardex, "i_catalogo", Catalogo);

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexCatalogo(dr);

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
        /// Lista todos los kardex del catalogo actual
        /// </summary>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoActual()
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'D');

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexCatalogo(dr);

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
        /// Consulta de los articulos por una referencia talla y color
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoTalla"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxArticuloxRefxTalxCol(string Referencia, string CodigoTalla, string CodigoColor, string Catalogo)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'E');
            db.SetParameterValue(commandKardex, "i_referencia", Referencia);
            db.SetParameterValue(commandKardex, "i_codigotalla", CodigoTalla);
            db.SetParameterValue(commandKardex, "i_codigocolor", CodigoColor);
            db.SetParameterValue(commandKardex, "i_catalogo", Catalogo);

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexSearch(dr);

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
        /// Lista el nombre de un producto por referencia.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public KardexInfo ListxNombrexReferencia(string Referencia)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'F');
            db.SetParameterValue(commandKardex, "i_referencia", Referencia);

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetNombreProducto(dr);
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
            TableMapping searchMapping = new TableMapping("PRC_SVDN_KARDEX", "Application.Enterprise.CommonObjects.KardexInfo");

            searchMapping.Fields.Add(new FieldMapping("kar.referencia", DbType.String, "REFERENCIA", "103"));
            searchMapping.Fields.Add(new FieldMapping("kar.nombre_producto", DbType.String, "NOMBRE PRODUCTO", "103"));

            return searchMapping;
        }

        /// <summary>
        /// Buscador de Articulos.
        /// </summary>
        /// <param Name="filter">parametros de filtro para la busqueda.</param>
        /// <returns>Lista de Articulos.</returns>
        public List<KardexInfo> ListSearch(string lstItem)
        {
            List<KardexInfo> res = new List<KardexInfo>();
            KardexInfo item = null;
            IDataReader dr = null;

            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'C');
            db.SetParameterValue(commandKardex, "i_str_query", lstItem);

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    item = Factory.GetKardexSearch(dr);

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
        /// Buscador de Articulos de Premios.
        /// </summary>
        /// <param Name="filter">parametros de filtro para la busqueda de premios.</param>
        /// <returns>Lista de Articulos.</returns>
        public List<KardexInfo> ListSearchPremios(string lstItem)
        {
            List<KardexInfo> res = new List<KardexInfo>();
            KardexInfo item = null;
            IDataReader dr = null;

            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'G');
            db.SetParameterValue(commandKardex, "i_str_query", lstItem);

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    item = Factory.GetKardexPremiosSearch(dr);

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
        /// Lista todos los kardex (referencias) del catalogo actual para el Outlet
        /// </summary>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoActualOutlet()
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'H');

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexCatalogo(dr);

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
        /// Lista todos los kardex (referencias) del catalogo seleccionado
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoPedidos(string Catalogo)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'I');
            db.SetParameterValue(commandKardex, "i_catalogo", Catalogo);

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexCatalogo(dr);

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
        /// Lista todos los kardex (referencias) del catalogo seleccionado x catalogo y x Referencia
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<KardexInfo> ListxCatalogoPedidosxReferencia(string Catalogo, string Referencia)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'J');
            db.SetParameterValue(commandKardex, "i_catalogo", Catalogo);
            db.SetParameterValue(commandKardex, "i_referencia", Referencia);

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexCatalogo(dr);

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
        /// Lista de referencias por catalogo especifico en MKT
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <param name="Referencia"></param>
        /// <returns></returns>
        public List<KardexInfo> ListReferenciasXCatalogoEspecificoMKT(string Catalogo)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'L');
            db.SetParameterValue(commandKardex, "i_catalogo", Catalogo);

            List<KardexInfo> col = new List<KardexInfo>();

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexCatalogoMKT(dr);

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
        /// Consulta de los articulos por una PLU
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxArticuloxPLU(int PLU)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'M');
            db.SetParameterValue(commandKardex, "i_plu", PLU);

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexSearch(dr);
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
        /// Consulta de los articulos por una PLU para ver valor catalogoplus
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxArticuloxPLUJUTA(int PLU)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'P');
            db.SetParameterValue(commandKardex, "i_plu", PLU);

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexSearch(dr);
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
        /// Consulta si exite el grupo de prodcuto de un articulo por un PLU para que sume al valor de descuento 
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxGrupoProductoxPLU(int PLU)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'N');
            db.SetParameterValue(commandKardex, "i_plu", PLU);

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexSearch(dr);
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
        /// Consulta si exite el articulo es agotado anunciado.
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxVisiblePOS(int PLU)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'O');
            db.SetParameterValue(commandKardex, "i_plu", PLU);

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardex(dr);
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
        /// Consulta de los articulos por una PLU
        /// </summary>
        /// <param name="PLU"></param>
        /// <returns></returns>
        public KardexInfo ListxArticuloxPLUExtensiones(int PLU)
        {
            db.SetParameterValue(commandKardex, "i_operation", 'S');
            db.SetParameterValue(commandKardex, "i_option", 'P');
            db.SetParameterValue(commandKardex, "i_plu", PLU);

            IDataReader dr = null;

            KardexInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandKardex);

                while (dr.Read())
                {
                    m = Factory.GetKardexSearchExtensiones(dr);
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


        #region Actualiza Unidad de Negocio Configuracion Descuentos NIVI Especial

        /// <summary>
        /// Actualiza campo unidadad de negocio Segun la referencia para Activa 50% NIVI ESPECIAL
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="UnidadNegocio"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizaUnidadXReferencia(string Referencia, string UnidadNegocio,string usuario)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandKardex, "i_operation", 'U');
                db.SetParameterValue(commandKardex, "i_option", 'A');

                db.SetParameterValue(commandKardex, "i_referencia", Referencia);
                db.SetParameterValue(commandKardex, "i_uni_negocio", UnidadNegocio);
                

                dr = db.ExecuteReader(commandKardex);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualizacion unidada de Negocio por Referencia  Nivi Especial, de la  Tabla KARDEX: Unidad: " + UnidadNegocio + ",Referencia: " + Referencia + ". Acción Realizada por el Usuario: " + usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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

        #endregion

        #endregion
    }
}