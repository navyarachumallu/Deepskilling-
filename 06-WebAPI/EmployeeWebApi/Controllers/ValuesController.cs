using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private static readonly string[] Values = { "value1", "value2", "value3", "value4", "value5" };

    [HttpGet]
    public ActionResult<IEnumerable<string>> Get() => Values;

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        if (id < 0 || id >= Values.Length)
            return NotFound();

        return Values[id];
    }

    [HttpPost]
    public void Post([FromBody] string value) { }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    [HttpDelete("{id}")]
    public void Delete(int id) { }
}
