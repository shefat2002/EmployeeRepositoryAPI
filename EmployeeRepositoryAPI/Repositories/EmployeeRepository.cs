using EmployeeRepositoryAPI.Models;
using EmployeeRepositoryAPI.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRepositoryAPI.Repositories;

public class EmployeeRepository : IEmployee
{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    public void Delete(int id)
    {
        var employee =  _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Remove(employee);
        }
    }

    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetById(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        return employee;
    }

    public void Insert(Employee employee)
    {
        _context.Employees.Add(employee);
    }

    public int Save()
    {
        return  _context.SaveChanges();
    }

    public void Update(Employee employee)
    {
        _context.Employees.Update(employee);
    }
}