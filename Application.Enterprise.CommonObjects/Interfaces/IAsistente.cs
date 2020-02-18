using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Asistente
    /// </summary>
    public interface IAsistente
    {
        #region "Metodos de Asistente"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool InsertAsistente(AsistenteInfo item, string Usuario);


        /// <summary>
        ///  GAVL  INSERTA ASISTENTES X ZONAS
        /// </summary>
        /// <param name="Asistente"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool InsertAsistenteXZona(string Asistente, string Zona, string Usuario);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateAsistente(AsistenteInfo item, string Usuario);


        /// <summary>
        /// GAVL  ELIMINA ASISTENTES X ZONAS
        /// </summary>
        /// <param name="Asistente"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool DeleteAsistenteXZona(string Asistente, string Zona, string Usuario);


        /// <summary>
        /// lista todos los Asistente existentes.
        /// </summary>
        /// <returns></returns>
        List<AsistenteInfo> List();

        /// <summary>
        /// Lista todos los asistentes de una Zona
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        AsistenteInfo ListXAsistenteXZona(string Zona, string asistente);


        /// <summary>
        /// Lista todos por asistente
        /// </summary>
        /// <param name="asistente"></param>
        /// <returns></returns>
        AsistenteInfo ListXAsistente(string asistente);



        AsistenteInfo AsistenteXZona(string Zona);
              
        #endregion
    }
}

