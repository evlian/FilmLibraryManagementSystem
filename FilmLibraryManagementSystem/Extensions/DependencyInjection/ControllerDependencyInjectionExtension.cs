﻿using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace FilmLibraryManagementSystem.App.Extensions.DependencyInjection
{
    public static class ControllerDependencyInjectionExtension
    {
        public static void RegisterControllers(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
                .ConfigureApiBehaviorOptions(opt => {
                    opt.SuppressModelStateInvalidFilter = true;
                }).AddFluentValidationExtension();
        }
    }
}