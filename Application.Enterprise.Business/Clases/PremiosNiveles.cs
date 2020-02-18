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
    public class PremiosNiveles : IPremiosNiveles
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.PremiosNiveles module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PremiosNiveles()
        {
            module = new Application.Enterprise.Data.PremiosNiveles();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public PremiosNiveles(string databaseName)
        {
            module = new Application.Enterprise.Data.PremiosNiveles(databaseName);
        }

        #region Miembros de IPremiosNiveles
        /// <summary>
        /// Lista todos los Niveles.
        /// </summary>
        /// <returns></returns>
        public List<PremiosNivelesInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Lista todos los Niveles de un premio especifico.  Se debe ordenar por puntos para validar la asignacion de premios.
        /// </summary>
        /// <returns></returns>
        public List<PremiosNivelesInfo> ListxPremio(int IdPremio)
        {
            return module.ListxPremio(IdPremio);
        }

        /// <summary>
        /// Realiza el registro del nivel de un premio.
        /// </summary>
        /// <param name="item"></param>
        public int Insert(PremiosNivelesInfo item)
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
