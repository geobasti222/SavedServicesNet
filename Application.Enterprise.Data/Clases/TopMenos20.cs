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
   public class TopMenos20
    {
      
         private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand command;

       

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public TopMenos20 (string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }
        public TopMenos20 ()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

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

        public List<Topmenos20Info> lista()
        {
            db.SetParameterValue(command, "i_operation", 'S');
            db.SetParameterValue(command, "i_option", 'I');
            db.SetParameterValue(command, "@o_err_cod", '0');
            db.SetParameterValue(command, "@o_err_msg", '1');
           

            /*b.SetParameterValue(command, "i_Catalogo", Catalogo);
             db.SetParameterValue(command, "i_Referencia", Referencia);*/
            // falta poner parametro de busqueda

            List<Topmenos20Info> col = new List<Topmenos20Info>();

            IDataReader dr = null;

            Topmenos20Info m = null;

            try
            {
                dr = db.ExecuteReader(command);

                while (dr.Read())
                {
                    m = FactoryTopMenos20(dr);

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





        private Topmenos20Info FactoryTopMenos20(IDataReader dr)
        {
            Topmenos20Info item = new Topmenos20Info();

            try
            {
                item.Catalogo = Tools.ToString(dr, "Catalogo");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }

            try
            {
                item.Referencia = Tools.ToString(dr, "Referencia");
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
                item.Descripcion = Tools.ToString(dr, "descripcion");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
            }


            return item;
        }
        





    }
}
