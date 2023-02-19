using FluentAssertions;
using MFex.Zoo.Api.Controllers;
using MFex.Zoo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFex.Zoo.UnitTests.Api
{
    public class ZooControllerTest
    {
        [Fact]
        public void ShouldGetSpends()
        {
            // Arrange
            var mockZooUseCase = new Mock<IZooUseCase>();
            mockZooUseCase.Setup(m => m.CalculSpends()).Returns(236.63m);
            var zooController = new ZooController(mockZooUseCase.Object);

            // Act
            var res = zooController.GetSpends();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(res);
            var model = Assert.IsAssignableFrom<OkObjectResult>(actionResult);
            model.Value.Should().Be(236.63m);
        }
    }
}
