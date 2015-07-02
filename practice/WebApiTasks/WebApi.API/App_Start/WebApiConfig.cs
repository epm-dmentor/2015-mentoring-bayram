using System.Web.Http;


namespace WebApi.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "MailApi",
                routeTemplate: "api/mails/{id}",
                defaults: new { controller = "mails", id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "JiraItems",
                routeTemplate: "api/jiraitems/{id}",
                defaults: new { controller = "jiraitems" }
                );
            config.Routes.MapHttpRoute(
                name: "Jiras",
                routeTemplate: "api/{*jiraitems}",
                defaults: new { controller = "jiraitems", action = "GetAll" }
                );

            config.Routes.MapHttpRoute(
                name: "AttachmentsByExtension",
                routeTemplate: "api/mails/{id}/attachments/{attId}/{extension}/{status}",
                defaults: new { controller = "attachments", }
                );

            config.Routes.MapHttpRoute(
                name: "AttachmentsByStatus",
                routeTemplate: "api/mails/{id}/attachments/{attId}/{extension}",
                defaults: new { controller = "attachments" }
                );


            config.Routes.MapHttpRoute(
                name: "AttachmentsByMailId",
                routeTemplate: "api/mails/{id}/attachments",
                defaults: new { controller = "attachments" }
                );

            config.Routes.MapHttpRoute(
                name: "AttachmentsByAttId",
                routeTemplate: "api/mails/{id}/attachments/{attId}",
                defaults: new { controller = "attachments" }
                );
            

        }
    }
}
