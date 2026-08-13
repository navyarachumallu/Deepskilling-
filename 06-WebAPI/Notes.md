# Module 06 - ASP.NET Core 8.0 Web API

## Hands-On 1: First Web API
- `ValuesController` with GET, POST, PUT, DELETE
- Run: `dotnet run` from `EmployeeWebApi/`
- Test: `GET https://localhost:7xxx/api/values`

## Hands-On 2: Swagger
- Swashbuckle configured in `Program.cs`
- Swagger UI: `https://localhost:7xxx/swagger`
- Test Employee endpoints with Postman

## Hands-On 3: Custom Model & Filters
- `Employee` model with Department and Skills
- `CustomAuthFilter` - checks Authorization Bearer header
- `CustomExceptionFilter` - logs exceptions to `exception.log`

## Hands-On 4: CRUD Operations
- `EmployeeController` - GET, POST, PUT, DELETE with hardcoded employee list
- PUT validates id and updates employee from request body

## Hands-On 5: JWT Authentication & CORS
- `AuthController` - generates JWT token (GET `/api/auth`)
- `EmployeeController` protected with `[Authorize(Roles = "Admin,POC")]`
- Use token in Postman: `Authorization: Bearer <token>`

## Hands-On 6: Kafka Integration
Reference links for chat application with Kafka:
- https://www.c-sharpcorner.com/article/apache-kafka-net-application/
- https://www.c-sharpcorner.com/article/step-by-step-installation-and-configuration-guide-of-apache-kafka-on-windows-ope/

## Project Location
`EmployeeWebApi/` - Run with `dotnet run`
