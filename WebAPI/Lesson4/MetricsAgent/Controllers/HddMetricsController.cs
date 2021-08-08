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
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private ILogger<HddMetricsController> _logger;
        private IHddMetricsRepository _repository;
        private IMapper _mapper;

        public HddMetricsController(
            ILogger<HddMetricsController> logger, 
            IHddMetricsRepository repository,
            IMapper mapper)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в HddMetricsController");

            _repository = repository;

            _mapper = mapper;
        }


        [HttpGet("left")]
        public IActionResult GetLeftMemoryMegabyte()
        {
            _logger.LogInformation($"Вызван метод HddMetricsController.GetLeftMemoryMegabyte без аргументов");
            return Ok();
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _repository.Create(new HddMetric
            {
                Time = request.Time
            });

            return Ok();
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
                }
            }
            return Ok(response);
        }


        [HttpGet("period")]
        public IActionResult GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            var metrics = _repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
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
                    command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                    
                    command.ExecuteNonQuery();
                                        
                    command.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARY KEY,
                    time INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO hddmetrics(time) VALUES(1)";
                    command.ExecuteNonQuery();         
                    command.CommandText = "INSERT INTO hddmetrics(time) VALUES(2)";
                    command.ExecuteNonQuery();         
                    command.CommandText = "INSERT INTO hddmetrics(time) VALUES(4)";
                    command.ExecuteNonQuery();         
                    command.CommandText = "INSERT INTO hddmetrics(time) VALUES(5)";
                    command.ExecuteNonQuery();

                    string readQuery = "SELECT * FROM hddmetrics LIMIT 3";

                    var returnArray = new HddMetric[3];
                    command.CommandText = readQuery;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new HddMetric
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
