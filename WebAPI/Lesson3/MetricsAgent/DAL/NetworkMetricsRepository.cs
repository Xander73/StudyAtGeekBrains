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


        public void Create(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "INSERT INTO networkmetrics (time) VLUES (@time)";
            cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }


        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "DELETE FROM networkmetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();
        }


        public void Update(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"UPDATE networkmetrics SET time = {item.Time} WHERE id={item.Id}";

            cmd.ExecuteNonQuery();
        }


        public IList<NetworkMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM networkmetrics";

            var returnlist = new List<NetworkMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnlist.Add(new NetworkMetric
                    {
                        Id = reader.GetInt32(0),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(1))
                    });
                }
            }
            return returnlist;
        }


        public NetworkMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"SELECT * FROM networkmetrics WHERE id={id}";

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new NetworkMetric
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


        public IList<NetworkMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = $"SELECT * FROM networkmetrics WHERE time BETWEEN {fromTime} AND {toTime}";

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                IList<NetworkMetric> response = new List<NetworkMetric>();
                while (reader.Read())
                {
                    response.Add(new NetworkMetric
                    {
                        Id = reader.GetInt32(0),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(1))
                    });
                }
                return response;
            }
        }

        IList<NetworkMetric> IRepository<NetworkMetric>.GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            throw new NotImplementedException();
        }
    }
}
