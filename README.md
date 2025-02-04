# Employer Portal API

A REST API developed in .NET 8 following DDD (Domain-Driven Design) principles and Clean Architecture practices.

## 🚀 Technologies

- .NET 8.0
- Entity Framework Core 8
- SQL Server
- Serilog
- Swagger
- xUnit
- Moq

## 📁 Project Structure

```plaintext
src/
  ├── EmployerPortal.Domain/        # Entities and business rules
  ├── EmployerPortal.Application/   # Use cases and DTOs
  ├── EmployerPortal.Infrastructure/# Persistence implementations
  └── EmployerPortal.API/          # Controllers and API configurations
tests/
  └── EmployerPortal.UnitTests/    # Unit tests
```

## 🔧 Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio 2022](https://visualstudio.microsoft.com/)

## ⚙️ Setup

1. Clone the repository:
```bash
git clone https://github.com/pedrocezar/employer-portal.git
cd employer-portal
```

2. Restore NuGet packages:
```bash
dotnet restore
```

3. Set up the database:
```bash
# Install EF Core tools
dotnet tool install --global dotnet-ef

# Apply migrations
dotnet ef migrations add InitialCreate --project src/EmployerPortal.Infrastructure --startup-project src/EmployerPortal.API
dotnet ef database update --project src/EmployerPortal.Infrastructure --startup-project src/EmployerPortal.API
```

## 🚀 Running the Application

### Using VSCode:

1. Install recommended extensions:
   - C# Dev Kit
   - .NET Core Tools

2. Press F5 or use Run > Start Debugging

### Using Terminal:

```bash
cd src/EmployerPortal.API
dotnet run
```

The API will be available at:
- Swagger UI: https://localhost:7001/swagger
- API Base URL: https://localhost:7001/api

## 🧪 Running Tests

```bash
dotnet test
```

## 📝 API Endpoints

### Welcome User
```http
GET /api/employerportal/employer/{username}
```

| Parameter | Type   | Description        |
|-----------|--------|--------------------|
| username  | string | User's username    |

## 📊 Logging

Logs are generated using Serilog and can be found at:
- Development environment: `src/EmployerPortal.API/logs/`
- Console (development only)

## 🏗️ Architecture

The project follows these principles:
- Domain-Driven Design (DDD)
- Clean Architecture
- SOLID
- Repository Pattern
- Unit of Work

### Layers:

1. **Domain**: 
   - Entities
   - Interfaces
   - Business rules

2. **Application**: 
   - Application services
   - DTOs
   - Service interfaces

3. **Infrastructure**: 
   - Repository implementations
   - EF Core context
   - Migrations

4. **API**: 
   - Controllers
   - Middlewares
   - Configurations

## 🔒 Error Handling

The application uses a global middleware for exception handling, providing standardized responses for:
- Validation errors (400 Bad Request)
- Not found resources (404 Not Found)
- Internal errors (500 Internal Server Error)

## 🤝 Contributing

1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request