using FilmLibraryManagementSystem.Core.Abstraction.Services.Users;
using FilmLibraryManagementSystem.Model.Entitites;
using FilmLibraryManagementSystem.Model.General.Commands.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUsersService _service;

        public RegisterUserCommandHandler(IUsersService service) 
        { 
            _service = service;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User();
            user.Username = request.Username;
            user.Password = request.Password;
            user.Name = request.Name;
            await _service.RegisterUser(user);
            return new RegisterUserResponse();
        }
    }
}
