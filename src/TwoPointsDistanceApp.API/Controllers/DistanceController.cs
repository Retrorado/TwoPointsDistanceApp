using Microsoft.AspNetCore.Mvc;
using TwoPointsDistanceApp.Application.Common.CQRS;
using TwoPointsDistanceApp.Application.Features.Distance.Queries.Calculation;
using TwoPointsDistanceApp.Controllers.Requests;

namespace TwoPointsDistanceApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DistanceController : ControllerBase
{
    private readonly IQueryDispatcher _queryDispatcher;

    public DistanceController(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [HttpPut("calculation")]
    public async Task<object> Calculate(CalculateDistanceRequest request)
        => await _queryDispatcher.ExecuteAsync<CalculateDistance, double>(request.ToCommand());
}