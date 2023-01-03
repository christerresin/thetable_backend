using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTableBackend.Controllers;

namespace TheTableBackend.Test.Controllers
{
 
    public class AppetizerControllerTests
    {
        [Theory]
        [InlineData(1, "Pikachu!")]
        public void AppetizerController_pikaPika_ReturnString(int number, string expected)
        {
            // Arrange
            var appetizerController = new AppetizerController();

            // Act
            var result = appetizerController.pikaPika(number);

            // Assert
            result.Should().Be(expected);
        }
    }
}
