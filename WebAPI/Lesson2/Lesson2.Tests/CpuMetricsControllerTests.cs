using Lesson2.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Lesson2.Tests
{
    public class CpuMetricsControllerTests
    {
        private CPUMetricsController controller;


        public CpuMetricsControllerTests ()
        {
            controller = new CPUMetricsController();
        }


        [Fact]
        public void GetMetricsFromAgent_OkReturned()
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
