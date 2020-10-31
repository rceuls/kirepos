using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kirepos.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Kirepos.Configuration
{
    public static class DatabaseExtensionMethods
    {
        public static void AddDatabaseConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextPool<KireposDatabaseContext>(
                    dbContextOptions => dbContextOptions
                        .UseMySql(
                            // Replace with your connection string.
                            config["MARIADB_CONNECTIONSTRING"],
                            // Replace with your server version and type.
                            mySqlOptions => mySqlOptions
                                .ServerVersion(new Version(8, 0, 21), ServerType.MySql)
                                .CharSetBehavior(CharSetBehavior.NeverAppend))
                        // Everything from this point on is optional but helps with debugging.
                        .UseLoggerFactory(
                            LoggerFactory.Create(
                                logging => logging
                                    .AddConsole()
                                    .AddFilter(level => level >= LogLevel.Information)))
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors()
                );
        }
    }
}
