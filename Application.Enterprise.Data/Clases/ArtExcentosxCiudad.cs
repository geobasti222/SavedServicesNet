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
    public class ArtExcentosxCiudad
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandArtExcentosxCiudad;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ArtExcentosxCiudad(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ArtExcentosxCiudad()
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
            commandArtExcentosxCiudad = db.GetStoredProcCommand("PRC_SVDN_ARTEXENTOSXCIUDAD");

            db.AddInParameter(commandArtExcentosxCiudad, "i_operation", DbType.String);
            db.AddInParameter(commandArtExcentosxCiudad, "i_option", DbType.String);
            db.AddInParameter(commandArtExcentosxCiudad, "i_codciudad", DbType.String);
            db.AddInParameter(commandArtExcentosxCiudad, "i_plu", DbType.Int32);
            db.AddInParameter(commandArtExcentosxCiudad, "i_referencia", DbType.String);
            db.AddInParameter(commandArtExcentosxCiudad, "i_estado", DbType.Boolean);

            db.AddOutParameter(commandArtExcentosxCiudad, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandArtExcentosxCiudad, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de ArtExcentosxCiudad

        /// <summary>
        /// Lista todos los articulos exentos x ciudad.
        /// </summary>
        /// <returns></returns>
        public List<ArtExcentosxCiudadInfo> List()
        {
            db.SetParameterValue(commandArtExcentosxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandArtExcentosxCiudad, "i_option", 'A');

            List<ArtExcentosxCiudadInfo> col = new List<ArtExcentosxCiudadInfo>();

            IDataReader dr = null;

            ArtExcentosxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandArtExcentosxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetArtExcentosxCiudad(dr);

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
        /// Lista todos los articulos exentos x ciudad.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <param name="Plu"></param>
        /// <returns></returns>
        public ArtExcentosxCiudadInfo ListxCiudadxPlu(string CodigoCiudad, int Plu)
        {
            db.SetParameterValue(commandArtExcentosxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandArtExcentosxCiudad, "i_option", 'B');
            db.SetParameterValue(commandArtExcentosxCiudad, "i_codciudad", CodigoCiudad);
            db.SetParameterValue(commandArtExcentosxCiudad, "i_plu", Plu);

            IDataReader dr = null;

            ArtExcentosxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandArtExcentosxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetArtExcentosxCiudad(dr);
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