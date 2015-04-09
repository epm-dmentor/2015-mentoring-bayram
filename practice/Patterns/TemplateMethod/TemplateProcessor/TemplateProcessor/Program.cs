using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.TemplateProcessor
{
    class Program
    {
        static Template FillFirstTemplate()
        {
            var bayram = new User { Id = 1, Name = "Bayram" };
            var igor = new User {Id = 2, Name = "Igor"};
            var users = new List<User> {bayram, igor};
            var templateOne = new Template();
            templateOne.Name = "First Template";
            templateOne.Users = users;
            return templateOne;
        }

        static void Main(string[] args)
        {
            var factory = new TemplateFactory();
            var processor = factory.CreateTemplate(1);
            processor.ProcessTemplate(FillFirstTemplate(),"Bayram");
            Console.ReadKey();

        }
    }
}
