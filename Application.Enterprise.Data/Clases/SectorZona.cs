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
    public class SectorZona
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandSectorZona;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public SectorZona(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public SectorZona()
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
            commandSectorZona = db.GetStoredProcCommand("PRC_SVDN_SECTORXZONA");

            db.AddInParameter(commandSectorZona, "i_operation", DbType.String);
            db.AddInParameter(commandSectorZona, "i_option", DbType.String);
            db.AddInParameter(commandSectorZona, "i_sec_codsector", DbType.String);
            db.AddInParameter(commandSectorZona, "i_zona", DbType.String);       

            db.AddOutParameter(commandSectorZona, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandSectorZona, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de SectorZona

        /// <summary>
        ///  lista los todos los Sectores por Zona.
        /// </summary>
        /// <returns></returns>
        public List<SectorZonaInfo> List()
        {
            db.SetParameterValue(commandSectorZona, "i_operation", 'S');
            db.SetParameterValue(commandSectorZona, "i_option", 'A');
            
            List<SectorZonaInfo> col = new List<SectorZonaInfo>();

            IDataReader dr = null;

            SectorZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSectorZona);

                while (dr.Read())
                {
                    m = Factory.GetSectorZona(dr);

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
        /// Lista las zonas de un sector especifico.
        /// </summary>
        /// <returns></returns>
        public List<SectorZonaInfo> ListxSector(string CodSector)
        {
            db.SetParameterValue(commandSectorZona, "i_operation", 'S');
            db.SetParameterValue(commandSectorZona, "i_option", 'B');
            db.SetParameterValue(commandSectorZona, "i_sec_codsector", CodSector);

            List<SectorZonaInfo> col = new List<SectorZonaInfo>();

            IDataReader dr = null;

            SectorZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSectorZona);

                while (dr.Read())
                {
                    m = Factory.GetSectorZona(dr);

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
        /// Lista los sectores de una zona especifica.
        /// </summary>
        /// <param name="CodigoZona"></param>
        /// <returns></returns>
        public List<SectorZonaInfo> ListSectorxZona(string CodigoZona)
        {
            db.SetParameterValue(commandSectorZona, "i_operation", 'S');
            db.SetParameterValue(commandSectorZona, "i_option", 'C');
            db.SetParameterValue(commandSectorZona, "i_zona", CodigoZona);

            List<SectorZonaInfo> col = new List<SectorZonaInfo>();

            IDataReader dr = null;

            SectorZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSectorZona);

                while (dr.Read())
                {
                    m = Factory.GetSectoresxZona(dr);

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