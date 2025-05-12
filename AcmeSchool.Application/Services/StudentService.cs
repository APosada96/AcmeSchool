using AcmeSchool.Domain.DTOs;
using AcmeSchool.Domain.Entities;

namespace AcmeSchool.Application.Services
{
    /// <summary>
    /// Handles student-related operations.
    /// </summary>
    public class StudentService
    {
        public Student Create(StudentDto dto)
        {
            return new Student(dto.Name, dto.Age);
        }
    }
}
