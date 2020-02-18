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
    public class VisitaEmpresaria
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandVisitaEmpresaria;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public VisitaEmpresaria(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public VisitaEmpresaria()
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
            commandVisitaEmpresaria = db.GetStoredProcCommand("PRC_SVDN_VISITAEMPRESARIA");

            db.AddInParameter(commandVisitaEmpresaria, "i_operation", DbType.String);
            db.AddInParameter(commandVisitaEmpresaria, "i_option", DbType.String);

            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_id", DbType.Int32);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_nit", DbType.String);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_tipovisita", DbType.Int32);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_fechavisita", DbType.DateTime);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_horavisita", DbType.String);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_campana", DbType.String);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_observacion", DbType.String);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_sysdate", DbType.DateTime);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_estado", DbType.Boolean);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_zona", DbType.String);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_vendedor", DbType.String);
            db.AddInParameter(commandVisitaEmpresaria, "i_estadoempresaria", DbType.Int32);
            db.AddInParameter(commandVisitaEmpresaria, "i_vip_id", DbType.Int32);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_fechadesde", DbType.DateTime);
            db.AddInParameter(commandVisitaEmpresaria, "i_rvi_fechahasta", DbType.DateTime);                        
            db.AddInParameter(commandVisitaEmpresaria, "i_iddivisional", DbType.Int32);
            db.AddInParameter(commandVisitaEmpresaria, "i_codciudad", DbType.String);   

            db.AddOutParameter(commandVisitaEmpresaria, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandVisitaEmpresaria, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de VisitaEmpresaria

        /// <summary>
        /// Lista todos las visitas de empresarias existentes.
        /// </summary>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> List()
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'A');

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetVisitaEmpresaria(dr);

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
        /// Lista todos las visitas de empresarias existentes x zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxZona(string Zona)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'B');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", Zona);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetVisitaEmpresaria(dr);

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
        /// Reporte General de visitas a empresarias x fecha.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReporteGeneral(DateTime FechaDesde, DateTime FechaHasta)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'C');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", FechaDesde);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", FechaHasta);
            

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetVisitaEmpresariaReporteGeneral(dr);

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
        /// Reporte General de visitas a empresarias x fecha.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReporteFiltrosGeneral(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'D');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias para todos los filtros sin seleccionar uno solo.
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReporteSinFiltros(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'E');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x estados de empresarias
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexEstadoEmpresaria(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'F');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x campañas
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexCampanas(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'G');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Zona
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexZona(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'H');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Division
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivision(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'I');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Division x Campaña
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivisionxCampana(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'J');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Division x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivisionxEstado(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'K');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Zona x Campaña
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexZonaxCampana(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'L');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Zona x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexZonaxEstado(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'M');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Campaña x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexCampanaxEstado(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'N');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Lista todos las visitas de empresarias x Division x Zona x Campaña x Estado
        /// </summary>
        /// <param name="FechaDesde"></param>
        /// <param name="FechaHasta"></param>
        /// <returns></returns>
        public List<VisitaEmpresariaInfo> ListxReportexDivisionxZonaxCampanaxEstado(VisitaEmpresariaInfo item)
        {
            db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'S');
            db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'O');
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
            db.SetParameterValue(commandVisitaEmpresaria, "i_iddivisional", item.IdDivisional);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechadesde", item.FechaInicio);
            db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechahasta", item.FechaFin);
            db.SetParameterValue(commandVisitaEmpresaria, "i_estadoempresaria", item.IdEstadoCliente);
            db.SetParameterValue(commandVisitaEmpresaria, "i_codciudad", item.CodCiudad);

            List<VisitaEmpresariaInfo> col = new List<VisitaEmpresariaInfo>();

            IDataReader dr = null;

            VisitaEmpresariaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVisitaEmpresaria);

                while (dr.Read())
                {
                    m = Factory.GetReporteFiltrosGeneral(dr);

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
        /// Guarda una visita a empresaria.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(VisitaEmpresariaInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'I');
                db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'A');

                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_nit", item.Nit);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_tipovisita", item.TipoVisita);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechavisita", item.FechaVisita);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_horavisita", item.HoraVisita);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_observacion", item.Observacion);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_sysdate", item.Sysdate);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_estado", item.Estado);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_vendedor", item.Vendedor);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_vendedor", item.Vendedor);
                db.SetParameterValue(commandVisitaEmpresaria, "i_vip_id", item.IdVisitaPositiva);

                dr = db.ExecuteReader(commandVisitaEmpresaria);

                //Obtiene el identificador (consecutivo) del insert
                //id = Convert.ToInt32(db.GetParameterValue(commandVisitaEmpresaria, "i_dsc_id"));
                id = 1;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de visita a empresaria.  NIT:" + item.Nit + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de una visita a empresaria.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(VisitaEmpresariaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'U');
                db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'A');

                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_id", item.Id);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_nit", item.Nit);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_tipovisita", item.TipoVisita);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_fechavisita", item.FechaVisita);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_horavisita", item.HoraVisita);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_campana", item.Campana);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_observacion", item.Observacion);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_sysdate", item.Sysdate);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_estado", item.Estado);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_zona", item.Zona);
                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_vendedor", item.Vendedor);

                dr = db.ExecuteReader(commandVisitaEmpresaria);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó actualización de visita a empresaria. Nuevos Valores para Id:" + item.Id + ", NIT:" + item.Nit + ". Acción Realizada por el Usuario: " + item.Usuario;

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


        /// <summary>
        /// Elimina una visita a empresaria.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool Delete(int Id, string Usuario)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandVisitaEmpresaria, "i_operation", 'D');
                db.SetParameterValue(commandVisitaEmpresaria, "i_option", 'A');

                db.SetParameterValue(commandVisitaEmpresaria, "i_rvi_id", Id);

                dr = db.ExecuteReader(commandVisitaEmpresaria);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la eliminación de visita a empresaria. Visita Id:" + Id + ". Acción Realizada por el Usuario: " + Usuario;

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