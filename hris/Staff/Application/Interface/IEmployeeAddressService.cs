using hris.Staff.Domain.Entities;

namespace hris.Staff.Application.Interface
{
    public interface IEmployeeAddressService
    {
        Task<bool> AddEmployeeAddressAsync(Employee employee, EmployeeAddress address);
        Task<bool> UpdateEmployeeAddressAsync(Employee employee, EmployeeAddress address);
        Task<bool> DeleteEmployeeAddressAsync(Employee employee, EmployeeAddress address);
    }
}

