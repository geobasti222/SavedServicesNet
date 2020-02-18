using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;


namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IReglasJA
    {
        /// <summary>
        /// Inserta los datos de las reglas en la tabla svdn_siesa_reglas
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool Insert(ReglaJAInfo item, string Usuario);

        /// <summary>
        /// lista las reglas
        /// </summary>
        /// <returns></returns>
        List<ReglaJAInfo> ListReglas();

        /// <summary>
        /// Lista reglas por una campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        List<ReglaJAInfo> ListReglasxCampana(String campana);

        /// <summary>
        /// lista las campañas de las reglas
        /// </summary>
        /// <returns></returns>
        List<ReglaJAInfo> ListCampañas();
        
         /// <summary>
        /// lista los estados
        /// </summary>
        /// <returns></returns>
        List<EstadosClienteInfo> ListEstados();

        /// <summary>
        /// lista las campañas 
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampañasAll();
        
         /// <summary>
        /// busca el producto para premiar
         /// </summary>
         /// <param name="codigoCorto"></param>
         /// <returns></returns>
        DataTable ListPremioReglas(string codigoCorto);

        /// <summary>
        /// "borra" acutaliza una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateDeleteReglas(int id, string Usuario);
        
         /// <summary>
        /// busca la existencias del producto
        /// </summary>
        /// <returns></returns>
        DataTable ListCantidadPremio(string codigoCorto);

        /// <summary>
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        bool UpdateActivoRegla(int id, string Usuario, bool activo);
        
        
        /// <summary>
        /// lista las zonas 
        /// </summary>
        /// <returns></returns>
        List<ZonaInfo> Listzonas();

        /// <summary>
        /// LLama el id de la regla maxima o ultima
        /// </summary>
        /// <returns></returns>
        ReglaJAInfo llamarregla();

        /// <summary>
        /// Inserta las zonas de una regla
      /// </summary>
      /// <param name="regla"></param>
      /// <param name="Zona"></param>
      /// <returns></returns>
        bool InsertZonas(ReglaJAInfo Zona, String Usuario);

        /// <summary>
        /// listar las zonas por una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        List<ReglaJAInfo> ListZonasReglas(int regla);

        // <summary>
        /// "borra" acutaliza una zona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateDeleteZona(int id, string Usuario);
        
        /// <summary>
        /// listar la regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        ReglaJAInfo ListRegla(int regla);

         /// <summary>
        /// Inserta los productos de una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        bool InsertProducto(ReglaJAInfo producto, String Usuario);

         /// <summary>
        /// listar los premios por una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        List<ReglaJAInfo> ListPremiosReglas(int regla);

        /// <summary>
        /// "borra" acutaliza un premio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateDeletePremio(int id, string Usuario);


        /// <summary>
        /// "borra"  los premios por regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateDeletePremiosPorRegla(int id, string Usuario);
        
    }
}
