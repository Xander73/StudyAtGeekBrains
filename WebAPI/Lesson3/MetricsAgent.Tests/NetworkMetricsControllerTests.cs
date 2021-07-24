using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MetricsAgent.DAL;

namespace MetricsAgent.Tests
{
    public class NetworkMetricsControllerTests
    {
        private NetworkMetricsController controller;
        private Mock<ILogger<NetworkMetricsController>> mockLogger;
        private Mock<NetworkMetricsRepository> mockRepository;

        public NetworkMetricsControllerTests()
        {
            mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            mockRepository = new Mock<NetworkMetricsRepository>();
            controller = new NetworkMetricsController(mockLogger.Object, mockRepository.Object);
        }


        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetrics(fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
