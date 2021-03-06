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
    public class DevolucionesDetalle
    {
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandDevolucionesDetalle;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public DevolucionesDetalle(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public DevolucionesDetalle()
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
            commandDevolucionesDetalle = db.GetStoredProcCommand("PRC_SVDN_HISDEVOLUCIONES");

            db.AddInParameter(commandDevolucionesDetalle, "i_operation", DbType.String);
            db.AddInParameter(commandDevolucionesDetalle, "i_option", DbType.String);

            db.AddInParameter(commandDevolucionesDetalle, "i_nit", DbType.String);
            db.AddInParameter(commandDevolucionesDetalle, "i_campana", DbType.String);
            db.AddInParameter(commandDevolucionesDetalle, "i_numero", DbType.String);

            db.AddOutParameter(commandDevolucionesDetalle, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandDevolucionesDetalle, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Devoluciones de Detalle

        /// <summary>
        /// Lista todos los Devoluciones de una empresaria
        /// </summary>
        /// <returns></returns>
        public List<DevolucionesDetalleInfo> List(string nit, string numero)
        {
            db.SetParameterValue(commandDevolucionesDetalle, "i_operation", 'S');
            db.SetParameterValue(commandDevolucionesDetalle, "i_option", 'D');
            db.SetParameterValue(commandDevolucionesDetalle, "i_nit", nit);
            db.SetParameterValue(commandDevolucionesDetalle, "i_numero", numero);

            List<DevolucionesDetalleInfo> col = new List<DevolucionesDetalleInfo>();

            IDataReader dr = null;

            DevolucionesDetalleInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandDevolucionesDetalle);

                while (dr.Read())
                {
                    m = Factory.GetDevolucionesDetalle(dr);

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
