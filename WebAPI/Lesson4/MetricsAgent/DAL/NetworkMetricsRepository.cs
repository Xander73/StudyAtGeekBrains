using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Responses;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public interface INetworkMetricsRepository : IRepository<NetworkMetric>
    {

    }


    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private const string ConnectionString = "DataSource=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public NetworkMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(NetworkMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO networkmetrics (time) VLUES (@time)",
                    new
                    {
                        time = item.Time
                    });
            };
        }


        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM networkmetrics WHERE id=@id",
                    new { id = id });
            }
        }


        public void Update(NetworkMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE networkmetrics SET time = @time WHERE id=@id",
                    new
                    {
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }


        public IList<NetworkMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<NetworkMetric>("SELECT * from networkmetrics").ToList();
            }
        }


        public NetworkMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<NetworkMetric>("SELECT * FROM networkmetrics WHERE id=@id",
                    new { id = id });
            }
        }


        public IList<NetworkMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<NetworkMetric>("SELECT * FROM networkmetrics WHERE time BETWEEN @fromTime AND @toTime",
                    new
                    {
                        fromTime = fromTime,
                        toTime = toTime
                    }).ToList();
            }
        }

    }
}
