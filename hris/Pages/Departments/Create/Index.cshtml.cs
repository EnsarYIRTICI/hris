using AutoMapper;
using hris.Pages.PageModels;
using hris.Seed.Application.Command._Department;
using hris.Seed.Application.Dto._Department;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Command._Employee;
using hris.Staff.Application.Dto._Employee;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages.Departments.Create
{
    public class IndexModel : BreadcrumbPageModel
    {

        [BindProperty]
        public CreateDepartmentDto CreateDepartment { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }



        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public IndexModel(


            IMapper mapper,
            IMediator mediator
            )
        {

            _mapper = mapper;
            _mediator = mediator;

        }


        public void Init(bool clear = true)
        {
            AddBreadcrumb("Departments", "/departments");
            AddBreadcrumb("Create Deparment");

            if(clear)
            {
                CreateDepartment = new CreateDepartmentDto();
            }

        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                Init();
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Redirect("/departments");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try {
                ModelState.Clear();

                if (CreateDepartment.DeletePositionId >= 0 && CreateDepartment.DeletePositionId < CreateDepartment.Positions.Count && CreateDepartment.Positions.Count > 1)
                {
                    CreateDepartment.Positions.RemoveAt(CreateDepartment.DeletePositionId);
                }

                CreateDepartment.DeletePositionId = -1;

                Console.WriteLine(CreateDepartment.AddPosition);
                Console.WriteLine(CreateDepartment.Positions.Count);


                if (CreateDepartment.AddPosition)
                {
                    CreateDepartment.Positions.Add(new PositionDto());
                    CreateDepartment.AddPosition = false;
                }

                Console.WriteLine(CreateDepartment.Positions.Count);


                Init(false);
                return Page();

            } catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return Redirect("/departments");
            }
        }

        public async Task<IActionResult> OnPostCreate()
        {
            try {

                if(CreateDepartment.Positions.Count > 5)
                {
                    Init(false);
                    return Page();
                }

                if (!ModelState.IsValid)
                {
                    Init(false);
                    return Page();
                }

                try 
                {
                    var command = _mapper.Map<CreateDepartmentCommand>(CreateDepartment);
                    var department = await _mediator.Send(command);

                    Console.WriteLine(department.Name);

                    SuccessMessage = "Department created successfully!";
                }
                catch(Exception ex) 
                {
                    ErrorMessage = ex.Message;

                    Init(false);
                    return Page();
                }

                Init();
                return Page();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return Redirect("/departments");
            }

   
        }
    }
}
