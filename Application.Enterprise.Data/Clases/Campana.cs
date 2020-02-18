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
    /// DAO Campana JA
    /// </summary>
    public class Campana
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCampana;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Campana(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Campana()
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
            commandCampana = db.GetStoredProcCommand("PRC_SVDN_CAMPANAS");

            db.AddInParameter(commandCampana, "i_operation", DbType.String);
            db.AddInParameter(commandCampana, "i_option", DbType.String);
            db.AddInParameter(commandCampana, "i_campana", DbType.String);
            db.AddInParameter(commandCampana, "i_fechaini", DbType.DateTime);
            db.AddInParameter(commandCampana, "i_fechafin", DbType.DateTime);
            db.AddInParameter(commandCampana, "i_catalogo", DbType.String);
            db.AddInParameter(commandCampana, "i_estado", DbType.Int32);
            db.AddInParameter(commandCampana, "i_ano", DbType.String);
            //db.AddInParameter(commandCampana, "i_top", DbType.Int32);            
            //db.AddInParameter(commandCampana, "i_campanafinal", DbType.Int32);

            db.AddOutParameter(commandCampana, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCampana, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Campana

        /// <summary>
        /// lista todos las campañas existentes.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> List()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'A');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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
        /// lista por una campaña especifica.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public CampanaInfo ListxCampana(string Campana)
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'B');
            db.SetParameterValue(commandCampana, "i_campana", Campana);

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                if (dr.Read())
                {
                    m = Factory.GetCampana(dr);
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

        /// <summary>
        /// Lista la campaña activa por en la que se encuenta la fecha actual.
        /// </summary>
        /// <returns></returns>
        public CampanaInfo ListxGetDate()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'C');

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                if (dr.Read())
                {
                    m = Factory.GetCampana(dr);
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

        /// <summary>
        /// Lista la campaña final de un año.
        /// </summary>
        /// <param name="Anio"></param>
        /// <returns></returns>
        public CampanaInfo ListUltimaCampanaxAnio(string Anio)
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'D');
            db.SetParameterValue(commandCampana, "i_ano", Anio);

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                if (dr.Read())
                {
                    m = Factory.GetCampanaFinal(dr);
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

        /// <summary>
        /// Lista la campaña activa en la que se encuenta la fecha actual y la campaña anterior.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanaActualAnterior()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'E');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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
        /// Lista la capaña final del  año vigente
        /// </summary>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public CampanaInfo ListxCampanaFinal(string Ano)
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'F');
            db.SetParameterValue(commandCampana, "i_ano", Ano);

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                if (dr.Read())
                {
                    m = Factory.GetCampana(dr);
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

        /// <summary>
        /// Lista las capañas del  año vigente
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasAno()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'G');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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


        public List<CampanaInfo> ListCampanasXCatalogo(string catalogo)
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'H');
            db.SetParameterValue(commandCampana, "i_catalogo", catalogo);

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                while (dr.Read())
                {
                    m = Factory.GetCampanaXCatalogo(dr);

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


        public List<CampanaInfo> ListUltimasCampanas()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'I');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                while (dr.Read())
                {
                    m = Factory.GetCampanaXCatalogo(dr);

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

        ///// <summary>
        ///// Lista una cantidad de campanas definidas desde la ultima
        ///// </summary>
        ///// <param name="cantidad">Cantidad de Campanas</param>
        ///// <returns></returns>
        //public List<CampanaInfo> ListUltimas_X_Campanas(int cantidad)
        //{
        //    db.SetParameterValue(commandCampana, "i_operation", 'S');
        //    db.SetParameterValue(commandCampana, "i_option", 'J');
        //    db.SetParameterValue(commandCampana, "i_top", cantidad);

        //    List<CampanaInfo> col = new List<CampanaInfo>();

        //    IDataReader dr = null;

        //    CampanaInfo m = null;

        //    try
        //    {
        //        dr = db.ExecuteReader(commandCampana);

        //        while (dr.Read())
        //        {
        //            m = Factory.GetCampanaXCatalogo(dr);

        //            col.Add(m);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

        //        bool rethrow = ExceptionPolicy.HandleException(ex, "DataAccess Policy");

        //        if (rethrow)
        //        {
        //            throw;
        //        }
        //    }
        //    finally
        //    {
        //        if (dr != null)
        //        {
        //            dr.Close();
        //        }
        //    }

        //    return col;
        //}

        /// <summary>
        /// Lista las campañas del año actual
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasAnoActual()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'J');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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
        /// Lista todas las campañas que se encuentren registradas desde la tabla de historico cliente
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasHistoricoCliente()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'K');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                while (dr.Read())
                {
                    m = Factory.GetCampanaFinal(dr);

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
        /// Lista por una campaña especifica, devuelve una lista.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public List<CampanaInfo> ListxCampanaLista(string Campana)
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'B');
            db.SetParameterValue(commandCampana, "i_campana", Campana);


            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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
        /// Lista la campaña actual y la anterior.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanaActualyAnterior()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'L');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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
        /// Lista las campañas que existan en el mailplan de facturacion de 21 dias abiertas.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanaDeMailPlan()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'M');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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

        public List<CampanaInfo> ListCampanasAnoActualFiltradas()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'N');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

                while (dr.Read())
                {
                    m = Factory.GetCampanaXCatalogo(dr);

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
        /// Lista las 3 ultimas campañas.
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListUltimasTresCampanas()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'O');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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
        /// Guarda una campana nueva.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CampanaInfo item)
        {
            int id = 1;

            IDataReader dr = null;            
            try
            {
                db.SetParameterValue(commandCampana, "i_operation", 'I');
                db.SetParameterValue(commandCampana, "i_option", 'A');

                db.SetParameterValue(commandCampana, "i_campana", item.Campana);
                db.SetParameterValue(commandCampana, "i_fechaini", item.FechaInicial);
                db.SetParameterValue(commandCampana, "i_fechafin", item.FechaFin);
                db.SetParameterValue(commandCampana, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandCampana, "i_estado", item.Estado);
                db.SetParameterValue(commandCampana, "i_ano", item.Ano);
               

                dr = db.ExecuteReader(commandCampana);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de una campaña.  Nombre:" + item.Campana + ",   Desde: " + item.FechaInicial + ", Hasta: " + item.FechaFin + ", Estado: " + item.Estado + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Realiza la actualizacion de una campana existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(CampanaInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCampana, "i_operation", 'U');
                db.SetParameterValue(commandCampana, "i_option", 'A');

                db.SetParameterValue(commandCampana, "i_campana", item.Campana);
                db.SetParameterValue(commandCampana, "i_fechaini", item.FechaInicial);
                db.SetParameterValue(commandCampana, "i_fechafin", item.FechaFin);
                db.SetParameterValue(commandCampana, "i_catalogo", item.Catalogo);
                db.SetParameterValue(commandCampana, "i_estado", item.Estado);
                db.SetParameterValue(commandCampana, "i_ano", item.Ano);


                dr = db.ExecuteReader(commandCampana);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la actualización de una campaña.  Nombre:" + item.Campana + ",   Desde: " + item.FechaInicial + ", Hasta: " + item.FechaFin + ", Estado: " + item.Estado + ". Acción Realizada por el Usuario: " + item.Usuario;

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
        /// Lista las campañas que se trasponen al ingreso 
        /// </summary>
        /// /// <param name="fechaini"></param>
        /// /// <param name="fechafin"></param>
        /// <returns></returns>
        public List<CampanaInfo> ListCampanasTrasponen(DateTime fechaini, DateTime fechafin)
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'P');

            db.SetParameterValue(commandCampana, "i_fechaini",fechaini);
            db.SetParameterValue(commandCampana, "i_fechafin",fechafin);

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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


        #endregion


        /// <summary>
        /// lista campañas preventa
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> Listxidpreventa(string campana)
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'Q');

            db.SetParameterValue(commandCampana, "i_campana", campana);

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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


        public List<CampanaInfo> ListCampanasPresenteFutura()
        {
            db.SetParameterValue(commandCampana, "i_operation", 'S');
            db.SetParameterValue(commandCampana, "i_option", 'N');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCampana);

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


    }
}
