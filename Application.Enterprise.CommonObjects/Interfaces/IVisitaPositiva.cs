using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Visita Positiva
    /// </summary>
    public interface IVisitaPositiva
    {
        #region "Metodos de VisitaPositiva"

        /// <summary>
        /// Lista todos los tipo de visita positiva
        /// </summary>
        /// <returns></returns>
        List<VisitaPositivaInfo> List();    
              
        #endregion
    }
}

