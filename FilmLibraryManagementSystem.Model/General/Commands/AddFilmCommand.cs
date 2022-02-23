using MediatR;

namespace FilmLibraryManagementSystem.Model.General.Commands
{
    public class AddFilmCommand : IRequest<AddFilmResponse>
    {
        public Film Film { get; set; }
    }
}
