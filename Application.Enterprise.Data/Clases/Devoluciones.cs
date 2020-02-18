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
    public class Devoluciones
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandDevoluciones;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Devoluciones(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Devoluciones()
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
            commandDevoluciones = db.GetStoredProcCommand("PRC_SVDN_HISDEVOLUCIONES");

            db.AddInParameter(commandDevoluciones, "i_operation", DbType.String);
            db.AddInParameter(commandDevoluciones, "i_option", DbType.String);

            db.AddInParameter(commandDevoluciones, "i_nit", DbType.String);
            db.AddInParameter(commandDevoluciones, "i_campana", DbType.String);
            db.AddInParameter(commandDevoluciones, "i_numero", DbType.String);

            db.AddOutParameter(commandDevoluciones, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandDevoluciones, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Cambios

        /// <summary>
        /// Lista todos los Cambios de una empresaria
        /// </summary>
        /// <returns></returns>
        public List<DevolucionesInfo> ListXNit(string nit)
        {
            db.SetParameterValue(commandDevoluciones, "i_operation", 'S');
            db.SetParameterValue(commandDevoluciones, "i_option", 'A');
            db.SetParameterValue(commandDevoluciones, "i_nit", nit);

            List<DevolucionesInfo> col = new List<DevolucionesInfo>();

            IDataReader dr = null;

            DevolucionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDevoluciones);

                while (dr.Read())
                {
                    m = Factory.GetDevoluciones(dr);

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

        public List<DevolucionesInfo> ListXNitCampana(string nit, string campana)
        {
            db.SetParameterValue(commandDevoluciones, "i_operation", 'S');
            db.SetParameterValue(commandDevoluciones, "i_option", 'B');
            db.SetParameterValue(commandDevoluciones, "i_nit", nit);
            db.SetParameterValue(commandDevoluciones, "i_campana", campana);

            List<DevolucionesInfo> col = new List<DevolucionesInfo>();

            IDataReader dr = null;

            DevolucionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDevoluciones);

                while (dr.Read())
                {
                    m = Factory.GetDevoluciones(dr);

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

        public List<DevolucionesInfo> ListXNitNumero(string nit, string numero)
        {
            db.SetParameterValue(commandDevoluciones, "i_operation", 'S');
            db.SetParameterValue(commandDevoluciones, "i_option", 'C');
            db.SetParameterValue(commandDevoluciones, "i_nit", nit);
            db.SetParameterValue(commandDevoluciones, "i_numero", numero);

            List<DevolucionesInfo> col = new List<DevolucionesInfo>();

            IDataReader dr = null;

            DevolucionesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDevoluciones);

                while (dr.Read())
                {
                    m = Factory.GetDevoluciones(dr);

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
