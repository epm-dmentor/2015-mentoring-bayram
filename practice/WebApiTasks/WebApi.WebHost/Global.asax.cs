using System;
using System.Web;
using System.Web.Http;
using WebApi.API;

namespace WebApi.WebHost
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

       
    }
}