namespace TwoPointsDistanceApp.Domain.Exceptions;

internal class InvalidLengthValueException : DomainException
{
    public InvalidLengthValueException(double value) : base($"Invalid length value: {value}")
    {
    }
}