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
    public class CatalogoInteres
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCatalogoInteres;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CatalogoInteres(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CatalogoInteres()
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
            commandCatalogoInteres = db.GetStoredProcCommand("PRC_SVDN_CATALOGOINTERES");

            db.AddInParameter(commandCatalogoInteres, "i_operation", DbType.String);
            db.AddInParameter(commandCatalogoInteres, "i_option", DbType.String);
            db.AddInParameter(commandCatalogoInteres, "i_cti_id", DbType.Int32);
            db.AddInParameter(commandCatalogoInteres, "i_cti_nombre", DbType.String);
            db.AddInParameter(commandCatalogoInteres, "i_cti_estado", DbType.Int32);

            db.AddOutParameter(commandCatalogoInteres, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCatalogoInteres, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Catalogo de Interes

        /// <summary>
        /// lista todos los catalogos de interes existentes activos.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInteresInfo> List()
        {
            db.SetParameterValue(commandCatalogoInteres, "i_operation", 'S');
            db.SetParameterValue(commandCatalogoInteres, "i_option", 'A');

            List<CatalogoInteresInfo> col = new List<CatalogoInteresInfo>();

            IDataReader dr = null;

            CatalogoInteresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCatalogoInteres);

                while (dr.Read())
                {
                    m = Factory.GetCatalogoInteres(dr);

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