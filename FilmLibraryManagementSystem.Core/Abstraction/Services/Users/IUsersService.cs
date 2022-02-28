using FilmLibraryManagementSystem.Model.Entitites;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Abstraction.Services.Users
{
    public interface IUsersService
    {
        Task<User> RegisterUser(User user);
        Task<User> AuthenticateUser(User user);
    }
}
