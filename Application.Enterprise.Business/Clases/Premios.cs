using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class Premios : IPremios
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Premios module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Premios()
        {
            module = new Application.Enterprise.Data.Premios();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Premios(string databaseName)
        {
            module = new Application.Enterprise.Data.Premios(databaseName);
        }

        #region Miembros de IPremios
        /// <summary>
        ///Lista todos los premios
        /// </summary>
        /// <returns></returns>
        public List<PremiosInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista un premio especifico.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public PremiosInfo ListxId(int IdPremio)
        {
            return module.ListxId(IdPremio);
        }

        /// <summary>
        /// Lista los premios ordenados.
        /// </summary>
        /// <returns></returns>
        public List<PremiosInfo> ListxOrden()
        {
            return module.ListxOrden();
        }

        /// <summary>
        /// busca un premio por nombre.
        /// </summary>
        /// <param name="NombrePremio"></param>
        /// <returns></returns>
        public List<PremiosInfo> ListxNombre(string NombrePremio)
        {
            return module.ListxNombre(NombrePremio);
        }

        /// <summary>
        /// Realiza el registro de un premio.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosInfo item)
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
        /// Realiza la actualizacion  de un premio.
        /// </summary>
        /// <param name="item"></param>
        public bool Update(PremiosInfo item)
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
        /// Elimina un premio especifico.	
        /// </summary>
        /// <param name="NumeroPedido"></param>
        /// <returns></returns>
        public bool DeletexIdPremio(int IdPremio)
        {
            try
            {
                return module.DeletexIdPremio(IdPremio);
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
