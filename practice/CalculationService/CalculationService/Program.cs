using System;

namespace Epam.NetMentoring.CalculationService
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcService = new CalculationService();
            
            //для того чтобы быстрее возвращал результат для нашего 
            //привиредливого клиента мы будем использовать CachedService ). Вроде по паттерну подходит.
            //к сожалению больше ничего не смог придумать для
            //Как наиболее оптимально сложить конструктор чтоб для нашего 
            //привередливого клиента (с корекцией) давать результат как можно быстрее?
            
            var correctionCalc = new CalculationServiceWithCorrection(10, new CachedCalculationService(calcService));
            var result = correctionCalc.Calculate(45, 45);
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
