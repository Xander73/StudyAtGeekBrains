using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private ILogger<DotNetMetricsController> _logger;
        private IDotNetMetricsRepository _repository;

        private IMapper _mapper;

        public DotNetMetricsController(
            ILogger<DotNetMetricsController> logger, 
            IDotNetMetricsRepository repository, 
            IMapper mapper)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в DotNetMetricsController");

            _repository = repository;

            _mapper = mapper;
        }


        [HttpGet("metricsController/from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorsCount([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Вызван метод DotNetMetricsController.GetErrorsCount с аргументами {fromTime} и {toTime}");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _repository.Create(new DotNetMetric
            {
                Time = request.Time,
                Value = request.Value
            });

            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
                }
            }
            return Ok(response);
        }


        [HttpGet("period")]
        public IActionResult GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            var metrics = _repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
                }
            }
            
            return Ok(response);
        }
    }
}
