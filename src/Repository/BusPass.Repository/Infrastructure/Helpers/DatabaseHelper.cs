using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusPass.Repository.Infrastructure.Helpers
{
    public class DatabaseHelper: IDatabaseHelper
    {
        private readonly IConfiguration _configuration;

        public DatabaseHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection GetHangfireConnection()=> GetDbConnection("Hangfire");

        public DbConnection GetBusPassConnection() => GetDbConnection("BusPass");

        private DbConnection GetDbConnection(string database)
        {
            var connectionString = _configuration.GetConnectionString(database);

            return new SqlConnection(connectionString);
        }
    }
}
