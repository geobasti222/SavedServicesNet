using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IEfectyx
    {
        /// <summary>
        /// Traer los saldos de la cartera por mes
        /// </summary>
        /// <returns></returns>
        DataTable traerCarteraSaldos();

         /// <summary>
        /// Traer llos totales linea 03
        /// </summary>
        /// <returns></returns>
        DataTable traerTotales();
        
        
    }
}
