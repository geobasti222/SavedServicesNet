using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para PremiosPuntosTotal
    /// </summary>
    public class PremiosPuntosTotal : IPremiosPuntosTotal
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosPuntosTotal module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosPuntosTotal()
        {
            module = new Application.Enterprise.Data.PremiosPuntosTotal();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosPuntosTotal(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosPuntosTotal(databaseName);
        }

        #region Miembros de IPremiosPuntosTotal

        /// <summary>
        /// Lista los puntos totales de un premio especifico
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalInfo> ListxPremio(int IdPremio)
        {
            return module.ListxPremio(IdPremio);
        }

        /// <summary>
        /// actualiza los puntos de un cliente a 0 (cero) por que ya se le asigno un premio.
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public bool UpdatePuntos(string Nit)
        {
            try
            {
                return module.UpdatePuntos(Nit);
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
