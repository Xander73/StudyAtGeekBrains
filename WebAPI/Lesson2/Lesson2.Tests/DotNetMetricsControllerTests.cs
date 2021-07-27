using Xunit;
using Lesson2.Controllers;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Lesson2.Tests
{
    public class DotNetMetricsControllerTests
    {
        private DotNetMetricsController controller;

        public DotNetMetricsControllerTests ()
        {
            controller = new DotNetMetricsController();
        }


        [Fact]
        public void DotNetMetricsController_OkReturned()
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


            var result = controller.GetMetricsFromAllCluster(fromTime, toTime);


            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
