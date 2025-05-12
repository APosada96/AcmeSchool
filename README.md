# 🎓 ACME School - Course Enrollment System

This is a C# proof-of-concept application designed for managing courses and student enrollments at ACME School. The system follows **Clean Architecture** principles, uses **DTOs** for abstraction, and includes unit tests written with **xUnit** and **Moq**.

---

## 📦 Project Structure

```
AcmeSchool.sln
├── AcmeSchool.Domain          // Core entities and interfaces (Student, Course, Enrollment, IPaymentGateway)
├── AcmeSchool.Application     // Services and use cases with DTOs (StudentService, CourseService, EnrollmentService)
├── AcmeSchool.Infrastructure  // Payment gateway implementations (Mock + Reliable)
└── AcmeSchool.Tests           // Unit tests for services and entities (using xUnit)
```

---

## ✅ Features

- Register **adult students** using `StudentDto`.
- Register **courses** with validation via `CourseDto`.
- Enroll students into courses via `EnrollmentService` using DTOs.
- Use **mocked payment gateways** to simulate success or failure.
- Retrieve enrollments filtered by date range.
- Clean separation of responsibilities with services for students, courses, and enrollments.

---

## 🔐 Design Decisions

- **DTOs** isolate domain logic from input models.
- **Application services** handle use cases and entity creation.
- **Domain entities** enforce business rules (e.g., age validation, date validation).
- **Interfaces (e.g., IPaymentGateway)** allow easy replacement of infrastructure services.
- **Test doubles (Moq)** simulate behavior of external services.
- **ReliablePaymentGateway** guarantees deterministic test behavior.

---

## 🧪 Testing

- Written with **xUnit**.
- Uses **Moq** for mocking `IPaymentGateway` where necessary.
- Tests also use real `StudentService`, `CourseService`, and `ReliablePaymentGateway`.
- Every entity and service has unit tests:
  - `StudentServiceTests`, `CourseServiceTests`, `EnrollmentServiceTests`
  - `StudentTests`, `CourseTests`, `EnrollmentTests`

---

## 🚀 Run Instructions

### Requirements

- .NET 8 SDK
- Visual Studio 2022+ or VS Code

### Build the solution

```bash
dotnet build
```

### Run tests

```bash
dotnet test
```

Use the Visual Studio Test Explorer to visualize and run individual tests.

---

## 🧠 Lessons & Notes

### What was improved
- Replaced direct entity usage with DTO-based construction.
- Added services for better separation of concerns.
- Introduced reliable and mock payment gateways for flexibility and testing.

### What could be improved in the future
- Add persistence (EF Core, MongoDB, etc.)
- Expose APIs (e.g., Minimal API or ASP.NET Core Web API).
- Apply MediatR for use case orchestration.
- Use FluentValidation for DTO validation.

### Time invested
- ~6–8 hours (design, refactor, documentation, testing)

---

## 📚 Dependencies

- [xUnit](https://xunit.net/)
- [Moq](https://github.com/moq)
- [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk)

---

## 📜 License

This is a technical assessment project. No license intended for commercial use.