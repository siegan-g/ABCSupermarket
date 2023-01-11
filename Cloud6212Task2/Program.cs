using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud6212Task2.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Cloud6212Task2
{
    /// <summary>
    /// # Notes
    /// ## References
    /// * https://stackoverflow.com/questions/21839351/how-can-i-implement-a-theme-from-bootswatch-or-wrapbootstrap-in-an-mvc-5-project 
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {   
        //tutorial docs reccommends storing the build instance into a IHost variable
          var host =  CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host); //see region
            host.Run();
        }

        #region Create DB program run if not exists
        //reference https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0#initialize-db-with-test-data
        //the following lines will retrieve an instance of the db context through the DI container
        // call the Intialise method in the programs DBContext 
        //disposes the instance when the method is finished executing
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SupermarketContext>();
                    SupermarketIntialiser.Intialise(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
        #endregion

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
