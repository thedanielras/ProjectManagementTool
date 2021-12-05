using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //   .SetBasePath(Directory.GetCurrentDirectory())
            //   .AddJsonFile("appsettings.json")
            //   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
            //   .Build();

            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //.Enrich.FromLogContext()
            //.WriteTo.Console()
            //.WriteTo.File("LOGS/log.txt", rollingInterval: RollingInterval.Day)
            //.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration.GetValue<String>("")))
            //{
            //    AutoRegisterTemplate = true,
            //    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
            //})
            //.CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();     
            }
            catch (Exception ex)            {
                Log.Fatal(ex, "Host terminated unexpectedly");               
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) => { 
                    configuration
                    .Enrich.WithMachineName()
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .WriteTo.Console()
                    .WriteTo.File("LOGS/log.txt", rollingInterval: RollingInterval.Day)        
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticSearch:Uri"]))
                    {
                        FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                       EmitEventFailureHandling.WriteToFailureSink |
                                       EmitEventFailureHandling.RaiseCallback,
                        IndexFormat = $"{context.Configuration["ApplicationName"]}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7
                    })
                    .ReadFrom.Configuration(context.Configuration);
                
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
