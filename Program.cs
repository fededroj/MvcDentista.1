using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;



using MvcDentista.Models;

using System;


namespace MvcDentista

{

    public class Program

    {

        public static void Main(string[] args)

        {

            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())

            {

                var services = scope.ServiceProvider;


                try

                {

                    SeedData.Initialize(services);

                }

                catch (Exception ex)

                {

                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "Un error ocurrió poblando la DB");

                }

            }


            host.Run();


        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>

                {

                    webBuilder.UseStartup<Startup>();

                });

    }

}