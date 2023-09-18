using System.Globalization;
using Microsoft.Extensions.Hosting;
using Wasly.net;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHotstBuilder(args).Build().Run();
    }




    static IHostBuilder CreateHotstBuilder(String[] args) =>
       Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(WebBuilder =>
       {

           WebBuilder.UseStartup<Startup>();
       });

}