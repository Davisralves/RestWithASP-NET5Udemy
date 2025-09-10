# RestWithASP-NET5Udemy

[![Continuous Integration with Github Actions](https://github.com/Davisralves/RestWithASP-NET5Udemy/actions/workflows/docker-publish.yml/badge.svg)](https://github.com/Davisralves/RestWithASP-NET5Udemy/actions/workflows/docker-publish.yml)

## Overview

RestWithASP-NET5Udemy is a comprehensive RESTful API built with ASP.NET Core 5 that demonstrates modern web API development practices. This project serves as the backend component for the AspnetCore-front-end-react full-stack application and showcases enterprise-level architecture patterns, authentication, and containerization using Docker.

## What Was Developed

### Core Features
- **RESTful API Architecture**: Full CRUD operations for multiple entities (Person, Books, Files)
- **Authentication & Authorization**: JWT-based security implementation with refresh tokens
- **API Versioning**: Support for multiple API versions
- **Hypermedia (HATEOAS)**: Self-descriptive API responses with navigation links
- **File Management**: Upload and download capabilities with secure file handling
- **Database Integration**: Entity Framework Core with MySQL database
- **API Documentation**: Swagger/OpenAPI integration for interactive documentation
- **Logging**: Structured logging with Serilog
- **Containerization**: Docker support with multi-stage builds
- **CORS Support**: Cross-origin resource sharing for frontend integration

### Entities and Endpoints
- **Person API**: Complete CRUD operations for person management
- **Books API**: Library management with book entities
- **File API**: File upload/download with secure storage
- **Auth API**: User authentication, token refresh, and revocation

## Architecture

```
RestWithASP-NET5Udemy/
│
├── .github/
│   └── workflows/              # GitHub Actions CI/CD pipelines
├── RestWithASPNETUdemy/
│   ├── RestWithASPNETUdemy.sln # Solution file
│   ├── docker-compose.yml     # Docker orchestration
│   ├── db/                    # Database scripts and migrations
│   │   ├── migrations/        # Database schema migrations
│   │   └── dataset/           # Initial data scripts
│   └── RestWithASPNETUdemy/   # Main API project
│       ├── Business/          # Business logic layer
│       │   ├── ILoginBusiness.cs
│       │   ├── IPersonBusiness.cs
│       │   ├── IBooksBusiness.cs
│       │   ├── IFileBusiness.cs
│       │   └── Implementations/
│       ├── Configurations/    # Configuration classes
│       ├── Controllers/       # API controllers
│       │   ├── AuthController.cs
│       │   ├── PersonController.cs
│       │   ├── BooksController.cs
│       │   └── FileController.cs
│       ├── Data/             # Data context and migrations
│       ├── Hypermedia/       # HATEOAS implementation
│       │   ├── Enricher/
│       │   ├── Filters/
│       │   └── ContentResponseEnricher.cs
│       ├── Model/            # Data models and entities
│       │   ├── User.cs
│       │   ├── Person.cs
│       │   ├── Book.cs
│       │   └── Context/
│       ├── Repository/       # Data access layer
│       │   ├── Generic/
│       │   ├── UserRepository.cs
│       │   └── PersonRepository.cs
│       ├── Services/         # Service layer
│       │   ├── ITokenService.cs
│       │   └── Implementations/
│       ├── Startup.cs        # Application configuration
│       ├── Program.cs        # Application entry point
│       ├── appsettings.json  # Configuration settings
│       └── Dockerfile        # Container configuration
└── REST API´s From 0 to Azure with ASP.NET Core 5 and Docker.postman_collection.json
```

### Architecture Principles
- **Layered Architecture**: Clear separation between Controllers, Business Logic, Repository, and Models
- **Dependency Injection**: Extensive use of DI container for loose coupling
- **Repository Pattern**: Abstract data access with generic repository implementation
- **Business Layer**: Centralized business logic separate from controllers
- **Service Layer**: Additional services for cross-cutting concerns (JWT, File handling)

## How to Run the Project

### Prerequisites
- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) or MySQL via Docker
- [Docker](https://www.docker.com/get-started) (optional, for containerization)
- [Visual Studio 2019/2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Local Development Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Davisralves/RestWithASP-NET5Udemy.git
   cd RestWithASP-NET5Udemy
   ```

2. **Navigate to the project directory:**
   ```bash
   cd RestWithASPNETUdemy/RestWithASPNETUdemy
   ```

3. **Update database connection:**
   - Open [`appsettings.json`](RestWithASPNETUdemy/RestWithASPNETUdemy/appsettings.json)
   - Update the MySQL connection string:
   ```json
   {
     "MySQLConnection": {
       "MySQLConnectionString": "Server=localhost;DataBase=rest_with_asp_net_udemy;Uid=root;Pwd=your_password"
     }
   }
   ```

4. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

5. **Run database migrations:**
   ```bash
   dotnet run
   ```
   The application will automatically run migrations on startup in development mode.

6. **Start the application:**
   ```bash
   dotnet run
   ```

7. **Access the API:**
   - Swagger UI: [https://localhost:5001/swagger](https://localhost:5001/swagger)
   - API Base URL: [https://localhost:5001/api](https://localhost:5001/api)

### Docker Setup

1. **Using Docker Compose (Recommended):**
   ```bash
   cd RestWithASPNETUdemy
   docker-compose up -d
   ```

2. **Build and run manually:**
   ```bash
   cd RestWithASPNETUdemy/RestWithASPNETUdemy
   docker build -t restwithasp-net5udemy .
   docker run -p 5000:80 restwithasp-net5udemy
   ```

### Testing the API

- **Postman Collection**: Import the provided [Postman collection](REST%20API´s%20From%200%20to%20Azure%20with%20ASP.NET%20Core%205%20and%20Docker.postman_collection.json)
- **Swagger UI**: Interactive API documentation available at `/swagger`

## Key Features Explained

### Authentication Flow
1. **Sign In**: POST `/api/Auth/v1/signin` with user credentials
2. **Receive JWT**: Get access token and refresh token
3. **Authorize Requests**: Include Bearer token in Authorization header
4. **Refresh Token**: POST `/api/Auth/v1/refresh` when token expires
5. **Revoke Token**: GET `/api/Auth/v1/revoke` to invalidate tokens

### API Versioning
- All endpoints support versioning via URL: `/api/[controller]/v{version}`
- Current version: v1

### Hypermedia (HATEOAS)
- API responses include navigational links
- Self-descriptive responses for better API discoverability
- Implemented via [`PersonEnricher`](RestWithASPNETUdemy/RestWithASPNETUdemy/Hypermedia/Enricher/PersonEnricher.cs) and [`BookEnricher`](RestWithASPNETUdemy/RestWithASPNETUdemy/Hypermedia/Enricher/BookEnricher.cs)

### File Management
- Secure file upload via [`FileController`](RestWithASPNETUdemy/RestWithASPNETUdemy/Controllers/FileController.cs)
- File download with proper content-type handling
- Configurable upload directory

## Configuration

### Key Configuration Sections
```json
{
  "TokenConfigurations": {
    "Audience": "ExampleAudience",
    "Issuer": "ExampleIssuer",
    "Secret": "YOUR_SECRET_KEY",
    "Minutes": 60,
    "DaysToExpiry": 7
  },
  "MySQLConnection": {
    "MySQLConnectionString": "Server=localhost;DataBase=rest_with_asp_net_udemy;Uid=root;Pwd=admin123"
  }
}
```

## Deployment

### Azure Deployment
- Configured for Azure deployment with GitHub Actions
- CI/CD pipeline defined in [`.github/workflows/`](.github/workflows/)
- Docker container publishing to Azure Container Registry

### Environment Variables
For production deployment, use environment variables instead of appsettings.json:
- `MYSQL_CONNECTION_STRING`
- `JWT_SECRET`
- `JWT_ISSUER`
- `JWT_AUDIENCE`

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License.

## Additional Resources

- **Swagger Documentation**: Available at `/swagger` when running
- **Postman Collection**: Import for API testing
- **Docker Hub**: Container images available for deployment
- **GitHub Actions**: Automated CI/CD pipeline

---

**Author**: Davis Alves  
**Course**: REST API's From 0 to Azure with ASP.NET Core 5 and Docker  
**Repository**: [https://github.com/Davisralves/RestWithASP-NET5Udemy](https://github.com/Davisralves/RestWithASP-NET5Udemy)
