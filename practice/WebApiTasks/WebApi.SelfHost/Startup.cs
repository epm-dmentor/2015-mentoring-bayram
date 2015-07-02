using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebApi.API;

[assembly: OwinStartup(typeof(WebApi.SelfHost.Startup))]

namespace WebApi.SelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config =new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
