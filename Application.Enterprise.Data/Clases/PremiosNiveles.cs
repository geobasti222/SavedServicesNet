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
    public class PremiosNiveles
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosNiveles;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public PremiosNiveles(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public PremiosNiveles()
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
            commandPremiosNiveles = db.GetStoredProcCommand("PRC_SVDN_PREMIOS_NIVELES");

            db.AddInParameter(commandPremiosNiveles, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosNiveles, "i_option", DbType.String);            
            db.AddParameter(commandPremiosNiveles, "i_niv_id", DbType.String, 12, ParameterDirection.InputOutput, false, 32, 32, string.Empty, DataRowVersion.Current, 32);
            db.AddInParameter(commandPremiosNiveles, "i_niv_orden", DbType.Int32);
            db.AddInParameter(commandPremiosNiveles, "i_niv_nombre", DbType.String);
            db.AddInParameter(commandPremiosNiveles, "i_niv_puntos", DbType.Int32);
            db.AddInParameter(commandPremiosNiveles, "i_niv_campanaini", DbType.String);
            db.AddInParameter(commandPremiosNiveles, "i_niv_campanafin", DbType.String);
            db.AddInParameter(commandPremiosNiveles, "i_pre_id", DbType.Int32);
            db.AddInParameter(commandPremiosNiveles, "i_art_id", DbType.Int32);
            db.AddInParameter(commandPremiosNiveles, "i_art_nombre", DbType.String);
            db.AddInParameter(commandPremiosNiveles, "i_niv_tipoprecio", DbType.String);
            db.AddInParameter(commandPremiosNiveles, "i_niv_nombreprecio", DbType.String);
            db.AddInParameter(commandPremiosNiveles, "i_niv_valorprecio", DbType.Decimal);
            db.AddInParameter(commandPremiosNiveles, "i_niv_valordevolucion", DbType.Decimal);
            db.AddInParameter(commandPremiosNiveles, "i_niv_puntos_camp2", DbType.Int32);
            db.AddInParameter(commandPremiosNiveles, "i_niv_tipo_puntos", DbType.String);            

            db.AddOutParameter(commandPremiosNiveles, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosNiveles, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Premios Niveles

        /// <summary>
        /// Lista todos los Niveles.
        /// </summary>
        /// <returns></returns>
        public List<PremiosNivelesInfo> List()
        {
            db.SetParameterValue(commandPremiosNiveles, "i_operation", 'S');
            db.SetParameterValue(commandPremiosNiveles, "i_option", 'A');

            List<PremiosNivelesInfo> col = new List<PremiosNivelesInfo>();

            IDataReader dr = null;

            PremiosNivelesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosNiveles);

                while (dr.Read())
                {
                    m = Factory.GetPremiosNiveles(dr);

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
        /// Lista todos los Niveles de un premio especifico.  Se debe ordenar por puntos para validar la asignacion de premios.
        /// </summary>
        /// <returns></returns>
        public List<PremiosNivelesInfo> ListxPremio(int IdPremio)
        {
            db.SetParameterValue(commandPremiosNiveles, "i_operation", 'S');
            db.SetParameterValue(commandPremiosNiveles, "i_option", 'B');
            db.SetParameterValue(commandPremiosNiveles, "i_pre_id", IdPremio);

            List<PremiosNivelesInfo> col = new List<PremiosNivelesInfo>();

            IDataReader dr = null;

            PremiosNivelesInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosNiveles);

                while (dr.Read())
                {
                    m = Factory.GetPremiosNiveles(dr);

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
        /// Realiza el registro del nivel de un premio.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosNivelesInfo item)
        {
            int id = 0;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosNiveles, "i_operation", 'I');
                db.SetParameterValue(commandPremiosNiveles, "i_option", 'A');

                db.SetParameterValue(commandPremiosNiveles, "i_niv_id", 0);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_orden", item.Orden);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_nombre", item.NombreNivel);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_puntos", item.Puntos);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_campanaini", item.CampanaInicial);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_campanafin", item.CampanaFin);
                db.SetParameterValue(commandPremiosNiveles, "i_pre_id", item.IdPremio);
                db.SetParameterValue(commandPremiosNiveles, "i_art_id", item.IdArticulo );
                db.SetParameterValue(commandPremiosNiveles, "i_art_nombre", item.NombreArticulo);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_tipoprecio", item.TipoPrecio);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_nombreprecio", item.NombrePrecio);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_valorprecio", item.ValorPrecio);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_valordevolucion", item.ValorDevolucion);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_puntos_camp2", item.PuntosCampana2);
                db.SetParameterValue(commandPremiosNiveles, "i_niv_tipo_puntos", item.TipoPuntos);
               
                dr = db.ExecuteReader(commandPremiosNiveles);

                //Obtiene el identificador (consecutivo) del insert
                id = Convert.ToInt32(db.GetParameterValue(commandPremiosNiveles, "i_niv_id"));

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