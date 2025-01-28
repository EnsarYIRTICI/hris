using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hris.Staff.Domain.Entities;
using System.Threading.Tasks;
using MediatR;
using hris.Staff.Application.Query;
using hris.Pages.PageModels;
using hris.Staff.Application.Query._Employee;
using hris.Staff.Domain.Exceptions._Employee;

namespace hris.Pages.Employees.Details
{
    public class IndexModel : BreadcrumbPageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                AddBreadcrumb("Employees", "/employees");
                AddBreadcrumb("Details");

                Employee = await _mediator.Send(new GetEmployeeWithDetailsByIdQuery(id));

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
