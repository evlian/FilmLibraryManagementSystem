using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Pixond.App.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items.Add("isAuthorized", false);
            await _next(context);
        }
    }
}
