using Microsoft.AspNetCore.Http;

namespace FilmLibraryManagementSystem.App.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    }
}
