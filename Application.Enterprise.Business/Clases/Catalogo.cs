using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Catalogo JA
    /// </summary>
    public class Catalogo : ICatalogo
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Catalogo module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Catalogo()
        {
            module = new Application.Enterprise.Data.Catalogo();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Catalogo(string databaseName)
        {
            module = new Application.Enterprise.Data.Catalogo(databaseName);
        }

        #region Miembros de ICatalogo
        /// <summary>
        /// Lista todos los catalogos.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public CatalogoInfo ListCatalogoActual()
        {
            return module.ListCatalogoActual();
        }

        /// <summary>
        /// Lista el catalogo de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInfo> ListCatalogoFechaActual()
        {
            return module.ListCatalogoFechaActual();
        }

        /// <summary>
        /// Lista el catalogo de NIVI de la fecha actual.
        /// </summary>
        /// <returns></returns>
        public CatalogoInfo ListCatalogoNIVIxFechaActual()
        {
            return module.ListCatalogoNIVIxFechaActual();
        }

        /// <summary>
        /// Lista la cantidad de catalogos de NIVI solicitados ordenados de mayor a menor
        /// </summary>
        /// <returns></returns>
        public List<CatalogoInfo> ListUltimosCatalogoNIVI()
        {
            return module.ListUltimosCatalogoNIVI();
        }

        /// <summary>
        /// Lista un catalogo x id.
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public List<CatalogoInfo> ListxId(string Catalogo)
        {
            return module.ListxId(Catalogo);
        }

        /// <summary>
        /// Lista un catalogo x campana.
        /// </summary>
        /// <param name="Campana"></param>
        /// <returns></returns>
        public CatalogoInfo ListCatalogoxCampana(string Campana)
        {
            return module.ListCatalogoxCampana(Campana);
        }


        /// <summary>
        /// Guarda un catalogo nuevo.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(CatalogoInfo item)
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
        /// Realiza la actualizacion de un catalogo existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(CatalogoInfo item)
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
        /// Realiza la consulta de los catalogos que se interponen con otros.
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechafin"></param>
        /// <returns></returns>
        public List<CatalogoInfo> ListCatalogoTrasponen(DateTime fechaini, DateTime fechafin)
        {
            return module.ListCatalogoTrasponen(fechaini, fechafin);
        }


        /// <summary>
        /// Lista un catalogo x codigo.
        /// </summary>
        /// <param name="Catalogo"></param>
        /// <returns></returns>
        public CatalogoInfo ListxCodigo(string Catalogo)
        {
            return module.ListxCodigo(Catalogo);
        }
        #endregion
    }
}
