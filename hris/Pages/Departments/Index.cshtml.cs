using Microsoft.AspNetCore.Mvc.RazorPages;

using hris.Seed.Domain.Entities;
using hris.Seed.Application.Query;
using MediatR;
using hris.Seed.Application.Query._Department;
using hris.Seed.Application.Dto._Department;
using Microsoft.AspNetCore.SignalR;

namespace hris.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public List<DepartmentSummaryDto> Departments { get; set; } = new List<DepartmentSummaryDto>();

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGetAsync()
        {
            Departments = await _mediator.Send(new GetAllDepartmentsQuery());
        }

    }
}
