using hris.Staff.Domain.Entities;

namespace hris.Staff.Application.Interface
{
    public interface IEmployeeEmailService
    {
        Task<bool> AddEmailAsync(Employee employee, EmployeeEmail email);
        Task<bool> UpdateEmailAsync(Employee employee, EmployeeEmail email);
        Task<bool> DeleteEmailAsync(Employee employee, EmployeeEmail email);

    }
}
