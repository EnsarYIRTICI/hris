using hris.Database;
using hris.Security.Application.Service;
using hris.Security.Domain.Exceptions;
using hris.Staff.Application.Query;
using hris.Staff.Application.Query._EmployeePassword;
using hris.Staff.Domain.Exceptions;
using hris.Staff.Domain.Exceptions._Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace hris.Security.Application.Query.Handler
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly AppDbContext _context;
        private readonly EmployeeTokenService _tokenService;
        private readonly IMediator _mediator;

        public LoginQueryHandler(
            AppDbContext context,
            EmployeeTokenService tokenService,
            IMediator mediator
            )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _mediator = mediator;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            // E-Postayı doğrula
            var employeeEmail = await _context.EmployeeEmails
                .FirstOrDefaultAsync(e => e.Email == request.Email && e.IsValid, cancellationToken);

            if (employeeEmail == null)
            {
                throw new InvalidCredentialsException();
            }

            // Şifreyi doğrula
            var employeePassword = await _context.EmployeePasswords
                .FirstOrDefaultAsync(p => p.EmployeeId == employeeEmail.EmployeeId && p.IsValid, cancellationToken);

            if (employeePassword == null ||
            !await _mediator.Send(new VerifyPasswordHashQuery(request.Password, employeePassword.PasswordHash, employeePassword.PasswordSalt)))
            {
                throw new InvalidCredentialsException();
            }

            // Çalışan bilgilerini al
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeEmail.EmployeeId, cancellationToken);

            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }

            // Token oluştur
            return await _tokenService.GenerateToken(employee);
        }
    }
}
