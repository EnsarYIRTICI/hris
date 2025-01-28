using AutoMapper;

using hris.Pages.PageModels;
using hris.Seed.Application.Query;
using hris.Seed.Application.Query._Country;
using hris.Seed.Application.Query._Department;
using hris.Seed.Application.Query._EmailType;
using hris.Seed.Application.Query._PhoneNumberType;
using hris.Seed.Application.Query._Position;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Command._Employee;
using hris.Staff.Application.Dto._Employee;
using hris.Staff.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hris.Pages.Employees.Create
{
    public class IndexModel : BreadcrumbPageModel
    {
        [BindProperty]
        public CreateEmployeeDto CreateEmployee { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; } 


        public List<Country> Countries { get; set; }
        public List<EmailType> EmailTypes { get; set; }
        public List<PhoneNumberType> PhoneNumberTypes { get; set; }
        public List<Department> Departments { get; set; }
        public List<Position> Positions { get; set; } 
        

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

        public async Task Init(bool clear = true)
        {

            AddBreadcrumb("Employees", "/employees");
            AddBreadcrumb("Create Employee");

            if (clear)
            {
                CreateEmployee = new CreateEmployeeDto();
            }

            Countries = await _mediator.Send(new GetAllCountriesQuery());
            EmailTypes = await _mediator.Send(new GetAllEmailTypesQuery());
            PhoneNumberTypes = await _mediator.Send(new GetAllPhoneNumberTypesQuery());
            Departments = await _mediator.Send(new GetAllDepartmentsQuery());

            if (CreateEmployee.DepartmentId > 0)
            {
                Positions = await _mediator.Send(new GetPositionsByDepartmentIdQuery(CreateEmployee.DepartmentId));
            }
            else
            {
                Positions = new List<Position>();
            }

        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                await Init();
                return Page();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Redirect("/employees");
            }
           
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                ModelState.Clear();

                Console.WriteLine(CreateEmployee.AddPhone);
                Console.WriteLine(CreateEmployee.AddEmail);
                Console.WriteLine(CreateEmployee.DepartmentId);

                if (CreateEmployee.AddEmail)
                {
                    CreateEmployee.Emails.Add(new EmailDto());
                    CreateEmployee.AddEmail = false;

                }

                if (CreateEmployee.AddPhone)
                {
                    CreateEmployee.PhoneNumbers.Add(new PhoneDto());
                    CreateEmployee.AddPhone = false;
                }


                await Init(false);
                return Page();

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return Redirect("/employees");
            }


        }

        public async Task<IActionResult> OnPostCreate()
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    await Init(false);
                    return Page();
                }

                try
                {
                    var createEmployeeCommand = _mapper.Map<CreateEmployeeCommand>(CreateEmployee);
                    var employee = await _mediator.Send(createEmployeeCommand);

                    Console.Write(employee.FirstName + " " + employee.LastName);

                    SuccessMessage = "Employee created successfully!";

                    await Init();
                    return Page();

                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;

                    await Init(false);
                    return Page();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return Redirect("/employees");
            }

        }


    }


}
