using hris.Staff.Domain.Entities;
using System.Net;

namespace hris.Staff.Application.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();

        Task<Employee> GetByIdAsync(int employeeId);

        Task<Employee> GetByTcknAsync(string Tckn);
        Task<Employee> CreateAsync();
    }
}
