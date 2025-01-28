namespace hris.Staff.Domain.Exceptions._EmployeeEmail
{
    public class ValidatedEmailNotFoundException : Exception
    {
        public ValidatedEmailNotFoundException() : base("The validated email for the specified employee was not found.") { }

        public ValidatedEmailNotFoundException(string message) : base(message) { }

        public ValidatedEmailNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
