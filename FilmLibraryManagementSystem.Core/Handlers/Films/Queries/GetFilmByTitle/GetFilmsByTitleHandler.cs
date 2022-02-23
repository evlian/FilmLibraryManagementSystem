using FilmLibraryManagementSystem.Data;
using FilmLibraryManagementSystem.Model.General.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FilmLibraryManagementSystem.Core.Handlers.Films.Queries.GetFilmByTitle
{
    public class GetFilmsByTitleHandler : IRequestHandler<GetFilmsByTitleQuery, GetFilmsByTitleResult>
    {
        public Task<GetFilmsByTitleResult> Handle(GetFilmsByTitleQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
