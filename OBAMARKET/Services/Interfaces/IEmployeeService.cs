using OBAMARKET.Models;

namespace OBAMARKET.Controllers;

public interface IEmployeeService
{
    public Task<int> AddAsync(Employee employee);
    public Task<int> AddAsync(List<Employee> employee);
    public Task<List<Employee>> GetAllAsync();
    public Task<Employee> GetByIdAsync(int id);
    public Task<int> Delete(int id);
    public Task<Employee> Update(int id, Employee employee);
}
