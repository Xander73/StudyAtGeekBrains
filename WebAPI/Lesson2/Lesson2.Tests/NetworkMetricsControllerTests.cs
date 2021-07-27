using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Lesson2.Controllers;

namespace Lesson2.Tests
{
    public class NetworkMetricsControllerTests
    {
        private NetworkMetricsController controller;

        public NetworkMetricsControllerTests()
        {
            controller = new NetworkMetricsController();
        }


        [Fact]
        public void GetMetricFromAgent_OkReturned()
        {
            var agentId = 1;

            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);


            var result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllCluster_OkReturned()
        {
            var fromTime = TimeSpan.FromSeconds(0);

            var toTime = TimeSpan.FromSeconds(100);


            var result = controller.GetMetricsFromAllCluster (fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
