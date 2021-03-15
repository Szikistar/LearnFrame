using System;
using LF.Data.Models;
using Microsoft.EntityFrameworkCore;

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

            if(factory.IsInMemoryDb())
            {
                // Mamóriában lévő db esetén
                db.Database.EnsureCreated();
            }
            else
            {
                // Csak fájl alapú futtatásnál, memória db-re nem fut le.
                db.Database.Migrate();
            }
            
        }

        public LFDbContext GetNewLFDbContext()
        {
            return factory.CreateDbContext( new string[] {} );
        }

        public void Dispose()
        {
            var db = GetNewLFDbContext();
            factory.Dispose();
            db.Database.EnsureDeleted();
            db.Dispose();
        }
            
    }
}