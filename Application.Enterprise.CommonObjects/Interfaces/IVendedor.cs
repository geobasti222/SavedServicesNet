using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Vendedor
    /// </summary>
    public interface IVendedor
    {
        #region "Metodos de Vendedor"

        /// <summary>
        /// lista todos los Vendedores existentes.
        /// </summary>
        /// <returns></returns>
        List<VendedorInfo> List();

        /// <summary>
        /// Lista el vendedor de una zona activo
        /// </summary>
        /// <param name="CodZona"></param>
        /// <returns></returns>
        List<VendedorInfo> ListxZona(string CodZona);

        /// <summary>
        /// Lista un vendedor por CodVendedor.
        /// </summary>
        /// <param name="CodZona"></param>
        /// <returns></returns>
        VendedorInfo ListxCodVendedor(string CodVendedor);

        /// <summary>
        /// Lista un vendedor por CodVendedor con ciudad.
        /// </summary>
        /// <returns></returns>
        VendedorInfo ListxCodVendedorCiudad(string CodVendedor);

        /// <summary>
        /// Lista un vendedor por cedula.
        /// </summary>
        /// <returns></returns>
        VendedorInfo ListxCedula(string Cedula);

        /// <summary>
        /// Lista un vendedor por id.
        /// </summary>
        /// <param name="IdVendedor">Id vendedor.</param>
        /// <returns></returns>
        VendedorInfo ListxIdVendedor(string IdVendedor);

        /// <summary>
        /// Lista una empresaria correspondiente a una gerente.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        VendedorInfo ListxCedulaxNit(string Cedula, string Nit);

        /// <summary>
        /// Lista una empresaria correspondiente a una gerente regional.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        VendedorInfo ListxCedulaxNitxRegional(string Cedula, string Nit);


        /// <summary>
        /// Lista las gerentes zonales de una gerente regional
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        List<VendedorInfo> ListxGerentesZonales(string CodigoRegional);

        /// <summary>
        /// Lista la informacion de un vendedor por la cedula de una empresaria.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        VendedorInfo ListVendedorxNitCliente(string Nit);

        /// <summary>
        /// Lista una empresaria correspondiente a una lider.
        /// </summary>
        /// <param name="Cedula"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        VendedorInfo ListxCedulaxNitxLider(string Cedula, string Nit);

        /// <summary>
        /// Realiza la actualizacion de la aceptacion de terminos y condiciones
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool AceptoTerminosyCondiciones(VendedorInfo item);

          /// <summary>
        /// Guarda un vendedor nuevo.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        int Insert(VendedorInfo item);

         /// <summary>
        /// Realiza la actualizacion de un vendedor existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Update(VendedorInfo item);


         /// <summary>
        /// Busca para examinar si ya existe un vendedor y por ende si tiene una zona asignada
        /// </summary>
        /// <param name="vendedor"></param>
        /// <returns></returns>
        VendedorInfo ListxVendedorId(String vendedor);

         /// <summary>
        /// lista todos los Vendedores existentes cogiendo el factory getvendedorall
        /// </summary>
        /// <returns></returns>
        List<VendedorInfo> ListAll();


         /// <summary>
        /// Lista un vendedor por CodVendedor usando factory getvendedorall.
        /// </summary>
        /// <returns></returns>
        VendedorInfo ListxCodVendedorAll(string CodVendedor);

        #endregion
    }
}
