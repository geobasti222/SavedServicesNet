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
    public class ClasificacionXValorAlarma
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandClasificacionXValorAlarma;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ClasificacionXValorAlarma(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ClasificacionXValorAlarma()
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
            commandClasificacionXValorAlarma = db.GetStoredProcCommand("PRC_SVDN_CLASIFICACIONXVALORALARMAS");

            db.AddInParameter(commandClasificacionXValorAlarma, "i_operation", DbType.String);
            db.AddInParameter(commandClasificacionXValorAlarma, "i_option", DbType.String);

            db.AddInParameter(commandClasificacionXValorAlarma, "i_campana", DbType.String);
            db.AddInParameter(commandClasificacionXValorAlarma, "i_nit", DbType.String);
            db.AddInParameter(commandClasificacionXValorAlarma, "i_estado", DbType.String);
            db.AddInParameter(commandClasificacionXValorAlarma, "i_detalle", DbType.String);
            db.AddInParameter(commandClasificacionXValorAlarma, "i_codgereg", DbType.String);
            db.AddInParameter(commandClasificacionXValorAlarma, "i_zona", DbType.String);

            db.AddOutParameter(commandClasificacionXValorAlarma, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandClasificacionXValorAlarma, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Clasificacion por valor

        /// <summary>
        /// LISTA TODAS LAS ALARMAS DE UN ESTADO Y/O NIT Y/O CAMPAÑA ESPECIFICO(A)(S)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public List<ClasificacionXValorAlarmaInfo> ListX(ClasificacionXValorAlarmaInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorAlarma, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorAlarma, "i_option", 'A');
            db.SetParameterValue(commandClasificacionXValorAlarma, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorAlarma, "i_nit", item.Nit.Trim());
            db.SetParameterValue(commandClasificacionXValorAlarma, "i_estado", item.Estado);
            db.SetParameterValue(commandClasificacionXValorAlarma, "i_codgereg", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorAlarma, "i_zona", item.Zona);

            IDataReader dr = null;

            ClasificacionXValorAlarmaInfo m = null;
            List<ClasificacionXValorAlarmaInfo> col = new List<ClasificacionXValorAlarmaInfo>();

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorAlarma);

                while (dr.Read())
                {
                    m = Factory.GetClasificacionXValorAlarmaInfo(dr);
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
        /// ACTUALIZACION DE ALARMA
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Update(ClasificacionXValorAlarmaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {

                db.SetParameterValue(commandClasificacionXValorAlarma, "i_operation", 'U');
                db.SetParameterValue(commandClasificacionXValorAlarma, "i_option", 'A');

                db.SetParameterValue(commandClasificacionXValorAlarma, "i_campana", item.Campana);
                db.SetParameterValue(commandClasificacionXValorAlarma, "i_nit", item.Nit);

                db.SetParameterValue(commandClasificacionXValorAlarma, "i_detalle", item.Detalle);

                dr = db.ExecuteReader(commandClasificacionXValorAlarma);

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
        /// CREACION DE ALARMAS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Proceso(ClasificacionXValorAlarmaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {

                db.SetParameterValue(commandClasificacionXValorAlarma, "i_operation", 'U');
                db.SetParameterValue(commandClasificacionXValorAlarma, "i_option", 'A');

                db.SetParameterValue(commandClasificacionXValorAlarma, "i_campana", item.Campana);
                
                dr = db.ExecuteReader(commandClasificacionXValorAlarma);

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
