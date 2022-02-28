using MediatR;

namespace Pixond.Model.General.Queries
{
    public class GetFilmsByTitleQuery : IRequest<GetFilmsByTitleResult>
    {
        public string Title { get; set; }
    }
}
