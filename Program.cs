using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Barnama
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
                    webBuilder.UseStartup<Startup>().UseUrls("http://localhost:5001","http://192.168.1.103","https://192.168.1.103");
                });
               
    }
}
