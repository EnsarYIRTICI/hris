﻿using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query._Employee
{
    public class GetEmployeeByTcknQuery : IRequest<Employee?>
    {
        public string Tckn { get; set; }

        public GetEmployeeByTcknQuery(string tckn)
        {
            Tckn = tckn;
        }
    }
}
