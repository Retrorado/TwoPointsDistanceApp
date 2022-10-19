using TwoPointsDistanceApp.Domain.ValueObjects;

namespace TwoPointsDistanceApp.Controllers.Requests;

public record CoordinatesDto(double Latitude, double Longitude)
{
    public Coordinates ToDomainContract() => Coordinates.Create(Latitude, Longitude);
}