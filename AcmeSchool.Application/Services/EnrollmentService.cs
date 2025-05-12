using AcmeSchool.Domain.DTOs;
using AcmeSchool.Domain.Entities;
using AcmeSchool.Domain.Interfaces;

namespace AcmeSchool.Application.Services
{
    /// <summary>
    /// Handles student enrollment into courses.
    /// </summary>
    public class EnrollmentService
    {
        private readonly IPaymentGateway _paymentGateway;
        private readonly List<Enrollment> _enrollments = new();
        private readonly StudentService _studentService = new();
        private readonly CourseService _courseService = new();
        public EnrollmentService(IPaymentGateway paymentGateway)
        {
            _paymentGateway = paymentGateway;
        }

        /// <summary>
        /// Enrolls a student in a course if payment is successful.
        /// </summary>
        public Enrollment Enroll(StudentDto studentDto, CourseDto courseDto)
        {
            var student = _studentService.Create(studentDto);
            var course = _courseService.Create(courseDto);

            if (!_paymentGateway.Charge(course.RegistrationFee))
                throw new InvalidOperationException("Payment failed.");

            var enrollment = new Enrollment(student, course);
            _enrollments.Add(enrollment);
            return enrollment;
        }

        /// <summary>
        /// Lists all enrollments between given dates.
        /// </summary>
        public IEnumerable<Enrollment> GetEnrollments(DateTime from, DateTime to)
        {
            return _enrollments
                .Where(e => e.Course.StartDate >= from && e.Course.EndDate <= to)
                .ToList();
        }
    }
}
