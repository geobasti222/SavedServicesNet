using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;
using System.Data;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    public interface IBodega
    {
         /// <summary>
        /// lista lso amarrados
        /// </summary>
        /// <returns></returns>
        List<BodegaInfo> List();
        
    }
}
