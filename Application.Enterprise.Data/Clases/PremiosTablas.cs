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
    public class PremiosTablas
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosTablas;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosTablas(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosTablas()
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
            commandPremiosTablas = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_TABLAS");

            db.AddInParameter(commandPremiosTablas, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosTablas, "i_option", DbType.String);
            db.AddInParameter(commandPremiosTablas, "i_tab_id", DbType.Int32);
            db.AddInParameter(commandPremiosTablas, "i_tab_nombre", DbType.String);
            db.AddInParameter(commandPremiosTablas, "i_tab_key", DbType.String);
            db.AddInParameter(commandPremiosTablas, "i_tab_concepto", DbType.String);

            db.AddOutParameter(commandPremiosTablas, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosTablas, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de PremiosTablas

        /// <summary>
        /// Lista todas las tablas de los premios.
        /// </summary>
        /// <returns></returns>
        public List<PremiosTablasInfo> List()
        {
            db.SetParameterValue(commandPremiosTablas, "i_operation", 'S');
            db.SetParameterValue(commandPremiosTablas, "i_option", 'A');

            List<PremiosTablasInfo> col = new List<PremiosTablasInfo>();

            IDataReader dr = null;

            PremiosTablasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosTablas);

                while (dr.Read())
                {
                    m = Factory.GetPremiosTablas(dr);

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
        /// Lista una tabla por id.
        /// </summary>
        /// <param name="IdTabla"></param>
        /// <returns></returns>
        public PremiosTablasInfo ListxId(int IdTabla)
        {
            db.SetParameterValue(commandPremiosTablas, "i_operation", 'S');
            db.SetParameterValue(commandPremiosTablas, "i_option", 'B');
            db.SetParameterValue(commandPremiosTablas, "i_tab_id", IdTabla);

            IDataReader dr = null;

            PremiosTablasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosTablas);

                if (dr.Read())
                {
                    m = Factory.GetPremiosTablas(dr);
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
        /// Lista una tabla por Nombre.
        /// </summary>
        /// <param name="NombreTabla"></param>
        /// <returns></returns>
        public PremiosTablasInfo ListxNombre(string NombreTabla)
        {
            db.SetParameterValue(commandPremiosTablas, "i_operation", 'S');
            db.SetParameterValue(commandPremiosTablas, "i_option", 'C');
            db.SetParameterValue(commandPremiosTablas, "i_tab_nombre", NombreTabla);

            IDataReader dr = null;

            PremiosTablasInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosTablas);

                if (dr.Read())
                {
                    m = Factory.GetPremiosTablas(dr);
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