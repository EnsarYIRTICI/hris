using hris.Seed.Application.Service;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Dto;
using hris.Staff.Application.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages.Staff.Create
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CreateEmployeeDto CreateEmployee { get; set; }

        public string SuccessMessage { get; set; }

        public List<EmailType> EmailTypes { get; set; }
        public List<Department> Departments { get; set; }
        public List<Position> Positions { get; set; }
        public List<PhoneNumberType> PhoneNumberTypes { get; set; }



        private readonly EmployeeService _employeeService;      
        private readonly EmailTypeService _emailTypeService;
        private readonly DepartmentService _departmentService;
        private readonly PositionService _positionService;
        private readonly PhoneNumberTypeService _phoneNumberTypeService;


        public IndexModel(
            EmployeeService employeeService,
            DepartmentService departmentService,
            PositionService positionService,
            EmailTypeService emailTypeService,
            PhoneNumberTypeService phoneNumberTypeService
            )
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _positionService = positionService;
            _emailTypeService = emailTypeService;
            _phoneNumberTypeService = phoneNumberTypeService;
        }
        public async Task OnGet()
        {
            CreateEmployee = new CreateEmployeeDto();

            EmailTypes = await _emailTypeService.GetAllAsync();
            Departments = await _departmentService.GetAllDepartmentsWithPositionsAsync();
            PhoneNumberTypes = await _phoneNumberTypeService.GetAllAsync();


            foreach (var department in Departments)
            {
                Console.WriteLine("Departmant --> " + department.Name);

                foreach (var position in department.Positions)
                {
                    Console.WriteLine("Position --> " + position.Name);
                }
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newEmployee = await _employeeService.CreateAsync(CreateEmployee);

            CreateEmployee = new CreateEmployeeDto();

            SuccessMessage = "Employee created successfully!";

            return Page();

        }
    }
}
