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
    public class CpuMetricsControllerTests
    {

        private CpuMetricsController controller;
        private Mock<ILogger<CpuMetricsController>> mockLoger;
        private Mock<ICpuMetricsRepository> mockRepository;

        public CpuMetricsControllerTests()
        {
            mockLoger = new Mock<ILogger<CpuMetricsController>>();
            mockRepository = new Mock<ICpuMetricsRepository>();
            controller = new CpuMetricsController(mockLoger.Object, mockRepository.Object);
        }

        [Fact]
        public void GetMetricsInPercentile_OkReturned()
        {
            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);

            var percentile = 0.0;

            var result = controller.GetMetricsInPercentile(fromTime, toTime, percentile);


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void GetMetrics_OkReturned()
        {
            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);
                        
            var result = controller.GetMetrics(fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void Create_OkReturned()
        {
            var request = new CpuMetricCreateRequest();

            var result = controller.Create(request);


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
