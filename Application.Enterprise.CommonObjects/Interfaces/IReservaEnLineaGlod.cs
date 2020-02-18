using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{ 
    public interface IReservaEnLineaGlod
    {
        string RealizarReservaEnLinea(string NumeroPedido);
        string RealizarReservaEnLineaDifBodega(string NumeroPedido, string bodega, int cobrarFlete);
    }
}

