using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Tests
{
    public class CpuMetricsControllerTests
    {

        private CpuMetricsController controller;

        public CpuMetricsControllerTests()
        {
            controller = new CpuMetricsController();
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
    }
}
