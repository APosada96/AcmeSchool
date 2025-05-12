using AcmeSchool.Application.Services;
using AcmeSchool.Domain.DTOs;
using AcmeSchool.Domain.Entities;
using Xunit;

namespace AcmeSchool.Tests.Services
{
    public class CourseServiceTests
    {
        [Fact]
        public void Should_Create_Course_With_Valid_Dates()
        {
            var start = DateTime.UtcNow;
            var end = start.AddDays(10);
            var dto = new CourseDto
            {
                Name = "Advanced C#",
                RegistrationFee = 200,
                StartDate = start,
                EndDate = end
            };
            var service = new CourseService();

            // Act
            var course = service.Create(dto);

            // Assert
            Assert.Equal(dto.Name, course.Name);
            Assert.Equal(dto.RegistrationFee, course.RegistrationFee);
            Assert.Equal(dto.StartDate, course.StartDate);
            Assert.Equal(dto.EndDate, course.EndDate);
            Assert.IsType<Course>(course);
        }

        [Fact]
        public void Should_Throw_Exception_When_EndDate_Before_StartDate()
        {
            var start = DateTime.UtcNow;
            var end = start.AddDays(-1);
            var dto = new CourseDto
            {
                Name = "Bad Course",
                RegistrationFee = 100,
                StartDate = start,
                EndDate = end
            };
            var service = new CourseService();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.Create(dto));
        }
    }
}
