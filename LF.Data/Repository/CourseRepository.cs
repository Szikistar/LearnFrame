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
        public void Add(Course course)
        {
            // TODO: Async
            db.Courses.Add(course);
        }

        public Course GetById(int Id) 
        {
            // TODO: Async
            return db.Courses.Find(Id);
        }

        public void Update(Course course)
        {
            // TODO: return with void?
            db.Courses.Update(course);
        }

        public void Remove(Course course)
        {
            // TODO: return with void?
            db.Courses.Remove(course);
        }
    }
}