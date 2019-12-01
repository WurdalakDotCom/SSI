using System;
using System.Configuration;
using System.Diagnostics;
using ServiceStack.Text;

namespace SSI.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppHost().Init().Start($"http://{ConfigurationManager.AppSettings.Get("Host")}/");
            $"ServiceStack Self Host with Razor listening at {ConfigurationManager.AppSettings.Get("Host")}".Print();
            Console.ReadLine();
        }
    }
}
