using Pixond.Core.Abstraction.Services.Users;
using Pixond.Model.Entitites;
using Pixond.Model.General.Commands.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Pixond.Core.Handlers.Users.Commands.RegisterUser
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
