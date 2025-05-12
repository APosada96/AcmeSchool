namespace AcmeSchool.Domain.DTOs
{
    /// <summary>
    /// Represents student data input.
    /// </summary>
    public class StudentDto
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
