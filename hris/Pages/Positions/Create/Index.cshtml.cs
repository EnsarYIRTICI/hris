using hris.Pages.PageModels;
using hris.Seed.Application.Dto._Department;
using hris.Seed.Application.Query._Department;
using hris.Seed.Application.Command._Position;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace hris.Pages.Positions.Create
{
	public class IndexModel : BreadcrumbPageModel
	{
		private readonly IMediator _mediator;

		public IndexModel(IMediator mediator)
		{
			_mediator = mediator;
		}

		public DepartmentDetailsDto Department { get; set; }

		[BindProperty]
		public string PositionName { get; set; }

		public async Task Init(int id)
		{
			Department = await _mediator.Send(new GetDepartmentDetailsQuery(id));

			AddBreadcrumb("Departments", "/departments");
			AddBreadcrumb(Department.Name, "/departments/details/" + id);
			AddBreadcrumb("Create Position");
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
				return Redirect("/departments");
			}
		}

		public async Task<IActionResult> OnPostCreatePositionAsync(int id)
		{
			if (string.IsNullOrWhiteSpace(PositionName))
			{
				ModelState.AddModelError("", "Position name cannot be empty.");
				await Init(id);
				return Page();
			}

			try
			{
				await _mediator.Send(new CreatePositionCommand
				{
					DepartmentId = id,
					Name = PositionName
				});

				return Redirect($"/departments/details/{id}");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				await Init(id);
				return Page();
			}
		}
	}
}
