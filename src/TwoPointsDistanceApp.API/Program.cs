using TwoPointsDistanceApp;
using TwoPointsDistanceApp.Application;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services
    .AddApi()
    .AddApplication();

app.Run();