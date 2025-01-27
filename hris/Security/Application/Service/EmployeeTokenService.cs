using hris.Security.Application.Command;
using hris.Security.Application.Dto;
using hris.Staff.Domain.Entities;
using Microsoft.IdentityModel.Tokens;


public class EmployeeTokenService
{
    private readonly TokenValidator _tokenValidator;
    private readonly EmployeeValidator _employeeValidationService;
    private readonly TokenGenerator _tokenGenerator;

    public EmployeeTokenService(
        TokenValidator tokenValidator,
        EmployeeValidator employeeValidationService,
        TokenGenerator tokenGenerator)
    {
        _tokenValidator = tokenValidator;
        _employeeValidationService = employeeValidationService;
        _tokenGenerator = tokenGenerator;
    }


    public async Task<EmployeeTokenValidationResult> ValidateToken(string token)
    {
        var result = new EmployeeTokenValidationResult();

        var principal = _tokenValidator.Validate(token, out var validatedToken);

        if (principal == null)
        {
            result.ErrorMessage = "Token is invalid.";
            result.IsValid = false;
            return result;
        }

        var (isValid, errorMessage, employee) = await _employeeValidationService.ValidateAsync(principal);

        result.IsValid = isValid;
        result.ErrorMessage = errorMessage;
        result.Employee = employee;

        return result;
    }

    public string GenerateToken(Employee employee)
    {
        var tokenData = new EmployeeTokenClaim
        {
            EmployeeId = employee.Id.ToString(),
            LastPasswordChange = employee.LastPasswordChange
        };

        return _tokenGenerator.Generate(tokenData);
    }
}
