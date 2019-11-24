using System;
using System.Diagnostics;
using ServiceStack.Text;

namespace SSI.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppHost().Init().Start("http://*:4558/");
            "ServiceStack Self Host with Razor listening at http://127.0.0.1:4558".Print();
            Process.Start("http://127.0.0.1:8088/");

            Console.ReadLine();
        }
    }
}
