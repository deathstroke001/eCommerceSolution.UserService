using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.DBContext
{
    public class DapperDbContext
    {
        public readonly IConfiguration _configuration;
        public readonly IDbConnection dbConnection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = _configuration.GetConnectionString("PostgresConnection") ?? throw new InvalidOperationException("Connection string 'PostgresConnection' not found.");
            dbConnection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => dbConnection;
    }
}
