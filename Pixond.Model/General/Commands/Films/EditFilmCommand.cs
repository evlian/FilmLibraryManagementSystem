using Pixond.Model.General.Queries;
using MediatR;

namespace Pixond.Model.General.Commands.Films
{
    public class EditFilmCommand : IRequest<EditFilmResponse>
    {
        public int Id { get; set; }
        public FilmModel Film { get; set; }
    }
}
