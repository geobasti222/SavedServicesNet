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
    public class Ciudad
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCiudad;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Ciudad(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Ciudad()
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
            commandCiudad = db.GetStoredProcCommand("PRC_SVDN_CIUDAD");

            db.AddInParameter(commandCiudad, "i_operation", DbType.String);
            db.AddInParameter(commandCiudad, "i_option", DbType.String);
            db.AddInParameter(commandCiudad, "i_codciudad", DbType.String);
            db.AddInParameter(commandCiudad, "i_nombreciudad", DbType.String);
            db.AddInParameter(commandCiudad, "i_codestado", DbType.String);
            db.AddInParameter(commandCiudad, "i_rete_ica", DbType.String);
            db.AddInParameter(commandCiudad, "i_codigociudad", DbType.String);
            db.AddOutParameter(commandCiudad, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCiudad, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Ciudad

        /// <summary>
        /// lista todas las ciudades existentes.
        /// </summary>
        /// <returns></returns>
        public List<CiudadInfo> List()
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'A');

            List<CiudadInfo> col = new List<CiudadInfo>();

            IDataReader dr = null;

            CiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetCiudad(dr);

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
        /// lista todas las ciudades existentes por codigo de departamento.
        /// </summary>
        /// <returns></returns>
        public List<CiudadInfo> ListByEstado(string CodEstado)
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'B');
            db.SetParameterValue(commandCiudad, "i_codestado", CodEstado);

            List<CiudadInfo> col = new List<CiudadInfo>();

            IDataReader dr = null;

            CiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetCiudad(dr);

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
        /// lista todas las ciudades existentes por codigo de departamento.
        /// </summary>
        /// <returns></returns>
        public List<CiudadInfo> ListByCanton(string CodCanton, string codprovincia)
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'G');
            db.SetParameterValue(commandCiudad, "i_codestado", codprovincia);
            db.SetParameterValue(commandCiudad, "i_codciudad", CodCanton);

            List<CiudadInfo> col = new List<CiudadInfo>();

            IDataReader dr = null;

            CiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetParroquia(dr);

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
        /// Retorna un objeto de Zona Ciudad
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public ZonadeCiudadInfo ZonadeCiudad(string Ciudad)
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'C');
            db.SetParameterValue(commandCiudad, "i_nombreciudad", Ciudad);

            IDataReader dr = null;

            ZonadeCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetZonaDeCiudad(dr);

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
        /// lista una ciudad por codigo.
        /// </summary>
        /// <param name="Ciudad"></param>
        /// <returns></returns>
        public CiudadInfo ListxCodCiudad(string CodCiudad)
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'D');
            db.SetParameterValue(commandCiudad, "i_codciudad", CodCiudad);

            IDataReader dr = null;

            CiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetCiudad(dr);

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
        /// Lista todas las ciudades que tengan relacionadas un estado
        /// </summary>
        /// <returns></returns>
        public List<CiudadInfo> ListCiudadesConEstado(string CodEstado)
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'D');
            db.SetParameterValue(commandCiudad, "i_codestado", CodEstado);

            List<CiudadInfo> col = new List<CiudadInfo>();

            IDataReader dr = null;

            CiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetCiudad(dr);

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
        /// Lista una ciudad especifica x codigo.
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public CiudadInfo ListCiudadxId(string CodCiudad)
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'F');
            db.SetParameterValue(commandCiudad, "i_codciudad", CodCiudad);

            IDataReader dr = null;

            CiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetCiudad(dr);
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
        /// Lista una ciudad especifica x codigo. para sacar el pedidomin
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public CiudadInfo ListCiudadxIdPedMin(string CodCiudad)
        {
            db.SetParameterValue(commandCiudad, "i_operation", 'S');
            db.SetParameterValue(commandCiudad, "i_option", 'F');
            db.SetParameterValue(commandCiudad, "i_codciudad", CodCiudad);

            IDataReader dr = null;

            CiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiudad);

                while (dr.Read())
                {
                    m = Factory.GetCiudadPedMin(dr);
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