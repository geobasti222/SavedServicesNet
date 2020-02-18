using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para pais
    /// </summary>
    public class Ciclos 
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Ciclos module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Ciclos()
        {
            module = new Application.Enterprise.Data.Ciclos();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Ciclos(string databaseName)
        {
            module = new Application.Enterprise.Data.Ciclos(databaseName);
        }

        #region Miembros de ICiclos
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CiclosInfo> List()
        {
            return module.List();
        }

        public CiclosInfo CiclosXCiclo(string Codciclo)
        {
            return module.CiclosXCiclo(Codciclo);
        }

        public bool InsertCiclos(CiclosInfo item, string Usuario)
        {
            return module.InsertCiclos(item, Usuario);
        }

        public bool UpdateCiclos(CiclosInfo item, string Usuario)
        {
            return module.UpdateCiclos(item, Usuario);
        }

        public bool DeleteCiclos(string ciclo, string Usuario)
        {
            return module.DeleteCiclos(ciclo, Usuario);
        }

        #endregion
    }
}
