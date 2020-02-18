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
using System.Data.SqlClient;


namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ZonaxCiudad
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandZonaxCiudad;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ZonaxCiudad(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ZonaxCiudad()
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
            commandZonaxCiudad = db.GetStoredProcCommand("PRC_SVDN_ZONAXCIUDAD");

            db.AddInParameter(commandZonaxCiudad, "i_operation", DbType.String);
            db.AddInParameter(commandZonaxCiudad, "i_option", DbType.String);  
            db.AddInParameter(commandZonaxCiudad, "i_ciu_codciudad", DbType.String);
            db.AddInParameter(commandZonaxCiudad, "i_zona", DbType.String);
            db.AddInParameter(commandZonaxCiudad, "i_sector", DbType.String);

            db.AddOutParameter(commandZonaxCiudad, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandZonaxCiudad, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Zona x Ciudad

        /// <summary>
        /// Lista todos las zonas y ciudades existentes.
        /// </summary>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> List()
        {
            db.SetParameterValue(commandZonaxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandZonaxCiudad, "i_option", 'A');

            List<ZonaxCiudadInfo> col = new List<ZonaxCiudadInfo>();

            IDataReader dr = null;

            ZonaxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonaxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetZonaxCiudad(dr);

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
        /// Lista todas las ciudades de una zona especifica de tablas SVDN.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> ListxZona(string Zona)
        {
            db.SetParameterValue(commandZonaxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandZonaxCiudad, "i_option", 'B');
            db.SetParameterValue(commandZonaxCiudad, "i_zona", Zona);

            List<ZonaxCiudadInfo> col = new List<ZonaxCiudadInfo>();

            IDataReader dr = null;

            ZonaxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonaxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetZonaxCiudad(dr);

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
        /// Lista todas las ciudades de una zona especifica de las tablas de G&G.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> ListxZonaGYG(string Zona)
        {
            db.SetParameterValue(commandZonaxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandZonaxCiudad, "i_option", 'C');
            db.SetParameterValue(commandZonaxCiudad, "i_zona", Zona);

            List<ZonaxCiudadInfo> col = new List<ZonaxCiudadInfo>();

            IDataReader dr = null;

            ZonaxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonaxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetZonaxCiudadGYG(dr);

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
        /// Lista todas las ciudades de un departamento especifico con tablas de G&G.
        /// </summary>
        /// <param name="IdDepto"></param>
        /// <param name="IdZona"></param>
        /// <returns></returns>
        public List<ZonaxCiudadInfo> ListxZonaGYGxDepartamento(string IdDepto, string IdZona)
        {
            db.SetParameterValue(commandZonaxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandZonaxCiudad, "i_option", 'D');
            db.SetParameterValue(commandZonaxCiudad, "i_ciu_codciudad", IdDepto);
            db.SetParameterValue(commandZonaxCiudad, "i_zona", IdZona);

            List<ZonaxCiudadInfo> col = new List<ZonaxCiudadInfo>();

            IDataReader dr = null;

            ZonaxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonaxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetZonaxCiudadGYG(dr);

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




        public List<ZonaxCiudadInfo> ListxZonaGYGxDepartamentoTodos(string IdDepto)
        {
            db.SetParameterValue(commandZonaxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandZonaxCiudad, "i_option", 'F');
            db.SetParameterValue(commandZonaxCiudad, "i_ciu_codciudad", IdDepto);
       
            List<ZonaxCiudadInfo> col = new List<ZonaxCiudadInfo>();

            IDataReader dr = null;

            ZonaxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonaxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetZonaxCiudadGYG(dr);

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





        /******************GAVL******************************/
        /// <summary>
        /// Lista todas las Zonas Con ciudades con tablas de G&G.
        /// </summary>
        /// <returns></returns>/ </summary>
        public List<ZonaxCiudadInfo> ListZonaGYG()
        {
            db.SetParameterValue(commandZonaxCiudad, "i_operation", 'S');
            db.SetParameterValue(commandZonaxCiudad, "i_option", 'E');

            List<ZonaxCiudadInfo> col = new List<ZonaxCiudadInfo>();

            IDataReader dr = null;

            ZonaxCiudadInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandZonaxCiudad);

                while (dr.Read())
                {
                    m = Factory.GetZonaxCiudadGYG(dr);

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
        /// Guarda las Ciudade de una zona 
        /// </summary>
        /// <param name="item"></param>
        public bool InsertZonaxCiudad(ZonaxCiudadInfo item)
        {
            bool okTrans = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandZonaxCiudad, "i_operation", 'I');
                db.SetParameterValue(commandZonaxCiudad, "i_option", 'A');

                db.SetParameterValue(commandZonaxCiudad, "i_ciu_codciudad", item.CodigoCiudadString);
                db.SetParameterValue(commandZonaxCiudad, "i_zona", item.Zona);
                db.SetParameterValue(commandZonaxCiudad, "i_sector", item.Sector);


                dr = db.ExecuteReader(commandZonaxCiudad);




                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó registro Tabla ZonaxCiudad: Codciudad " + item.CodigoCiudadString + ",Zona" + item.Zona + ",sector" + item.Sector + ". Acción Realizada por el Usuario: " + item.Usuario;

                    objAuditoria.Insert(objAuditoriaInfo);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                }
                //-----------------------------------------------------------------------------------------------------------------------------

                okTrans = true;


            }
            catch(SqlException ex) 
            {
                okTrans = false;
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                

            }
            catch (Exception ex)
            {
                okTrans = false;

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
            return okTrans;
        }



        #endregion
    }
}