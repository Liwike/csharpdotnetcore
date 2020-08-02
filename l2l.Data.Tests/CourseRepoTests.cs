using System;
using Xunit;
using l2l.Data.Model;
using l2l.Data.Repo;
using FluentAssertions;

namespace l2l.Data.Tests
{
    /// <summary>
    /// CRUD és a lita tesztje
    /// </summary>
    public class CourseRepoTests
    {
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
            result.Should().BeEquivalentTo(course);
        }
    }
}
