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
    public class ProductosCatalogo
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandProductosCatalogo;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ProductosCatalogo(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ProductosCatalogo()
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
            commandProductosCatalogo = db.GetStoredProcCommand("PRC_SVDN_CATALOGOSPRODUCTOS");

            db.AddInParameter(commandProductosCatalogo, "i_operation", DbType.String);
            db.AddInParameter(commandProductosCatalogo, "idcatalogo", DbType.String);
            db.AddInParameter(commandProductosCatalogo, "descripcion", DbType.String);
            db.AddInParameter(commandProductosCatalogo, "codubicacion", DbType.String);
            db.AddInParameter(commandProductosCatalogo, "referencia", DbType.String);
            db.AddInParameter(commandProductosCatalogo, "catalogo", DbType.String);
            db.AddInParameter(commandProductosCatalogo, "pagina", DbType.String);
            db.AddInParameter(commandProductosCatalogo, "preciocatalogo", DbType.Double);
                       
            db.AddOutParameter(commandProductosCatalogo, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandProductosCatalogo, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Productos de Catalogo

        /// <summary>
        /// Lista todos los productos del catalogo
        /// </summary>
        /// <returns></returns>
        public List<ProductosCatalogoInfo> List()
        {
            db.SetParameterValue(commandProductosCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandProductosCatalogo, "i_option", 'A');

            List<ProductosCatalogoInfo> col = new List<ProductosCatalogoInfo>();

            IDataReader dr = null;

            ProductosCatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProductosCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetProductosCatalogo(dr);

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
        /// Lista los productos de un catalogo de campaña especifico
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ProductosCatalogoInfo> ListxCatalogoCampana(string CatalogoCampana)
        {
            db.SetParameterValue(commandProductosCatalogo, "i_operation", 'S');
            db.SetParameterValue(commandProductosCatalogo, "i_option", 'B');
            db.SetParameterValue(commandProductosCatalogo, "i_campana", CatalogoCampana);

            List<ProductosCatalogoInfo> col = new List<ProductosCatalogoInfo>();

            IDataReader dr = null;

            ProductosCatalogoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandProductosCatalogo);

                while (dr.Read())
                {
                    m = Factory.GetProductosCatalogo(dr);

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
    }
}