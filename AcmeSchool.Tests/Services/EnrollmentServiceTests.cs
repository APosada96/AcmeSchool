using AcmeSchool.Application.Services;
using AcmeSchool.Domain.DTOs;
using AcmeSchool.Domain.Entities;
using AcmeSchool.Domain.Interfaces;
using Moq;
using Xunit;

namespace AcmeSchool.Tests.Services
{
    public class EnrollmentServiceTests
    {
        [Fact]
        public void Enroll_ShouldAddEnrollment_WhenPaymentIsSuccessful()
        {
            // Arrange
            var studentDto = new StudentDto { Name = "Diana", Age = 23 };
            var courseDto = new CourseDto
            {
                Name = "Unit Testing",
                RegistrationFee = 120,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(15)
            };
            var paymentGatewayMock = new Mock<IPaymentGateway>();
            paymentGatewayMock.Setup(p => p.Charge(courseDto.RegistrationFee)).Returns(true);

            var service = new EnrollmentService(paymentGatewayMock.Object);

            // Act
            var enrollment = service.Enroll(studentDto, courseDto);

            // Assert
            Assert.Equal(studentDto.Name, enrollment.Student.Name);
            Assert.Equal(studentDto.Age, enrollment.Student.Age);
            Assert.Equal(courseDto.Name, enrollment.Course.Name);
            Assert.Equal(courseDto.RegistrationFee, enrollment.Course.RegistrationFee);
            Assert.Equal(courseDto.StartDate, enrollment.Course.StartDate);
            Assert.Equal(courseDto.EndDate, enrollment.Course.EndDate);
        }

        [Fact]
        public void Should_Create_Enrollment_With_Valid_Student_And_Course()
        {
            var studentDto = new StudentDto { Name = "Emily", Age = 22 };
            var courseDto = new CourseDto
            {
                Name = "Programming c#",
                RegistrationFee = 100,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(20)
            };

            // Use services to create domain entities
            var studentService = new StudentService();
            var courseService = new CourseService();

            var student = studentService.Create(studentDto);
            var course = courseService.Create(courseDto);

            // Act
            var enrollment = new Enrollment(student, course);

            // Assert
            Assert.Equal(student.Name, enrollment.Student.Name);
            Assert.Equal(student.Age, enrollment.Student.Age);
            Assert.Equal(course.Name, enrollment.Course.Name);
            Assert.Equal(course.RegistrationFee, enrollment.Course.RegistrationFee);
            Assert.NotEqual(Guid.Empty, enrollment.Id);
            Assert.True((DateTime.UtcNow - enrollment.EnrollmentDate).TotalSeconds < 1);
        }
    }
}
