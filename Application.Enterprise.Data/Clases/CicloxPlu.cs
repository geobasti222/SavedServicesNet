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
    public class CicloxPlu
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandCiclosxPlu;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public CicloxPlu(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public CicloxPlu()
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
            commandCiclosxPlu = db.GetStoredProcCommand("PRC_SVDN_CICLOSXPLU");

            db.AddInParameter(commandCiclosxPlu, "i_operation", DbType.String);
            db.AddInParameter(commandCiclosxPlu, "i_option", DbType.String);

            db.AddInParameter(commandCiclosxPlu, "i_cic_id", DbType.Int32);
            db.AddInParameter(commandCiclosxPlu, "i_cic_referencia", DbType.String);
            db.AddInParameter(commandCiclosxPlu, "i_cic_ccostos", DbType.String);
            db.AddInParameter(commandCiclosxPlu, "i_cic_plu", DbType.Int32);
            db.AddInParameter(commandCiclosxPlu, "i_cic_ciclo", DbType.String);
            db.AddInParameter(commandCiclosxPlu, "i_cic_nombreciclo", DbType.String);
            db.AddInParameter(commandCiclosxPlu, "i_cic_fecha", DbType.DateTime);
            db.AddInParameter(commandCiclosxPlu, "i_cic_idcorto", DbType.String);
            db.AddInParameter(commandCiclosxPlu, "i_cic_campana", DbType.String);
            db.AddInParameter(commandCiclosxPlu, "i_cic_zona", DbType.String);
           
            db.AddOutParameter(commandCiclosxPlu, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandCiclosxPlu, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de CiclosxPlu

        /// <summary>
        /// Lista todos los Ciclos x Plu.
        /// </summary>
        /// <returns></returns>
        public List<CicloxPluInfo> List()
        {
            db.SetParameterValue(commandCiclosxPlu, "i_operation", 'S');
            db.SetParameterValue(commandCiclosxPlu, "i_option", 'A');

            List<CicloxPluInfo> col = new List<CicloxPluInfo>();

            IDataReader dr = null;

            CicloxPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiclosxPlu);

                while (dr.Read())
                {
                    m = Factory.GetCicloxPlu(dr);

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
        /// Lista el consolidado de los plu e ciclo de vida.
        /// </summary>
        /// <returns></returns>
        public List<CicloxPluInfo> ListConsolidado()
        {
            db.SetParameterValue(commandCiclosxPlu, "i_operation", 'S');
            db.SetParameterValue(commandCiclosxPlu, "i_option", 'B');

            List<CicloxPluInfo> col = new List<CicloxPluInfo>();

            IDataReader dr = null;

            CicloxPluInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandCiclosxPlu);

                while (dr.Read())
                {
                    m = Factory.GetCicloxPluConsolidado(dr);

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
        /// Guarda un Ciclo x Plu nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CicloxPluInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandCiclosxPlu, "i_operation", 'I');
                db.SetParameterValue(commandCiclosxPlu, "i_option", 'A');

                db.SetParameterValue(commandCiclosxPlu, "i_cic_id", item.Id);
                db.SetParameterValue(commandCiclosxPlu, "i_cic_referencia", item.Referencia);
                db.SetParameterValue(commandCiclosxPlu, "i_cic_ccostos", item.CCostos);
                db.SetParameterValue(commandCiclosxPlu, "i_cic_plu", item.PLU);
                db.SetParameterValue(commandCiclosxPlu, "i_cic_idcorto", item.CodigoRapido);
                db.SetParameterValue(commandCiclosxPlu, "i_cic_campana", item.Campana);
                db.SetParameterValue(commandCiclosxPlu, "i_cic_zona", item.Zona);

                dr = db.ExecuteReader(commandCiclosxPlu);

                //Obtiene el identificador (consecutivo) del insert
                id = 1; // 1 = OK trans.


                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se digito Codigo Rapido Agotado Anunciado.  CCostos:" + item.CCostos + ",   Referencia: " + item.Referencia + ". Acción Realizada por el Usuario: " + item.Usuario;

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
      

        #endregion
    }
}