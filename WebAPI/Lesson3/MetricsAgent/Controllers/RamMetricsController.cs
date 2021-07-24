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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private ILogger<RamMetricsController> _logger;
        private IRamMetricsRepository _repository;

        public RamMetricsController(ILogger<RamMetricsController> logger, IRamMetricsRepository repository)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в RamMetricsController");

            _repository = repository;
        }


        [HttpGet("available")]
        public IActionResult GetRamAvailable()
        {
            _logger.LogInformation($"Вызван метод RamMetricsController.GetRamAvailable без аргументов");
            return Ok();
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _repository.Create(new RamMetric
            {
                Time = request.Time
            });

            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto
                {
                    Time = metric.Time,
                    Id = metric.Id
                });
            }
            return Ok();
        }


        [HttpGet("period")]
        public IActionResult GetPeriod()
        {
            var metrics = _repository.GetAll();

            var response = new AllRamMetricsResponse()
            {
                Metrics = new List<RamMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(new RamMetricDto
                {
                    Time = metric.Time,
                    Id = metric.Id
                });
            }
            return Ok();
        }


        [HttpGet("sql-read-write-test")]
        public IActionResult TryToInsertAndRead()
        {
            string connectionString = "DataSource=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DROP TABLE IF EXISTS rammetrics";

                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE rammetrics(id INTEGER PRIMARY KEY,
                    time INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO rammetrics(time) VALUES(1)";
                    command.ExecuteNonQuery();         
                    command.CommandText = "INSERT INTO rammetrics(time) VALUES(2)";
                    command.ExecuteNonQuery();         
                    command.CommandText = "INSERT INTO rammetrics(time) VALUES(4)";
                    command.ExecuteNonQuery();         
                    command.CommandText = "INSERT INTO rammetrics(time) VALUES(5)";
                    command.ExecuteNonQuery();

                    string readQuery = "SELECT * FROM rammetrics LIMIT 3";

                    var returnArray = new RamMetric[3];
                    command.CommandText = readQuery;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new RamMetric
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
