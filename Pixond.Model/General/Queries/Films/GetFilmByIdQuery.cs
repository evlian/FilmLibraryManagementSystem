using MediatR;
using System.Text.Json.Serialization;

namespace Pixond.Model.General.Queries
{
    public class GetFilmByIdQuery : IRequest<GetFilmByIdResult>
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
