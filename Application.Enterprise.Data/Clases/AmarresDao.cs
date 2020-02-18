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
using System.Data.SqlClient;




namespace Application.Enterprise.Data
{
    public class AmarresDao { 
    
    

         /// <summary>
        ///  CODIGO BY JUTA.
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandAmarres;

     

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public AmarresDao(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public AmarresDao()
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
            commandAmarres = db.GetStoredProcCommand("PRC_SVDN_AMARRES");

            db.AddInParameter(commandAmarres, "i_operation", DbType.String);
            db.AddInParameter(commandAmarres, "i_option", DbType.String);

            db.AddInParameter(commandAmarres, "i_pinta", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_amarre", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_xreferencia", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_xcodigorapido", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_xfecha", DbType.Int32);
            db.AddInParameter(commandAmarres, "i_xcampana", DbType.Int32);

            db.AddInParameter(commandAmarres, "i_id", DbType.String);
            db.AddInParameter(commandAmarres, "i_idproducto", DbType.String);
            db.AddInParameter(commandAmarres, "i_idamarre", DbType.String);
            db.AddInParameter(commandAmarres, "i_campana", DbType.String);
            db.AddInParameter(commandAmarres, "i_fechaini", DbType.DateTime);
            db.AddInParameter(commandAmarres, "i_fechafin", DbType.DateTime);

            db.AddInParameter(commandAmarres, "i_descripcion", DbType.String);
            db.AddInParameter(commandAmarres, "i_precio", DbType.Decimal);
            db.AddInParameter(commandAmarres, "i_descuento", DbType.Decimal);
            db.AddInParameter(commandAmarres, "id_regla", DbType.Int32);


        }




         public List<AmarresInfo> verTodosAmarres(){

             db.SetParameterValue(commandAmarres, "i_operation", 'S');
             db.SetParameterValue(commandAmarres, "i_option", '7');
            

             List<AmarresInfo> col = new List<AmarresInfo>();

             IDataReader dr = null;

             AmarresInfo m = null;

             try
             {
                 dr = db.ExecuteReader(commandAmarres);

                 while (dr.Read())
                 {
                     m = Factory.getAmarre(dr);

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
          public List<AmarresInfo> verPintasyAmarresVigentes(){

              db.SetParameterValue(commandAmarres, "i_operation", 'S');
              db.SetParameterValue(commandAmarres, "i_option", '4');
             
              List<AmarresInfo> col = new List<AmarresInfo>();

              IDataReader dr = null;

              AmarresInfo m = null;

              try
              {
                  dr = db.ExecuteReader(commandAmarres);

                  while (dr.Read())
                  {
                      m = Factory.getAmarre(dr);

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
         public List<AmarresInfo> verPintasVigentes(){

             db.SetParameterValue(commandAmarres, "i_operation", 'S');
             db.SetParameterValue(commandAmarres, "i_option", '6');
          

             List<AmarresInfo> col = new List<AmarresInfo>();

             IDataReader dr = null;

             AmarresInfo m = null;

             try
             {
                 dr = db.ExecuteReader(commandAmarres);

                 while (dr.Read())
                 {
                     m = Factory.getAmarre(dr);

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
        public List<AmarresInfo> verAmarresVigentes(){

            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '5');
         

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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

        public string getReferencia(string id_corto)
        {
            string referencia = "";
            db.SetParameterValue(commandAmarres, "i_operation", "S");
            db.SetParameterValue(commandAmarres, "i_option", "14");
            db.SetParameterValue(commandAmarres, "i_id", id_corto);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    try
                    {

                        referencia = Tools.ToString(dr, "descripcion");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                    }


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

            return referencia;
        }


        public List<AmarresInfo> ListtodosamarresCodigo(string id_producto)
        {
            db.SetParameterValue(commandAmarres, "i_operation", "S");
            db.SetParameterValue(commandAmarres, "i_option", "15");
            db.SetParameterValue(commandAmarres, "i_idproducto", id_producto);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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

        public List<AmarresInfo> ListAmarresxCodigo(string id_producto)
        {
            db.SetParameterValue(commandAmarres, "i_operation", "S");
            db.SetParameterValue(commandAmarres, "i_option", "10");
            db.SetParameterValue(commandAmarres, "i_idproducto", id_producto);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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



        public List<AmarresInfo> ListAmarresxregla(string id_regla, string codproducto)
        {
            db.SetParameterValue(commandAmarres, "i_operation", "S");
            db.SetParameterValue(commandAmarres, "i_option", "11");
            db.SetParameterValue(commandAmarres, "i_id", id_regla);
            db.SetParameterValue(commandAmarres, "i_idproducto", codproducto);
            
            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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


        public List<AmarresInfo> ListItemsPorpinta(string id_regla, string codproducto)
        {
            db.SetParameterValue(commandAmarres, "i_operation", "S");
            db.SetParameterValue(commandAmarres, "i_option", "12");
            db.SetParameterValue(commandAmarres, "i_id", id_regla);
            db.SetParameterValue(commandAmarres, "i_idproducto", codproducto);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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




        public AmarresInfo getAmarreIteminfo(string codproducto)
        {
            db.SetParameterValue(commandAmarres, "i_operation", "S");
            db.SetParameterValue(commandAmarres, "i_option", "13");
 
            db.SetParameterValue(commandAmarres, "i_idproducto", codproducto);

            

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

                   
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





        public List<AmarresInfo> ListAmarres(int regla)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '3');
            db.SetParameterValue(commandAmarres, "i_id", regla);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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



    
        public bool verxistenciaEncabezado(int pinta, int amarre, decimal valorpinta, string descripcion) {

                bool existe = false;
                int contador = 0; 
                 
                db.SetParameterValue(commandAmarres, "i_operation", 'S');
                db.SetParameterValue(commandAmarres, "i_option", '2');
            

                db.SetParameterValue(commandAmarres, "i_pinta",pinta);
                db.SetParameterValue(commandAmarres, "i_amarre",amarre);
                db.SetParameterValue(commandAmarres, "i_precio", valorpinta);
                db.SetParameterValue(commandAmarres, "i_descripcion",descripcion);

            
                //db.SetParameterValue(commandAmarres, "i_id", regla);

                List<AmarresInfo> col = new List<AmarresInfo>();

                IDataReader dr = null;

                AmarresInfo m = null;

                try
                {
                    dr = db.ExecuteReader(commandAmarres);
                   
                    while (dr.Read())
                    {
                        contador++; 
                       // m = Factory.getAmarre(dr);

                       
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
                if (contador > 0) {
                    existe = true; 

                }


                return existe; 

        }

        public bool validarReferencia(string referencia) {

            bool existe = false;
            int contador = 0;

            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '9');


            db.SetParameterValue(commandAmarres, "i_idproducto", referencia);
        

            //db.SetParameterValue(commandAmarres, "i_id", regla);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    contador++;
                    // m = Factory.getAmarre(dr);


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
            if (contador > 0)
            {
                existe = true;

            }


            return existe; 

        }

        public bool validarSku(string idcorto) {
            bool existe = false;
            int contador = 0;

            db.SetParameterValue(commandAmarres, "i_operation", 'S');
            db.SetParameterValue(commandAmarres, "i_option", '8');


            db.SetParameterValue(commandAmarres, "i_idproducto", idcorto);


            //db.SetParameterValue(commandAmarres, "i_id", regla);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    contador++;
                    // m = Factory.getAmarre(dr);


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
            if (contador > 0)
            {
                existe = true;

            }


            return existe; 

        
        }

        public bool insertaramarreDeta(AmarresInfo amarre)
        {
            bool respuesta = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'I');
                db.SetParameterValue(commandAmarres, "i_option", 'B');

                db.SetParameterValue(commandAmarres, "i_pinta", amarre.Pinta);
                db.SetParameterValue(commandAmarres, "i_amarre", amarre.Amarre);
                db.SetParameterValue(commandAmarres, "i_xreferencia", amarre.xReferencia);
                db.SetParameterValue(commandAmarres, "i_xcodigorapido", amarre.xCodigo);
                db.SetParameterValue(commandAmarres, "i_xfecha", amarre.xFecha);
                db.SetParameterValue(commandAmarres, "i_xcampana", amarre.xCampana);

                // db.SetParameterValue(commandAmarres, "i_id", DbType.String);
                db.SetParameterValue(commandAmarres, "i_idproducto", amarre.Idproducto);
                db.SetParameterValue(commandAmarres, "i_idamarre", amarre.Idamarre);
                db.SetParameterValue(commandAmarres, "i_campana", amarre.Campana);
                db.SetParameterValue(commandAmarres, "i_fechaini", amarre.Fechainicial);
                db.SetParameterValue(commandAmarres, "i_fechafin", amarre.Fechafinal);

                db.SetParameterValue(commandAmarres, "i_descripcion", amarre.Descripcion);
                db.SetParameterValue(commandAmarres, "i_precio", amarre.Precio);
                db.SetParameterValue(commandAmarres, "i_descuento", amarre.Descuento);
                //db.SetParameterValue(commandAmarres, "id_regla", amarre.id);



                dr = db.ExecuteReader(commandAmarres);
                respuesta = true;



            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return respuesta;
        }




        public bool insertaramarreEnca(AmarresInfo amarre)
        {
            bool respuesta = false; 

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandAmarres, "i_operation", 'I');
                db.SetParameterValue(commandAmarres, "i_option", 'A');

                db.SetParameterValue(commandAmarres, "i_pinta",amarre.Pinta);
                db.SetParameterValue(commandAmarres, "i_amarre",amarre.Amarre);
                db.SetParameterValue(commandAmarres, "i_xreferencia", amarre.xReferencia);
                db.SetParameterValue(commandAmarres, "i_xcodigorapido",amarre.xCodigo);
                db.SetParameterValue(commandAmarres, "i_xfecha", amarre.xFecha);
                db.SetParameterValue(commandAmarres, "i_xcampana", amarre.xCampana);

                // db.SetParameterValue(commandAmarres, "i_id", DbType.String);
                db.SetParameterValue(commandAmarres, "i_idproducto",amarre.Idproducto);
                db.SetParameterValue(commandAmarres, "i_idamarre",amarre.Idamarre);
                db.SetParameterValue(commandAmarres, "i_campana",amarre.Campana);
                db.SetParameterValue(commandAmarres, "i_fechaini", amarre.Fechainicial);
                db.SetParameterValue(commandAmarres, "i_fechafin",amarre.Fechafinal);

                db.SetParameterValue(commandAmarres, "i_descripcion",amarre.Descripcion);
                db.SetParameterValue(commandAmarres, "i_precio", amarre.Precio);
                db.SetParameterValue(commandAmarres, "i_descuento", amarre.Descuento);
                //db.SetParameterValue(commandAmarres, "id_regla", amarre.id);

                

                dr = db.ExecuteReader(commandAmarres);
                respuesta = true;


               
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
            }
            return respuesta;
        }

        public void insertaramarrexReferenciaxCampana(AmarresInfo amarre)
        {
        }
        public void insertaramarrexReferenciaxFecha(AmarresInfo amarre)
        {
        }
        public void insertaramarrexIdCortoxCampana(AmarresInfo amarre)
        {
        }
        public void insertaramarrexIdCortoxFecha(AmarresInfo amarre)
        {
        }
        public void insertarpintaxReferenciaxCampana(AmarresInfo amarre)
        {
        }
        public void insertarpintaxReferenciaxFecha(AmarresInfo amarre)
        {
        }
        public void insertarpintaxIdCortoxCampana(AmarresInfo amarre)
        {
        }
        public void insertarpintaxIdCortoxFecha(AmarresInfo amarre)
        {
        }
           


        /*
        public void insertarAmarre(AmarresInfo amarre)
        {
            db.SetParameterValue(commandAmarres, "i_operation", 'I');
            db.SetParameterValue(commandAmarres, "i_option", '1');
            //db.SetParameterValue(commandAmarres, "i_id", regla);

            List<AmarresInfo> col = new List<AmarresInfo>();

            IDataReader dr = null;

            AmarresInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandAmarres);

                while (dr.Read())
                {
                    m = Factory.getAmarre(dr);

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

        */



    
    }
}
