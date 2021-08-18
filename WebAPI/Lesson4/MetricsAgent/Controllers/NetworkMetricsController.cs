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
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private ILogger<NetworkMetricsController> _logger;
        private INetworkMetricsRepository _repository;

        private IMapper _mapper;

        public NetworkMetricsController(
            ILogger<NetworkMetricsController> logger, 
            INetworkMetricsRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в NetworkMetricsController");

            _repository = repository;

            _mapper = mapper;
        }


        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics(TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation($"Вызван метод NetworkMetricsController.GetMetrics с аргументами {fromTime} и {toTime}");
            return Ok();
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] NetworkMetricCreateRequest request)
        {
            _repository.Create(new NetworkMetric
            {
                Time = request.Time
            });

            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new AllNetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<NetworkMetricDto>(metric));
                }
            }
            return Ok(response);
        }


        [HttpGet("period")]
        public IActionResult GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            var metrics = _repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllNetworkMetricsResponse()
            {
                Metrics = new List<NetworkMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<NetworkMetricDto>(metric));
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
                    command.CommandText = "DROP TABLE IF EXISTS networkmetrics";

                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE networkmetrics(id INTEGER PRIMARY KEY,
                    time INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO networkmetrics(time) VALUES(1)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO networkmetrics(time) VALUES(2)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO networkmetrics(time) VALUES(4)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO networkmetrics(time) VALUES(5)";
                    command.ExecuteNonQuery();

                    string readQuery = "SELECT * FROM networkmetrics LIMIT 3";

                    var returnArray = new NetworkMetric[3];
                    command.CommandText = readQuery;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new NetworkMetric
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
