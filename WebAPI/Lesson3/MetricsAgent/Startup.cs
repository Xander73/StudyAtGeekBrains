using MetricsAgent.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSqlLiteConnection(services);
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetworkMetricsRepository, NetworkMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
        }


        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "Data Source=metrics.db;Version=3;Pooling=tru;Max Pool Size=100";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareScema(connection);
        }


        private void PrepareScema (SQLiteConnection connection)
        {
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
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
                        
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
