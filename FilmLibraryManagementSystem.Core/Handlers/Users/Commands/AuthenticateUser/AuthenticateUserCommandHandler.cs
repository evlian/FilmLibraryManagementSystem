using FilmLibraryManagementSystem.Core.Abstraction.Services.Users;
using FilmLibraryManagementSystem.Model.Entitites;
using FilmLibraryManagementSystem.Model.General.Commands.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Users.Commands.AuthenticateUser
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
