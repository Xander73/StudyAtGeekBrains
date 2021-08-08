using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MetricsAgent.DAL;
using System;
using MetricsAgent.Requests;

namespace MetricsAgent.Tests
{
    public class HddMetricsControllerTests
    {
        private HddMetricsController controller;
        private Mock<ILogger<HddMetricsController>> mockLogger;
        private Mock<IHddMetricsRepository> mockRepository;

        public HddMetricsControllerTests()
        {
            mockLogger = new Mock<ILogger<HddMetricsController>>();
            mockRepository = new Mock<IHddMetricsRepository>();
            controller = new HddMetricsController(mockLogger.Object, mockRepository.Object);
        }


        [Fact]
        public void Create_OkReturned()
        {
            var request = new HddMetricCreateRequest();

            var result = controller.Create(request);


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetErrorsCount_OkReturned()
        {
            var result = controller.GetLeftMemoryMegabyte();


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
