using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hris.Staff.Application.Service;
using hris.Seed.Application.Service;
using hris.Division.Application.Service;
using hris.Staff.Application.Query;
using MediatR;

namespace hris.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        private readonly DepartmentService _departmentService;
        private readonly PositionService _positionService;

        public string Title { get; set; } = "Dashboard";
        public string Message { get; set; } = "Hello from Hris!";

        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalPositions { get; set; }

        public IndexModel(IMediator mediator, DepartmentService departmentService, PositionService positionService)
        {
            _departmentService = departmentService;
            _positionService = positionService;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task OnGetAsync()
        {
            TotalEmployees = await _mediator.Send(new GetEmployeeTotalCountQuery());
            TotalDepartments = await _departmentService.GetTotalCountAsync();
            TotalPositions = await _positionService.GetTotalCountAsync();

        }
    }
}
