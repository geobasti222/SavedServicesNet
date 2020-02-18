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
    public class Estado
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEstado;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Estado(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Estado()
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
            commandEstado = db.GetStoredProcCommand("PRC_SVDN_ESTADO");

            db.AddInParameter(commandEstado, "i_operation", DbType.String);
            db.AddInParameter(commandEstado, "i_option", DbType.String);
            db.AddInParameter(commandEstado, "i_codestado", DbType.String);
            db.AddInParameter(commandEstado, "i_nombreestado", DbType.String);
            db.AddInParameter(commandEstado, "i_codpais", DbType.String);
            db.AddInParameter(commandEstado, "i_codigoestado", DbType.String);

            db.AddOutParameter(commandEstado, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEstado, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Estado

        /// <summary>
        /// lista todos los Estados existentes.
        /// </summary>
        /// <returns></returns>
        public List<EstadoInfo> List()
        {
            db.SetParameterValue(commandEstado, "i_operation", 'S');
            db.SetParameterValue(commandEstado, "i_option", 'A');

            List<EstadoInfo> col = new List<EstadoInfo>();

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstado);

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


        public List<EstadoInfo> ListF()
        {
            db.SetParameterValue(commandEstado, "i_operation", 'S');
            db.SetParameterValue(commandEstado, "i_option", 'F');

            List<EstadoInfo> col = new List<EstadoInfo>();

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstado);

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
        /// lista todos los Estados existentes por codigo de pais.
        /// </summary>
        /// <returns></returns>
        public List<EstadoInfo> ListByPais(string CodPais)
        {
            db.SetParameterValue(commandEstado, "i_operation", 'S');
            db.SetParameterValue(commandEstado, "i_option", 'B');
            db.SetParameterValue(commandEstado, "i_codpais", CodPais);

            List<EstadoInfo> col = new List<EstadoInfo>();

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstado);

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
        /// Lista todos los Estados existentes ordenados por nombre
        /// </summary>
        /// <returns></returns>
        public List<EstadoInfo> ListOrdenada()
        {
            db.SetParameterValue(commandEstado, "i_operation", 'S');
            db.SetParameterValue(commandEstado, "i_option", 'C');

            List<EstadoInfo> col = new List<EstadoInfo>();

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstado);

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
            db.SetParameterValue(commandEstado, "i_operation", 'S');
            db.SetParameterValue(commandEstado, "i_option", 'D');
            db.SetParameterValue(commandEstado, "i_codpais", IdZona);

            List<EstadoInfo> col = new List<EstadoInfo>();

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstado);

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
        /// GAVL Lista Estados por Estado
        /// </summary>
        /// <param name="codestado"></param>
        /// <returns></returns>
        public EstadoInfo ListXEstado(string codestado)
        {
            db.SetParameterValue(commandEstado, "i_operation", 'S');
            db.SetParameterValue(commandEstado, "i_option", 'E');
            db.SetParameterValue(commandEstado, "i_codestado", codestado);

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstado);

                while (dr.Read())
                {
                    m = Factory.GetEstado(dr);
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
        /// Lista los departamentos x ciudad
        /// </summary>
        /// <param name="codestado"></param>
        /// <returns></returns>
        public EstadoInfo ListDeptoxCiudad(string codestado)
        {
            db.SetParameterValue(commandEstado, "i_operation", 'S');
            db.SetParameterValue(commandEstado, "i_option", 'F');
            db.SetParameterValue(commandEstado, "i_codestado", codestado);

            IDataReader dr = null;

            EstadoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEstado);

                while (dr.Read())
                {
                    m = Factory.GetEstado(dr);
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