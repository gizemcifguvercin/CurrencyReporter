
using CurrencyEmailServiceCore.Service.Concrete;
using CurrencyEmailServiceCore.Service.Contract;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(CurrencyEmailServiceCore.Startup))]

namespace CurrencyEmailServiceCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseDefaultTypeSerializer()
                    .UseMemoryStorage());

            services.AddHangfireServer(); 
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<ICurrencyReporterService, CurrencyReporterService>();
        }

        public void Configure(
            IApplicationBuilder app,
            IRecurringJobManager recurringJobManager,
            ICurrencyReporterService currencyReporterService)
        {
            app.UseRouting();

            app.UseWelcomePage("/");
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            recurringJobManager.AddOrUpdate("CurrencyReporter", () => currencyReporterService.CurrencyReporter(), Cron.Daily);
        }
    }
}

