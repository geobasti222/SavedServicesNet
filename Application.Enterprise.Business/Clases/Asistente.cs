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
    public class Asistente : IAsistente
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Asistente module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Asistente()
        {
            module = new Application.Enterprise.Data.Asistente();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Asistente(string databaseName)
        {
            module = new Application.Enterprise.Data.Asistente(databaseName);
        }

        #region Miembros de IPais

        /// <summary>
        /// GAVL  INSERTA ASISTENTES X ZONAS
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertAsistente(AsistenteInfo item, string Usuario)
        {
            return module.InsertAsistente (item,Usuario);
        }


        /// <summary>
        /// GAVL  INSERTA ASISTENTES X ZONAS
        /// </summary>
        /// <param name="Asistente"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertAsistenteXZona(string Asistente, string Zona, string Usuario)
        {
            return module.InsertAsistenteXZona(Asistente,Zona, Usuario);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool UpdateAsistente(AsistenteInfo item, string Usuario)
        {
            return module.UpdateAsistente(item, Usuario);
        }


        /// <summary>
        /// GAVL  ELIMINA ASISTENTES X ZONAS
        /// </summary>
        /// <param name="Asistente"></param>
        /// <param name="Zona"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteAsistenteXZona(string Asistente, string Zona, string Usuario)
        {
            return module.DeleteAsistenteXZona(Asistente, Zona, Usuario);
        }  
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AsistenteInfo> List()
        {
            return module.List();
        }

        public AsistenteInfo ListXAsistenteXZona(string Zona, string asistente)
        {
            return module.ListXAsistenteXZona(Zona, asistente);
        }

        public AsistenteInfo ListXAsistente(string asistente)
        {
            return module.ListXAsistente(asistente);
        }

        /// <summary>
        /// Lista todos los asistentes X Zona Asistente
        /// </summary>
        /// <returns></returns>
        public List<AsistenteInfo> ListAsiszona()
        {
            return module.ListAsiszona();
        }


        public AsistenteInfo AsistenteXZona(string Zona)
        {
            return module.AsistenteXZona(Zona);
        }

        public string ListZona(string Asistente)
        {
            return module.ListZona(Asistente);
        }

        #endregion
    }
}
