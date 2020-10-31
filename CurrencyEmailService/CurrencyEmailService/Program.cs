using System;
using System.IO; 
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using Microsoft.Owin.Hosting;

namespace CurrencyEmailService
{
    class Program
    {
        static void Main(string[] args)
        { 
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data"));
            LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());
            const string endpoint = "http://localhost:12345";
            
            using (WebApp.Start<Startup>(endpoint))
            {
                Console.WriteLine("{0} Hangfire Server started.", DateTime.Now);
                Console.WriteLine("{0} Dashboard is available at {1}/hangfire", DateTime.Now, endpoint);
                Console.WriteLine("{0} Press ENTER to exit...", DateTime.Now);
                while (Console.ReadLine() != String.Empty) { }
            }
        }
    }
}
