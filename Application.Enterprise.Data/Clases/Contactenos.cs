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
    public class Contactenos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandContactenos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Contactenos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();

        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Contactenos()
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
            commandContactenos = db.GetStoredProcCommand("PRC_SVDN_CONTACTENOS");

            db.AddInParameter(commandContactenos, "i_operation", DbType.String);
            db.AddInParameter(commandContactenos, "i_option", DbType.String);
            db.AddParameter(commandContactenos, "io_cont_id", DbType.Int32, 12, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandContactenos, "i_cont_categoria", DbType.Int32);
            db.AddInParameter(commandContactenos, "i_cont_asunto", DbType.String);
            db.AddInParameter(commandContactenos, "i_cont_descripcion", DbType.String);
            db.AddInParameter(commandContactenos, "i_cont_email", DbType.String);
            db.AddInParameter(commandContactenos, "i_cont_resuelto", DbType.Boolean);

            db.AddOutParameter(commandContactenos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandContactenos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de la clase

        /// <summary>
        ///  Lista todos los contactenos de las empresarias.
        /// </summary>
        /// <returns></returns>
        public List<ContactenosInfo> List()
        {
            db.SetParameterValue(commandContactenos, "i_operation", 'S');
            db.SetParameterValue(commandContactenos, "i_option", 'A');

            List<ContactenosInfo> col = new List<ContactenosInfo>();


            IDataReader dr = null;

            ContactenosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandContactenos);

                while (dr.Read())
                {
                    m = Factory.GetContactenos(dr);

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
        /// Lista un contactenos x id.
        /// </summary>
        /// <param name="Id">Id del contactenos.</param>
        /// <returns></returns>
        public ContactenosInfo ListxId(int Id)
        {
            db.SetParameterValue(commandContactenos, "i_operation", 'S');
            db.SetParameterValue(commandContactenos, "i_option", 'B');
            db.SetParameterValue(commandContactenos, "io_cont_id", Id);


            IDataReader dr = null;

            ContactenosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandContactenos);

                while (dr.Read())
                {
                    m = Factory.GetContactenos(dr);
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
        /// Guarda un mensaje de contactenos de una empresaria.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string Insert(ContactenosInfo item)
        {
            string strid = "";

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandContactenos, "i_operation", 'I');
                db.SetParameterValue(commandContactenos, "i_option", 'A');


                db.SetParameterValue(commandContactenos, "i_cont_categoria", item.Categoria);
                db.SetParameterValue(commandContactenos, "i_cont_asunto", item.Asunto);
                db.SetParameterValue(commandContactenos, "i_cont_descripcion", item.Descripcion);
                db.SetParameterValue(commandContactenos, "i_cont_email", item.Email);
                db.SetParameterValue(commandContactenos, "i_cont_resuelto", item.Resuelto);

                dr = db.ExecuteReader(commandContactenos);

                //Obtiene el identificador (consecutivo) del insert
                strid = System.Convert.ToString(db.GetParameterValue(commandContactenos, "io_cont_id")).Trim();

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro de contactenos. Id Registro:" + strid + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

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

            return strid;
        }



        /// <summary>
        /// Realiza la actualizacion del estado de un contactenos existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(ContactenosInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandContactenos, "i_operation", 'U');
                db.SetParameterValue(commandContactenos, "i_option", 'A');

                db.SetParameterValue(commandContactenos, "io_cont_id", item.ID);
                db.SetParameterValue(commandContactenos, "i_cont_resuelto", item.Resuelto);


                dr = db.ExecuteReader(commandContactenos);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la actualización del estado del registro de contactenos numero: " + item.ID + " El estado se actualizo a:" + item.Resuelto + " . Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                }
                //-----------------------------------------------------------------------------------------------------------------------------                
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