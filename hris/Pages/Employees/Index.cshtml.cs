using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using hris.Pages.PageModels;
using hris.Staff.Domain.Entities;
using MediatR;
using hris.Staff.Application.Query;
using hris.Staff.Application.Query._Employee;
using hris.Staff.Application.Dto._Employee;

namespace hris.Pages.Employees
{
    public class IndexModel : BreadcrumbPageModel
    {
        public string Title { get; set; } = "Employees";
        public string Message { get; set; } = "Manage Employees";

        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public List<EmployeeSummary> Employees { get; set; } = new List<EmployeeSummary>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            AddBreadcrumb("Employees");

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                Employees = await _mediator.Send(new SearchEmployeeQuery(SearchTerm));
            }
            else
            {
                Employees = await _mediator.Send(new GetAllEmployeesQuery(offset: 0));
            }
        }
    }
}
