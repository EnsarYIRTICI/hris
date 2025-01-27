
using hris.Security.Application.Command;
using hris.Security.Application.Dto;
using hris.Security.Application.Query;
using hris.Staff.Domain.Entities;
using MediatR;

namespace hris.Security.Application.Service
{
    public class EmployeeTokenService
    {
        private readonly IMediator _mediator;

        public EmployeeTokenService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<EmployeeTokenValidationResult> ValidateToken(string token)
        {
            var result = new EmployeeTokenValidationResult();

            var principal = await _mediator.Send(new ValidateTokenQuery(token));

            if (principal == null)
            {
                result.ErrorMessage = "Token geçersiz.";
                result.IsValid = false;
                return result;
            }

            var (isValid, errorMessage, employee) = await _mediator.Send(new ValidateEmployeeQuery(principal));

            result.IsValid = isValid;
            result.ErrorMessage = errorMessage;
            result.Employee = employee;

            return result;
        }

        public async Task<string> GenerateToken(Employee employee)
        {
            return await _mediator.Send(new GenerateTokenCommand(
                employee.Id.ToString(),
                employee.LastPasswordChange
            ));
        }
    }
}
