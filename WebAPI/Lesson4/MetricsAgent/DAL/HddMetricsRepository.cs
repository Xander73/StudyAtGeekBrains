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
    public interface IHddMetricsRepository : IRepository<HddMetric>
    {

    }


    public class HddMetricsRepository : IHddMetricsRepository
    {
        private const string ConnectionString = "DataSource=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public HddMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(HddMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO hddmetrics (time) VLUES (@time)",
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
                connection.Execute("DELETE FROM hddmetrics WHERE id=@id",
                    new { id = id });
            }
        }


        public void Update(HddMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE hddmetrics SET time = @time WHERE id=@id",
                    new
                    {
                        time = item.Time.TotalSeconds,
                        id = item.Id
                    });
            }
        }


        public IList<HddMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<HddMetric>("SELECT * from hddmetrics").ToList();
            }
        }


        public HddMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<HddMetric>("SELECT * FROM hddmetrics WHERE id=@id",
                    new { id = id });
            }
        }


        public IList<HddMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<HddMetric>("SELECT * FROM hddmetrics WHERE time BETWEEN @fromTime AND @toTime",
                    new
                    {
                        fromTime = fromTime,
                        toTime = toTime
                    }).ToList();
            }
        }
    }
}
