using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TwoPointsDistanceApp.Controllers.Requests;

namespace TwoPointsDistanceApp.API.IntegrationTests.Common.EndpointOperations;

public static class DistanceEndpointOperations
{
    private static readonly Uri Uri = new("http://localhost/distance");

    public static async Task<(HttpResponseMessage ResponseMessage, TResult Result)> CalculateDistance<TResult>(
        this HttpClient httpClient,
        CalculateDistanceRequest request)
    {
        var response = await httpClient.PutAsJsonAsync(new Uri($"{Uri}/calculation"), request);

        return (response, await response.Content.ReadFromJsonAsync<TResult>());
    }
}