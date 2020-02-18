using Microsoft.AspNet.SignalR;
using Quartz.Util;
using System;

namespace Application.Enterprise.Services.RealTime
{
    //Esta es la clase que se debe usar desde afuera para notificar a todos los que esten subscritos

    public class ExternalTickerNotifier
    {
        /*public static void BroadCastTransaction(TransactionSummarized transaction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateTransaction(transaction);
        }

        public static void BroadCastDateTime(DateTime date)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateDateTime(date);
        }

        public static void BroadCastTransactionMin(TransactionSummarized transaction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateTransactionMin(transaction);
        }

        public static void BroadCastCloseIntraday(CloseIntraDay closeIntraDay)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateCloseIntraday(closeIntraDay);
        }

        public static void BroadCastNewBidsOffers(BidsOffers ListBidsOffers)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateNewBidsOffers(ListBidsOffers);
        }

        public static void BroadCastUpdateBidsOffers(BidsOffers ListBidsOffers)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateBidsOffers(ListBidsOffers);
        }

        public static void NotifyOrderMatch(string strGroup, Order order)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyOrder(order);
        }

        public static void NotifyUpdateOrder(string strGroup, Order order)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyUpdateOrder(order);
        }

        public static void NotifyReplaceOrder(string strGroup, Order order)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyReplaceOrder(order);
        }

        public static void NotifyOrderCancel(string strGroup, Order order)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyOrdercancel(order);
        }

        public static void NotifyComplementadaOrder(string strGroup, Order order)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyComplementadaOrder(order);
        }

        #region Esto hay que cambiarlo

        /// <summary>
        /// Se notifica a todos los conectados para
        /// que funcione en java como raro con JAVA
        /// </summary>

        public static void BroadCastNotifyOrderMatch(Order order)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyOrderBroadCast(order);
        }

        public static void BroadCastNotifyOrderCancel(Order order)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyOrdercancelBroadCast(order);
        }

        public static void NotifyDisconnectionBroadCast(string strUser)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyDisconnectionBroadcast(strUser);
        }

        public static void NotifyDisconnectionBroadCastAdmin(string strUser)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyDisconnectionBroadcastAdmin(strUser);
        }

        #endregion Esto hay que cambiarlo

        public static void NotifyNews(News news)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifynews(news);
        }

        public static void NotifyLogoutAll()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyLogoutAll();
        }
        

        public static void NotifyDollar(DollarBidOffer dollar)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifydollar(dollar);
        }

        public static void NotifyAuction(Auction Auction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyAuction(Auction);
        }

        public static void BroadCastReferencePrice(Auction Auction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyReferencePrice(Auction);
        }

        public static void NotifyAlarm(string strGroup, Alarm alarm)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyalarm(alarm);
        }

        public static void NotifyIndicator(Indicators indicator)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyIndicator(indicator);
        }
        */
        public static void BroadCastTargetPrice(Object[] objResponse)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateTargetPrice(objResponse);
        }

        public static void BroadCastAuction(Object[] objResponse)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.updateAuction(objResponse);
        }

        public static void NotifyDisconnection(string strGroup)
        {
            if (strGroup.IsNullOrWhiteSpace()) return;

            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyDisconnection();
        }

        public static void NotifyDisconnectionAdmin(string strGroup)
        {
            if (strGroup.IsNullOrWhiteSpace()) return;
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyDisconnectionAdmin();
        }

        public static void NotifyBlockedUser(string strGroup)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyBlockedUser();
        }

        public static void NotifyUnBlockedUser(string strGroup)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyUnBlockedUser();
        }

        public static void NotifyChangeSegment(Object[] objResponse, string strGroup)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyChangeSegment(objResponse);
        }

        public static void NotifyMessage(string objResponse)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyMessage(objResponse);
        }

        /*public static void NotifyMessageUser(MessageUser msg)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyMessageUser(msg);
        }

        public static void NotifyReports(Report objResponse)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyReports(objResponse);
        }
        public static void NotifyUdateFolioCoeasy(string documento)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.udateFolioCoeasy(documento);
        }
        public static void NotifyBlockedChat(Object[] objResponse, string strGroup)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyBlockedChat(objResponse);
        }

        public static void BroadCastMinLimit(Auction Auction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyMinLimit(Auction);
        }

        public static void BroadCastMaxLimit(Auction Auction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.All.notifyMaxLimit(Auction);
        }

        public static void NotifyUpdateInfo(string strGroup, string strClient)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).NotifyUpdateInfo(strClient);
        }

        #region Demo

        public static void BroadCastTransactionDemo(TransactionSummarized transaction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group("DemoAccount").updateTransactionDemo(transaction);
        }

        public static void BroadCastNewBidsOffersDemo(BidsOffers ListBidsOffers)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group("DemoAccount").updateNewBidsOffersDemo(ListBidsOffers);
        }

        public static void BroadCastUpdateBidsOffersDemo(BidsOffers ListBidsOffers)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group("DemoAccount").updateBidsOffersDemo(ListBidsOffers);
        }

        public static void BroadCastCloseIntradayDemo(CloseIntraDay closeIntraDay)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group("DemoAccount").updateCloseIntradayDemo(closeIntraDay);
        }

        public static void BroadCastTransactionMinDemo(TransactionSummarized transaction)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group("DemoAccount").updateTransactionMinDemo(transaction);
        }*/

        //#endregion Demo

        public static void NotifyCreateOrderAlarm(string strGroup, string stridOrdenAlarma)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyCreateOrderAlarm(stridOrdenAlarma);
        }

        public static void NotifyErrorOrderAlarm(string strGroup, string strMsj)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>();
            context.Clients.Group(strGroup).notifyErrorOrderAlarm(strMsj);
        }
    }
}