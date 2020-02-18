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
    public class Talla
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTalla;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Talla(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Talla()
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
            commandTalla = db.GetStoredProcCommand("PRC_SVDN_TALLA");

            db.AddInParameter(commandTalla, "i_operation", DbType.String);
            db.AddInParameter(commandTalla, "i_option", DbType.String);
            db.AddInParameter(commandTalla, "i_codtalla", DbType.String);
            db.AddInParameter(commandTalla, "i_descripcion", DbType.String);
            db.AddInParameter(commandTalla, "i_referencia", DbType.String);
            db.AddInParameter(commandTalla, "i_codcolor", DbType.String);
            db.AddInParameter(commandTalla, "i_catalogo", DbType.String);

            db.AddOutParameter(commandTalla, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTalla, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Talla

        /// <summary>
        /// Lista todos las Tallas
        /// </summary>
        /// <returns></returns>
        public List<TallaInfo> List()
        {
            db.SetParameterValue(commandTalla, "i_operation", 'S');
            db.SetParameterValue(commandTalla, "i_option", 'A');

            List<TallaInfo> col = new List<TallaInfo>();

            IDataReader dr = null;

            TallaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTalla);

                while (dr.Read())
                {
                    m = Factory.GetTalla(dr);

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
        /// Lista una talla por referencia y color de articulo.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        public List<TallaInfo> ListxReferenciaxColor(string Referencia, string CodigoColor, string Catalogo)
        {
            db.SetParameterValue(commandTalla, "i_operation", 'S');
            db.SetParameterValue(commandTalla, "i_option", 'B');
            db.SetParameterValue(commandTalla, "i_referencia", Referencia);
            db.SetParameterValue(commandTalla, "i_codcolor", CodigoColor);
            db.SetParameterValue(commandTalla, "i_catalogo", Catalogo);

            List<TallaInfo> col = new List<TallaInfo>();

            IDataReader dr = null;

            TallaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTalla);

                while (dr.Read())
                {
                    m = Factory.GetTalla(dr);

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
        /// Lista una talla por referencia y color de articulo para el catalogo outlet.
        /// </summary>
        /// <param name="Referencia"></param>
        /// <param name="CodigoColor"></param>
        /// <returns></returns>
        public List<TallaInfo> ListxReferenciaxColorOutlet(string Referencia, string CodigoColor, string Catalogo)
        {
            db.SetParameterValue(commandTalla, "i_operation", 'S');
            db.SetParameterValue(commandTalla, "i_option", 'C');
            db.SetParameterValue(commandTalla, "i_referencia", Referencia);
            db.SetParameterValue(commandTalla, "i_codcolor", CodigoColor);
            db.SetParameterValue(commandTalla, "i_catalogo", Catalogo);

            List<TallaInfo> col = new List<TallaInfo>();

            IDataReader dr = null;

            TallaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTalla);

                while (dr.Read())
                {
                    m = Factory.GetTalla(dr);

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