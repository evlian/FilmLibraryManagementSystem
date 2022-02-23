using MediatR;
using System.Text.Json.Serialization;

namespace FilmLibraryManagementSystem.Model.General.Queries
{
    public class GetFilmByIdQuery : IRequest<GetFilmByIdResult>
    {

        public int Id { get; set; }
    }
}
