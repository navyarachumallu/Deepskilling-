# Hands-On 4: CRUD API

`EmployeeController` endpoints:

| Method | Route | Description |
|--------|-------|-------------|
| GET | /api/employee | List all employees |
| GET | /api/employee/{id} | Get employee by id |
| POST | /api/employee | Create employee |
| PUT | /api/employee/{id} | Update employee |
| DELETE | /api/employee/{id} | Delete employee |

PUT validates:
- id <= 0 returns BadRequest "Invalid employee id"
- id not in list returns BadRequest "Invalid employee id"
- valid id updates from JSON body and returns updated employee
