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
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private ILogger<CpuMetricsController> _logger;
        private ICpuMetricsRepository _repository;
        private IMapper _mapper;

        public CpuMetricsController(
            ILogger<CpuMetricsController> logger, 
            ICpuMetricsRepository repository, 
            IMapper mapper)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsController");

            _repository = repository;

            _mapper = mapper;
        }


        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsInPercentile(TimeSpan fromTime, TimeSpan toTime, double percentile)
        {
            _logger.LogInformation($"Вызван метод CpuMetricsController.GetMetricsInPercentile с аргументами {fromTime}, {toTime} и {percentile}");
            return Ok();
        }


        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetrics(TimeSpan fromTime, TimeSpan toTime)
        {
            _logger.LogInformation($"Вызван метод CpuMetricsController.GetMetrics с аргументами {fromTime} и {toTime}");
            return Ok();
        }
        

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _repository.Create(new CpuMetric
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

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
                }
            }
            
            return Ok(response);
        }


        [HttpGet("period")]
        public IActionResult GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            var metrics = _repository.GetByTimePeriod(fromTime, toTime);

            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            if (metrics != null)
            {
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
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
                    command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER PRIMARY KEY,
                    value INT, time INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(10,1)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(50,2)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(75,4)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time) VALUES(90,5)";
                    command.ExecuteNonQuery();

                    
                    string readQuery = "SELECT * FROM cpumetrics LIMIT 3";

                    var returnArray = new CpuMetric[3];
                    command.CommandText = readQuery;

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new CpuMetric
                            {
                                Id = reader.GetInt32(0), 
                                Value = reader.GetInt32(1), 
                                Time = TimeSpan.FromSeconds(reader.GetInt64(2))
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
