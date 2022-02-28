using MediatR;
using System.Text.Json.Serialization;

namespace FilmLibraryManagementSystem.Model.General.Commands.Users
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
