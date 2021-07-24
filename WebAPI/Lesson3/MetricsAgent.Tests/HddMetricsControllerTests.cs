using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MetricsAgent.DAL;

namespace MetricsAgent.Tests
{
    public class HddMetricsControllerTests
    {
        private HddMetricsController controller;
        private Mock<ILogger<HddMetricsController>> mockLogger;
        private Mock<HddMetricsRepository> mockRepository;

        public HddMetricsControllerTests()
        {
            mockLogger = new Mock<ILogger<HddMetricsController>>();
            mockRepository = new Mock<HddMetricsRepository>();
            controller = new HddMetricsController(mockLogger.Object, mockRepository.Object);
        }


        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var result = controller.GetLeftMemoryMegabyte();


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
