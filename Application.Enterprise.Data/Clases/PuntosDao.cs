namespace Application.Enterprise.Data
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    using Application.Enterprise.CommonObjects;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Reflection;

    public class PuntosDao
    {
        private Database db;
        private DbCommand commandPuntos;

        public PuntosDao()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        public PuntosDao(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        public void actualizarDetalleGananciaPuntos(string idpedido, string cedula, int puntos)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'E');
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idpedido);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", puntos);
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void actualizarEncabezadoPuntosCliente(string cedula)
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'J');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
        }

        public void actualizarParametrocampaniasperderpuntos(string valor)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'F');
            this.db.SetParameterValue(this.commandPuntos, "i_valorpunto_parametro", valor);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void actualizarParametropedidominimoganarpuntos(string valor)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'G');
            this.db.SetParameterValue(this.commandPuntos, "i_valorpunto_parametro", valor);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void actualizarParametrovalorpuntos(string valor)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'B');
            this.db.SetParameterValue(this.commandPuntos, "i_valorpunto_parametro", valor);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void actualizarpuntosEfectivo(int puntosganados, int puntosgastados, string cedula)
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'A');
            this.db.SetParameterValue(this.commandPuntos, "i_puntosganados", puntosganados);
            this.db.SetParameterValue(this.commandPuntos, "i_puntosgastados", puntosgastados);
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
        }

        public void actualizarpuntosPedido(int puntosganados, int puntosgastados, string cedula)
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'D');
            this.db.SetParameterValue(this.commandPuntos, "i_puntosganados", puntosganados);
            this.db.SetParameterValue(this.commandPuntos, "i_puntosgastados", puntosgastados);
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
        }

        public void actualizarRegla(PuntosInfo punto)
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'C');
            this.db.SetParameterValue(this.commandPuntos, "i_id_enca", punto.Id_enca);
            this.db.SetParameterValue(this.commandPuntos, "i_estado", punto.Estado);
            this.db.SetParameterValue(this.commandPuntos, "i_xestado", punto.Xestado);
            this.db.SetParameterValue(this.commandPuntos, "i_xpup", punto.Xpup);
            this.db.SetParameterValue(this.commandPuntos, "i_xrango", punto.Xrango);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", punto.Puntos);
            this.db.SetParameterValue(this.commandPuntos, "i_bonopuntos", punto.Bonopuntos);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_unidades_a", punto.Valor_unidades_a);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_unidades_b", punto.Valor_unidades_b);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_a", punto.Valor_decimal_a);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_b", punto.Valor_decimal_b);
            this.db.SetParameterValue(this.commandPuntos, "i_categoria_regla", punto.Id_reglaCategoria);
            this.db.SetParameterValue(this.commandPuntos, "i_descripcion", punto.Decripcion);
            this.db.SetParameterValue(this.commandPuntos, "i_nombre", punto.Nombre);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
        }

        public void agregarConcepto(string concepto)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'F');
            this.db.SetParameterValue(this.commandPuntos, "i_nombre", concepto);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void agregarDescuento100(string idPedido)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idPedido);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void agregarDescuentoPuntos(string IdPedido, decimal totalDescuentoPuntos)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'H');
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", IdPedido);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_a", totalDescuentoPuntos);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void agregarNivelPuntos(string dolares, string punto)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'G');
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_a", dolares);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_unidades_a", punto);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void agregarNivelPuntosCantidad(string cantidad, string punto)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'J');
            this.db.SetParameterValue(this.commandPuntos, "i_valor_unidades_a", cantidad);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", punto);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void borrarPuntosAnulados()
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'L');
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void borrarPuntosDevol()
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'M');
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void borrarPuntosEmpresariasInactivas()
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'D');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'F');
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        private void Config()
        {
            this.commandPuntos = this.db.GetStoredProcCommand("PRC_SVDN_PUNTOS");
            this.db.AddInParameter(this.commandPuntos, "i_operation", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_option", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_idpedido", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_catalogo", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_plu", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_valoragotado", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_puntosganados", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_puntosgastados", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_unidadesa", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_id_regla", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_id_enca", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_estado", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_xestado", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_xpup", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_xrango", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_puntos", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_bonopuntos", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_valor_unidades_a", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_valor_unidades_b", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_valor_decimal_a", DbType.Decimal);
            this.db.AddInParameter(this.commandPuntos, "i_valor_decimal_b", DbType.Decimal);
            this.db.AddInParameter(this.commandPuntos, "i_categoria_regla", DbType.Int32);
            this.db.AddInParameter(this.commandPuntos, "i_idcorto", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_campana", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_nit", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_valorpunto_parametro", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_descripcion", DbType.String);
            this.db.AddInParameter(this.commandPuntos, "i_nombre", DbType.String);
        }

        public void efectuarPuntosPagos()
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'U');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'K');
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public string ejecutarConsulta(string consulta)
        {
            string str = "0";
            try
            {
                SqlConnection connection = new SqlConnection(this.db.ConnectionString);
                connection.Open();
                new SqlCommand(consulta, connection).ExecuteNonQuery();
                connection.Close();
                str = "1";
            }
            catch (Exception exception1)
            {
                return exception1.ToString();
            }
            return str;
        }

        public void eliminarCatalogo(string catalogo)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'D');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'E');
            this.db.SetParameterValue(this.commandPuntos, "i_catalogo", catalogo);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void eliminarNivelPuntos(string regla)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'D');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'G');
            this.db.SetParameterValue(this.commandPuntos, "i_id_regla", regla);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void eliminarNivelPuntosCantidad(string regla)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'D');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'H');
            this.db.SetParameterValue(this.commandPuntos, "i_id_regla", regla);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void eliminarRegla(int valorunidadesa, int categoria_regla)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'D');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'A');
            this.db.SetParameterValue(this.commandPuntos, "i_valor_unidades_a", valorunidadesa);
            this.db.SetParameterValue(this.commandPuntos, "i_categoria_regla", categoria_regla);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public int getcantdiasparaReprogramacion()
        {
            int num = 0;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'V');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    num = Tools.ToInt32(dr, "dias");
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public decimal getCantidadCampanasInactiva()
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'Q');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public int getcantidadpuntoporCategoria(int unidad_a, int regla)
        {
            int num = 0;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'G');
            this.db.SetParameterValue(this.commandPuntos, "i_unidadesa", unidad_a);
            this.db.SetParameterValue(this.commandPuntos, "i_id_regla", regla);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    try
                    {
                        num = Tools.ToInt32(dr, "cantidad");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public int getcantRegistroxCatalogo(string catalogo)
        {
            int num = 0;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'L');
            this.db.SetParameterValue(this.commandPuntos, "i_idcorto", catalogo);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo info = new PuntosInfo();
                    try
                    {
                        num = Tools.ToInt32(dr, "contador");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public List<PLUInfo> getCatalogo(string catalogo)
        {
            List<PLUInfo> list = new List<PLUInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'K');
            this.db.SetParameterValue(this.commandPuntos, "i_catalogo", catalogo);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PLUInfo item = new PLUInfo();
                    try
                    {
                        item.CatalogoReal = Tools.ToString(dr, "catalogo");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Referencia = Tools.ToString(dr, "referencia");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PLU = Tools.ToInt32(dr, "plu");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.CodigoRapido = Tools.ToString(dr, "id_corto");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Pagopuntos = Convert.ToDecimal(Tools.ToInt32(dr, "puntos"));
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PrecioPuntos = Tools.ToInt32(dr, "preciopuntos");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Activo = Tools.ToInt32(dr, "activo");
                    }
                    catch (Exception exception7)
                    {
                        Trace.WriteLine($"NIVI Error: {exception7.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PLUInfo> getCatalogoActual()
        {
            PLUInfo item = new PLUInfo();
            List<PLUInfo> list = new List<PLUInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'J');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    try
                    {
                        item.CatalogoReal = Tools.ToString(dr, "catalogo");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Referencia = Tools.ToString(dr, "referencia");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PLU = Tools.ToInt32(dr, "plu");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.CodigoRapido = Tools.ToString(dr, "id_corto");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Pagopuntos = Tools.ToDecimal(dr, "puntos");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PrecioPuntos = Tools.ToInt32(dr, "preciopuntos");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getCatalogoActualYPreventa()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AJ");
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "codigo");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Concepto = Tools.ToString(dr, "preventa");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getcategoriasReglasPuntos()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'D');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Id_reglaCategoria = Tools.ToInt32(dr, "id");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "descripcion");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "nombre");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public string getClaveLider(string nit)
        {
            string str = "";
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AH");
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo info = new PuntosInfo();
                    try
                    {
                        str = Tools.ToString(dr, "clave_acce");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return str.Trim();
        }

        public List<PuntosInfo> getConceptos()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'W');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Id_regla = Tools.ToInt32(dr, "id");
                    }
                    catch
                    {
                        item.Id_regla = 0;
                    }
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "nombre");
                    }
                    catch
                    {
                        item.Nombre = null;
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public PuntosInfo getdetallepuntoporCategoria(int unidad_a, int regla)
        {
            PuntosInfo info = new PuntosInfo();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'F');
            this.db.SetParameterValue(this.commandPuntos, "i_unidadesa", unidad_a);
            this.db.SetParameterValue(this.commandPuntos, "i_id_regla", regla);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    try
                    {
                        info.Decripcion = Tools.ToString(dr, "descripcion");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        info.Puntos = Tools.ToInt32(dr, "puntos");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        info.Bonopuntos = Tools.ToInt32(dr, "bonopuntos");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        info.Estado = Tools.ToInt32(dr, "estado");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return info;
        }

        public List<PuntosInfo> getDetallePuntosxPedido(string numero)
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AG");
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", numero);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "concepto");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "Tipo");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosTotal = Tools.ToInt32(dr, "Cantidad");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getEstadosEmpresaria()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'E');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Id_reglaCategoria = Tools.ToInt32(dr, "esc_id");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "esc_nombre");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getListaPedidosAnulados()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AB");
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Cedula = Tools.ToString(dr, "nit");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Campana = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.IdPedido = Tools.ToString(dr, "documento");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha2 = Tools.ToString(dr, "fecha2");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "tipo");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosTotal = Tools.ToInt32(dr, "cantidad");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getListaPedidosDevueltos()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AC");
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Cedula = Tools.ToString(dr, "nit");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Campana = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha2 = Tools.ToString(dr, "fecha2");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.IdPedido = Tools.ToString(dr, "documento");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "tipo");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosTotal = Tools.ToInt32(dr, "cantidad");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getListaPedidosPagos()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AA");
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Cedula = Tools.ToString(dr, "nit");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Campana = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha2 = Tools.ToString(dr, "fecha2");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.IdPedido = Tools.ToString(dr, "documento");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "tipo");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosTotal = Tools.ToInt32(dr, "cantidad");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getListaPuntosEmpresariasInctivas()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'S');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Cedula = Tools.ToString(dr, "nit");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosSinPagar = Tools.ToInt32(dr, "puntoped");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosEfectivos = Tools.ToInt32(dr, "PuntoEfec");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha2 = Tools.ToString(dr, "fecha2");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosRedimidos = Tools.ToInt32(dr, "PuntoRed");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosTotal = Tools.ToInt32(dr, "total");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Campana = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception7)
                    {
                        Trace.WriteLine($"NIVI Error: {exception7.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getNivelesPuntos()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'X');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Id_regla = Tools.ToInt32(dr, "id");
                    }
                    catch
                    {
                        item.Id_regla = 0;
                    }
                    try
                    {
                        item.Valor_decimal_a = Tools.ToDecimal(dr, "monto");
                    }
                    catch
                    {
                        item.Valor_decimal_a = 0M;
                    }
                    try
                    {
                        item.Puntos = Tools.ToInt32(dr, "puntos");
                    }
                    catch
                    {
                        item.Puntos = 0;
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getNivelesPuntosCantidad()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AF");
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Id_regla = Tools.ToInt32(dr, "id");
                    }
                    catch
                    {
                        item.Id_regla = 0;
                    }
                    try
                    {
                        item.Valor_unidades_a = Tools.ToInt32(dr, "cantidad");
                    }
                    catch
                    {
                        item.Valor_unidades_a = 0;
                    }
                    try
                    {
                        item.Puntos = Tools.ToInt32(dr, "puntos");
                    }
                    catch
                    {
                        item.Puntos = 0;
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public string getPedidoActivo(string nit)
        {
            string str = "";
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AI");
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo info = new PuntosInfo();
                    try
                    {
                        str = Tools.ToString(dr, "numero");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return str.Trim();
        }

        public decimal getPedidoMinimoGanarPuntos()
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'R');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public int getPrecioPuntosProducto(string id_corto, string campana)
        {
            int num = 0;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'A');
            this.db.SetParameterValue(this.commandPuntos, "i_idcorto", id_corto);
            this.db.SetParameterValue(this.commandPuntos, "i_campana", campana);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    num = Tools.ToInt32(dr, "PrecioPuntos");
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public int getPuntosEfectivoEmpresaria(string nit)
        {
            int num = 0;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'B');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    num = Tools.ToInt32(dr, "PuntoEfec");
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public int getPuntosGanadosxPedido(string nit, string idpedido)
        {
            int num = 0;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'Z');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idpedido);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    try
                    {
                        num = Tools.ToInt32(dr, "puntos");
                    }
                    catch
                    {
                        num = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public PuntosInfo getpuntosganarxestadoxempresaria(string nit)
        {
            PuntosInfo info = new PuntosInfo {
                Puntos = 0,
                Bonopuntos = 0
            };
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    try
                    {
                        info.Puntos = Tools.ToInt32(dr, "puntos");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        info.Bonopuntos = Tools.ToInt32(dr, "bonopuntos");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return info;
        }

        public int getPuntosGanarXProducto(string id_corto)
        {
            int num = 0;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'T');
            this.db.SetParameterValue(this.commandPuntos, "i_idcorto", id_corto);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    num = Tools.ToInt32(dr, "Puntos");
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public List<PuntosInfo> getPuntosxPedido(string nit, string idpedido)
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AD");
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idpedido);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "tipo");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Campana = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.IdPedido = Tools.ToString(dr, "documento");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Puntos = Tools.ToInt32(dr, "cantidad");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha = Tools.ToDateTime(dr, "cantidad");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "tipo2");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha2 = Tools.ToString(dr, "fecha2");
                    }
                    catch (Exception exception7)
                    {
                        Trace.WriteLine($"NIVI Error: {exception7.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Concepto = Tools.ToString(dr, "concepto");
                    }
                    catch (Exception exception8)
                    {
                        Trace.WriteLine($"NIVI Error: {exception8.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public PuntosInfo getSiguienteNivelPuntos(decimal monto)
        {
            PuntosInfo info = null;
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'Y');
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_a", monto);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    info = new PuntosInfo();
                    try
                    {
                        info.Id_regla = Tools.ToInt32(dr, "id");
                    }
                    catch
                    {
                        info.Id_regla = 0;
                    }
                    try
                    {
                        info.Valor_decimal_a = Tools.ToDecimal(dr, "monto");
                    }
                    catch
                    {
                        info.Valor_decimal_a = 0M;
                    }
                    try
                    {
                        info.Puntos = Tools.ToInt32(dr, "puntos");
                    }
                    catch
                    {
                        info.Puntos = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return info;
        }

        public List<PuntosInfo> gettodasCampanasCod()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'P');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getTodaslasreglasPuntosporCategoria(int categoria)
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'H');
            this.db.SetParameterValue(this.commandPuntos, "i_categoria_regla", categoria);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Estado = Tools.ToInt32(dr, "estado");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Id_regla = Tools.ToInt32(dr, "id");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "descripcion");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Puntos = Tools.ToInt32(dr, "puntos");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Bonopuntos = Tools.ToInt32(dr, "bonopuntos");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Valor_unidades_a = Tools.ToInt32(dr, "valor_unidades_a");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Valor_unidades_b = Tools.ToInt32(dr, "valor_unidades_b");
                    }
                    catch (Exception exception7)
                    {
                        Trace.WriteLine($"NIVI Error: {exception7.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getTodosMovimientoEncabezados()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", "AE");
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "nombre");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Email = Tools.ToString(dr, "email");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Telefono = Tools.ToString(dr, "telefono");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Zona = Tools.ToString(dr, "zona");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Cedula = Tools.ToString(dr, "nit");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosSinPagar = Tools.ToInt32(dr, "puntoPed");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosEfectivos = Tools.ToInt32(dr, "puntoEfec");
                    }
                    catch (Exception exception7)
                    {
                        Trace.WriteLine($"NIVI Error: {exception7.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosRedimidos = Tools.ToInt32(dr, "puntoRed");
                    }
                    catch (Exception exception8)
                    {
                        Trace.WriteLine($"NIVI Error: {exception8.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosRedimidosO = Tools.ToInt32(dr, "PuntoRedO");
                    }
                    catch (Exception exception9)
                    {
                        Trace.WriteLine($"NIVI Error: {exception9.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.PuntosTotal = Tools.ToInt32(dr, "Total");
                    }
                    catch (Exception exception10)
                    {
                        Trace.WriteLine($"NIVI Error: {exception10.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getTodosMovimientoPuntosPorEmpresaria(string nit)
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'N');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "tipo");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Campana = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.IdPedido = Tools.ToString(dr, "documento");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Puntos = Tools.ToInt32(dr, "cantidad");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha = Tools.ToDateTime(dr, "cantidad");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "tipo2");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha2 = Tools.ToString(dr, "fecha2");
                    }
                    catch (Exception exception7)
                    {
                        Trace.WriteLine($"NIVI Error: {exception7.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Concepto = Tools.ToString(dr, "concepto");
                    }
                    catch (Exception exception8)
                    {
                        Trace.WriteLine($"NIVI Error: {exception8.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public List<PuntosInfo> getTodosMovimientoPuntosPorEmpresariayCampana(string nit, string campana)
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'O');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            this.db.SetParameterValue(this.commandPuntos, "i_campana", campana);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "tipo");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Campana = Tools.ToString(dr, "campana");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.IdPedido = Tools.ToString(dr, "documento");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Puntos = Tools.ToInt32(dr, "cantidad");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha = Tools.ToDateTime(dr, "cantidad");
                    }
                    catch (Exception exception5)
                    {
                        Trace.WriteLine($"NIVI Error: {exception5.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Nombre = Tools.ToString(dr, "tipo2");
                    }
                    catch (Exception exception6)
                    {
                        Trace.WriteLine($"NIVI Error: {exception6.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Fecha2 = Tools.ToString(dr, "fecha2");
                    }
                    catch (Exception exception7)
                    {
                        Trace.WriteLine($"NIVI Error: {exception7.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        item.Concepto = Tools.ToString(dr, "concepto");
                    }
                    catch (Exception exception8)
                    {
                        Trace.WriteLine($"NIVI Error: {exception8.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }

        public PuntosInfo getTotalPuntosPorEmpresaria(string nit)
        {
            PuntosInfo info = new PuntosInfo();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'M');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", nit);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    try
                    {
                        info.PuntosTotal = Tools.ToInt32(dr, "Total");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        info.PuntosRedimidos = Tools.ToInt32(dr, "PuntoRed");
                    }
                    catch (Exception exception2)
                    {
                        Trace.WriteLine($"NIVI Error: {exception2.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        info.PuntosEfectivos = Tools.ToInt32(dr, "PuntoEfec");
                    }
                    catch (Exception exception3)
                    {
                        Trace.WriteLine($"NIVI Error: {exception3.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    try
                    {
                        info.PuntosSinPagar = Tools.ToInt32(dr, "Puntoped");
                    }
                    catch (Exception exception4)
                    {
                        Trace.WriteLine($"NIVI Error: {exception4.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return info;
        }

        public decimal getvalorPuntoEnSoles()
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'C');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return num;
        }

        public void insertarDetalleGananciaPuntos(string idpedido, string cedula, int puntos, decimal monto, int portal)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'C');
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idpedido);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", puntos);
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_a", monto);
            this.db.SetParameterValue(this.commandPuntos, "i_unidadesa", portal);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void insertarDetalleGastoPuntos(string idpedido, string cedula, int puntos)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'D');
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idpedido);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", puntos);
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void insertarGastoFlete(string idpedido, string cedula, int puntos)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'K');
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idpedido);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", puntos);
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void insertarMovimientoPuntosExpirados(string cedula)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'E');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void insertarMovimientoPuntosGenerico(string idpedido, string cedula, int puntos, string tipo, string concepto)
        {
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'H');
            this.db.SetParameterValue(this.commandPuntos, "i_nit", cedula);
            this.db.SetParameterValue(this.commandPuntos, "i_idpedido", idpedido);
            this.db.SetParameterValue(this.commandPuntos, "i_descripcion", tipo);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", puntos);
            this.db.SetParameterValue(this.commandPuntos, "i_nombre", concepto);
            IDataReader objA = null;
            try
            {
                objA = this.db.ExecuteReader(this.commandPuntos);
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
        }

        public void insertarNuevaRegla(PuntosInfo punto)
        {
            decimal num = 0M;
            string str = "";
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'I');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'A');
            this.db.SetParameterValue(this.commandPuntos, "i_id_enca", punto.Id_enca);
            this.db.SetParameterValue(this.commandPuntos, "i_estado", punto.Estado);
            this.db.SetParameterValue(this.commandPuntos, "i_xestado", punto.Xestado);
            this.db.SetParameterValue(this.commandPuntos, "i_xpup", punto.Xpup);
            this.db.SetParameterValue(this.commandPuntos, "i_xrango", punto.Xrango);
            this.db.SetParameterValue(this.commandPuntos, "i_puntos", punto.Puntos);
            this.db.SetParameterValue(this.commandPuntos, "i_bonopuntos", punto.Bonopuntos);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_unidades_a", punto.Valor_unidades_a);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_unidades_b", punto.Valor_unidades_b);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_a", punto.Valor_decimal_a);
            this.db.SetParameterValue(this.commandPuntos, "i_valor_decimal_b", punto.Valor_decimal_b);
            this.db.SetParameterValue(this.commandPuntos, "i_categoria_regla", punto.Id_reglaCategoria);
            this.db.SetParameterValue(this.commandPuntos, "i_descripcion", punto.Decripcion);
            this.db.SetParameterValue(this.commandPuntos, "i_nombre", punto.Nombre);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = $"{Tools.ToString(dr, "par_valor"):C}".Replace(".", ",");
                    num = Convert.ToDecimal(str);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
        }

        public List<PuntosInfo> listarCatalogosTodos()
        {
            List<PuntosInfo> list = new List<PuntosInfo>();
            this.db.SetParameterValue(this.commandPuntos, "i_operation", 'S');
            this.db.SetParameterValue(this.commandPuntos, "i_option", 'U');
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandPuntos);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    PuntosInfo item = new PuntosInfo();
                    try
                    {
                        item.Decripcion = Tools.ToString(dr, "catalogo");
                    }
                    catch (Exception exception1)
                    {
                        Trace.WriteLine($"NIVI Error: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                    }
                    list.Add(item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"NIVI Error: {exception.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                if (ExceptionPolicy.HandleException(exception, "DataAccess Policy"))
                {
                    throw;
                }
            }
            finally
            {
                if (!ReferenceEquals(dr, null))
                {
                    dr.Close();
                }
            }
            return list;
        }
    }
}

