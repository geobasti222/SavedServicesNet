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
    public class Transportista
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandTransportista;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Transportista(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Transportista()
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
            commandTransportista = db.GetStoredProcCommand("PRC_SVDN_TRANSPORTISTAS");

            db.AddInParameter(commandTransportista, "i_operation", DbType.String);
            db.AddInParameter(commandTransportista, "i_option", DbType.String);
            db.AddInParameter(commandTransportista, "i_idtrlz", DbType.String);
            db.AddInParameter(commandTransportista, "i_razonsocial", DbType.String);
            db.AddInParameter(commandTransportista, "i_nit", DbType.String);
            db.AddInParameter(commandTransportista, "i_codciudad", DbType.String);
            db.AddInParameter(commandTransportista, "i_direccion", DbType.String);
            db.AddInParameter(commandTransportista, "i_telefono", DbType.String);
            db.AddInParameter(commandTransportista, "i_email", DbType.String);
            db.AddInParameter(commandTransportista, "i_tipolitr", DbType.Int32);
            db.AddInParameter(commandTransportista, "i_vendedor", DbType.String);
            db.AddInParameter(commandTransportista, "i_activo", DbType.Int32);
            db.AddInParameter(commandTransportista, "i_zona", DbType.String);
            db.AddOutParameter(commandTransportista, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandTransportista, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Transportista

        /// <summary>
        /// Lista todos los transportistas.
        /// </summary>
        /// <returns></returns>
        public List<TransportistaInfo> List()
        {
            db.SetParameterValue(commandTransportista, "i_operation", 'S');
            db.SetParameterValue(commandTransportista, "i_option", 'A');

            List<TransportistaInfo> col = new List<TransportistaInfo>();

            IDataReader dr = null;

            TransportistaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTransportista);

                while (dr.Read())
                {
                    m = Factory.GetTransportista(dr);

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
        /// Lista los transportistas de una zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<TransportistaInfo> ListxZona(string Zona)
        {
            db.SetParameterValue(commandTransportista, "i_operation", 'S');
            db.SetParameterValue(commandTransportista, "i_option", 'B');
            db.SetParameterValue(commandTransportista, "i_zona", Zona);

            List<TransportistaInfo> col = new List<TransportistaInfo>();

            IDataReader dr = null;

            TransportistaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTransportista);

                while (dr.Read())
                {
                    m = Factory.GetTransportista(dr);

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
        /// Lista un transportista x id.
        /// </summary>
        /// <param name="IdTransportista"></param>
        /// <returns></returns>
        public TransportistaInfo ListxId(string IdTransportista)
        {
            db.SetParameterValue(commandTransportista, "i_operation", 'S');
            db.SetParameterValue(commandTransportista, "i_option", 'C');
            db.SetParameterValue(commandTransportista, "i_idtrlz", IdTransportista);

            IDataReader dr = null;

            TransportistaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTransportista);

                while (dr.Read())
                {
                    m = Factory.GetTransportista(dr);
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
        /// Lista todos los transportistas de una IdZona.
        /// </summary>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<TransportistaInfo> ListxIdZona(string IdZona)
        {
            db.SetParameterValue(commandTransportista, "i_operation", 'S');
            db.SetParameterValue(commandTransportista, "i_option", 'D');
            db.SetParameterValue(commandTransportista, "i_zona", IdZona);

            List<TransportistaInfo> col = new List<TransportistaInfo>();

            IDataReader dr = null;

            TransportistaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandTransportista);

                while (dr.Read())
                {
                    m = Factory.GetTransportista(dr);

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