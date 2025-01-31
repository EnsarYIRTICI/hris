using hris.Pages.PageModels;
using hris.Seed.Application.Dto._Position;
using hris.Seed.Application.Query._Position;
using hris.Staff.Application.Command._EmployeePosition;
using hris.Staff.Application.Dto._Employee;
using hris.Staff.Application.Query._Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages.Positions.Details.AssignEmployee
{
    public class IndexModel : BreadcrumbPageModel
    {
		private readonly IMediator _mediator;

		public IndexModel(IMediator mediator)
		{
			_mediator = mediator;
		}

		public PositionDetailsDto Position { get; set; }
        public List<EmployeeSummary> Employees { get; set; } = new();


        public async Task Init(int id)
        {
			Position = await _mediator.Send(new GetPositionDetailsQuery(id));
            Employees = await _mediator.Send(new GetAllEmployeesQuery(0));


            AddBreadcrumb("Departments", "/departments");
			AddBreadcrumb(Position.DepartmentName, "/departments/details/" + Position.DepartmentId);
			AddBreadcrumb(Position.Name, "/positions/details/" + Position.Id);
			AddBreadcrumb("Assign Employee");
		}
        public async Task<IActionResult> OnGet(int id)
        {
			try 
			{
				await Init(id);
				return Page();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return Redirect("Positions");
			}
        }

        public async Task<IActionResult> OnPostAddEmployeeAsync(int positionId, int employeeId)
        {
            try
            {
                await _mediator.Send(new AddEmployeeToPositionCommand(positionId, employeeId));
                return RedirectToPage(new { id = positionId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                await Init(positionId);
                return Page();
            }
        }


    }
}
