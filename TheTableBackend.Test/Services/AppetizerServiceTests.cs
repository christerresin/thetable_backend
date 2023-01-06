using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTableBackend.Dtos.Meal;
using TheTableBackend.Interfaces;
using TheTableBackend.Models;
using TheTableBackend.Repositories;
using TheTableBackend.Services.AppetizerService;

namespace TheTableBackend.Test.Services
{
    public class AppetizerServiceTests
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        private MealType mealType = MealType.Appetizer;
        private readonly AppetizerService _appetizerService;

        public AppetizerServiceTests()
        {
            _mealRepository = A.Fake<IMealRepository>();
            _mapper = A.Fake<IMapper>();

            // SUT
            _appetizerService = new AppetizerService(_mapper, _mealRepository);
        }

        [Fact]
        public virtual async void AppetizerService_GetAllAppetizers_ReturnOk()
        {
            // Arrange
            var appetizers = A.Fake<ServiceResponse<List<GetMealDto>>>();
            var appetizerList = A.Fake<List<GetMealDto>>();
            var dbAppetizerList = A.Fake<List<Meal>>();
            var appetizerDto = A.Fake<GetMealDto>();
            var appetizer = A.Fake<Meal>();
            A.CallTo(() => _mapper.Map<GetMealDto>(appetizer)).Returns(appetizerDto);
            A.CallTo(() => _mealRepository.GetAllMeals(mealType)).Returns(dbAppetizerList);

            // Act
            var result = await _appetizerService.GetAllAppetizers();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ServiceResponse<List<GetMealDto>>>();
        }

        [Fact]
        public virtual async void AppetizerService_GetAppetizerById_ReturnOk()
        {
            // Arrange
            var response = A.Fake<ServiceResponse<GetMealDto>>();
            var appetizerDto = A.Fake<GetMealDto>();
            var appetizer = A.Fake<Meal>();
            A.CallTo(() => _mapper.Map<GetMealDto>(appetizer)).Returns(appetizerDto);
            A.CallTo(() => _mealRepository.GetMealById(1)).Returns(appetizer);

            // Act
            var result = await _appetizerService.GetAppetizerById(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ServiceResponse<GetMealDto>>();

        }
    }
}
