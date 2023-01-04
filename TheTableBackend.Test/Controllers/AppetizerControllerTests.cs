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
        private readonly AppetizerController _appetizerController;

        public AppetizerControllerTests()
        {
            _appetizerService = A.Fake<IAppetizerService>();

            // SUT
            _appetizerController = new AppetizerController(_appetizerService);
        }

        [Fact]
        // add "virtual async" from FakeItEasy to test async methods that otherwise returns a <Task>
        public virtual async void AppetizerController_GetAllAppetizers_ReturnOk()
        {
            // Arrange
            var appetizers = A.Fake<ServiceResponse<List<GetMealDto>>>();
            A.CallTo(() => _appetizerService.GetAllAppetizers()).Returns(appetizers);

            // Act
            var result = await _appetizerController.GetAllAppetizers();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<ServiceResponse<List<GetMealDto>>>>();
        }

        [Fact]
        // add "virtual async" from FakeItEasy to test async methods that otherwise returns a <Task>
        public virtual async void AppetizerController_GetAppetizerById_ReturnOk()
        {
            // Arrange
            var appetizer = A.Fake<ServiceResponse<GetMealDto>>();
            A.CallTo(() => _appetizerService.GetAppetizerById(1)).Returns(appetizer);

            // Act
            var result = await _appetizerController.GetAppetizerById(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<ServiceResponse<GetMealDto>>>();
        }

        [Fact]
        public virtual async void AppetizerController_AddNewAppetizer_ReturnOk()
        {
            // Arrange
            AddMealDto newAppetizerDto = A.Fake<AddMealDto>();
            var returnedAppetizer = A.Fake<ServiceResponse<GetMealDto>>();
            A.CallTo(() => _appetizerService.AddNewAppetizer(newAppetizerDto)).Returns(returnedAppetizer);

            // Act
            var result = await _appetizerController.AddNewAppetizer(newAppetizerDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<ServiceResponse<GetMealDto>>>();
        }

        [Fact]
        public virtual async void AppetizerController_UpdateAppetizer_ReturnOk()
        {
            // Arrange
            var updatedAppetizerDto = A.Fake<UpdateMealDto>();
            GetMealDto appetizer = new GetMealDto { Id = 1, Title = "Appetizer" };
            ServiceResponse<GetMealDto> response = new ServiceResponse<GetMealDto> { Data = appetizer };
            A.CallTo(() => _appetizerService.UpdateAppetizer(updatedAppetizerDto)).Returns(response);

            // Act
            var result = await _appetizerService.UpdateAppetizer(updatedAppetizerDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Title.Should().Be("Appetizer");
            result.Should().BeOfType<ServiceResponse<GetMealDto>>();
        }

        [Fact]
        public virtual async void AppetizerController_DeleteAppetizer_ReturnOk()
        {
            // Arrange
            GetMealDto deletedAppetizer = new GetMealDto { Id = 1, Title = "Stub Appetizer" };
            ServiceResponse<GetMealDto> response = new ServiceResponse<GetMealDto> { Data = deletedAppetizer };
            A.CallTo(() => _appetizerService.DeleteAppetizer(1)).Returns(response);

            // Act
            var result = await _appetizerService.DeleteAppetizer(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ServiceResponse<GetMealDto>>();
        }

    }
}
