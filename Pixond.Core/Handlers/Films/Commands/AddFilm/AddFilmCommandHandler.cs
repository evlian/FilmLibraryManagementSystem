using Pixond.Core.Services.Films;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pixond.Model.General.Commands.Films;
using DotPulsar;
using DotPulsar.Extensions;
using System.Text;
using Pixond.Model.General.Commands.Films.AddFilm;

namespace Pixond.Core.Handlers.Films.Commands.AddFilm
{
    public class AddFilmCommandHandler : IRequestHandler<AddFilmCommand, AddFilmResponse>
    {
        private readonly IFilmsService _filmsService;

        public AddFilmCommandHandler(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }
        public async Task<AddFilmResponse> Handle(AddFilmCommand request, CancellationToken cancellationToken)
        {
            //var pulsarClient = PulsarClient.Builder().Build();
            //var producer = pulsarClient.NewProducer().Topic("persistent://public/default/metadata_request").Create();
            //await producer.Send(Encoding.UTF8.GetBytes(request.Title));
            return new AddFilmResponse() { Film = await _filmsService.AddFilm(request, cancellationToken) };
        }
    }
}
