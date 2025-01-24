using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hris.Staff.Domain.Entities;
using System.Threading.Tasks;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Exceptions;
using hris.Pages.PageModels;

namespace hris.Pages.Employees.Details
{
    public class IndexModel : BreadcrumbPageModel
    {
        private readonly EmployeeService _employeeService;

        public IndexModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public Employee Employee { get; set; } 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {

                AddBreadcrumb("Employees", "/employees");
                AddBreadcrumb("Details");

                Employee = await _employeeService.GetByIdWithDetailsAsync(id);

                if (Employee == null)
                {
                    return NotFound(); 
                }

                return Page(); 
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound(); 
            }
            catch (Exception)
            {
                return StatusCode(500); 
            }
        }
    }
}
