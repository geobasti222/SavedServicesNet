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
    public class Sustitutos
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
        public Sustitutos(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Sustitutos()
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
            command = db.GetStoredProcCommand("PRC_SVDN_SUSTITUTOS");

            db.AddInParameter(command, "i_operation", DbType.String);
            db.AddInParameter(command, "i_option", DbType.String);
            
            db.AddInParameter(command, "i_Catalogo", DbType.String);
            db.AddInParameter(command, "i_Referencia", DbType.String);

            db.AddOutParameter(command, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(command, "o_err_msg", DbType.String, 1000);

        }

        #endregion



        #region





       
        #endregion





        #region Factory

        private SustitutosInfo Factory(IDataReader dr)
        {
            SustitutosInfo item = new SustitutosInfo();

            try
            {
                item.Ref_sustituto = Tools.ToString(dr, "Ref_Sustituto");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }
            
            try
            {
                item.Descripcion = Tools.ToString(dr, "Descripcion");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            try
            {
                item.Id_corto = Tools.ToString(dr, "Id_Corto");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            try
            {
                item.PrecioConIVA = Tools.ToDecimal(dr, "PrecioConIVA");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            try
            {
                item.Pagina = Tools.ToString(dr, "Pagina");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }


            try
            {
                item.Foto = Tools.ToString(dr, "Foto");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            String prec = item.PrecioConIVA + "";
            String prec2 = ""; 
            for (int i = 0; i < prec.Length; i++)
            {

                if (prec.Substring(i, 1).Equals(","))
                {
                    prec2 += ".";
                }
                else {
                    prec2 += prec.Substring(i, 1); 
                }
            }


                item.Descripcion = "<strong><font color=#167ac6> " + item.Descripcion + "</font></strong> </br>" +
                                 "<strong>Codigo Rapido: </strong>" + item.Id_corto + "</br>" +
                                 "<strong>Referencia: </strong>" + item.Ref_sustituto + "</br>" +
                                 "<strong>Precio: </strong>" + prec2+ "</br>" +
                                 "<strong><font color=#ef3652><u>click aquí para seleccionar</u></font></strong>";

            //"<strong>Pagina: </strong>" + item.Pagina + "</br>" +



            return item;
        }
        
        #endregion


       


        #region Metodos de SustitutosDetalle

        public List<SustitutosInfo> Lista(string Referencia, string Catalogo)
        {
            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'A');

            db.SetParameterValue(command, "i_Catalogo", Catalogo);
            db.SetParameterValue(command, "i_Referencia", Referencia);

            // falta poner parametro de busqueda

            List<SustitutosInfo> col = new List<SustitutosInfo>();

            IDataReader dr = null;

            SustitutosInfo m = null;

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