﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsInPercentile(TimeSpan fromTime, TimeSpan toTime, double percentile)
        {
            return Ok();
        }


        [HttpGet("from/{fromTime}/to/{toTime}/")]
        public IActionResult GetMetrics(TimeSpan fromTime, TimeSpan toTime)
        {
            return Ok();
        }
    }
}
