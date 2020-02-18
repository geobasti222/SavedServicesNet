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
    /// JA
    /// </summary>
    public class ReglasJA
    {
        
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandPremiosJA;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public ReglasJA(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public ReglasJA()
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
            commandPremiosJA = db.GetStoredProcCommand("PRC_SVDN_SIESA_REGLAS");

            db.AddInParameter(commandPremiosJA, "i_operation", DbType.String);
            db.AddInParameter(commandPremiosJA, "i_option", DbType.String);

            db.AddInParameter(commandPremiosJA, "i_categoria",     DbType.String );
            db.AddInParameter(commandPremiosJA, "i_activo",        DbType.Boolean);
            db.AddInParameter(commandPremiosJA, "i_consulta",      DbType.String );
            db.AddInParameter(commandPremiosJA, "i_campanaPremio", DbType.String );
            db.AddInParameter(commandPremiosJA, "i_campanaAtras",  DbType.String );
            db.AddInParameter(commandPremiosJA, "i_campanaAtras2", DbType.String);
            db.AddInParameter(commandPremiosJA, "i_estado",        DbType.String );
            db.AddInParameter(commandPremiosJA, "i_valorPremio",   DbType.Int32  );
            db.AddInParameter(commandPremiosJA, "i_valorAtras",    DbType.Int32  );            
            db.AddInParameter(commandPremiosJA, "i_productoPlug",  DbType.String );
            db.AddInParameter(commandPremiosJA, "i_eliminar",      DbType.Boolean);
            db.AddInParameter(commandPremiosJA, "i_idcorto",       DbType.String );
            db.AddInParameter(commandPremiosJA, "i_id",            DbType.Int32  );
            db.AddInParameter(commandPremiosJA, "i_cantidad",      DbType.Int32  );
            db.AddInParameter(commandPremiosJA, "i_campanaAtras18",DbType.String );
            db.AddInParameter(commandPremiosJA, "i_descripcion",   DbType.String );
            db.AddInParameter(commandPremiosJA, "i_zona",          DbType.String );
            db.AddInParameter(commandPremiosJA, "i_valordescuento",DbType.Int32  );
            db.AddInParameter(commandPremiosJA, "i_todouno",       DbType.Boolean);
            db.AddInParameter(commandPremiosJA, "i_campanapremiorango", DbType.String);
            db.AddInParameter(commandPremiosJA, "i_valortotalrango", DbType.Int32);
            db.AddInParameter(commandPremiosJA, "i_nivel", DbType.String);

            db.AddInParameter(commandPremiosJA, "i_idregla", DbType.Int32);
            db.AddInParameter(commandPremiosJA, "i_zonas", DbType.String);
            db.AddInParameter(commandPremiosJA, "i_descripcionZona", DbType.String);

            db.AddOutParameter(commandPremiosJA, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandPremiosJA, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        /// <summary>
        /// Inserta los datos de las reglas en la tabla svdn_siesa_reglas
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool Insert(ReglaJAInfo item, string Usuario )
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosJA, "i_operation", 'I');
                db.SetParameterValue(commandPremiosJA, "i_option", 'A');

                db.SetParameterValue(commandPremiosJA, "i_categoria", item.Categoria);
                db.SetParameterValue(commandPremiosJA, "i_activo", item.Activo);
                db.SetParameterValue(commandPremiosJA, "i_consulta", item.Consulta);
                db.SetParameterValue(commandPremiosJA, "i_campanaPremio", item.CampanaPremio);
                db.SetParameterValue(commandPremiosJA, "i_campanaAtras", item.CampanaAtras);
                db.SetParameterValue(commandPremiosJA, "i_campanaAtras2", item.CampanaAtras2);
                db.SetParameterValue(commandPremiosJA, "i_estado", item.Estado);
                db.SetParameterValue(commandPremiosJA, "i_valorPremio", item.ValorPremio);
                db.SetParameterValue(commandPremiosJA, "i_productoPlug", item.ProductoPlug);               
                db.SetParameterValue(commandPremiosJA, "i_valorAtras", item.ValorAtras);
                db.SetParameterValue(commandPremiosJA, "i_eliminar", item.Eliminar);
                db.SetParameterValue(commandPremiosJA, "i_cantidad", item.Cantidad);
                db.SetParameterValue(commandPremiosJA, "i_campanaAtras18", item.CampanaAtras18);
                db.SetParameterValue(commandPremiosJA, "i_descripcion", item.Descripcion);
                db.SetParameterValue(commandPremiosJA, "i_zona", item.Zona);
                db.SetParameterValue(commandPremiosJA, "i_valordescuento", item.ValorDescuento);
                db.SetParameterValue(commandPremiosJA, "i_todouno", item.TodoUno);
                db.SetParameterValue(commandPremiosJA, "i_valortotalrango", item.ValorTotalRango);
                db.SetParameterValue(commandPremiosJA, "i_campanapremiorango", item.CampanaPremioRango);
                db.SetParameterValue(commandPremiosJA, "i_nivel", item.Nivel);
                dr = db.ExecuteReader(commandPremiosJA);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación de ReglaParaPremio: Categoria: " + item.Categoria + " Activo: " + item.Activo + "  CampanaPremio: " + item.CampanaPremio + "  Estado : " + item.Estado + " VAlorCampaña Premio : " + item.ValorPremio + " VAlorCampaña Anterior : " + item.ValorAtras +"  Producto : " + item.ProductoPlug + " . Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }


      /// <summary>
        /// Inserta las zonas de una regla
      /// </summary>
      /// <param name="regla"></param>
      /// <param name="Zona"></param>
      /// <returns></returns>
        public bool InsertZonas(ReglaJAInfo Zona, String Usuario)
        {
            bool oktrans = false;

            IDataReader dr = null;
            try
            {
               
                
                db.SetParameterValue(commandPremiosJA, "i_operation", 'I');
                db.SetParameterValue(commandPremiosJA, "i_option", 'B');

                db.SetParameterValue(commandPremiosJA, "i_idregla", Zona.IdRegla);
                db.SetParameterValue(commandPremiosJA, "i_zonas", Zona.Zonas);
                db.SetParameterValue(commandPremiosJA, "i_DescripcionZona", Zona.DescripcionZona);
                dr = db.ExecuteReader(commandPremiosJA);
               

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación del grupo de zonas de la regla " + Zona.IdRegla + " con zona: "+Zona.DescripcionZona+". Acción Realizada por el Usuario: " + Usuario;
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
                oktrans = false;

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
            return oktrans;
        }

        /// <summary>
        /// Inserta los productos de una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool InsertProducto(ReglaJAInfo producto, String Usuario)
        {
            bool oktrans = false;

            IDataReader dr = null;
            try
            {


                db.SetParameterValue(commandPremiosJA, "i_operation", 'I');
                db.SetParameterValue(commandPremiosJA, "i_option", 'C');

                db.SetParameterValue(commandPremiosJA, "i_idregla", producto.IdRegla);
                db.SetParameterValue(commandPremiosJA, "i_productoplug", producto.ProductoPlug);
                db.SetParameterValue(commandPremiosJA, "i_cantidad", producto.Cantidad);
                dr = db.ExecuteReader(commandPremiosJA);


                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la creación del producto de la regla " + producto.IdRegla + " con producto: " + producto.ProductoPlug + ". Acción Realizada por el Usuario: " + Usuario;
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
                oktrans = false;

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
            return oktrans;
        }

        /// <summary>
        /// LLama el id de la regla maxima o ultima
        /// </summary>
        /// <returns></returns>
        public ReglaJAInfo llamarregla() 
        {

            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'N');
        
            IDataReader dr = null;

            ReglaJAInfo m = null; 

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.getidRegla(dr);                    
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
        /// lista las reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglaJAInfo> ListReglas()
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'A');

            List<ReglaJAInfo> col = new List<ReglaJAInfo>();

            IDataReader dr = null;

            ReglaJAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.GetReglaJA(dr);

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
        /// Lista reglas por una campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<ReglaJAInfo> ListReglasxCampana(String campana)
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'B');
            db.SetParameterValue(commandPremiosJA, "i_campanaPremio", campana);

            List<ReglaJAInfo> col = new List<ReglaJAInfo>();

            IDataReader dr = null;

            ReglaJAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.GetReglaJA(dr);

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
        /// lista las campañas de las reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglaJAInfo> ListCampañas()
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'C');

            List<ReglaJAInfo> col = new List<ReglaJAInfo>();

            IDataReader dr = null;

            ReglaJAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.GetReglaJACampana(dr);

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
        /// lista los estados
        /// </summary>
        /// <returns></returns>
        public List<EstadosClienteInfo> ListEstados()
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'D');

            List<EstadosClienteInfo> col = new List<EstadosClienteInfo>();

            IDataReader dr = null;

            EstadosClienteInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.GetEstadosClienteReglas(dr);

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
        /// lista las campañas 
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampañasAll()
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'E');

            List<CampanaInfo> col = new List<CampanaInfo>();

            IDataReader dr = null;

            CampanaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.GetCampanaRegla(dr);

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
        /// lista las zonas 
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> Listzonas()
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'H');

            List<ZonaInfo> col = new List<ZonaInfo>();

            IDataReader dr = null;

            ZonaInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.GetZonaRegla(dr);

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
        /// busca el producto para premiar
        /// </summary>
        /// <returns></returns>
        public DataTable ListPremioReglas(string codigoCorto)
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'F');
            db.SetParameterValue(commandPremiosJA, "i_idcorto", codigoCorto);

            IDataReader dr = null;
            DataTable dt = new DataTable();


            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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

            return dt;
        }

        /// <summary>
        /// "borra" acutaliza una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeleteReglas(int id,string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosJA, "i_operation", 'U');
                db.SetParameterValue(commandPremiosJA, "i_option", 'A');
                db.SetParameterValue(commandPremiosJA, "i_id", id);

                dr = db.ExecuteReader(commandPremiosJA);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de Regla:Codigo Regla: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }

        /// <summary>
        /// busca la existencias del producto
        /// </summary>
        /// <returns></returns>
        public DataTable ListCantidadPremio(string codigoCorto)
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'G');
            db.SetParameterValue(commandPremiosJA, "i_idcorto", codigoCorto);

            IDataReader dr = null;
            DataTable dt = new DataTable();


            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("SVDN Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

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

            return dt;
        }

        /// <summary>
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public bool UpdateActivoRegla(int id, string Usuario,bool activo)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosJA, "i_operation", 'U');
                db.SetParameterValue(commandPremiosJA, "i_option", 'B');
                db.SetParameterValue(commandPremiosJA, "i_id", id);
                db.SetParameterValue(commandPremiosJA, "i_activo", activo);

                dr = db.ExecuteReader(commandPremiosJA);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una Edicion de activacion "+activo+" de Regla:Codigo Regla: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }



        /// <summary>
        /// listar las zonas por una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public List<ReglaJAInfo> ListZonasReglas(int regla)
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'O');
            db.SetParameterValue(commandPremiosJA, "i_idregla", regla);

            List<ReglaJAInfo> col = new List<ReglaJAInfo>();

            IDataReader dr = null;

            ReglaJAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.getZonasRegla(dr);

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
        /// "borra" acutaliza una zona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeleteZona(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosJA, "i_operation", 'U');
                db.SetParameterValue(commandPremiosJA, "i_option", 'C');
                db.SetParameterValue(commandPremiosJA, "i_id", id);

                dr = db.ExecuteReader(commandPremiosJA);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de una zona:Codigo Zona: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }


        /// <summary>
        /// listar la regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public ReglaJAInfo ListRegla(int regla)
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'P');
            db.SetParameterValue(commandPremiosJA, "i_id", regla);

           

            IDataReader dr = null;

            ReglaJAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.GetReglaJA(dr);

                   
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
        /// listar los premios por una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public List<ReglaJAInfo> ListPremiosReglas(int regla)
        {
            db.SetParameterValue(commandPremiosJA, "i_operation", 'S');
            db.SetParameterValue(commandPremiosJA, "i_option", 'Q');
            db.SetParameterValue(commandPremiosJA, "i_idregla", regla);

            List<ReglaJAInfo> col = new List<ReglaJAInfo>();

            IDataReader dr = null;

            ReglaJAInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandPremiosJA);

                while (dr.Read())
                {
                    m = Factory.getPremiosRegla(dr);

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
        /// "borra" acutaliza un premio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeletePremio(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosJA, "i_operation", 'U');
                db.SetParameterValue(commandPremiosJA, "i_option", 'D');
                db.SetParameterValue(commandPremiosJA, "i_id", id);

                dr = db.ExecuteReader(commandPremiosJA);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de un Premio:Codigo Premio: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }


        /// <summary>
        /// "borra"  los premios por regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeletePremiosPorRegla(int id, string Usuario)
        {
            bool oktrans = false;
            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandPremiosJA, "i_operation", 'D');
                db.SetParameterValue(commandPremiosJA, "i_option", 'A');
                db.SetParameterValue(commandPremiosJA, "i_id", id);

                dr = db.ExecuteReader(commandPremiosJA);

                oktrans = true;
                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó Una eliminación de los premios de la regla:Codigo Regla: " + id + ". Acción Realizada por el Usuario: " + Usuario;

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
                oktrans = false;

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
            return oktrans;
        }
    }
}
