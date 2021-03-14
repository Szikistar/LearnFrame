using System;
using LF.Data.Models;

namespace LF.Data.Repository
{
    public class CourseRepository
    {
        private readonly LFDbContext db;
        public CourseRepository()
        {
            var factory = new LFDbContextFactory();
            db = factory.CreateDbContext( new string[] {} );
        }
        public void Add(Course entity)
        {
            db.Courses.Add(entity);
        }

        public Course GetById(int Id) 
        {
            return db.Courses.Find(Id);
        }
    }
}