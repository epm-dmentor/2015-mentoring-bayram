using System;
using System.Collections.Generic;
using Epam.NetMentoring.Adapter;


namespace Epam.NetMentoring.AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string> {"asdfas0", "sdsdfads", "sdfasdfa"};
            var printer = new Printer();
            var container = new Container(list);
            printer.Print(container);
            Console.ReadKey();
        }
    }
}
