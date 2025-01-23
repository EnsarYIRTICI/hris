using Microsoft.AspNetCore.Mvc.RazorPages;
using hris.Staff.Domain.Entities;
using hris.Staff.Application.Service;
using Microsoft.AspNetCore.Mvc;
using hris.Pages.PageModels;

namespace hris.Pages.Staff
{
    public class IndexModel : BreadcrumbPageModel
    {
        public string Title { get; set; } = "Employee";
        public string Message { get; set; } = "Manage Employees";

        private readonly EmployeeService _employeeService;

        public IndexModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public List<Employee> Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            AddBreadcrumb("Home", "/");
            AddBreadcrumb("Staff");

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                Employees = await _employeeService.SearchByFullNameOrTcknAsync(SearchTerm);
            }
            else
            {
                Employees = await _employeeService.GetAllAsync(offset: 0);
            }
        }
    }
}
