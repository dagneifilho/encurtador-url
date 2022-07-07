using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace App.Infra.Data.Dapper
{
    public class DefaultSqlConnectionFacotry : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DefaultSqlConnectionFacotry(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection()
        {
            return new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
