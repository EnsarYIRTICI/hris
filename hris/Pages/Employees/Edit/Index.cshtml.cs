using hris.Pages.PageModels;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Entities;
using hris.Staff.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages.Employees.Edit
{
    public class IndexModel : BreadcrumbPageModel
    {

        public void OnGet()
        {
            AddBreadcrumb("Employees", "/employees");
            AddBreadcrumb("Edit");


        }
    }

  
}
