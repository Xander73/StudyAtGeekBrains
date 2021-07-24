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


        public void Create(HddMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "INSERT INTO hddmetrics (time) VLUES (@time)";
            cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }


        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "DELETE FROM hddmetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }


        public void Update(HddMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"UPDATE hddmetrics SET time = {item.Time} WHERE id={item.Id}";

            cmd.ExecuteNonQuery();
        }


        public IList<HddMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM hddmetrics";

            var returnlist = new List<HddMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnlist.Add(new HddMetric
                    {
                        Id = reader.GetInt32(0),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(1))
                    });
                }
            }
            return returnlist;
        }


        public HddMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"SELECT * FROM hddmetrics WHERE id={id}";

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new HddMetric
                    {
                        Id = reader.GetInt32(0),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(1))
                    };
                }
                else
                {
                    return null;
                }
            }
        }


        public AllHddMetricsResponse GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"SELECT * FROM hddmetrics WHERE time BETWEEN {fromTime} AND {toTime}";

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                AllHddMetricsResponse response = new AllHddMetricsResponse();
                while (reader.Read())
                {
                    response.Metrics.Add(new HddMetricDto
                    {
                        Id = reader.GetInt32(0),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(1))
                    });
                }
                return response;
            }
        }
    }
}
