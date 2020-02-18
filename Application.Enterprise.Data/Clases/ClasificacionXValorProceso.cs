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
    public class ClasificacionXValorProceso
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandClasificacionXValorProceso;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ClasificacionXValorProceso(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ClasificacionXValorProceso()
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
            commandClasificacionXValorProceso = db.GetStoredProcCommand("PRC_SVDN_CLASIFICACIONXVALORPROCESO");

            db.AddInParameter(commandClasificacionXValorProceso, "i_operation", DbType.String);
            db.AddInParameter(commandClasificacionXValorProceso, "i_option", DbType.String);

            db.AddInParameter(commandClasificacionXValorProceso, "i_campana", DbType.String);
            db.AddInParameter(commandClasificacionXValorProceso, "i_nit", DbType.String);
            db.AddInParameter(commandClasificacionXValorProceso, "i_reg_codregional", DbType.String);
            db.AddInParameter(commandClasificacionXValorProceso, "i_zona", DbType.String);

            db.AddOutParameter(commandClasificacionXValorProceso, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandClasificacionXValorProceso, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Clasificacion por valor

        /// <summary>
        /// Traer todas las empresarias por campaña
        /// </summary>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> List(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'A');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);

            List<ClasificacionXValorProcesoInfo> col = new List<ClasificacionXValorProcesoInfo>();

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                while (dr.Read())
                {
                    m = Factory.GetClasificacionXValorProcesoInfo(dr);

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
        /// Traer todas las empresarias por campañay Nit
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXNit(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'B');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_nit", item.Nit);

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                if (dr.Read()) m = Factory.GetClasificacionXValorProcesoInfo(dr);
                else m = null;
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
        /// Traer promedios por campaña primera division
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXPrimerCuadrante(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'C');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_reg_codregional", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_zona", item.Zona);


            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                if (dr.Read()) m = Factory.GetClasificacionXValorProcesoInfo(dr);
                else m = null;
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
        /// Traer promedios por campaña segunda division
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXSegundoCuadrante(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'D');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_reg_codregional", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_zona", item.Zona);

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                if (dr.Read()) m = Factory.GetClasificacionXValorProcesoInfo(dr);
                else m = null;
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
        /// Trae orden promedio Maximo
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXOrdenPromedioMaximo(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'E');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_reg_codregional", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_zona", item.Zona);

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                if (dr.Read()) m = Factory.GetClasificacionXValorProcesoInfo(dr);
                else m = null;
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
        /// -- Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListConFiltro(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'F');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_reg_codregional", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_zona", item.Zona);

            List<ClasificacionXValorProcesoInfo> col = new List<ClasificacionXValorProcesoInfo>();

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                while (dr.Read())
                {
                    m = Factory.GetClasificacionXValorProcesoInfo(dr);

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
        /// -- Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListConFiltroEstados(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'J');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_reg_codregional", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_zona", item.Zona);

            List<ClasificacionXValorProcesoInfo> col = new List<ClasificacionXValorProcesoInfo>();

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                while (dr.Read())
                {
                    m = Factory.GetClasificacionXValorProcesoInfo(dr);

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
        /// -- Trae todas las empresarias filtradas por los valores de frecuencia y orden en caso de que se repitan dichos valores
        /// </summary>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListConFiltroCount(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'I');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_reg_codregional", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_zona", item.Zona);

            List<ClasificacionXValorProcesoInfo> col = new List<ClasificacionXValorProcesoInfo>();

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                while (dr.Read())
                {
                    m = Factory.GetClasificacionXValorProcesoInfo(dr);

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
        /// -- Trae cantidades de empresarias por clasificacion filtradas por region y zona 
        /// </summary>
        /// <returns></returns>
        public List<ClasificacionXValorProcesoInfo> ListCantidadesConFiltro(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'G');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_reg_codregional", item.Codgereg);
            db.SetParameterValue(commandClasificacionXValorProceso, "i_zona", item.Zona);

            List<ClasificacionXValorProcesoInfo> col = new List<ClasificacionXValorProcesoInfo>();

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                while (dr.Read())
                {
                    m = Factory.GetClasificacionXValorProcesoInfo(dr);

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
        /// Trae cantidades de empresarias por clasificacion filtradas por region y zona 
        /// </summary>
        /// <returns></returns>
        public ClasificacionXValorProcesoInfo ListXNitUltimaCampana(ClasificacionXValorProcesoInfo item)
        {
            db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'S');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'H');
            db.SetParameterValue(commandClasificacionXValorProceso, "i_nit", item.Nit);

            IDataReader dr = null;

            ClasificacionXValorProcesoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandClasificacionXValorProceso);

                if (dr.Read()) m = Factory.GetClasificacionXValorProcesoInfo(dr);
                else m = null;
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
        /// Proceso de clasificacion de empresarias una campaña determinada
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public bool Update(ClasificacionXValorProcesoInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {

                db.SetParameterValue(commandClasificacionXValorProceso, "i_operation", 'U');
                db.SetParameterValue(commandClasificacionXValorProceso, "i_option", 'A');

                db.SetParameterValue(commandClasificacionXValorProceso, "i_campana", item.Campana);

                commandClasificacionXValorProceso.CommandTimeout = 600;

                dr = db.ExecuteReader(commandClasificacionXValorProceso);

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
