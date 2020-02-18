using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Application.Enterprise.CommonObjects;

namespace Application.Enterprise.Services.RealTime
{

    public class RealTimeTicker
    {
        private readonly static Lazy<RealTimeTicker> _instance = new Lazy<RealTimeTicker>(() => new RealTimeTicker());
        private Timer _timer;
       // private readonly Lazy<IHubConnectionContext> _clientsInstance = new Lazy<IHubConnectionContext>(() => GlobalHost.ConnectionManager.GetHubContext<RealTimeHub>().Clients);
        private readonly ConcurrentDictionary<string, Transaction> _transactions = new ConcurrentDictionary<string, Transaction>();
        
        private readonly double _rangePercent = 2;
        private readonly int _updateInterval = 200; //ms
        private bool _updatingStockPrices = false;
        private readonly object _updateStockPricesLock = new object();
        private readonly object _simulationStateLock = new object();
        private readonly Random _updateOrNotRandom = new Random();
        private SimulationState _simulationState = SimulationState.stoped;

        private RealTimeTicker()
        {
        }

        //private IHubConnectionContext Clients
        //{
        //    get { return _clientsInstance.Value; }
        //}

        
        public static RealTimeTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }


        //Este metodo es solo para simular el envio de broadcast
        public void StartSimulation()
        {
            if (_simulationState == SimulationState.stoped)
            {
                lock (_simulationStateLock)
                {
                    _transactions.Clear();
                    /*new List<Transaction>  {
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "BCOLOMBIA"}},
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "ECOPETROL"}},
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "PFBCOLOM"}} ,                
                         new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "INVERARGOS"}},
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "NUTRESA"}},
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "BOGOTA"}},                 
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "BBVACOL"}},
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "PAZRIO"}},
                        new Transaction { Date= new DateTime(), Quantity =100, ClosingPrice=100, Variation=12, PurchasePrice=100, SalePrice =100, Instrument = new Instrument { mnemonic = "BIOMAX"}}                 
                    }.ForEach(transaction => _transactions.TryAdd("", transaction));

                    */
                    
                    _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
                    _simulationState = SimulationState.started;
                }
            }

        }

        public void StopSimulation()
        {
            if (_simulationState == SimulationState.stoped)
            {
                lock (_simulationStateLock)
                {

                    if (_timer != null)
                    {
                        _timer.Dispose();
                    }
                    _simulationState = SimulationState.stoped;
                }
            }
        }


        private void UpdateStockPrices(object state)
        {

            if (_updatingStockPrices)
            {
                return;
            }

            lock (_updateStockPricesLock)
            {
                if (!_updatingStockPrices)
                {
                    _updatingStockPrices = true;

                    foreach (var transaction in _transactions.Values)
                    {
                        if (UpdateStockPrice(transaction))
                        {
                            BroadcastTransaction(transaction);
                        }
                    }

                   
                    _updatingStockPrices = false;
                }
            }

        }

        /*private bool UpdateStockPriceBids(BidsOffers transaction)
        {

            var r = _updateOrNotRandom.NextDouble();
            if (r > .1)
            {
                return false;
            }

            var random = new Random((int)Math.Floor(transaction.Price));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > .51;
            var change = Math.Round(transaction.Price * (double)percentChange, 2);
            change = pos ? change : -change;

            transaction.Price += change;
            return true;
        }*/

        private bool UpdateStockPrice(Transaction transaction)
        {

            var r = _updateOrNotRandom.NextDouble();
            if (r > .1)
            {
                return false;
            }

            var random = new Random((int)Math.Floor(transaction.Variation));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > .51;
            var change = Math.Round(transaction.Variation * (double)percentChange, 2);
            change = pos ? change : -change;

            transaction.Variation += change;
            return true;
        }

        private void BroadcastTransaction(Transaction transaction)
        {
          //  Clients.All.updateTransaction(transaction);
        }

       

    }

    public enum SimulationState
    {
        stoped,
        started
    }
}