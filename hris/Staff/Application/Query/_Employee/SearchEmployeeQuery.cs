using hris.Staff.Application.Dto._Employee;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query._Employee
{
    public class SearchEmployeeQuery : IRequest<List<EmployeeSummary>>
    {
        public string SearchQuery { get; }

        public SearchEmployeeQuery(string searchQuery)
        {
            SearchQuery = searchQuery;
        }
    }
}
