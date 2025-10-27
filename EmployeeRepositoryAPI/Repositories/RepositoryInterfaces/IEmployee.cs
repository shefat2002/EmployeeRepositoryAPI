using EmployeeRepositoryAPI.Models;

namespace EmployeeRepositoryAPI.Repositories.RepositoryInterfaces;

public interface IEmployee
{
    Task<IEnumerable<Employee>> GetAll();
    Task<Employee?> GetById(int id);
    void Insert(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
    int Save();
}
