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
    public class MatrizComercialJA
    {
         /// <summary>
        /// matriz comercial JA
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMatrizComercialJA;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MatrizComercialJA(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MatrizComercialJA()
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
            commandMatrizComercialJA = db.GetStoredProcCommand("PRC_SVDN_MATRIZ_COMERCIAL_J_LISTAR");

            db.AddInParameter(commandMatrizComercialJA, "i_operation", DbType.String);
            db.AddInParameter(commandMatrizComercialJA, "i_option", DbType.String);

            db.AddInParameter(commandMatrizComercialJA, "i_campanaini", DbType.String);
            db.AddInParameter(commandMatrizComercialJA, "i_campanafin", DbType.String);
            db.AddInParameter(commandMatrizComercialJA, "i_fechaini", DbType.DateTime);
            db.AddInParameter(commandMatrizComercialJA, "i_fechafin", DbType.DateTime);
            db.AddInParameter(commandMatrizComercialJA, "i_zona", DbType.String);
            db.AddInParameter(commandMatrizComercialJA, "i_divisional", DbType.String);
            db.AddInParameter(commandMatrizComercialJA, "i_estado", DbType.String);

            db.AddOutParameter(commandMatrizComercialJA, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMatrizComercialJA, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        /// <summary>
        /// Traer las campanas completas
        /// </summary>
        /// <returns></returns>
        public DataTable traerCampanas()
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'A');            

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Traer las campanas mayores a la seleccionada
        /// </summary>
        /// <returns></returns>
        public DataTable traerCampanasMayores(DateTime campanaini)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'A');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campanaini);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'C');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Traer divisionales por zona seleccionada
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerZonasXDivisionales(String division)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'D');
            db.SetParameterValue(commandMatrizComercialJA, "i_divisional", division);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Traer Zona por zona seleccionada
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public ZonaInfo  traerZonasXZona(String zona)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'Q');
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", zona);

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

                if (dr.Read())
                {
                    m = Factory.GetZonaMatriz(dr);
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

        #region LISTAR

        /// <summary>
        /// Traer todos los datos de una divisional por campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerxDivisionalYCampana(String division, String campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'E');
            db.SetParameterValue(commandMatrizComercialJA, "i_divisional", division);
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Traer todos los datos de las divisionales de una campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerDivisionales(String campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'F');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
            

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        ///end divisiones////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Lista todas los datos de las zonas x campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxCampana(String campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'G');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
           


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todas los datos de las zonas por divional y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        public DataTable traerDatosxDivisionalYCampana(String divisional, String campana, String campanafin)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'H');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_campanafin", campanafin);
            db.SetParameterValue(commandMatrizComercialJA, "i_divisional", divisional);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todas los datos de las zonas por divional y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxDivisionalYCampana(String divisional, String campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'X');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);            
            db.SetParameterValue(commandMatrizComercialJA, "i_divisional", divisional);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todas los datos de las zonas por zona y campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxZonaYCampana(String zona, String campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'I');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", zona);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todas los datos de las zonas por divional, campana y zona
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="divisional"></param>
        /// <returns></returns>
        public DataTable traerDatosZonasxDivisionalCampanaYZona(String campana, String divisional, String zona)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'J');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_divisional", divisional);
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", zona);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        ////////////////////// end zonas ////////////////////////////////////
        
        /// <summary>
        /// Lista todas los datos de las campanas por  rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        public DataTable traerDatoscampanaxRangoCampana(DateTime campana,  DateTime campanafin)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'K');
            db.SetParameterValue(commandMatrizComercialJA, "i_fechaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_fechafin", campanafin);
            


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
       /// Lista todas los datos de las campanas por divisional, rango campana
       /// </summary>
       /// <param name="campana"></param>
       /// <param name="divisional"></param>
       /// <param name="campanafin"></param>
       /// <returns></returns>
        public DataTable traerDatoscampanaxDivisionalYRangoCampana(DateTime campana, String divisional, DateTime campanafin)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'L');
            db.SetParameterValue(commandMatrizComercialJA, "i_fechaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_fechafin", campanafin);
            db.SetParameterValue(commandMatrizComercialJA, "i_divisional", divisional);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todas los datos de las campanas por zona, rango campana
        /// </summary>
        /// <param name="campana"></param>
        /// <param name="zona"></param>
        /// <param name="campanafin"></param>
        /// <returns></returns>
        public DataTable traerDatoscampanaxZonaYRangoCampana(DateTime campana, String zona, DateTime campanafin)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'M');
            db.SetParameterValue(commandMatrizComercialJA, "i_fechaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_fechafin", campanafin);
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", zona);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
     /// Lista todos los datos de campana x zona rango de campana y divisional
     /// </summary>
     /// <param name="campana"></param>
     /// <param name="zona"></param>
     /// <param name="campanafin"></param>
     /// <param name="divisional"></param>
     /// <returns></returns>
        public DataTable traerDatoscampanaxZonaYRangoCampanaYDivisional(DateTime campana, String zona, DateTime campanafin,String divisional)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'N');
            db.SetParameterValue(commandMatrizComercialJA, "i_fechaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_fechafin", campanafin);
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", zona);
            db.SetParameterValue(commandMatrizComercialJA, "i_divisional", divisional);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todos los datos de Empresarias por estado X
      /// </summary>
      /// <param name="Estado"></param>
      /// <param name="campana"></param>
      /// <param name="Zona"></param>
      /// <returns></returns>
        public DataTable traerDatosEmpresariasEstado(String Estado, String campana, String Zona)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'O');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_estado", Estado);
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", Zona);
          


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todos los datos de Empresarias por estado (1,2,6,7)
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public DataTable traerDatosEmpresariasActivas(String campana, String Zona)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'P');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);           
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", Zona);



            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista todos los datos de Empresarias con pedidos en la campaña y zona 
        /// </summary>
        /// <param name="Estado"></param>
        /// <param name="campana"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public DataTable traerDatosEmpresariasPedidos(String campana, String Zona)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", 'R');
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_zona", Zona);



            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Traer todos los datos de las divisionales de una campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public DataTable traerPais(String campana,string campanafin)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", "D2");
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);
            db.SetParameterValue(commandMatrizComercialJA, "i_campanafin", campanafin);


            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

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
        /// Lista el reporte de estados de las empresarias x campaña.
        /// </summary>
        /// <param name="IdEstado"></param>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<ClienteInfo> ListEstadosEmpresariasxCampana(int IdEstado, string Campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", "W");
            db.SetParameterValue(commandMatrizComercialJA, "i_estado", IdEstado);
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", Campana);

            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

                while (dr.Read())
                {
                    m = Factory.GetClientexEstadosClienteMisEmpresariasJA(dr);

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

        #region COSAS DE LA MATRIZ VIEJA FEA
        /// <summary>
        /// Lista las nuevas que fueron prospecto
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> NuevasProspecto(string campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", "S");
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);


            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

                while (dr.Read())
                {
                    m = Factory.GetClienteNuevasReport(dr);

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
        /// Lista las nuevas que fueron referido
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> NuevasReferido(string campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", "U");
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);


            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

                while (dr.Read())
                {
                    m = Factory.GetClienteNuevasReport(dr);

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
        /// Lista las nuevas que fueron 18 campana
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> Nuevas18Campana(string campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", "T");
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);


            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

                while (dr.Read())
                {
                    m = Factory.GetClienteNuevasReport(dr);

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
        /// Lista las nuevas 
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        public List<ClienteInfo> Nuevas(string campana)
        {
            db.SetParameterValue(commandMatrizComercialJA, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercialJA, "i_option", "V");
            db.SetParameterValue(commandMatrizComercialJA, "i_campanaini", campana);


            List<ClienteInfo> col = new List<ClienteInfo>();

            IDataReader dr = null;

            ClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercialJA);

                while (dr.Read())
                {
                    m = Factory.GetClienteNuevasReport(dr);

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
