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
    public class PremiosPuntosTotal
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosPuntosTotal;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosPuntosTotal(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosPuntosTotal()
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
            commandPremiosPuntosTotal = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_PUNTOSNIVTOTAL");

            db.AddInParameter(commandPremiosPuntosTotal, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosPuntosTotal, "i_option", DbType.String);
            db.AddInParameter(commandPremiosPuntosTotal, "i_nit", DbType.String);
            db.AddInParameter(commandPremiosPuntosTotal, "i_puntostotal", DbType.Int32);
            db.AddInParameter(commandPremiosPuntosTotal, "i_pre_id", DbType.Int32);


        }
        #endregion

        #region Metodos de Puntos Nivel Total

        /// <summary>
        /// Lista los puntos totales de un premio especifico
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalInfo> ListxPremio(int IdPremio)
        {
            db.SetParameterValue(commandPremiosPuntosTotal, "i_operation", 'S');
            db.SetParameterValue(commandPremiosPuntosTotal, "i_option", 'B');
            db.SetParameterValue(commandPremiosPuntosTotal, "i_pre_id", IdPremio);

            List<PremiosPuntosTotalInfo> col = new List<PremiosPuntosTotalInfo>();

            IDataReader dr = null;

            PremiosPuntosTotalInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosPuntosTotal);

                while (dr.Read())
                {
                    m = Factory.GetPremiosPuntosTotal(dr);

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
        /// actualiza los puntos de un cliente a 0 (cero) por que ya se le asigno un premio.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdatePuntos(string Nit)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosPuntosTotal, "i_operation", 'U');
                db.SetParameterValue(commandPremiosPuntosTotal, "i_option", 'C');
                db.SetParameterValue(commandPremiosPuntosTotal, "i_nit", Nit);

                dr = db.ExecuteReader(commandPremiosPuntosTotal);

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