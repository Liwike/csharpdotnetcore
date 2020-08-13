

using l2l.Data.Model;

namespace l2l.Data.Repo
{
public class CourseRepository
    {
        private readonly L2LDbContext db;  //csa a kostruktorban kaphat értéket

        public CourseRepository()
        {
            //TODO: Antipattern
            var factory = new L2LDbContextFactory();
            db = factory.CreateDbContext(new string[] {});
        }

        public CourseRepository(L2LDbContext db)
        {
            this.db = db 
                ?? throw new System.ArgumentNullException(nameof(db));
        }

        public void Add(Course course)
        {
            //TODO: Async
            db.Courses.Add(course);
        }

        public Course GetById(int Id)
        {
            //TODO: Async
            return db.Courses.Find(Id);
        }

        public void Update(Course course)
        {
            //TODO: return with void?
            db.Courses.Update(course);
        }

        public void Remove(Course course)
        {
            //TODO: return with void?
            db.Courses.Remove(course);
        }
    }

}