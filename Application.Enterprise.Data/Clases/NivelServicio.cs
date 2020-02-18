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
    public class NivelServicio
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandNivelServicio;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public NivelServicio(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public NivelServicio()
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
            commandNivelServicio = db.GetStoredProcCommand("PRC_SVDN_NIVELSERVICIO");

            db.AddInParameter(commandNivelServicio, "i_operation", DbType.String);
            db.AddInParameter(commandNivelServicio, "i_option", DbType.String);
            db.AddInParameter(commandNivelServicio, "i_nis_id", DbType.Int32);
            db.AddInParameter(commandNivelServicio, "i_nis_nivelestimado", DbType.Decimal);
            db.AddInParameter(commandNivelServicio, "i_nis_fecha", DbType.DateTime);
            db.AddInParameter(commandNivelServicio, "i_zona", DbType.String);

            db.AddOutParameter(commandNivelServicio, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandNivelServicio, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de NivelServicio

        /// <summary>
        /// Lista todos los niveles de servicio
        /// </summary>
        /// <returns></returns>
        public List<NivelServicioInfo> List()
        {
            db.SetParameterValue(commandNivelServicio, "i_operation", 'S');
            db.SetParameterValue(commandNivelServicio, "i_option", 'A');

            List<NivelServicioInfo> col = new List<NivelServicioInfo>();

            IDataReader dr = null;

            NivelServicioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandNivelServicio);

                while (dr.Read())
                {
                    m = Factory.GetNivelServicio(dr);

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
        /// Lista un nivel de servicio por fecha actual
        /// </summary>
        /// <returns></returns>
        public NivelServicioInfo ListxFecha()
        {
            db.SetParameterValue(commandNivelServicio, "i_operation", 'S');
            db.SetParameterValue(commandNivelServicio, "i_option", 'B');           

            IDataReader dr = null;

            NivelServicioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandNivelServicio);

                if (dr.Read())
                {
                    m = Factory.GetNivelServicio(dr);                   
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
        /// Calcula el nivel de servicio de la campaña actual x zona.
        /// </summary>
        /// <param name="zona"></param>
        /// <returns></returns>
        public List<NivelServicioInfo> ListxCampanaxZona(string zona)
        {
            db.SetParameterValue(commandNivelServicio, "i_operation", 'S');
            db.SetParameterValue(commandNivelServicio, "i_option", 'C');
            db.SetParameterValue(commandNivelServicio, "i_zona", zona);
                        
            List<NivelServicioInfo> col = new List<NivelServicioInfo>();

            IDataReader dr = null;

            NivelServicioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandNivelServicio);

                while (dr.Read())
                {
                    m = Factory.GetNivelServicioxCampanaxZona(dr);

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
        /// Calcula el nivel de servicio de la campaña actual para todas las zonas.
        /// </summary>
        /// <returns></returns>
        public List<NivelServicioInfo> ListxCampanaxTodasZonas()
        {
            db.SetParameterValue(commandNivelServicio, "i_operation", 'S');
            db.SetParameterValue(commandNivelServicio, "i_option", 'D');

            List<NivelServicioInfo> col = new List<NivelServicioInfo>();

            IDataReader dr = null;

            NivelServicioInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandNivelServicio);

                while (dr.Read())
                {
                    m = Factory.GetNivelServicioxCampanaxZona(dr);

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