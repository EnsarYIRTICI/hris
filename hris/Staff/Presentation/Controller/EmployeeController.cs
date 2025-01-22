using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using hris.Staff.Domain;
using hris.Staff.Application;
using hris.Staff.Application.Service;
using hris.Staff.Domain.Entities;

namespace hris.Staff.Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;


        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

    }
}
