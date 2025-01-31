using hris.Pages.PageModels;
using hris.Seed.Application.Dto._Position;
using hris.Seed.Application.Query._Position;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages.Positions.Details
{
    public class IndexModel : BreadcrumbPageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public PositionDetailsDto Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            Position = await _mediator.Send(new GetPositionDetailsQuery(id));

            AddBreadcrumb("Departments", "/departments");
            AddBreadcrumb(Position.DepartmentName, "/departments/details/" + Position.DepartmentId);
            AddBreadcrumb(Position.Name);


            if (Position == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
