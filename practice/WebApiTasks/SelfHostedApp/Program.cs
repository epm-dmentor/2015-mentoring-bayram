using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;

namespace Epam.Sdesk.SelfHostedApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:9000");
            var assembly = Assembly.GetExecutingAssembly().Location;

            // The Assembly to load
            var path = assembly.Substring(0, assembly.LastIndexOf("\\")) + "\\Sdesk.Api.dll";
            config.Services.Replace(typeof(IAssembliesResolver), new CustomAssemblyResolver(path));
            config.Routes.MapHttpRoute("MailApi", "api/mails/{id}", new { controller = "MailsController", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute("JiraItems", "api/jiraitems/{id}", new { controller = "jiraitems" }
                );
            config.Routes.MapHttpRoute("Jiras", "api/{*jiraitems}", new { controller = "jiraitems", action = "GetAll" }
                );

            config.Routes.MapHttpRoute("AttachmentsByExtension", "api/mails/{id}/attachments/{attId}/{extension}/{status}", new { controller = "attachments" }
                );

            config.Routes.MapHttpRoute("AttachmentsByStatus", "api/mails/{id}/attachments/{attId}/{extension}", new { controller = "attachments" }
                );


            config.Routes.MapHttpRoute("AttachmentsByMailId", "api/mails/{id}/attachments", new { controller = "attachments" }
                );

            config.Routes.MapHttpRoute("AttachmentsByAttId", "api/mails/{id}/attachments/{attId}", new { controller = "attachments" }
                );

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
