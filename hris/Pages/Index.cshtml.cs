using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hris.Staff.Application.Service;
using hris.Seed.Application.Service;
using hris.Division.Application.Service;

namespace hris.Pages
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly PositionService _positionService;

        public string Title { get; set; } = "Dashboard";
        public string Message { get; set; } = "Hello from Hris!";

        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalPositions { get; set; }

        public IndexModel(EmployeeService employeeService, DepartmentService departmentService, PositionService positionService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _positionService = positionService;
        }

        public async Task OnGetAsync()
        {
            TotalEmployees = await _employeeService.GetTotalCountAsync();
            TotalDepartments = await _departmentService.GetTotalCountAsync();
            TotalPositions = await _positionService.GetTotalCountAsync();

        }
    }
}
