using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ModelHostingServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(options =>
                    {
                        options.ListenAnyIP(5000); // Listen on port 5000 for any IP address
                    });
                });
    }
}
