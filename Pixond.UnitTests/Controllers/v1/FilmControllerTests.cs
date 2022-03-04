using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Pixond.Controllers;
using Pixond.Model.General.Queries.Films.GetAllFilms;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pixond.UnitTests.Controllers.v1
{
    public class FilmControllerTests
    {
        private readonly Mock<ILogger<FilmController>> _logger;
        private readonly Mock<IMediator> _mockMediator;
        private readonly FilmController _filmController;

        public FilmControllerTests() 
        { 
            _logger = new Mock<ILogger<FilmController>>();
            _mockMediator = new Mock<IMediator>();
            _filmController = new FilmController(_logger.Object, _mockMediator.Object);
        }


        [Fact]
        public async Task GetAllFilms____() 
        {
            #region Arrange
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllFilmsQuery>(), new CancellationToken())).ReturnsAsync(new GetAllFilmsResult());
            #endregion

            #region Act
            var response = await _filmController.GetAllFilms();
            #endregion

            #region Assert
            response.AllFilms.Should().BeOfType<List<FilmModel>>();
            #endregion
        }
    }
}
