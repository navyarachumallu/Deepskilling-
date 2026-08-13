# Hands-On 2: Swagger Configuration

Swagger is configured in `EmployeeWebApi/Program.cs`:

- `AddSwaggerGen` with API title, version, contact details
- `UseSwagger` and `UseSwaggerUI` middleware
- JWT Bearer security definition for authenticated endpoints

Access Swagger UI at: `/swagger`

Test with Postman:
1. GET `/api/values` - no auth required
2. GET `/api/auth` - get JWT token
3. GET `/api/employee` - add `Authorization: Bearer <token>` header
