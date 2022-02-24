using FilmLibraryManagementSystem.App.Extensions.DependencyInjection;
using FilmLibraryManagementSystem.Core.Services.Films;
using FilmLibraryManagementSystem.Data;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace FilmLibraryManagementSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmLibraryManagementSystem", Version = "v1" });
            });

            services.RegisterControllers();
            services.AddMediatRExtension();
            services.AddCommandHandlers();
            services.AddQueryHandlers();
            services.AddServices();
            services.AddMappingWithProfiles();
            services.AddDbContext<FilmLibraryContext>(builder => {
                if (!builder.IsConfigured)
                    builder.UseSqlServer("Data Source= (LocalDb)\\MSSQLLocalDB; Initial Catalog=FilmLibrary");
            
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmLibraryManagementSystem v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        
    }
}
