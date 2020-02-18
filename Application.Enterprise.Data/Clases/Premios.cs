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
    public class Premios
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremios;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Premios(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Premios()
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
            commandPremios = db.GetStoredProcCommand("PRC_SVDN_PREMIOS");

            db.AddInParameter(commandPremios, "i_operation", DbType.String);
            db.AddInParameter(commandPremios, "i_option", DbType.String);
            db.AddParameter(commandPremios, "i_pre_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, 32);
            db.AddInParameter(commandPremios, "i_pre_descripcion", DbType.String);
            db.AddInParameter(commandPremios, "i_pre_condiciones", DbType.String);
            db.AddInParameter(commandPremios, "i_pre_estado", DbType.Int32);
            db.AddInParameter(commandPremios, "i_pre_creado", DbType.DateTime);
            db.AddInParameter(commandPremios, "i_pre_modificado", DbType.DateTime);

            db.AddOutParameter(commandPremios, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremios, "o_err_msg", DbType.String, 1000);
        }
        #endregion

        #region Metodos de Premios

        /// <summary>
        ///Lista todos los premios
        /// </summary>
        /// <returns></returns>
        public List<PremiosInfo> List()
        {
            db.SetParameterValue(commandPremios, "i_operation", 'S');
            db.SetParameterValue(commandPremios, "i_option", 'A');

            List<PremiosInfo> col = new List<PremiosInfo>();

            IDataReader dr = null;

            PremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremios);

                while (dr.Read())
                {
                    m = Factory.GetPremios(dr);

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
        /// Lista un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public PremiosInfo ListxId(int IdPremio)
        {
            db.SetParameterValue(commandPremios, "i_operation", 'S');
            db.SetParameterValue(commandPremios, "i_option", 'B');
            db.SetParameterValue(commandPremios, "i_pre_id", IdPremio);

            IDataReader dr = null;

            PremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremios);

                if (dr.Read())
                {
                    m = Factory.GetPremios(dr);
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
        /// Lista los premios ordenados.
        /// </summary>
        /// <returns></returns>
        public List<PremiosInfo> ListxOrden()
        {
            db.SetParameterValue(commandPremios, "i_operation", 'S');
            db.SetParameterValue(commandPremios, "i_option", 'C');

            List<PremiosInfo> col = new List<PremiosInfo>();

            IDataReader dr = null;

            PremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremios);

                while (dr.Read())
                {
                    m = Factory.GetPremios(dr);

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
        /// busca un premio por nombre.
        /// </summary>
        /// <param name="NombrePremio"></param>
        /// <returns></returns>
        public List<PremiosInfo> ListxNombre(string NombrePremio)
        {
            db.SetParameterValue(commandPremios, "i_operation", 'S');
            db.SetParameterValue(commandPremios, "i_option", 'D');
            db.SetParameterValue(commandPremios, "i_pre_descripcion", NombrePremio);

            List<PremiosInfo> col = new List<PremiosInfo>();

            IDataReader dr = null;

            PremiosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremios);

                while (dr.Read())
                {
                    m = Factory.GetPremios(dr);

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
        /// Realiza el registro de un premio.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremios, "i_operation", 'I');
                db.SetParameterValue(commandPremios, "i_option", 'A');

                db.SetParameterValue(commandPremios, "i_pre_descripcion", item.Descripcion);
                db.SetParameterValue(commandPremios, "i_pre_condiciones", item.Condiciones);
                db.SetParameterValue(commandPremios, "i_pre_estado", item.Estado);
                db.SetParameterValue(commandPremios, "i_pre_creado", item.Creado);
                db.SetParameterValue(commandPremios, "i_pre_modificado", item.Modificado);

                dr = db.ExecuteReader(commandPremios);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandPremios, "i_pre_id"));

            }
            catch (Exception ex)
            {
                id = 0;

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

            return id;
        }

        /// <summary>
        /// Realiza la actualizacion  de un premio.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(PremiosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremios, "i_operation", 'U');
                db.SetParameterValue(commandPremios, "i_option", 'A');

                db.SetParameterValue(commandPremios, "i_pre_id", item.Id);
                db.SetParameterValue(commandPremios, "i_pre_descripcion", item.Descripcion);
                db.SetParameterValue(commandPremios, "i_pre_condiciones", item.Condiciones);
                db.SetParameterValue(commandPremios, "i_pre_estado", item.Estado);
                db.SetParameterValue(commandPremios, "i_pre_modificado", item.Modificado);

                dr = db.ExecuteReader(commandPremios);

                transOk = true;

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

            return transOk;
        }

        /// <summary>
        /// Elimina un premio especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletexIdPremio(int IdPremio)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremios, "i_operation", 'D');
                db.SetParameterValue(commandPremios, "i_option", 'A');
                db.SetParameterValue(commandPremios, "i_pre_id", IdPremio);

                dr = db.ExecuteReader(commandPremios);

                transOk = true;
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

            return transOk;
        }

        #endregion
    }
}