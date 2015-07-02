using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using WebApi.API;

namespace WebApi.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = "http://+:9000/";
            Console.WriteLine("Started listening on : "+baseAddress);
            using (WebApp.Start<Startup>(baseAddress))
            {
                var client = new HttpClient();

                var response = client.GetAsync("http://localhost:9000/" + "api/mails/").Result;

                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }

            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
