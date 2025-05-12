namespace AcmeSchool.Domain.Entities
{
    /// <summary>
    /// Represents a student that can be enrolled in courses.
    /// </summary>
    public class Student
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Student(string name, int age)
        {
            if (age < 18)
                throw new ArgumentException("Only adults (18+) can register.");

            Id = Guid.NewGuid();
            Name = name;
            Age = age;
        }
    }
}
