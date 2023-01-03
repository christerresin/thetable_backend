using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        //[Theory]
        //[InlineData(1, "Pikachu!")]
        //public void AppetizerController_pikaPika_ReturnString(int number, string expected)
        //{
        //    // Arrange
        //    var appetizerController = new AppetizerController();

        //    // Act
        //    var result = appetizerController.pikaPika(number);

        //    // Assert
        //    result.Should().Be(expected);
        //}
        //[Fact]
        //public void AppetizerController_Get_ReturnMeal()
        //{
        //    // Arrange
        //    var appetizerController = new AppetizerController();

        //    // Act
        //    var result = appetizerController.Get();

        //    // Assert
        //    result.Should().BeOfType<ActionResult<Meal>>();
        //}
    }
}
