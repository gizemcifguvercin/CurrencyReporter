using CurrencyEmailService.Service;
using Hangfire;
using Hangfire.MemoryStorage; 
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CurrencyEmailService.Startup))]

namespace CurrencyEmailService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            app.UseWelcomePage("/");
 
            GlobalConfiguration.Configuration.UseColouredConsoleLogProvider().UseMemoryStorage();
            
            
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate("CurrencyReporter", () => new CurrencyReporterService().CurrencyReporter(), Cron.Daily);
        } 
        
    }
}
