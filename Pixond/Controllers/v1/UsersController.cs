using Pixond.Model.General.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pixond.App.Controllers.v1
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<RegisterUserResponse> RegisterUser([FromBody]RegisterUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("login")]
        public async Task<AuthenticateUserResponse> AuthenticateUser([FromBody]AuthenticateUserCommand command) 
        {
            return await Mediator.Send(command);
        }


    }
}
