namespace AcmeSchool.Domain.DTOs
{
    /// <summary>
    /// Represents course data input.
    /// </summary>
    public class CourseDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
