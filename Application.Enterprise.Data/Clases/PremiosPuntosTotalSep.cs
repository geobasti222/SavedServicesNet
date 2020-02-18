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
    public class PremiosPuntosTotalSep
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosPuntosTotalSep;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosPuntosTotalSep(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosPuntosTotalSep()
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
            commandPremiosPuntosTotalSep = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_PUNTOSNIVTOTAL_SEP");

            db.AddInParameter(commandPremiosPuntosTotalSep, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosPuntosTotalSep, "i_option", DbType.String);
            db.AddInParameter(commandPremiosPuntosTotalSep, "i_nit", DbType.String);
            db.AddInParameter(commandPremiosPuntosTotalSep, "i_puntostotal", DbType.Int32);
            db.AddInParameter(commandPremiosPuntosTotalSep, "i_pre_id", DbType.Int32);
            db.AddInParameter(commandPremiosPuntosTotalSep, "i_campana", DbType.String);
            db.AddInParameter(commandPremiosPuntosTotalSep, "id_nivel", DbType.Int32);


        }
        #endregion

        #region Metodos de Puntos Nivel Total Separado

        /// <summary>
        /// Lista los puntos totales de un premio especifico niveles separado
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalSepInfo> ListxPremio(int IdPremio)
        {
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_option", 'B');
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_pre_id", IdPremio);

            List<PremiosPuntosTotalSepInfo> col = new List<PremiosPuntosTotalSepInfo>();

            IDataReader dr = null;

            PremiosPuntosTotalSepInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosTotalSep);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosTotalSeparado(dr);

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
        /// Lista los nit que contienen puntos de un premio y nivel
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalSepInfo> ListNitPuntosxPremio(int IdPremio)
        {
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_option", 'C');
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_pre_id", IdPremio);

            List<PremiosPuntosTotalSepInfo> col = new List<PremiosPuntosTotalSepInfo>();

            IDataReader dr = null;

            PremiosPuntosTotalSepInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosTotalSep);

                while (dr.Read())
                {
                    m = Factory.GetNitPremiosPuntosTotalSeparado(dr);

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
        /// Lista los puntos que contienen un nit por nivel.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdNivel"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalSepInfo> ListPuntosxNitxNivel(string Nit, int IdNivel)
        {
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_option", 'D');
            db.SetParameterValue(commandPremiosPuntosTotalSep, "i_nit", Nit);
            db.SetParameterValue(commandPremiosPuntosTotalSep, "id_nivel", IdNivel);

            List<PremiosPuntosTotalSepInfo> col = new List<PremiosPuntosTotalSepInfo>();

            IDataReader dr = null;

            PremiosPuntosTotalSepInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosTotalSep);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosTotalSeparado(dr);

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
        ///  actualiza los puntos de un cliente a 0 (cero) por que ya se le asigno un premio.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdNivel"></param>
        /// <returns></returns>
        public bool UpdatePuntos(string Nit, int IdNivel)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosPuntosTotalSep, "i_operation", 'U');
                db.SetParameterValue(commandPremiosPuntosTotalSep, "i_option", 'C');
                db.SetParameterValue(commandPremiosPuntosTotalSep, "i_nit", Nit);
                db.SetParameterValue(commandPremiosPuntosTotalSep, "id_nivel", IdNivel);

                dr = db.ExecuteReader(commandPremiosPuntosTotalSep);

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