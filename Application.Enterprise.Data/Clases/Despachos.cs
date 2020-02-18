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
    public class Despachos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandDespachos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Despachos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Despachos()
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
            commandDespachos = db.GetStoredProcCommand("PRC_SVDN_DESPACHOS");

            db.AddInParameter(commandDespachos, "i_operation", DbType.String);
            db.AddInParameter(commandDespachos, "i_option", DbType.String);
            db.AddInParameter(commandDespachos, "i_vendedor", DbType.String);
            db.AddInParameter(commandDespachos, "i_campana", DbType.String);
            db.AddInParameter(commandDespachos, "i_numero", DbType.String);
            db.AddInParameter(commandDespachos, "i_nit", DbType.String);
            db.AddInParameter(commandDespachos, "i_idlider", DbType.String);

            db.AddInParameter(commandDespachos, "i_fecha", DbType.String);
            db.AddInParameter(commandDespachos, "i_zona", DbType.String);

            db.AddOutParameter(commandDespachos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandDespachos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Despachos

        /// <summary>
        /// lista todos los despachos existentes.
        /// </summary>
        /// <returns></returns>
        public List<DespachosInfo> List()
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'A');

            List<DespachosInfo> col = new List<DespachosInfo>();

            IDataReader dr = null;

            DespachosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachos(dr);

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
        /// Lista los despachos de un vendedor por campana.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxVendedorxCampanaActual(string IdVendedor, string Campana)
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'B');
            db.SetParameterValue(commandDespachos, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandDespachos, "i_campana", Campana);

            List<DespachosInfo> col = new List<DespachosInfo>();

            IDataReader dr = null;

            DespachosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachos(dr);

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
        /// Lista los despachos x cedula de la empresaria o numero de pedido.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxDespachoxCedulaxPedido(string Nit, string NumeroPedido)
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'C');
            db.SetParameterValue(commandDespachos, "i_nit", Nit);
            db.SetParameterValue(commandDespachos, "i_numero", NumeroPedido);

            List<DespachosInfo> col = new List<DespachosInfo>();

            IDataReader dr = null;

            DespachosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachosSAC(dr);

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
        /// Lista los despachos de una empresaria por campana.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxNitxCampanaActual(string Nit, string Campana)
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'D');
            db.SetParameterValue(commandDespachos, "i_nit", Nit);
            db.SetParameterValue(commandDespachos, "i_campana", Campana);

            List<DespachosInfo> col = new List<DespachosInfo>();

            IDataReader dr = null;

            DespachosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachos(dr);

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
        /// Lista los pedidos despachados de un lider x campaña.
        /// </summary>
        /// <param name="IdLider"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListPedidosDespachadosxLider(string IdLider, string Campana)
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'E');
            db.SetParameterValue(commandDespachos, "i_idlider", IdLider);
            db.SetParameterValue(commandDespachos, "i_campana", Campana);

            List<DespachosInfo> col = new List<DespachosInfo>();

            IDataReader dr = null;

            DespachosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachos(dr);

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
        ///  Ejecuta Consulta de informe de Despachos por MES
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<DespachosVInfo> ListXFecha(string fecha)
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'D');
            db.SetParameterValue(commandDespachos, "i_fecha", fecha);

            

            List<DespachosVInfo> col = new List<DespachosVInfo>();

            IDataReader dr = null;

            DespachosVInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachosV(dr);

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
        /// Lista los despachos de un vendedor por campana para Zona Maestra.
        /// </summary>
        /// <param name="ZonaMaestra"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxVendedorxCampanaActualZonaMaestra(string ZonaMaestra, string Campana)
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'E');
            db.SetParameterValue(commandDespachos, "i_zona", ZonaMaestra);
            db.SetParameterValue(commandDespachos, "i_campana", Campana);

            List<DespachosInfo> col = new List<DespachosInfo>();

            IDataReader dr = null;

            DespachosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachos(dr);

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


        #region Asistentes

        /// <summary>
        /// -- GAVL  Lista los despachos de un vendedor X Asistente por campana.
        /// </summary>
        /// <param name="IdVendedor"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<DespachosInfo> ListxVendedorxCampanaActualxAsistente(string IdVendedor, string Campana)
        {
            db.SetParameterValue(commandDespachos, "i_operation", 'S');
            db.SetParameterValue(commandDespachos, "i_option", 'F');
            db.SetParameterValue(commandDespachos, "i_vendedor", IdVendedor);
            db.SetParameterValue(commandDespachos, "i_campana", Campana);

            List<DespachosInfo> col = new List<DespachosInfo>();

            IDataReader dr = null;

            DespachosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDespachos);

                while (dr.Read())
                {
                    m = Factory.GetDespachos(dr);

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