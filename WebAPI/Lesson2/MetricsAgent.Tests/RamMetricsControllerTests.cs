using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Tests
{
    public class RamMetricsControllerTests
    {
        private RamMetricsController controller;

        public RamMetricsControllerTests()
        {
            controller = new RamMetricsController();
        }

        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var result = controller.GetRamAvailable();


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
