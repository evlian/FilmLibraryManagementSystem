using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FilmLibraryManagementSystem.App.Extensions.DependencyInjection
{
    public static class FluentValidationDependencyInjectionExtension
    {
        public static void AddFluentValidationExtension(this IServiceCollection services)
        {
            services.AddFluentValidation();
        }
    }
}
