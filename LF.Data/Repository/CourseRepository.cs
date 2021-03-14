using System;
using LF.Data.Models;

namespace LF.Data.Repository
{
    public class CourseRepository
    {
        private readonly LFDbContext db;
        public CourseRepository()
        {
            // TODO: Antipattern - konstruktorban összekötöm a két objektumot
            var factory = new LFDbContextFactory();
            db = factory.CreateDbContext( new string[] {} );
        }
        public void Add(Course entity)
        {
            // TODO: Async
            db.Courses.Add(entity);
        }

        public Course GetById(int Id) 
        {
            // TODO: Async
            return db.Courses.Find(Id);
        }
    }
}