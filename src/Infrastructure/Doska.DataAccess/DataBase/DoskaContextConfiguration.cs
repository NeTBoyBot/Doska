using Doska.DataAccess.EntityConfiguration.Configuraion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.DataAccess.DataBase
{
    public class DoskaContextConfiguration : IDbContextOptionsConfigurator<DoskaContext>
    {
        private const string PostgresConnectionStringName = "PostgresDoskaDb";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public DoskaContextConfiguration(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public void Configure(DbContextOptionsBuilder<DoskaContext> options)
        {
            string connectionString = _configuration.GetConnectionString(PostgresConnectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '(ConnectionStringName)'");
            }
            options.UseNpgsql(connectionString)
                .UseLoggerFactory(_loggerFactory); ;
        }
    }
}
