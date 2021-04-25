
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularASPNETCoreSeed.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Angular_ASPNET_Core_Seed
{
    public class Program
    {
        public static void Main(string[] args)
    {
      var host = CreateWebHostBuilder(args).Build();
      //2. Find the service layer within our scope.
      using (var scope = host.Services.CreateScope())
      {
        //3. Get the instance of BoardGamesDBContext in our services layer
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<CalculatorDBContext>();

        //4. Call the DataGenerator to create sample data
        SeedData.Initialize(services);
      }
      host.Run();
    }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}