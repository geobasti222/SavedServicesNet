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
    public class Cambios
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCambios;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Cambios(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Cambios()
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
            commandCambios = db.GetStoredProcCommand("PRC_SVDN_HISCAMBIOS");

            db.AddInParameter(commandCambios, "i_operation", DbType.String);
            db.AddInParameter(commandCambios, "i_option", DbType.String);

            db.AddInParameter(commandCambios, "i_nit", DbType.String);
            db.AddInParameter(commandCambios, "i_campana", DbType.String);
            db.AddInParameter(commandCambios, "i_numero", DbType.String);

            db.AddOutParameter(commandCambios, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCambios, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Cambios

        /// <summary>
        /// Lista todos los Cambios de una empresaria
        /// </summary>
        /// <returns></returns>
        public List<CambiosInfo> ListXNit(string nit)
        {
            db.SetParameterValue(commandCambios, "i_operation", 'S');
            db.SetParameterValue(commandCambios, "i_option", 'A');
            db.SetParameterValue(commandCambios, "i_nit", nit);

            List<CambiosInfo> col = new List<CambiosInfo>();

            IDataReader dr = null;

            CambiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCambios);

                while (dr.Read())
                {
                    m = Factory.GetCambios(dr);

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

        public List<CambiosInfo> ListXNitCampana(string nit, string campana)
        {
            db.SetParameterValue(commandCambios, "i_operation", 'S');
            db.SetParameterValue(commandCambios, "i_option", 'B');
            db.SetParameterValue(commandCambios, "i_nit", nit);
            db.SetParameterValue(commandCambios, "i_campana", campana);

            List<CambiosInfo> col = new List<CambiosInfo>();

            IDataReader dr = null;

            CambiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCambios);

                while (dr.Read())
                {
                    m = Factory.GetCambios(dr);

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

        public List<CambiosInfo> ListXNitNumero(string nit, string numero)
        {
            db.SetParameterValue(commandCambios, "i_operation", 'S');
            db.SetParameterValue(commandCambios, "i_option", 'C');
            db.SetParameterValue(commandCambios, "i_nit", nit);
            db.SetParameterValue(commandCambios, "i_numero", numero);

            List<CambiosInfo> col = new List<CambiosInfo>();

            IDataReader dr = null;

            CambiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCambios);

                while (dr.Read())
                {
                    m = Factory.GetCambios(dr);

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
