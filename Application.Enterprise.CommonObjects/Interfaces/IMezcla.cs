using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IMezcla
    {
        /// <summary>
        /// lista todos las campañas existentes.
        /// </summary>
        /// <returns></returns>
        DataTable traerClaseVenta();
    }
}
