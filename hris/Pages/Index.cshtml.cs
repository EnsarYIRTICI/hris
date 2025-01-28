using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using hris.Staff.Application.Query;
using MediatR;
using hris.Seed.Application.Query;
using hris.Seed.Application.Query._Department;
using hris.Seed.Application.Query._Position;
using hris.Staff.Application.Query._Employee;
using hris.Staff.Application.Query._EmployeeDocument;

namespace hris.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public string Title { get; set; } = "Dashboard";
        public string Message { get; set; } = "Hello from Hris!";

        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalPositions { get; set; }
        public int TotalDocuments { get; set; }


        public IndexModel(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGetAsync()
        {
            TotalEmployees = await _mediator.Send(new GetEmployeeTotalCountQuery());
            TotalDocuments = await _mediator.Send(new GetEmployeeDocumentTotalCountQuery());
            TotalDepartments = await _mediator.Send(new GetDepartmentTotalCountQuery());
            TotalPositions = await _mediator.Send(new GetPositionTotalCountQuery());

        }
    }
}
