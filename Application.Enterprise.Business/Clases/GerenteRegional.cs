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
    public class GerenteRegional : IGerenteRegional
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.GerenteRegional module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public GerenteRegional()
        {
            module = new Application.Enterprise.Data.GerenteRegional();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public GerenteRegional(string databaseName)
        {
            module = new Application.Enterprise.Data.GerenteRegional(databaseName);
        }



        #region Miembros de IVendedor
        /// <summary>
        /// Listsa todos los gerentes regionales
        /// </summary>
        /// <returns></returns>
        public List<GerenteRegionalInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Busca el GerenteRegional especifico
        /// </summary>
        /// <param name="CodCiudad"></param>
        /// <returns></returns>
        public GerenteRegionalInfo ListxGerente(string Gerente)
        {
            return module.ListxGerente(Gerente);
        }

    

        /// <summary>
        /// Guarda un GerenteRegional nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(GerenteRegionalInfo item)
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
        /// Realiza la actualizacion de un GerenteRegional existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(GerenteRegionalInfo item)
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

       
        #endregion
    }
}
