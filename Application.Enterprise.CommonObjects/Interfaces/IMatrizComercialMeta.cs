using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// JA
    /// </summary>
    public interface IMatrizComercialMeta
    {
        /// <summary>
        /// lista el presupuesto matriz usando distinct en campana
        /// </summary>
        /// <returns></returns>
        List<MatrizComercialMetaInfo> ListCampana();

        /// <summary>
        /// Lista presupuesto por una campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        List<MatrizComercialMetaInfo> ListxCampana(String campana);

        /// <summary>
        /// Eliminar una meta
        /// </summary>
        /// <param name="Campana"></param>
        /// <param name="zona"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool DeleteMeta(string Campana, string zona, string usuario);

         /// <summary>
        /// Inserta registros en tabla matriz presupuesto
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool InsertRegistroMeta(MatrizComercialMetaInfo item);
        
        
       
    }
}
