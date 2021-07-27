using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Lesson2.Controllers;
using Lesson2.Core;

namespace Lesson2.Tests
{
    public class AgentsControllerTests
    {
        private AgentsController controller;


        public AgentsControllerTests()
        {
            controller = new AgentsController();
        }

        [Fact]
        public void RegisterAgent_OkReturned()
        {
            var agentInfo = new AgentInfo();


            var result = controller.RegisterAgent(agentInfo);


            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void EnableAgentById_OkReturned()
        {
            var agentId = 1;

            var result = controller.EnableAgentById(agentId);

            Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void DisableAgentById()
        {
            var agentId = 1;

            var result = controller.DisableAgentById(agentId);

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
