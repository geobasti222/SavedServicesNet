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
    public class CommercialMatrix
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCommercialMatrix;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CommercialMatrix(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CommercialMatrix()
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
            commandCommercialMatrix = db.GetStoredProcCommand("PRC_SVDN_MATRIZCOMERCIAL");

            db.AddInParameter(commandCommercialMatrix, "i_operation", DbType.String);
            db.AddInParameter(commandCommercialMatrix, "i_option", DbType.String);

            db.AddInParameter(commandCommercialMatrix, "i_campana_actual", DbType.String);
            db.AddInParameter(commandCommercialMatrix, "i_campana_anterior", DbType.String);
            db.AddInParameter(commandCommercialMatrix, "i_fecha_inicio", DbType.DateTime);
            db.AddInParameter(commandCommercialMatrix, "i_fecha_fin", DbType.DateTime);

            db.AddInParameter(commandCommercialMatrix, "i_mailgroup", DbType.Int32);
            db.AddInParameter(commandCommercialMatrix, "i_region", DbType.Int32);
            //MAO:db.AddInParameter(commandCommercialMatrix, "i_asistente", DbType.String);
            db.AddInParameter(commandCommercialMatrix, "i_zona", DbType.String);
            db.AddInParameter(commandCommercialMatrix, "i_esc_id", DbType.Int32);
            db.AddInParameter(commandCommercialMatrix, "i_vista", DbType.Int32);
            
            db.AddOutParameter(commandCommercialMatrix, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCommercialMatrix, "o_err_msg", DbType.String, 1000);

            commandCommercialMatrix.CommandTimeout = 2000;

        }
        #endregion

        #region Metodos de CommercialMatrix

        /// <summary>
        /// Traer la Matriz Comercial Completa
        /// </summary>
        /// <returns></returns>
        public DataTable traerCampanas(int vistaCampanas)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'A');
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vistaCampanas);
            
            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerDivisiones()
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'E');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerZonasXDivisiones(int division)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'F');
            db.SetParameterValue(commandCommercialMatrix, "i_region", division);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerMailgroups()
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'D');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerAsistentes()
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'Q');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerZonasXMailgroups(int mailgroup)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'G');
            db.SetParameterValue(commandCommercialMatrix, "i_mailgroup", mailgroup);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerZonasXAsistentes(string asistente)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'R');
            db.SetParameterValue(commandCommercialMatrix, "i_asistente", asistente);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialCompleta(string cpini, string cpfin, int vista)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", cpfin);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialCompletaXDivision(string cpini, string cpfin, int vista, int division)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", cpfin);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);
            db.SetParameterValue(commandCommercialMatrix, "i_region", division);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialCompletaXMailgroup(string cpini, string cpfin, int vista, int mailgroup)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", cpfin);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);
            db.SetParameterValue(commandCommercialMatrix, "i_mailgroup", mailgroup);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialCompletaXAsistente(string cpini, string cpfin, int vista, string asistente)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", cpfin);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);
            db.SetParameterValue(commandCommercialMatrix, "i_asistente", asistente);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialCompletaXZona(string cpini, string cpfin, int vista, string zona)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", cpfin);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);
            db.SetParameterValue(commandCommercialMatrix, "i_zona", zona);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialDivision(string cpini, int vista)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialMailgroup(string cpini, int vista)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialAsistente(string cpini, int vista)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialZona(string cpini, int vista)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialZonaConDivisional(string cpini, int vista, int division)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);
            db.SetParameterValue(commandCommercialMatrix, "i_region", division);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable MatrizComercialZonaConAsistente(string cpini, int vista, string asistente)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", vista);
            db.SetParameterValue(commandCommercialMatrix, "i_asistente", asistente);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable ClasificacionXValorCompleta(string cpini)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'M');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable ClasificacionXValorDivision(string cpini, int division)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'N');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_region", division);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable ClasificacionXValorMailGroup(string cpini, int mailgroup)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'O');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_mailgroup", mailgroup);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable ClasificacionXValorZona(string cpini, string zona)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'P');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", cpini);
            db.SetParameterValue(commandCommercialMatrix, "i_zona", zona);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public List<decimal> MatrizComercialPorcentajes(int id)
        {
            List<decimal> m = new List<decimal>();

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'J');
            db.SetParameterValue(commandCommercialMatrix, "i_vista", id);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

                if (dr.Read())
                {
                    m.Add(Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("pom_valormenor")).ToString()));
                    m.Add(Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("pom_valormayor")).ToString()));
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

        public DataTable ListaEmpresariasCampanaZonaEstado(string campana, string zona, int estado, string TipoAgrupamiento)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'K');
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana);
            db.SetParameterValue(commandCommercialMatrix, "i_zona", zona);
            db.SetParameterValue(commandCommercialMatrix, "i_vista", Convert.ToInt32(TipoAgrupamiento));
            db.SetParameterValue(commandCommercialMatrix, "i_esc_id", estado);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerCampanasParaProcesar()
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'B');

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public DataTable traerInformacionDeCampanaParaProcesar(string campana)
        {
            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'S');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'L');
            
            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana);

            IDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);

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

        public void proceso01(string campana_actual, string campana_anterior, DateTime fecha_inicio, DateTime fecha_fin)
        {
            //-- VERIFICAR LA EXISTENCIA DEL REGISTRO PRINCIPAL PARA CADA EMPRESARIA EN LA CAMPAÑA 
            //-- ACTUAL EN LA TABLA SVDN_MATRIZCOMERCIAL_HISTORICO, SI NO EXISTE HACER EL INSERT CON 
            //-- LOS DATOS BÁSICOS.

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'A');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", campana_anterior);
            db.SetParameterValue(commandCommercialMatrix, "i_fecha_inicio", fecha_inicio);
            db.SetParameterValue(commandCommercialMatrix, "i_fecha_fin", fecha_fin);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso02(string campana_actual)
        {
            //-- ACTUALIZAR VALORES DE ZONA PARA LOS REGISTROS DE CADA EMPRESARIA EN LA TABLA 
            //-- SVDN_MATRIZCOMERCIAL_HISTORICO.

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'A');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso03(string campana_actual, string campana_anterior)
        {
            //-- ACTUALIZAR CONSECUTIVIDAD DE EMPRESARIAS.

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'B');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", campana_anterior);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso04(string campana_actual)
        {
            //-- ACTUALIZAR SALDOS DE PEDIDOS Y FACTURAS Y SUS RESPECTIVOS VALORES EN LA TABLA 
            //-- SVDN_MATRIZCOMERCIAL_HISTORICO.

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'C');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso04_extendido(string campana_actual, string opcion)
        {

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", "C" + opcion);

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso05(string campana_actual, string campana_anterior)
        {
            //-- ACTUALIZACIÓN DE ESTADOS DE CADA EMPRESARIA.

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'D');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", campana_anterior);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso05_extendido(string campana_actual, string campana_anterior, string opcion)
        {
            //-- ACTUALIZACIÓN DE ESTADOS DE CADA EMPRESARIA.

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", "D" + opcion);

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", campana_anterior);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso06(string campana_actual, string campana_anterior)
        {
            //-- CONSTRUCCION DE RESUMEN DE MATRIZ COMERCIAL

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'B');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);
            db.SetParameterValue(commandCommercialMatrix, "i_campana_anterior", campana_anterior);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso07(string campana_actual)
        {
            //-- ACTUALIZACIÓN DE PRESUPUESTO EN RESUMEN

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'E');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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
        
        public void proceso08(string campana_actual)
        {
            //-- SE DEJA EL CAMPO ACTUALIZACION DE LA TABLA SVDN_MATRIZCOMERCIAL_HISTORICO QUE ES EL
            //-- PIBOTE DE ACTUALIZACION

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'U');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'F');

            db.SetParameterValue(commandCommercialMatrix, "i_campana_actual", campana_actual);

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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

        public void proceso09()
        {
            //-- LIBERAR MEMORIA DEL PROCESO

            db.SetParameterValue(commandCommercialMatrix, "i_operation", 'I');
            db.SetParameterValue(commandCommercialMatrix, "i_option", 'C');

            IDataReader dr = null;

            try
            {
                dr = db.ExecuteReader(commandCommercialMatrix);
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
        }

        #endregion
    }
}
