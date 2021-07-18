using Lesson2.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult RegisterAgent ([FromBody] AgentInfo fgentInfo)
        {
            return Ok();
        }


        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById ([FromRoute] int agentId)
        {
            return Ok();
        }


        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById ([FromRoute] int agentId)
        {
            return Ok();
        }
    }
}
