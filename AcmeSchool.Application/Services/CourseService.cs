using AcmeSchool.Domain.DTOs;
using AcmeSchool.Domain.Entities;

namespace AcmeSchool.Application.Services
{
    /// <summary>
    /// Handles course-related operations.
    /// </summary>
    public class CourseService
    {
        public Course Create(CourseDto dto)
        {
            return new Course(dto.Name, dto.RegistrationFee, dto.StartDate, dto.EndDate);
        }
    }
}
