using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TheTableBackend.Controllers;
using TheTableBackend.Dtos.Meal;
using TheTableBackend.Interfaces;
using TheTableBackend.Models;
using TheTableBackend.Services.AppetizerService;

namespace TheTableBackend.Test.Controllers
{
 
    public class AppetizerControllerTests
    {
        private readonly IAppetizerService _appetizerService;
        public AppetizerControllerTests()
        {
            _appetizerService = A.Fake<IAppetizerService>();
        }

        [Fact]
        public void AppetizerController_GetAllAppetizers_ReturnOk()
        {
            // Arrange
            var appetizers = A.Fake<ServiceResponse<List<GetMealDto>>>();
            A.CallTo(() => _appetizerService.GetAllAppetizers()).Returns(appetizers);
            var controller = new AppetizerController(_appetizerService);

            // Act
            var result = controller.GetAllAppetizers();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult<ServiceResponse<List<GetMealDto>>>>>();
        }

        [Fact]
        public void AppetizerController_GetAppetizerById_ReturnOk()
        {
            // Arrange
            var appetizer = A.Fake<ServiceResponse<GetMealDto>>();
            A.CallTo(() => _appetizerService.GetAppetizerById(1)).Returns(appetizer);
            var controller = new AppetizerController(_appetizerService);

            // Act
            var result = controller.GetAppetizerById(1);

            // Assert
            result.Should().NotBeNull();
        }
        
    }
}
