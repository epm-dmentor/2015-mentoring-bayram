using System;
using System.ServiceModel;
using WeatherClient.WeatherService;

namespace WeatherClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var channelFactory = new ChannelFactory<WeatherSoap>("WeatherSoap"))
            {
                var channel = channelFactory.CreateChannel();
                var weather = channel.GetCityWeatherByZIP("23320");
                Console.WriteLine("Weather in Cheaspeak: {0} F", weather.Temperature);
                
            }
            Console.ReadLine();
        }
    }
}
