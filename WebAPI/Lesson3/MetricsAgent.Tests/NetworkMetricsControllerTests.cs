using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MetricsAgent.DAL;
using MetricsAgent.Requests;

namespace MetricsAgent.Tests
{
    public class NetworkMetricsControllerTests
    {
        private NetworkMetricsController controller;
        private Mock<ILogger<NetworkMetricsController>> mockLogger;
        private Mock<INetworkMetricsRepository> mockRepository;

        public NetworkMetricsControllerTests()
        {
            mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            mockRepository = new Mock<INetworkMetricsRepository>();
            controller = new NetworkMetricsController(mockLogger.Object, mockRepository.Object);
        }


        [Fact]
        public void Create_OkReturned()
        {
            var request = new NetworkMetricCreateRequest();

            var result = controller.Create(request);


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetMetrics(fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetAll_OkReturned()
        {

            var result = controller.GetAll();


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetByTimePeriod_OkReturned()
        {
            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);

            var result = controller.GetByTimePeriod(fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void TryToInsertAndRead_OkReturned()
        {
            var result = controller.TryToInsertAndRead();


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
