namespace TwoPointsDistanceApp.Responses;

public record ErrorApiResponse
{
    public string Code { get; set; }

    public string Details { get; set; }
}