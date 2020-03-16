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
using static Application.Enterprise.CommonObjects.Enumerations;

namespace Application.Enterprise.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class EPuntos

    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandEPuntos;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public EPuntos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public EPuntos()
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
            commandEPuntos = db.GetStoredProcCommand("PRC_SVDN_EPUNTOS");

            db.AddInParameter(commandEPuntos, "i_operation", DbType.String);
            db.AddInParameter(commandEPuntos, "i_option", DbType.String);
            db.AddInParameter(commandEPuntos, "i_zona", DbType.String);
            db.AddInParameter(commandEPuntos, "i_nit", DbType.String);
            db.AddInParameter(commandEPuntos, "i_vendedor", DbType.String);
            db.AddInParameter(commandEPuntos, "i_lider", DbType.String);
            db.AddOutParameter(commandEPuntos, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandEPuntos, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de EPuntos



        /// <summary>
        /// Lista el saldo de cartera de Lideres por nit .
        /// </summary>
        /// <param name="Vendedor"></param>
        /// <returns></returns>
        public List<EPuntosInfo> ListPuntosEmpresarias(string Nit, string Lider,string Vendedor)
        {
            db.SetParameterValue(commandEPuntos, "i_operation", 'S');
            db.SetParameterValue(commandEPuntos, "i_option", 'A');
            db.SetParameterValue(commandEPuntos, "i_nit", Nit);
            db.SetParameterValue(commandEPuntos, "i_lider", Lider);
            db.SetParameterValue(commandEPuntos, "i_vendedor", Vendedor);


            List<EPuntosInfo> col = new List<EPuntosInfo>();

            IDataReader dr = null;

            EPuntosInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandEPuntos);

                while (dr.Read())
                {
                    m = Factory.GetPuntosEmpresaria(dr);
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