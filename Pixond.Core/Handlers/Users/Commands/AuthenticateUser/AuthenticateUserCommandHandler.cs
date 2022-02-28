using Pixond.Core.Abstraction.Services.Users;
using Pixond.Model.Entitites;
using Pixond.Model.General.Commands.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Pixond.Core.Handlers.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResponse>
    {
        private readonly IUsersService _usersService;
        public AuthenticateUserCommandHandler(IUsersService service)
        {
            _usersService = service;
        }
        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            AuthenticateUserResponse response = new AuthenticateUserResponse();
            User user = new User() { Username = request.Username, Password = request.Password};
            var s = await _usersService.AuthenticateUser(user);
            response.Authenticated = s != null;
            return response;
        }
    }
}
