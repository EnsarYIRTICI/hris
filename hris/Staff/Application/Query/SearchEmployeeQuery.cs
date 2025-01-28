using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query
{
    public class SearchEmployeeQuery : IRequest<List<Employee>>
    {
        public string SearchQuery { get; }

        public SearchEmployeeQuery(string searchQuery)
        {
            SearchQuery = searchQuery;
        }
    }
}
