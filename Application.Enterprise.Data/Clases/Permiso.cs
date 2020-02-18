﻿using System;
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
    public class Permiso
    {
         /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPermiso;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Permiso(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Permiso()
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
            commandPermiso = db.GetStoredProcCommand("PRC_SVDN_PERMISOS");

            db.AddInParameter(commandPermiso, "i_operation", DbType.String);
            db.AddInParameter(commandPermiso, "i_option", DbType.String);

            db.AddInParameter(commandPermiso, "i_usuario", DbType.String);
            db.AddInParameter(commandPermiso, "i_formulario", DbType.String);
           
            db.AddOutParameter(commandPermiso, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPermiso, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Permiso

        /// <summary>
        /// lista todos las funciones de un usuario en un formulario
        /// </summary>
        /// <returns></returns>
        public List<PermisoInfo> FUncionesXusuarioXFormulario(string usuario, string formulario)
        {
            db.SetParameterValue(commandPermiso, "i_operation", 'S');
            db.SetParameterValue(commandPermiso, "i_option", 'A');
            db.SetParameterValue(commandPermiso, "i_usuario", usuario);
            db.SetParameterValue(commandPermiso, "i_formulario", formulario);

            List<PermisoInfo> col = new List<PermisoInfo>();

            IDataReader dr = null;

            PermisoInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPermiso);

                while (dr.Read())
                {
                    m = Factory.getpermisoFunciones(dr);

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
