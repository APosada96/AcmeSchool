namespace AcmeSchool.Domain.Entities
{
    /// <summary>
    /// Represents a course offered by the school.
    /// </summary>
    public class Course
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal RegistrationFee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Course(string name, decimal registrationFee, DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new ArgumentException("End date must be after start date.");

            Id = Guid.NewGuid();
            Name = name;
            RegistrationFee = registrationFee;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
