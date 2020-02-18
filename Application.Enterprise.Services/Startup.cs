using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(Application.Enterprise.Services.Startup))]


namespace Application.Enterprise.Services
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.Configuration.DefaultMessageBufferSize = 500;
            app.MapSignalR();
            RealTime.DateTimeJobScheduler.Start();
        }

        
    }
}
