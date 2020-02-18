using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Application.Enterprise.Services.Models;
using Application.Enterprise.Services.Controllers;
using System.Threading.Tasks;
using Application.Enterprise.CommonObjects;
using System.Reflection;

namespace Application.Enterprise.Services.RealTime
{
    [HubName("RealTimeHubTicker")]
    public class RealTimeHub : Hub
    {
        private static Lazy<Autentication> _Instance = new Lazy<Autentication>(() => new Autentication());
        public static Autentication Instance
        {
            get
            {
                return _Instance.Value;
            }
        }
        //  private readonly RealTimeTicker _transactionTicker;
        //public RealTimeHub() : this(RealTimeTicker.Instance) { }
        //public RealTimeHub(RealTimeTicker transactionTicker)
        //{
        //    _transactionTicker = transactionTicker;
        //}
        static Dictionary<string,string> ConnectedUsers = new Dictionary<string, string>();

        public void AddConnectionGroup(string strgroup)
        {
            if (ConnectedUsers.ContainsValue(strgroup))
                RemoveConnection(strgroup);
            if (!ConnectedUsers.ContainsKey(Context.ConnectionId))
                ConnectedUsers.Add(Context.ConnectionId, strgroup);
            this.Groups.Add(Context.ConnectionId, strgroup);
        }
        
        public void RemoveConnection(string strgroup)
        {
            this.Groups.Remove(Context.ConnectionId, strgroup);

            //------------------------------------------------------------------------------------------------------------------------
            //Elimina el usuario que se conecta en la tabla usuarios.            
            //Business.Usuario.BorrarUsuarioOnline(strgroup);
            System.Diagnostics.Trace.WriteLine(string.Format("CorredoresDavivienda ApiWebServices Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "Usuario Desconectado y eliminado: " + strgroup, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name));
            //------------------------------------------------------------------------------------------------------------------------

          
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                if (!ConnectedUsers.ContainsKey(Context.ConnectionId)) return null;

                var item = ConnectedUsers[Context.ConnectionId];
                if (item != null)
                {
                    ConnectedUsers.Remove(Context.ConnectionId);
                    var id = Context.ConnectionId;
                   // AutenticationUserController.Instance.LogOutUserAdmin(item, false);

                    //------------------------------------------------------------------------------------------------------------------------
                    //Elimina el usuario que se conecta en la tabla usuarios.
                    //Business.Usuario.BorrarUsuarioOnline(item);
                    System.Diagnostics.Trace.WriteLine(string.Format("CorredoresDavivienda ApiWebServices Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", "Usuario Desconectado y eliminado: " + item, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace, System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, System.Reflection.MethodBase.GetCurrentMethod().Name));
                    //------------------------------------------------------------------------------------------------------------------------
                    //Registrar Evento de Seguridad
                    try
                    {
                        //Data.LogSeguridad.Adicionar(DateTime.Now, item?.Trim(), "0", EventoSeguridadSistema.CierraSession.GetHashCode());
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                        /*Infrastructure.Models.Operation itemNews = new Infrastructure.Models.Operation();
                        itemNews.Error = new Infrastructure.Models.Error();
                        itemNews.Error.existError = true;
                        itemNews.Error.Code = 3;
                        itemNews.Error.Description = ex.Message;*/
                    }


                }
            }
            return base.OnDisconnected(stopCalled);
        }

        //Estos 2 metodos se pueden llamar desde algun cliente para que inicie o pare la simulacion de enviar cambios cada n ms
        //public void StartSimulation()
        //{
        //    _transactionTicker.StartSimulation();
        //}

        //public void StopSimulation()
        //{
        //    _transactionTicker.StopSimulation();

        //}



    }




}