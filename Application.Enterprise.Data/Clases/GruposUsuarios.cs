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
    public class GruposUsuarios
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand command;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public GruposUsuarios(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public GruposUsuarios()
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
            command = db.GetStoredProcCommand("PRC_SVDN_GRUPOS_USUARIOS");

            db.AddInParameter(command, "i_operation", DbType.String);
            db.AddInParameter(command, "i_option", DbType.String);
            
            db.AddOutParameter(command, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(command, "o_err_msg", DbType.String, 1000);

        }

        private GruposUsuariosInfo Factory(IDataReader dr)
        {
            GruposUsuariosInfo item = new GruposUsuariosInfo();
            
            try
            {
                item.Grupo = Tools.ToString(dr, "grupo");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            try
            {
                item.Nombre = Tools.ToString(dr, "nombre");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            return item;
        }

        #endregion

        #region Metodos de GruposUsuarios

        /// <summary>
        /// lista todas las Zonas existentes.
        /// </summary>
        /// <returns></returns>
        public List<GruposUsuariosInfo> List()
        {
            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'A');

            List<GruposUsuariosInfo> col = new List<GruposUsuariosInfo>();

            IDataReader dr = null;

            GruposUsuariosInfo m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = Factory(dr);

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