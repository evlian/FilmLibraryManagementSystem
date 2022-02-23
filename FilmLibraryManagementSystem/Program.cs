using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using FilmLibraryManagementSystem.Data;

namespace FilmLibraryManagementSystem
{
    public class Program
    {
        private static FilmLibraryContext _context = new FilmLibraryContext();
        public static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
    }
}
