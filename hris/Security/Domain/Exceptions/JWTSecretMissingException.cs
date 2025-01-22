namespace hris.Security.Domain.Exceptions
{
    public class JWTSecretMissingException : Exception
    {
        private const string DefaultMessage = "The JWT_SECRET configuration is missing. Please ensure that the secret key is provided in the application settings.";

        public JWTSecretMissingException()
            : base(DefaultMessage) // Varsayılan mesaj
        {
        }

        public JWTSecretMissingException(string message)
            : base(message) // Özelleştirilmiş mesaj
        {
        }

        public JWTSecretMissingException(string message, Exception innerException)
            : base(message, innerException) // İç istisna ile mesaj
        {
        }
    }
}