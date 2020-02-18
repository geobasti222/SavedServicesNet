using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects.Interfaces;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Business
{
    /// <summary>
    /// clase de negocio para Regionales
    /// </summary>
    public class Regionales : IRegionales
    {
        /// <summary>
        /// Instancia en la capa de acceso a datos.
        /// </summary>
        private Application.Enterprise.Data.Regionales module;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Regionales()
        {
            module = new Application.Enterprise.Data.Regionales();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="databaseName">Nombre de la Base de Datos.</param>
        public Regionales(string databaseName)
        {
            module = new Application.Enterprise.Data.Regionales(databaseName);
        }

        #region Miembros de IRegionales
        /// <summary>
        /// Lista todos las regiones existentes.
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> List()
        {
            return module.List();
        }

        /// <summary>
        /// Consulta una regional por id
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public RegionalesInfo ListxId(int CodigoRegional)
        {
            return module.ListxId(CodigoRegional);
        }

        /// <summary>
        /// Lista una regional por zona.
        /// </summary>
        /// <param name="Zona"></param>
        /// <returns></returns>
        public RegionalesInfo ListxZona(string Zona)
        {
            return module.ListxZona(Zona);
        }

         /// <summary>
        /// -Lista una regional por cedula de regional
        /// </summary>
        /// <param name="CedulaRegional"></param>
        /// <returns></returns>
        public RegionalesInfo ListxCedulaRegional(string CedulaRegional)
        {
            return module.ListxCedulaRegional(CedulaRegional);
        }

        public List<RegionalesInfo> ListRegionesPais()
        {
            return module.ListRegionesPais();
        }

        /// <summary>
        /// Se obtiene la regiones por codigo
        /// </summary>
        /// <param name="CodigoRegional"></param>
        /// <returns></returns>
        public RegionalesInfo ListxCedulaRegional(int CodigoRegional)
        {
            return module.ListxCedulaRegional(CodigoRegional);
        }


        /// <summary>
        /// Lista una regional Y nombre de gerente
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> ListXGerente()
        {
            return module.ListXGerente();
        }

        /// <summary>
        /// Realiza el registro de una regional
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool InsertRegionales( RegionalesInfo  item, string Usuario)
        {
            return module.InsertRegionales(item, Usuario);
        }

        /// <summary>
        /// Realiza el eliminacion  de una regional
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public bool DeleteRegionales(string CodigoRegional, string Usuario)
        {
            return module.DeleteRegionales(CodigoRegional, Usuario);
        }

        /// <summary>
        /// Lista  nombre de gerente
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> ListGerentes()
        {
            return module.ListGerentes();
        }


        /// <summary>
        /// Lista  los gerentesregionales
        /// </summary>
        /// <returns></returns>
        public List<RegionalesInfo> ListGerentesRegionales()
        {
            return module.ListGerentesRegionales();
        }



        /// <summary>
        /// Realiza la actualizacion de un divisional existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(RegionalesInfo item)
        {
            try
            {
                return module.Update(item);
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
