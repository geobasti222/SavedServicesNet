using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para PremiosPuntosTotalSep
    /// </summary>
    public class PremiosPuntosTotalSep : IPremiosPuntosTotalSep
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosPuntosTotalSep module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosPuntosTotalSep()
        {
            module = new Application.Enterprise.Data.PremiosPuntosTotalSep();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosPuntosTotalSep(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosPuntosTotalSep(databaseName);
        }

        #region Miembros de IPremiosPuntosTotalSep

        /// <summary>
        /// Lista los puntos totales de un premio especifico de niveles separados.
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalSepInfo> ListxPremio(int IdPremio)
        {
            return module.ListxPremio(IdPremio);
        }

        /// <summary>
        /// Lista los nit que contienen puntos de un premio y nivel
        /// </summary>
        /// <param name="IdPremio"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalSepInfo> ListNitPuntosxPremio(int IdPremio)
        {
            return module.ListNitPuntosxPremio(IdPremio);
        }

        /// <summary>
        /// Lista los puntos que contienen un nit por nivel.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdNivel"></param>
        /// <returns></returns>
        public List<PremiosPuntosTotalSepInfo> ListPuntosxNitxNivel(string Nit, int IdNivel)
        {
            return module.ListPuntosxNitxNivel(Nit, IdNivel);
        }

        /// <summary>
        ///  actualiza los puntos de un cliente a 0 (cero) por que ya se le asigno un premio.
        /// </summary>
        /// <param name="Nit"></param>
        /// <param name="IdNivel"></param>
        /// <returns></returns>
        public bool UpdatePuntos(string Nit, int IdNivel)
        {
            try
            {
                return module.UpdatePuntos(Nit, IdNivel);
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
