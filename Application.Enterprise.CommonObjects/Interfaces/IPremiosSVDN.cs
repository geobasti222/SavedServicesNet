using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IPremiosSVDN
    {
        /// <summary>
        /// Calcula el premio
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        bool ganarPremio(string pedido);

       /// <summary>
        /// Inserta el premio en el pedido
       /// </summary>
       /// <param name="pedido"></param>
       /// <returns></returns>
        bool insertarPremio(string pedido);
        
        
    }
}
