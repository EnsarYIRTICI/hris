namespace hris.Seed.Domain.Exceptions._Position
{
    public class PositionNotFoundException : Exception
    {
        public PositionNotFoundException(string positionName)
            : base($"Position '{positionName}' was not found.") { }

        public PositionNotFoundException(int positionId)
            : base($"Position with ID '{positionId}' was not found.") { }

        public PositionNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }

}
