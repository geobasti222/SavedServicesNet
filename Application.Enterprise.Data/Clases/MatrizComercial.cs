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
    /// </summary>l
    public class MatrizComercial
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandMatrizComercial;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public MatrizComercial(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public MatrizComercial()
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
            commandMatrizComercial = db.GetStoredProcCommand("PRC_SVDN_MATRIZ_COMERCIAL");

            db.AddInParameter(commandMatrizComercial, "i_operation", DbType.String);
            db.AddInParameter(commandMatrizComercial, "i_option", DbType.String);
            db.AddInParameter(commandMatrizComercial, "i_campana", DbType.String);
            //db.AddInParameter(commandMatrizComercial, "i_campanaanterior", DbType.String);
            //db.AddInParameter(commandMatrizComercial, "i_vendedor", DbType.String);
            db.AddInParameter(commandMatrizComercial, "i_zona", DbType.String);
            db.AddInParameter(commandMatrizComercial, "i_reg_codregional", DbType.Int32);
            db.AddInParameter(commandMatrizComercial, "i_mailgroup", DbType.Int32);
            db.AddInParameter(commandMatrizComercial, "i_tipoagrupamiento", DbType.Int32);
            db.AddOutParameter(commandMatrizComercial, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandMatrizComercial, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Pais

        /// <summary>
        /// lista el estado del stencil con informacion resumida.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="TipoAgrupamiento">1) por Zona,  2) por Region,  3) Sin Agrupamiento(todos los registros)</param>
        /// <returns></returns>
        public MatrizComercialInfo ListEstadoStencilResumen(MatrizComercialInfo item, int TipoAgrupamiento, string mailgroup = null)
        {
            db.SetParameterValue(commandMatrizComercial, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercial, "i_option", 'A');
            db.SetParameterValue(commandMatrizComercial, "i_campana", item.Campana);            
            db.SetParameterValue(commandMatrizComercial, "i_zona", item.Zona);
            db.SetParameterValue(commandMatrizComercial, "i_reg_codregional", item.CodigoRegional);
            if (mailgroup != null)
                db.SetParameterValue(commandMatrizComercial, "i_mailgroup", mailgroup);
            db.SetParameterValue(commandMatrizComercial, "i_tipoagrupamiento", TipoAgrupamiento);

            
            IDataReader dr = null;

            MatrizComercialInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandMatrizComercial);

                while (dr.Read())
                {
                    m = Factory.GetEstadoStencil(dr);
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
        /// Lista el informe de estado del stencil con el resumen del Historico_Clientes por cada Zona de una Campaña especifica
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<MatrizComercialInfo> ListEstadoStencilResumenZonas(string campana, string mailgroup, int CodReg)
        {
            db.SetParameterValue(commandMatrizComercial, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercial, "i_option", 'B');
            db.SetParameterValue(commandMatrizComercial, "i_campana", campana);
            db.SetParameterValue(commandMatrizComercial, "i_mailgroup", mailgroup);
            db.SetParameterValue(commandMatrizComercial, "i_reg_codregional", CodReg);
            //db.SetParameterValue(commandMatrizComercial, "i_tipoagrupamiento", 5);

            List<MatrizComercialInfo> col = new List<MatrizComercialInfo>();

            IDataReader dr = null;

            MatrizComercialInfo m = null;

            try
            {
                //commandMatrizComercial.CommandTimeout = 360;
                dr = db.ExecuteReader(commandMatrizComercial);

                while (dr.Read())
                {
                    m = Factory.GetMatrizComercialZon(dr);

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
        /// Lista de Matriz Comercial agrupada por Regional vista por columnas
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<MatrizComercialInfo> ListEstadoStencilResumenRegional(string campana)
        {
            db.SetParameterValue(commandMatrizComercial, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercial, "i_option", 'C');
            db.SetParameterValue(commandMatrizComercial, "i_campana", campana);

            List<MatrizComercialInfo> col = new List<MatrizComercialInfo>();

            IDataReader dr = null;

            MatrizComercialInfo m = null;

            try
            {
                //commandMatrizComercial.CommandTimeout = 360;
                dr = db.ExecuteReader(commandMatrizComercial);

                while (dr.Read())
                {
                    m = Factory.GetMatrizComercialReg(dr);

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
        /// Lista de Matriz Comercial agrupada por Mailgroup vista por columnas
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<MatrizComercialInfo> ListEstadoStencilResumenMailgroup(string campana)
        {
            db.SetParameterValue(commandMatrizComercial, "i_operation", 'S');
            db.SetParameterValue(commandMatrizComercial, "i_option", 'D');
            db.SetParameterValue(commandMatrizComercial, "i_campana", campana);

            List<MatrizComercialInfo> col = new List<MatrizComercialInfo>();

            IDataReader dr = null;

            MatrizComercialInfo m = null;

            try
            {
                //commandMatrizComercial.CommandTimeout = 360;
                dr = db.ExecuteReader(commandMatrizComercial);

                while (dr.Read())
                {
                    m = Factory.GetMatrizComercialMai(dr);

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