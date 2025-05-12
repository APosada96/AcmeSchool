namespace AcmeSchool.Domain.Entities
{
    /// <summary>
    /// Represents the enrollment of a student in a course.
    /// </summary>
    public class Enrollment
    {
        public Guid Id { get; private set; }
        public Student Student { get; private set; }
        public Course Course { get; private set; }
        public DateTime EnrollmentDate { get; private set; }

        public Enrollment(Student student, Course course)
        {
            Id = Guid.NewGuid();
            Student = student;
            Course = course;
            EnrollmentDate = DateTime.UtcNow;
        }
    }
}
