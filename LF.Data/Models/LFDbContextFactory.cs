using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LF.Data.Models
{
    public class LFDbContextFactory : IDesignTimeDbContextFactory<LFDbContext>, IDisposable
    {
        private readonly string cn;
        private readonly SqliteConnection connection = null;

        public LFDbContextFactory()
        {
            var basePath = Directory.GetCurrentDirectory();
            var environment = Environment.GetEnvironmentVariable(GlobalStrings.AspnetCoreEnvironment);

            var cbuilder = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile($"appsettings.{environment}.json", true)
                        .AddEnvironmentVariables();
            var config = cbuilder.Build();
            
            cn = config.GetConnectionString(GlobalStrings.ConnectionName);
            
            if(IsInMemoryDb())
            {
                connection = new SqliteConnection(cn);
                connection.Open();
            }
            
        }

        public bool IsInMemoryDb()
        {
            var cb = new SqlConnectionStringBuilder(cn);
            if(!cb.ContainsKey(GlobalStrings.DataSource))
            {
                throw new ArgumentException("Missing property from ConnectionString: Data Source", "ConnectionString");
            }

            return GlobalStrings.SqlMemoryDb.Equals( 
                (string)cb[GlobalStrings.DataSource], StringComparison.OrdinalIgnoreCase );
        }

        public LFDbContext CreateDbContext(string[] args)
        {
            var obuilder = new DbContextOptionsBuilder<LFDbContext>();            
            
            if(IsInMemoryDb())
            {
                obuilder.UseSqlite(connection);
            }
            else
            {
                obuilder.UseSqlite(cn);
            }
            

            return new LFDbContext(obuilder.Options);
        }

        public void Dispose()
        {
            if( connection != null )
            {
                connection.Dispose();
            }
        }
    }
}