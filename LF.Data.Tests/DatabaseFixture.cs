using System;
using LF.Data.Models;

namespace LF.Data.Tests
{
    public class DatabaseFixture : IDisposable
    {
        private readonly LFDbContextFactory factory;

        public DatabaseFixture()
        {
            // TODO: Antipattern
            factory = new LFDbContextFactory();
            var db = GetNewLFDbContext();
            db.Database.EnsureCreated();
        }

        public LFDbContext GetNewLFDbContext()
        {
            return factory.CreateDbContext( new string[] {} );
        }

        public void Dispose()
        {
            var db = GetNewLFDbContext();
            db.Database.EnsureDeleted();
            db.Dispose();
        }
            
    }
}