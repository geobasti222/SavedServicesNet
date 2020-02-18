using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Application.Enterprise.Services.RealTime;
 
using System.Reflection;
using System.Diagnostics;
using System.Configuration;

namespace Application.Enterprise.Services
{
    public partial class Realtime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.Params["cmd"] != null)
                {
                    switch (Request.Params["cmd"].ToString())
                    {
                        case "TRANS":

                            //try
                            //{
                            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Log\LogWeb1.txt", true))
                            //{
                            //    file.WriteLine("OK - Date=" + Request.Params["Hora"].ToString() + " Nemo=" + Request.Params["Nemotecnico"].ToString());
                            //}

                            // Application.Enterprise.Data.Error.Adicionar(DateTime.Now, "RelaTime", Request.Params["Nemotecnico"].ToString(), "OK - Date=" + Request.Params["Hora"].ToString() + " Nemo=" + Request.Params["Nemotecnico"].ToString());

                           /* TransactionSummarized tran = new TransactionSummarized();
                            if (Request.Params["Hora"] != null)
                            tran.Date = DateTime.ParseExact(Request.Params["Hora"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Cantidad"] != null)
                            tran.Quantity = Convert.ToInt64(Request.Params["Cantidad"].ToString());
                            if (Request.Params["Precio"] != null)
                            tran.ClosingPrice = Convert.ToDouble(Request.Params["Precio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Minimo"] != null)
                            tran.Minimum = Convert.ToDouble(Request.Params["Minimo"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Maximo"] != null)
                            tran.Maximum = Convert.ToDouble(Request.Params["Maximo"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Promedio"] != null)
                            tran.Average = Convert.ToDouble(Request.Params["Promedio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Variacion"] != null)
                            tran.Variation = Convert.ToDouble(Request.Params["Variacion"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Cambio"] != null)
                            tran.Change = Convert.ToDouble(Request.Params["Cambio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Estado"] != null)
                            tran.state = Request.Params["Estado"].ToString();
                            if (Request.Params["TotalNegociado"] != null)
                            tran.TotalTrading = Convert.ToDouble(Request.Params["TotalNegociado"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            if (Request.Params["NumeroOperaciones"] != null)
                                tran.OperationsNumber = Convert.ToInt64(Request.Params["NumeroOperaciones"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            if (Request.Params["MarcaPrecio"] != null)
                            tran.SelectPrice = Request.Params["MarcaPrecio"].ToString();


                            if (Request.Params["TipoMercado"] != null)
                            {
                                //tran.Instrument = new Instrument
                                //{
                                tran.mnemonic = Request.Params["Nemotecnico"].ToString();
                                tran.DescriptionMnemonic = Request.Params["Nemotecnico"].ToString();
                                tran.Type = (Application.Enterprise.Infrastructure.Enumerations.MarketType)Convert.ToInt32(Request.Params["TipoMercado"].ToString());
                                //};
                            }
                            else
                            {
                                //tran.Instrument = new Instrument
                                //{
                                tran.mnemonic = Request.Params["Nemotecnico"].ToString();
                                tran.DescriptionMnemonic = Request.Params["Nemotecnico"].ToString();
                                //  };
                            }


                            ExternalTickerNotifier.BroadCastTransaction(tran);*/
                            Response.Write("OK");
                            //}
                            //catch (Exception err)
                            //{
                            //   Application.Enterprise.Data.Error.Adicionar(DateTime.Now, "RelaTime", "0", err.Message);
                            //}


                            break;

                        case "TRANSMIN":

                            /*TransactionSummarized transmin = new TransactionSummarized();
                            if (Request.Params["Hora"] != null)
                            transmin.Date = DateTime.ParseExact(Request.Params["Hora"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Cantidad"] != null)
                            transmin.Quantity = Convert.ToInt64(Request.Params["Cantidad"].ToString());
                            if (Request.Params["Precio"] != null)
                            transmin.ClosingPrice = Convert.ToDouble(Request.Params["Precio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Minimo"] != null)
                            transmin.Minimum = Convert.ToDouble(Request.Params["Minimo"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Maximo"] != null)
                            transmin.Maximum = Convert.ToDouble(Request.Params["Maximo"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Promedio"] != null)
                            transmin.Average = Convert.ToDouble(Request.Params["Promedio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Variacion"] != null)
                            transmin.Variation = Convert.ToDouble(Request.Params["Variacion"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Cambio"] != null)
                            transmin.Change = Convert.ToDouble(Request.Params["Cambio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Estado"] != null)
                            transmin.state = Request.Params["Estado"].ToString();
                            if (Request.Params["TotalNegociado"] != null)
                            transmin.TotalTrading = Convert.ToDouble(Request.Params["TotalNegociado"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            if (Request.Params["NumeroOperaciones"] != null)
                                transmin.OperationsNumber = Convert.ToInt64(Request.Params["NumeroOperaciones"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["MarcaPrecio"] != null)
                            transmin.SelectPrice = Request.Params["MarcaPrecio"].ToString();

                            if (Request.Params["TipoMercado"] != null)
                            {
                                transmin.mnemonic = Request.Params["Nemotecnico"].ToString();
                                transmin.DescriptionMnemonic = Request.Params["Nemotecnico"].ToString();
                                transmin.Type = (Application.Enterprise.Infrastructure.Enumerations.MarketType)Convert.ToInt32(Request.Params["TipoMercado"].ToString());
                            }
                            else
                            {
                                transmin.mnemonic = Request.Params["Nemotecnico"].ToString();
                                transmin.DescriptionMnemonic = Request.Params["Nemotecnico"].ToString();
                            }


                            ExternalTickerNotifier.BroadCastTransactionMin(transmin);


                            CloseIntraDay closeIntraDay = new CloseIntraDay();
                            if (Request.Params["Hora"] != null)
                                closeIntraDay.Date = DateTime.ParseExact(Request.Params["Hora"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            if (Request.Params["Cantidad"] != null)
                                closeIntraDay.Quantity = Convert.ToInt64(Request.Params["Cantidad"].ToString());
                            if (Request.Params["Precio"] != null)
                                closeIntraDay.ClosingPrice = Convert.ToDouble(Request.Params["Precio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            closeIntraDay.mnemonic = Request.Params["Nemotecnico"].ToString();


                            if (Request.Params["Consecutivo"] != null)
                                closeIntraDay.Consecutive = Convert.ToInt64(Request.Params["Consecutivo"].ToString());

                            ExternalTickerNotifier.BroadCastCloseIntraday(closeIntraDay);*/

                            Response.Write("OK");

                            break;

                        case "UPDATEBIDOFFER":
                            /*BidsOffers bidOffer = new BidsOffers();
                            //PosPuntaSimple  -- el indice que cambio an la profundidad desagrupada
                            //PosPuntaAgrupada -- el indice que cambio an la profundidad agrupada
                            //Profundidad -- la profundidad

                            bidOffer.PosPuntaSimple = Convert.ToInt64(Request.Params["PosPuntaSimple"].ToString());
                            bidOffer.PosPuntaAgrupada = Convert.ToInt64(Request.Params["PosPuntaAgrupada"].ToString());
                            bidOffer.Profundidad = Convert.ToDouble(Request.Params["Profundidad"].ToString());
                            bidOffer.Instrument = new Instrument { mnemonic = Request.Params["Nemotecnico"].ToString() };

                            if (Request.Params["Size"] != null)
                                bidOffer.Quantity = Convert.ToInt64(Request.Params["Size"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            if (Request.Params["Precio"] != null)
                                bidOffer.Price = Convert.ToDouble(Request.Params["Precio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            string strTipoNegocio = Request.Params["TipoNegocio"].ToString();
                            bidOffer.BussinessType = (strTipoNegocio == "C") ? TransactionType.Buy : TransactionType.Sell;
                            ExternalTickerNotifier.BroadCastUpdateBidsOffers(bidOffer);*/
                            Response.Write("OK");
                            break;

                        case "NEWBIDOFFER":
                            /*BidsOffers bidOfferNew = new BidsOffers();
                            bidOfferNew.Instrument = new Instrument { mnemonic = Request.Params["Nemotecnico"].ToString() };
                            string strTipo = Request.Params["TipoNegocio"].ToString();
                            bidOfferNew.BussinessType = (strTipo == "C") ? TransactionType.Buy : TransactionType.Sell;
                            bidOfferNew.Price = Convert.ToDouble(Request.Params["Precio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            if (Request.Params["Size"] != null)
                                bidOfferNew.Quantity = Convert.ToInt64(Request.Params["Size"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            if (Request.Params["PosPuntaSimple"] != null)
                                bidOfferNew.PosPuntaSimple = Convert.ToInt64(Request.Params["PosPuntaSimple"].ToString());

                            ExternalTickerNotifier.BroadCastNewBidsOffers(bidOfferNew);*/
                            Response.Write("OK");
                            break;

                        case "ORDERMATCH":
                            /*Order orderMatch = new Order();
                            orderMatch.Id = Convert.ToInt32(Request.Params["IdOrden"].ToString());
                            orderMatch.RegistrationDate = DateTime.ParseExact(Request.Params["FechaHora"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            orderMatch.Instrument = new Instrument { mnemonic = Request.Params["Nemotecnico"].ToString() };
                            string strTipoNegocioOrden = Request.Params["TipoNegocio"].ToString();
                            orderMatch.BussinessType = (strTipoNegocioOrden == "C") ? TransactionType.Buy : TransactionType.Sell;
                            orderMatch.Quantity = Convert.ToInt64(Request.Params["Cantidadconfirmada"].ToString());
                            orderMatch.Value = Convert.ToDouble(Request.Params["Precio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            orderMatch.Comission = Convert.ToDouble(Request.Params["Comision"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            double iva = Convert.ToDouble(Request.Params["PorIva"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            orderMatch.IVA = (iva * orderMatch.Comission) / 100; // Convert.ToDouble(Request.Params["PorIva"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            orderMatch.OrdeType = new OrderType() { Id = Convert.ToChar(Request.Params["TipoOrden"].ToString()) , Description = Request.Params["TipoOrden"].ToString() };

                            List<PortfolioAccount> ListCuentaTitulos = new List<PortfolioAccount>();
                            ListCuentaTitulos.Add(new PortfolioAccount() { AccountNumber = Convert.ToInt32(Request.Params["Deceval"].ToString()) });

                            orderMatch.Client = new Client()
                            {
                                IdentificationNumber = Request.Params["NumeroDocumento"].ToString(),
                                DocumentType = new DocumentType() { Description = Request.Params["TipoDocumento"].ToString() },
                                CuentaTitulos = ListCuentaTitulos,
                                Name = Request.Params["Cliente"].ToString(),
                                Id = Request.Params["IdUsuario"].ToString(),

                            };

                            //id de fix en caso de que venga

                            if (Request.Params["idseeoms"] != null && !Request.Params["idseeoms"].ToString().Equals("0"))
                                orderMatch.OrigID = Request.Params["idseeoms"].ToString();
                            orderMatch.ConfirmedQuantity = Convert.ToInt32(Request.Params["Cantidadconfirmada"].ToString());
                            orderMatch.TotalQuantity = Convert.ToInt64(Request.Params["Cantidadtotal"].ToString());
                            //Folio -- 
                            //IdUsuarioComercial -- Para notifcarla al comercial
                            //Adjudicacion -- Parcial

                            String strGroup = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyOrderMatch(strGroup, orderMatch);

                            if (Request.Params["IdUsuarioComercial"] != null && !Request.Params["IdUsuarioComercial"].ToString().Equals("0"))
                            {
                                string strGroupComercial = Request.Params["IdUsuarioComercial"].ToString();
                                ExternalTickerNotifier.NotifyOrderMatch(strGroupComercial, orderMatch);
                            }
                            ExternalTickerNotifier.BroadCastNotifyOrderMatch(orderMatch);*/
                            Response.Write("OK");


                            break;

                        case "ORDERCANCEL":

                            /*Order orderCancel = new Order();
                            orderCancel.Id = Convert.ToInt32(Request.Params["IdOrden"].ToString());
                            orderCancel.RegistrationDate = DateTime.ParseExact(Request.Params["FechaHora"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            orderCancel.Instrument = new Instrument { mnemonic = Request.Params["Nemotecnico"].ToString() };
                            string strTipoNeg = Request.Params["TipoNegocio"].ToString();
                            orderCancel.BussinessType = (strTipoNeg == "C") ? TransactionType.Buy : TransactionType.Sell;
                            orderCancel.Client = new Client() { Id = Request.Params["IdUsuario"].ToString(), };
                            orderCancel.OrdeType.Description = Request.Params["TipoOrden"].ToString();

                            if (Request.Params["idseeoms"] != null && !Request.Params["idseeoms"].ToString().Equals("0"))
                                orderCancel.OrigID = Request.Params["idseeoms"].ToString();
                            orderCancel.ConfirmedQuantity = Convert.ToInt32(Request.Params["Cantidadconfirmada"].ToString());
                            orderCancel.TotalQuantity =  (Convert.ToInt64(Request.Params["Cantidadtotal"].ToString()) - orderCancel.ConfirmedQuantity);

                            if (Request.Params["Valor"] != null)
                                orderCancel.Value = Convert.ToDouble(Request.Params["Valor"].ToString());

                            orderCancel.ErrorService = new Infrastructure.Models.Error { Description = Request.Params["Motivorechazo"].ToString() };
                            //IdUsuarioComercial -- para notificarle al comercial 

                            String strGroupCancel = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyOrderCancel(strGroupCancel, orderCancel);
                            ExternalTickerNotifier.BroadCastNotifyOrderCancel(orderCancel);

                            if (Request.Params["IdUsuarioComercial"] != null && !Request.Params["IdUsuarioComercial"].ToString().Equals("0"))
                            {
                                string strGroupComercial = Request.Params["IdUsuarioComercial"].ToString();
                                ExternalTickerNotifier.NotifyOrderCancel(strGroupComercial, orderCancel);
                            }
                            */
                            Response.Write("OK");
                            break;

                        case "NEWS":
                            /*News news = new News();
                            news.Id = Convert.ToInt64(Request.Params["Consecutivo"].ToString());
                            news.Date = DateTime.ParseExact(Request.Params["Fecha"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            news.Title = Request.Params["Titular"].ToString();
                            if (Request.Params["Fuente"] != null)
                            {
                                news.Source = Request.Params["Fuente"].ToString();
                            }
                            else
                            { 
                                news.Source = "";
                            }

                            news.Description = Request.Params["Descripcion"].ToString();

                            ExternalTickerNotifier.NotifyNews(news);*/
                            Response.Write("OK");
                            break;

                        case "ALARM":

                            /*Alarm alarm = new Alarm();
                            Order orderAlarm = new Order();
                            alarm.Error = new Error() { existError = false };
                            alarm.Id = Convert.ToInt32(Request.Params["IdOrdenAlarma"].ToString());

                            string strTipoN = Request.Params["TipoNegocio"].ToString();
                            orderAlarm.BussinessType = (strTipoN == "C") ? TransactionType.Buy : TransactionType.Sell;
                            orderAlarm.OrdeType = new OrderType() { Id = Convert.ToChar(Request.Params["TipoOrden"].ToString()) };
                            orderAlarm.Instrument = new Instrument { mnemonic = Request.Params["Nemotecnico"].ToString() };
                            orderAlarm.Quantity = Convert.ToInt64(Request.Params["Cantidad"].ToString());
                            orderAlarm.Value = Convert.ToDouble(Request.Params["Precio"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            orderAlarm.Comission = Convert.ToDouble(Request.Params["Comision"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            List<PortfolioAccount> ListCuenta = new List<PortfolioAccount>();
                            ListCuenta.Add(new PortfolioAccount() { AccountNumber = Convert.ToInt32(Request.Params["CuentaDeceval"].ToString()) });

                            orderAlarm.Client = new Client()
                            {
                                CuentaTitulos = ListCuenta,
                                Id = Request.Params["IdCliente"].ToString(),
                            };

                            if (!string.IsNullOrEmpty(Request.Params["Vigencia"]))
                            orderAlarm.EffectiveDate = DateTime.ParseExact(Request.Params["Vigencia"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                            alarm.Order = orderAlarm;

                            String strGroupAlarm = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyAlarm(strGroupAlarm, alarm);*/
                            Response.Write("OK");
                            break;

                        case "ALARMERROR":

                            /*Alarm objAlarm = new Alarm();
                            objAlarm.Id = Convert.ToInt32(Request.Params["IdOrdenAlarma"].ToString());
                            objAlarm.Error = new Error() { Code = 0, Description = Request.Params["Mensaje"].ToString(), existError = true };
                            String GroupAlarm = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyAlarm(GroupAlarm, objAlarm);
                            Response.Write("OK");*/
                            break;

                        case "PXIN":
                            var objResponse = new Object[] { Request.Params["Nemotecnico"] ,
                                Convert.ToDouble(value: Request.Params["PrecioIndicativo"], provider: System.Globalization.CultureInfo.InvariantCulture)  };
                            ExternalTickerNotifier.BroadCastTargetPrice(objResponse);

                            var mnemonic = Request.Params["Nemotecnico"] ;
                            var precIndicativo = Convert.ToDouble(Request.Params["PrecioIndicativo"]?.ToString());
                            var cantIndicativa = Convert.ToDouble(Request.Params["CantidadIndicativa"]?.ToString());
                            var activePrice = (Request.Params["Sesion"] != null && Request.Params["Sesion"].ToUpper().Equals("VOLATILITY AUCTION"));

                            /*var objAuction = new Auction
                            {
                                Mnemonic = mnemonic,
                                TargetPrice = precIndicativo,
                                ActivePrice = activePrice,
                                IndicativeQuantity = cantIndicativa
                            };
                          
                            
                            ExternalTickerNotifier.NotifyAuction(objAuction); */
                             Response.Write("OK");
                            break;
                        case "DOLLAR":
                            /*DollarBidOffer dollar = new DollarBidOffer();
                            ExternalTickerNotifier.NotifyDollar(dollar); */
                             Response.Write("OK");
                            break;

                        case "SUB":

                            Object[] objRes = new Object[] { Request.Params["Nemotecnico"].ToString(), Request.Params["Accion"].ToString() };
                            /*Auction objAuctionAction = new Auction
                            {
                                Mnemonic = Request.Params["Nemotecnico"].ToString(),
                                Action = Request.Params["Accion"].ToString(),

                            };

                            if (Request.Params["Sesion"] != null)
                            {
                                if (Request.Params["Sesion"].ToUpper().Equals("VOLATILITY AUCTION"))
                                    objAuctionAction.ActivePrice = true;
                                else
                                    objAuctionAction.ActivePrice = false;
                            }


                            ExternalTickerNotifier.NotifyAuction(objAuctionAction);
                            ExternalTickerNotifier.BroadCastAuction(objRes); */
                             Response.Write("OK");
                            break;

                        case "IND":
                            /*Indicators objIndicator = new Indicators
                            {
                                Date = DateTime.ParseExact(Request.Params["FechaHora"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                                Value = double.Parse(Request.Params["Valor"].ToString()),
                                PercentageVariation = float.Parse(Request.Params["Variacion"].ToString(), System.Globalization.CultureInfo.InvariantCulture),
                                IndicatorType = Request.Params["Indice"].ToString()
                            };
                            ExternalTickerNotifier.NotifyIndicator(objIndicator); */
                             Response.Write("OK");
                            break;

                        case "BLOCKUSER":
                            String strUser = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyBlockedUser(strUser);
                            Response.Write("OK");
                            break;

                        case "UNBLOCKUSER":
                            String strUserUnBlock = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyUnBlockedUser(strUserUnBlock);
                            Response.Write("OK");
                            break;

                        case "CHANGESEGMENT":
                            String strUserSegment = Request.Params["IdUsuario"].ToString();
                            Object[] objSegment = new Object[] { Request.Params["idCliente"].ToString(), Request.Params["Segmento"].ToString(), Request.Params["Type"].ToString() };

                            ExternalTickerNotifier.NotifyChangeSegment(objSegment, strUserSegment);
                            Response.Write("OK");
                            break;

                        case "MESSAGEUSERS":
                            String strMessage = Request.Params["strMensaje"].ToString();

                            //Esta parte del codigo recibe las notificaciones desde la plataforma antigua que solo envia el String
                            if (Request.Params["strType"] == null)
                            {
                                ExternalTickerNotifier.NotifyMessage(strMessage);
                                return;
                            }

                            //Esta parte del codigo recibe las notificaciones desde el administrador HTML5
                            /*var typeMsg = (MessageUser.MessageUserType)int.Parse(Request.Params["strType"]);
                            var msgObj = new MessageUser() { Users = new List<string>(), Type = typeMsg  , Message= strMessage };
                            ExternalTickerNotifier.NotifyMessageUser(msgObj); */
                             Response.Write("OK");
                            break;

                        case "MESSAGEUSER":

                            /*var message = Request.Params["strMensaje"];
                            var type = (MessageUser.MessageUserType)int.Parse(Request.Params["strType"]);
                            if (message == null) return;


                            var msg = new MessageUser() { Users = new List<string>()  , Type= type };

                            var i = 0;
                            for (i = 0; i < 100 && Request.Params["user" + i] != null; i++)
                                    msg.Users.Add(Request.Params["user" + i]);
                            

                            msg.Message = message;
                            ExternalTickerNotifier.NotifyMessageUser(msg); 
                             Response.Write("Message Send to "+i +" users");*/
                            break;

                        case "REPORT":
                            /*Report report = new Report();
                            report.Date = DateTime.ParseExact(Request.Params["fecha"].ToString(), "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            report.Description = Request.Params["descripcion"].ToString();
                            ExternalTickerNotifier.NotifyReports(report); */
                             Response.Write("OK");
                            break;

                        case "CHAT":
                            /*String strUserChat = Request.Params["IdUsuario"].ToString();
                            Object[] objChat = new Object[] { Request.Params["Enable"].ToString() };
                            ExternalTickerNotifier.NotifyBlockedChat(objChat, strUserChat); */
                             Response.Write("OK");
                            break;

                        case "PXREF":

                            /*Auction objAuctionRef = new Auction
                            {
                                Mnemonic = Request.Params["Nemotecnico"].ToString(),
                                TargetPrice = Convert.ToDouble(Request.Params["PrecioReferencia"].ToString(), System.Globalization.CultureInfo.InvariantCulture)
                            };
                            ExternalTickerNotifier.BroadCastReferencePrice(objAuctionRef); */

                             Response.Write("OK");
                            break;

                        case "LIMITEINFERIOR":

                            /*Auction objAuctionLimitInferior = new Auction
                            {
                                Mnemonic = Request.Params["Nemotecnico"].ToString(),
                                TargetPrice = Convert.ToDouble(Request.Params["LimiteInferior"].ToString(), System.Globalization.CultureInfo.InvariantCulture)
                            };
                            ExternalTickerNotifier.BroadCastMinLimit(objAuctionLimitInferior);
                            */
                            Response.Write("OK");
                            break;

                        case "LIMITESUPERIOR":

                            /*Auction objAuctionLimitSuperior = new Auction
                            {
                                Mnemonic = Request.Params["Nemotecnico"].ToString(),
                                TargetPrice = Convert.ToDouble(Request.Params["LimiteSuperior"].ToString(), System.Globalization.CultureInfo.InvariantCulture)
                            };

                            ExternalTickerNotifier.BroadCastMaxLimit(objAuctionLimitSuperior); */
                             Response.Write("OK");
                            break;

                        case "UPDATEFOLIO":

                            /*Order orderUpdate = new Order();
                            orderUpdate.Id = Convert.ToInt32(Request.Params["IdOrden"].ToString());
                            orderUpdate.Client = new Client() { Id = Request.Params["IdUsuario"].ToString(), };

                            String strGroupUpdate = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyUpdateOrder(strGroupUpdate, orderUpdate);

                            if (Request.Params["IdUsuarioComercial"] != null && !Request.Params["IdUsuarioComercial"].ToString().Equals("0"))
                            {
                                string strGroupUpdateComercial = Request.Params["IdUsuarioComercial"].ToString();
                                ExternalTickerNotifier.NotifyUpdateOrder(strGroupUpdateComercial, orderUpdate);
                            }
                            */
                            Response.Write("OK");
                            break;

                        case "UPDATEINFO":
                            String strGroupInfo = Request.Params["IdUsuario"].ToString();
                            String strClient = Request.Params["IdCliente"].ToString();
                            //ExternalTickerNotifier.NotifyUpdateInfo(strGroupInfo, strClient);
                            Response.Write("OK");
                            break;
                        case "REPLACE":

                            /*Order orderReplace = new Order();
                            orderReplace.Id = Convert.ToInt32(Request.Params["Id"].ToString());
                            orderReplace.OrdeType = new OrderType() { Id = Convert.ToChar(Request.Params["TipoOrden"].ToString()) };
                            orderReplace.Instrument = new Instrument { mnemonic = Request.Params["Nemotecnico"].ToString() };
                            orderReplace.Quantity = Convert.ToInt64(Request.Params["Cantidad"].ToString());
                            orderReplace.Value = Convert.ToDouble(Request.Params["PrecioOrden"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            orderReplace.Mensaje = Request.Params["MensajeBolsa"].ToString();

                            String strGroupReplace = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyReplaceOrder(strGroupReplace, orderReplace);

                            if (Request.Params["IdUsuarioComercial"] != null && !Request.Params["IdUsuarioComercial"].ToString().Equals("0"))
                            {
                                string strGroupUpdateComercial = Request.Params["IdUsuarioComercial"].ToString();
                                ExternalTickerNotifier.NotifyReplaceOrder(strGroupUpdateComercial, orderReplace);
                            }
                            */
                            Response.Write("OK");
                            break;
                        case "COMPLEMENTADA":
                            /*
                            Order orderComplementada = new Order();
                            orderComplementada.Id = Convert.ToInt32(Request.Params["Id"].ToString());
                            orderComplementada.Mensaje = Request.Params["MensajeBolsa"].ToString();

                            String strGrouporderComplementada = Request.Params["IdUsuario"].ToString();
                            ExternalTickerNotifier.NotifyComplementadaOrder(strGrouporderComplementada, orderComplementada);

                            if (Request.Params["IdUsuarioComercial"] != null && !Request.Params["IdUsuarioComercial"].ToString().Equals("0"))
                            {
                                string strGroupUpdateComercial = Request.Params["IdUsuarioComercial"].ToString();
                                ExternalTickerNotifier.NotifyComplementadaOrder(strGroupUpdateComercial, orderComplementada);
                            }
                            */
                            Response.Write("OK");
                            break;
                        case "CREATEORDERALARM":
                            /*string stridOrdenAlarma = Request.Params["idOrdenAlarma"].ToString();

                            Controllers.IntegradorCorredoresController objIntegradorCorredores = new Controllers.IntegradorCorredoresController();
                            objIntegradorCorredores.CreateOrderAlarm(stridOrdenAlarma);
                            */
                            Response.Write("OK");
                            break;
                        case "LOGOUTALL":
                            //ExternalTickerNotifier.NotifyLogoutAll();
                           
                            break;
                        case "SENDMAIL":
                            String Usermailaddressee = Request.Params["Usermailaddressee"].ToString();
                            String Subjectmail = Request.Params["Subjectmail"].ToString();
                            String TitleMail = Request.Params["TitleMail"].ToString();
                            String BodyMail = Request.Params["BodyMail"].ToString();


                            string MailSenderNotification = Properties.Settings.Default.MailSenderNotification;
                            string PasswordMailSenderNotification = Properties.Settings.Default.PasswordMailSenderNotification;
                            //Business.Utils.NotificationData.SendMail(Subjectmail, Usermailaddressee, MailSenderNotification, TitleMail, PasswordMailSenderNotification, BodyMail);
                            Response.Write("OK");
                            break;
                        case "UPDATEFOLIOCOEASY":
                            string documento = Request.Params["documento"].ToString();

                            //ExternalTickerNotifier.NotifyUdateFolioCoeasy(documento);
                            Response.Write("OK");
                            break;
                    }
                }
            }
            catch (Exception ex)
            { // TODO manejo de la exception
                System.Diagnostics.Trace.WriteLine(string.Format("COMPANYNAME Services Auditoria: {0} , NameSpace: {1}, Clase: {2}, Metodo: {3} ", ex.Message, MethodBase.GetCurrentMethod().DeclaringType.Namespace, MethodBase.GetCurrentMethod().DeclaringType.Name, MethodBase.GetCurrentMethod().Name));
                Response.Write(ex.ToString());

            }
            finally
            {
                Response.End();
            }

        }
    }
}