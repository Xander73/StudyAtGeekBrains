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


        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetErrorsCount(TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation($"Вызван метод DotNetMetricsController.GetErrorsCount с аргументами {fromTime} и {toTime}");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _repository.Create(new DotNetMetric
            {
                Time = request.Time
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


        /// <remarks>
        /// Метод ля создания и заполнения таблицы
        /// </remarks>
        [HttpGet("sql-read-write-test")]
        public IActionResult TryToInsertAndRead()
        {
            string connectionString = "DataSource=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DROP TABLE IF EXISTS dotnetmetrics";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE dotnetmetrics(id INTEGER PRIMARY KEY,
                    time INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO dotnetmetrics(time) VALUES(1)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO dotnetmetrics(time) VALUES(2)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO dotnetmetrics(time) VALUES(4)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO dotnetmetrics(time) VALUES(5)";
                    command.ExecuteNonQuery();

                    string readQuery = "SELECT * FROM dotnetmetrics LIMIT 3";

                    var returnArray = new DotNetMetric[3];
                    command.CommandText = readQuery;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new DotNetMetric
                            {
                                Id = reader.GetInt32(0), 
                                Time = TimeSpan.FromSeconds(reader.GetInt64(1))
                            };
                            counter++;
                        }
                    }
                    return Ok(returnArray);
                }
            }
        }
    }
}
