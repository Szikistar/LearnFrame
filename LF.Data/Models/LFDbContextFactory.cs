using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LF.Data.Models
{
    public class LFDbContextFactory : IDesignTimeDbContextFactory<LFDbContext>
    {
        public LFDbContext CreateDbContext(string[] args)
        {
            var obuilder = new DbContextOptionsBuilder<LFDbContext>();

            var basePath = Directory.GetCurrentDirectory();
            var environment = Environment.GetEnvironmentVariable(GlobalStrings.AspnetCoreEnvironment);

            var cbuilder = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{environment}.json", true)
                        .AddEnvironmentVariables();
            var config = cbuilder.Build();
            
            var cn = config.GetConnectionString(GlobalStrings.ConnectionName);
            
            obuilder.UseSqlite(cn);

            return new LFDbContext(obuilder.Options);
        }
    }
}