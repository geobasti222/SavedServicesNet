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
    /// ClasificacionPorValor JA
    /// </summary>
    public class ClasificacionPorValor
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCxV;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ClasificacionPorValor(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ClasificacionPorValor()
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
            commandCxV = db.GetStoredProcCommand("PRC_SVDN_CXV2");

            db.AddInParameter(commandCxV, "i_operation", DbType.String);
            db.AddInParameter(commandCxV, "i_option", DbType.String);
            db.AddInParameter(commandCxV, "i_zona", DbType.String);
            db.AddInParameter(commandCxV, "i_region", DbType.String);    
            db.AddInParameter(commandCxV, "i_campana", DbType.String);
            db.AddInParameter(commandCxV, "campana", DbType.String);   

        }
        #endregion

        #region Metodos de Clasificacion
        
        /// <summary>
        /// Traer las campanas completas
        /// </summary>
        /// <returns></returns>
        public DataTable traerCampanas()
        {
            db.SetParameterValue(commandCxV, "i_option", '2');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCxV);

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
        /// Traer divisionales completas
        /// </summary>
        /// <returns></returns>
        public DataTable traerDivisionales()
        {
            db.SetParameterValue(commandCxV, "i_option", '3');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCxV);

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
        /// Traer zonas por divisional seleccionada
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerZonasXDivisionales(String division)
        {
            db.SetParameterValue(commandCxV, "i_option", '4');
            db.SetParameterValue(commandCxV, "i_codregional", division);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCxV);

                //while (dr.Read())
                //{
                //    System.Diagnostics.Trace.WriteLine("h1");
                //}

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
        /// lista todos las nits por zona campana
        /// </summary>
        /// <returns></returns>
        public List<CxVNitsInfo> ListxLosnits(string zona,string campana)
        {           
            db.SetParameterValue(commandCxV, "i_option", '5');
            db.SetParameterValue(commandCxV, "i_zona", zona);
            db.SetParameterValue(commandCxV, "i_campana", campana);
            
            List<CxVNitsInfo> col = new List<CxVNitsInfo>();

            IDataReader dr = null;

            CxVNitsInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getcxvnits(dr);

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
        /// trae promedio por agrupado y campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public clasificacionPorValorInfo traePromedio(string campana)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'B');
            db.SetParameterValue(commandCxV, "i_campana", campana);

            clasificacionPorValorInfo m = null;

            IDataReader dr = null;
           

            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);                    
                }
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

            return m;
        }

        /// <summary>
        /// trae promedio por agrupado y campana AA
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public clasificacionPorValorInfo traePromedioAA(string campana)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'C');
            db.SetParameterValue(commandCxV, "i_campana", campana);

            clasificacionPorValorInfo m = null;

            IDataReader dr = null;


            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);
                }
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

            return m;
        }


        /// <summary>
        /// trae todos los datos por campana detallado
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxCampana(string campana, string zona)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'A');
            db.SetParameterValue(commandCxV, "i_campana", campana);
            db.SetParameterValue(commandCxV, "i_zona", zona);

            clasificacionPorValorInfo m = null;
            List<clasificacionPorValorInfo> d = new List<clasificacionPorValorInfo>();

            IDataReader dr = null;


            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);
                    d.Add(m);
                }
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

            return d;
        }

        /// <summary>
        /// trae todos los totales
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxCampanaValores(string campana)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'E');
            db.SetParameterValue(commandCxV, "i_campana", campana);

            clasificacionPorValorInfo m = null;
            List<clasificacionPorValorInfo> d = new List<clasificacionPorValorInfo>();

            IDataReader dr = null;


            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);
                    d.Add(m);
                }
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

            return d;
        }


        /// <summary>
        /// trae max de OP
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public clasificacionPorValorInfo traeMAXOP(string campana)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'F');
            db.SetParameterValue(commandCxV, "i_campana", campana);

            clasificacionPorValorInfo m = null;           

            IDataReader dr = null;


            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);                   
                }
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

            return m;
        }


        /// <summary>
        /// trae todos los totales por region
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxRegion(string campana,string region)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'G');
            db.SetParameterValue(commandCxV, "i_campana", campana);
            db.SetParameterValue(commandCxV, "i_region", region);

            clasificacionPorValorInfo m = null;
            List<clasificacionPorValorInfo> d = new List<clasificacionPorValorInfo>();

            IDataReader dr = null;


            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);
                    d.Add(m);
                }
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

            return d;
        }


       

        /// <summary>
        /// Trae las dos ultimas campañas actuales
        /// </summary>
        /// <returns></returns>
        public DataTable    traerInformacionDeCampanaParaProcesar()
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'H');


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCxV);

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
        /// proceso clasificacion x valor
        /// </summary>
        /// <returns></returns>
        public bool proceso(string campana)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'P');
            db.SetParameterValue(commandCxV, "i_option", 'A');
            db.SetParameterValue(commandCxV, "campana", 'A');
            bool chi = false;

            IDataReader dr = null;
            

            try
            {
                dr = db.ExecuteReader(commandCxV);

                chi = true;
            }
            catch (Exception ex)
            {
                chi = false;
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

            return chi;
        }



        /// <summary>
        /// trae todos los datos por campana detallado region
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxCampanaRegion(string campana, string region)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'I');
            db.SetParameterValue(commandCxV, "i_campana", campana);
            db.SetParameterValue(commandCxV, "i_region", region);

            clasificacionPorValorInfo m = null;
            List<clasificacionPorValorInfo> d = new List<clasificacionPorValorInfo>();

            IDataReader dr = null;


            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);
                    d.Add(m);
                }
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

            return d;
        }



        /// <summary>
        /// lista todos las campañas existentes.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> List()
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'J');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.GetCampana(dr);

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
        /// trae todos los orncejtaes por zona
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<clasificacionPorValorInfo> traeDatosxPorcentajeZona(string campana, string zona)
        {
            db.SetParameterValue(commandCxV, "i_operation", 'S');
            db.SetParameterValue(commandCxV, "i_option", 'K');
            db.SetParameterValue(commandCxV, "i_campana", campana);
            db.SetParameterValue(commandCxV, "i_zona", zona);

            clasificacionPorValorInfo m = null;
            List<clasificacionPorValorInfo> d = new List<clasificacionPorValorInfo>();

            IDataReader dr = null;


            try
            {
                dr = db.ExecuteReader(commandCxV);

                while (dr.Read())
                {
                    m = Factory.getclasificacionporvalor(dr);
                    d.Add(m);
                }
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

            return d;
        }

        #endregion
    }
}
