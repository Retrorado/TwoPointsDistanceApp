namespace TwoPointsDistanceApp.Domain.Exceptions;

internal class InvalidLengthValueException : Exception
{
    public InvalidLengthValueException(double value) : base($"Invalid length value: {value}")
    {
    }
}