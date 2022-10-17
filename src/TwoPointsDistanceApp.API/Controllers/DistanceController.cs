using Microsoft.AspNetCore.Mvc;

namespace TwoPointsDistanceApp.Controllers;

[ApiController]
[Route("[controller]")]
public class DistanceController
{
    [HttpGet("calculation")]
    public async Task<object> Calculate()
        => await _getAllToDosHandler.Handle(new GetAllToDos());
}