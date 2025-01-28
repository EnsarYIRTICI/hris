
using Azure.Core;
using hris.Security.Application.Command;
using hris.Security.Application.Dto;
using hris.Security.Application.Query;
using hris.Staff.Domain.Entities;
using MediatR;
using System.Security.Claims;

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
                result.ErrorMessage = "Token is invalid.";
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
            var claims = new List<Claim>
            {
                new Claim("EmployeeId", employee.Id.ToString()),
                new Claim("LastPasswordChange", employee.LastPasswordChange?.ToString() ?? string.Empty)
            };

            return await _mediator.Send(new GenerateTokenCommand(claims));
        }


    }
}
