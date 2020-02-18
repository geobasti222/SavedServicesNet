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
    public class Grupos
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandGrupos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Grupos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Grupos()
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
            commandGrupos = db.GetStoredProcCommand("PRC_SVDN_GRUPOS");

            db.AddInParameter(commandGrupos, "i_operation", DbType.String);
            db.AddInParameter(commandGrupos, "i_option", DbType.String);
            db.AddInParameter(commandGrupos, "i_grupo", DbType.String);
            db.AddInParameter(commandGrupos, "i_descripcion", DbType.String);
            db.AddInParameter(commandGrupos, "i_tarifaiva", DbType.String);
            db.AddInParameter(commandGrupos, "i_retencion", DbType.String);
            db.AddInParameter(commandGrupos, "i_rete_ica", DbType.String);
            db.AddOutParameter(commandGrupos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandGrupos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Grupos

        /// <summary>
        /// Lista todos los grupos.
        /// </summary>
        /// <returns></returns>
        public List<GruposInfo> List()
        {
            db.SetParameterValue(commandGrupos, "i_operation", 'S');
            db.SetParameterValue(commandGrupos, "i_option", 'A');

            List<GruposInfo> col = new List<GruposInfo>();

            IDataReader dr = null;

            GruposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGrupos);

                while (dr.Read())
                {
                    m = Factory.GetGrupos(dr);

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
        /// Lista un grupo por id.
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns></returns>
        public GruposInfo ListxId(string IdGrupo) 
        {
            db.SetParameterValue(commandGrupos, "i_operation", 'S');
            db.SetParameterValue(commandGrupos, "i_option", 'B');
            db.SetParameterValue(commandGrupos, "i_grupo", IdGrupo);

            IDataReader dr = null;

            GruposInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandGrupos);

                if (dr.Read())
                {
                    m = Factory.GetGrupos(dr);
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

        #endregion
    }
}