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
    public class GeografiaEcu
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandGeografiaEcu;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public GeografiaEcu(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public GeografiaEcu()
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
            commandGeografiaEcu = db.GetStoredProcCommand("PRC_SVDN_GEOGRAFIAECU");

            db.AddInParameter(commandGeografiaEcu, "i_operation", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_option", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_codigo", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_codprovincia", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_nomprovincia", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_codcanton", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_nomcanton", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_codparroquia", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_nomparroquia", DbType.String);
            db.AddInParameter(commandGeografiaEcu, "i_hombres", DbType.Decimal);
            db.AddInParameter(commandGeografiaEcu, "i_mujer", DbType.Decimal);
            db.AddInParameter(commandGeografiaEcu, "i_total", DbType.Decimal);
            db.AddInParameter(commandGeografiaEcu, "i_estado", DbType.Boolean);

            db.AddOutParameter(commandGeografiaEcu, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandGeografiaEcu, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Geografias de Ecuador

        /// <summary>
        /// Lista todos las geografias de ecuador
        /// </summary>
        /// <returns></returns>
        public List<GeografiaEcuInfo> List()
        {
            db.SetParameterValue(commandGeografiaEcu, "i_operation", 'S');
            db.SetParameterValue(commandGeografiaEcu, "i_option", 'A');

            List<GeografiaEcuInfo> col = new List<GeografiaEcuInfo>();

            IDataReader dr = null;

            GeografiaEcuInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGeografiaEcu);

                while (dr.Read())
                {
                    m = Factory.GetGeografiaEcuador(dr);

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
        /// Lista todas las provincias de Ecuador.
        /// </summary>
        /// <returns></returns>
        public List<GeografiaEcuInfo> ListProvincias()
        {
            db.SetParameterValue(commandGeografiaEcu, "i_operation", 'S');
            db.SetParameterValue(commandGeografiaEcu, "i_option", 'B');

            List<GeografiaEcuInfo> col = new List<GeografiaEcuInfo>();

            IDataReader dr = null;

            GeografiaEcuInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGeografiaEcu);

                while (dr.Read())
                {
                    m = Factory.GetGeografiaEcuadorProvincias(dr);

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
        /// Lista todos los cantones de una provincia especifica.
        /// </summary>
        /// <param name="CodProvincia"></param>
        /// <returns></returns>
        public List<GeografiaEcuInfo> ListCantonxProvincia(string CodProvincia)
        {
            db.SetParameterValue(commandGeografiaEcu, "i_operation", 'S');
            db.SetParameterValue(commandGeografiaEcu, "i_option", 'C');
            db.SetParameterValue(commandGeografiaEcu, "i_codprovincia", CodProvincia);

            List<GeografiaEcuInfo> col = new List<GeografiaEcuInfo>();

            IDataReader dr = null;

            GeografiaEcuInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGeografiaEcu);

                while (dr.Read())
                {
                    m = Factory.GetGeografiaEcuadorCantonxProvincias(dr);

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
        /// Lista todas las parroquias de un canton especifico.
        /// </summary>
        /// <param name="CodCanton"></param>
        /// <returns></returns>
        public List<GeografiaEcuInfo> ListParroquiasxCanton(string CodProvincia, string CodCanton)
        {
            db.SetParameterValue(commandGeografiaEcu, "i_operation", 'S');
            db.SetParameterValue(commandGeografiaEcu, "i_option", 'D');
            db.SetParameterValue(commandGeografiaEcu, "i_codprovincia", CodProvincia);
            db.SetParameterValue(commandGeografiaEcu, "i_codcanton", CodCanton);

            List<GeografiaEcuInfo> col = new List<GeografiaEcuInfo>();

            IDataReader dr = null;

            GeografiaEcuInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGeografiaEcu);

                while (dr.Read())
                {
                    m = Factory.GetGeografiaEcuadorParroquiasxCanton(dr);

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