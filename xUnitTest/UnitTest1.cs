using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace xUnitTest
{
    public class UnitTestGet
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            WebAPI.Services.People people = new WebAPI.Services.People();
            WebAPI.Controllers.ValuesController controller = new WebAPI.Controllers.ValuesController(people);

            // Act
            ActionResult<string> actionResult = controller.Get();


            // Assert
            Assert.NotEmpty(actionResult.Value);
        }
    }
}
