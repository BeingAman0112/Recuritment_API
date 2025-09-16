using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.infrastructure.Data
{
    public class DbContext 
    {
        private readonly IDbConnection _connection;

        public DbContext(IConfiguration configuration)
        {
            // Reads connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection Connection => _connection;

    }
}
