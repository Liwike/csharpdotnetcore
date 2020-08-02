using System;

namespace l2l.Data.Model
{
    public class Course : IEquatable<Course>
    {
        public Course()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Course);
        }

        public bool Equals(Course c)
        {
            if (null == c || Id != c.Id || Name != c.Name)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            //túlcsordulás ellenőrző
            unchecked
            {
                var hash = 27;
                hash = (13 * hash) + Id.GetHashCode();
                hash = (13 * hash) + Name.GetHashCode();
                return hash;
            }

        }
    }

}