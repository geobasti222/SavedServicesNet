namespace Application.Enterprise.Data
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    using Application.Enterprise.CommonObjects;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;
    using System.Reflection;

    public class DescuentoGlod
    {
        private Database db;
        private DbCommand commandDescuento;

        public DescuentoGlod()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        public DescuentoGlod(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        private void Config()
        {
            this.commandDescuento = this.db.GetStoredProcCommand("PRC_SVDN_DESCUENTO");
            this.db.AddInParameter(this.commandDescuento, "i_operation", DbType.String);
            this.db.AddInParameter(this.commandDescuento, "i_option", DbType.String);
            this.db.AddParameter(this.commandDescuento, "i_dsc_id", DbType.Int32, ParameterDirection.InputOutput, "", DataRowVersion.Current, (int) 0x20);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_descripcion", DbType.String);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_desde", DbType.Decimal);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_hasta", DbType.Decimal);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_porcentaje", DbType.Decimal);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_porcentajehogar", DbType.Decimal);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_estado", DbType.Boolean);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_sysdate", DbType.DateTime);
            this.db.AddInParameter(this.commandDescuento, "i_valorpedido", DbType.Decimal);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_unineg", DbType.String);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_grupoproducto", DbType.String);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_grupocliente", DbType.String);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_campana", DbType.String);
            this.db.AddInParameter(this.commandDescuento, "i_dsc_prodestrella", DbType.Boolean);
            this.db.AddOutParameter(this.commandDescuento, "o_err_cod", DbType.Int32, 0x3e8);
            this.db.AddOutParameter(this.commandDescuento, "o_err_msg", DbType.String, 0x3e8);
        }

        public bool Delete(int Id, string Usuario)
        {
            bool flag = false;
            IDataReader objA = null;
            try
            {
                this.db.SetParameterValue(this.commandDescuento, "i_operation", 'D');
                this.db.SetParameterValue(this.commandDescuento, "i_option", 'A');
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_id", Id);
                objA = this.db.ExecuteReader(this.commandDescuento);
                flag = true;
                try
                {
                    Auditoria auditoria = new Auditoria("conexion");
                    AuditoriaInfo item = new AuditoriaInfo {
                        FechaSistema = DateTime.Now,
                        Usuario = Usuario
                    };
                    object[] objArray = new object[] { "Se realiz\x00f3 la eliminaci\x00f3n de descuento. Descuento Id:", Id, ". Acci\x00f3n Realizada por el Usuario: ", Usuario };
                    item.Proceso = string.Concat(objArray);
                    auditoria.Insert(item);
                }
                catch (Exception exception1)
                {
                    Trace.WriteLine($"NIVI Error Auditoria: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
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
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
            return flag;
        }

        public string getGrupoCliente(string nit)
        {
            string str = "";
            this.db.SetParameterValue(this.commandDescuento, "i_operation", 'S');
            this.db.SetParameterValue(this.commandDescuento, "i_option", 'F');
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_descripcion", nit);
            IDataReader dr = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandDescuento);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    str = Tools.ToString(dr, "grupoCliente");
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
            return str;
        }

        public int Insert(DescuentoInfo item)
        {
            int num = 0;
            IDataReader objA = null;
            try
            {
                this.db.SetParameterValue(this.commandDescuento, "i_operation", 'I');
                this.db.SetParameterValue(this.commandDescuento, "i_option", 'A');
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_descripcion", item.Descripcion);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_desde", item.Desde);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_hasta", item.Hasta);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_porcentaje", item.Porcentaje);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_porcentajehogar", item.PorcentajeHogar);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_estado", item.Estado);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_unineg", item.UnidadNegocio);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_campana", item.Campana);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_prodestrella", item.ProdEstrella);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_grupocliente", item.GrupoCliente);
                objA = this.db.ExecuteReader(this.commandDescuento);
                num = Convert.ToInt32(this.db.GetParameterValue(this.commandDescuento, "i_dsc_id"));
                try
                {
                    Auditoria auditoria = new Auditoria("conexion");
                    AuditoriaInfo info = new AuditoriaInfo {
                        FechaSistema = DateTime.Now,
                        Usuario = item.Usuario
                    };
                    object[] objArray = new object[] { "Se realiz\x00f3 creaci\x00f3n de descuento.  Nombre:", item.Descripcion, ",   Desde: ", item.Desde, ", Hasta: ", item.Hasta, ", Porcentaje:", item.Porcentaje, ", Estado:" };
                    objArray[9] = item.Estado;
                    objArray[10] = ", ProdEstrella:";
                    objArray[11] = item.ProdEstrella;
                    objArray[12] = ". Acci\x00f3n Realizada por el Usuario: ";
                    objArray[13] = item.Usuario;
                    info.Proceso = string.Concat(objArray);
                    auditoria.Insert(info);
                }
                catch (Exception exception1)
                {
                    Trace.WriteLine($"NIVI Error Auditoria: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
                }
            }
            catch (Exception exception)
            {
                num = 0;
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
            return num;
        }

        public List<DescuentoInfo> List()
        {
            this.db.SetParameterValue(this.commandDescuento, "i_operation", 'S');
            this.db.SetParameterValue(this.commandDescuento, "i_option", 'A');
            List<DescuentoInfo> list = new List<DescuentoInfo>();
            IDataReader dr = null;
            DescuentoInfo item = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandDescuento);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    item = Factory.GetDescuento(dr);
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

        public DescuentoInfo ListxId(int Id)
        {
            this.db.SetParameterValue(this.commandDescuento, "i_operation", 'S');
            this.db.SetParameterValue(this.commandDescuento, "i_option", 'B');
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_id", Id);
            IDataReader dr = null;
            DescuentoInfo descuento = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandDescuento);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    descuento = Factory.GetDescuento(dr);
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
            return descuento;
        }

        public DescuentoInfo ListxValorPedido(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana)
        {
            this.db.SetParameterValue(this.commandDescuento, "i_operation", 'S');
            this.db.SetParameterValue(this.commandDescuento, "i_option", 'C');
            this.db.SetParameterValue(this.commandDescuento, "i_valorpedido", ValorPedido);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_unineg", UnidadNegocio);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_grupoproducto", GrupoProducto);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_campana", Campana);
            IDataReader dr = null;
            DescuentoInfo descuento = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandDescuento);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    descuento = Factory.GetDescuento(dr);
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
            return descuento;
        }

        public DescuentoInfo ListxValorPedidoProdEstrella(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella)
        {
            this.db.SetParameterValue(this.commandDescuento, "i_operation", 'S');
            this.db.SetParameterValue(this.commandDescuento, "i_option", 'D');
            this.db.SetParameterValue(this.commandDescuento, "i_valorpedido", ValorPedido);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_unineg", UnidadNegocio);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_grupoproducto", GrupoProducto);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_campana", Campana);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_prodestrella", ProdEstrella);
            IDataReader dr = null;
            DescuentoInfo descuento = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandDescuento);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    descuento = Factory.GetDescuento(dr);
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
            return descuento;
        }

        public DescuentoInfo ListxValorPedidoProdEstrellaXGrupoCliente(decimal ValorPedido, string UnidadNegocio, string GrupoProducto, string Campana, bool ProdEstrella, string grupoCliente)
        {
            this.db.SetParameterValue(this.commandDescuento, "i_operation", 'S');
            this.db.SetParameterValue(this.commandDescuento, "i_option", 'E');
            this.db.SetParameterValue(this.commandDescuento, "i_valorpedido", ValorPedido);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_unineg", UnidadNegocio);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_grupoproducto", GrupoProducto);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_campana", Campana);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_prodestrella", ProdEstrella);
            this.db.SetParameterValue(this.commandDescuento, "i_dsc_grupocliente", grupoCliente);
            IDataReader dr = null;
            DescuentoInfo descuento = null;
            try
            {
                dr = this.db.ExecuteReader(this.commandDescuento);
                while (true)
                {
                    if (!dr.Read())
                    {
                        break;
                    }
                    descuento = Factory.GetDescuento(dr);
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
            return descuento;
        }

        public bool Update(DescuentoInfo item)
        {
            bool flag = false;
            IDataReader objA = null;
            try
            {
                this.db.SetParameterValue(this.commandDescuento, "i_operation", 'U');
                this.db.SetParameterValue(this.commandDescuento, "i_option", 'A');
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_id", item.Id);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_descripcion", item.Descripcion);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_desde", item.Desde);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_hasta", item.Hasta);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_porcentaje", item.Porcentaje);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_porcentajehogar", item.PorcentajeHogar);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_estado", item.Estado);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_unineg", item.UnidadNegocio);
                this.db.SetParameterValue(this.commandDescuento, "i_dsc_campana", item.Campana);
                objA = this.db.ExecuteReader(this.commandDescuento);
                flag = true;
                try
                {
                    Auditoria auditoria = new Auditoria("conexion");
                    AuditoriaInfo info = new AuditoriaInfo {
                        FechaSistema = DateTime.Now,
                        Usuario = item.Usuario
                    };
                    object[] objArray = new object[] { "Se realiz\x00f3 actualizaci\x00f3n de descuento. Nuevos Valores para Id:", item.Id, ", Nombre:", item.Descripcion, ",   Desde: ", item.Desde, ", Hasta: ", item.Hasta, ", Porcentaje:" };
                    objArray[9] = item.Porcentaje;
                    objArray[10] = ", Estado:";
                    objArray[11] = item.Estado;
                    objArray[12] = ". Acci\x00f3n Realizada por el Usuario: ";
                    objArray[13] = item.Usuario;
                    info.Proceso = string.Concat(objArray);
                    auditoria.Insert(info);
                }
                catch (Exception exception1)
                {
                    Trace.WriteLine($"NIVI Error Auditoria: {exception1.Message} , NameSpace: {MethodBase.GetCurrentMethod().DeclaringType.Namespace}, Clase: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Metodo: {MethodBase.GetCurrentMethod().Name} ");
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
                if (!ReferenceEquals(objA, null))
                {
                    objA.Close();
                }
            }
            return flag;
        }
    }
}

