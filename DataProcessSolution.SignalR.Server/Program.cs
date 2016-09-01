using Microsoft.Owin.Hosting;
using System;

namespace DataProcessSolution.SignalR.Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://localhost:8080/";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"Server running at {url}");
                Console.ReadLine();
            }
        }
    }
}
