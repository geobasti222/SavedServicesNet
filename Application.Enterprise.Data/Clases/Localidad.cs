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
    public class Localidad
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandLocalidad;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Localidad(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Localidad()
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
            commandLocalidad = db.GetStoredProcCommand("PRC_SVDN_LOCALIDAD");

            db.AddInParameter(commandLocalidad, "i_operation", DbType.String);
            db.AddInParameter(commandLocalidad, "i_option", DbType.String);
            db.AddInParameter(commandLocalidad, "i_codlocalidad", DbType.String);
            db.AddInParameter(commandLocalidad, "i_nombrelocalidad", DbType.String);
            db.AddInParameter(commandLocalidad, "i_codciudad", DbType.String);
            

            db.AddOutParameter(commandLocalidad, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandLocalidad, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Localidad

        /// <summary>
        /// Lista todos las localidades
        /// </summary>
        /// <returns></returns>
        public List<LocalidadInfo> List()
        {
            db.SetParameterValue(commandLocalidad, "i_operation", 'S');
            db.SetParameterValue(commandLocalidad, "i_option", 'A');

            List<LocalidadInfo> col = new List<LocalidadInfo>();

            IDataReader dr = null;

            LocalidadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLocalidad);

                while (dr.Read())
                {
                    m = Factory.GetLocalidad(dr);

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
        /// Lista todas las localidades de una ciudad.
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public List<LocalidadInfo> ListxCiudad(string CodCiudad)
        {
            db.SetParameterValue(commandLocalidad, "i_operation", 'S');
            db.SetParameterValue(commandLocalidad, "i_option", 'B');
            db.SetParameterValue(commandLocalidad, "i_codciudad", CodCiudad);

            List<LocalidadInfo> col = new List<LocalidadInfo>();

            IDataReader dr = null;

            LocalidadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLocalidad);

                while (dr.Read())
                {
                    m = Factory.GetLocalidad(dr);

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
        /// Lista todos los Estados existentes ordenados por nombre
        /// </summary>
        /// <returns></returns>
        public List<EstadoInfo> ListOrdenada()
        {
            db.SetParameterValue(commandLocalidad, "i_operation", 'S');
            db.SetParameterValue(commandLocalidad, "i_option", 'C');

            List<EstadoInfo> col = new List<EstadoInfo>();

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLocalidad);

                while (dr.Read())
                {
                    m = Factory.GetEstado(dr);

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
        ///Lista todos los departamentos de una zona especifica.
        /// </summary>
        /// <returns></returns>
        public List<EstadoInfo> ListDepartamentosxZona(string IdZona)
        {
            db.SetParameterValue(commandLocalidad, "i_operation", 'S');
            db.SetParameterValue(commandLocalidad, "i_option", 'D');
            db.SetParameterValue(commandLocalidad, "i_codpais", IdZona);

            List<EstadoInfo> col = new List<EstadoInfo>();

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandLocalidad);

                while (dr.Read())
                {
                    m = Factory.GetEstado(dr);

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