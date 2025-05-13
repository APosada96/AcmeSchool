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

## 🧠 Project Reflections & Evaluation Answers

### ❓ What would I have liked to do but didn’t?

- Implement real data persistence using a database (EF Core, or MongoDB).
- Expose the use cases via a REST API using ASP.NET Core Minimal APIs or Controllers.
- Add command-line interface or UI layer to simulate a real user scenario.
- Use FluentValidation to validate DTOs more robustly before building domain entities.
- Implement domain events to decouple logic further (e.g., after enrollment success).

### 🔁 What did I do that could be improved or revisited?

- Enrollment list is stored in memory; introducing a repository pattern would allow persistence without breaking the architecture.
- Exception handling could be standardized and enriched with specific error types.
- Logging is missing and could help trace issues in future service or API layers.
- Test coverage is strong for the current scope, but integration tests and stress tests could be valuable for future phases.

---

### 📚 What third-party libraries did I use and why?

- **xUnit**: A popular and extensible unit testing framework for .NET.
- **Moq**: Used for creating test doubles to mock external dependencies like `IPaymentGateway`.
- **Microsoft.NET.Test.Sdk**: Required to run tests and integrate with Visual Studio Test Explorer.

These libraries are lightweight, widely adopted, and easy to integrate in Clean Architecture setups.

---

### ⏱️ How much time did I invest?

- **Estimated time**: ~12 hours total.
  - 2h planning and setting up architecture.
  - 8h implementing domain, services, DTOs, and tests.
  - 2h writing documentation and refining tests.

---

### 🔮 What could be improved in the future?

- Add a **database layer** (with repository pattern) to persist students, courses, and enrollments.
- Expose the system via **Web API** for actual client interaction.
- Add a **notification service** (e.g., email on enrollment).
- Add a **validation pipeline** (FluentValidation or custom logic).
- Write **integration and end-to-end tests** for the full flow.

---

## 📜 License

This is a technical assessment project. No license intended for commercial use.