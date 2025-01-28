using hris.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Staff.Application.Query._EmployeeDocument.Handler
{
    public class GetEmployeeDocumentTotalCountQueryHandler : IRequestHandler<GetEmployeeDocumentTotalCountQuery, int>
    {
        private readonly AppDbContext _context;

        public GetEmployeeDocumentTotalCountQueryHandler(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(GetEmployeeDocumentTotalCountQuery request, CancellationToken cancellationToken)
        {
            return await _context.EmployeeDocuments.CountAsync(cancellationToken);
        }
    }
}
