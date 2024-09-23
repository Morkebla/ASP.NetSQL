using GameStore2.Api.Data;
using GameStore2.Api.EndPoints;
using GameStore2.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

await app.Services.InitialiseDbAsync();

app.MapGamesEndPoints();

app.Run();
