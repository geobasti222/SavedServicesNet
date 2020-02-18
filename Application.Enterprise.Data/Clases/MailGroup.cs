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
    public class MailGroup
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMailGroup;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MailGroup(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MailGroup()
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
            commandMailGroup = db.GetStoredProcCommand("PRC_SVDN_MAILGROUP");

            db.AddInParameter(commandMailGroup, "i_operation", DbType.String);
            db.AddInParameter(commandMailGroup, "i_option", DbType.String);
            db.AddInParameter(commandMailGroup, "i_mailgroup", DbType.Int32);
            db.AddInParameter(commandMailGroup, "i_nombre", DbType.String);

            db.AddOutParameter(commandMailGroup, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMailGroup, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de MailGroup

        /// <summary>
        /// lista todos los MailGroup existentes.
        /// </summary>
        /// <returns></returns>
        public List<MailGroupInfo> List()
        {
            db.SetParameterValue(commandMailGroup, "i_operation", 'S');
            db.SetParameterValue(commandMailGroup, "i_option", 'A');

            List<MailGroupInfo> col = new List<MailGroupInfo>();

            IDataReader dr = null;

            MailGroupInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailGroup);

                while (dr.Read())
                {
                    m = Factory.GetMailGroup(dr);

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
        ///Obtiene los mailgroup que se encuentran abiertos para procesar de la fecha.
        /// </summary>
        /// <returns></returns>
        public List<MailGroupInfo> ListxFechaActual()
        {
            db.SetParameterValue(commandMailGroup, "i_operation", 'S');
            db.SetParameterValue(commandMailGroup, "i_option", 'B');

            List<MailGroupInfo> col = new List<MailGroupInfo>();

            IDataReader dr = null;

            MailGroupInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailGroup);

                while (dr.Read())
                {
                    m = Factory.GetMailGroup(dr);

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
        ///Obtiene los mailgroup que se encuentran abiertos para procesar de la fecha para la facturacion.
        /// </summary>
        /// <returns></returns>
        public List<MailGroupInfo> ListxFechaActualFacturacion()
        {
            db.SetParameterValue(commandMailGroup, "i_operation", 'S');
            db.SetParameterValue(commandMailGroup, "i_option", 'C');

            List<MailGroupInfo> col = new List<MailGroupInfo>();

            IDataReader dr = null;

            MailGroupInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMailGroup);

                while (dr.Read())
                {
                    m = Factory.GetMailGroup(dr);

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
        /// Realiza la actualizacion de un mailplan del sistema por mailgroup.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(MailGroupInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailGroup, "i_operation", 'U');
                db.SetParameterValue(commandMailGroup, "i_option", 'A');
                db.SetParameterValue(commandMailGroup, "i_mailgroup", item.MailGroup);

                dr = db.ExecuteReader(commandMailGroup);

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
        /// Realiza la actualizacion de un mailplan para factuacion del sistema por mailgroup. Lo deja en estado abierto para facturar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateEstadoFacturacionAbierto(MailGroupInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailGroup, "i_operation", 'U');
                db.SetParameterValue(commandMailGroup, "i_option", 'B');
                db.SetParameterValue(commandMailGroup, "i_mailgroup", item.MailGroup);

                dr = db.ExecuteReader(commandMailGroup);

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
        /// Realiza la actualizacion de un mailplan para factuacion del sistema por mailgroup. Lo deja en estado cerrado y no se puede facturar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateEstadoFacturacionCerrado(MailGroupInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandMailGroup, "i_operation", 'U');
                db.SetParameterValue(commandMailGroup, "i_option", 'C');
                db.SetParameterValue(commandMailGroup, "i_mailgroup", item.MailGroup);

                dr = db.ExecuteReader(commandMailGroup);

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