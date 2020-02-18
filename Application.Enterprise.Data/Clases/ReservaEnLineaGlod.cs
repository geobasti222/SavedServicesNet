namespace Application.Enterprise.Data
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;
    using System.Reflection;

    public class ReservaEnLineaGlod
    {
        private Database db;
        private DbCommand commandReservaEnLinea;

        public ReservaEnLineaGlod()
        {
            string dataBase = "conexion"; //TODO: quitar

            db = DatabaseFactory.CreateDatabase(dataBase); //TODO: cambiar a db = DatabaseFactory.CreateDatabase(); por que no se tiene el conexionstrign
            Config();
        }

        public ReservaEnLineaGlod(string dataBase)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.Create(dataBase);
            Config();
        }

        private void Config()
        {
            this.commandReservaEnLinea = this.db.GetStoredProcCommand("PRC_SVDN_RESERVAENLINEA");
            this.db.AddInParameter(this.commandReservaEnLinea, "i_operation", DbType.String);
            this.db.AddInParameter(this.commandReservaEnLinea, "i_option", DbType.String);
            this.db.AddInParameter(this.commandReservaEnLinea, "i_numeropedido", DbType.String);
            this.db.AddInParameter(this.commandReservaEnLinea, "i_bodegass", DbType.String);
            this.db.AddInParameter(this.commandReservaEnLinea, "i_cobrarEnvio", DbType.Int32);
            this.db.AddOutParameter(this.commandReservaEnLinea, "o_err_cod", DbType.Int32, 0x3e8);
            this.db.AddOutParameter(this.commandReservaEnLinea, "o_err_msg", DbType.String, 0x3e8);
        }

        public string RealizarReservaEnLinea(string NumeroPedido)
        {
            string str = "";
            IDataReader objA = null;
            try
            {
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_operation", 'I');
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_option", 'A');
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_numeropedido", NumeroPedido);
                objA = this.db.ExecuteReader(this.commandReservaEnLinea);
                str = NumeroPedido;
            }
            catch (Exception exception)
            {
                str = null;
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
            return str;
        }

        public string RealizarReservaEnLineaBorrador(string NumeroPedido, string bodega)
        {
            string str = "";
            IDataReader objA = null;
            try
            {
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_operation", 'I');
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_option", 'B');
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_numeropedido", NumeroPedido);
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_bodegass", bodega);
                objA = this.db.ExecuteReader(this.commandReservaEnLinea);
                str = NumeroPedido;
            }
            catch (Exception exception)
            {
                str = null;
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
            return str;
        }

        public string RealizarReservaEnLineaDifBodega(string NumeroPedido, string bodega, int cobrarFlete)
        {
            string str = "";
            IDataReader objA = null;
            try
            {
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_operation", 'I');
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_option", 'A');
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_numeropedido", NumeroPedido);
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_cobrarEnvio", cobrarFlete);
                this.db.SetParameterValue(this.commandReservaEnLinea, "i_bodegass", bodega);
                objA = this.db.ExecuteReader(this.commandReservaEnLinea);
                str = NumeroPedido;
            }
            catch (Exception exception)
            {
                str = null;
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
            return str;
        }
    }
}

