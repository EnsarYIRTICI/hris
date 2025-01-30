using hris.Seed.Application.Dto._Department;
using MediatR;

namespace hris.Seed.Application.Query._Department
{
    public class SearchDepartmentsQuery : IRequest<List<DepartmentSummaryDto>>
    {
        public string SearchTerm { get; set; }

        public SearchDepartmentsQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}
