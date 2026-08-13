# Hands-On 5: JWT Authentication

1. Get token: `GET /api/auth` (AllowAnonymous)
2. Copy token from response
3. Call protected endpoint with header: `Authorization: Bearer <token>`

Configuration in `Program.cs`:
- `AddAuthentication` + `AddJwtBearer`
- Issuer: mySystem, Audience: myUsers
- Security key: mysuperdupersecret
- Token expires in 10 minutes

`EmployeeController` uses `[Authorize(Roles = "Admin,POC")]`

CORS enabled with `AllowLocal` policy for cross-origin requests.
