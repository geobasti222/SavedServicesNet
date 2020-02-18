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
    public class ReporteVentas
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
        public ReporteVentas(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReporteVentas()
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
            command = db.GetStoredProcCommand("PRC_SVDN_REPORTE_VENTAS");

            db.AddInParameter(command, "i_operation", DbType.String);
            db.AddInParameter(command, "i_option", DbType.String);

            db.AddInParameter(command, "i_fecha_ini", DbType.Date);
            db.AddInParameter(command, "i_fecha_fin", DbType.Date);

            db.AddOutParameter(command, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(command, "o_err_msg", DbType.String, 1000);

        }

        #endregion

        #region Metodos de ReportePedidos

        public List<ReporteVentasInfo> TraerRegistroDeVentasEIngresos(DateTime fecha_ini, DateTime fecha_fin)
        {
            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'A');

            db.SetParameterValue(command, "i_fecha_ini", fecha_ini);
            db.SetParameterValue(command, "i_fecha_fin", fecha_fin);

            List<ReporteVentasInfo> col = new List<ReporteVentasInfo>();

            IDataReader dr = null;

            ReporteVentasInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory.GetReporteVentasInfo(dr);

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


        public List<ReporteVentasInfo> TraerRegistroDeVentasEIngresosM(DateTime fecha_ini, DateTime fecha_fin)
        {
            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'B');

            db.SetParameterValue(command, "i_fecha_ini", fecha_ini);
            db.SetParameterValue(command, "i_fecha_fin", fecha_fin);

            List<ReporteVentasInfo> col = new List<ReporteVentasInfo>();

            IDataReader dr = null;

            ReporteVentasInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory.GetReporteVentasMInfo(dr);

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



        public List<ReporteVentasInfo> TraerRegistroDeVentasEIngresosIquitos(DateTime fecha_ini, DateTime fecha_fin)
        {
            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'C');

            db.SetParameterValue(command, "i_fecha_ini", fecha_ini);
            db.SetParameterValue(command, "i_fecha_fin", fecha_fin);

            List<ReporteVentasInfo> col = new List<ReporteVentasInfo>();

            IDataReader dr = null;

            ReporteVentasInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory.GetReporteVentasMInfo(dr);

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