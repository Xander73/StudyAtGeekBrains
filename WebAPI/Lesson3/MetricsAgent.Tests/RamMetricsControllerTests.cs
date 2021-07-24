using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MetricsAgent.DAL;

namespace MetricsAgent.Tests
{
    public class RamMetricsControllerTests
    {
        private RamMetricsController controller;
        private Mock<ILogger<RamMetricsController>> mockLogger;
        private Mock<RamMetricsRepository> mockRepository;

        public RamMetricsControllerTests()
        {
            mockLogger = new Mock<ILogger<RamMetricsController>>();
            mockRepository = new Mock<RamMetricsRepository>();
            controller = new RamMetricsController(mockLogger.Object, mockRepository.Object);
        }

        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var result = controller.GetRamAvailable();


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
