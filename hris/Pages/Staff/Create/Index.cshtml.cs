using hris.Pages.PageModels;
using hris.Seed.Application.Service;
using hris.Seed.Domain.Entities;
using hris.Staff.Application.Dto;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hris.Pages.Staff.Create
{
    public class IndexModel : BreadcrumbPageModel
    {
        [BindProperty]
        public CreateEmployeeDto CreateEmployee { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? DepartmentId { get; set; }


        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; } 

        public List<EmailType> EmailTypes { get; set; }
        public List<PhoneNumberType> PhoneNumberTypes { get; set; }
        public List<Department> Departments { get; set; }
        public List<Position> Positions { get; set; } 
        

        private readonly EmployeeService _employeeService;      
        private readonly EmailTypeService _emailTypeService;      
        private readonly PhoneNumberTypeService _phoneNumberTypeService;
        private readonly DepartmentService _departmentService;
        private readonly PositionService _positionService;

        public IndexModel(
            EmployeeService employeeService,     
            EmailTypeService emailTypeService,
            PhoneNumberTypeService phoneNumberTypeService,
            DepartmentService departmentService,
            PositionService positionService
            )
        {
            _employeeService = employeeService;       
            _emailTypeService = emailTypeService;
            _phoneNumberTypeService = phoneNumberTypeService;
            _departmentService = departmentService;
            _positionService = positionService;

        }

        public async Task Init(bool clear = true)
        {
            AddBreadcrumb("Home", "/");
            AddBreadcrumb("Staff", "/staff");
            AddBreadcrumb("Create Employee");

            if (clear)
            {
                CreateEmployee = new CreateEmployeeDto();
            }

            EmailTypes = await _emailTypeService.GetAllAsync();
            Departments = await _departmentService.GetAllAsync();
            PhoneNumberTypes = await _phoneNumberTypeService.GetAllAsync();

            if (DepartmentId.HasValue)
            {
                Positions = await _positionService.GetAllByDepartmentIdAsync(DepartmentId.Value);

                foreach (var position in Positions)
                {
                    Console.WriteLine(position.Name);

                }

            }
            else
            {
                Positions = new List<Position>();
            }
        }

        public async Task OnGet()
        {
            try
            {
                await Init();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
          
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try {

                if (!ModelState.IsValid)
                {
                    await Init(false);

                    return Page();
                }

                var newEmployee = await _employeeService.CreateAsync(CreateEmployee);

                SuccessMessage = "Employee created successfully!";

                await Init();

            }
            catch (Exception ex) 
            {
                ErrorMessage = ex.Message;   
                
            }

            return Page();
        }

    }

}
