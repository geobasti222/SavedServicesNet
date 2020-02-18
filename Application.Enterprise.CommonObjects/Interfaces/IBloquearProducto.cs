using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IBloquearProducto
    {
        /// <summary>
        /// Inserta los datos de las blqoueproducto en la tabla 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool Insert(BloquearProductoInfo item, string Usuario);

         /// <summary>
        /// Lista bloqueoproducto por una campana
        /// </summary>
        /// <param name="campana"></param>
        /// <returns></returns>
        List<BloquearProductoInfo> ListbloqueoproductoxCampana(String campana);

        /// <summary>
        /// lista las campañas de las bloqueoproducto
        /// </summary>
        /// <returns></returns>
        List<BloquearProductoInfo> ListCampañas();
        
        /// <summary>
        /// lista las bloqueoproductos
        /// </summary>
        /// <returns></returns>
        List<BloquearProductoInfo> ListBloqueoproductos();
        
        /// <summary>
        /// "borra" acutaliza una bloqueoproducto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        bool UpdateDeletebloqueoproducto(int id, string Usuario);

        /// <summary>
        /// lista las campañas 
        /// </summary>
        /// <returns></returns>
        List<CampanaInfo> ListCampañasAll();
        

        
    }
}
