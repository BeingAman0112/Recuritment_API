using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;

namespace Recruitment.Infrastructure.Data
{
    public class DbContext
    {
        private readonly IDbConnection _connection;

        public DbContext(IConfiguration configuration)
        {
            // Read connection string from appsettings.json or environment variable
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Initialize PostgreSQL connection
            _connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection Connection => _connection;
    }
}
