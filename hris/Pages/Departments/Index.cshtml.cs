using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using hris.DepartmentModule.Application.Service;
using hris.DepartmentModule.Domain.Entities;

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
