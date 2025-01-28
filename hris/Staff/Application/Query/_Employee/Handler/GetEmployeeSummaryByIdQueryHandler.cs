using hris.Staff.Application.Dto._Employee;
using hris.Staff.Application.Query._Employee;
using hris.Staff.Application.Query._EmployeeEmail;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Staff.Application.Query._Employee.Handler
{
    public class GetEmployeeSummaryByIdQueryHandler : IRequestHandler<GetEmployeeSummaryByIdQuery, EmployeeSummary?>
    {
        private readonly IMediator _mediator;

        public GetEmployeeSummaryByIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<EmployeeSummary?> Handle(GetEmployeeSummaryByIdQuery request, CancellationToken cancellationToken)
        {
            // Çalışanı getir
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(request.EmployeeId), cancellationToken);

            if (employee == null)
            {
                return null;
            }

            // Geçerli e-posta adresini getir
            var validatedEmail = await _mediator.Send(new GetValidEmailByEmployeeIdQuery(request.EmployeeId), cancellationToken);

            if (validatedEmail == null)
            {
                return null;
            }

            // Çalışan özetini döndür
            return new EmployeeSummary
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                LastPasswordChange = employee.LastPasswordChange,
                Email = validatedEmail.Email
            };
        }
    }
}
