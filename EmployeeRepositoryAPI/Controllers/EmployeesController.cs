using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeRepositoryAPI.Models;
using EmployeeRepositoryAPI.Repositories.RepositoryInterfaces;

namespace EmployeeRepositoryAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployee _employee;

    public EmployeesController(IEmployee employee)
    {
        _employee = employee;
    }

    // GET: api/Employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        var employees = await _employee.GetAll();
        return Ok(employees);
    }

    // GET: api/Employees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee([FromBody] int id)
    {
        var employee = await _employee.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    // PUT: api/Employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee([FromBody] int id)
    {
        var existingEmployee = await _employee.GetById(id);
        if (existingEmployee == null)
        {
            return NotFound();
        }
        _employee.Update(existingEmployee);
        await Task.Run(() => _employee.Save());
        return NoContent();

    }

    // POST: api/Employees
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee([FromForm] Employee employee)
    {
        _employee.Insert(employee);
        await Task.Run(() => _employee.Save());
        return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee([FromBody] int id)
    {
        _employee.Delete(id);
        await Task.Run(() => _employee.Save());
        return NoContent();
    }

}
