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
    public class SectorxBarrio
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandSectorxBarrio;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public SectorxBarrio(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public SectorxBarrio()
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
            commandSectorxBarrio = db.GetStoredProcCommand("PRC_SVDN_SECTORXBARRIO");

            db.AddInParameter(commandSectorxBarrio, "i_operation", DbType.String);
            db.AddInParameter(commandSectorxBarrio, "i_option", DbType.String);
            db.AddInParameter(commandSectorxBarrio, "i_bar_codbarrio", DbType.Int32);
            db.AddInParameter(commandSectorxBarrio, "i_sec_codsector", DbType.String);

            db.AddOutParameter(commandSectorxBarrio, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandSectorxBarrio, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de SectorxBarrio

        /// <summary>
        /// lista todos los sectores x barrios existentes.
        /// </summary>
        /// <returns></returns>
        public List<SectorxBarrioInfo> List()
        {
            db.SetParameterValue(commandSectorxBarrio, "i_operation", 'S');
            db.SetParameterValue(commandSectorxBarrio, "i_option", 'A');

            List<SectorxBarrioInfo> col = new List<SectorxBarrioInfo>();

            IDataReader dr = null;

            SectorxBarrioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSectorxBarrio);

                while (dr.Read())
                {
                    m = Factory.GetSectorxBarrio(dr);

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
        /// lista el sector de un barrio especifico.
        /// </summary>
        /// <returns></returns>
        public List<SectorxBarrioInfo> ListxBarrio(int CodigoBarrio)
        {
            db.SetParameterValue(commandSectorxBarrio, "i_operation", 'S');
            db.SetParameterValue(commandSectorxBarrio, "i_option", 'B');
            db.SetParameterValue(commandSectorxBarrio, "i_bar_codbarrio", CodigoBarrio);

            List<SectorxBarrioInfo> col = new List<SectorxBarrioInfo>();

            IDataReader dr = null;

            SectorxBarrioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandSectorxBarrio);

                while (dr.Read())
                {
                    m = Factory.GetSectorxBarrio(dr);

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