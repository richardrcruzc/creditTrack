using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CreditReport.Data;
using Microsoft.Extensions.Logging;
using CreditReport.Data.PersonalInformation;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;

namespace CreditReport
{
    public class Program
    {



        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    //var context = services.GetRequiredService<CreditReportContext>();
                    //DbInitializer.Initialize(context);
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    SeedData.Initialize(services, "Q!w2e3r4").Wait();

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex.Message, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
             .ConfigureAppConfiguration((hostContext, config) =>
             {
                 // delete all default configuration providers
                 config.Sources.Clear();
                 config.AddJsonFile("appsettings.json", optional: true);
               //  config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
             })
               .Build();

        //var host = new WebHostBuilder()
        //    .UseKestrel()
        //    .UseContentRoot(Directory.GetCurrentDirectory())
        //    .UseIISIntegration()
        //    .UseStartup<Startup>()
        //    .UseApplicationInsights()
        //    .Build();


        //using (var scope = host.Services.CreateScope())
        //{
        //    var services = scope.ServiceProvider;
        //    try
        //    {
        //        //var context = services.GetRequiredService<CreditReportContext>();
        //        //DbInitializer.Initialize(context);
        //        var context = services.GetRequiredService<ApplicationDbContext>();
        //        SeedData.Initialize(services, "Q!w2e3r4").Wait();

        //    }
        //    catch (Exception ex)
        //    {
        //        var logger = services.GetRequiredService<ILogger<Program>>();
        //        logger.LogError(ex.Message, "An error occurred while seeding the database.");
        //    }
        //}

        //host.Run();
        //}
    }
}
