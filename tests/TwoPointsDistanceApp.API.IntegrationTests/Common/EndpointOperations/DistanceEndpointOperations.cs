using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TwoPointsDistanceApp.Application.Features.Distance.Queries.DTOs;
using TwoPointsDistanceApp.Controllers.Requests;

namespace TwoPointsDistanceApp.API.IntegrationTests.Common.EndpointOperations;

public static class DistanceEndpointOperations
{
    private static readonly Uri Uri = new("http://localhost/distance");

    public static async Task<(HttpResponseMessage ResponseMessage, LengthUnitDto Result)> CalculateDistance(
        this HttpClient httpClient,
        CalculateDistanceRequest request)
    {
        var response = await httpClient.PutAsJsonAsync(new Uri($"{Uri}/calculation"), request);

        return (response, await response.Content.ReadFromJsonAsync<LengthUnitDto>());
    }
}