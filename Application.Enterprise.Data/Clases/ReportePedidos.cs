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
    public class ReportePedidos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand command;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReportePedidos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReportePedidos()
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
            command = db.GetStoredProcCommand("PRC_SVDN_REPORTE_PEDIDOS");

            db.AddInParameter(command, "i_operation", DbType.String);
            db.AddInParameter(command, "i_option", DbType.String);
            
            db.AddInParameter(command, "i_campana_actual", DbType.String);
	        db.AddInParameter(command, "i_campana_anterior", DbType.String);
            db.AddInParameter(command, "i_region", DbType.String);
	        db.AddInParameter(command, "i_zona", DbType.String);
	        db.AddInParameter(command, "i_grupo_usuarios", DbType.String);

            db.AddOutParameter(command, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(command, "o_err_msg", DbType.String, 1000);

        }

        #endregion

        #region Metodos de ReportePedidos

        public List<ReportePedidosInfo> TraerPedidos(string campana_actual, string campana_anterior, string region, string zona, string grupo)
        {
            campana_actual = campana_actual.Substring(2, 2) + campana_actual.Substring(0, 2);
            campana_anterior = campana_anterior.Substring(2, 2) + campana_anterior.Substring(0, 2);

            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'A');

            db.SetParameterValue(command, "i_campana_actual", campana_actual);
            db.SetParameterValue(command, "i_campana_anterior", campana_anterior);

            if (region != "" && region != null) db.SetParameterValue(command, "i_region", region);
            if (zona != "" && zona != null) db.SetParameterValue(command, "i_zona", zona);
            if (grupo != "" && grupo != null) db.SetParameterValue(command, "i_grupo_usuarios", grupo);

            List<ReportePedidosInfo> col = new List<ReportePedidosInfo>();

            IDataReader dr = null;

            ReportePedidosInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory.GetReportePedidos(dr);

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
        /// traer todos los pedidos por campana y grupo
        /// </summary>
        /// <param name="campana_actual"></param>
        /// <param name="campana_anterior"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<ReportePedidosInfo> TraerPedidosTodos(string campana_actual, string campana_anterior,  string grupo)
        {
            
            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'C');

            db.SetParameterValue(command, "i_campana_actual", campana_actual);
            db.SetParameterValue(command, "i_campana_anterior", campana_anterior);
          
            db.SetParameterValue(command, "i_grupo_usuarios", grupo);

            List<ReportePedidosInfo> col = new List<ReportePedidosInfo>();

            IDataReader dr = null;

            ReportePedidosInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory.GetReportePedidos(dr);

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
       /// trae todos los pedidos digitados por grupo y por divisional y por rango de campana
       /// </summary>
       /// <param name="campana_actual"></param>
       /// <param name="campana_anterior"></param>
       /// <param name="divisional"></param>
       /// <param name="grupo"></param>
       /// <returns></returns>
        public List<ReportePedidosInfo> TraerPedidosDivisional(string campana_actual, string campana_anterior, string divisional, string grupo)
        {

            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'D');

            db.SetParameterValue(command, "i_campana_actual", campana_actual);
            db.SetParameterValue(command, "i_campana_anterior", campana_anterior);
            db.SetParameterValue(command, "i_region", divisional);

            db.SetParameterValue(command, "i_grupo_usuarios", grupo);

            List<ReportePedidosInfo> col = new List<ReportePedidosInfo>();

            IDataReader dr = null;

            ReportePedidosInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory.GetReportePedidos(dr);

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
        /// trae todas los pedidos por portal y por zona y campana rango
        /// </summary>
        /// <param name="campana_actual"></param>
        /// <param name="campana_anterior"></param>
        /// <param name="divisional"></param>
        /// <param name="zona"></param>
        /// <param name="grupo"></param>
        /// <returns></returns>
        public List<ReportePedidosInfo> TraerPedidosZona(string campana_actual, string campana_anterior, string divisional,string zona, string grupo)
        {

            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'E');

            db.SetParameterValue(command, "i_campana_actual", campana_actual);
            db.SetParameterValue(command, "i_campana_anterior", campana_anterior);
            db.SetParameterValue(command, "i_region", divisional);
            db.SetParameterValue(command, "i_zona", zona);

            db.SetParameterValue(command, "i_grupo_usuarios", grupo);

            List<ReportePedidosInfo> col = new List<ReportePedidosInfo>();

            IDataReader dr = null;

            ReportePedidosInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory.GetReportePedidos(dr);

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