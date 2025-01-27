using Microsoft.AspNetCore.Mvc.RazorPages;

using hris.Division.Application.Service;
using hris.Division.Domain.Entities;

namespace hris.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly DepartmentService _departmentService;

        public List<Department> Departments { get; set; } = new List<Department>();

        public IndexModel(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task OnGetAsync()
        {
            Departments = await _departmentService.GetAllAsync();
        }
    }
}
