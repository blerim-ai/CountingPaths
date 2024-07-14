using CountingPathsApi.Controllers;
using CountingPathsApi.Models;
using CountingPathsApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CountingPathsApi.Tests
{
    [TestFixture]
    public class CountingPathControllerTest
    {
        private Mock<IMediator> _mediatorMock;
        private CountingPathsController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CountingPathsController(_mediatorMock.Object);
        }

        [Test]
        public async Task GetPaths_ValidInput_ReturnsOk()
        {
            // Arrange
            var request = new CalculatePathsRequest { X = 2, Y = 2 };
            var response = new CalculatePathsResponse(); 

            _mediatorMock.Setup(m => m.Send(request, CancellationToken.None)).ReturnsAsync(response);

            // Act
            var result = await _controller.CalculatePaths(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetPaths_InvalidInput_NegativeX_ReturnsBadRequest()
        {
            // Arrange
            var request = new CalculatePathsRequest { X = -1, Y = 5 };

            // Act
            var result = await _controller.CalculatePaths(request);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }

        [Test]
        public async Task GetPaths_InvalidInput_NegativeY_ReturnsBadRequest()
        {
            // Arrange
            var request = new CalculatePathsRequest { X = 5, Y = -1 };

            // Act
            var result = await _controller.CalculatePaths(request);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }

        [Test]
        public async Task GetPaths_InvalidInput_XGreaterThan1000_ReturnsBadRequest()
        {
            // Arrange
            var request = new CalculatePathsRequest { X = 1001, Y = 5 };

            // Act
            var result = await _controller.CalculatePaths(request);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }

        [Test]
        public async Task GetPaths_InvalidInput_YGreaterThan1000_ReturnsBadRequest()
        {
            // Arrange
            var request = new CalculatePathsRequest { X = 5, Y = 1001 };

            // Act
            var result = await _controller.CalculatePaths(request);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
    }
}
