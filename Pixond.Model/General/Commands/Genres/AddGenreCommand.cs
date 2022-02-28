using MediatR;

namespace Pixond.Model.General.Commands.Genres
{
    public class AddGenreCommand : IRequest<AddGenreResponse>
    {
        public string Name { get; set; }
    }
}
