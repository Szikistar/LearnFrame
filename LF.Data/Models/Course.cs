using System;

namespace LF.Data.Models
{
    public class Course : IEquatable<Course>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj) => Equals(obj as Course);

        public bool Equals(Course course)
        {
            if(null == course)
            {
                return false;
            }

            if(Id != course.Id || Name != course.Name)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            
            unchecked
            {
                int hash = 27;
                hash = (hash * 13) + Id.GetHashCode();
                hash = (hash * 13) + Name.GetHashCode();
                return hash;
            }
        }
    }
}