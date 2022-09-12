using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp_Bot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите город:");
                string city = Console.ReadLine();
                weather(city).Wait();
            }
            while (true);
        }
        static async Task weather(string city)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=a7bca1f3e4fedfca7dddc38ba3b77bf4";
            var response = (await client.GetAsync(url)).Content.ReadAsStringAsync();
            //Console.WriteLine(response.Result.ToString());
            JsonNode node = JsonNode.Parse(response.Result.ToString());
            try
            {
                Console.WriteLine($"Температура в городе {city}: {(float)node["main"]["temp"]} °C");
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Название города введено неверно!");
            }
        }
    }
}