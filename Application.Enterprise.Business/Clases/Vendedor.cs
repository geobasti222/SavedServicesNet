using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para vendedor
    /// </summary>
    public class Vendedor : IVendedor
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Vendedor module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Vendedor()
        {
            module = new Application.Enterprise.Data.Vendedor();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Vendedor(string databaseName)
        {
            module = new Application.Enterprise.Data.Vendedor(databaseName);
        }



        #region Miembros de IVendedor
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<VendedorInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista el vendedor de una zona activo
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public List<VendedorInfo> ListxZona(string CodZona)
        {
            return module.ListxZona(CodZona);
        }

        /// <summary>
        /// Lista un vendedor por CodVendedor.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <returns></returns>
        public VendedorInfo ListxCodVendedor(string CodVendedor)
        {
            return module.ListxCodVendedor(CodVendedor);
        }

        /// <summary>
        /// Lista un vendedor por CodVendedor con ciudad.
        /// </summary>
        /// <returns></returns>
        public VendedorInfo ListxCodVendedorCiudad(string CodVendedor)
        {
            return module.ListxCodVendedorCiudad(CodVendedor);
        }

        /// <summary>
        /// Lista un vendedor por cedula.
        /// </summary>
        /// <returns></returns>
        public VendedorInfo ListxCedula(string Cedula)
        {
            return module.ListxCedula(Cedula);
        }

        /// <summary>
        /// Lista un vendedor por id.
        /// </summary>
        /// <param name="IdVendedor">Id vendedor.</param>
        /// <returns></returns>
        public VendedorInfo ListxIdVendedor(string IdVendedor)
        {
            return module.ListxIdVendedor(IdVendedor);
        }

        /// <summary>
        /// Lista una empresaria correspondiente a una gerente.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNit(string Cedula, string Nit)
        {
            return module.ListxCedulaxNit(Cedula, Nit);
        }

        /// <summary>
        /// Lista una empresaria correspondiente a una gerente regional.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNitxRegional(string Cedula, string Nit)
        {
            return module.ListxCedulaxNitxRegional(Cedula, Nit);
        }


        /// <summary>
        /// Lista las gerentes zonales de una gerente regional
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public List<VendedorInfo> ListxGerentesZonales(string CodigoRegional)
        {
            return module.ListxGerentesZonales(CodigoRegional);
        }

        /// <summary>
        /// Lista la informacion de un vendedor por la cedula de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListVendedorxNitCliente(string Nit)
        {
            return module.ListVendedorxNitCliente(Nit);
        }

        /// <summary>
        /// Lista una empresaria correspondiente a una lider.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNitxLider(string Cedula, string Nit)
        {
            return module.ListxCedulaxNitxLider(Cedula, Nit);
        }

        /// <summary>
        /// Realiza la actualizacion de la aceptacion de terminos y condiciones
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AceptoTerminosyCondiciones(VendedorInfo item)
        {
            try
            {
                return module.AceptoTerminosyCondiciones(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Guarda un vendedor nueva.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(VendedorInfo item)
        {
            try
            {
                return module.Insert(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return 0;
            }
        }

        /// <summary>
        /// Realiza la actualizacion de un vendedor existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(VendedorInfo item)
        {
            try
            {
                return module.Update(item);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// Obtiene un vendedor especifico
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        public VendedorInfo ListxVendedorId(string vendedor)
        {
            return module.ListxVendedorId(vendedor);
        }

         /// <summary>
        /// Obiene una lista de vendedores uando el factory getvendedorall
        /// </summary>
        /// <returns></returns>
        public List<VendedorInfo> ListAll()
        {
            return module.ListAll();
        }

        /// <summary>
        /// Obiene una lista de vendedores usando el factory getvendedorall
        /// </summary>
        /// <returns></returns>
        public VendedorInfo ListxCodVendedorAll(String vendedor)
        {
            return module.ListxCodVendedorAll(vendedor);
        }

        #endregion

        #region Asistentes

        /// <summary>
        ///  Lista una empresaria correspondiente a un Asistente
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public VendedorInfo ListxCedulaxNitxAsistente(string Cedula, string Nit)
        {
            return module.ListxCedulaxNitxAsistente(Cedula, Nit);
        }
        #endregion
    }
}
