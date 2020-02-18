using System;
using System.Collections.Generic;
using System.Text;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.CommonObjects.Interfaces
{
    /// <summary>
    /// Interface de Historico
    /// </summary>
    public interface IHistoricoCliente
    {
        #region "Metodos de Historico Cliente"
        
        /// <summary>
        /// Guarda un historico de clientes nuevo.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Insert(HistoricoClienteInfo item);

        /// <summary>
        /// Insercion de todos los campos en la tabla SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool FullInsert(HistoricoClienteInfo item);

        ///// <summary>
        ///// Insercion de los estados calculados de los usuarios que hicieron pedidos para la campaña actual.
        ///// </summary>
        ///// <param name="EmpresariasConPedido">true: filtrar por empresarias con pedido; false: filtrar por empresarias sin pedido</param>
        ///// <param name="fecha"></param>
        ///// <returns></returns>
        //bool InsertNuevoEstadoCliente(bool EmpresariasConPedido, DateTime fecha);

        /// <summary>
        /// Realiza insercion de los clientes que son prospectos en la tabla de SVDN_CLIENTES_HISTORICO
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool InsertNuevoProspecto(DateTime fecha);

        /// <summary>
        /// Insercion de Nuevas, Activas, Retenidas y Reingresos
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool InsertEstadosIngresos(DateTime fecha);

        /// <summary>
        /// Insercion de Posibles Egresos, Egresos e Inactivas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool InsertEstadosInactividades(DateTime fecha);

        /// <summary>
        /// Insercion de prospectos de campaña anterior en nueva campaña
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool InsertProspectosCampAnterior(DateTime fecha);
                
        /// <summary>
        /// Elimina los registros de SVDN_CLIENTES_HISTORICO que hayan anulado todos sus pedidos
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool EliminarPedidosAnulados(DateTime fecha);

        /// <summary>
        /// Fix del Bug que se genera al insertar nuevos prospectos
        /// Este procedimiento se encarga de eliminar los prospectos que se insertaron despues
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool EliminarProspectosFix(DateTime fecha);

        /// <summary>
        /// Realiza la actualizacion del estado activo de un historico existente.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateEstadoActivo(HistoricoClienteInfo item);

        /// <summary>
        /// Actualizacion de empresaria que haya realizado pedido
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool UpdateEmpresariasEstadoConPedido(DateTime fecha);

        /// <summary>
        /// Actualizacion de empresaria que NO haya realizado pedido
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool UpdateEmpresariasEstadoSinPedido(DateTime fecha);

        /// <summary>
        /// Actualizacion de campos de empresarias prospectos que puedan tener inconsistencias
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool UpdateProspectosIncompletos(DateTime fecha);

        /// <summary>
        /// Actualizacion de campos de empresarias que realizan anulaciones de todos sus pedidos.
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool UpdateAnulaciones(DateTime fecha);

        /// <summary>
        /// ACTUALIZACION DE ESTADOS EN LA TABLA CLIENTES
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        bool UpdateTablaClientes(DateTime fecha);

        /// <summary>
        /// Lista todos los historicos de clientes
        /// </summary>
        /// <returns></returns>
        List<HistoricoClienteInfo> List();

        /// <summary>
        /// Lista de informe comparativo de variables de la tabla de historicos de clientes entre campañas actual, anterior y año pasado
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        List<HistoricoClienteComparacionInfo> HistoricoComparacion(DateTime fecha);

        #endregion
    }
}

