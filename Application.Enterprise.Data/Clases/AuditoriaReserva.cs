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
    public class AuditoriaReserva
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAuditoriaReserva;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public AuditoriaReserva(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public AuditoriaReserva()
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
            commandAuditoriaReserva = db.GetStoredProcCommand("PRC_SVDN_AUDITORIA_RESERVA");

            db.AddInParameter(commandAuditoriaReserva, "i_operation", DbType.String);
            db.AddInParameter(commandAuditoriaReserva, "i_option", DbType.String);
            db.AddInParameter(commandAuditoriaReserva, "i_aur_id", DbType.Int32);
            db.AddInParameter(commandAuditoriaReserva, "i_aur_numeroerror", DbType.String);
            db.AddInParameter(commandAuditoriaReserva, "i_aur_mensajeerror", DbType.String);
            db.AddInParameter(commandAuditoriaReserva, "i_aur_sysdate", DbType.DateTime);
            db.AddInParameter(commandAuditoriaReserva, "i_aur_confirmado", DbType.Boolean);
            db.AddInParameter(commandAuditoriaReserva, "i_aur_numeropedido", DbType.String);

            db.AddOutParameter(commandAuditoriaReserva, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandAuditoriaReserva, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Auditoria de Reserva en Linea

        /// <summary>
        /// Lista todos errores de reserva en linea sin confirmar por email.
        /// </summary>
        /// <returns></returns>
        public List<AuditoriaReservaInfo> ListErroresSinConfirmar()
        {
            db.SetParameterValue(commandAuditoriaReserva, "i_operation", 'S');
            db.SetParameterValue(commandAuditoriaReserva, "i_option", 'A');

            List<AuditoriaReservaInfo> col = new List<AuditoriaReservaInfo>();

            IDataReader dr = null;

            AuditoriaReservaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAuditoriaReserva);

                while (dr.Read())
                {
                    m = Factory.GetAuditoriaReserva(dr);

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
        /// Realiza la actualizacion de la auditoria enviada por correo.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateIdConfirmado(int Id)
        {
            bool transOk = false;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandAuditoriaReserva, "i_operation", 'U');
                db.SetParameterValue(commandAuditoriaReserva, "i_option", 'A');
                db.SetParameterValue(commandAuditoriaReserva, "i_aur_id", Id);

                dr = db.ExecuteReader(commandAuditoriaReserva);

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