namespace hris.Seed.Domain.Exceptions
{
    public class EmailTypeNotFoundException : Exception
    {
        private const string DefaultMessage = "Personal EmailType could not be found.";

        public EmailTypeNotFoundException() : base(DefaultMessage) { }

        public EmailTypeNotFoundException(string message) : base(message) { }

        public EmailTypeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

}
