using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ERS.HotWheels.Collectors.Infra.Data.Dapper
{
    public interface IDapperContext
    {
        IDbConnection ConnectionCreate();
        IDbConnection ConnectionCreate(string connectionString);
    }

    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection ConnectionCreate()
        {
            return new SqlConnection(_configuration.GetConnectionString("HTCollectors"));
        }

        public IDbConnection ConnectionCreate(string connectionString)
        {
            return new SqlConnection(_configuration.GetConnectionString(connectionString));
        }
    }
}
