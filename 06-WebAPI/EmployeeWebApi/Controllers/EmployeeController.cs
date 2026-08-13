using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,POC")]
public class EmployeeController : ControllerBase
{
    private static readonly List<Employee> Employees = GetStandardEmployeeList();
    private static bool _throwTestException;

    [HttpGet]
    [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<List<Employee>> Get()
    {
        if (_throwTestException)
            throw new InvalidOperationException("Test exception for CustomExceptionFilter");

        return Employees;
    }

    [HttpGet("standard")]
    [ActionName("GetStandard")]
    public ActionResult<Employee> GetStandard() => Employees.First();

    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        return employee is null ? NotFound() : employee;
    }

    [HttpPost]
    public ActionResult<Employee> Post([FromBody] Employee employee)
    {
        employee.Id = Employees.Max(e => e.Id) + 1;
        Employees.Add(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    public ActionResult<Employee> Put(int id, [FromBody] Employee employee)
    {
        if (id <= 0)
            return BadRequest("Invalid employee id");

        var existing = Employees.FirstOrDefault(e => e.Id == id);
        if (existing is null)
            return BadRequest("Invalid employee id");

        existing.Name = employee.Name;
        existing.Salary = employee.Salary;
        existing.Permanent = employee.Permanent;
        existing.Department = employee.Department;
        existing.Skills = employee.Skills;
        existing.DateOfBirth = employee.DateOfBirth;

        return existing;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = Employees.FirstOrDefault(e => e.Id == id);
        if (employee is null)
            return NotFound();

        Employees.Remove(employee);
        return NoContent();
    }

    [HttpPost("trigger-exception")]
    [AllowAnonymous]
    public IActionResult TriggerException()
    {
        _throwTestException = true;
        return Ok("Next GET call will throw an exception.");
    }

    private static List<Employee> GetStandardEmployeeList() =>
    [
        new Employee
        {
            Id = 1,
            Name = "John Doe",
            Salary = 75000,
            Permanent = true,
            Department = new Department { Id = 1, Name = "Engineering" },
            Skills = [new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "SQL" }],
            DateOfBirth = new DateTime(1990, 5, 15)
        },
        new Employee
        {
            Id = 2,
            Name = "Jane Smith",
            Salary = 82000,
            Permanent = true,
            Department = new Department { Id = 2, Name = "HR" },
            Skills = [new Skill { Id = 3, Name = "Communication" }],
            DateOfBirth = new DateTime(1988, 8, 22)
        },
        new Employee
        {
            Id = 3,
            Name = "Bob Wilson",
            Salary = 65000,
            Permanent = false,
            Department = new Department { Id = 1, Name = "Engineering" },
            Skills = [new Skill { Id = 1, Name = "C#" }],
            DateOfBirth = new DateTime(1995, 3, 10)
        }
    ];
}
