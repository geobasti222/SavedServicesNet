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
    public class CiudadSVDN
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCiudadSVDN;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CiudadSVDN(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CiudadSVDN()
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
            commandCiudadSVDN = db.GetStoredProcCommand("PRC_SVDN_CIUDADSVDN");

            db.AddInParameter(commandCiudadSVDN, "i_operation", DbType.String);
            db.AddInParameter(commandCiudadSVDN, "i_option", DbType.String);
            db.AddInParameter(commandCiudadSVDN, "i_ciu_codciudad", DbType.Int32);
            db.AddInParameter(commandCiudadSVDN, "i_ciu_nombre", DbType.String);
            db.AddInParameter(commandCiudadSVDN, "i_reg_codregional", DbType.Int32);

            db.AddOutParameter(commandCiudadSVDN, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCiudadSVDN, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de CiudadSVDN

        /// <summary>
        /// Lista todos las ciudades de svdn existentes.
        /// </summary>
        /// <returns></returns>
        public List<CiudadSVDNInfo> List()
        {
            db.SetParameterValue(commandCiudadSVDN, "i_operation", 'S');
            db.SetParameterValue(commandCiudadSVDN, "i_option", 'A');

            List<CiudadSVDNInfo> col = new List<CiudadSVDNInfo>();

            IDataReader dr = null;

            CiudadSVDNInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudadSVDN);

                while (dr.Read())
                {
                    m = Factory.GetCiudadSVDN(dr);

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
        /// Lista todos las ciudades de una regional existentes.
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<CiudadSVDNInfo> ListxRegional(int CodigoRegional)
        {
            db.SetParameterValue(commandCiudadSVDN, "i_operation", 'S');
            db.SetParameterValue(commandCiudadSVDN, "i_option", 'B');
            db.SetParameterValue(commandCiudadSVDN, "i_reg_codregional", CodigoRegional);

            List<CiudadSVDNInfo> col = new List<CiudadSVDNInfo>();

            IDataReader dr = null;

            CiudadSVDNInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudadSVDN);

                while (dr.Read())
                {
                    m = Factory.GetCiudadSVDN(dr);

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
        /// Lista una ciudad por codigo.
        /// </summary>
        /// <param name="CodigoCiudad"></param>
        /// <returns></returns>
        public CiudadSVDNInfo ListxCodigoCiudad(int CodigoCiudad)
        {
            db.SetParameterValue(commandCiudadSVDN, "i_operation", 'S');
            db.SetParameterValue(commandCiudadSVDN, "i_option", 'C');
            db.SetParameterValue(commandCiudadSVDN, "i_ciu_codciudad", CodigoCiudad);

            IDataReader dr = null;

            CiudadSVDNInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudadSVDN);

                while (dr.Read())
                {
                    m = Factory.GetCiudadSVDN(dr);

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