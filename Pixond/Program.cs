using DotPulsar;
using DotPulsar.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace Pixond
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test();
            CreateHostBuilder(args).Build().Run();
        }

        public static async void Test() 
        {
            var client = PulsarClient.Builder().Build();
            var producer = client.NewProducer().Topic("persistent://public/default/mytopic").Create();
            await producer.Send(Encoding.UTF8.GetBytes("pulsartest001"));
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
