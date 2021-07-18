using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Tests
{
    public class HddMetricsControllerTests
    {
        private HddMetricsController controller;

        public HddMetricsControllerTests()
        {
            controller = new HddMetricsController();
        }


        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var result = controller.GetLeftMemoryMegabyte();


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
