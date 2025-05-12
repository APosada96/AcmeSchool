using AcmeSchool.Application.Services;
using AcmeSchool.Domain.DTOs;
using AcmeSchool.Domain.Entities;
using Xunit;

namespace AcmeSchool.Tests.Services
{
    public class StudentServiceTests
    {
        [Fact]
        public void Should_Create_Student_When_Adult()
        {
            var dto = new StudentDto { Name = "John Doe", Age = 20 };
            var service = new StudentService();

            // Act
            var student = service.Create(dto);

            // Assert
            Assert.Equal(dto.Name, student.Name);
            Assert.Equal(dto.Age, student.Age);
            Assert.IsType<Student>(student);
            Assert.NotEqual(Guid.Empty, student.Id);
        }

        [Fact]
        public void Should_Throw_Exception_When_Underage()
        {
            var dto = new StudentDto { Name = "Jane Doe", Age = 17 };
            var service = new StudentService();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.Create(dto));
        }
    }
}
