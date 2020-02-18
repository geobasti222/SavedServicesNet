using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Auditoria
    /// </summary>
    public interface IAuditoria
    {
        #region "Metodos de Auditoria"

        /// <summary>
        /// lista todos las Auditorias existentes.
        /// </summary>
        /// <returns></returns>
        List<AuditoriaInfo> List();

        /// <summary>
        /// Guarda un proceso de auditoria en el sistema.
        /// </summary>
        /// <param name="item"></param>
        bool Insert(AuditoriaInfo item);

        #endregion
    }
}

