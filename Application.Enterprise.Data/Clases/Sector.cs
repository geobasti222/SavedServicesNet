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
    public class Sector
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandSector;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Sector(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Sector()
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
            commandSector = db.GetStoredProcCommand("PRC_SVDN_SECTOR");

            db.AddInParameter(commandSector, "i_operation", DbType.String);
            db.AddInParameter(commandSector, "i_option", DbType.String);
            db.AddInParameter(commandSector, "i_sec_codsector", DbType.String);
            db.AddInParameter(commandSector, "i_sec_nomsector", DbType.String);
            db.AddInParameter(commandSector, "i_codciudad", DbType.String);
            db.AddInParameter(commandSector, "i_zona", DbType.String);          

            db.AddOutParameter(commandSector, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandSector, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Sector
        
        /// <summary>
        /// lista los sectores existentes por una ciudad.
        /// </summary>
        /// <returns></returns>
        public List<SectorInfo> ListxCiudad(string CodCiudad)
        {
            db.SetParameterValue(commandSector, "i_operation", 'S');
            db.SetParameterValue(commandSector, "i_option", 'A');
            db.SetParameterValue(commandSector, "i_codciudad", CodCiudad);

            List<SectorInfo> col = new List<SectorInfo>();

            IDataReader dr = null;

            SectorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSector);

                while (dr.Read())
                {
                    m = Factory.GetSector(dr);

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
        /// Lista los sectores de una zona y por ciudad.
        /// </summary>
        /// <returns></returns>
        public List<SectorInfo> ListxZona(string CodCiudad, string CodZona)
        {
            db.SetParameterValue(commandSector, "i_operation", 'S');
            db.SetParameterValue(commandSector, "i_option", 'B');
            db.SetParameterValue(commandSector, "i_codciudad", CodCiudad);
            db.SetParameterValue(commandSector, "i_zona", CodZona);

            List<SectorInfo> col = new List<SectorInfo>();

            IDataReader dr = null;

            SectorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSector);

                while (dr.Read())
                {
                    m = Factory.GetSector(dr);

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