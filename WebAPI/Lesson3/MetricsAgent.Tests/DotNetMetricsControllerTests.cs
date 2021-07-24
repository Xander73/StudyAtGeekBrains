using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MetricsAgent.DAL;

namespace MetricsAgent.Tests
{
    public class DotNetMetricsControllerTests
    {
        private DotNetMetricsController controller;
        private Mock<ILogger<DotNetMetricsController>> mockLogger;
        private Mock<DotNetMetricsRepository> mockRepository;

        public DotNetMetricsControllerTests()
        {
            mockLogger = new Mock<ILogger<DotNetMetricsController>>();
            mockRepository = new Mock<DotNetMetricsRepository>();
            controller = new DotNetMetricsController(mockLogger.Object, mockRepository.Object);
        }

        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetErrorsCount(fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
