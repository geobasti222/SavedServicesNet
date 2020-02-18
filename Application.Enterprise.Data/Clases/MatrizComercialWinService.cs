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
    public class MatrizComercialWinService
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMatrizComercialWinService;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MatrizComercialWinService(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MatrizComercialWinService()
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
            commandMatrizComercialWinService = db.GetStoredProcCommand("PRC_SVDN_MATRIZ_COMERCIAL_J_DETALLADO_UNITARIO");


            db.AddInParameter(commandMatrizComercialWinService, "i_option", DbType.String);

            db.AddInParameter(commandMatrizComercialWinService, "i_campana", DbType.String);
            db.AddInParameter(commandMatrizComercialWinService, "i_rangocampañanuevas", DbType.Int32);        

            db.AddOutParameter(commandMatrizComercialWinService, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMatrizComercialWinService, "o_err_msg", DbType.String, 1000);

            commandMatrizComercialWinService.CommandTimeout = 2000;

        }
        #endregion

        /// <summary>
        /// Trae las dos ultimas campañas actuales
        /// </summary>
        /// <returns></returns>
        public DataTable traerInformacionDeCampanaParaProcesar( )
        {           
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", 'A');

         
            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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

            return dt;
        }

        /// <summary>
        /// Primer proceso averiguar estados y almacenar en historico y en corpus
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="rangoparanuevas"></param>
        /// <param name="campana"></param>
        public void proceso01(int rangoparanuevas, string campana)
        {
        
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '1');

            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);
            db.SetParameterValue(commandMatrizComercialWinService, "i_rangocampañanuevas", rangoparanuevas);
         
            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        /// Segundo proceso trae los valores de facturas pedidos y devoluciones y los pone en la empresaria correspondiente en el historico
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="rangoparanuevas"></param>
        /// <param name="campana"></param>
        public void proceso02(string campana)
        {

            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '2');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);         

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        /// PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS ESTADOSANTERIORES POR LA MATRIZ VIEJA FEA-
        /// </summary>
        /// <param name="campana"></param>
        public void proceso03(string campana)
        {
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '3');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        /// CALCULA LOS VALORES(totalempresariasactivas,totalingresos,estencil,capitalizacion) CON BASE A LOS ESTADOS EN EL RESUMEN (CORPUS)
        /// </summary>
        /// <param name="campana"></param>
        public void proceso04(string campana)
        {
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '4');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        /// PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA Y CAMPANA DE METAS EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso05(string campana)
        {
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '5');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        /// EGIN VARIABLES CALCULADAS CON BASE A ESTADOS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso06(string campana)
        {
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '6');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        ///  BEGIN PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA PORCENTAJES Y CAMPANA DE PORCENTAJES EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso07(string campana)
        {
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '7');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        ///  BEGIN PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA DE PEDIDOS Y CAMPANA DE PEDIDOS EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso08(string campana)
        {
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '8');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

        /// <summary>
        /// BEGIN PARTE SUPERMEGAPODEROSA QUE HACE LA INSERCION DE LOS DATOS POR ZONA Y CAMPANA DE FACTURAS EN LA MATRIZ CORPUS
        /// </summary>
        /// <param name="campana"></param>
        public void proceso09(string campana)
        {
            db.SetParameterValue(commandMatrizComercialWinService, "i_option", '9');
            db.SetParameterValue(commandMatrizComercialWinService, "i_campana", campana);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialWinService);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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
        }

    }
}
