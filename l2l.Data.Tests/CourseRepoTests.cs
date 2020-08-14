using System;
using Xunit;
using l2l.Data.Repo;
using FluentAssertions;
using l2l.Data.Model;

namespace l2l.Data.Tests
{
    /// <summary>
    /// CRUD és a lita tesztje
    /// </summary>
    public class CourseRepoTests
    {
        public CourseRepoTests()
        {
            //addatbázis létrehozása
            var factory=new L2LDbContextFactory();
            var db=factory.CreateDbContext(new string[] {});
            db.Database.EnsureCreated();
        }
        [Fact]
        public void CourseRepoTests_AddedCourseShouldBeAppearInRepo()
        {
            Console.WriteLine("Huhu első tesztem!");
            // EZ A VÁZA A TESZTNEK

            // Arrange: előkészület

            // SUT=System Under Test
            var sut = new CourseRepository();
            //var course = new Model.Course { Id = 1, Name = "Teszt kurzus" };
            var course = new Course { Id = 1, Name = "Teszt kurzus" };

            // Act: action csinálunk valamit a tesztelendő dologgal
            sut.Add(course);
            var result = sut.GetById(course.Id);

            // Assert: kijelent 
            Assert.NotNull(result);

            //Antipattern : IEquatable<Course> mert a TESZT MIATT implementálja a
            //Equals és a GetHashCode függvényeket NEM HASZNÁLHATÓ
            //Assert.Equal(course, result);
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(course);
        }

        [Fact]
        public void CourseRepoTests_ExitsingCoursesdShouldAppearInRepo()
        {
            //Arrange
            var sut = new CourseRepository();
            var course = new Course { Id = 1, Name = "Teszt kurzus" };
            sut.Add(course);
            //act
            var result = sut.GetById(course.Id);
            //assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(course);

        }

        [Fact]
        public void CourseRepoTests_ExitsingCoursesdShouldBeChange()
        {
            //Arrange
            var sut = new CourseRepository();
            var course = new Course { Id = 1, Name = "Teszt kurzus" };
            sut.Add(course);
            //act
            var toUpdate = sut.GetById(course.Id);
            toUpdate.Name = "Módosított";
            sut.Update(toUpdate);
            var afterUpdate = sut.GetById(course.Id);
            //assert
            afterUpdate.Should().BeEquivalentTo(toUpdate);
        }

         [Fact]
        public void CourseRepoTests_ExitsingCoursesdShouldBeDeleted()
        {
            //Arrange
            var sut = new CourseRepository();
            var course = new Course { Id = 1, Name = "Teszt kurzus" };
            sut.Add(course);
            //act
            var toDelete = sut.GetById(course.Id);
            sut.Remove(toDelete);
            var afterDelete = sut.GetById(course.Id);
            //assert
            afterDelete.Should().BeNull();
        }
    }
}
