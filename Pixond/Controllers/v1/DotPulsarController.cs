using DotPulsar;
using DotPulsar.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pixond.Model.General.Queries.Films;
using Pixond.Model.General.Queries.Films.GetAllFilms;
using System.Text;
using System.Threading.Tasks;


namespace Pixond.App.Controllers.v1
{
    [Route("api/test")]
    [ApiController]
    public class DotPulsarController : BaseController
    {
        public DotPulsarController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] FilmModel film) 
        {
            var client = PulsarClient.Builder().Build();
            var producer = client.NewProducer().Topic("persistent://public/default/retrieve_metadata").Create();
            await producer.Send(Encoding.UTF8.GetBytes(film.Title));
            return Ok();
        }
    }
}
