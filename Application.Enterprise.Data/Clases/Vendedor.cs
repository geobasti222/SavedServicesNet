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
    public class Vendedor
    {
        /// <summary>
        /// 
        /// </summary>
        private Database db;
        /// <summary>
        /// Propiedad que contiene el comando para ejecutar el procedimiento almacenado que tiene la funcionalidad para persistir los datos 
        /// </summary>
        private DbCommand commandVendedor;

        #region Constructor

        /// <summary>
        /// Constructor de la clase en la que se trae una base de datos distinta a la que hay por defecto
        /// </summary>
        /// <param name="dataBase"> Nombre que contiene la base de datos a utilizar</param>
        public Vendedor(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        /// <summary>
        /// Constructor de la clase en la que se toma la base de datos por defecto
        /// </summary>
        public Vendedor()
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
            commandVendedor = db.GetStoredProcCommand("PRC_SVDN_VENDEDOR");

            db.AddInParameter(commandVendedor, "i_operation", DbType.String);
            db.AddInParameter(commandVendedor, "i_option", DbType.String);
            db.AddInParameter(commandVendedor, "i_vendedor", DbType.String);
            db.AddInParameter(commandVendedor, "i_nombre", DbType.String);
            db.AddInParameter(commandVendedor, "i_cedula", DbType.String);
            db.AddInParameter(commandVendedor, "i_fecha_ingreso", DbType.DateTime);
            db.AddInParameter(commandVendedor, "i_comision", DbType.Decimal);
            db.AddInParameter(commandVendedor, "i_recaudo_0", DbType.Decimal);
            db.AddInParameter(commandVendedor, "i_recaudo_30", DbType.Decimal);
            db.AddInParameter(commandVendedor, "i_recaudo_60", DbType.Decimal);
            db.AddInParameter(commandVendedor, "i_recaudo_90", DbType.Decimal);
            db.AddInParameter(commandVendedor, "i_fechanacimiento", DbType.DateTime);
            db.AddInParameter(commandVendedor, "i_localizacion", DbType.String);
            db.AddInParameter(commandVendedor, "i_clasificacion", DbType.String);
            db.AddInParameter(commandVendedor, "i_persona", DbType.String);
            db.AddInParameter(commandVendedor, "i_sexo", DbType.String);
            db.AddInParameter(commandVendedor, "i_categoria", DbType.String);
            db.AddInParameter(commandVendedor, "i_zona", DbType.String);
            db.AddInParameter(commandVendedor, "i_nombreuno", DbType.String);
            db.AddInParameter(commandVendedor, "i_nombredos", DbType.String);
            db.AddInParameter(commandVendedor, "i_apellidouno", DbType.String);
            db.AddInParameter(commandVendedor, "i_apellidodos", DbType.String);
            db.AddInParameter(commandVendedor, "i_direccion", DbType.String);
            db.AddInParameter(commandVendedor, "i_email", DbType.String);
            db.AddInParameter(commandVendedor, "i_telefonouno", DbType.String);
            db.AddInParameter(commandVendedor, "i_telefonodos", DbType.String);
            db.AddInParameter(commandVendedor, "i_telefonotres", DbType.String);
            db.AddInParameter(commandVendedor, "i_emailnivi", DbType.String);            
            db.AddInParameter(commandVendedor, "i_fechavigencia_inicio", DbType.DateTime);
            db.AddInParameter(commandVendedor, "i_fechavigencia_fin", DbType.DateTime);
            db.AddInParameter(commandVendedor, "i_activo", DbType.Int32);
            db.AddInParameter(commandVendedor, "i_nit", DbType.String);
            db.AddInParameter(commandVendedor, "i_codgereg", DbType.String);
            db.AddInParameter(commandVendedor, "i_termycond", DbType.Boolean);
            db.AddInParameter(commandVendedor, "i_fechaaceptacionterm", DbType.DateTime);
            db.AddInParameter(commandVendedor, "i_mostrartermycond", DbType.Boolean);
            //--comentar para evitar problemas con BD
            //db.AddInParameter(commandVendedor, "i_director", DbType.Int32);
            //db.AddInParameter(commandVendedor, "i_codciudad", DbType.String);

            db.AddOutParameter(commandVendedor, "o_err_cod", DbType.Int32, 1000);
            db.AddOutParameter(commandVendedor, "o_err_msg", DbType.String, 1000);

        }
        #endregion

        #region Metodos de Vendedor

        /// <summary>
        /// lista todos los Vendedores existentes.
        /// </summary>
        /// <returns></returns>
        public List<VendedorInfo> List()
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'A');

            List<VendedorInfo> col = new List<VendedorInfo>();

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                while (dr.Read())
                {
                    m = Factory.GetVendedor(dr);

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
        /// Lista el vendedor de una zona activo
        /// </summary>
        /// <returns></returns>
        public List<VendedorInfo> ListxZona(string CodZona)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'B');
            db.SetParameterValue(commandVendedor, "i_zona", CodZona);

            List<VendedorInfo> col = new List<VendedorInfo>();

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                while (dr.Read())
                {
                    m = Factory.GetVendedor(dr);

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
        /// Lista un vendedor por CodVendedor.
        /// </summary>
        /// <returns></returns>
        public VendedorInfo ListxCodVendedor(string CodVendedor)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'C');
            db.SetParameterValue(commandVendedor, "i_vendedor", CodVendedor);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedor(dr);
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
        /// Lista un vendedor por cedula.
        /// </summary>
        /// <returns></returns>
        public VendedorInfo ListxCedula(string Cedula)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'D');
            db.SetParameterValue(commandVendedor, "i_cedula", Cedula);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedor(dr);
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
        /// Lista un vendedor por id.
        /// </summary>
        /// <param name="IdVendedor">Id vendedor.</param>
        /// <returns></returns>
        public VendedorInfo ListxIdVendedor(string IdVendedor)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'E');
            db.SetParameterValue(commandVendedor, "i_vendedor", IdVendedor);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedorId(dr);
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
        /// Lista una empresaria correspondiente a una gerente.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNit(string Cedula, string Nit)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'F');
            db.SetParameterValue(commandVendedor, "i_cedula", Cedula);
            db.SetParameterValue(commandVendedor, "i_nit", Nit);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedorxCedulaxNit(dr);
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
        /// Lista una empresaria correspondiente a una gerente regional.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNitxRegional(string Cedula, string Nit)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'G');
            db.SetParameterValue(commandVendedor, "i_cedula", Cedula);
            db.SetParameterValue(commandVendedor, "i_nit", Nit);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedorxCedulaxNit(dr);
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
        /// Lista las gerentes zonales de una gerente regional
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<VendedorInfo> ListxGerentesZonales(string CodigoRegional)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'H');
            db.SetParameterValue(commandVendedor, "i_codgereg", CodigoRegional);

            List<VendedorInfo> col = new List<VendedorInfo>();

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                while (dr.Read())
                {
                    m = Factory.GetGerentesZonales(dr);

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
        /// Lista un vendedor por CodVendedor con ciudad.
        /// </summary>
        /// <returns></returns>
        public VendedorInfo ListxCodVendedorCiudad(string CodVendedor)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'C');
            db.SetParameterValue(commandVendedor, "i_vendedor", CodVendedor);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedorCiudad(dr);
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
        /// Lista la informacion de un vendedor por la cedula de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListVendedorxNitCliente(string Nit)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'I');
            db.SetParameterValue(commandVendedor, "i_nit", Nit);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedor(dr);
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
        /// Lista una empresaria correspondiente a una lider.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNitxLider(string Cedula, string Nit)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'J');
            db.SetParameterValue(commandVendedor, "i_cedula", Cedula);
            db.SetParameterValue(commandVendedor, "i_nit", Nit);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedorxCedulaxNit(dr);
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
        /// Realiza la actualizacion de la aceptacion de terminos y condiciones
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AceptoTerminosyCondiciones(VendedorInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandVendedor, "i_operation", 'U');
                db.SetParameterValue(commandVendedor, "i_option", 'A');

                db.SetParameterValue(commandVendedor, "i_vendedor", item.IdVendedor);
                db.SetParameterValue(commandVendedor, "i_termycond", item.TerminosyCondiciones);
                db.SetParameterValue(commandVendedor, "i_fechaaceptacionterm", item.FechaAceptacionTerminos);
                db.SetParameterValue(commandVendedor, "i_mostrartermycond", item.MostrarTerminosyCondiciones);

                dr = db.ExecuteReader(commandVendedor);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.IdVendedor;
                    objAuditoriaInfo.Proceso = "Se realizó aceptación de terminos y condiciones de la gerente : IdVendedor " + item.IdVendedor + ". Acción Realizada por el Usuario: " + item.IdVendedor;

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

            return transOk;
        }


        /// <summary>
        /// Guarda un vendedor nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(VendedorInfo item)
        {
            int id = 1;

            IDataReader dr = null;
            try
            {
                db.SetParameterValue(commandVendedor, "i_operation", 'I');
                db.SetParameterValue(commandVendedor, "i_option", 'A');

                db.SetParameterValue(commandVendedor, "i_vendedor", item.IdVendedor);
                db.SetParameterValue(commandVendedor, "i_nombre", item.Nombre);
                db.SetParameterValue(commandVendedor, "i_cedula", item.Cedula);
                db.SetParameterValue(commandVendedor, "i_fecha_ingreso", item.FechaIngreso);
                db.SetParameterValue(commandVendedor, "i_comision", item.Comision);
                db.SetParameterValue(commandVendedor, "i_recaudo_0", item.Recaudo_0);
                db.SetParameterValue(commandVendedor, "i_recaudo_30", item.Recaudo_30);
                db.SetParameterValue(commandVendedor, "i_recaudo_60", item.Recaudo_60);
                db.SetParameterValue(commandVendedor, "i_recaudo_90", item.Recaudo_90);
                db.SetParameterValue(commandVendedor, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandVendedor, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandVendedor, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandVendedor, "i_persona", item.Persona);
                db.SetParameterValue(commandVendedor, "i_sexo", item.Sexo);
                db.SetParameterValue(commandVendedor, "i_categoria", item.Categoria);
                db.SetParameterValue(commandVendedor, "i_zona", item.Zona);
                db.SetParameterValue(commandVendedor, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandVendedor, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandVendedor, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandVendedor, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandVendedor, "i_direccion", item.Direccion);
                db.SetParameterValue(commandVendedor, "i_email", item.Email);
                db.SetParameterValue(commandVendedor, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandVendedor, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandVendedor, "i_telefonotres", item.TelefonoTres);
                db.SetParameterValue(commandVendedor, "i_emailnivi", item.EmailNivi);
                db.SetParameterValue(commandVendedor, "i_codciudad", item.CodigoCiudad);
                db.SetParameterValue(commandVendedor, "i_fechavigencia_inicio", item.FechaVigenciaInicio);
                db.SetParameterValue(commandVendedor, "i_fechavigencia_fin", item.FechaVigenciaFin);
                db.SetParameterValue(commandVendedor, "i_activo", item.Activo);
                db.SetParameterValue(commandVendedor, "i_termycond", item.TerminosyCondiciones);
                db.SetParameterValue(commandVendedor, "i_fechaaceptacionterm", item.FechaAceptacionTerminos);
                db.SetParameterValue(commandVendedor, "i_mostrartermycond", item.MostrarTerminosyCondiciones);
                db.SetParameterValue(commandVendedor, "i_director", item.Director);

                dr = db.ExecuteReader(commandVendedor);

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó creación de un vendedor.  VendedorID:" + item.IdVendedor + ",  nombre:" + item.Nombre + ",   cedula: " + item.Cedula + ", fechaingreso: " + item.FechaIngreso + ", comision: " + item.Comision + ",  terminos y condiciones: " + item.TerminosyCondiciones + ",. Acción Realizada por el Usuario: " + item.Usuario;

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


        /// <summary>
        /// Realiza la actualizacion de un vendedor existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(VendedorInfo item)
        {
            bool transOk = false;

            IDataReader dr = null;

            try
            {
                db.SetParameterValue(commandVendedor, "i_operation", 'U');
                db.SetParameterValue(commandVendedor, "i_option", 'B');

                db.SetParameterValue(commandVendedor, "i_vendedor", item.IdVendedor);
                db.SetParameterValue(commandVendedor, "i_nombre", item.Nombre);
                db.SetParameterValue(commandVendedor, "i_cedula", item.Cedula);
                db.SetParameterValue(commandVendedor, "i_fecha_ingreso", item.FechaIngreso);
                db.SetParameterValue(commandVendedor, "i_comision", item.Comision);
                db.SetParameterValue(commandVendedor, "i_recaudo_0", item.Recaudo_0);
                db.SetParameterValue(commandVendedor, "i_recaudo_30", item.Recaudo_30);
                db.SetParameterValue(commandVendedor, "i_recaudo_60", item.Recaudo_60);
                db.SetParameterValue(commandVendedor, "i_recaudo_90", item.Recaudo_90);
                db.SetParameterValue(commandVendedor, "i_fechanacimiento", item.FechaNacimiento);
                db.SetParameterValue(commandVendedor, "i_localizacion", item.Localizacion);
                db.SetParameterValue(commandVendedor, "i_clasificacion", item.Clasificacion);
                db.SetParameterValue(commandVendedor, "i_persona", item.Persona);
                db.SetParameterValue(commandVendedor, "i_sexo", item.Sexo);
                db.SetParameterValue(commandVendedor, "i_categoria", item.Categoria);
                db.SetParameterValue(commandVendedor, "i_zona", item.Zona);
                db.SetParameterValue(commandVendedor, "i_nombreuno", item.NombreUno);
                db.SetParameterValue(commandVendedor, "i_nombredos", item.NombreDos);
                db.SetParameterValue(commandVendedor, "i_apellidouno", item.ApellidoUno);
                db.SetParameterValue(commandVendedor, "i_apellidodos", item.ApellidoDos);
                db.SetParameterValue(commandVendedor, "i_direccion", item.Direccion);
                db.SetParameterValue(commandVendedor, "i_email", item.Email);
                db.SetParameterValue(commandVendedor, "i_telefonouno", item.TelefonoUno);
                db.SetParameterValue(commandVendedor, "i_telefonodos", item.TelefonoDos);
                db.SetParameterValue(commandVendedor, "i_telefonotres", item.TelefonoTres);
                db.SetParameterValue(commandVendedor, "i_emailnivi", item.EmailNivi);
                db.SetParameterValue(commandVendedor, "i_codciudad", item.CodigoCiudad);
                db.SetParameterValue(commandVendedor, "i_fechavigencia_inicio", item.FechaVigenciaInicio);
                db.SetParameterValue(commandVendedor, "i_fechavigencia_fin", item.FechaVigenciaFin);
                db.SetParameterValue(commandVendedor, "i_activo", item.Activo);
                db.SetParameterValue(commandVendedor, "i_termycond", item.TerminosyCondiciones);
                db.SetParameterValue(commandVendedor, "i_fechaaceptacionterm", item.FechaAceptacionTerminos);
                db.SetParameterValue(commandVendedor, "i_mostrartermycond", item.MostrarTerminosyCondiciones);
                db.SetParameterValue(commandVendedor, "i_director", item.Director);

                dr = db.ExecuteReader(commandVendedor);

                transOk = true;

                //-----------------------------------------------------------------------------------------------------------------------------
                //Guardar auditoria 
                try
                {
                    Auditoria objAuditoria = new Auditoria("conexion");
                    AuditoriaInfo objAuditoriaInfo = new AuditoriaInfo();

                    objAuditoriaInfo.FechaSistema = DateTime.Now;
                    objAuditoriaInfo.Usuario = item.Usuario;
                    objAuditoriaInfo.Proceso = "Se realizó la actualización de un vendedor.  VendedorID:" + item.IdVendedor + ",  nombre:" + item.Nombre + ",   cedula: " + item.Cedula + ", fechaingreso: " + item.FechaIngreso + ", comision: " + item.Comision + ",  terminos y condiciones: " + item.TerminosyCondiciones + ",. Acción Realizada por el Usuario: " + item.Usuario;

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

            return transOk;
        }
       

        /// <summary>
        /// Busca para examinar si ya existe un vendedor y por ende si tiene una zona asignada
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        public VendedorInfo ListxVendedorId(String vendedor)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'J');
            db.SetParameterValue(commandVendedor, "i_vendedor", vendedor);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                while (dr.Read())
                {
                    m = Factory.GetVendedorAll(dr);

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
        /// lista todos los Vendedores existentes cogiendo el factory getvendedorall
        /// </summary>
        /// <returns></returns>
        public List<VendedorInfo> ListAll()
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'A');

            List<VendedorInfo> col = new List<VendedorInfo>();

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                while (dr.Read())
                {
                    m = Factory.GetVendedorAll(dr);

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
        /// Lista un vendedor por CodVendedor usando factory getvendedorall.
        /// </summary>
        /// <returns></returns>
        public VendedorInfo ListxCodVendedorAll(string CodVendedor)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'C');
            db.SetParameterValue(commandVendedor, "i_vendedor", CodVendedor);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedorAll(dr);
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



        #region Asistentes

        /// <summary>
        /// Lista una empresaria correspondiente a un Asistente 
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNitxAsistente(string Cedula, string Nit)
        {
            db.SetParameterValue(commandVendedor, "i_operation", 'S');
            db.SetParameterValue(commandVendedor, "i_option", 'K');
            db.SetParameterValue(commandVendedor, "i_cedula", Cedula);
            db.SetParameterValue(commandVendedor, "i_nit", Nit);

            IDataReader dr = null;

            VendedorInfo m = null;

            try
            {
                dr = db.ExecuteReader(commandVendedor);

                if (dr.Read())
                {
                    m = Factory.GetVendedorxCedulaxNit(dr);
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
        #endregion


        #endregion
    }
}