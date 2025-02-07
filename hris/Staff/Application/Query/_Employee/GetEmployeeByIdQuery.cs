﻿using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query._Employee
{
    public class GetEmployeeByIdQuery : IRequest<Employee?>
    {
        public int EmployeeId { get; }

        public GetEmployeeByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
