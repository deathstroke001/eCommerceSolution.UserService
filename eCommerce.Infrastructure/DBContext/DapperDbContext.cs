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
            string ISLOCAL = _configuration.GetConnectionString("ISLOCAL") ?? throw new InvalidOperationException("Connection string 'PostgresConnection' not found.");
            string connectionString = ISLOCAL == "1" ? "Host=ecommerceusers.postgres.database.azure.com; Port=5432; Database=eCommerceUsers; Username=postgresadmin; Password=I@mthebest10"
                :  Environment.GetEnvironmentVariable("CONNECTIONSTRINGS_DEFAULTCONNECTION_USERS")!;
            dbConnection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => dbConnection;
    }
}
