using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Premios Articulos
    /// </summary>
    public class PremiosArticulos : IPremiosArticulos
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosArticulos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosArticulos()
        {
            module = new Application.Enterprise.Data.PremiosArticulos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosArticulos(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosArticulos(databaseName);
        }

        #region Miembros de IPremiosArticulos

        /// <summary>
        /// Lista todos los articulos de los premios.
        /// </summary>
        /// <returns></returns>
        public List<PremiosArticulosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un articulo de un id especifico.
        /// </summary>
        /// <param name="IdArticulo"></param>
        /// <returns></returns>
        public PremiosArticulosInfo ListxId(int IdArticulo)
        {
            return module.ListxId(IdArticulo);
        }

        /// <summary>
        /// Lista todos los articulos de un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosArticulosInfo> ListxPremio(int IdPremio)
        {
            return module.ListxPremio(IdPremio);
        }

        /// <summary>
        /// Realiza el registro de articulo para un premio.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosArticulosInfo item)
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

        #endregion
    }
}
