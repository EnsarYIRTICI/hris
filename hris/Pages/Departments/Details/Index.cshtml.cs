using hris.Pages.PageModels;
using hris.Seed.Application.Dto._Department;
using hris.Seed.Application.Query._Department;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages.Departments.Details
{
    public class IndexModel : BreadcrumbPageModel
    {

        public DepartmentDetailsDto Department { get; set; }

        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            try 
            {
                Department = await _mediator.Send(new GetDepartmentDetailsQuery(id));

                AddBreadcrumb("Departments", "/departments");
                AddBreadcrumb(Department.Name);

                return Page();

            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return Redirect("/departments");
            }
        }


    }
}
