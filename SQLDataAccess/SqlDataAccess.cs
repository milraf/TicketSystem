using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess
{
    public class SqlDataAccess
    {
        private readonly IConfiguration config;
        public string ConnectionString { get; set; } = "DefaultConnection";

        public SqlDataAccess(IConfiguration configuration)
        {
            config = configuration;
        }

        public async Task<List<T>> LoadData<T,U>(string sql, U parameters)
        {
            string connectionString = config.GetConnectionString(ConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = config.GetConnectionString(ConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

    }
}
