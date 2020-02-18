using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;
using System.Data;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// JA
    /// </summary>
    public class ReglasJA : IReglasJA
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ReglasJA module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public ReglasJA()
        {
            module = new Application.Enterprise.Data.ReglasJA();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public ReglasJA(string databaseName)
        {
            module = new Application.Enterprise.Data.ReglasJA(databaseName);
        }

        /// <summary>
        /// Guarda una regla nueva.
        /// </summary>
        /// <param name="item"></param>
        public bool Insert(ReglaJAInfo item,string usuario)
        {
            try
            {
                return module.Insert(item,usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// lista las reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglaJAInfo> ListReglas()
        {
            return module.ListReglas();
        }

        /// <summary>
        /// Lista reglas por una campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        public List<ReglaJAInfo> ListReglasxCampana(String campana)
        {
            return module.ListReglasxCampana(campana);
        }

        /// <summary>
        /// lista las campañas de las reglas
        /// </summary>
        /// <returns></returns>
        public List<ReglaJAInfo> ListCampañas()
        {
            return module.ListCampañas();
        }

         /// <summary>
        /// lista los estados
        /// </summary>
        /// <returns></returns>
        public List<EstadosClienteInfo> ListEstados()
        {
            return module.ListEstados();
        }

        /// <summary>
        /// lista las campañas 
        /// </summary>
        /// <returns></returns>
        public List<CampanaInfo> ListCampañasAll()
        {
            return module.ListCampañasAll();
        }

         /// <summary>
        /// busca el producto para premiar
        /// </summary>
        /// <returns></returns>
        public DataTable ListPremioReglas(string codigoCorto)
        {
            return module.ListPremioReglas(codigoCorto);
        }

         /// <summary>
        /// "borra" acutaliza una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeleteReglas(int id, string Usuario)
        {
            return module.UpdateDeleteReglas(id, Usuario);
        }

         /// <summary>
        /// busca la existencias del producto
        /// </summary>
        /// <returns></returns>
        public DataTable ListCantidadPremio(string codigoCorto)
        {
            return module.ListCantidadPremio(codigoCorto);
        }

        /// <summary>
        /// acutaliza El estado activo de una regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public bool UpdateActivoRegla(int id, string Usuario, bool activo)
        {
            return module.UpdateActivoRegla(id, Usuario, activo);
        }

        /// <summary>
        /// lista las zonas 
        /// </summary>
        /// <returns></returns>
        public List<ZonaInfo> Listzonas()
        {
            return module.Listzonas();
        }


        /// <summary>
        /// LLama el id de la regla maxima o ultima
        /// </summary>
        /// <returns></returns>
        public ReglaJAInfo llamarregla()
        {
            return module.llamarregla();
        }


        /// <summary>
        /// Guarda una regla nueva.
        /// </summary>
        /// <param name="item"></param>
        public bool InsertZonas(ReglaJAInfo item, string usuario)
        {
            try
            {
                return module.InsertZonas(item, usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }

        /// <summary>
        /// listar las zonas por una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public List<ReglaJAInfo> ListZonasReglas(int regla)
        {
            return module.ListZonasReglas(regla);
        }

        // <summary>
        /// "borra" acutaliza una zona
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeleteZona(int id, string Usuario)
        {
            return module.UpdateDeleteZona(id, Usuario);
        }


        /// <summary>
        /// listar la regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public ReglaJAInfo ListRegla(int regla)
        {
            return module.ListRegla(regla);
        }

         /// <summary>
        /// Inserta los productos de una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public bool InsertProducto(ReglaJAInfo producto, String Usuario)
        {
            try
            {
                return module.InsertProducto(producto, Usuario);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("NIVI Error: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));

                return false;
            }
        }


         /// <summary>
        /// listar los premios por una regla
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public List<ReglaJAInfo> ListPremiosReglas(int regla)
        {
            return module.ListPremiosReglas(regla);
        }


        /// <summary>
        /// "borra" acutaliza un premio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeletePremio(int id, string Usuario)
        {
            return module.UpdateDeletePremio(id, Usuario);
        }



        /// <summary>
        /// "borra"  los premios por regla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateDeletePremiosPorRegla(int id, string Usuario)
        {
            return module.UpdateDeletePremiosPorRegla(id, Usuario);
        }
    }
}
