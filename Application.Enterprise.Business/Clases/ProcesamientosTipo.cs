using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Procesamientos Tipo
    /// </summary>
    public class ProcesamientosTipo : IProcesamientosTipo
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.ProcesamientosTipo module;

        public ProcesamientosTipo()
        {
            module = new Application.Enterprise.Data.ProcesamientosTipo();
        }

        public ProcesamientosTipo(string databaseName)
        {
            module = new Application.Enterprise.Data.ProcesamientosTipo(databaseName);
        }

        #region Miembros de IBarrios

        /// <summary>
        /// Mostrar todos los elementos de la tabla SVDN_CLIENTES_HISTORICO_RESUMEN
        /// </summary>
        /// <returns></returns>
        public List<ProcesamientosTipoInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Insercion de un tipo de procesamiento
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string InsertProcesamientoTipo(ProcesamientosTipoInfo item)
        {
            return InsertProcesamientoTipo(item);
        }

        /// <summary>
        /// Actualiza la descripcion de SVDN_PROCESAMIENTOS_TIPO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool UpdateProcesamientoTipo(ProcesamientosTipoInfo item)
        {
            return UpdateProcesamientoTipo(item);
        }

        /// <summary>
        /// Elimina un elemento de SVDN_PROCESAMIENTOS_TIPO de acuerdo a una ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool DeleteProcesamientoTipo(ProcesamientosTipoInfo item)
        { 
            return DeleteProcesamientoTipo(item);
        }

        #endregion
    }
}
