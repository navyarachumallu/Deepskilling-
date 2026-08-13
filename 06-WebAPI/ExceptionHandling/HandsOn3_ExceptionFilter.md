# Hands-On 3: Exception Handling

`CustomExceptionFilter` implements `IExceptionFilter`:
- Logs exception details to `exception.log`
- Returns 500 Internal Server Error with message

To test:
1. POST `/api/employee/trigger-exception`
2. GET `/api/employee` - throws exception, logged to file

`CustomAuthFilter` (in Filters folder) validates Bearer token in Authorization header.
Used before JWT was configured; Employee controller now uses `[Authorize]` attribute.
